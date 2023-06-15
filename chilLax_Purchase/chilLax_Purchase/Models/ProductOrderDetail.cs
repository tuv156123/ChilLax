using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace chilLax_Purchase.Models
{
    public class ProductOrderDetail
    {
        ChilLaxContext db = new ChilLaxContext();

        public ProductOrder ProductOrder { get; set; }
        public OrderDetail OrderDetail { get; set; }

        [DisplayName("小計")]
        public int Subtotal => this.OrderDetail.CartProductQuantity * this.ProductPrice;
        [DisplayName("商品價格")]
        public int ProductPrice
        {
            get
            {
                return db.Products
                    .Where(p => p.ProductId == OrderDetail.ProductId)
                    .Select(p => p.ProductPrice)
                    .FirstOrDefault();
            }
        }
        [DisplayName("會員姓名")]
        public string MemberName
        {
            get
            {
                return db.Members
                    .Where(p => p.MemberId == ProductOrder.MemberId)
                    .Select(p => p.MemberName)
                    .FirstOrDefault();
            }
        }
        public string ProductName
        {
            get
            {
                return db.Products
                    .Where(p => p.ProductId == OrderDetail.ProductId)
                    .Select(p => p.ProductName)
                    .FirstOrDefault();
            }
        }
    }

}
