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
    public class HomeVideoController : Controller
    {
        ChilLaxEntities db = new ChilLaxEntities();
        // GET: HomeVideo
        public ActionResult List(string searchBy, string searchValue)
        {
            var data = db.HomeVideo.ToList();
            List<HomeVideoWrapper> list = new List<HomeVideoWrapper>();
            foreach (HomeVideo item in data)
            {
                HomeVideoWrapper fsw = new HomeVideoWrapper()
                {
                    hv = item,
                };
                list.Add(fsw);
            }

            try
            {
                if (data.Count == 0)
                {
                    TempData["InfoMessage"] = "尚無任何資料";
                    return View(list);
                }
                else
                {
                    if (string.IsNullOrEmpty(searchValue))
                    {
                        return View(list);
                    }
                    else
                    {
                        if (searchBy.ToLower() == "主題")
                        {
                            var searchByTheme = data.Where(hv => hv.video_name.ToLower().Contains(searchValue.ToLower()));
                            List<HomeVideoWrapper> searchByThemeList = new List<HomeVideoWrapper>();
                            foreach (HomeVideo item in searchByTheme)
                            {
                                HomeVideoWrapper hvw = new HomeVideoWrapper()
                                {
                                    hv = item,
                                };
                                searchByThemeList.Add(hvw);
                            }
                            return View(searchByThemeList);
                        }
                        else if (searchBy.ToLower() == "影片檔類型")
                        {
                            var searchByVideo = data.Where(fs => fs.video_path.ToLower().Contains(searchValue.ToLower()));
                            List<HomeVideoWrapper> searchByVideoList = new List<HomeVideoWrapper>();
                            foreach (HomeVideo item in searchByVideo)
                            {
                                HomeVideoWrapper fsw = new HomeVideoWrapper()
                                {
                                    hv = item,
                                };
                                searchByVideoList.Add(fsw);
                            }
                            return View(searchByVideoList);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View(list);
            }
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HomeVideoWrapper hvw)
        {
            if (ModelState.IsValid)
            {
                HomeVideo HV = new HomeVideo();
                HV.video_name = hvw.video_name;
                if (hvw.video != null)
                {
                    string videoName = Guid.NewGuid().ToString() + Path.GetExtension(hvw.video.FileName);
                    hvw.video.SaveAs(Server.MapPath("~/assets/videos/" + videoName));
                    HV.video_path = videoName;
                }

                try
                {
                    db.HomeVideo.Add(HV);
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
                return View(hvw);
            }
            TempData["ErrorMessage"] = "新增失敗!";
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            HomeVideo HV = db.HomeVideo.FirstOrDefault(hv => hv.video_id == id);
            HomeVideoWrapper hvw = new HomeVideoWrapper();
            hvw.hv = HV;
            return View(hvw);
        }

        [HttpPost]
        public ActionResult Edit(HomeVideoWrapper hvw)
        {
            if (ModelState.IsValid)
            {
                HomeVideo HV = db.HomeVideo.FirstOrDefault(hv => hv.video_id == hvw.video_id);

                if (HV != null)
                {
                    if (hvw.video != null)
                    {
                        string videoName = Guid.NewGuid().ToString() + Path.GetExtension(hvw.video.FileName);
                        hvw.video.SaveAs(Server.MapPath("~/assets/images/" + videoName));
                        HV.video_path = videoName;
                        System.IO.File.Delete(Server.MapPath("~/assets/images/" + HV.video_path));
                    }

                    HV.video_name = hvw.video_name;
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "修改成功!";
                    return RedirectToAction("List");
                }
            }
            else
            {
                return View(hvw);
            }
           
            TempData["ErrorMessage"] = "修改失敗!";
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                HomeVideo HV = db.HomeVideo.FirstOrDefault(hv => hv.video_id == id);
                if (HV != null)
                {
                    System.IO.File.Delete(Server.MapPath("~/assets/videos/" + HV.video_path));
                    db.HomeVideo.Remove(HV);
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