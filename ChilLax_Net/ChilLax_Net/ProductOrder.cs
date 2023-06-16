namespace ChilLax_Net
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductOrder")]
    public partial class ProductOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductOrder()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        [Key]
        public int order_id { get; set; }

        public int member_id { get; set; }

        public bool order_payment { get; set; }

        public int order_totalPrice { get; set; }

        public bool order_delivery { get; set; }

        [Required]
        public string order_address { get; set; }

        public DateTime order_date { get; set; }

        public string order_note { get; set; }

        [Required]
        [StringLength(500)]
        public string order_state { get; set; }

        public virtual Member Member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
