using chilLax_Net.Models;
using Microsoft.Ajax.Utilities;
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
            
            int dataCount = db.ProductOrder.Count();
            int pageCount = dataCount / 10;
            if (dataCount % 10 != 0) pageCount += 1;

            List<ProductOrderDetail> productOrderDetails = db
                .ProductOrder
                .OrderByDescending(p => p.order_date)
                .Skip(10)
                .Take(10)
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

                List<SelectListItem> mySelectItemList = new List<SelectListItem>(){
                    new SelectListItem{Text="未出貨", Value="未出貨", Selected=productOrderDetails.First().ProductOrder.order_state=="未出貨"},
                    new SelectListItem{Text="已出貨", Value="已出貨", Selected=productOrderDetails.First().ProductOrder.order_state=="已出貨"},
                    new SelectListItem{Text="已完成", Value="已完成", Selected=productOrderDetails.First().ProductOrder.order_state=="已完成"}
                };

                productOrderDetails.First().orderStateSelectedList = mySelectItemList;

                return View(productOrderDetails);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(ProductOrderDetail po)
        {
            try
            {
                ChilLaxModels db = new ChilLaxModels();
                ProductOrder prod = db.ProductOrder.FirstOrDefault(p => p.order_id == po.ProductOrder.order_id);
                if (prod != null)
                {
                    prod.order_payment = po.ProductOrder.order_payment;
                    prod.order_state = po.ProductOrder.order_state;
                    prod.order_delivery = po.ProductOrder.order_delivery;
                    prod.order_address = po.ProductOrder.order_address;
                    prod.order_note = po.ProductOrder.order_note;
                    db.SaveChanges();
                }
            //TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View(po);
            }
        }

       
    }
}
