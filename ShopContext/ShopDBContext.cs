using System;
using System.Data.Entity;
using System.Linq;
using ShopContext.DBInitializers;

namespace ShopContext
{
    public class ShopDBContext : DbContext
    {
        static ShopDBContext()
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<ShopDBContext>());
            Database.SetInitializer(new DropCreateDBAlways());
            //Database.SetInitializer(new DropCreateDBIfModelChanges());
            //Database.SetInitializer(new IDBInitializer());
        }

        public ShopDBContext()
            : base("name=ShopDBContext")
        {
        }

        public virtual DbSet<Person> People { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new PersonConfig());

            modelBuilder.Entity<Customer>().Map(e => e.MapInheritedProperties());
        }
    }
}