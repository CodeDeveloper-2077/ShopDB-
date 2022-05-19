namespace ShopDBContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int CustomerNO { get; set; }

        [Required]
        [StringLength(25)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(25)]
        public string Address1 { get; set; }

        [Required]
        [StringLength(15)]
        public string City { get; set; }

        [Required]
        [StringLength(25)]
        public string Contact { get; set; }

        [StringLength(12)]
        public string Phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
