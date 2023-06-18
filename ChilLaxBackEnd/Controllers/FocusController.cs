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
    public class FocusController : Controller
    {
        ChilLaxEntities db = new ChilLaxEntities();
        // GET: Focus
        public ActionResult List(string searchBy, string searchValue)
        {
            var data = db.FocusSlide.ToList();
            List<FocusSlideWrapper> list = new List<FocusSlideWrapper>();
            foreach (FocusSlide item in data)
            {
                FocusSlideWrapper fsw = new FocusSlideWrapper()
                {
                    fs = item,
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
                        if (searchBy.ToLower() == "情境")
                        {
                            var searchByCategory = data.Where(fs => fs.category.ToLower().Contains(searchValue.ToLower()));
                            List<FocusSlideWrapper> searchByCategoryList = new List<FocusSlideWrapper>();
                            foreach (FocusSlide item in searchByCategory)
                            {
                                FocusSlideWrapper fsw = new FocusSlideWrapper()
                                {
                                    fs = item,
                                };
                                searchByCategoryList.Add(fsw);
                            }
                            return View(searchByCategoryList);
                        } 
                        else if (searchBy.ToLower() == "圖檔類型")
                        {
                            var searchByImage = data.Where(fs => fs.image_path.ToLower().Contains(searchValue.ToLower()));
                            List<FocusSlideWrapper> searchByImageList = new List<FocusSlideWrapper>();
                            foreach (FocusSlide item in searchByImage)
                            {
                                FocusSlideWrapper fsw = new FocusSlideWrapper()
                                {
                                    fs = item,
                                };
                                searchByImageList.Add(fsw);
                            }
                            return View(searchByImageList);
                        }
                        else if (searchBy.ToLower() == "音檔類型")
                        {
                            var searchByAudio = data.Where(fs => fs.audio_path.ToLower().Contains(searchValue.ToLower()));
                            List<FocusSlideWrapper> searchByAudioList = new List<FocusSlideWrapper>();
                            foreach (FocusSlide item in searchByAudio)
                            {
                                FocusSlideWrapper fsw = new FocusSlideWrapper()
                                {
                                    fs = item,
                                };
                                searchByAudioList.Add(fsw);
                            }
                            return View(searchByAudioList);
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
        public ActionResult Create(FocusSlideWrapper fsw)
        {
            if (ModelState.IsValid)
            {
                FocusSlide FS = new FocusSlide();
                FS.category = fsw.category;
                if (fsw.image != null)
                {
                    string photoName = Guid.NewGuid().ToString() + Path.GetExtension(fsw.image.FileName);
                    fsw.image.SaveAs(Server.MapPath("~/assets/images/" + photoName));
                    FS.image_path = photoName;
                }
                if (fsw.audio != null)
                {
                    string audioName = Guid.NewGuid().ToString() + Path.GetExtension(fsw.audio.FileName);
                    fsw.audio.SaveAs(Server.MapPath("~/assets/audios/" + audioName));
                    FS.audio_path = audioName;
                }
               
                try
                {
                    db.FocusSlide.Add(FS);
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
                return View(fsw);
            }
            TempData["ErrorMessage"] = "新增失敗!";
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            FocusSlide FS = db.FocusSlide.FirstOrDefault(fs => fs.focus_id == id);
            FocusSlideWrapper fsw = new FocusSlideWrapper();
            fsw.fs = FS;
            return View(fsw);
        }

        [HttpPost]
        public ActionResult Edit(FocusSlideWrapper fsw)
        {
            if (ModelState.IsValid)
            {
                FocusSlide FS = db.FocusSlide.FirstOrDefault(fs => fs.focus_id == fsw.focus_id);

                if (FS != null)
                {
                    if (fsw.image != null)
                    {
                        System.IO.File.Delete(Server.MapPath("~/assets/images/" + FS.image_path));
                        string photoName = Guid.NewGuid().ToString() + Path.GetExtension(fsw.image.FileName);
                        fsw.image.SaveAs(Server.MapPath("~/assets/images/" + photoName));
                        FS.image_path = photoName;

                    }
                    if (fsw.audio != null)
                    {
                        System.IO.File.Delete(Server.MapPath("~/assets/audios/" + FS.audio_path));
                        string audioName = Guid.NewGuid().ToString() + Path.GetExtension(fsw.audio.FileName);
                        fsw.audio.SaveAs(Server.MapPath("~/assets/audios/" + audioName));
                        FS.audio_path = audioName;
                    }
                    FS.category = fsw.category;
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "修改成功!";
                    return RedirectToAction("List");
                }
            }
            else
            {
                return View(fsw);
            }
            TempData["ErrorMessage"] = "修改失敗!";
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                FocusSlide FS = db.FocusSlide.FirstOrDefault(fs => fs.focus_id == id);
                if (FS != null)
                {
                    System.IO.File.Delete(Server.MapPath("~/assets/images/" + FS.image_path));
                    System.IO.File.Delete(Server.MapPath("~/assets/audios/" + FS.audio_path));
                    db.FocusSlide.Remove(FS);
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