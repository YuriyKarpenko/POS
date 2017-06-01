using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
//using System.Linq;
using System.Text;

//using CoderOD.DB35.Linq;

//namespace POS.Data.Linq
//{
//    public class Repositorys
//    {
//        static Repositorys() { Reps.db.GetType(); }

//        public class RepBill : RepositoryBaseG_WPF<DTO.Bill, Bill>
//        {
//            public RepBill(DBDataContext db) : base(db) { }
//        }

//        public class RepBillItem : RepositoryBaseG_WPF<DTO.BillItem, BillItem>
//        {
//            public RepBillItem(DBDataContext db) : base(db) { }
//        }

//        public class RepCheck : RepositoryBaseG_WPF<DTO.Check, Check>
//        {
//            public RepCheck(DBDataContext db) : base(db) { }
//        }

//        public class RepDivision : RepositoryBaseG_WPF<DTO.Division, Division>
//        {
//            public RepDivision(DBDataContext db) : base(db) { }
//        }

//        public class RepMenuGroup : RepositoryBaseG_WPF<DTO.MenuGroup, MenuGroup>
//        {
//            public RepMenuGroup(DBDataContext db) : base(db) { }
//        }

//        public class RepMenuItem : RepositoryBaseG_WPF<DTO.MenuItem, MenuItem>
//        {
//            public RepMenuItem(DBDataContext db) : base(db) { }
//        }

//        /*public class RepOption : RepositoryBaseG_WPF<DTO.Option, Option>
//        {
//            public RepOption(DBDataContext db) : base(db) { }
//        }	//	*/

//        public class RepPrice : RepositoryBaseG_WPF<DTO.Price, Price>
//        {
//            public RepPrice(DBDataContext db) : base(db) { }
//        }

//        public class RepPriceList : RepositoryBaseG_WPF<DTO.PriceList, PriceList>
//        {
//            public RepPriceList(DBDataContext db) : base(db) { }
//        }

//        public class RepUser : RepositoryBaseG_WPF<DTO.User, User>
//        {
//            public RepUser(DBDataContext db) : base(db) { }

//            public override DTO.User db2dto(User dbEnt)
//            {
//                var x = base.db2dto(dbEnt);
//                x.UserGroup = Reps.UserGroups.db2dto(dbEnt.UserGroup);
//                x.UserGroups =  Reps.UserGroups.List;
//                return x;
//            }

//            public override User dto2db(DTO.User dtoEnt)
//            {
//                User ret = base.dto2db(dtoEnt);
//                ret.UserGroup = Reps.UserGroups.dto2db(dtoEnt.UserGroup);
//                return ret;
//            }
//            //public DTO.UserGroup
//            //public CoderOD.DB35.ChangeTrackingCollection<DTO.UserGroup> UserGroups { get { return; } set { } } 
//        }

//        public class RepUserGroup : RepositoryBaseG_WPF<DTO.UserGroup, UserGroup>
//        {
//            public RepUserGroup(DBDataContext db) : base(db) { }

//            public override DTO.UserGroup db2dto(UserGroup dbEnt)
//            {
//                var x = base.db2dto(dbEnt);
////				x.Users = new CoderOD.DB35.ChangeTrackingCollection<DTO.User>(Reps.Users.List);
//                return x;
//            }
//        }

//    }

//    public static class Reps
//    {
//        const string connStr = @"Data Source=(local);Initial Catalog=sem;Integrated Security=True";
//        public static DBDataContext db = new DBDataContext(connStr);

//        public static void CreateDb()
//        {
 
//        }

//        public static Repositorys.RepBill Bills = new Repositorys.RepBill(db);
//        public static Repositorys.RepBillItem BillItems = new Repositorys.RepBillItem(db);
//        public static Repositorys.RepCheck Checks = new Repositorys.RepCheck(db);
//        public static Repositorys.RepDivision Divisions = new Repositorys.RepDivision(db);

//        public static Repositorys.RepMenuGroup MenuGroups = new Repositorys.RepMenuGroup(db);
//        public static Repositorys.RepMenuItem MenuItems = new Repositorys.RepMenuItem(db);

//        //public static Repositorys.RepOption Options = new Repositorys.RepOption(db);
//        public static Repositorys.RepPrice Prices = new Repositorys.RepPrice(db);
//        public static Repositorys.RepPriceList PriceLists = new Repositorys.RepPriceList(db);

//        public static Repositorys.RepUser Users = new Repositorys.RepUser(db);
//        public static Repositorys.RepUserGroup UserGroups = new Repositorys.RepUserGroup(db);
//    }

	//public class SQL
	//{
	//    POS.Data.sem acontext = new sem();

	//    public IEnumerable<POS.Data.Division> GetDivisions()
	//    {
	//        return this.acontext.Divisions.Execute(System.Data.Objects.MergeOption.OverwriteChanges);
	//    }
	//}
//}

