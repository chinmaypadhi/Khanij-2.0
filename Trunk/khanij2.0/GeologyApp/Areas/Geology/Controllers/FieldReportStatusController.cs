// ***********************************************************************
//  Controller Name          : FieldReportStatusController
//  Desciption               : Add,View,Edit,Update,Delete Field Report Status
//  Created By               : Lingaraj Dalai
//  Created On               : 18 March 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using GeologyApp.Areas.Geology.Models.FieldReportStatus;
using GeologyApp.Models.InspectionReport;
using GeologyEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using GeologyApp.Web;
using GeologyApp.Models.MailService;
using GeologyApp.ActionFilter;

namespace GeologyApp.Areas.Geology.Controllers
{
    [Area("Geology")]
    public class FieldReportStatusController : Controller
    {
        /// <summary>
        /// Global object and variable declaration
        /// </summary>
        private readonly IFieldReportStatusModel _objFieldReportStatusMasterModel;
        private readonly IInspectionReportModel _objInspectionReportMasterModel;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        private readonly IMailModel mailModel;
        MessageEF objobjmodel = new MessageEF();
        FieldReportStatusmaster objmodel;
        GeologyMail mailobj = new GeologyMail();
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objFieldReportStatusMasterModel"></param>
        /// <param name="objInspectionReportMasterModel"></param>
        /// <param name="hostingEnvironment"></param>
        public FieldReportStatusController(IFieldReportStatusModel objFieldReportStatusMasterModel, IInspectionReportModel objInspectionReportMasterModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration, IMailModel mailModel)
        {
            _objFieldReportStatusMasterModel = objFieldReportStatusMasterModel;
            _objInspectionReportMasterModel = objInspectionReportMasterModel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
            this.mailModel = mailModel;
        }
        #region Field Report Status
        /// <summary>
        /// GET method To Bind the Field Report Status Details Data in View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public IActionResult Add(string id = "0")
        {
            objmodel = new FieldReportStatusmaster();
            try
            {
                GetOfficerNameAndDesignation();
                if (id != "0")
                {
                    objmodel.MPR_ID = Convert.ToInt32(id);
                    objmodel = _objFieldReportStatusMasterModel.Edit(objmodel);
                    ViewBag.Button = "Update";
                    ViewBag.Regionaloffice = GetRegionalOffice(objmodel.RegionalOfficeId);
                    ViewBag.FPOcode = GetMPRCode(objmodel.FPO_Id);
                    return View(objmodel);
                }
                else
                {
                    ViewBag.Button = "Submit";
                    ViewBag.Regionaloffice = GetRegionalOffice(null);
                    ViewBag.FPOcode = GetMPRCode(null);
                    ViewBag.SubmissionDate = DateTime.Now.ToString("dd/MM/yyyy");
                    return View(objmodel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objmodel = null;
            }
        }
        /// <summary>
        /// Post method To Add the Field Report Status Details Data in View
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Add(FieldReportStatusmaster objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserId = profile.UserId;
            objmodel.UserLoginId = profile.UserLoginId;
            try
            {
                #region Validation
                if (objmodel.FPO_Id == null)
                {
                    ModelState.AddModelError("FPO_Id", "Field Program Order field is required");
                }
                if (objmodel.ReportType == null)
                {
                    ModelState.AddModelError("ReportType", "Report Type field is required");
                }
                if (objmodel.ReportStatus_1 == null)
                {
                    ModelState.AddModelError("ReportStatus_1", "Report Status field is required");
                }
                if (objmodel.RegionalOfficeId == null)
                {
                    ModelState.AddModelError("RegionalOfficeId", "Regional Office field is required");
                }
                if (objmodel.FIELD_REPORT_FILE_NAME == null || objmodel.FIELD_REPORT_FILE_NAME == "")
                {
                    if (objmodel.FIELD_REPORTAttachment == null)
                    {
                        ModelState.AddModelError("FIELD_REPORTAttachment", "Upload Field Report");
                    }
                }
                if (objmodel.MAPS_PLATES_FILE_NAME == null || objmodel.MAPS_PLATES_FILE_NAME == "")
                {
                    if (objmodel.MAPS_PLATESAttachment == null)
                    {
                        ModelState.AddModelError("MAPS_PLATESAttachment", "Upload Maps & Plates");
                    }
                }
                if (objmodel.ANNEXURE_FILE_NAME == null || objmodel.ANNEXURE_FILE_NAME == "")
                {
                    if (objmodel.ANNEXUREAttachment == null)
                    {
                        ModelState.AddModelError("ANNEXUREAttachment", "Upload Annexure");
                    }
                }
                #endregion
                if (ModelState.IsValid)
                {
                    #region File Upload                    
                    string FIELD_REPORTFileName = null; string FIELD_REPORTfilePath = null;
                    string MAPS_PLATESFileName = null; string MAPS_PLATESfilePath = null;
                    string ANNEXUREFileName = null; string ANNEXUREfilePath = null;
                    if (objmodel.FIELD_REPORTAttachment != null)
                    {
                        FIELD_REPORTFileName = DateTime.Now.Ticks.ToString() + "_" + Path.GetFileName(objmodel.FIELD_REPORTAttachment.FileName);
                        FIELD_REPORTfilePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadFieldReportPath"), FIELD_REPORTFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadFieldReportPath"));
                        string uploadsFolder = Path.Combine(RootPath, FIELD_REPORTFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.FIELD_REPORTAttachment.CopyTo(fileStream);
                        objmodel.FIELD_REPORT_FILE_NAME = FIELD_REPORTFileName;
                        objmodel.FIELD_REPORT_FILE_PATH = FIELD_REPORTfilePath;
                        objmodel.FIELD_REPORTAttachment = null;
                    }
                    if (objmodel.MAPS_PLATESAttachment != null)
                    {
                        MAPS_PLATESFileName = DateTime.Now.Ticks.ToString() + "_" + Path.GetFileName(objmodel.MAPS_PLATESAttachment.FileName);
                        MAPS_PLATESfilePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadMapAttachmentPath"), MAPS_PLATESFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadMapAttachmentPath"));
                        string uploadsFolder = Path.Combine(RootPath, MAPS_PLATESFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.MAPS_PLATESAttachment.CopyTo(fileStream);
                        objmodel.MAPS_PLATES_FILE_NAME = MAPS_PLATESFileName;
                        objmodel.MAPS_PLATES_FILE_PATH = MAPS_PLATESfilePath;
                        objmodel.MAPS_PLATESAttachment = null;
                    }
                    if (objmodel.ANNEXUREAttachment != null)
                    {
                        ANNEXUREFileName = DateTime.Now.Ticks.ToString() + "_" + Path.GetFileName(objmodel.ANNEXUREAttachment.FileName);
                        ANNEXUREfilePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadAnnexurePath"), ANNEXUREFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadAnnexurePath"));
                        string uploadsFolder = Path.Combine(RootPath, ANNEXUREFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.ANNEXUREAttachment.CopyTo(fileStream);
                        objmodel.ANNEXURE_FILE_NAME = ANNEXUREFileName;
                        objmodel.ANNEXURE_FILE_PATH = ANNEXUREfilePath;
                        objmodel.ANNEXUREAttachment = null;
                    }
                    #endregion
                    if (submit == "Submit")
                    {
                        objobjmodel = _objFieldReportStatusMasterModel.Add(objmodel);
                    }
                    else
                    {
                        objobjmodel = _objFieldReportStatusMasterModel.Update(objmodel);
                    }
                    TempData["msg"] = objobjmodel.Satus;
                    return RedirectToAction("Add", "FieldReportStatus", new { Area = "Geology" });
                }
                else
                {
                    GetOfficerNameAndDesignation();
                    int id = objmodel.MPR_ID;
                    if (id != 0)
                    {
                        objmodel.MPR_ID = id;
                        objmodel = _objFieldReportStatusMasterModel.Edit(objmodel);
                        ViewBag.Button = "Update";
                        ViewBag.Regionaloffice = GetRegionalOffice(objmodel.RegionalOfficeId);
                        ViewBag.FPOcode = GetMPRCode(objmodel.FPO_Id);
                        return View(objmodel);
                    }
                    else
                    {
                        ViewBag.Button = "Submit";
                        ViewBag.Regionaloffice = GetRegionalOffice(null);
                        ViewBag.FPOcode = GetMPRCode(null);
                        ViewBag.SubmissionDate = DateTime.Now.ToString("dd/MM/yyyy");
                        return View(objmodel);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objmodel = null;
            }
        }
        /// <summary>
        /// GET method To Bind the Field Report Status Details Data in View
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewList()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel = new FieldReportStatusmaster();
            objmodel.UserId = profile.UserId;
            List<FieldReportStatusmaster> lstFieldReportmaster = new List<FieldReportStatusmaster>();
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                lstFieldReportmaster = _objFieldReportStatusMasterModel.View(objmodel);
                ViewBag.ViewList = lstFieldReportmaster;
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objmodel = null;
                lstFieldReportmaster = null;
            }
        }
        /// <summary>
        /// Post method To Bind the Field Report Status Details Data in View
        /// </summary>
        /// <param name="Show1"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult ViewList(string Show1)
        {
            objmodel = new FieldReportStatusmaster();
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                ViewBag.ViewList = _objFieldReportStatusMasterModel.View(objmodel);
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objmodel = null;
            }
        }
        /// <summary>
        /// To Delete the Field Report Status Details Data in View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public IActionResult Delete(string id = "0")
        {
            objmodel = new FieldReportStatusmaster();
            try
            {
                objmodel.MPR_ID = Convert.ToInt32(id);
                objobjmodel = _objFieldReportStatusMasterModel.Delete(objmodel);
                if (objobjmodel.Satus == "1")
                {
                    TempData["msg"] = "Data Deleted Sucessfully !";
                }
                else
                {
                    TempData["msg"] = "Data not Deleted Sucessfully !";
                }
                return RedirectToAction("ViewList", "FieldReportStatus", new { Area = "Geology" });
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objmodel = null;
            }
        }
        /// <summary>
        /// To Bind the Regional Office Details Data in View
        /// </summary>
        /// <param name="RegionalOfficeId"></param>
        /// <returns></returns>
        public SelectList GetRegionalOffice(int? RegionalOfficeId)
        {
            List<FieldReportStatusmaster> listRegionalOfficeResult = new List<FieldReportStatusmaster>();
            try
            {
                listRegionalOfficeResult = _objFieldReportStatusMasterModel.GetRegionalOfficeList(objmodel);
                return new SelectList(listRegionalOfficeResult, "RegionalOfficeId", "RegionalOfficeName", RegionalOfficeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                listRegionalOfficeResult = null;
            }
        }
        /// <summary>
        /// To Bind the MPR code Details Data in View
        /// </summary>
        /// <param name="FPO_Id"></param>
        /// <returns></returns>
        public SelectList GetMPRCode(int? FPO_Id)
        {
            InspectionReportmaster objmodel = new InspectionReportmaster();
            List<InspectionReportmaster> listMPRCodeResult = new List<InspectionReportmaster>();
            try
            {
                listMPRCodeResult = _objInspectionReportMasterModel.GetMPRCodeList(objmodel);
                return new SelectList(listMPRCodeResult, "FPO_Id", "FPO_Code", FPO_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objmodel = null;
                listMPRCodeResult = null;
            }
        }
        /// <summary>
        /// To Bind the Officer Details Data in View
        /// </summary>
        /// <returns></returns>
        public FieldReportStatusmaster GetOfficerNameAndDesignation()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel = new FieldReportStatusmaster();
            InspectionReportmaster ofcdata = new InspectionReportmaster();
            try
            {
                ofcdata.UserId = profile.UserId;
                ofcdata = _objInspectionReportMasterModel.GetOfficerNameAndDesignation(ofcdata);
                objmodel.ApplicantName = ofcdata.ApplicantName;
                objmodel.RoleName = ofcdata.Designation;
                objmodel.MobileNo = ofcdata.MobileNo;
                objmodel.EmailId = ofcdata.EmailId;
                return objmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ofcdata = null;
            }
        }
        /// <summary>
        /// Submit To Regional Office
        /// </summary>
        /// <param name="MPR_Id"></param>
        /// <returns></returns>
        public JsonResult UpdateStatusOfReport_STOREGIONALOFFICE(int MPR_Id)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel = new FieldReportStatusmaster();
            FieldReportStatusmaster FieldReportmaster = new FieldReportStatusmaster();
            objmodel.MPR_ID = MPR_Id;
            objmodel.UserId = profile.UserId;
            objmodel.UserLoginId = profile.UserLoginId;
            try
            {
                #region Fetch Email details and mail
                FieldReportmaster = _objFieldReportStatusMasterModel.ViewEmailDetails(objmodel);
                mailobj.Type = "FORWARD_RO";
                mailobj.EmailId = FieldReportmaster.EmailId_List;
                mailobj.EmailIdCC = FieldReportmaster.EmailId_CC_List;
                mailobj.FPO = FieldReportmaster.FPO_Code;
                mailobj.ReportType = FieldReportmaster.Report_Type;
                mailobj.ReportStatus = FieldReportmaster.Report_Status;
                if (mailobj.EmailId != null && mailobj.EmailId != "")
                {
                    objobjmodel = mailModel.SendMail_FSR(mailobj);
                }
                #endregion
                #region Forward To RO
                objobjmodel = _objFieldReportStatusMasterModel.UpdateStatusOfReport_STOREGIONALOFFICE(objmodel);
                #endregion
                return Json(objobjmodel.Satus);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objmodel = null;
                FieldReportmaster = null;
            }

        }
        #endregion
    }
}
