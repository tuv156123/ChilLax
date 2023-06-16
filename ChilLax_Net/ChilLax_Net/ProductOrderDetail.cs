namespace chilLax_Net.Models
{
    using ChilLax_Net;
    using Microsoft;
    using System.ComponentModel;
    using System.Linq;

    public class ProductOrderDetail
    {
        ChilLaxModels db = new ChilLaxModels();

        public ProductOrder ProductOrder { get; set; }
        public OrderDetail OrderDetail { get; set; }

        [DisplayName("小計")]
        public int Subtotal => this.OrderDetail.cart_product_quantity * this.ProductPrice;
        [DisplayName("商品價格")]
        public int ProductPrice
        {
            get
            {
                return db.Product
                    .Where(p => p.product_id == OrderDetail.product_id)
                    .Select(p => p.product_price)
                    .FirstOrDefault();
            }
        }
        [DisplayName("會員姓名")]
        public string MemberName => db.Member
                    .Where(p => p.member_id == ProductOrder.member_id)
                    .Select(p => p.member_name)
                    .FirstOrDefault();
            
        [DisplayName("商品名稱")]
        public string ProductName => db.Product
                    .Where(p => p.product_id == OrderDetail.product_id)
                    .Select(p => p.product_name)
                    .FirstOrDefault();
    }

}
