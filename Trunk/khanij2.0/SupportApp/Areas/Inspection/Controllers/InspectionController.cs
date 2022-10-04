// ***********************************************************************
//  Controller Name          : Inspection
//  Desciption               : Add view of inspection report submitted by Mining Inspector
//  Created By               : Debaraj Swain
//  Created On               : 25 May 2021
// ***********************************************************************

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupportApp.Web;
using SupportEF;
using SupportApp.Areas.Inspection.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Net.Mail;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using SupportApp.ActionFilter;

namespace SupportApp.Areas.Inspection.Controllers
{
    [Area("Inspection")]
    public class InspectionController : Controller
    {
        IinspectionModel _objIInspectionModel;
        MessageEF objobjmodel = new MessageEF();
        private readonly IHostingEnvironment hostingEnvironment;
        public InspectionController(IinspectionModel objInspectionModel, IHostingEnvironment hostingEnvironment)
        {
            _objIInspectionModel = objInspectionModel;
            this.hostingEnvironment = hostingEnvironment;

        }
        /// <summary>
        /// Get portion of Add inspection Report
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        [SkipImportantTask]
        public IActionResult SubmitInspectionReport(string id="0")
        {
            InspectionModel obj = new InspectionModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            obj.IntUid = profile.UserId;
            obj = _objIInspectionModel.GetUDetails(obj);
            var x = _objIInspectionModel.GetUserType(obj);
            ViewBag.Details = "submit";
            if (id !="0")
            {
                InspectionModel obj1 = new InspectionModel();
                obj1.USERID =Convert.ToInt32(id);
                ViewBag.showDetails = _objIInspectionModel.GetInspectionDetails(obj1);
                ViewBag.Details = "detailsData";
            }
            
            if (x.DDL != null)
            {
                ViewBag.ViewUTList = x.DDL.Select(c => new SelectListItem
                {
                    Text = c.TEXT,
                    Value = c.VALUE.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewUTList = Enumerable.Empty<SelectListItem>();
            }
            if (ViewBag.Details == "detailsData")
            {
                obj.LesseeLicenseeUserTypeId = ViewBag.showDetails[0].insId;
            }
            return View(obj);
        }
        /// <summary>
        /// Post portion of Add inspection Report
        /// </summary>
        /// <param name="model"></param>
        /// <param name="listTerms"></param>
        /// <returns></returns>
        [HttpPost]
        [SkipImportantTask]
        public ActionResult SubmitInspectionReport(InspectionModel model, ListTearmsAndCondition listTerms)
        {
            if (string.IsNullOrEmpty(model.insSubject))
            {
                ModelState.AddModelError("insSubject", "Subject is required");
            }
            if (string.IsNullOrEmpty(model.insDate))
            {
                ModelState.AddModelError("insDate", "Date is required");
            }
            if (string.IsNullOrEmpty(model.inspectorCode))
            {
                ModelState.AddModelError("insDate", "Inspector Code is required");
            }
            if (string.IsNullOrEmpty(model.inspectorName))
            {
                ModelState.AddModelError("inspectorName", "Inspector name is required");
            }
            if (string.IsNullOrEmpty(model.inspectorDesignation))
            {
                ModelState.AddModelError("inspectorDesignation", "Inspector Designation is required");
            }
            if (string.IsNullOrEmpty(model.District))
            {
                ModelState.AddModelError("District", "District  is required");
            }
            if (string.IsNullOrEmpty(model.State))
            {
                ModelState.AddModelError("State", "State  is required");
            }
           
            if (string.IsNullOrEmpty(model.insMobileNo))
            {
                ModelState.AddModelError("insMobileNo", "Mobile No  is required");
            }
            if (string.IsNullOrEmpty(model.insEmail))
            {
                ModelState.AddModelError("insEmail", "Email No  is required");
            }
            //if (string.IsNullOrEmpty(model.LesseeLicenseeVillage))
            //{
            //    ModelState.AddModelError("LesseeLicenseeVillage", "Village is required");
            //}
            //if (string.IsNullOrEmpty(model.LesseeLicenseeTehsil))
            //{
            //    ModelState.AddModelError("LesseeLicenseeTehsil", "Tehsil is required");
            //}
            //if (string.IsNullOrEmpty(model.LesseeLicenseeDistrict))
            //{
            //    ModelState.AddModelError("LesseeLicenseeDistrict", "District is required");
            //}
            //if (string.IsNullOrEmpty(model.LesseeLicenseePanchayat))
            //{
            //    ModelState.AddModelError("LesseeLicenseePanchayat", "Panchayat is required");
            //}
            //if (string.IsNullOrEmpty(model.LesseeLicenseePoliceStation))
            //{
            //    ModelState.AddModelError("LesseeLicenseePoliceStation", "Police Station is required");
            //}
           
            //if (string.IsNullOrEmpty(model.LesseeLicenseeMobile))
            //{
            //    ModelState.AddModelError("LesseeLicenseeMobile", "Pin code is required");
            //}
            //if (string.IsNullOrEmpty(model.LesseeLicenseeEmail))
            //{
            //    ModelState.AddModelError("LesseeLicenseeEmail", "Email is required");
            //}
            if (model.LesseeLicenseeUserTypeId==0)
            {
                ModelState.AddModelError("LesseeLicenseeUserTypeId", "User ID is required");
            }
            if (model.IdofLesseeLicensee==0)
            {
                ModelState.AddModelError("IdofLesseeLicensee", "Name is required");
            }
          
           
            if (model.InspectionReport ==null)
            {
                ModelState.AddModelError("InspectionReport", "Inspection Report is required");
            }
            if (model.Bayan == null)
            {
                ModelState.AddModelError("Bayan", "Bayan is required");
            }
            if (ModelState.IsValid)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("insId", typeof(int));
                dt.Columns.Add("IssuanceOfNoticeId", typeof(int));
                dt.Columns.Add("IsSatisfied", typeof(int));
                dt.Columns.Add("Remarks", typeof(string));


                int insId = 0;
                int IssuanceOfNoticeId = 0;
                int IsSatisfied = 0;
                string Remarks = "";
                for (int index = 0; index < listTerms.IssuanceOfNoticeId.Count; index++)
                {
                    IssuanceOfNoticeId = listTerms.IssuanceOfNoticeId[index];
                    if (listTerms.isSatisfied.Contains(IssuanceOfNoticeId))
                    {
                        Remarks = listTerms.remarks[index];
                        dt.Rows.Add(0, IssuanceOfNoticeId, 1, Remarks);
                    }
                    else
                    {
                        Remarks = listTerms.remarks[index];
                        dt.Rows.Add(insId, IssuanceOfNoticeId, 0, Remarks);
                    }
                }

                model.listTerms = listTerms;
                string InspectionFileName = null; string InspectionfilePath = null;
                string PanchnamaFileName = null; string PanchnamaFilePath = null;
                string BayanFileName = null; string BayanFilePath = null;
                string PhotosFileName = null; string PhotosFilePath = null;
                string OthersFileName = null; string OthersFilePath = null;
                if (model.InspectionReport != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Inspection\\InspectionReportDoc");
                    InspectionFileName = Guid.NewGuid().ToString() + "_" + model.InspectionReport.FileName;
                    InspectionfilePath = Path.Combine(uploadsFolder, InspectionFileName);
                    using (var fileStream = new FileStream(InspectionfilePath, FileMode.Create))
                        model.InspectionReport.CopyTo(fileStream);
                }
                if (model.Panchaname != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Inspection\\Panchnama");
                    PanchnamaFileName = Guid.NewGuid().ToString() + "_" + model.Panchaname.FileName;
                    PanchnamaFilePath = Path.Combine(uploadsFolder, PanchnamaFileName);
                    using (var fileStream = new FileStream(PanchnamaFilePath, FileMode.Create))
                        model.Panchaname.CopyTo(fileStream);
                }
                if (model.Bayan != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Inspection\\Bayan");
                    BayanFileName = Guid.NewGuid().ToString() + "_" + model.Bayan.FileName;
                    BayanFilePath = Path.Combine(uploadsFolder, BayanFileName);
                    using (var fileStream = new FileStream(BayanFilePath, FileMode.Create))
                        model.Bayan.CopyTo(fileStream);
                }
                if (model.Photos != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Inspection\\Photos");
                    PhotosFileName = Guid.NewGuid().ToString() + "_" + model.Photos.FileName;
                    PhotosFilePath = Path.Combine(uploadsFolder, PhotosFileName);
                    using (var fileStream = new FileStream(PhotosFilePath, FileMode.Create))
                        model.Photos.CopyTo(fileStream);
                }
                if (model.Others != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Inspection\\Others");
                    OthersFileName = Guid.NewGuid().ToString() + "_" + model.Others.FileName;
                    OthersFilePath = Path.Combine(uploadsFolder, OthersFileName);
                    using (var fileStream = new FileStream(OthersFilePath, FileMode.Create))
                        model.Others.CopyTo(fileStream);
                }


                if (InspectionFileName != null && InspectionfilePath != null)
                {
                    model.Inspection_Report_FILE_PATH = InspectionfilePath;
                    model.Inspection_Report_FILE_NAME = InspectionFileName;
                }
                if (PanchnamaFileName != null && PanchnamaFilePath != null)
                {

                    model.Panchnama_FILE_NAME = InspectionFileName;
                    model.Panchnama_FILE_PATH = InspectionfilePath;

                }
                if (BayanFileName != null && BayanFilePath != null)
                {

                    model.Bayan_FILE_NAME = BayanFileName;
                    model.Bayan_FILE_PATH = BayanFilePath;

                }
                if (PhotosFileName != null && PhotosFilePath != null)
                {

                    model.Photos_FILE_NAME = PhotosFileName;
                    model.Photos_FILE_PATH = PhotosFilePath;

                }
                if (OthersFileName != null && OthersFilePath != null)
                {

                    model.Others_FILE_NAME = OthersFileName;
                    model.Others_FILE_PATH = OthersFilePath;

                }
                string jsonSerialize = JsonConvert.SerializeObject(dt, Formatting.Indented);
                model.jsonSerialize = jsonSerialize;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                model.USERID = profile.UserId;
                model.inspectorId = profile.UserId;
                model.InspectionReport = null;
                model.Panchaname = null;
                model.Bayan = null;
                model.Photos = null;
                model.Others = null;

                objobjmodel = _objIInspectionModel.AddInspectionData(model);
                string objReturnData = objobjmodel.Satus;

                if (objReturnData != null && !string.IsNullOrEmpty(Convert.ToString(objReturnData)))
                {
                    TempData["result"] = "Your Inspection Report has been submitted successfully."; // Success
                    return RedirectToAction("SubmitInspectionReport", "Inspection", new { Area = "Inspection" });
                }
                else
                {
                    TempData["resultFailed"] = "Your Inspection Report has not been submitted. Please try after some time."; // Success
                    return RedirectToAction("SubmitInspectionReport", "Inspection", new { Area = "Inspection" });
                }
            }
            else
            {
                InspectionModel obj = new InspectionModel();
                // obj.insId = id;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                obj.IntUid = profile.UserId;
                obj = _objIInspectionModel.GetUDetails(obj);
                var x = _objIInspectionModel.GetUserType(obj);
                if (x.DDL != null)
                {
                    ViewBag.ViewUTList = x.DDL.Select(c => new SelectListItem
                    {
                        Text = c.TEXT,
                        Value = c.VALUE.ToString(),
                    }).ToList();
                }
                else
                {
                    ViewBag.ViewUTList = Enumerable.Empty<SelectListItem>();
                }
                TempData["result"] = "Please select a correct Lessee/Licensee/End User for valid data.";
                return View(model);
            }

            
                
              


        }
        /// <summary>
        /// To Get Issurance of notice
        /// </summary>
        /// <param name="TypeId"></param>
        /// <returns>Json string</returns>
        public JsonResult getIssuanceOfNotice(int? TypeId)
        {

            List<NoticeModel> List = new List<NoticeModel>();
            NoticeModel obj = new NoticeModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            obj.IntUserID = profile.UserId;
            obj.RoleTypeId = TypeId;
            List = _objIInspectionModel.GetLst(obj);
            return Json(List);
        }
        /// <summary>
        /// Get lessee Licensee User Dropdown
        /// </summary>
        /// <param name="TypeId"></param>
        /// <returns>Json String</returns>
        public JsonResult GetLesseeLicenseeUserDropDown(int TypeId)
        {
            InspectionModel objGrade = null;
            try
            {
                objGrade = new InspectionModel();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objGrade.IntUid = profile.UserId;
                objGrade.LesseeLicenseeUserTypeId = TypeId;

                var x = _objIInspectionModel.GetUserList(objGrade);
                var SList = x.DDL.ToList();
                //var UserList = SList.Where(item => item.Value != "68").ToList();
                return Json(SList);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                throw;
            }
            finally
            {
                objGrade = null;
            }

        }
        /// <summary>
        /// To Get Lessee Licensee user Data
        /// </summary>
        /// <param name="IdofLesseeLicensee"></param>
        /// <returns>Json String</returns>
        public JsonResult GetLesseeLicenseeUserData(int IdofLesseeLicensee)
        {
            InspectionModel objGrade = null;
            try
            {
                objGrade = new InspectionModel();
                objGrade.USERID = IdofLesseeLicensee;
                var x = _objIInspectionModel.GetUserDetails(objGrade);

                return Json(x);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                throw;
            }
            finally
            {
                objGrade = null;
            }

        }
        /// <summary>
        /// Get portion of Submitted inspection report
        /// </summary>
        /// <returns>View</returns>
        public ActionResult SubmitedInspectionReportList()
        {
            InspectionModel model = new InspectionModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.IntUid = profile.UserId;
            ViewBag.AllReport = _objIInspectionModel.ViewLst(model);
            return View();
        }
        /// <summary>
        /// Post portion of Submitted inspection report
        /// </summary>
        /// <param name="model"></param>
        /// <param name="submit"></param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult SubmitedInspectionReportList(InspectionModel model, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.IntUid = profile.UserId;
            ViewBag.AllReport = _objIInspectionModel.ViewLst(model);
            ViewBag.fromdate = model.FromDate;
            ViewBag.todate = model.ToDate;
            return View();
        }
        /// <summary>
        /// Download uploaded files
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="foldername"></param>
        /// <returns>File</returns>
        [SkipImportantTask]
        public IActionResult DownloadFiles(string filename, string foldername)
        {
            string filepath = null;
            var absolutePath = filename;
            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Inspection\\" + foldername + "");
            if (filename != null)
            {
                if (filepath == null)
                    filepath = Path.Combine(uploadsFolder, filename);
                if (filename.Contains("_"))
                {
                    string[] splitFileName = filename.Split('_');
                    filename = splitFileName[1];
                }
                if (System.IO.File.Exists(filepath))
                {
                    return File(new FileStream(filepath, FileMode.Open), "application/octetstream", filename);
                }
                return null;
            }
            else
            {
                return null;
            }

        }

        public ActionResult InspectionReportDetails()
        {
            InspectionModel model = new InspectionModel();
           // UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
           // model.IntUid = ;
            ViewBag.AllReport = _objIInspectionModel.ViewLst(model);
            return View();
        }
    }
}
