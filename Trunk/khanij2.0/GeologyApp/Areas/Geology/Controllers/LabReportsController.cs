// ***********************************************************************
//  Controller Name          : LabReportsController
//  Desciption               : Add,Edit,View,Update,delete Lab Report details
//  Created By               : Lingaraj Dalai
//  Created On               : 24 Feb 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using GeologyApp.Models.LabReports;
using GeologyApp.Models.MPR;
using GeologyEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using System.Data;
using Microsoft.Extensions.Configuration;
using GeologyApp.Web;
using GeologyApp.ActionFilter;

namespace GeologyApp.Controllers
{
    [Area("Geology")]
    public class LabReportsController : Controller
    {
        /// <summary>
        /// Global object and variable declaration
        /// </summary>
        private readonly ILabReportsModel _objLabReportMasterModel;
        private readonly IMPRModel _objMPRMasterModel;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        MessageEF objobjmodel = new MessageEF();
        LabReportmaster objmodel = new LabReportmaster();
        List<MPRmaster> listDistrictResult = new List<MPRmaster>();
        List<MPRmaster> listTehsilResult = new List<MPRmaster>();
        List<MPRmaster> listVillageResult = new List<MPRmaster>();
        List<LabReportmaster> listRegionalOfficeResult = new List<LabReportmaster>();
        List<LabReportmaster> lstLabReportmaster = new List<LabReportmaster>();
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objLabReportMasterModel"></param>
        /// <param name="objMPRMasterModel"></param>
        /// <param name="hostingEnvironment"></param>
        public LabReportsController(ILabReportsModel objLabReportMasterModel, IMPRModel objMPRMasterModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _objLabReportMasterModel = objLabReportMasterModel;
            _objMPRMasterModel = objMPRMasterModel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }
        #region Submit New Samples
        /// <summary>
        /// GET method to bind Lab Report details in view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public IActionResult Add(string id = "0")
        {
            MPRmaster objmprmodel = new MPRmaster();
            BindDropdowns();
            GetOfficerNameAndDesignation();
            try
            {
                if (id != "0")
                {
                    objmodel.LabReport_Id = Convert.ToInt32(id);
                    objmodel = _objLabReportMasterModel.Edit(objmodel);
                    objmprmodel.RegionalID = objmodel.RegionalID;
                    objmprmodel.DistrictID = objmodel.DistrictID;
                    objmprmodel.TehsilID = objmodel.TehsilID;
                    listDistrictResult = _objMPRMasterModel.GetDistrictList(objmprmodel);
                    ViewData["District"] = listDistrictResult;
                    listTehsilResult = _objMPRMasterModel.GetTehsilList(objmprmodel);
                    ViewData["Tehsil"] = listTehsilResult;
                    listVillageResult = _objMPRMasterModel.GetVillageList(objmprmodel);
                    ViewData["Village"] = listVillageResult;
                    ViewBag.Button = "Update";
                    return View(objmodel);
                }
                else
                {
                    objmodel.IsActive = true;
                    ViewBag.Button = "Submit";
                    if (objmodel.Date_of_Submission == null)
                        objmodel.Date_of_Submission = DateTime.Now.ToString();
                    return View(objmodel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objmprmodel = null;
                listDistrictResult = null;
                listTehsilResult = null;
                listVillageResult = null;
            }
        }
        /// <summary>
        /// POST method to Add Lab Report details in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Add(LabReportmaster objmodel, string submit)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserId = profile.UserId;
                objmodel.UserLoginId = profile.UserLoginId;
                #region Validation
                if (objmodel.FPO_Id == null)
                {
                    ModelState.AddModelError("FPO_Id", "FPO Code field is required.");
                }
                if (string.IsNullOrEmpty(objmodel.Location))
                {
                    ModelState.AddModelError("Location", "Name of camp field is required");
                }
                if (string.IsNullOrEmpty(objmodel.Report_MY))
                {
                    ModelState.AddModelError("Year", "Field Season field is required");
                }
                if (objmodel.MineralID == null)
                {
                    ModelState.AddModelError("MineralID", "Mineral field is required");
                }
                if (objmodel.RegionalID == null)
                {
                    ModelState.AddModelError("RegionalID", "Division field is required.");
                }
                if (objmodel.DistrictID == null)
                {
                    ModelState.AddModelError("DistrictID", "District field is required");
                }
                if (objmodel.TehsilID == null)
                {
                    ModelState.AddModelError("TehsilID", "Tehsil field is required");
                }
                if (objmodel.VillageID == null)
                {
                    ModelState.AddModelError("VillageID", "Village field is required");
                }
                if (string.IsNullOrEmpty(objmodel.Type_Of_Sample))
                {
                    ModelState.AddModelError("Type_Of_Sample", "Type of Sample field is required");
                }
                if (string.IsNullOrEmpty(objmodel.No_Of_Sample))
                {
                    ModelState.AddModelError("No_Of_Sample", "No of Sample field is required");
                }
                if (objmodel.StudyAnalysisID == null)
                {
                    ModelState.AddModelError("ddlStudyAnalysisID", "Type of Study field is required");
                }
                if (string.IsNullOrEmpty(objmodel.Block))
                {
                    ModelState.AddModelError("txtBlock", "Block field is required");
                }
                if (objmodel.RegionalOfficeId == null)
                {
                    ModelState.AddModelError("RegionalOfficeId", "Regional Office field is required");
                }
                #endregion
                if (ModelState.IsValid)
                {
                    #region File Upload
                    string uniqueFileName = null; string filePath = null;
                    if (objmodel.Attachment != null)
                    {
                        uniqueFileName = DateTime.Now.Ticks.ToString() + "_" + Path.GetFileName(objmodel.Attachment.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadLabReportPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadLabReportPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.Attachment.CopyTo(fileStream);
                        objmodel.AttechmentName = uniqueFileName;
                        objmodel.Attechment = filePath;
                        objmodel.Attachment = null;
                    }
                    #endregion
                    if (submit == "Submit")
                    {
                        objobjmodel = _objLabReportMasterModel.Add(objmodel);
                    }
                    else
                    {
                        objobjmodel = _objLabReportMasterModel.Update(objmodel);
                    }
                    TempData["msg"] = objobjmodel.Satus;
                    return RedirectToAction("Add", "LabReports", new { Area = "Geology" });
                }
                else
                {
                    MPRmaster objmprmodel = new MPRmaster();
                    BindDropdowns();
                    GetOfficerNameAndDesignation();
                    int? id = objmodel.LabReport_Id;
                    if (id != null)
                    {
                        objmodel.LabReport_Id = id;
                        objmodel = _objLabReportMasterModel.Edit(objmodel);
                        objmprmodel.RegionalID = objmodel.RegionalID;
                        objmprmodel.DistrictID = objmodel.DistrictID;
                        objmprmodel.TehsilID = objmodel.TehsilID;
                        listDistrictResult = _objMPRMasterModel.GetDistrictList(objmprmodel);
                        ViewData["District"] = listDistrictResult;
                        listTehsilResult = _objMPRMasterModel.GetTehsilList(objmprmodel);
                        ViewData["Tehsil"] = listTehsilResult;
                        listVillageResult = _objMPRMasterModel.GetVillageList(objmprmodel);
                        ViewData["Village"] = listVillageResult;
                        ViewBag.Button = "Update";
                        return View(objmodel);
                    }
                    else
                    {
                        objmodel.IsActive = true;
                        ViewBag.Button = "Submit";
                        if (objmodel.Date_of_Submission == null)
                            objmodel.Date_of_Submission = DateTime.Now.ToString();
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
                listDistrictResult = null;
                listTehsilResult = null;
                listVillageResult = null;
            }
        }
        /// <summary>
        /// GET method to bind Lab Report details in viewlist
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewList()
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                lstLabReportmaster = _objLabReportMasterModel.View(objmodel);
                ViewBag.ViewList = lstLabReportmaster;
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objmodel = null;
                lstLabReportmaster = null;
            }
        }
        /// <summary>
        /// POST method to bind Lab Report details in viewlist
        /// </summary>
        /// <param name="Show1"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult ViewList(string Show1)
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                ViewBag.ViewList = _objLabReportMasterModel.View(objmodel);
                return View();
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
        /// To delete Lab Report details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public IActionResult Delete(string id = "0")
        {
            try
            {
                objmodel.LabReport_Id = Convert.ToInt32(id);
                objmodel.Attachment = null;
                objobjmodel = _objLabReportMasterModel.Delete(objmodel);
                if (objobjmodel.Satus == "1")
                {
                    TempData["msg"] = "Data Deleted Sucessfully !";
                }
                else
                {
                    TempData["msg"] = "Data not Deleted Sucessfully !";
                }
                return RedirectToAction("ViewList", "LabReports", new { Area = "Geology" });
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
        /// To send Lab report details for forward
        /// </summary>
        /// <param name="LabReport_Id"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SendForForward(int? LabReport_Id)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserId = profile.UserId;
                objmodel.UserLoginId = profile.UserLoginId;
                objmodel.LabReport_Id = LabReport_Id;
                objobjmodel = _objLabReportMasterModel.SendForForward(objmodel);
                return Json(objobjmodel.Satus);
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
        /// Download Uploaded files
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="filepath"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public IActionResult DownloadLab(string filename, string filepath)
        {
            try
            {
                var absolutePath = filename;
                var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadLabReportPath"));
                if (filename != null)
                {
                    if (filepath == null)
                        filepath = Path.Combine(RootPath, filename);
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
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }
        /// <summary>
        /// Method to bind dropdowns
        /// </summary>
        public void BindDropdowns()
        {
            List<LabReportmaster> listMPRCodeResult = new List<LabReportmaster>();
            List<LabReportmaster> listMineralResult = new List<LabReportmaster>();
            List<LabReportmaster> listDivisionResult = new List<LabReportmaster>();
            List<LabReportmaster> listTypeOfStudyAnalysisResult = new List<LabReportmaster>();
            try
            {
                listMPRCodeResult = _objLabReportMasterModel.GetMPRCodeList(objmodel);
                ViewBag.FPOcode = new SelectList(listMPRCodeResult, "FPO_Id", "FPO_Code", objmodel.FPO_Id);
                listMineralResult = _objLabReportMasterModel.GetMineralList(objmodel);
                ViewBag.Mineralname = new SelectList(listMineralResult, "MineralID", "MineralName", objmodel.MineralID);
                listDivisionResult = _objLabReportMasterModel.GetDivisionList(objmodel);
                ViewBag.Division = new SelectList(listDivisionResult, "RegionalID", "RegionalName", objmodel.RegionalID);
                listRegionalOfficeResult = _objLabReportMasterModel.GetRegionalOfficeList(objmodel);
                ViewBag.Regionaloffice = new SelectList(listRegionalOfficeResult, "RegionalOfficeId", "RegionalOfficeName", objmodel.RegionalOfficeId);
                listTypeOfStudyAnalysisResult = _objLabReportMasterModel.GetTypeOfStudyAnalysis(objmodel);
                ViewBag.TypeOfStudyAnalysis = new SelectList(listTypeOfStudyAnalysisResult, "StudyAnalysisID", "StudyAnalysisName", objmodel.StudyAnalysisID);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objmodel = null;
                listMPRCodeResult = null;
                listMineralResult = null;
                listDivisionResult = null;
                listTypeOfStudyAnalysisResult = null;
                listRegionalOfficeResult = null;
            }
        }
        /// <summary>
        /// To bind officer details in view
        /// </summary>
        /// <returns></returns>
        public LabReportmaster GetOfficerNameAndDesignation()
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);             
                objmodel = new LabReportmaster();
                objmodel.UserId = profile.UserId;
                objmodel.UserLoginId = profile.UserLoginId;
                LabReportmaster ofcdata = new LabReportmaster();
                ofcdata = _objLabReportMasterModel.GetOfficerNameAndDesignation(objmodel);
                objmodel.GeologistName = ofcdata.ApplicantName;
                objmodel.Designation = ofcdata.Designation;
                return objmodel;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region Lab Report Forward
        /// <summary>
        /// To view Lab Report details for forward
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewLabReportForward()
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserId = profile.UserId;
                listRegionalOfficeResult = _objLabReportMasterModel.GetRegionalOfficeList(objmodel);
                ViewBag.Regionaloffice = new SelectList(listRegionalOfficeResult, "RegionalOfficeId", "RegionalOfficeName", objmodel.RegionalOfficeId);
                lstLabReportmaster = _objLabReportMasterModel.ViewLabReportForward(objmodel);
                ViewBag.ViewList = lstLabReportmaster;
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objmodel = null;
                listRegionalOfficeResult = null;
                lstLabReportmaster = null;
            }
        }
        /// <summary>
        /// To send Lab Report details for approval
        /// </summary>
        /// <param name="LabReport_Id"></param>
        /// <returns></returns>
        public JsonResult SendForApproval(int? LabReport_Id)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserId = profile.UserId;
                objmodel.UserLoginId = profile.UserLoginId;
                objmodel.LabReport_Id = LabReport_Id;
                objobjmodel = _objLabReportMasterModel.SendForApproval(objmodel);
                return Json(objobjmodel.Satus);
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
        #endregion
        #region StatusOfLabReport
        /// <summary>
        /// To View Lab Report Status
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewStatusOfLabReport()
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserId = profile.UserId;
                objmodel.UserType = profile.UserType;
                lstLabReportmaster = _objLabReportMasterModel.ViewStatusOfLabReport(objmodel);
                ViewBag.ViewList = lstLabReportmaster;
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objmodel = null;
                lstLabReportmaster = null;
            }
        }
        /// <summary>
        /// To Upload Samples results
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult UploadResult(LabReportmaster objmodel, string submit)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserId = profile.UserId;
                objmodel.UserLoginId = profile.UserLoginId;
                #region File Upload
                string uniqueFileName = null; string filePath = null;
                DataTable dt = new DataTable("MultipleFileUpload");
                dt.Columns.Add("LabReport_Id");
                dt.Columns.Add("ResultFileName");
                dt.Columns.Add("Result_Attechment");
                dt.Columns.Add("UserId");
                dt.Columns.Add("UserLoginId");
                if (objmodel.file != null)
                {
                    foreach (IFormFile photo in objmodel.file)
                    {
                        uniqueFileName = DateTime.Now.Ticks.ToString() + "_" + Path.GetFileName(photo.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadSamplesPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadSamplesPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            photo.CopyTo(fileStream);
                        dt.Rows.Add(objmodel.LabReport_Id, uniqueFileName, filePath, objmodel.UserId, objmodel.UserLoginId);//
                    }
                    objmodel.dtUpload = dt;
                }

                #endregion
                if (submit == "submit")
                {
                    objmodel.file = null;
                    objobjmodel = _objLabReportMasterModel.UploadResult(objmodel);
                }
                TempData["msg"] = objobjmodel.Satus;
                return RedirectToAction("ViewStatusOfLabReport", "LabReports", new { Area = "Geology" });
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
        #endregion
        #region GetAnalysedSamples
        /// <summary>
        /// To view analysed samples
        /// </summary>
        /// <returns></returns>
        public IActionResult GetAnalysedSample()
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                objmodel.LabReport_Id = 0;
                objmodel.Type = "ForAnalysedSample";
                lstLabReportmaster = _objLabReportMasterModel.ViewAnalysedSamples(objmodel);
                ViewBag.ViewList = lstLabReportmaster;
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objmodel = null;
                lstLabReportmaster = null;
            }
        }
        /// <summary>
        /// To view uploaded sample results
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public IActionResult AnalysedSample(string id = "0")
        {
            try
            {
                objmodel.LabReport_Id = Convert.ToInt32(id);
                lstLabReportmaster = _objLabReportMasterModel.ViewFilesList(objmodel);
                ViewBag.ViewList = lstLabReportmaster;
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objmodel = null;
                lstLabReportmaster = null;
            }
        }
        #endregion
    }
}