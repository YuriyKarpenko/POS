﻿using System;
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

		private static TRes UsingContext<TRes>(Func<POSContext, TRes> action)
		{
			return POSContext.UsingContext(_connString, action);
		}

		[OperationContract]
		public ResponceAPI UseAPI(RequestAPI request)
		{
			var res = new ResponceAPI();
			try
			{
				//	validation request

				res.ResultQuantity = POSContext.UsingContext(_connString, con => {
					//	identity user
					User user = null;
					this.Debug($"({request.Action} | {user})");

					switch (request.Action)
					{
						case ActionAPI.Dictionary_Get:
							//	TODO:	mast use where
							res.Data = Sel_ById(request.Table, request.Where);
							break;

						case ActionAPI.Dictionary_Set:
							return ApplyAction(request.Table, request.DataAction, request.Data);
					}

					return 0;
				});
			}
			catch (Exception ex)
			{
				this.Error(ex, $"({request})");
				res.Error = ex;
				if (res.Result == ResultAPI.Ok)
				{
					res.Result = ResultAPI.ErrorOther;
				}
				//throw;
			}

			return res;
		}


		[OperationContract]
		public string Sel_ById(Tables tab, Dictionary<string, object> where)
		{
			switch (tab)
			{
				case Tables.Bill: return Sel_ById<Bill>(where);
				case Tables.BillItem: return Sel_ById<BillItem>(where);
				case Tables.Division: return Sel_ById<Division>(where);
				case Tables.MenuGroup: return Sel_ById<MenuGroup>(where);
				case Tables.MenuItem: return Sel_ById<MenuItem>(where);
				//case Tables.Option: return Sel_ById<>(where);
				case Tables.Price: return Sel_ById<Price>(where);
				case Tables.PriceList: return Sel_ById<PriceList>(where);
				case Tables.User: return Sel_ById<User>(where);
				case Tables.UserGroup: return Sel_ById<UserGroup>(where);
			}
			return null;
		}

		[OperationContract]
		public int ApplyAction(Tables tab, DataAction act, string serializedItem)
		{
			switch (tab)
			{
				case Tables.Bill: return ApplyAction<Bill>(act, serializedItem);
				case Tables.BillItem: return ApplyAction<BillItem>(act, serializedItem);
				case Tables.Division: return ApplyAction<Division>(act, serializedItem);
				case Tables.MenuGroup: return ApplyAction<MenuGroup>(act, serializedItem);
				case Tables.MenuItem: return ApplyAction<MenuItem>(act, serializedItem);
				//case Tables.Option: return ApplyAction<Option>(obj);
				case Tables.Price: return ApplyAction<Price>(act, serializedItem);
				case Tables.PriceList: return ApplyAction<PriceList>(act, serializedItem);
				case Tables.User: return ApplyAction<User>(act, serializedItem);
				case Tables.UserGroup: return ApplyAction<UserGroup>(act, serializedItem);
			}
			return 0;
		}

		#region Universal Actions

		private int ApplyAction<T>(DataAction act, string serializedItem) where T : class, IPersistedModel
		{
			T item = JsonConvert.DeserializeObject<T>(serializedItem);
			if (item != null)
			{
				return POSContext.UsingContext(_connString, context =>
				{
					var repo = new BaseRepository<T>(context);
					switch (act)
					{
						case DataAction.Delete: return repo.Delete(item);
						case DataAction.Insert: return repo.Insert(item);
						case DataAction.Update: return repo.Update(item);
					}
					return 0;
				});
			}
			return 0;
		}

		public string Sel_ById<T>(Dictionary<string, object> where) where T : class, IPersistedModel
		{
			return POSContext.UsingContext(_connString, context =>
			{
				var repo = new BaseRepository<T>(context);

				IEnumerable<T> res = null;

				var expr = GetWhere<T>(where);
						res = repo.Select(c => c.Where(expr));

				if (res.Any())
				{
					return JsonConvert.SerializeObject(res);
				}

				return null;
			});
		}

		private Expression<Func<T, bool>> GetWhere<T>(Dictionary<string, object> where)
		{
			this.Debug("()");
			try
			{
				var param = Expression.Parameter(typeof(T), "item");

				var eConst = Expression.Constant(true, typeof(bool));
				var body = Expression.Equal(eConst, eConst);
				if (where?.Any() == true)
				{
					foreach (var kv in where) {
						var pi = typeof(T).GetProperty(kv.Key);

						var left = Expression.Property(param, pi);
						var right = Expression.Constant(kv.Value, pi.PropertyType);
						//right = Expression.Constant(right, pi.PropertyType);
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
