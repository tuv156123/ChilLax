using chilLax_Purchase.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using static NuGet.Packaging.PackagingConstants;

namespace chilLax_Purchase.Controllers
{
    public class CPurchase : Controller
    {
        public IActionResult LIst()
        {
            ChilLaxContext db = new ChilLaxContext();
            var datas = from order in db.ProductOrders
                         join detail in db.OrderDetails on order.OrderId equals detail.OrderId
                         select order ;
           
            return View(datas);
        }
    }
}
