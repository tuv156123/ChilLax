using ChilLaxBackEnd.Models.ViewModels;
using ChilLaxBackEnd.Models;
using ChilLaxBackEnd.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.SqlClient;

namespace ChilLaxBackEnd.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: PurchaseController
        [HttpGet]
        public ActionResult Index(int? nowpage, int? _pageCount)
        {
            ChilLaxEntities db = new ChilLaxEntities();

            if (nowpage == null)
            {
                nowpage = 1;
            }
            int? pageCount = _pageCount;

            if (_pageCount == null)
            {
                int dataCount = db.ProductOrder.Count();
                pageCount = dataCount / 10;
                if (dataCount % 10 != 0) pageCount += 1;
            }
            

            List<ProductOrderDetail> productOrderDetails = db
                .ProductOrder
                .OrderByDescending(p => p.order_date)
                .Skip(10 * ((int)nowpage) - 1)
                .Take(10)
                .Join(db.OrderDetail,
                    po => po.order_id,
                    od => od.order_id,
                    (po, od) => new ProductOrderDetail
                    {
                        ProductOrder = po,
                        OrderDetail = od
                    }).ToList();

            productOrderDetails.FirstOrDefault().pageCount = pageCount;
            productOrderDetails.FirstOrDefault().nowpage = nowpage;

            return View(productOrderDetails);
        }
        
        // GET: Purchas/Details/5
        public ActionResult Details(int id)
        {
            if (id != null)
            {
                ChilLaxEntities db = new ChilLaxEntities();
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
                ChilLaxEntities db = new ChilLaxEntities();
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
                ChilLaxEntities db = new ChilLaxEntities();
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
        public ActionResult ErrDevBar()
        {
            ChilLaxEntities db = new ChilLaxEntities();

            List<ModelChartJs> chartData = db.Database.SqlQuery<ModelChartJs>(@"
                WITH new_data AS (
                    SELECT
                    REPLACE(CONVERT(varchar(6), po.ORDER_DATE, 112), '-', '') AS OrderData,
                    po.ORDER_TOTALPRICE
                    FROM DBO.PRODUCTORDER PO
                )
                SELECT OrderData, SUM(ORDER_TOTALPRICE) AS Total FROM new_data GROUP BY OrderData;"
            ).ToList();

            return View(chartData);
        }
    }
}