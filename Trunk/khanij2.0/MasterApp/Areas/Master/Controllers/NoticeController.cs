// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.Models.MIneral;
using MasterApp.Areas.Master.Models.NoticeMaster;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using MasterApp.ActionFilter;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class NoticeController : Controller
    {
        INoticeMasterModel _objNoticemasterModel;
        MessageEF objobjmodel = new MessageEF();
        public NoticeController(INoticeMasterModel objNoticemasterModel)
        {
            _objNoticemasterModel = objNoticemasterModel;
        }
        [Decryption]
        public IActionResult Add(string id = "0")
        {
            Noticemaster objmodel = new Noticemaster();
            if (!string.IsNullOrEmpty(id) && id != "0")
            {
                objmodel.NoticeID = Convert.ToInt32(id);
                objmodel = _objNoticemasterModel.Edit(objmodel);
                ViewBag.Button = "Update";
                return View(objmodel);
            }
            else
            {
                objmodel.IsActive = 1;
                ViewBag.Button = "Submit";
                return View(objmodel);
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(Noticemaster objmodel, string submit)
        {

            if (string.IsNullOrEmpty(objmodel.NoticeText))
            {
                ModelState.AddModelError("CheckpostName", "Checkpost Name is required");
            }
            if (ModelState.IsValid)
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.CreatedBy = (int)profile.UserId;

                if (submit == "Submit")
                {
                    objobjmodel = _objNoticemasterModel.Add(objmodel);
                }
                else
                {
                    objobjmodel = _objNoticemasterModel.Update(objmodel);
                }
                if (objobjmodel.Satus == "1")
                {
                    if (submit == "Submit")
                    {
                        TempData["msg"] = "Data Save Sucessfully";
                    }
                    else
                    {
                        TempData["msg"] = "Data Updated Sucessfully";
                    }
                    // return View();
                    return RedirectToAction("ViewList");
                }
                else
                {
                    ViewBag.msg = "Data not Save Sucessfully";
                    return View(objmodel);
                }
            }
            return View();
        }

        public IActionResult ViewList(Noticemaster objmodel)
        {
            try
            {
                ViewBag.ViewList = _objNoticemasterModel.View(objmodel);
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult ViewList(Noticemaster objmodel, string Show1)
        {
            try
            {
                ViewBag.ViewList = _objNoticemasterModel.View(objmodel);
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [Decryption]
        public IActionResult Delete(string id = "0")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            Noticemaster objmodel = new Noticemaster();
            objmodel.CreatedBy = (int)profile.UserId;
            objmodel.NoticeID = Convert.ToInt32(id);
            objobjmodel = _objNoticemasterModel.Delete(objmodel);

            if (objobjmodel.Satus == "1")
            {
                TempData["msgDel"] = "Data Deleted Sucessfully";
                return RedirectToAction("ViewList");
            }
            else
            {
                TempData["msgDel"] = "Data not Deleted Sucessfully";
                return RedirectToAction("ViewList");
            }


        }
    }
}