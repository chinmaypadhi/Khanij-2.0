// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 28-Jan-2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using MasterApp.Areas.Master.Models.ApplicationSetting;
using MasterEF;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MasterApp.Web;
using MasterApp.ActionFilter;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class ApplicationSettingController : Controller
    {
        IApplicationSettingModel _objApplicationSettingmasterModel;
        MessageEF objobjmodel = new MessageEF();
        public ApplicationSettingController(IApplicationSettingModel objApplicationSettingmasterModel)
        {
            _objApplicationSettingmasterModel = objApplicationSettingmasterModel;
        }
        
        public IActionResult Add()
        {
            ApplicationSettingmaster objmodel = new ApplicationSettingmaster();
            objmodel = _objApplicationSettingmasterModel.Edit(objmodel);
            ViewBag.Button = "Update";
            return View(objmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(ApplicationSettingmaster objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserId = profile.UserId;

            if (objmodel.EXPIRY_DATE_ALERT_COUNT==null)
            {
                ModelState.AddModelError("EXPIRY_DATE_ALERT_COUNT", "Expiry Alert Count is required");
            }
            if (objmodel.TP_OFFLINE_NET_WEIGHT == null)
            {
                ModelState.AddModelError("TP_OFFLINE_NET_WEIGHT", "TP Offline Net Weight is required");
            }
            if (objmodel.FORWARDINGNOTE_GRACE_WEIGHT == null)
            {
                ModelState.AddModelError("FORWARDINGNOTE_GRACE_WEIGHT", "RTP Trip Close Tolerance Weight is required");
            }
            if (objmodel.TIMELINE_OF_REPLY_OF_NOTICE == null)
            {
                ModelState.AddModelError("TIMELINE_OF_REPLY_OF_NOTICE", "Timeline of Reply of Notice is required");
            }
            if (objmodel.EXPIRY_DATE_INTIMATION == null)
            {
                ModelState.AddModelError("EXPIRY_DATE_INTIMATION", "Validity Expired Intimation is required");
            }
            if (ModelState.IsValid)
            {
                
                objobjmodel = _objApplicationSettingmasterModel.Update(objmodel);
                
                TempData["msg"] = objobjmodel.Satus;
                return RedirectToAction("Viewlist");
            }
            else
            {
                ViewBag.Button = "Update";
                return View(objmodel);
            }
        }
        public IActionResult ViewList(ApplicationSettingmaster objmodel)
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = "Updated Successfully.";
                }
                ViewBag.ViewList = _objApplicationSettingmasterModel.View(objmodel);
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult ViewList(ApplicationSettingmaster objmodel, string Show1)
        {
            try
            {
                ViewBag.ViewList = _objApplicationSettingmasterModel.View(objmodel);
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}