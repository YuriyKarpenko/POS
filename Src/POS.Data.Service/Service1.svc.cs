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
	//class ServiceBase<T> where T : class, IObjectWithChangeTracker
	//{
	//	public static ModelSem GetContext()
	//	{
	//		Log.ToLog("GetContext() = {0}", System.Configuration.ConfigurationManager.ConnectionStrings["ModelSem"].ConnectionString);

	//		return new ModelSem(System.Configuration.ConfigurationManager.ConnectionStrings["ModelSem"].ConnectionString);
	//	}

	//	public bool Del(T value, Predicate<ModelSem> isAccess)
	//	{
	//		Log.ToLog("Del({0})", value);

	//		using (ModelSem context = ServiceBase<IObjectWithChangeTracker>.GetContext())
	//		{
	//			try
	//			{
	//				ObjectSet<T> oSet = context.CreateObjectSet<T>();

	//				if (isAccess(context))
	//				{
	//					oSet.DeleteObject(value);

	//					context.SaveChanges();
	//				}
	//				return true;
	//			}
	//			catch (Exception ex)
	//			{
	//				Log.ToLog(true, "Del({0}) : {1}", value, ex);
	//			}
	//		}

	//		return false;
	//	}

	//	public bool Ins(T value, Predicate<ModelSem> isAccess)
	//	{
	//		Log.ToLog("Ins({0})", value);

	//		using (ModelSem context = ServiceBase<IObjectWithChangeTracker>.GetContext())
	//		{
	//			try
	//			{
	//				ObjectSet<T> oSet = context.CreateObjectSet<T>();

	//				if (isAccess(context))
	//				{
	//					oSet.AddObject(value);

	//					context.SaveChanges();
	//				}
	//				return true;
	//			}
	//			catch (Exception ex)
	//			{
	//				Log.ToLog(true, "Ins({0}) : {1}", value, ex);
	//			}
	//		}

	//		return false;
	//	}

	//	public List<T> Sel(Func<ModelSem, ObjectResult<T>> select)
	//	{
	//		Log.ToLog("Sel({0})", typeof(T));

	//		using (ModelSem context = ServiceBase<IObjectWithChangeTracker>.GetContext())
	//		{
	//			try
	//			{
	//				//ObjectSet<T> oSet = context.CreateObjectSet<T>();

	//				return select(context).ToList();
	//			}
	//			catch (Exception ex)
	//			{
	//				Log.ToLog(true, "Sel() : {0}", ex);
	//			}

	//			return null;// new ObjectResult<T>();
	//		}
	//	}

	//	public bool Upd(T value, Predicate<ModelSem> isAccess)
	//	{
	//		using (ModelSem context = ServiceBase<IObjectWithChangeTracker>.GetContext())
	//		{
	//			Log.ToLog("Upd({0})", value);

	//			try
	//			{
	//				ObjectSet<T> oSet = context.CreateObjectSet<T>();

	//				if (isAccess(context))
	//				{
	//					oSet.ApplyChanges(value);

	//					context.SaveChanges();
	//				}
	//				return true;
	//			}
	//			catch (Exception ex)
	//			{
	//				Log.ToLog(true, "Upd({0}) : {1}", value, ex);
	//			}
	//		}

	//		return false;
	//	}


	//}

	[ServiceContract]
	[KnownType(typeof(Division))]
	[KnownType(typeof(User))]
	[KnownType(typeof(UserGroup))]
	public class Service1
	{
		private static string _connString = System.Configuration.ConfigurationManager.ConnectionStrings["ModelSem"].ConnectionString;

		//[OperationContract]
		//public void Save()
		//{
		//    using (ModelSem context = ServiceBase<IObjectWithChangeTracker>.GetContext())
		//    {
		//        try
		//        {
		//            context.SaveChanges();
		//        }
		//        catch (Exception ex)
		//        {
		//            Trace.TraceError("Error in Save() : {0}", ex);
		//        }
		//    }
		//}

		#region Permission
		
		//[OperationContract]
		public bool IsDel(Tables tab, Guid userId)
		{
			return false;
		}

		#endregion

		[OperationContract]
		public Guid Login(string password)
		{
			return Guid.Empty;
		}

		#region Division

		public BaseRepository<Division> Divisions = new BaseRepository<Division>(_connString);

		[OperationContract]
		public int DivisionDel(Division value) { return Divisions.Delete(value); }

		[OperationContract]
		public int DivisionIns(Division value) { return Divisions.Insert(value); }

		[OperationContract]
		public int DivisionUpd(Division value) { return Divisions.Update(value); }

		[OperationContract]
		public IEnumerable<Division> DivisionsGet(int? id) { return Divisions.Select(c => c.Where(i => !id.HasValue || i.Id == id.Value)); }

		#endregion



		#region UserGroup

		BaseRepository<UserGroup> UserGroups = new BaseRepository<UserGroup>(_connString);

		[OperationContract]
		public int UserGroupDel(UserGroup value) { return UserGroups.Delete(value); }

		[OperationContract]
		public int UserGroupIns(UserGroup value) { return UserGroups.Insert(value); }

		[OperationContract]
		public int UserGroupUpd(UserGroup value) { return UserGroups.Update(value); }

		[OperationContract]
		public IEnumerable<UserGroup> UserGroupGet(int? id) { return UserGroups.Select(c => c.Where(i=> !id.HasValue || i.Id == id.Value)); }

		#endregion

		#region User

		BaseRepository<User> Users = new BaseRepository<User>(_connString);

		[OperationContract]
		public int UserDel(User value) { return Users.Delete(value); }

		[OperationContract]
		public int UserIns(User value) { return Users.Insert(value); }

		[OperationContract]
		public IEnumerable<User> UserSel(int? id) { return Users.Select(c => c.Where(i => !id.HasValue || i.Id == id.Value)); }

		[OperationContract]
		public int UserUpd(User value) { return Users.Update(value); }

		#endregion
	}
}
