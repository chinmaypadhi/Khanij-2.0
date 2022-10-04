// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 18-Jan-2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.Route;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class RouteController : Controller
    {
        IRouteModel _objRoutemasterModel;
        MessageEF objobjmodel = new MessageEF();
        Routemaster objmodel = new Routemaster();
        List<Routemaster> listDistrictResult = new List<Routemaster>();
        public RouteController(IRouteModel objRoutemasterModel)
        {
            _objRoutemasterModel = objRoutemasterModel;
        }
        [Decryption]
        public IActionResult Add(string id = "0")
        {
            if (!string.IsNullOrEmpty(id) && id != "0")
            {

                objmodel.RouteID = Convert.ToInt32(id);
                objmodel = _objRoutemasterModel.Edit(objmodel);
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
        private SelectList GetDistrict(int? DistrictID)
        {
            listDistrictResult = _objRoutemasterModel.GetDistrictList(objmodel);
            return new SelectList(listDistrictResult, "DistrictID", "DistrictName", DistrictID);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(Routemaster objmodel, string submit)
        {
            try
            {
               
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.CreatedBy = profile.UserId; 
                //objmodel.UserLoginID = profile.UserLoginId;
                if (string.IsNullOrEmpty(objmodel.DistrictID.ToString()) || objmodel.DistrictID.ToString() == "0")
                {
                    ModelState.AddModelError("DistrictID", "Please Select District");
                    ViewBag.Districts = GetDistrict(null);
                }
                if (string.IsNullOrEmpty(objmodel.RouteName))
                {
                    ModelState.AddModelError("RouteName", "Route Name is required");
                }
                if (!string.IsNullOrEmpty(objmodel.RouteName) && (objmodel.RouteName.Length > 50))
                {
                    ModelState.AddModelError("RouteName", "Route Name must be less than 50 characters");
                }
                if (ModelState.IsValid)
                {
                    objmodel.CreatedBy = profile.UserId;
                    if (submit == "Submit")
                    {
                        objobjmodel = _objRoutemasterModel.Add(objmodel);
                    }
                    else
                    {
                        objobjmodel = _objRoutemasterModel.Update(objmodel);
                    }
                    if (objobjmodel.Satus == "1" && submit == "Submit")
                    {
                        //ViewBag.msg = "Data Saved Sucessfully";
                        // return View();
                        //return RedirectToAction("ViewList");
                        objmodel.IsActive = true;
                        TempData["msg"] = "Route Name Saved Sucessfully";
                        objmodel.RouteName = "";
                        ModelState.Clear();
                        //return View(objmodel);
                        return RedirectToAction("ViewList");
                    }
                    if (objobjmodel.Satus == "1")
                    {
                        TempData["msg"] = "Route Name Updated Sucessfully";
                        return RedirectToAction("Viewlist", "Route", new { Area = "master" });
                    }
                    if (objobjmodel.Satus == "3")
                    {
                        ViewBag.msg = "Route Already Exist!";
                        ViewBag.Districts = GetDistrict(null);
                        ViewBag.Button = objmodel.RouteID > 0 ? "Update" : "Submit";
                        return View(objmodel);
                    }
                    else
                    {
                        ViewBag.msg = "Data not Saved Sucessfully";
                        ViewBag.Districts = GetDistrict(null);
                        ViewBag.Button = objmodel.RouteID > 0 ? "Update" : "Submit";
                        return View();
                    }
                }
                else
                {
                    ViewBag.Districts = GetDistrict(null);
                    ViewBag.Button = objmodel.RouteID > 0 ? "Update" : "Submit";
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult ViewList(Routemaster objmodel)
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                ViewBag.ViewList = _objRoutemasterModel.View(objmodel);
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult ViewList(Routemaster objmodel, string Show1)
        {
            try
            {
                ViewBag.ViewList = _objRoutemasterModel.View(objmodel);
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
            Routemaster objmodel = new Routemaster();
            objmodel.CreatedBy = (int)profile.UserId;
            //objmodel.UserLoginID = (int)profile.UserLoginId;
            
            objmodel.RouteID = Convert.ToInt32(id);
            objobjmodel = _objRoutemasterModel.Delete(objmodel);
            if (objobjmodel.Satus == "1")
            {
                TempData["msg"] = "Route Name Deleted Sucessfully";
                return RedirectToAction("ViewList");
            }
            else
            {
                TempData["msg"] = "Data not Deleted Sucessfully";
                return RedirectToAction("ViewList");
            }
        }
    }
}