using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using POS.Data.Model;

namespace POS.Data
{
    class POSContext : DbContext
    {
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillItem> BillItems { get; set; }
        public DbSet<Check> Checks { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<MenuGroup> MenuGroups { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<PriceList> PriceLists { get; set; }
        //public DbSet<Role> Roles { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<User> Users { get; set; }

        void Mapping()
        {
            System.Data.Entity.ModelConfiguration.Configuration.
        }
    }
}
