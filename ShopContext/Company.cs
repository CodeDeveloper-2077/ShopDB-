using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ShopContext
{
    [Table("CompanyInfo")]
    public class Company
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CompanyKey { get; set; }

        [Required, MaxLength(30)]
        public string CompanyName { get; set; }

        [Required, MaxLength(15)]
        public string OwnerFirstName { get; set; }

        [MaxLength(15)]
        public string OwnerLastName { get; set; }

        ICollection<Customer> Customers { get; set; }

        public Company()
        {
            this.Customers = new HashSet<Customer>();
        }
    }
}