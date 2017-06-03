using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

using POS.Data.Model;
using POS.Data.Model.Mapping;

namespace POS.Data
{
    public class POSContext : DbContext
    {
		static POSContext()
		{
			//Database.SetInitializer<POSContext>(null);
			Database.SetInitializer(new DropCreateDatabaseIfModelChanges<POSContext>());
		}

		public static TRes UsingContext<TRes>(string _connStr, Func<POSContext, TRes> action)
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
				IT.Log.Logger.ToLogFmt(null, System.Diagnostics.TraceLevel.Error, ex, $"({_connStr})");
				throw;
			}
		}

		public POSContext(string connStr):base(connStr)
		{
		}


        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<MenuGroup> MenuGroups { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<PriceList> PriceLists { get; set; }
        //public DbSet<Role> Roles { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ComplexType<PersonInfo>();
			//modelBuilder.ComplexType<UserInfo>();

			modelBuilder.Configurations.Add(new BillMapping());
			modelBuilder.Configurations.Add(new BillItemMapping());
			modelBuilder.Configurations.Add(new DivisionMapping());
			modelBuilder.Configurations.Add(new MenuGroupMapping());
			modelBuilder.Configurations.Add(new MenuItemMapping());
			modelBuilder.Configurations.Add(new PriceMapping());
			modelBuilder.Configurations.Add(new PriceListMapping());
			modelBuilder.Configurations.Add(new UserGroupMapping());
			modelBuilder.Configurations.Add(new UserMapping());
		}
	}
}