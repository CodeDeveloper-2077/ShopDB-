using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ShopDBContext
{
    public partial class ShopDBContext : DbContext
    {
        public ShopDBContext()
            : base("name=ShopDBContext")
        {
        }

        public virtual DbSet<Cours> Courses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cours>()
                .Property(e => e.CourseName)
                .IsUnicode(false);

            modelBuilder.Entity<Cours>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Cours>()
                .HasMany(e => e.Students)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("StudentsCourses").MapLeftKey("CourseId").MapRightKey("StudentId"));

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Address1)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Contact)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Goods)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.FName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.LName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Phone)
                .IsUnicode(false);
        }
    }
}
