using ChilLaxBackEnd.Models;
using ChilLaxBackEnd.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChilLaxBackEnd.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                ChilLaxEntities db = new ChilLaxEntities();
                Member member = db.Member.FirstOrDefault(m => m.member_id == id);
                MemberCredential credential = db.MemberCredential.FirstOrDefault(mc => mc.member_id == id);
                if (member != null && credential != null)
                {
                    db.Member.Remove(member);
                    db.MemberCredential.Remove(credential);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("List");
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("List");
            }

            ChilLaxEntities db = new ChilLaxEntities();

            Member member = db.Member.FirstOrDefault(m => m.member_id == id);

            if (member == null)
            {
                return RedirectToAction("List");
            }

            MemberCredential credential = db.MemberCredential.FirstOrDefault(mc => mc.member_id == id);

            if (credential == null)
            {
                return RedirectToAction("List");
            }

            MemberViewModel mvm = new MemberViewModel
            {
                member_id = member.member_id,
                member_account = credential.member_account,
                member_name = member.member_name,
                member_tel = member.member_tel,
                member_address = member.member_address,
                member_email = member.member_email,
                member_sex = member.member_sex,
                member_birthday = member.member_birthday,
                member_point = member.member_point,
                member_joinTime = member.member_joinTime
            };
            return View(mvm);
        }


        [HttpPost]
        public ActionResult Edit(MemberViewModel mvm)
        {
            ChilLaxEntities db = new ChilLaxEntities();
            Member member = db.Member.FirstOrDefault(m => m.member_id == mvm.member_id);
            MemberCredential credential = db.MemberCredential.FirstOrDefault(mc => mc.member_id == mvm.member_id);

            if (member != null && credential != null)
            {
                if (mvm.member_account != null && mvm.member_name != null && mvm.member_tel != null && mvm.member_email != null && mvm.member_birthday.ToString() != null && mvm.member_joinTime.ToString() != null)
                {
                    if (ModelState.IsValid)
                    {
                        credential.member_account = mvm.member_account;
                        member.member_name = mvm.member_name;
                        member.member_tel = mvm.member_tel;
                        member.member_address = mvm.member_address;
                        member.member_email = mvm.member_email;
                        member.member_birthday = mvm.member_birthday;
                        member.member_point = mvm.member_point;
                        member.member_joinTime = mvm.member_joinTime;
                        member.member_sex = mvm.member_sex;

                        db.SaveChanges();
                        return RedirectToAction("List");
                    }                

                    return RedirectToAction("Edit");
                }
                else
                {
                    //ModelState.AddModelError("", "無法儲存資料。請確保所有必填欄位都已填寫正確。");
                    ViewBag.ErrorMessage = "請填寫所有必填欄位。";
                    return RedirectToAction("Edit");
                }
            }
            return RedirectToAction("List");
        }


        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(MemberCredential MC)
        //{  
        //    ChilLaxEntities db = new ChilLaxEntities();
        //    db.MemberCredential.Add(MC);
        //    db.SaveChanges();
        //    return RedirectToAction("List");
        //}
        public ActionResult List(MemberViewModel mvm)
        {
            ChilLaxEntities db = new ChilLaxEntities();
            Member member = db.Member.FirstOrDefault(m => m.member_id == mvm.member_id);
            MemberCredential credential = db.MemberCredential.FirstOrDefault(mc => mc.member_id == mvm.member_id);
            IEnumerable<MemberViewModel> datas = from m in db.Member
                                                 join mc in db.MemberCredential on m.member_id equals mc.member_id
                                                 select new MemberViewModel
                                                 {
                                                     member_id = m.member_id,
                                                     member_account = mc.member_account,
                                                     member_name = m.member_name,
                                                     member_tel = m.member_tel,
                                                     member_address = m.member_address,
                                                     member_email = m.member_email,
                                                     member_sex = m.member_sex,
                                                     member_birthday = m.member_birthday,
                                                     member_point = m.member_point,
                                                     member_joinTime = m.member_joinTime
                                                 };
            return View(datas);
        }


    }
}