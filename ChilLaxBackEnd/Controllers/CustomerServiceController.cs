using ChilLaxBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChilLaxBackEnd.Controllers
{
    public class CustomerServiceController : Controller
    {
        // GET: CustomerService
        public ActionResult 留言系統()
        {
            ChilLaxEntities db = new ChilLaxEntities();
            var datas = from p in db.CustomerService
                        select p;
            return View(datas);
        }

        public ActionResult Reply(int? id)
        {
            // 根據 id 從資料庫中取得對應的留言
            if (id == null)
                return RedirectToAction("留言系統");
            ChilLaxEntities db = new ChilLaxEntities();
            CustomerService prod = db.CustomerService.FirstOrDefault(p => p.customer_service_id == id);
            return View(prod);
        }

        [HttpPost]
        public ActionResult Reply(CustomerService message)
        {
            // 在此處將回覆的訊息和時間存入資料庫
            ChilLaxEntities db = new ChilLaxEntities();
            CustomerService prod = db.CustomerService.FirstOrDefault(p => p.customer_service_id == message.customer_service_id);
            if (prod != null)
            {
                string reply_time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                prod.reply = message.reply;
                prod.reply_datetime = reply_time;
                db.SaveChanges();
            }

            return RedirectToAction("留言系統");
        }

    }
}