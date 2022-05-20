using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDBContext
{
    class Program
    {
        static ShopDBContext db = new ShopDBContext();
        static void OutputCustomers(IQueryable<Customer> customers)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Customers Table\n");
            Console.WriteLine("CustomerNO | CustomerName | City | Contact | Address1");

            foreach (var customer in customers)
            {
                string customerData = string.Format("{0}. {1} {2} {3} {4}",
                                                                        customer.CustomerNO,
                                                                        customer.CustomerName,
                                                                        customer.City,
                                                                        customer.Contact,
                                                                        customer.Address1
                                                   );

                Console.WriteLine(customerData);
                Console.WriteLine(new string('-', 50) + "\n");
            }
        }

        static void OutputCourses(IQueryable<Cours> courses)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Courses Table\n");
            Console.WriteLine("CourseID | CourseName | Price");

            foreach(var course in courses)
            {
                string courseData = string.Format("{0}. {1} {2}", course.CourseId, course.CourseName, course.Price);

                Console.WriteLine(courseData);
                Console.WriteLine(new string('-', 50) + "\n");
            }
        }

        static void OutputOrders(IQueryable<Order> orders)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Orders Table\n");
            Console.WriteLine("OrderID | CustomerNo | OrderDate | Goods");

            foreach (var order in orders)
            {
                string orderData = string.Format("{0}. {1} {2} {3}", order.OrderID,
                                                                     order.CustomerNo,
                                                                     order.OrderDate,
                                                                     order.Goods
                                                );

                Console.WriteLine(orderData);
                Console.WriteLine(new string('-', 50) + "\n");
            }
        }

        static void OutputStudents(IQueryable<Student> students)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Students Table\n");
            Console.WriteLine("StudentID | FName | LName | EMail | Phone");

            foreach (var student in students)
            {
                string studentData = string.Format("{0}. {1} {2} {3} {4}", student.StudentId,
                                                                           student.FName,
                                                                           student.LName,
                                                                           student.Email,
                                                                           student.Phone
                                                  );

                Console.WriteLine(studentData);
                Console.WriteLine(new string('-', 50) + "\n");
            }
        }

        static void Main(string[] args)
        {
            using (db)
            {
                OutputCustomers(db.Customers);
                OutputOrders(db.Orders);
                OutputStudents(db.Students);
                OutputCourses(db.Courses);

                foreach (var student in Students())
                {
                    Console.WriteLine("{0}", student);
                    Console.WriteLine(new string('-', 50));
                }

                foreach(var student in StudentsOrderBy())
                {
                    Console.WriteLine("{0}", student);
                    Console.WriteLine(new string('.', 100));
                }

                foreach (var student in StudentsOrderByDescending())
                {
                    Console.WriteLine("{0}", student);
                    Console.WriteLine(new string('~', 100));
                }
            }
        }

        static IEnumerable<string> Students()
        {
            return from student in db.Students.ToList()
                   where student.Courses.Contains(db.Courses.FirstOrDefault(c => c.CourseName == "ASP.NET MVC"))
                   let Name = student.FName + " " +  student.LName
                   let outputData = string.Format("{0}. {1}", student.StudentId, Name)
                   select outputData;
        }

        static IEnumerable<string> StudentsOrderBy()
        {
            return from student in db.Students.ToList()
                   let Name = student.FName + " " + student.LName
                   orderby Name ascending
                   select Name;
        }

        static IEnumerable<string> StudentsOrderByDescending()
        {
            return from student in db.Students.ToList()
                   let Name = student.FName + " " + student.LName
                   orderby Name descending
                   select Name;
        }
    }
}
