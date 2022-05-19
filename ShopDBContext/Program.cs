using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDBContext
{
    class Program
    {
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
            using (ShopDBContext db = new ShopDBContext())
            {
                OutputCustomers(db.Customers);
                OutputOrders(db.Orders);
                OutputStudents(db.Students);
                OutputCourses(db.Courses);
            }
        }
    }
}
