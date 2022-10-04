// ***********************************************************************
//  Controller Name          : Grievance
//  Desciption               : Adding grievance,Showing List of Grievence and DD Approval of grievance
//  Created By               : Debaraj Swain
//  Created On               : 25 April 2021
// ***********************************************************************

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupportApp.Web;
using SupportEF;
using SupportApp.Areas.Grievance.Models;
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
using SupportApp.Models.WebsiteMenu;
using SupportApp.Models.MailService;
using SupportApp.Models.SMSService;
using SupportApp.ActionFilter;

namespace SupportApp.Areas.Grievance.Controllers
{
    [Area("Grievance")]
    public class GrievanceController : Controller
    {
        IGrievanceModel _objIGrievanceModel;
        MessageEF objobjmodel = new MessageEF();
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IWebsiteMenuModel websiteMenuModel;
        private readonly IMailModel mailModel;
        private readonly ISMSModel smsModel;
        SMS smsobj = new SMS();
        GrievanceMail mailobj = new GrievanceMail();
        PublicGrievanceModel GrievanceModel = new PublicGrievanceModel();
        public GrievanceController(IGrievanceModel objGrievanceModel, IHostingEnvironment hostingEnvironment, IWebsiteMenuModel websiteMenuModel, IMailModel mailModel, ISMSModel smsModel)
        {
            _objIGrievanceModel = objGrievanceModel;
            this.hostingEnvironment = hostingEnvironment;
            this.websiteMenuModel = websiteMenuModel;
            this.mailModel = mailModel;
            this.smsModel = smsModel;
        }
        /// <summary>
        /// Get portion of Public Grievance Add
        /// </summary>
        /// <returns>View</returns>
        [SkipSessionTask]
        public IActionResult PublicGrievance()
        {
            ViewData["MainmenuTable"] = websiteMenuModel.GetMainmenulist();
            ViewData["FootermenuTable"] = websiteMenuModel.GetFootermenulist();
            PublicGrievanceModel objmodel = new PublicGrievanceModel();
            var x = _objIGrievanceModel.GetDist(objmodel);

            if (x.DDL != null)
            {
                ViewBag.ViewDistList = x.DDL.Select(c => new SelectListItem
                {
                    Text = c.DistrictName,
                    Value = c.DistrictID.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewDistList = Enumerable.Empty<SelectListItem>();
            }

            var Y = _objIGrievanceModel.GetCtype(objmodel);

            if (Y.DDL != null)
            {
                ViewBag.ViewCType = Y.DDL.Select(c => new SelectListItem
                {
                    Text = c.TEXT,
                    Value = c.VALUE.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewCType = Enumerable.Empty<SelectListItem>();
            }

            if (TempData["ResponseMessage"] != null)
            {
                ViewBag.ResponseMessage = TempData["ResponseMessage"];
            }
            return View();
        }
        /// <summary>
        /// Send OTP
        /// </summary>
        /// <param name="MobileNumber"></param>
        /// <param name="EmailID"></param>
        /// <returns>String OTP</returns>
        /// 
        //[SkipSessionTask]
        //public IActionResult SendOTP(string MobileNumber, string EmailID)
        //{
        //    if (!string.IsNullOrEmpty(MobileNumber))
        //    {
        //        try
        //        {
        //            PublicGrievanceModel ObjeU = new PublicGrievanceModel();
        //            ObjeU.MobileNo = MobileNumber;
        //            ObjeU.EmailId = EmailID;
        //            ObjeU = _objIGrievanceModel.GetOTPModel(ObjeU);
        //            ViewBag.OTP = ObjeU.OTP;
        //            ObjeU = null;
        //            string OTP = ViewBag.OTP;
        //            if (!string.IsNullOrEmpty(OTP))
        //            {
        //                string message = "Your One time code for Khanij Online application is : " + OTP;
        //                smsobj.mobileNo = MobileNumber;
        //                smsobj.message = message;
        //                smsobj.templateid = "1307161883520738720";
        //                smsModel.Main(smsobj);
        //                mailobj.EmailId = EmailID;
        //                mailobj.Type = "OTP";
        //                mailobj.MobileNo = OTP;
        //                mailModel.SendMail_EUP(mailobj);
        //                return Json(new { data = "SUCCESS" });
        //            }
        //            else
        //            {
        //                return Json(new { data = "FAILED" });

        //            }
        //        }
        //        catch (Exception)
        //        {
        //            return Json(new { data = "FAILED" });
        //        }
        //    }
        //    else
        //    {
        //        return Json(new { data = "No Mobile Number Entered" });
        //    }
        //}
        /// <summary>
        /// Verify OTP entered by the user
        /// </summary>
        /// <param name="MobileNumber"></param>
        /// <param name="EmailID"></param>
        /// <param name="OTP"></param>
        /// <returns>String OTP</returns>
        //[SkipSessionTask]
        //public IActionResult VerifyOTP(string MobileNumber, string EmailID, string OTP)
        //{
        //    try
        //    {
        //        PublicGrievanceModel objER = null;
        //        objobjmodel = null;
        //        if (!string.IsNullOrEmpty(MobileNumber) && !string.IsNullOrEmpty(EmailID) && !string.IsNullOrEmpty(OTP))
        //        {
        //            objER = new PublicGrievanceModel();
        //            objER.MobileNo = MobileNumber;
        //            objER.EmailId = EmailID;
        //            objER.OTP = OTP;


        //            objobjmodel = _objIGrievanceModel.VerifyOTP(objER);
        //            if (objobjmodel.Msg == "SUCCESS")
        //            {
        //                return Json(new { data = "SUCCESS" });
        //            }
        //            else
        //            {
        //                return Json(new { data = "FAILED" });

        //            }
        //        }
        //        else
        //        {
        //            return Json(new { data = "REQUIRED" });
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return Json(new { data = "FAILED" });
        //    }
        //}
        ///// <summary>
        ///// Add Public Grievance
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns>View</returns>
        [HttpPost]
        [SkipSessionTask]
        public ActionResult PublicGrievanceAed(PublicGrievanceModel model)
        {
            if (string.IsNullOrEmpty(model.NAME_OF_COMPLAINER))
            {
                ModelState.AddModelError("NAME_OF_COMPLAINER", "Name is required");
            }
            if (string.IsNullOrEmpty(model.EMAIL_ADDRESS_OF_COMPLAINER))
            {
                ModelState.AddModelError("EMAIL_ADDRESS_OF_COMPLAINER", "Email is required");
            }
            if (string.IsNullOrEmpty(model.MOBILE_NUMBER_OF_COMPLAINER))
            {
                ModelState.AddModelError("MOBILE_NUMBER_OF_COMPLAINER", "Mobile No is required");
            }
            if (model.DISTRICT == 0)
            {
                ModelState.AddModelError("DISTRICT", "District No is required");
            }
            if (string.IsNullOrEmpty(model.COMPLETE_ADDRESS))
            {
                ModelState.AddModelError("COMPLETE_ADDRESS", "Complete Address is required");
            }
            if (string.IsNullOrEmpty(model.PINCODE))
            {
                ModelState.AddModelError("PINCODE", "PINCODE No is required");
            }
            if (string.IsNullOrEmpty(model.SUBJECT_OF_COMPLAINT))
            {
                ModelState.AddModelError("SUBJECT_OF_COMPLAINT", "SUBJECT OF COMPLAINT is required");
            }
            if (string.IsNullOrEmpty(model.COMPLAINT_IN_BRIEF))
            {
                ModelState.AddModelError("COMPLAINT_IN_BRIEF", "COMPLAINT IN BRIEF is required");
            }
            if (string.IsNullOrEmpty(model.ADDRESS))
            {
                ModelState.AddModelError("ADDRESS", "ADDRESS is required");
            }
            if (model.C_DISTRICT == 0)
            {
                ModelState.AddModelError("C_DISTRICT", "ADDRESS is required");
            }
            if (string.IsNullOrEmpty(model.Action_Against))
            {
                ModelState.AddModelError("Action_Against", "Action Against is required");
            }

            if (ModelState.IsValid)
            {

                string fileName = null; string savePath = null;
                if (model.ATTACHMENT != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Grievance\\Register");
                    fileName = Guid.NewGuid().ToString() + "_" + model.ATTACHMENT.FileName;
                    savePath = Path.Combine(uploadsFolder, fileName);
                    using (var fileStream = new FileStream(savePath, FileMode.Create))
                        model.ATTACHMENT.CopyTo(fileStream);
                    model.ATTACHMENT_FILE_PATH = savePath;
                    model.ATTACHMENT_FILE_NAME = fileName;
                }
                model.ATTACHMENT = null;
                objobjmodel = _objIGrievanceModel.AddPublicGrievance(model);
                string resultMessage = "";
                resultMessage = objobjmodel.Msg;
                if (resultMessage != "")
                {
                    //Main(model.MOBILE_NUMBER_OF_COMPLAINER, resultMessage);
                    TempData["ResponseMessage"] = resultMessage;
                }
                return RedirectToAction("PublicGrievance", "Grievance");
            }
            else
            {
                PublicGrievanceModel objmodel = new PublicGrievanceModel();
                var x = _objIGrievanceModel.GetDist(objmodel);

                if (x.DDL != null)
                {
                    ViewBag.ViewDistList = x.DDL.Select(c => new SelectListItem
                    {
                        Text = c.DistrictName,
                        Value = c.DistrictID.ToString(),
                    }).ToList();
                }
                else
                {
                    ViewBag.ViewDistList = Enumerable.Empty<SelectListItem>();
                }

                var Y = _objIGrievanceModel.GetCtype(objmodel);

                if (Y.DDL != null)
                {
                    ViewBag.ViewCType = Y.DDL.Select(c => new SelectListItem
                    {
                        Text = c.TEXT,
                        Value = c.VALUE.ToString(),
                    }).ToList();
                }
                else
                {
                    ViewBag.ViewCType = Enumerable.Empty<SelectListItem>();
                }

                if (TempData["ResponseMessage"] != null)
                {
                    ViewBag.ResponseMessage = TempData["ResponseMessage"];
                }
                return View(model);

            }
        }
        /// <summary>
        /// Add Grievance Non Public Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>    
        [SkipImportantTask]
        public IActionResult Register(string id)
        {
            if (id != null)
            {


                PublicGrievanceModel objmodel = new PublicGrievanceModel();
                var x = _objIGrievanceModel.GetDist(objmodel);

                if (x.DDL != null)
                {
                    ViewBag.ViewDistList = x.DDL.Select(c => new SelectListItem
                    {
                        Text = c.DistrictName,
                        Value = c.DistrictID.ToString(),
                    }).ToList();
                }
                else
                {
                    ViewBag.ViewDistList = Enumerable.Empty<SelectListItem>();
                }

                var Y = _objIGrievanceModel.GetCtype(objmodel);

                if (Y.DDL != null)
                {
                    ViewBag.ViewCType = Y.DDL.Select(c => new SelectListItem
                    {
                        Text = c.TEXT,
                        Value = c.VALUE.ToString(),
                    }).ToList();
                }
                else
                {
                    ViewBag.ViewCType = Enumerable.Empty<SelectListItem>();
                }


                var Z = _objIGrievanceModel.GetState(objmodel);

                if (Z.DDL != null)
                {
                    ViewBag.ViewStatelst = Z.DDL.Select(c => new SelectListItem
                    {
                        Text = c.TEXT,
                        Value = c.VALUE.ToString(),
                    }).ToList();
                }
                else
                {
                    ViewBag.ViewStatelst = Enumerable.Empty<SelectListItem>();
                }

                if (TempData["ResponseMessage"] != null)
                {
                    ViewBag.ResponseMessage = TempData["ResponseMessage"];
                }
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.IntUserId = profile.UserId;
                objmodel.GRIEVANCE_COMPLAINT_ID = Convert.ToInt32(id);
                objmodel = _objIGrievanceModel.GetSingleData(objmodel);
                return View(objmodel);
                ViewBag.flag = "Disabled";
                ViewBag.c_tehsil = objmodel.C_TEHSIL;
                ViewBag.c_village = objmodel.C_VILLAGE;
                return View(objmodel);
            }
            else
            {
                PublicGrievanceModel objmodel = new PublicGrievanceModel();
                var x = _objIGrievanceModel.GetDist(objmodel);

                if (x.DDL != null)
                {
                    ViewBag.ViewDistList = x.DDL.Select(c => new SelectListItem
                    {
                        Text = c.DistrictName,
                        Value = c.DistrictID.ToString(),
                    }).ToList();
                }
                else
                {
                    ViewBag.ViewDistList = Enumerable.Empty<SelectListItem>();
                }

                var Y = _objIGrievanceModel.GetCtype(objmodel);

                if (Y.DDL != null)
                {
                    ViewBag.ViewCType = Y.DDL.Select(c => new SelectListItem
                    {
                        Text = c.TEXT,
                        Value = c.VALUE.ToString(),
                    }).ToList();
                }
                else
                {
                    ViewBag.ViewCType = Enumerable.Empty<SelectListItem>();
                }


                var Z = _objIGrievanceModel.GetState(objmodel);

                if (Z.DDL != null)
                {
                    ViewBag.ViewStatelst = Z.DDL.Select(c => new SelectListItem
                    {
                        Text = c.TEXT,
                        Value = c.VALUE.ToString(),
                    }).ToList();
                }
                else
                {
                    ViewBag.ViewStatelst = Enumerable.Empty<SelectListItem>();
                }

                if (TempData["ResponseMessage"] != null)
                {
                    ViewBag.ResponseMessage = TempData["ResponseMessage"];
                }
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.IntUserId = profile.UserId;
                objmodel = _objIGrievanceModel.GetUDetails(objmodel);
                return View(objmodel);
            }
        }
        /// <summary>
        /// Add Grievance Non Public Post
        /// </summary>
        /// <param name="model"></param>
        /// <returns>View</returns>
        [HttpPost]
        [SkipImportantTask]
        public ActionResult Register(PublicGrievanceModel model)
        {
            if (string.IsNullOrEmpty(model.NAME_OF_COMPLAINER))
            {
                ModelState.AddModelError("NAME_OF_COMPLAINER", "Name is required");
            }

            if (model.STATE == 0)
            {
                ModelState.AddModelError("STATE", "STATE No is required");
            }
            if (string.IsNullOrEmpty(model.MOBILE_NUMBER_OF_COMPLAINER))
            {
                ModelState.AddModelError("MOBILE_NUMBER_OF_COMPLAINER", "Mobile No is required");
            }
            if (model.DISTRICT == 0)
            {
                ModelState.AddModelError("DISTRICT", "DISTRICT No is required");
            }
            if (string.IsNullOrEmpty(model.COMPLETE_ADDRESS))
            {
                ModelState.AddModelError("COMPLETE_ADDRESS", "COMPLETE ADDRESS is required");
            }
            if (string.IsNullOrEmpty(model.PINCODE))
            {
                ModelState.AddModelError("PINCODE", "PINCODE is required");
            }
            if (string.IsNullOrEmpty(model.EMAIL_ADDRESS_OF_COMPLAINER))
            {
                ModelState.AddModelError("EMAIL_ADDRESS_OF_COMPLAINER", "Email is required");
            }
            if (string.IsNullOrEmpty(model.SUBJECT_OF_COMPLAINT))
            {
                ModelState.AddModelError("SUBJECT_OF_COMPLAINT", "SUBJECT OF COMPLAINT is required");
            }
            if (string.IsNullOrEmpty(model.COMPLAINT_IN_BRIEF))
            {
                ModelState.AddModelError("COMPLAINT_IN_BRIEF", "COMPLAINT IN BRIEF is required");
            }
            if (string.IsNullOrEmpty(model.ADDRESS))
            {
                ModelState.AddModelError("ADDRESS", "ADDRESS is required");
            }
            if (string.IsNullOrEmpty(model.C_DISTRICT.ToString()))
            {
                ModelState.AddModelError("C_DISTRICT", "District is required");
            }
            if (string.IsNullOrEmpty(model.Action_Against))
            {
                ModelState.AddModelError("Action_Against", "Action Against is required");
            }


            if (ModelState.IsValid)
            {

                string fileName = null; string savePath = null;
                if (model.ATTACHMENT != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Grievance\\Register");
                    fileName = Guid.NewGuid().ToString() + "_" + model.ATTACHMENT.FileName;
                    savePath = Path.Combine(uploadsFolder, fileName);
                    using (var fileStream = new FileStream(savePath, FileMode.Create))
                        model.ATTACHMENT.CopyTo(fileStream);
                    model.ATTACHMENT_FILE_PATH = savePath;
                    model.ATTACHMENT_FILE_NAME = fileName;
                }
                model.ATTACHMENT = null;
                objobjmodel = _objIGrievanceModel.AddGrievance(model);
                string resultMessage = "";
                resultMessage = objobjmodel.Msg;
                if (resultMessage != "")
                {
                    //Main(model.MOBILE_NUMBER_OF_COMPLAINER, resultMessage);
                    TempData["ResponseMessage"] = resultMessage;
                }
                return RedirectToAction("Register", "Grievance");
            }
            else
            {
                PublicGrievanceModel objmodel = new PublicGrievanceModel();
                var x = _objIGrievanceModel.GetDist(objmodel);

                if (x.DDL != null)
                {
                    ViewBag.ViewDistList = x.DDL.Select(c => new SelectListItem
                    {
                        Text = c.DistrictName,
                        Value = c.DistrictID.ToString(),
                    }).ToList();
                }
                else
                {
                    ViewBag.ViewDistList = Enumerable.Empty<SelectListItem>();
                }

                var Y = _objIGrievanceModel.GetCtype(objmodel);

                if (Y.DDL != null)
                {
                    ViewBag.ViewCType = Y.DDL.Select(c => new SelectListItem
                    {
                        Text = c.TEXT,
                        Value = c.VALUE.ToString(),
                    }).ToList();
                }
                else
                {
                    ViewBag.ViewCType = Enumerable.Empty<SelectListItem>();
                }


                var Z = _objIGrievanceModel.GetState(objmodel);

                if (Z.DDL != null)
                {
                    ViewBag.ViewStatelst = Z.DDL.Select(c => new SelectListItem
                    {
                        Text = c.TEXT,
                        Value = c.VALUE.ToString(),
                    }).ToList();
                }
                else
                {
                    ViewBag.ViewStatelst = Enumerable.Empty<SelectListItem>();
                }

                if (TempData["ResponseMessage"] != null)
                {
                    ViewBag.ResponseMessage = TempData["ResponseMessage"];
                }
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.IntUserId = profile.UserId;
                objmodel = _objIGrievanceModel.GetUDetails(objmodel);
                return View(objmodel);
            }
        }
        /// <summary>
        /// Get Grievance Complaint List For DD Get
        /// </summary>
        /// <param name="model"></param>
        /// <returns>View</returns>
        public IActionResult GetGrievanceComplaint_List_For_DD(PublicGrievanceModel model)
        {

            PublicGrievanceModel objmodel = new PublicGrievanceModel();
            var x = _objIGrievanceModel.GetUtype(objmodel);

            if (x.DDL != null)
            {
                ViewBag.ViewUTypeList = x.DDL.Select(c => new SelectListItem
                {
                    Text = c.RoleName,
                    Value = c.RoleId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewUTypeList = Enumerable.Empty<SelectListItem>();
            }

            var Y = _objIGrievanceModel.CComplaint(objmodel);

            if (Y.DDL != null)
            {
                ViewBag.CComplaint = Y.DDL.Select(c => new SelectListItem
                {
                    Text = c.TEXT,
                    Value = c.VALUE.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.CComplaint = Enumerable.Empty<SelectListItem>();
            }


            if (TempData["ResponseMessageDD"] != null)
            {
                ViewBag.ResponseMessageDD = TempData["ResponseMessageDD"];
            }
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.IntUserId = profile.UserId;
            ViewBag.AllReport = _objIGrievanceModel.GetLst(objmodel);
            return View();
        }
        /// <summary>
        /// Get Grievance Complaint List For DD Post
        /// </summary>
        /// <param name="model"></param>
        /// <param name="submit"></param>
        /// <returns>View</returns>
        [HttpPost]
        public IActionResult GetGrievanceComplaint_List_For_DD(PublicGrievanceModel model, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.IntUserId = profile.UserId;
            ViewBag.AllReport = _objIGrievanceModel.GetLst(model);


            PublicGrievanceModel objmodel = new PublicGrievanceModel();
            var x = _objIGrievanceModel.GetUtype(objmodel);

            if (x.DDL != null)
            {
                ViewBag.ViewUTypeList = x.DDL.Select(c => new SelectListItem
                {
                    Text = c.RoleName,
                    Value = c.RoleId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewUTypeList = Enumerable.Empty<SelectListItem>();
            }

            var Y = _objIGrievanceModel.CComplaint(objmodel);

            if (Y.DDL != null)
            {
                ViewBag.CComplaint = Y.DDL.Select(c => new SelectListItem
                {
                    Text = c.TEXT,
                    Value = c.VALUE.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.CComplaint = Enumerable.Empty<SelectListItem>();
            }

            ViewBag.fromdate = model.FromDate;
            ViewBag.todate = model.ToDate;
            return View();
        }
        /// <summary>
        /// Download File
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="foldername"></param>
        /// <returns>Download file</returns>
        [SkipImportantTask]
        public IActionResult DownloadFiles(string filename, string foldername)
        {
            string filepath = null;
            var absolutePath = filename;
            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Grievance\\" + foldername + "");
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
        /// <summary>
        /// Get Name List
        /// </summary>
        /// <param name="UTypeID"></param>
        /// <returns>JsonResult</returns>
        public JsonResult GetNameList(int UTypeID)
        {
            PublicGrievanceModel objname = null;
            try
            {
                objname = new PublicGrievanceModel();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objname.IntUserId = profile.UserId;
                objname.RoleId = UTypeID;

                var x = _objIGrievanceModel.GetUByType(objname);
                if (x.DDL != null)
                {
                    var SList = x.DDL.ToList();
                    return Json(SList);
                }
                else
                {
                    return Json("");
                }

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                throw;
            }
            finally
            {
                objname = null;
            }

        }
        /// <summary>
        /// Send Grievance COmplaint to mining Inspector
        /// </summary>
        /// <param name="GRIEVANCE_COMPLAINT_ID"></param>
        /// <param name="ACTIVE_STATUS"></param>
        /// <param name="DD_DMO_REMARKS"></param>
        /// <param name="MINING_INSPECTER_ID"></param>
        /// <param name="UserType"></param>
        /// <param name="COC"></param>
        /// <returns>JsonResult</returns>
        public JsonResult SendGrievanceComplaintToMiningInspector(int GRIEVANCE_COMPLAINT_ID, int ACTIVE_STATUS, string DD_DMO_REMARKS, int MINING_INSPECTER_ID, string UserType, string COC)
        {
            string resultMessage = "";
            string OutputResult = "4";
            if (ACTIVE_STATUS == 4)
            {
                return Json("3");
            }
            else
            {

                if ((!string.IsNullOrEmpty(DD_DMO_REMARKS)) && (!string.IsNullOrEmpty(UserType.ToString())) && (MINING_INSPECTER_ID != 0))
                {
                    PublicGrievanceModel objmodel = new PublicGrievanceModel();
                    objmodel.GRIEVANCE_COMPLAINT_ID = GRIEVANCE_COMPLAINT_ID;
                    objmodel.DD_DMO_REMARKS = DD_DMO_REMARKS;
                    objmodel.MINING_INSPECTER_ID = MINING_INSPECTER_ID;
                    objmodel.UserType = UserType;
                    objmodel.COC = COC;
                    UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                    objmodel.IntUserId = profile.UserId;
                    objmodel.GRIEVANCE_COMPLAINT_ID = GRIEVANCE_COMPLAINT_ID;
                    objobjmodel = _objIGrievanceModel.FFOrwordDD(objmodel);
                    resultMessage = objobjmodel.Msg;
                    if (Convert.ToInt32(resultMessage) > 0)
                    {
                        OutputResult = "1";
                    }
                    else
                    {
                        OutputResult = "3";
                    }
                    return Json(OutputResult);
                }
                else
                {
                    return Json(OutputResult);
                }
            }
        }
        /// <summary>
        /// View Grievance Complaint List
        /// </summary>
        /// <param name="model"></param>
        /// <returns>View</returns>
        public IActionResult GrievanceComplaint_List(PublicGrievanceModel model)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.IntUserId = profile.UserId;
            ViewBag.GCAllReport = _objIGrievanceModel.GetGCLst(model);
            return View();
        }
        /// <summary>
        /// Get portion of submission of complaint
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        public IActionResult Submission_of_Complaint(int? id)
        {


            PublicGrievanceModel objmodel = new PublicGrievanceModel();
            var x = _objIGrievanceModel.GetDist(objmodel);

            if (x.DDL != null)
            {
                ViewBag.ViewDistList = x.DDL.Select(c => new SelectListItem
                {
                    Text = c.DistrictName,
                    Value = c.DistrictID.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewDistList = Enumerable.Empty<SelectListItem>();
            }

            var Y = _objIGrievanceModel.GetCtype(objmodel);

            if (Y.DDL != null)
            {
                ViewBag.ViewCType = Y.DDL.Select(c => new SelectListItem
                {
                    Text = c.TEXT,
                    Value = c.VALUE.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewCType = Enumerable.Empty<SelectListItem>();
            }




            if (TempData["ResponseMessage"] != null)
            {
                ViewBag.ResponseMessage = TempData["ResponseMessage"];
            }
            return View();

        }
        /// <summary>
        /// Post portion of Submission of complaint
        /// </summary>
        /// <param name="model"></param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult Submission_of_Complaint(PublicGrievanceModel model)
        {
            if (string.IsNullOrEmpty(model.SUBJECT_OF_COMPLAINT))
            {
                ModelState.AddModelError("SUBJECT_OF_COMPLAINT", "SUBJECT OF COMPLAINT is required");
            }
            if (string.IsNullOrEmpty(model.NAME_OF_COMPLAINER))
            {
                ModelState.AddModelError("NAME_OF_COMPLAINER", "Name is required");
            }
            if (string.IsNullOrEmpty(model.ADDRESS))
            {
                ModelState.AddModelError("ADDRESS", "ADDRESS is required");
            }
            if (string.IsNullOrEmpty(model.C_DISTRICT.ToString()))
            {
                ModelState.AddModelError("C_DISTRICT", "District is required");
            }
            if (string.IsNullOrEmpty(model.Date))
            {
                ModelState.AddModelError("Date", "Date is required");
            }
            if (model.ATTACHMENT == null)
            {
                ModelState.AddModelError("ATTACHMENT", "ATTACHMENT is required");
            }
            if (ModelState.IsValid)
            {
                string fileName = null; string savePath = null;
                if (model.ATTACHMENT != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Grievance\\Register");
                    fileName = Guid.NewGuid().ToString() + "_" + model.ATTACHMENT.FileName;
                    savePath = Path.Combine(uploadsFolder, fileName);
                    using (var fileStream = new FileStream(savePath, FileMode.Create))
                        model.ATTACHMENT.CopyTo(fileStream);
                    model.ATTACHMENT_FILE_PATH = savePath;
                    model.ATTACHMENT_FILE_NAME = fileName;
                }
                model.ATTACHMENT = null;
                objobjmodel = _objIGrievanceModel.AddDGMGrievance(model);

                string resultMessage = "";
                resultMessage = objobjmodel.Msg;
                if (resultMessage != "")
                {
                    TempData["ResponseMessage"] = resultMessage;
                }
                return RedirectToAction("Submission_of_Complaint", "Grievance");
            }
            else
            {
                PublicGrievanceModel objmodel = new PublicGrievanceModel();
                var x = _objIGrievanceModel.GetDist(objmodel);

                if (x.DDL != null)
                {
                    ViewBag.ViewDistList = x.DDL.Select(c => new SelectListItem
                    {
                        Text = c.DistrictName,
                        Value = c.DistrictID.ToString(),
                    }).ToList();
                }
                else
                {
                    ViewBag.ViewDistList = Enumerable.Empty<SelectListItem>();
                }

                var Y = _objIGrievanceModel.GetCtype(objmodel);

                if (Y.DDL != null)
                {
                    ViewBag.ViewCType = Y.DDL.Select(c => new SelectListItem
                    {
                        Text = c.TEXT,
                        Value = c.VALUE.ToString(),
                    }).ToList();
                }
                else
                {
                    ViewBag.ViewCType = Enumerable.Empty<SelectListItem>();
                }
                return View(model);

            }
        }
        /// <summary>
        /// Get portion of mining inspector grievance complaint list
        /// </summary>
        /// <param name="model"></param>
        /// <returns>View</returns>
        public IActionResult Mining_Inspector_GrievanceComplaint_List(PublicGrievanceModel model)
        {
            if (TempData["ResponseMessageMI"] != null)
            {
                ViewBag.ResponseMessageMI = TempData["ResponseMessageMI"];
            }

            PublicGrievanceModel objmodel = new PublicGrievanceModel();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.IntUserId = profile.UserId;
            ViewBag.AllReportMI = _objIGrievanceModel.GetLstMI(model);
            return View();
        }
        /// <summary>
        /// Post portion of mining inspector grievance complaint list
        /// </summary>
        /// <param name="model"></param>
        /// <param name="submit"></param>
        /// <returns>View</returns>
        [HttpPost]
        public IActionResult Mining_Inspector_GrievanceComplaint_List(PublicGrievanceModel model, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.IntUserId = profile.UserId;
            ViewBag.AllReportMI = _objIGrievanceModel.GetLstMI(model);
            PublicGrievanceModel objmodel = new PublicGrievanceModel();
            ViewBag.fromdate = model.FromDate;
            ViewBag.todate = model.ToDate;
            return View();
        }
        /// <summary>
        /// Post portion of Send grievance complaint to DD By Mining Inspector
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns>View</returns>
        [HttpPost]
        public IActionResult SendGrievanceComplaintToDDByMiningInspector(PublicGrievanceModel objmodel)
        {

            string resultMessage = "";
            string OutputResult = "4";
            if ((!string.IsNullOrEmpty(objmodel.MINING_INSPECTER_REMARKS)))
            {
                ForwardMItoDD model = new ForwardMItoDD();
                string fileName = null; string savePath = null;
                if (objmodel.ATTACHMENT != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Grievance\\MIUpload");
                    fileName = Guid.NewGuid().ToString() + "_" + objmodel.ATTACHMENT.FileName;
                    savePath = Path.Combine(uploadsFolder, fileName);
                    using (var fileStream = new FileStream(savePath, FileMode.Create))
                        objmodel.ATTACHMENT.CopyTo(fileStream);
                    objmodel.ATTACHMENT_FILE_NAME = fileName;
                }
                model.AFilename = objmodel.ATTACHMENT_FILE_NAME;
                model.Remark = objmodel.MINING_INSPECTER_REMARKS;
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.IntUserId = profile.UserId;
                model.Uid = objmodel.IntUserId;
                model.Gid = objmodel.GRIEVANCE_COMPLAINT_ID;
                objobjmodel = _objIGrievanceModel.MIFFOrwordDD(model);
                resultMessage = objobjmodel.Msg;
                if (Convert.ToInt32(resultMessage) > 0)
                {
                    OutputResult = "1";
                    TempData["ResponseMessageMI"] = OutputResult;
                }
                else
                {
                    OutputResult = "3";
                    TempData["ResponseMessageMI"] = OutputResult;
                }
            }
            else
            {
                TempData["ResponseMessageMI"] = OutputResult;
            }
            return RedirectToAction("Mining_Inspector_GrievanceComplaint_List", "Grievance");


        }
        /// <summary>
        /// Post portion of Close Grievance
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CloseGrievance(PublicGrievanceModel objmodel)
        {
            string OutputResult = "";
            if (objmodel.ACTIVE_STATUS == 4)
            {
                if (objmodel.ATTACHMENT != null)
                {
                    try
                    {
                        string fileName = null; string savePath = null;
                        if (objmodel.ATTACHMENT != null)
                        {
                            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Grievance\\FinalUpload");
                            fileName = Guid.NewGuid().ToString() + "_" + objmodel.ATTACHMENT.FileName;
                            savePath = Path.Combine(uploadsFolder, fileName);
                            using (var fileStream = new FileStream(savePath, FileMode.Create))
                                objmodel.ATTACHMENT.CopyTo(fileStream);
                            objmodel.ATTACHMENT_FILE_NAME = fileName;
                        }
                        PublicGrievanceModel ObjResult = new PublicGrievanceModel();
                        UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                        objmodel.IntUserId = profile.UserId;
                        CloseComplain objmodel1 = new CloseComplain();
                        objmodel1.IntUserId = objmodel.IntUserId;
                        objmodel1.ATTACHMENT_FILE_NAME = objmodel.ATTACHMENT_FILE_NAME;
                        objmodel1.GRIEVANCE_COMPLAINT_ID = objmodel.GRIEVANCE_COMPLAINT_ID;
                        ObjResult = _objIGrievanceModel.CloseGR(objmodel1);
                        string message = "Dear " + ObjResult.NAME_OF_COMPLAINER + Environment.NewLine + Environment.NewLine +
                            "Your complaint status for complaint number " + ObjResult.ComplaintNumber + " is " + ObjResult.Complaint_Status + Environment.NewLine + Environment.NewLine +
                            "Thank You," + Environment.NewLine + Environment.NewLine +
                            "Khanij Online Portal";
                        smsobj.mobileNo = ObjResult.MOBILE_NUMBER;
                        smsobj.message = message;
                        smsobj.templateid = "1307161883525452959";
                        smsModel.Main(smsobj);
                        OutputResult = "6";
                        TempData["ResponseMessageDD"] = OutputResult;
                    }
                    catch
                    {
                        OutputResult = "3";
                        TempData["ResponseMessageDD"] = OutputResult;
                        return RedirectToAction("GetGrievanceComplaint_List_For_DD", "Grievance");
                    }
                }
                else
                {
                    OutputResult = "4";
                    TempData["ResponseMessageDD"] = OutputResult;
                }
            }
            return RedirectToAction("GetGrievanceComplaint_List_For_DD", "Grievance");

        }
        /// <summary>
        /// For Feedback from home page
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        [SkipSessionTask]
        public IActionResult PublicGrievance(AddFeedbackModel objmodel, string submit)
        {
            try
            {
                #region Validation
                if (string.IsNullOrEmpty(objmodel.FULL_NAME))
                {
                    ModelState.AddModelError("FULL_NAME", "Full Name is Required");
                }
                if (string.IsNullOrEmpty(objmodel.MAIL_ID))
                {
                    ModelState.AddModelError("MAIL_ID", "Mail Id is Required");
                }
                if (string.IsNullOrEmpty(objmodel.FEEDBACK))
                {
                    ModelState.AddModelError("FEEDBACK", "Feedback is Required");
                }

                #endregion
                if (ModelState.IsValid)
                {
                    if (submit == "Submit")
                    {
                        objobjmodel = websiteMenuModel.Add(objmodel);
                        if (objobjmodel.Satus == "1")
                            TempData["Message"] = "Thank You For Your Valueable Feedback.";
                    }
                }
                else
                {
                    ViewData["MainmenuTable"] = websiteMenuModel.GetMainmenulist();
                    ViewData["FootermenuTable"] = websiteMenuModel.GetFootermenulist();
                }
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #region Send OTP
        /// <summary>
        /// To Send OTP
        /// </summary>
        /// <param name="MobileNumber,EmailID"></param>
        /// <returns></returns>
        [SkipSessionTask]
        public IActionResult SendOTP(string MobileNumber, string EmailID)
        {
            if (!string.IsNullOrEmpty(MobileNumber))
            {
                objobjmodel = _objIGrievanceModel.VerifyMobile(new PublicGrievanceModel() { MobileNo = MobileNumber, EmailId = EmailID });
                if (string.IsNullOrEmpty(objobjmodel.Satus))
                {
                    try
                    {
                        objobjmodel = _objIGrievanceModel.GetOTP(new PublicGrievanceModel() { MobileNo = MobileNumber, EmailId = EmailID });
                        if (!string.IsNullOrEmpty(objobjmodel.Satus))
                        {

                            string message = "Your One time code for Khanij Online application is : " + objobjmodel.Satus + " CHiMMS, GoCG";

                            string templateid = "1307161883520738720";
                            smsModel.Main(new SMS() { mobileNo = MobileNumber, message = message, templateid = templateid });
                            //mailModel.SendMail_EUP(new PublicGrievanceModel() { EmailId = EmailID, MobileNo = objobjmodel.Satus, Type = "OTP" });
                            mailobj.EmailId = EmailID;
                            mailobj.Type = "OTPGrivance";
                            mailobj.MobileNo = MobileNumber;
                            mailobj.RegistrationNo = objobjmodel.Satus;
                            mailModel.SendMail_EUP(mailobj);
                            return Json(new { data = "SUCCESS" });
                        }
                        else
                        {
                            return Json(new { data = "FAILED" });
                        }


                    }
                    catch (Exception ex)
                    {
                        return Json(new { data = "FAILED" });
                    }
                }
                else
                {
                    return Json(new { data = "Mobile Number Already Exist.Duplicate Not Allowed." });
                }
            }
            else
            {
                return Json(new { data = "No Mobile Number Entered" });
            }
        }
        #endregion

        #region VerifyOTP
        /// <summary>
        /// To Verify OTP
        /// </summary>
        /// <param name="MobileNumber,EmailID,OTP"></param>
        /// <returns></returns>
        [SkipSessionTask]
        public JsonResult VerifyOTP(string MobileNumber, string EmailID, string OTP)
        {
            if (!string.IsNullOrEmpty(MobileNumber) && !string.IsNullOrEmpty(EmailID) && !string.IsNullOrEmpty(OTP))
            {
                GrievanceModel.MobileNo = MobileNumber;
                GrievanceModel.EmailId = EmailID;
                GrievanceModel.OTP = OTP;
                objobjmodel = _objIGrievanceModel.VerifyOTP(GrievanceModel);
                return Json(objobjmodel.Satus);
            }
            else
            {
                return Json("REQUIRED");
            }
        }
        #endregion
    }
}
