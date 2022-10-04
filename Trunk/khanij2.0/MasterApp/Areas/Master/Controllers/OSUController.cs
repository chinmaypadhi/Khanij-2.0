// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 28-Jan-2021
// Modified by      : Prakash Biswal
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using MasterApp.Areas.Master.Models.OSU;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class OSUController : Controller
    {
        /// <summary>
        /// Global Declaration
        /// </summary>
        IOSUModel _objOSUmasterModel;
        MessageEF objobjmodel = new MessageEF();
        OSUmaster objmodel = new OSUmaster();
        /// <summary>
        /// Constructor Dependency injection
        /// </summary>
        /// <param name="objOSUmasterModel"></param>
        public OSUController(IOSUModel objOSUmasterModel)
        {
            _objOSUmasterModel = objOSUmasterModel;
        }
        /// <summary>
        /// Get Method 
        /// </summary>
        /// <returns></returns>
        public IActionResult Add()
        {
            BindDropdowns();
            ViewBag.Button = "Submit";
            return View(objmodel);
        }
        /// <summary>
        /// Post Method to Add A New Lessee or Licensee
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(OSUmaster objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserId = (int)profile.UserId;
            objmodel.UserLoginId = (int)profile.UserLoginId;
            if (string.IsNullOrEmpty(objmodel.ApplicantName))
            {
                ModelState.AddModelError("ApplicantName", "Applicant Name is required");
            }
            if (!string.IsNullOrEmpty(objmodel.ApplicantName) && (objmodel.ApplicantName.Length > 50))
            {
                ModelState.AddModelError("ApplicantName", "Applicant Name must be less than 50 characters");
            }
            if (string.IsNullOrEmpty(objmodel.UserTypeId.ToString()) || objmodel.UserTypeId.ToString() == "0")
            {
                ModelState.AddModelError("UserTypeId", "Please Select User Type");
                ViewBag.Usertypes = GetUsertype(null);
            }
            if (string.IsNullOrEmpty(objmodel.CompanyId.ToString()) || objmodel.CompanyId.ToString() == "0")
            {
                ModelState.AddModelError("CompanyId", "Please Select Company");
                ViewBag.Company = GetCompany(null);
            }
            if (string.IsNullOrEmpty(objmodel.DistrictID.ToString()) || objmodel.DistrictID.ToString() == "0")
            {
                ModelState.AddModelError("DistrictID", "Please Select District");
                ViewBag.Districts = GetDistrict(null);
            }
            if (string.IsNullOrEmpty(objmodel.EmailID))
            {
                ModelState.AddModelError("EmailID", "EmailID is required");
            }
            if (!string.IsNullOrEmpty(objmodel.EmailID) && (objmodel.EmailID.Length > 100))
            {
                ModelState.AddModelError("EmailID", "EmailID must be less than 100 characters");
            }
            if (string.IsNullOrEmpty(objmodel.MobileNumber))
            {
                ModelState.AddModelError("MobileNumber", "Mobile Number is required");
            }
            if (!string.IsNullOrEmpty(objmodel.MobileNumber) && (objmodel.MobileNumber.Length > 10) || (objmodel.MobileNumber.Length < 10))
            {
                ModelState.AddModelError("MobileNumber", "Mobile Number must be less than equal to 10 characters");
            }
            if (string.IsNullOrEmpty(objmodel.Address))
            {
                ModelState.AddModelError("Address", "Address is required");
            }
            if (!string.IsNullOrEmpty(objmodel.Address) && (objmodel.Address.Length > 500))
            {
                ModelState.AddModelError("Address", "Address must be less than 500 characters");
            }
            if (string.IsNullOrEmpty(objmodel.ID.ToString()) || objmodel.ID.ToString() == "0")
            {
                ModelState.AddModelError("ID", "Please Select Mines Status");
                //ViewBag.Districts = GetDistrict(null);
            }

            if (objmodel.UserTypeId == 7 && string.IsNullOrEmpty(objmodel.LesseeTypeID.ToString()) || objmodel.LesseeTypeID.ToString() == "0")
            {
                ModelState.AddModelError("LesseeTypeID", "Please Select Lease Type");
                ViewBag.Lesseetype = GetLesseetype(null);
            }
            if (objmodel.UserTypeId == 10 && string.IsNullOrEmpty(objmodel.LicenseeTypeID.ToString()) || objmodel.LicenseeTypeID.ToString() == "0")
            {
                ModelState.AddModelError("LicenseeTypeID", "Please Select Licensee Type");
                ViewBag.Licenseetype = GetLicenseetype(null);
            }
            if (ModelState.IsValid)
            {

                objobjmodel = _objOSUmasterModel.Add(objmodel);
                ViewBag.msg = objobjmodel.Data;
               
                if (!string.IsNullOrEmpty(objobjmodel.Password) && !string.IsNullOrEmpty(objobjmodel.UserName))
                {
                    string s = ComputeSha256Hash(objobjmodel.Password).ToUpper();
                    _objOSUmasterModel.UpdateEncryptPassword(new UpdateEncryptPasswordModel() { UserName = objobjmodel.UserName, EncryptPassword = s });
                }

            }
            BindDropdowns();
            return View(objmodel);
        }
        /// <summary>
        /// To bind Dropdowns
        /// </summary>
        public void BindDropdowns()
        {
            ViewBag.Usertypes = GetUsertype(null);
            ViewBag.Districts = GetDistrict(null);
            ViewBag.Company = GetCompany(null);
            ViewBag.Lesseetype = GetLesseetype(null);
            ViewBag.Licenseetype = GetLicenseetype(null);
        }
        /// <summary>
        /// To Get Dropdwon if the user type is Lessee
        /// </summary>
        /// <param name="UserType"></param>
        /// <returns></returns>
        public JsonResult GetLesseeTypeByUserType(string UserType)
        {
            OSUmaster objmodel = new OSUmaster();
            objmodel.UserType = UserType;
            List<OSUmaster> listLesseeTypeResult = new List<OSUmaster>();
            listLesseeTypeResult = _objOSUmasterModel.GetLesseeTypeList(objmodel);
            return Json(listLesseeTypeResult);
        }
        /// <summary>
        /// To Bind District in Dropdown
        /// </summary>
        /// <param name="DistrictID"></param>
        /// <returns></returns>
        private SelectList GetDistrict(int? DistrictID)
        {
            List<OSUmaster> listDistrictResult = new List<OSUmaster>();
            listDistrictResult = _objOSUmasterModel.GetDistrictList(objmodel);
            return new SelectList(listDistrictResult, "DistrictID", "DistrictName", DistrictID);
        }
        /// <summary>
        /// To Bind user type Lessee, Licensee etc
        /// </summary>
        /// <param name="UserTypeId"></param>
        /// <returns></returns>
        private SelectList GetUsertype(int? UserTypeId)
        {
            List<OSUmaster> listUserTypeResult = new List<OSUmaster>();
            listUserTypeResult = _objOSUmasterModel.GetUserTypeList(objmodel);
            return new SelectList(listUserTypeResult, "UserTypeId", "UserType", UserTypeId);
        }
        /// <summary>
        /// To Bind Company in Dropdown
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        private SelectList GetCompany(int? CompanyId)
        {
            List<OSUmaster> listCompanyResult = new List<OSUmaster>();
            listCompanyResult = _objOSUmasterModel.GetCompanyList(objmodel);
            return new SelectList(listCompanyResult, "CompanyId", "CompanyName", CompanyId);
        }
        private SelectList GetLesseetype(int? LesseeTypeID)
        {
            List<OSUmaster> listLesseeTypeResult = new List<OSUmaster>();
            listLesseeTypeResult = _objOSUmasterModel.GetLesseeTypeList(objmodel);
            return new SelectList(listLesseeTypeResult, "ID", "Name", LesseeTypeID);
        }
        /// <summary>
        /// To Get Dropdwon if the user type is Licensee
        /// </summary>
        /// <param name="UserType"></param>
        /// <returns></returns>
        private SelectList GetLicenseetype(int? LicenseeTypeID)
        {
            List<OSUmaster> listLicenseeTypeResult = new List<OSUmaster>();
            listLicenseeTypeResult = _objOSUmasterModel.GetLicenseeTypeList(objmodel);
            return new SelectList(listLicenseeTypeResult, "ID", "Name", LicenseeTypeID);
        }

        #region password encript 
        public static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i <= bytes.Length - 1; i++)
                    builder.Append(bytes[i].ToString("x2"));

                return builder.ToString();
            }
        }

        #endregion
    }
}