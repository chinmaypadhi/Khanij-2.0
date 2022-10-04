// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 21-Jan-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using MasterApp.Areas.Master.Models.WeighBridge;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class WeighBridgeController : Controller
    {
        IWeighBridgeModel _objWeighBridgemasterModel;
        MessageEF objobjmodel = new MessageEF();
        WeighBridgemaster objmodel = new WeighBridgemaster();
        public WeighBridgeController(IWeighBridgeModel objWeighBridgemasterModel)
        {
            _objWeighBridgemasterModel = objWeighBridgemasterModel;
        }
        public IActionResult Add(int id = 0)
        {            
            if (id != 0)
            {
                objmodel.WeighBridgeId = id;
                objmodel = _objWeighBridgemasterModel.Edit(objmodel);
                ViewBag.Districts = GetDistrict(objmodel.DistrictID);
                ViewBag.Button = "Update";
                return View(objmodel);
            }
            else
            {
                objmodel.IsActive = true;
                ViewBag.Districts = GetDistrict(null);
                ViewBag.Button = "Submit";
                return View(objmodel);
            }
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Add(WeighBridgemaster objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.CreatedBy =  profile.UserId;                                   
            if (string.IsNullOrEmpty(objmodel.WeighBridgeName))
            {
                ModelState.AddModelError("WeighBridgeName", "WeighBridge Name is required");
            }
            if (!string.IsNullOrEmpty(objmodel.WeighBridgeName) && (objmodel.WeighBridgeName.Length > 50))
            {
                ModelState.AddModelError("WeighBridgeName", "WeighBridge Name must be less than 50 characters");
            }
            if (string.IsNullOrEmpty(objmodel.DistrictID.ToString()) || objmodel.DistrictID.ToString() == "0")
            {
                ModelState.AddModelError("DistrictID", "Please Select District");
                ViewBag.Districts = GetDistrict(null);
            }                      
            if (string.IsNullOrEmpty(objmodel.Address))
            {
                ModelState.AddModelError("Address", "Address is required");
            }
            if (string.IsNullOrEmpty(objmodel.UserName))
            {
                ModelState.AddModelError("UserName", "User Name is required");
            }
            if (!string.IsNullOrEmpty(objmodel.UserName) && (objmodel.UserName.Length > 50))
            {
                ModelState.AddModelError("UserName", "User Name must be less than 50 characters");
            }
            if (string.IsNullOrEmpty(objmodel.Password))
            {
                ModelState.AddModelError("Password", "Password is required");
            }
            if (!string.IsNullOrEmpty(objmodel.Password) && (objmodel.Password.Length > 20))
            {
                ModelState.AddModelError("Password", "Password must be less than 20 characters");
            }
            if (ModelState.IsValid)
            {
                if (submit == "Submit")
                {
                    objobjmodel = _objWeighBridgemasterModel.Add(objmodel);
                }
                else
                {
                    objobjmodel = _objWeighBridgemasterModel.Update(objmodel);
                }
                if (objobjmodel.Satus == "1" && submit == "Submit")
                {
                    objmodel.IsActive = true;
                    TempData["msg"] = "WeighBridge Saved Sucessfully";
                    objmodel.WeighBridgeName = "";
                    ModelState.Clear();
                    return RedirectToAction("Viewlist", "WeighBridge", new { Area = "master" });
                }
                if (objobjmodel.Satus == "1")
                {
                    TempData["msg"] = "WeighBridge Updated Sucessfully";
                    return RedirectToAction("Viewlist", "WeighBridge", new { Area = "master" });
                }
                if (objobjmodel.Satus == "3")
                {
                    ViewBag.msg = "WeighBridge Already Exist!";
                    ViewBag.Districts = GetDistrict(null);
                    ViewBag.Button = objmodel.WeighBridgeId > 0 ? "Update" : "Submit";
                    return View(objmodel);
                }
                else
                {
                    ViewBag.msg = "Data not Saved Sucessfully";
                    ViewBag.Districts = GetDistrict(null);
                    ViewBag.Button = objmodel.WeighBridgeId > 0 ? "Update" : "Submit";
                    return View(objmodel);
                }
            }
            else
            {
                ViewBag.Districts = GetDistrict(null);
                ViewBag.Button = objmodel.WeighBridgeId > 0 ? "Update" : "Submit";
                return View();
            }
        }
        public IActionResult ViewList(WeighBridgemaster objmodel)
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                ViewBag.ViewList = _objWeighBridgemasterModel.View(objmodel);
                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult ViewList(WeighBridgemaster objmodel, string Show1)
        {
            try
            {
                ViewBag.ViewList = _objWeighBridgemasterModel.View(objmodel);
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public IActionResult Delete(int id = 0)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            WeighBridgemaster objmodel = new WeighBridgemaster();
            //objmodel.CreatedBy = (int)profile.UserId;
            //objmodel.UserLoginID = (int)profile.UserLoginId;
            objmodel.CreatedBy = 1;
            //objmodel.UserLoginID = 1;
            objmodel.WeighBridgeId = id;

            objobjmodel = _objWeighBridgemasterModel.Delete(objmodel);

            if (objobjmodel.Satus == "1")
            {
                TempData["msg"] = "WeighBridge Deleted Sucessfully";
                return RedirectToAction("ViewList");
            }
            else
            {
                TempData["msg"] = "Data not Deleted Sucessfully";
                return RedirectToAction("ViewList");
            }
        }
        private SelectList GetDistrict(int? DistrictID)
        {
            List<WeighBridgemaster> listDistrictResult = new List<WeighBridgemaster>();
            listDistrictResult = _objWeighBridgemasterModel.GetDistrictList(objmodel);
            return new SelectList(listDistrictResult, "DistrictID", "DistrictName", DistrictID);
        }
    }
}