using ChilLaxBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChilLaxBackEnd.Controllers
{
    public class ProductController : Controller
    {

        public ActionResult List()
        {
            string keyword = Request.Form["txtKeyword"];
            ChilLaxEntities db = new ChilLaxEntities();
            IEnumerable<Product> datas = null;
            if (string.IsNullOrEmpty(keyword))
            {
                datas = from p in db.Product
                        select p;
            }
            else
            {
                datas = db.Product.Where(p => p.product_name.Contains(keyword));
            }
            return View(datas);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product t)
        {
            ChilLaxEntities db = new ChilLaxEntities();
 
            if (t.photo != null)
            {
                string photoName = Guid.NewGuid().ToString() + ".jpg";
                t.photo.SaveAs(Server.MapPath("~/assets/images/" + photoName));
                t.product_img = photoName;
            }
            db.Product.Add(t);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                ChilLaxEntities db = new ChilLaxEntities();
                Product prod = db.Product.FirstOrDefault(p => p.product_id == id);
                if (prod != null)
                {
                    System.IO.File.Delete(Server.MapPath("~/assets/images/" + prod.product_img));
                    db.Product.Remove(prod);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            ChilLaxEntities db = new ChilLaxEntities();
            Product prod = db.Product.FirstOrDefault(p => p.product_id == id);
            return View(prod);
        }

        [HttpPost]
        public ActionResult Edit(Product x)
        {
            ChilLaxEntities db = new ChilLaxEntities();
            Product prod = db.Product.FirstOrDefault(p => p.product_id == x.product_id);
            if (prod != null)
            {
                if (x.photo != null)
                {
                    System.IO.File.Delete(Server.MapPath("~/assets/images/" + prod.product_img));
                    string photoName = Guid.NewGuid().ToString() + ".jpg";
                    x.photo.SaveAs(Server.MapPath("~/assets/images/" + photoName));
                    prod.product_img = photoName;

                }
                prod.supplier_id = x.supplier_id;
                prod.product_name = x.product_name;
                prod.product_desc = x.product_desc;
                prod.product_price = x.product_price;
                prod.product_quantity = x.product_quantity;
                prod.product_category = x.product_category;
                prod.product_state = x.product_state;
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public ActionResult Details()
        {
            return View();
        }
    }
}