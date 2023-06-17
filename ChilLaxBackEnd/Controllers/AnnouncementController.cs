using ChilLaxBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChilLaxBackEnd.Controllers
{
    public class AnnouncementController : Controller
    {
        ChilLaxEntities db = new ChilLaxEntities();
        // GET: Announcement
        public ActionResult List(DateTime? start = null, DateTime? end = null)
        {
            var data = db.Announcement.Select(anmt => anmt).OrderBy(anmt => anmt.start_date).ThenBy(anmt => anmt.end_date).ToList();
            List<AnnouncementWrapper> list = new List<AnnouncementWrapper>();
            foreach (Announcement item in data)
            {
                AnnouncementWrapper anmt = new AnnouncementWrapper()
                {
                    anmt = item,
                };

                list.Add(anmt);
            }

            if (string.IsNullOrEmpty(start.ToString()) && string.IsNullOrEmpty(end.ToString()))
            {
                return View(list);
            }

            else 
            {
                var SearchData = db.GetFunctionAnmt(start, end);
                List<AnnouncementWrapper> SearchList = new List<AnnouncementWrapper>();
                foreach (Announcement item in SearchData)
                {
                    AnnouncementWrapper SearchAnmt = new AnnouncementWrapper()
                    {
                        anmt = item,
                    };

                    SearchList.Add(SearchAnmt);
                }
                return View(SearchList);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AnnouncementWrapper anmtw)
        {
            if (ModelState.IsValid)
            {
                Announcement anmt = new Announcement();
                anmt.announcement = anmtw.announcement;
                anmt.start_date = anmtw.start_date;
                anmt.end_date = anmtw.end_date;
                anmt.bonus_for_focus = anmtw.bonus_for_focus;
                anmt.bonus_for_shopping = anmtw.bonus_for_shopping;

                try
                {
                    db.Announcement.Add(anmt);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "新增成功!";
                    return RedirectToAction("List");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationError in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationError.ValidationErrors)
                        {
                            Console.WriteLine($"Validation error in entity {entityValidationError.Entry.Entity.GetType().Name}:");
                            Console.WriteLine($"  Property: {validationError.PropertyName}");
                            Console.WriteLine($"  Error: {validationError.ErrorMessage}");
                        }
                    }
                }
            }
            else
            {
                return View(anmtw);
            }
           
            TempData["ErrorMessage"] = "新增失敗!";
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            Announcement ANMT = db.Announcement.FirstOrDefault(anmt => anmt.announcement_id == id);
            AnnouncementWrapper anmtw = new AnnouncementWrapper();
            anmtw.anmt = ANMT;
            return View(anmtw);
        }
        
        [HttpPost]
        public ActionResult Edit(AnnouncementWrapper anmtw)
        {
            if(ModelState.IsValid)
            {
                Announcement ANMT = db.Announcement.FirstOrDefault(anmt => anmt.announcement_id == anmtw.announcement_id);

                if (ANMT != null)
                {
                    ANMT.announcement = anmtw.announcement;
                    ANMT.start_date = anmtw.start_date;
                    ANMT.end_date = anmtw.end_date;
                    ANMT.bonus_for_focus = anmtw.bonus_for_focus;
                    ANMT.bonus_for_shopping = anmtw.bonus_for_shopping;
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "修改成功!";
                    return RedirectToAction("List");
                }
            }
            else
            {
                return View(anmtw);
            }
            
            TempData["ErrorMessage"] = "修改失敗!";
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                Announcement ANMT = db.Announcement.FirstOrDefault(anmt => anmt.announcement_id == id);
                if (ANMT != null)
                {
                    db.Announcement.Remove(ANMT);
                    db.SaveChanges();
                }
                TempData["SuccessMessage"] = "刪除成功!";
                return RedirectToAction("List");
            }
            TempData["ErrorMessage"] = "刪除失敗!";
            return RedirectToAction("List");
        }
    }
}