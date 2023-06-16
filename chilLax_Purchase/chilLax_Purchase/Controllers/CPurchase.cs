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
                    }).ToList();

            return View(productOrderDetails);
        }
        public IActionResult Detail(int? id)
        {
            if (id != null)
            {
                ChilLaxContext db = new ChilLaxContext();
                ProductOrder prod = db.ProductOrders.FirstOrDefault(p => p.OrderId == id);
                OrderDetail detail = db.OrderDetails.FirstOrDefault(p => p.OrderId == id);
                if (prod != null || detail != null)
                {
                    db.ProductOrders.Remove(prod);
                    db.OrderDetails.Remove(detail);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }
        public IActionResult Edit(int? id)
        {
            if(id == null)
                return View();
            
            ChilLaxContext db = new ChilLaxContext();
            ProductOrder prod = db.ProductOrders.FirstOrDefault(p => p.OrderId==id); 
            return View(prod);
        }
    
  
    }
}
