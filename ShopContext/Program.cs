using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.Linq;

namespace ShopContext
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ShopDBContext db = new ShopDBContext())
            {
                var people = from person in db.People
                             where person.Age > 18
                             orderby person.FirstName ascending
                             select new { Id = person.PersonKey, Name = person.FirstName + " " + person.LastName, person.Age, person.BirthPlace };
                //var people = Enumerable.Select
                //                              (
                //                              Enumerable.Where(db.People, p => p.Age > 18),
                //                              p => new { Id = p.PersonKey, Name = p.FirstName + " " + p.LastName, p.Age, p.BirthPlace }
                //                              );
                //var orderedPeople = Enumerable.OrderBy(people, p => p.Name);
                //var people = db.People
                //                      .Where(p => p.Age > 18)
                //                      .OrderBy(p => p.FirstName)
                //                      .Select(p => new { Id = p.PersonKey, Name = p.FirstName + " " + p.LastName, p.Age, p.BirthPlace });

                var customers = from customer in db.Customers
                                where customer.Age <= 40
                                orderby customer.FirstName descending
                                select new
                                {
                                    Id = customer.PersonKey,
                                    Name = customer.FirstName + " " + customer.LastName,
                                    customer.Age,
                                    customer.BirthPlace,
                                    customer.WorkPlace,
                                    customer.WorkDate
                                };
                //var customers = Enumerable.Select(Enumerable.Where(db.Customers, c => c.Age <= 40), c => new
                //{
                //    Id = c.PersonKey,
                //    Name = c.FirstName + " " + c.LastName,
                //    c.Age,
                //    c.BirthPlace,
                //    c.WorkPlace,
                //    c.WorkDate
                //});
                //var customers = db.Customers
                //                            .Where(c => c.Age <= 40)
                //                            .OrderByDescending(c => c.FirstName)
                //                            .Select(c => new { Id = c.PersonKey, Name = c.FirstName + " " + c.LastName, c.Age, c.BirthPlace, c.WorkPlace, c.WorkDate });

                var companies = from company in db.Companies
                                orderby company.CompanyName ascending
                                select company;
                //var companies = Enumerable.OrderByDescending(db.Companies, c => c.CompanyName);
                //var companies = db.Companies.OrderByDescending(c => c.CompanyName);

                foreach (var person in people)
                {
                    Console.WriteLine
                                    ("{0}. {1}", 
                                    person.Id, 
                                    person.Name
                                    );
                }

                Console.WriteLine(new string('-', 50));
                Console.ReadKey();

                foreach(var customer in customers)
                {
                    Console.WriteLine
                                     ("{0}. {1}. WorkPlace: {2}, WorkDate: {3}",
                                     customer.Id,
                                     customer.Name,
                                     customer.WorkPlace,
                                     customer.WorkDate != null ? customer.WorkDate : null
                                     );
                }

                Console.WriteLine(new string('-', 50));
                Console.ReadKey();

                foreach(var company in companies)
                {
                    Console.WriteLine
                        ("{0}. {1} is an owner of {2} company.",
                        company.CompanyKey,
                        company.OwnerFirstName,
                        company.OwnerLastName == string.Empty ? company.OwnerLastName : String.Empty,
                        company.CompanyName
                        );
                }

                Console.ReadKey();
            }
        }
    }
}
