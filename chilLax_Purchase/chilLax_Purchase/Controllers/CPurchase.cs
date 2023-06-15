using chilLax_Purchase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Xml.Linq;
using static NuGet.Packaging.PackagingConstants;

namespace chilLax_Purchase.Controllers
{
    public class CPurchase : Controller
    {
        public IActionResult List()
        {
            ChilLaxContext db = new ChilLaxContext();

            List<ProductOrderDetail> productOrderDetails = db.ProductOrders
                .Join(db.OrderDetails,
                    po => po.OrderId,
                    od => od.OrderId,
                    (po, od) => new ProductOrderDetail
                    {
                        ProductOrder = po,
                        OrderDetail = od
                    })
                //.GroupBy(item => item.ProductOrder.OrderId)
                //.Select(group => group.FirstOrDefault())
                .ToList();

            return View(productOrderDetails);
        }


    }
}
