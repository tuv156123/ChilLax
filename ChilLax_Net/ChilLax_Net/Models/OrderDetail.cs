namespace ChilLax_Net
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("")]
        public int order_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int product_id { get; set; }

        [DisplayName("商品數量")]
        public int cart_product_quantity { get; set; }

        public virtual ProductOrder ProductOrder { get; set; }

        public virtual Product Product { get; set; }
    }
}
