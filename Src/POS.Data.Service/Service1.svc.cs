using System;
using System.Collections.Generic;
using System.Data.Objects;
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

		[OperationContract]
		public Guid Login(string password)
		{
			return Guid.Empty;
		}



		[OperationContract]
		public int Delete(Tables tab, string item)
		{
			return ApplyAction(tab, Action.Del, item);
		}
		[OperationContract]
		public int Insert(Tables tab, string item)
		{
			return ApplyAction(tab, Action.Ins, item);
		}
		[OperationContract]
		public int Update(Tables tab, string item)
		{
			return ApplyAction(tab, Action.Upd, item);
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

		private int ApplyAction(Tables tab, Action act, string serializedItem)
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

		private int ApplyAction<T>(Action act, string serializedItem) where T : class, IPersistedModel
		{
			T item = IT.Serializer_Json.Deserialize<T>(serializedItem);
			var repo = new BaseRepository<T>(_connString);
			switch (act)
			{
				case Action.Del: return repo.Delete(item);
				case Action.Ins: return repo.Insert(item);
				case Action.Upd: return repo.Update(item);
			}
			return 0;
		}

		public string Sel_ById<T>(int? id, IdColumn col) where T : class, IPersistedModel
		{
			var repo = new BaseRepository<T>(_connString);

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
		}

		private enum Action
		{
			Del,
			Ins,
			Upd
		}

		#endregion
	}
}
