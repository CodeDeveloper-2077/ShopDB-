using System;

namespace ShopContext
{
    public class Person
    {
        public Guid PersonKey { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public bool IsMarried { get; set; }

        public string BirthPlace { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
