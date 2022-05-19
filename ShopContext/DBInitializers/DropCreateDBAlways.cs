using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace ShopContext.DBInitializers
{
    class DropCreateDBAlways : DropCreateDatabaseAlways<ShopDBContext>
    {
        protected override void Seed(ShopDBContext context)
        {
            base.Seed(context);

            var people = new List<Person>
            {
                new Person { FirstName = "John", Age = 27 },
                new Person
                {
                    FirstName = "Max",
                    LastName = "Jhonson",
                    Age = 19,
                    BirthPlace = "c. Dnipro",
                    BirthDate = DateTime.Now
                },
                new Person { FirstName = "Ivan", LastName = "Ivanobich", Age = 60 }
            };

            var customers = new List<Customer>
            {
                new Customer
                {
                    FirstName = "Robin",
                    LastName = "Thomason",
                    Age = 38,
                    BirthPlace = "c. Kyiv",
                    BirthDate = DateTime.Now,
                    WorkPlace = "Epam",
                    WorkDate = new DateTime(2005, 12, 2)
                },
                new Customer
                {
                    FirstName = "Mike" ,
                    LastName = "Jackson",
                    Age = 45,
                    WorkPlace = "CyberbionicSystematics",
                    WorkDate = new DateTime(1999, 4, 28)
                }
            };

            var companies = new List<Company>
            {
                new Company { CompanyName = "Microsoft", OwnerFirstName = "Bill", OwnerLastName = "Gates" },
                new Company { CompanyName = "Samsung", OwnerFirstName = "Lee" }
            };

            context.People.AddRange(people);
            context.Customers.AddRange(customers);
            context.Companies.AddRange(companies);

            context.SaveChanges();
        }
    }
}
