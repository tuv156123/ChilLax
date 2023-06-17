using ChilLaxBackEnd.Models;
using ChilLaxBackEnd.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChilLaxBackEnd.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel vm)
        {
            ChilLaxEntities db = new ChilLaxEntities();
            Employee emp = new Employee();
            if (vm.txtAccount != null && vm.txtPassword != null)
            {
                if (emp.is驗證帳號與密碼(vm.txtAccount, vm.txtPassword))
                {
                    Session[CDictionary.SK_IS_通過驗證] = true;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "帳號或密碼錯誤";
                }
            }
           
            return View();
        }

    }
}