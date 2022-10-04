// ***********************************************************************
//  Controller Name          : InspectionReportController
//  Desciption               : Add,Edit,View,Update,delete Inspection Report details
//  Created By               : Lingaraj Dalai
//  Created On               : 01 March 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using GeologyApp.Models.InspectionReport;
using GeologyApp.Models.MPR;
using GeologyEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using GeologyApp.Web;
using GeologyApp.ActionFilter;
using Newtonsoft.Json;
using System.Linq;

namespace GeologyApp.Controllers
{
    [Area("Geology")]
    public class InspectionReportController : Controller
    {
        /// <summary>
        /// Global object and variable declaration
        /// </summary>
        private readonly IInspectionReportModel _objInspectionReportMasterModel;
        private readonly IMPRModel _objMPRMasterModel;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        MessageEF objobjmodel = new MessageEF();
        InspectionReportmaster objmodel;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objInspectionReportMasterModel"></param>
        /// <param name="objMPRMasterModel"></param>
        /// <param name="hostingEnvironment"></param>
        public InspectionReportController(IInspectionReportModel objInspectionReportMasterModel, IMPRModel objMPRMasterModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _objInspectionReportMasterModel = objInspectionReportMasterModel;
            _objMPRMasterModel = objMPRMasterModel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }
        #region Submit Inspection Report
        /// <summary>
        /// GET method to Add the Inspection report details data in view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public IActionResult Add(string id = "0")
        {
            objmodel = new InspectionReportmaster();
            try
            {
                BindDropdowns();
                GetOfficerNameAndDesignation();
                if (id != "0")
                {
                    objmodel.MPR_ID = Convert.ToInt32(id);
                    objmodel = _objInspectionReportMasterModel.Edit(objmodel);
                    ViewBag.Button = "Update";
                    return View(objmodel);
                }
                else
                {
                    ViewBag.Button = "Submit";
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
        /// POST method to Add the Inspection report details data in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Add(InspectionReportmaster objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserId = profile.UserId;
            objmodel.UserLoginId = profile.UserLoginId;
            try
            {
                #region Validation
                if (objmodel.FPO_Id == null)
                {
                    ModelState.AddModelError("FPO_Id", "Field Program Order is required");
                }
                if (objmodel.FileName == null || objmodel.FileName == "")
                {
                    if (objmodel.Attachment == null)
                    {
                        ModelState.AddModelError("Attachment", "Upload Inspection Report");
                    }
                }
                #endregion
                if (ModelState.IsValid)
                {
                    #region File Upload
                    string uniqueFileName = null; string filePath = null;
                    if (objmodel.Attachment != null)
                    {
                        uniqueFileName = DateTime.Now.Ticks + "_" + Path.GetFileName(objmodel.Attachment.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadInspectionPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadInspectionPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.Attachment.CopyTo(fileStream);
                        objmodel.FileName = uniqueFileName;
                        objmodel.FilePath = filePath;
                        objmodel.Attachment = null;
                    }
                    #endregion
                    if (submit == "Submit")
                    {
                        objobjmodel = _objInspectionReportMasterModel.Add(objmodel);
                    }
                    else
                    {
                        objobjmodel = _objInspectionReportMasterModel.Update(objmodel);
                    }
                    TempData["msg"] = objobjmodel.Satus;
                    return RedirectToAction("Add", "InspectionReport", new { Area = "Geology" });
                }
                else
                {
                    BindDropdowns();
                    GetOfficerNameAndDesignation();
                    int? id = objmodel.MPR_ID;
                    if (id != null)
                    {
                        objmodel.MPR_ID = id;
                        objmodel = _objInspectionReportMasterModel.Edit(objmodel);
                        ViewBag.Button = "Update";
                        return View(objmodel);
                    }
                    else
                    {
                        ViewBag.Button = "Submit";
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
        /// GET method to bind the Inspection report details data in view
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewList()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel = new InspectionReportmaster();
            List<InspectionReportmaster> lstInspReportmaster = new List<InspectionReportmaster>();
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                objmodel.UserId = profile.UserId;
                objmodel.UserLoginId = profile.UserLoginId;
                lstInspReportmaster = _objInspectionReportMasterModel.View(objmodel);
                ViewBag.ViewList = lstInspReportmaster;
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objmodel = null;
                lstInspReportmaster = null;
            }
        }
        /// <summary>
        /// POST method to bind the Inspection report details data in view
        /// </summary>
        /// <param name="Show1"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult ViewList(string Show1)
        {
            objmodel = new InspectionReportmaster();
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                ViewBag.ViewList = _objInspectionReportMasterModel.View(objmodel);
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
        /// To delete Inspection report details data in view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public IActionResult Delete(string id = "0")
        {
            objmodel = new InspectionReportmaster();
            try
            {
                objmodel.MPR_ID = Convert.ToInt32(id);
                objmodel.FileName = null;
                objobjmodel = _objInspectionReportMasterModel.Delete(objmodel);
                if (objobjmodel.Satus == "1")
                {
                    TempData["msg"] = "Data Deleted Sucessfully !";
                }
                else
                {
                    TempData["msg"] = "Data not Deleted Sucessfully !";
                }
                return RedirectToAction("ViewList", "InspectionReport", new { Area = "Geology" });
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
        /// Method to bind MPR code dropdown
        /// </summary>
        public void BindDropdowns()
        {
            objmodel = new InspectionReportmaster();
            List<InspectionReportmaster> listMPRCodeResult = new List<InspectionReportmaster>();
            try
            {
                listMPRCodeResult = _objInspectionReportMasterModel.GetMPRCodeList(objmodel);
                ViewBag.FPOcode = new SelectList(listMPRCodeResult, "FPO_Id", "FPO_Code", objmodel.FPO_Id);
            }
            catch (Exception ex)
            {
                throw;
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
        public InspectionReportmaster GetOfficerNameAndDesignation()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel = new InspectionReportmaster();
            InspectionReportmaster ofcdata = new InspectionReportmaster();
            try
            {
                objmodel.UserId = profile.UserId;
                objmodel.UserLoginId = profile.UserLoginId;
                ofcdata = _objInspectionReportMasterModel.GetOfficerNameAndDesignation(objmodel);
                objmodel.ApplicantName = ofcdata.ApplicantName;
                objmodel.OfficerDesignation = ofcdata.Designation;
                objmodel.OfficerMobileNo = ofcdata.MobileNo;
                objmodel.EmailId = ofcdata.EmailId;
                return objmodel;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ofcdata = null;
            }
        }
        #endregion
        /// <summary>
        /// Added on 14-04-2022 for Add Inspection Report
        /// </summary>
        /// <returns></returns>
        public IActionResult Create(int Inspectionid,string DetailStatus)
        {
            if (Inspectionid == 0 && DetailStatus==null)
            {
                GeologyMainData objmodel = new GeologyMainData();
                ViewBag.DistrictData = _objInspectionReportMasterModel.GetDistrict(objmodel);
                ViewBag.Designation = _objInspectionReportMasterModel.GetDesig(objmodel);
                ViewBag.GetVehicle = _objInspectionReportMasterModel.GetVehicle(objmodel);
                ViewBag.updateStatus = "0";
                return View();
            }
            else if(DetailStatus != null && Inspectionid != 0)
            {
                GeologyMainData objmodel = new GeologyMainData();
                ViewBag.DistrictData = _objInspectionReportMasterModel.GetDistrict(objmodel);
                ViewBag.Designation = _objInspectionReportMasterModel.GetDesig(objmodel);
                ViewBag.GetVehicle = _objInspectionReportMasterModel.GetVehicle(objmodel);
                SelectQueryMultiple obj = new SelectQueryMultiple();
                objmodel.GeologyInspectionReportId = Inspectionid;

                obj = _objInspectionReportMasterModel.SelectDataForUpdate(objmodel);
                ViewBag.CampOfficeStaffDetails = (from k in obj.InformationOnProgressOfRegionalWork where k.type == "CampOfficeOrStaff" select k).ToList();
                ViewBag.InformationAboutDrillingMachines = (from k in obj.InformationOnProgressOfRegionalWork where k.type == "DrillingMachine" select k).ToList();
                ViewBag.NumberAndTypeOfVehicles = (from k in obj.InformationOnProgressOfRegionalWork where k.type == "NumberAndTypeOfVehicles" select k).ToList();
                ViewBag.SurveyEquipment = (from k in obj.InformationOnProgressOfRegionalWork where k.type == "SurveyEquipment" select k).ToList();
                ViewBag.InformationOnProgressOfRegionalWork = (from k in obj.InformationOnProgressOfRegionalWork where k.type == "progressOfRegionalWorkInformation" select k).ToList();
                ViewBag.StatusAndProgressOfDrilling = (from k in obj.InformationOnProgressOfRegionalWork where k.type == "StatusAndProgressofDrillingMachines" select k).ToList();
                ViewBag.TotalSupplyVehiclesAndTheirTypes = (from k in obj.InformationOnProgressOfRegionalWork where k.type == "Vehicles_and_types" select k).ToList();
                ViewBag.TotalExpeditureAfter1stExpediture = (from k in obj.InformationOnProgressOfRegionalWork where k.type == "TotalExpeditureAfterFirstExpediture" select k).ToList();
                ViewBag.FuelConsumptionAverageOfTheVehicle = (from k in obj.InformationOnProgressOfRegionalWork where k.type == "FuelConsumptionAverageOfVehicle" select k).ToList();
                ViewBag.allData = obj.GeologyMainData.ToList();
                ViewBag.updateStatus = "2";
                return View();
            }
            else
            {
                GeologyMainData objmodel = new GeologyMainData();
                ViewBag.DistrictData = _objInspectionReportMasterModel.GetDistrict(objmodel);
                ViewBag.Designation = _objInspectionReportMasterModel.GetDesig(objmodel);
                ViewBag.GetVehicle = _objInspectionReportMasterModel.GetVehicle(objmodel);
                SelectQueryMultiple obj = new SelectQueryMultiple();
                objmodel.GeologyInspectionReportId = Inspectionid;

                obj = _objInspectionReportMasterModel.SelectDataForUpdate(objmodel);
                ViewBag.CampOfficeStaffDetails = (from k in obj.InformationOnProgressOfRegionalWork where k.type == "CampOfficeOrStaff" select k).ToList();
                ViewBag.InformationAboutDrillingMachines =( from k in obj.InformationOnProgressOfRegionalWork where k.type == "DrillingMachine" select k).ToList();
                ViewBag.NumberAndTypeOfVehicles = (from k in obj.InformationOnProgressOfRegionalWork where k.type == "NumberAndTypeOfVehicles" select k).ToList();
                ViewBag.SurveyEquipment = (from k in obj.InformationOnProgressOfRegionalWork where k.type == "SurveyEquipment" select k).ToList();
                ViewBag.InformationOnProgressOfRegionalWork = (from k in obj.InformationOnProgressOfRegionalWork where k.type == "progressOfRegionalWorkInformation" select k).ToList();
                ViewBag.StatusAndProgressOfDrilling = (from k in obj.InformationOnProgressOfRegionalWork where k.type == "StatusAndProgressofDrillingMachines" select k).ToList();
                ViewBag.TotalSupplyVehiclesAndTheirTypes = (from k in obj.InformationOnProgressOfRegionalWork where k.type == "Vehicles_and_types" select k).ToList();
                ViewBag.TotalExpeditureAfter1stExpediture = (from k in obj.InformationOnProgressOfRegionalWork where k.type == "TotalExpeditureAfterFirstExpediture" select k).ToList();
                ViewBag.FuelConsumptionAverageOfTheVehicle = (from k in obj.InformationOnProgressOfRegionalWork where k.type == "FuelConsumptionAverageOfVehicle" select k).ToList();
                ViewBag.allData = obj.GeologyMainData.ToList();
                ViewBag.updateStatus = "1";
                return View();
            }

        }
        [HttpPost]
        public IActionResult CreateAllData(GeologyMainData objData)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {

                #region Validation

               
                if (ModelState.IsValid)
                {
                    objData.UserID = profile.UserId;
                    objData.UserLoginId = profile.UserLoginId;
                    if (objData.hdnUpdateStatus != 0)
                    {
                    objobjmodel = _objInspectionReportMasterModel.UpdateGeologyNew(objData);                        
                    }
                    else
                    {
                        objobjmodel = _objInspectionReportMasterModel.AddGeologyNew(objData);
                    }
                    return Json(new { data = objobjmodel.Msg });

                }
                #endregion
                else
                {
                    return Json(new { data = "please fill all the data" });

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
        /// Added on 14-04-2022 for View Inspection Report
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewReport()
        {
            return View(_objInspectionReportMasterModel.GetAllRecord(new GeologyMainData()));
        }
        [HttpPost]
        public IActionResult ViewReport(GeologyMainData obj)
        {
            return View(_objInspectionReportMasterModel.GetAllRecord(obj));
        }
        [HttpPost]
        public ActionResult GetTahasil(int? DistrictID)
        {
            GeologyMainData objdata = new GeologyMainData();
            objdata.DistrictID = DistrictID;
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            List<GeologyMainData> ofcdata = new List<GeologyMainData>();
            try
            {
                ofcdata = _objInspectionReportMasterModel.GetTahasil(objdata);
                return Json(ofcdata);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ofcdata = null;
            }
        }   
        
        [HttpPost]
        public ActionResult GetDesig()
        {
            GeologyMainData objdata = new GeologyMainData();
            List<GeologyMainData> ofcdata = new List<GeologyMainData>();
            try
            {
                ofcdata = _objInspectionReportMasterModel.GetDesig(objdata);
                return Json(ofcdata);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ofcdata = null;
            }
        }      
        [HttpPost]
        public ActionResult GetVillage(int? DistrictID,int TehasilId)
        {
            GeologyMainData objdata = new GeologyMainData();
            objdata.DistrictID = DistrictID;
            objdata.Tehsil = TehasilId;
            List<GeologyMainData> ofcdata = new List<GeologyMainData>();
            try
            {
                ofcdata = _objInspectionReportMasterModel.GetVillage(objdata);
                return Json(ofcdata);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ofcdata = null;
            }
        }

        [HttpPost]
        public ActionResult GetVehicle()
        {
            GeologyMainData objdata = new GeologyMainData();
            List<GeologyMainData> ofcdata = new List<GeologyMainData>();
            try
            {
                ofcdata = _objInspectionReportMasterModel.GetVehicle(objdata);
                return Json(ofcdata);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                ofcdata = null;
            }
        }

        public IActionResult DeleteInspection(GeologyMainData objData)
        {
            
            try
            {             
                    objobjmodel = _objInspectionReportMasterModel.DeleteInspection(objData);
                    return Json(new { data = objobjmodel.Msg });
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



    }
}