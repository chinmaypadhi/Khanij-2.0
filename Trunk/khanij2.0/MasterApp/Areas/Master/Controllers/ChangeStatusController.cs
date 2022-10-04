// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 29-Jan-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using MasterApp.Areas.Master.Models.ChangeStatus;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class ChangeStatusController : Controller
    {
        IChangeStatusModel _objChangeStatusmasterModel;
        private readonly IHostingEnvironment hostingEnvironment;
        MessageEF objobjmodel = new MessageEF();
        ChangeStatusmaster objmodel = new ChangeStatusmaster();
        public ChangeStatusController(IChangeStatusModel objChangeStatusmasterModel, IHostingEnvironment hostingEnvironment)
        {
            _objChangeStatusmasterModel = objChangeStatusmasterModel;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Add()
        {
            ViewBag.Divisions = GetDivision(null);
            ViewBag.Usertypes = GetUsertype(null);
            ViewBag.Button = "Submit";
            return View(objmodel);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Add(ChangeStatusmaster objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserId = profile.UserId;

            if (string.IsNullOrEmpty(objmodel.RegionalID.ToString()) || objmodel.RegionalID.ToString() == "0")
            {
                ModelState.AddModelError("RegionalID", "Please Select Division");
                ViewBag.Divisions = GetDivision(null);
            }
            if (string.IsNullOrEmpty(objmodel.DistrictID.ToString()) || objmodel.DistrictID.ToString() == "0")
            {
                ModelState.AddModelError("DistrictID", "Please Select District");
            }
            if (string.IsNullOrEmpty(objmodel.UserTypeId.ToString()) || objmodel.UserTypeId.ToString() == "0")
            {
                ModelState.AddModelError("UserTypeId", "Please Select User Type");
                ViewBag.Usertypes = GetUsertype(null);
            }
            if (string.IsNullOrEmpty(objmodel.UserId.ToString()) || objmodel.UserId.ToString() == "0")
            {
                ModelState.AddModelError("UserId", "Please Select User");
            }
            if (string.IsNullOrEmpty(objmodel.newSatus))
            {
                ModelState.AddModelError("newSatus", "Current Status is required");
            }
            if (string.IsNullOrEmpty(objmodel.ID.ToString()) || objmodel.ID.ToString() == "0")
            {
                ModelState.AddModelError("ID", "Please Select Change To Status");
            }
            if (string.IsNullOrEmpty(objmodel.Remarks))
            {
                ModelState.AddModelError("Remarks", "Remarks is required");
            }
            if (objmodel.Document == null)
            {
                ModelState.AddModelError("Document", "Select Notesheet");
            }
            if (ModelState.IsValid)
            {
                if (submit == "Submit")
                {
                    #region File Upload
                    string uniqueFileName = null; string filePath = null;
                    if (objmodel.Document != null)
                    {
                        string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "UpdateStatusDocuments");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + objmodel.Document.FileName;
                        filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                            objmodel.Document.CopyTo(fileStream);
                    }
                    #endregion
                    objmodel.Document_Name = uniqueFileName;
                    objmodel.Document_Path = filePath;
                    objmodel.Document = null;
                    objobjmodel = _objChangeStatusmasterModel.Add(objmodel);
                }
                if (objobjmodel.Satus == "1" && submit == "Submit")
                {
                    TempData["msg"] = "Status Changed Successfully";
                    ModelState.Clear();
                    return RedirectToAction("Add");
                }
                else
                {
                    ViewBag.msg = "Data not Saved Sucessfully";
                    ViewBag.Divisions = GetDivision(null);
                    ViewBag.Usertypes = GetUsertype(null);
                    return View();
                }
            }
            else
            {
                ViewBag.Divisions = GetDivision(null);
                ViewBag.Usertypes = GetUsertype(null);
                return View(objmodel);
            }
        }
        //public void BindDropdowns(ChangeStatusmaster objmodel)
        //{
        //    List<ChangeStatusmaster> listDivisionResult = new List<ChangeStatusmaster>();
        //    listDivisionResult = _objChangeStatusmasterModel.GetDivisionList(objmodel);
        //    List<ChangeStatusmaster> listUserTypeResult = new List<ChangeStatusmaster>();
        //    listUserTypeResult = _objChangeStatusmasterModel.GetUserTypeList(objmodel);
        //    ViewBag.Divisions = new SelectList(listDivisionResult, "RegionalID", "RegionalName", objmodel.RegionalID);
        //    ViewBag.Usertypes = new SelectList(listUserTypeResult, "UserTypeId", "UserType", objmodel.UserId);
        //}
        public JsonResult GetDistrictByDivisionID(int? RegionalID)
        {
            ChangeStatusmaster objmodel = new ChangeStatusmaster();
            objmodel.RegionalID = RegionalID;
            List<ChangeStatusmaster> listDistrictResult = new List<ChangeStatusmaster>();
            listDistrictResult = _objChangeStatusmasterModel.GetDistrictList(objmodel);
            return Json(listDistrictResult);
        }
        public JsonResult GetUserNameByUserType(int DistirctId, string UserType)
        {
            ChangeStatusmaster objmodel = new ChangeStatusmaster();
            objmodel.DistirctId = DistirctId;
            objmodel.RoleType = UserType;
            List<ChangeStatusmaster> listUserNameResult = new List<ChangeStatusmaster>();
            listUserNameResult = _objChangeStatusmasterModel.GetUserNameList(objmodel);
            return Json(listUserNameResult);
        }
        public JsonResult GetChangeStatusByUserType(string UserType)
        {
            ChangeStatusmaster objmodel = new ChangeStatusmaster();
            objmodel.UserType = UserType;
            List<ChangeStatusmaster> listChangeStatusResult = new List<ChangeStatusmaster>();
            listChangeStatusResult = _objChangeStatusmasterModel.GetChangeStatusList(objmodel);
            return Json(listChangeStatusResult);
        }
        public JsonResult GetCurrentStatus(int? UserID)
        {
            try
            {
                ChangeStatusmaster objmodel = new ChangeStatusmaster();
                objmodel.UserId = UserID;
                ChangeStatusmaster CurrentStatusResult = new ChangeStatusmaster();
                CurrentStatusResult = _objChangeStatusmasterModel.GetCurrentStatusList(objmodel);
                return Json(CurrentStatusResult.Status);
            }
            catch (Exception)
            {
                return null;
            }
        }
        private SelectList GetDivision(int? RegionalID)
        {
            List<ChangeStatusmaster> listDivisionResult = new List<ChangeStatusmaster>();
            listDivisionResult = _objChangeStatusmasterModel.GetDivisionList(objmodel);
            return new SelectList(listDivisionResult, "RegionalID", "RegionalName",RegionalID);
        }
        private SelectList GetUsertype(int? UserId)
        {
            List<ChangeStatusmaster> listUserTypeResult = new List<ChangeStatusmaster>();
            listUserTypeResult = _objChangeStatusmasterModel.GetUserTypeList(objmodel);
            return new SelectList(listUserTypeResult, "UserTypeId", "UserType",UserId);
        }
    }
}