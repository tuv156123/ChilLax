using ChilLaxBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChilLaxBackEnd.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                ChilLaxEntities db = new ChilLaxEntities();
                Employee emp = db.Employee.FirstOrDefault(e => e.emp_id == id);
                if (emp != null)
                {
                    db.Employee.Remove(emp);
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
            Employee emp = db.Employee.FirstOrDefault(e => e.emp_id == id);
            return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(Employee x)
        {
            ChilLaxEntities db = new ChilLaxEntities();
            Employee emp = db.Employee.FirstOrDefault(e => e.emp_id == x.emp_id);
            if (emp != null)
            {
                if (x.emp_permission.ToString() != null && x.emp_name != null && x.emp_account != null && x.emp_password != null)
                {

                    emp.emp_permission = x.emp_permission;
                    emp.emp_name = x.emp_name;
                    emp.emp_account = x.emp_account;
                    emp.emp_password = x.emp_password;
                    db.SaveChanges();

                }
            }
            else
            {
                //ModelState.AddModelError("", "無法儲存資料。請確保所有必填欄位都已填寫正確。");
                ViewBag.ErrorMessage = "請填寫所有必填欄位。";
                return RedirectToAction("Edit");
            }

            return RedirectToAction("List");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            ChilLaxEntities db = new ChilLaxEntities();
            db.Employee.Add(emp);
            db.SaveChanges();
            return RedirectToAction("List");
        }


        public ActionResult List()
        {
            ChilLaxEntities db = new ChilLaxEntities();
            IEnumerable<Employee> datas = from e in db.Employee
                                          select e;
            return View(datas);
        }
    }
}