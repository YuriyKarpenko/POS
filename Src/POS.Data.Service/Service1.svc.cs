using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using POS.Data.Model;
using POS.Data.Repositories;

namespace POS.Data.Service
{
	[ServiceContract]
	[ServiceBehavior(IncludeExceptionDetailInFaults = true)]
	[KnownType(typeof(IPersistedModel))]
	[KnownType(typeof(Division))]
	[KnownType(typeof(User))]
	[KnownType(typeof(UserGroup))]
	public class Service1
	{
		private static string _connString = System.Configuration.ConfigurationManager.ConnectionStrings["POSContext"].ConnectionString;

		private static TRes UsingContext<TRes>(Func<POSContext, TRes> action)
		{
			return POSContext.UsingContext(_connString, action);
		}

		[OperationContract]
		public Guid Login(string password)
		{
			return Guid.Empty;
		}



		[OperationContract]
		public int Delete(Tables tab, string item)
		{
			return ApplyAction(tab, DataAction.Delete, item);
		}
		[OperationContract]
		public int Insert(Tables tab, string item)
		{
			return ApplyAction(tab, DataAction.Insert, item);
		}
		[OperationContract]
		public int Update(Tables tab, string item)
		{
			return ApplyAction(tab, DataAction.Update, item);
		}

		[OperationContract]
		public string Sel_ById(Tables tab, int? id, IdColumn col)
		{
			switch (tab)
			{
				case Tables.Bill: return Sel_ById<Bill>(id, col);
				case Tables.BillItem: return Sel_ById<BillItem>(id, col);
				case Tables.Division: return Sel_ById<Division>(id, col);
				case Tables.MenuGroup: return Sel_ById<MenuGroup>(id, col);
				case Tables.MenuItem: return Sel_ById<MenuItem>(id, col);
				//case Tables.Option: return Sel_ById<>(id, col);
				case Tables.Price: return Sel_ById<Price>(id, col);
				case Tables.PriceList: return Sel_ById<PriceList>(id, col);
				case Tables.User: return Sel_ById<User>(id, col);
				case Tables.UserGroup: return Sel_ById<UserGroup>(id, col);
			}
			return string.Empty;
		}

		#region Universal Actions

		private int ApplyAction(Tables tab, DataAction act, string serializedItem)
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

		private int ApplyAction<T>(DataAction act, string serializedItem) where T : class, IPersistedModel
		{
			T item = IT.Serializer_Json.Deserialize<T>(serializedItem);
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

		public string Sel_ById<T>(int? id, IdColumn col) where T : class, IPersistedModel
		{
			return POSContext.UsingContext(_connString, context =>
			{
				var repo = new BaseRepository<T>(context);

				IEnumerable<T> res = null;

				switch (col)
				{
					case IdColumn.Id:
						res = repo.Select(c => c.Where(i => !id.HasValue || i.Id == id.Value));
						break;
					case IdColumn.DivisionId:
						res = repo.Select(c => c.Where(i => !id.HasValue || i.Id == id.Value));
						break;
				}

				if (res.Any())
				{
					return IT.Serializer_Json.Serialize_ToString(res);
				}

				return string.Empty;
			});
		}

		#endregion
	}
}
