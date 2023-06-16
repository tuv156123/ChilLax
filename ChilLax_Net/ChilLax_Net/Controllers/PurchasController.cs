using chilLax_Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChilLax_Net.Controllers
{
    public class PurchasController : Controller
    {
        // GET: Purchas
        public ActionResult Index()
        {
            ChilLaxModels db = new ChilLaxModels();

            List<ProductOrderDetail> productOrderDetails = db.ProductOrder
                .Join(db.OrderDetail,
                    po => po.order_id,
                    od => od.order_id,
                    (po, od) => new ProductOrderDetail
                    {
                        ProductOrder = po,
                        OrderDetail = od
                    }).ToList();

            return View(productOrderDetails);
        }

        // GET: Purchas/Details/5
        public ActionResult Details(int id)
        {
            if (id != null)
            {
                ChilLaxModels db = new ChilLaxModels();
                ProductOrder prod = db.ProductOrder.FirstOrDefault(p => p.order_id == id);
                OrderDetail detail = db.OrderDetail.FirstOrDefault(p => p.order_id == id);
                if (prod != null || detail != null)
                {
                    db.ProductOrder.Remove(prod);
                    db.OrderDetail.Remove(detail);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Purchas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                ChilLaxModels db = new ChilLaxModels();
                List<ProductOrderDetail> productOrderDetails = db.ProductOrder
                    .Join(db.OrderDetail,
                        po => po.order_id,
                        od => od.order_id,
                        (po, od) => new ProductOrderDetail
                        {
                            ProductOrder = po,
                            OrderDetail = od
                        })
                    .Where(po => po.ProductOrder.order_id == id)
                    .ToList();
                return View(productOrderDetails);
            }
            return RedirectToAction("Index");
        }

        // POST: Purchas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       
    }
}
