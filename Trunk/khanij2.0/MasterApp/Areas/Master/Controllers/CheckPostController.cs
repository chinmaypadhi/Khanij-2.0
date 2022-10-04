// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 20-Jan-2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.Checkpost;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class CheckPostController : Controller
    {
        ICheckPostModel _objCheckPostmasterModel;
        MessageEF objobjmodel = new MessageEF();
        Checkpostmaster objmodel = new Checkpostmaster();
        public CheckPostController(ICheckPostModel objCheckPostmasterModel)
        {
            _objCheckPostmasterModel = objCheckPostmasterModel;
        }
        [Decryption]
        public IActionResult Add(string id = "0")
        {                    
            if (!string.IsNullOrEmpty(id) && id != "0")
            {
                objmodel.CheckPostId = Convert.ToInt32(id);
                objmodel = _objCheckPostmasterModel.Edit(objmodel);
                ViewBag.Districts = GetDistrict(objmodel.DistrictID);
                ViewBag.Users = GetUser(objmodel.UserID);
                ViewBag.Button = "Update";
                return View(objmodel);
            }
            else
            {
                objmodel.IsActive = true;
                ViewBag.Districts = GetDistrict(null);
                ViewBag.Users = GetUser(null);
                ViewBag.Button = "Submit";
                return View(objmodel);
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(Checkpostmaster objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.CreatedBy = profile.UserId;
            
            if (string.IsNullOrEmpty(objmodel.CheckPostName))
            {
                ModelState.AddModelError("CheckpostName", "Checkpost Name is required");
            }
            if (!string.IsNullOrEmpty(objmodel.CheckPostName) && (objmodel.CheckPostName.Length > 50))
            {
                ModelState.AddModelError("CheckpostName", "Checkpost Name must be less than 50 characters");
            }
            if (string.IsNullOrEmpty(objmodel.DistrictID.ToString()) || objmodel.DistrictID.ToString() == "0")
            {
                ModelState.AddModelError("DistrictID", "Please Select District");
                ViewBag.Districts = GetDistrict(null);
            }
            if (string.IsNullOrEmpty(objmodel.UserID.ToString()) || objmodel.UserID.ToString() == "0")
            {
                ModelState.AddModelError("UserID", "Please Select User");
                ViewBag.Users = GetUser(null);
            }
            if (ModelState.IsValid)
            {
                if (submit == "Submit")
                {
                    objobjmodel = _objCheckPostmasterModel.Add(objmodel);
                }
                else
                {
                    objobjmodel = _objCheckPostmasterModel.Update(objmodel);
                }
                if (objobjmodel.Satus == "1" && submit == "Submit")
                {
                    objmodel.IsActive = true;
                    TempData["msg"] = "Checkpost Saved Sucessfully.";
                    objmodel.CheckPostName = "";
                    ModelState.Clear();
                    return RedirectToAction("Viewlist", "CheckPost", new { Area = "master" });
                }
                if (objobjmodel.Satus == "1")
                {
                    TempData["msg"] = "Checkpost Updated Sucessfully.";
                    return RedirectToAction("Viewlist", "CheckPost", new { Area = "master" });
                }
                if (objobjmodel.Satus == "3")
                {
                    ViewBag.msg = "Checkpost Already Exist!";
                    ViewBag.Districts = GetDistrict(null);
                    ViewBag.Users = GetUser(null);
                    ViewBag.Button = objmodel.CheckPostId > 0 ? "Update" : "Submit";
                    return View(objmodel);
                }
                else
                {
                    ViewBag.msg = "Data not Saved Sucessfully!";
                    ViewBag.Districts = GetDistrict(null);
                    ViewBag.Users = GetUser(null);
                    ViewBag.Button = objmodel.CheckPostId > 0 ? "Update" : "Submit";
                    return View(objmodel);
                }
            }
            else
            {
                ViewBag.Districts = GetDistrict(null);
                ViewBag.Users = GetUser(null);
                ViewBag.Button = objmodel.CheckPostId > 0 ? "Update" : "Submit";
                return View();
            }
        }
        public IActionResult ViewList(Checkpostmaster objmodel)
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                ViewBag.ViewList = _objCheckPostmasterModel.View(objmodel);
                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult ViewList(Checkpostmaster objmodel, string Show1)
        {
            try
            {
                ViewBag.ViewList = _objCheckPostmasterModel.View(objmodel);
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
            Checkpostmaster objmodel = new Checkpostmaster();
            objmodel.CreatedBy = (int)profile.UserId;
            
           
            objmodel.CheckPostId = Convert.ToInt32(id);

            objobjmodel = _objCheckPostmasterModel.Delete(objmodel);

            if (objobjmodel.Satus == "1")
            {
                TempData["msg"] = "Checkpost Deleted Sucessfully.";
                return RedirectToAction("ViewList");
            }
            else
            {
                TempData["msg"] = "Data not Deleted Sucessfully.";
                return RedirectToAction("ViewList");
            }


        }
        private SelectList GetDistrict(int? DistrictID)
        {
            List<Checkpostmaster> listDistrictResult = new List<Checkpostmaster>();
            listDistrictResult = _objCheckPostmasterModel.GetDistrictList(objmodel);            
            return new SelectList(listDistrictResult, "DistrictID", "DistrictName", DistrictID);
        }
        private SelectList GetUser(int? UserID)
        {
            List<Checkpostmaster> listUserResult = new List<Checkpostmaster>();
            listUserResult = _objCheckPostmasterModel.GetUserList(objmodel);
            return new SelectList(listUserResult, "UserID", "UserName",UserID);
        }
    }
}