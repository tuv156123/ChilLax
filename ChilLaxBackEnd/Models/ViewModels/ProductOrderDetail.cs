using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChilLaxBackEnd.Models;

namespace ChilLaxBackEnd.Models.ViewModels
{
    public class ProductOrderDetail
    {
        ChilLaxEntities db = new ChilLaxEntities();

        public ProductOrder ProductOrder { get; set; }
        public OrderDetail OrderDetail { get; set; }

        [DisplayName("小計")]
        public int? Subtotal => this.OrderDetail.cart_product_quantity * this.ProductPrice;
        [DisplayName("商品價格")]
        public int? ProductPrice
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

        public int? pageCount;
        public int? nowpage;


        public IEnumerable<SelectListItem> orderStateSelectedList { get; set; }
    }
}