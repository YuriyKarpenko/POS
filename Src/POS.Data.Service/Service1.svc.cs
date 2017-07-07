using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

using Newtonsoft.Json;
using IT;

using POS.Data.Model;
using POS.Data.Repositories;

namespace POS.Data.Service
{
	[ServiceContract]
	[ServiceBehavior(IncludeExceptionDetailInFaults = true)]
	[KnownType(typeof(IPersistedModel))]
	[KnownType(typeof(ResponceAPI))]
	[KnownType(typeof(RequestAPI))]
	public class Service1 : ILog
	{
		private static string _connString = System.Configuration.ConfigurationManager.ConnectionStrings["POSContext"].ConnectionString;

		private static ResponceAPI UsingContext(Func<POSContext, ResponceAPI, int> action)
		{
			var res = new ResponceAPI() { Result = ResultAPI.Ok };

			try
			{
				POSContext.UsingContext(_connString, c => action(c, res));
			}
			catch (Exception ex)
			{
				res.Error = ex.Message;
				res.Result = ResultAPI.ErrorDB;
			}

			return res;
		}

		[OperationContract]
		public ResponceAPI UseAPI(RequestAPI request)
		{
			try
			{
				//	validation request

				//	identity user
				//var conn = POSContext.Context(_connString);
				User user = null;
				this.Debug($"({request.Action} | {user})");

				return ApplyAction(request);
			}
			catch (Exception ex)
			{
				this.Error(ex, $"({request})");
				return new ResponceAPI() { Error = ex.Message, Result = ResultAPI.ErrorOther };
			}
		}


		#region Universal Actions

		//	определение типа сущностей
		private ResponceAPI ApplyAction(RequestAPI request)
		{
			switch (request.Table)
			{
				case Tables.Bill: return ApplyAction<Bill>(request);
				case Tables.BillItem: return ApplyAction<BillItem>(request);
				case Tables.Division: return ApplyAction<Division>(request);
				case Tables.MenuGroup: return ApplyAction<MenuGroup>(request);
				case Tables.MenuItem: return ApplyAction<MenuItem>(request);
				//case Tables.Option: return ApplyAction<Option>(request);
				case Tables.Price: return ApplyAction<Price>(request);
				case Tables.PriceList: return ApplyAction<PriceList>(request);
				case Tables.User: return ApplyAction<User>(request);
				case Tables.UserGroup: return ApplyAction<UserGroup>(request);
			}
			return new ResponceAPI() { Result = ResultAPI.ErrorOther };
		}

		private ResponceAPI ApplyAction<T>(RequestAPI request) where T : class, IPersistedModel
		{
			return UsingContext((context, res) =>
			{
				var repo = new BaseRepository<T>(context);
				switch (request.Action)
				{
					case ActionAPI.Dictionary_Get:
						//	TODO:	mast use where
						var expr = GetWhere<T>(request);
						var list = repo.Select(c => c.Where(expr));
						if (list.Any())
						{
							res.ResultQuantity = list.Count();
							res.Data = JsonConvert.SerializeObject(list);
						}
						break;

					case ActionAPI.Dictionary_Set:
						T item = JsonConvert.DeserializeObject<T>(request.Data);
						if (item != null)
						{
							res.ResultQuantity = repo.ApplyAction(request.DataAction, item);
						}
						break;
				}

				return 0;	//	fake
			});
		}


		private Expression<Func<T, bool>> GetWhere<T>(RequestAPI request)
		{
			this.Debug("()");
			try
			{
				var param = Expression.Parameter(typeof(T), "item");

				var eConst = Expression.Constant(true, typeof(bool));
				var body = Expression.Equal(eConst, eConst);
				if (request.WhereEqual?.Any() == true)
				{
					foreach (var kv in request.WhereEqual)
					{
						var pi = typeof(T).GetProperty(kv.Key);

						var left = Expression.Property(param, pi);
						var right = Expression.Constant(kv.Value, pi.PropertyType);
						var e = Expression.Equal(left, right);
						body = Expression.And(body, e);
					}
				}
				return Expression.Lambda<Func<T, bool>>(body, param);
			}
			catch (Exception ex)
			{
				this.Error(ex, "()");
				throw;
			}
		}


		#endregion
	}
}
