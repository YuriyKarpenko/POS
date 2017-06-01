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

namespace POS.Data.Service
{
	class ServiceBase<T> where T : class, IObjectWithChangeTracker
	{
		public static ModelSem GetContext()
		{
			Log.ToLog("GetContext() = {0}", System.Configuration.ConfigurationManager.ConnectionStrings["ModelSem"].ConnectionString);

			return new ModelSem(System.Configuration.ConfigurationManager.ConnectionStrings["ModelSem"].ConnectionString);
		}

		public bool Del(T value, Predicate<ModelSem> isAccess)
		{
			Log.ToLog("Del({0})", value);

			using (ModelSem context = ServiceBase<IObjectWithChangeTracker>.GetContext())
			{
				try
				{
					ObjectSet<T> oSet = context.CreateObjectSet<T>();

					if (isAccess(context))
					{
						oSet.DeleteObject(value);

						context.SaveChanges();
					}
					return true;
				}
				catch (Exception ex)
				{
					Log.ToLog(true, "Del({0}) : {1}", value, ex);
				}
			}

			return false;
		}

		public bool Ins(T value, Predicate<ModelSem> isAccess)
		{
			Log.ToLog("Ins({0})", value);

			using (ModelSem context = ServiceBase<IObjectWithChangeTracker>.GetContext())
			{
				try
				{
					ObjectSet<T> oSet = context.CreateObjectSet<T>();

					if (isAccess(context))
					{
						oSet.AddObject(value);

						context.SaveChanges();
					}
					return true;
				}
				catch (Exception ex)
				{
					Log.ToLog(true, "Ins({0}) : {1}", value, ex);
				}
			}

			return false;
		}

		public List<T> Sel(Func<ModelSem, ObjectResult<T>> select)
		{
			Log.ToLog("Sel({0})", typeof(T));

			using (ModelSem context = ServiceBase<IObjectWithChangeTracker>.GetContext())
			{
				try
				{
					//ObjectSet<T> oSet = context.CreateObjectSet<T>();

					return select(context).ToList();
				}
				catch (Exception ex)
				{
					Log.ToLog(true, "Sel() : {0}", ex);
				}

				return null;// new ObjectResult<T>();
			}
		}

		public bool Upd(T value, Predicate<ModelSem> isAccess)
		{
			using (ModelSem context = ServiceBase<IObjectWithChangeTracker>.GetContext())
			{
				Log.ToLog("Upd({0})", value);

				try
				{
					ObjectSet<T> oSet = context.CreateObjectSet<T>();

					if (isAccess(context))
					{
						oSet.ApplyChanges(value);

						context.SaveChanges();
					}
					return true;
				}
				catch (Exception ex)
				{
					Log.ToLog(true, "Upd({0}) : {1}", value, ex);
				}
			}

			return false;
		}


	}

	[ServiceContract]
	[KnownType(typeof(Types.Division))]
	[KnownType(typeof(Types.User))]
	[KnownType(typeof(Types.UserGroup))]
	public class Service1
	{

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

		ServiceBase<Division> Divisions = new ServiceBase<Division>();

		[OperationContract]
		public bool DivisionDel(Types.Division value) { return Divisions.Del(value, p=>true); }

		[OperationContract]
		public bool DivisionIns(Types.Division value) { return Divisions.Ins(value, p=>true); }

		[OperationContract]
		public bool DivisionUpd(Types.Division value) { return Divisions.Upd(value, p=>true); }

		[OperationContract]
		public List<Types.Division> DivisionsGet(Guid? id) { return Divisions.Sel(c => c.DivisionsGet(null, null, null, false)); }

		#endregion



		#region UserGroup

		ServiceBase<UserGroup> UserGroups = new ServiceBase<UserGroup>();

		[OperationContract]
		public bool UserGroupDel(UserGroup value) { return UserGroups.Del(value, p=>true); }

		[OperationContract]
		public bool UserGroupIns(UserGroup value) { return UserGroups.Ins(value, p=>true); }

		[OperationContract]
		public bool UserGroupUpd(UserGroup value) { return UserGroups.Upd(value, p=>true); }

		[OperationContract]
		public List<Types.UserGroup> UserGroupGet(Guid? id) { return UserGroups.Sel(c => c.UserGroupsGet(null, null)); }

		#endregion

		#region User

		ServiceBase<User> Users = new ServiceBase<User>();

		[OperationContract]
		public bool UserDel(User value) { return Users.Del(value, p=>true); }

		[OperationContract]
		public bool UserIns(User value) { return Users.Ins(value, p=>true); }

		[OperationContract]
		public List<User> UserSel() { return Users.Sel(c => c.Users.Execute(MergeOption.AppendOnly)).ToList(); }

		[OperationContract]
		public bool UserUpd(User value) { return Users.Upd(value, p=>true); }

		#endregion
	}
}
