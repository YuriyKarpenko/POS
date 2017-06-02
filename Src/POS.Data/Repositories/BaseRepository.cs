using System;
using System.Collections.Generic;
using System.Linq;

using IT;

using POS.Data.Model;

namespace POS.Data.Repositories
{
	public class BaseRepository<T> : ILog where T : PersistedModel
	{
		private string _connStr;
		public BaseRepository(string connStr)
		{
			Contract.NotIsNullOrEmpty(connStr, nameof(connStr));
			_connStr = connStr;
		}


#if USE_GUID
		public T Get(Guid id)
#else
		public T Get(int id)
#endif
		{
			this.Debug("({0}.Id = {1}) ", typeof(T), id);

			return UsingContext(context =>
			{
				try
				{
					return context.Set<T>().Find(id);
				}
				catch (Exception ex)
				{
					this.Error(ex, "()");
				}

				return null;// new ObjectResult<T>();
			});
		}
		public IEnumerable<T> Sel(Func<IOrderedQueryable<T>, IEnumerable<T>> select)
		{
			this.Debug("Sel({0})", typeof(T));

			return UsingContext(context =>
			{
				try
				{
					var oSet = context.Set<T>();

					return select(oSet);
				}
				catch (Exception ex)
				{
					this.Error(ex, "()");
				}

				return null;// new ObjectResult<T>();
			});
		}

		protected virtual void OnDelete(T entity) { }
		public int Del(T value)
		{
			this.Debug("({0})", value);

			return UsingContext(context =>
			{
				try
				{
					if (IsAccess(context))
					{
						OnDelete(value);
						context.Set<T>().Remove(value);
						return EntityFrameworkExceptionHelper.CatchValidationErrors(context.SaveChanges);
					}
				}
				catch (Exception ex)
				{
					this.Error(ex, $"({value})");
				}

				return 0;
			});
		}

		protected virtual void OnInsert(T entity) { }
		public int Ins(T value)
		{
			this.Debug("({0})", value);

			return UsingContext(context =>
			{
				try
				{
					if (IsAccess(context))
					{
						var now = DateTime.Now;
						value.DateCreated = now;
						value.DateLastModified = now;

						OnInsert(value);

						var oSet = context.Set<T>();
						oSet.Add(value);
						return EntityFrameworkExceptionHelper.CatchValidationErrors(context.SaveChanges);
					}
				}
				catch (Exception ex)
				{
					this.Error(ex, $"({value})");
				}
				return 0;
			});
		}

		protected virtual void OnUpdate(T entity) { }
		public int Upd(T value)
		{
			return UsingContext(context =>
			{
				this.Debug("({0})", value);

				try
				{
					if (IsAccess(context))
					{
						value.DateLastModified = DateTime.Now;

						OnUpdate(value);

						var oSet = context.Set<T>();
						oSet.Attach(value);
						return EntityFrameworkExceptionHelper.CatchValidationErrors(context.SaveChanges);
					}
				}
				catch (Exception ex)
				{
					this.Error(ex, $"({value})");
				}

				return 0;
			});
		}


		protected virtual bool IsAccess(POSContext context)
		{
			return true;
		}

		protected TRes UsingContext<TRes>(Func<POSContext, TRes> action)
		{
			try
			{
				using (var conn = new POSContext(_connStr))
				{
					return action(conn);
				}
			}
			catch (Exception ex)
			{
				this.Error(ex, $"({_connStr})");
				throw;
			}
		}
	}
}
