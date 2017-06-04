using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

using IT;

using POS.Data.Model;

namespace POS.Data.Repositories
{
	public interface IRepository<T>
	{
#if USE_GUID
		T Get(Guid id);
#else
		T Get(int id);
#endif
		IEnumerable<T> Select(Func<IOrderedQueryable<T>, IEnumerable<T>> select);
		int Delete(T item);
		int Insert(T item);
		int Update(T item);
	}


	public class BaseRepository<T> : ILog, IRepository<T> where T : class, IPersistedModel
	{
		private readonly POSContext _context;

		public BaseRepository(POSContext context)
		{
			Contract.NotNull(context, nameof(context));
			_context = context;
		}


#if USE_GUID
		public T Get(Guid id)
#else
		public T Get(int id)
#endif
		{
			try
			{
				return _context.Set<T>().Find(id);
			}
			catch (Exception ex)
			{
				this.Error(ex, $"({typeof(T)}.Id = {id})");
				throw;
			}
		}

		public IEnumerable<T> Select(Func<IOrderedQueryable<T>, IEnumerable<T>> select)
		{
			try
			{
				var oSet = _context.Set<T>();

				return select(oSet.AsNoTracking()).ToArray();
			}
			catch (Exception ex)
			{
				this.Error(ex, $"({typeof(T)})");
				throw;
			}
		}

		public int Delete(T value)
		{
			return ApplyAction(DataAction.Delete, value);
		}

		public int Insert(T value)
		{
			return ApplyAction(DataAction.Insert, value);
		}

		public int Update(T value)
		{
			return ApplyAction(DataAction.Update, value);
		}


		protected virtual void OnDelete(T entity) { }
		protected virtual void OnInsert(T entity) { }
		protected virtual void OnUpdate(T entity) { }

		protected virtual int ApplyAction(DataAction act, T item)
		{
			try
			{
				var res = 0;
				if (item != null && IsAccess(act))
				{
					var entry = _context.Entry<T>(item);
					var set = _context.Set<T>();
					set.Attach(item);
					var now = DateTime.Now;
					switch (act)
					{
						case DataAction.Delete:
							OnDelete(item);
							set.Remove(item);
							break;
						case DataAction.Insert:
							item.DateCreated = now;
							item.DateLastModified = now;
							OnInsert(item);
							set.Add(item);
							break;
						case DataAction.Update:
							entry.State = System.Data.Entity.EntityState.Modified;
							item.DateLastModified = now;
							OnUpdate(item);
							break;
					}
				}
				res = EntityFrameworkExceptionHelper.CatchValidationErrors(_context.SaveChanges);
				return res;
			}
			catch (Exception ex)
			{
				this.Error(ex, $"({act}, {item})");
				throw;
			}
		}

		protected virtual bool IsAccess(DataAction act)
		{
			return true;
		}
	}
}
