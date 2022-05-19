namespace ShopDBContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int OrderID { get; set; }

        public int CustomerNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }

        [Required]
        [StringLength(30)]
        public string Goods { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
