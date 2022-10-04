// ***********************************************************************
// Assembly         : Khanij
// Author           : Sanjay kumar
// Created          : 07-jan-2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.LeaseType;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class LeaseTypeController : Controller
    {
        ILeaseTypeModel _objLeaseTypeModel;
        MessageEF objobjmodel = new MessageEF();
        public LeaseTypeController(ILeaseTypeModel objLeaseType)
        {
            _objLeaseTypeModel = objLeaseType;
        }

        [Decryption]
        public IActionResult Add(string id = "0")
        {
            LeaseTypeMaster objmodel = new LeaseTypeMaster();
            if (!string.IsNullOrEmpty(id) && id != "0")
            {
              
                objmodel.LeaseTypeId = Convert.ToInt32(id);
                objmodel = _objLeaseTypeModel.Edit(objmodel);
                ViewBag.Button = "Update";
                return View(objmodel);
            }
            else
            {
                objmodel.IsActive = true;
                ViewBag.Button = "Submit";
                return View(objmodel);
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(LeaseTypeMaster objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.CreatedBy =  (int)profile.UserId;
            objmodel.UserLoginId = (int)profile.UserLoginId;

            if (string.IsNullOrEmpty(objmodel.LeaseTypeName))
            {
                ModelState.AddModelError("Lease Type Name", "Lease Type Name  is required");
            }
            if (string.IsNullOrEmpty(objmodel.LeaseTypeCode))
            {
                ModelState.AddModelError("Lease Type Code", "Lease Type Code is required");
            }


            if (ModelState.IsValid)
            {
                if (submit == "Submit")
                {
                    objobjmodel = _objLeaseTypeModel.Add(objmodel);
                }
                else
                {
                    objobjmodel = _objLeaseTypeModel.Update(objmodel);
                }
                if (objobjmodel.Satus == "1" && submit== "Submit")
                {
                    TempData["msg"] = "Data Saved Sucessfully";
                    return RedirectToAction("ViewList");
                }
                if (objobjmodel.Satus == "1")
                {
                    TempData["msg"] = "Data Updated Sucessfully";
                    return RedirectToAction("ViewList");
                }
                else if (objobjmodel.Satus == "2")
                {
                    TempData["msg"] = "Duplicate Data found.";
                    return View(objmodel);
                }
                else
                {
                    TempData["msg"] = "Data not Save Sucessfully";
                    return View(objmodel);
                }
            }
            return View();

        }
        public IActionResult ViewList(LeaseTypeMaster objmodel)
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                ViewBag.ViewList = _objLeaseTypeModel.View(objmodel);
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
            LeaseTypeMaster objmodel = new LeaseTypeMaster();
            objmodel.CreatedBy = (int)profile.UserId;
            objmodel.UserLoginId =(int)profile.UserLoginId;
            objmodel.LeaseTypeId = Convert.ToInt32(id);
            objobjmodel = _objLeaseTypeModel.Delete(objmodel);
            if (objobjmodel.Satus == "1")
            {
                TempData["msg"] = "Data Deleted Sucessfully";
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