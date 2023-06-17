namespace ChilLax_Net
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
        [DisplayName("單號")]
        public int order_id { get; set; }

        public int member_id { get; set; }
       
        [DisplayName("付款狀態")]
        public bool order_payment { get; set; }

        [DisplayName("總價")]
        public int order_totalPrice { get; set; }

        [DisplayName("物流狀態")]
        public bool order_delivery { get; set; }

        [Required]
        [DisplayName("物流地區")]
        public string order_address { get; set; }

        [DisplayName("購買日期")]
        public DateTime order_date { get; set; }

        [DisplayName("備註")]
        public string order_note { get; set; }

        [Required]
        [StringLength(500)]
        [DisplayName("訂單狀態")]
        public string order_state { get; set; }

        public virtual Member Member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
