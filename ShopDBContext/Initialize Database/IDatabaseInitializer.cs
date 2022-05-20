using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ShopDBContext.Initialize_Database
{
    class IDatabaseInitializer : IDatabaseInitializer<ShopDBContext>
    {
        public void InitializeDatabase(ShopDBContext db)
        {
            if (db.Database.Exists())
                db.Database.Delete();
            db.Database.Create();

            var customer1 = new Customer
            {
                CustomerName = "Robert",
                Address1 = "Time Square",
                City = "London",
                Contact = "robert19@gmail.com",
                Phone = "093123456789"
            };
            var customer2 = new Customer
            {
                CustomerName = "Oleg",
                Address1 = "Topolynaya",
                City = "Dnipro",
                Contact = "oleh.shevchenko02@gmail.com",
                Phone = "0660990374"
            };

            var order1 = new Order
            {
                CustomerNo = 4,
                OrderDate = DateTime.Now,
                Goods = "Camera"
            };
            var order2 = new Order
            {
                CustomerNo = 5,
                OrderDate = DateTime.Now,
                Goods = "Horizon Forbidden West"
            };
            var order3 = new Order
            {
                CustomerNo = 5,
                OrderDate = DateTime.Now,
                Goods = "Elden Ring"
            };
            var order4 = new Order
            {
                CustomerNo = 4,
                OrderDate = DateTime.Now,
                Goods = "Trampoline"
            };

            db.Customers.AddRange(new List<Customer> { customer1, customer2 });
            db.Orders.AddRange(new List<Order> { order1, order2, order3, order4 });
            db.SaveChanges();
        }
    }
}
