using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopContext
{
    [Table("CustomerInfo")]
    public class Customer : Person
    {
        [Required, MaxLength(250)]
        public string WorkPlace { get; set; }

        [DataType("datetime2")]
        public DateTime? WorkDate { get; set; }

        ICollection<Company> Companies { get; set; }

        public Customer()
        {
            this.Companies = new HashSet<Company>();
        }
    }
}