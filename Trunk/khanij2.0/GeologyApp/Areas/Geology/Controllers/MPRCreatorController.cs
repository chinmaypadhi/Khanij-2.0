// ***********************************************************************
//  Controller Name          : MPRCreatorController
//  Desciption               : To Add,View,Edit,Update,Approve Monthly Progress Report
//  Created By               : Lingaraj Dalai
//  Created On               : 18 Feb 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using GeologyApp.ActionFilter;
using GeologyApp.Web;
using GeologyApp.Models.MailService;
using GeologyApp.Models.MPR;
using GeologyEF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace GeologyApp.Controllers
{
    [Area("Geology")]
    public class MPRCreatorController : Controller
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        private readonly IMailModel mailModel;
        IMPRModel _objMPRMasterModel;
        MessageEF objobjmodel = new MessageEF();
        MPRmaster objmodel;
        MPRWorkmaster objworkmodel = new MPRWorkmaster();
        GeologyMail mailobj = new GeologyMail();     
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        /// <param name="objMPRMasterModel"></param>
        /// <param name="hostingEnvironment"></param>
        public MPRCreatorController(IMPRModel objMPRMasterModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration, IMailModel mailModel)
        {
            _objMPRMasterModel = objMPRMasterModel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
            this.mailModel = mailModel;
        }
        /// <summary>
        /// HTTP Get method of Add action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public IActionResult Add(string id = "0")
        {
            objmodel = new MPRmaster();
            List<MPRmaster> listDistrictResult = new List<MPRmaster>();
            List<MPRmaster> listTehsilResult = new List<MPRmaster>();
            List<MPRmaster> listVillageResult = new List<MPRmaster>();
            try
            {
                BindDropdowns(objmodel);
                GetOfficerNameAndDesignation(objmodel);
                if (id != "0")
                {
                    objmodel.MPR_Id = Convert.ToInt32(id);
                    objmodel = _objMPRMasterModel.Edit(objmodel);
                    ViewBag.Button = "Update";
                    GetOfficerNameAndDesignation(objmodel);
                    return View(objmodel);
                }
                else
                {
                    objmodel.IsActive = true;
                    ViewBag.Button = "Submit";
                    ViewBag.Date = DateTime.Now.ToString("dd/MM/yyyy");
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
                listDistrictResult = null;
                listTehsilResult = null;
                listVillageResult = null;
            }
        }
        /// <summary>
        /// POST method to Add MPR details
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Add(MPRmaster objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserId = profile.UserId;
            objmodel.UserLoginId = profile.UserLoginId;
            List<MPRmaster> listDistrictResult = new List<MPRmaster>();
            List<MPRmaster> listTehsilResult = new List<MPRmaster>();
            List<MPRmaster> listVillageResult = new List<MPRmaster>();
            try
            {
                #region Validation
                if (objmodel.FPO_Id == null)
                {
                    ModelState.AddModelError("FPO_Id", "Field Program Order Code field is required");
                }
                if (string.IsNullOrEmpty(objmodel.Report_MY))
                {
                    ModelState.AddModelError("txtReport_MY", "Report Month Year date is required");
                }
                if (objmodel.MineralID == null)
                {
                    ModelState.AddModelError("MineralID", "Mineral field is required");
                }
                if (objmodel.RegionalID == null)
                {
                    ModelState.AddModelError("RegionalID", "Division field is required");
                }
                if (string.IsNullOrEmpty(objmodel.PostOffice))
                {
                    ModelState.AddModelError("PostOffice", "PostOffice field is required");
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
                if (objmodel.RegionalOfficeId == null)
                {
                    ModelState.AddModelError("RegionalOfficeId", "Regional office field is required");
                }
                if (string.IsNullOrEmpty(objmodel.BlockName))
                {
                    ModelState.AddModelError("BlockName", "Block Name field is required");
                }
                if (string.IsNullOrEmpty(objmodel.PinCode))
                {
                    ModelState.AddModelError("PinCode", "PinCode field is required");
                }
                #endregion
                if (ModelState.IsValid)
                {
                    GetOfficerNameAndDesignation(objmodel);
                    if (submit == "Submit")
                    {
                        objobjmodel = _objMPRMasterModel.Add(objmodel);
                    }
                    else
                    {
                        objmodel.IsActive = true;                       
                        objobjmodel = _objMPRMasterModel.Update(objmodel);
                    }
                    TempData["msg"] = objobjmodel.Satus;
                    return RedirectToAction("Add", "MPRCreator", new { Area = "Geology" });
                }
                else
                {
                    int? id = objmodel.MPR_Id;
                    BindDropdowns(objmodel);
                    GetOfficerNameAndDesignation(objmodel);
                    if (id != null)
                    {
                        objmodel.MPR_Id = id;
                        objmodel = _objMPRMasterModel.Edit(objmodel);
                        ViewBag.Button = "Update";
                        GetOfficerNameAndDesignation(objmodel);
                        return View(objmodel);
                    }
                    else
                    {
                        objmodel.IsActive = true;
                        ViewBag.Button = "Submit";
                        ViewBag.Date = DateTime.Now.ToString("dd/MM/yyyy");
                        return View(objmodel);
                    }
                }
            }
            catch(Exception ex)
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
        /// GET method to bind MPR details in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        public IActionResult ViewList(MPRmaster objmodel)
        {
            List<MPRmaster> lstFPOmaster = new List<MPRmaster>();
            try
            {
                lstFPOmaster = _objMPRMasterModel.View(objmodel);
                ViewBag.ViewList = lstFPOmaster;
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                lstFPOmaster = null;
                objmodel = null;
            }
        }
        /// <summary>
        /// Method to bind dropdowns
        /// </summary>
        /// <param name="objmodel"></param>
        public void BindDropdowns(MPRmaster objmodel)
        {
            List<MPRmaster> listMPRCodeResult = new List<MPRmaster>();
            List<MPRmaster> listMineralResult = new List<MPRmaster>();
            List<MPRmaster> listDivisionResult = new List<MPRmaster>();
            List<MPRmaster> listRegionalOfficeResult = new List<MPRmaster>();
            try
            {               
                listMPRCodeResult = _objMPRMasterModel.GetMPRCodeList(objmodel);
                ViewBag.FPOcode = new SelectList(listMPRCodeResult, "FPO_Id", "FPO_Code", objmodel.FPO_Id);               
                listMineralResult = _objMPRMasterModel.GetMineralList(objmodel);
                ViewBag.Mineralname = new SelectList(listMineralResult, "MineralID", "MineralName", objmodel.MineralID);             
                listDivisionResult = _objMPRMasterModel.GetDivisionList(objmodel);
                ViewBag.Division = new SelectList(listDivisionResult, "RegionalID", "RegionalName", objmodel.RegionalID);                
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                listMPRCodeResult = null;
                listMineralResult = null;
                listDivisionResult = null;
                listRegionalOfficeResult = null;
                objmodel = null;
            }
        }
        /// <summary>
        /// Store MPR Id in session variables
        /// </summary>
        /// <param name="MPR_Id"></param>
        /// <returns></returns>
        public ActionResult MPR_Work(int? MPR_Id)
        {
            TempData["MPR_Id"] = MPR_Id;
            TempData["Temp_MPR_ID"] = MPR_Id;
            return View();
        }
        /// <summary>
        /// To Get the Monthly Progress Report Details Data in View based on MPR Id
        /// </summary>
        /// <param name="MPR_Id"></param>
        /// <returns></returns>
        public JsonResult getMultipleMPRData(int? MPR_Id)
        {
            objmodel = new MPRmaster();
            try
            {
                objmodel.MPR_Id = MPR_Id;
                objmodel = _objMPRMasterModel.Edit(objmodel);
                return Json(objmodel);
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                objmodel = null;
            }
        }
        /// <summary>
        /// To Send MPR details for approval
        /// </summary>
        /// <param name="MPR_Id"></param>
        /// <returns></returns>
        public JsonResult SendForApproval(int? MPR_Id)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);            
            objmodel = new MPRmaster();
            bool IsEMail = false;
            try
            {
                objmodel.MPR_Id = MPR_Id;
                objmodel.UserId = profile.UserId;
                objmodel.UserLoginId = profile.UserLoginId;
                objmodel.Approve_Status = 1;
                objobjmodel = _objMPRMasterModel.SendForApproval(objmodel);
                SendMaildata(MPR_Id, "FORWARD_RO");
                return Json(objobjmodel.Satus);
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                objmodel = null;
            }
        }
        /// <summary>
        /// To get Mail Information Details
        /// </summary>
        /// <param name="MPR_Id"></param>
        /// <returns></returns>
        public bool SendMaildata(int? MPR_Id,string MailType)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel = new MPRmaster();
            try
            {
                bool IsEMail = false;
                objmodel.MPR_Id = MPR_Id;
                objmodel.UserId = profile.UserId;
                objmodel = _objMPRMasterModel.GetMaildata(objmodel);
                mailobj.Type = MailType;
                mailobj.EmailId = objmodel.EmailId;
                mailobj.EmailIdCC = objmodel.EmailIdCC;
                mailobj.FPO = objmodel.FPO_Code;
                mailobj.MineralName = objmodel.MineralName;
                if (mailobj.EmailId != null)
                {
                    if (mailobj.EmailId != "")
                    {
                        #region Send Mail
                        try
                        {
                            objobjmodel=mailModel.SendMail_MPR(mailobj);
                            if(objobjmodel.Satus=="success")
                            {
                                IsEMail = true;
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        #endregion
                    }
                }
                return IsEMail;
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                objmodel = null;
                mailobj = null;
            }
        }
        /// <summary>
        /// To bind MPR Camps details in view
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public ActionResult App_Action_ViewMPR(string Type, string id = "0")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel = new MPRmaster();
            objmodel = new MPRmaster();
            try
            {
                //TempData["UserName"] = Type == "RO" ? "Regional Office" : "DGM";
                TempData["UserName"] = profile.UserType;
                objmodel.MPR_Id = Convert.ToInt32(id);
                objmodel = _objMPRMasterModel.PreviewMPRMaster(objmodel);
                if (objmodel.Camps_Name != null)
                {
                    string[] Camps_Name_values = objmodel.Camps_Name.Split(',');
                    for (int J = 0; J < Camps_Name_values.Length; J++)
                    {
                        string value = Camps_Name_values[J].Trim();
                        objmodel.List_Camps_Name.Add(value);
                    }
                }
                if (objmodel.Camps_Designation != null)
                {
                    string[] Camps_Designation_values = objmodel.Camps_Designation.Split(',');
                    for (int J = 0; J < Camps_Designation_values.Length; J++)
                    {
                        string value = Camps_Designation_values[J].Trim();
                        objmodel.List_Camps_Designation.Add(value);
                    }
                }
                if (objmodel.Camps_From != null)
                {
                    string[] Camps_From_values = objmodel.Camps_From.Split(',');
                    for (int J = 0; J < Camps_From_values.Length; J++)
                    {
                        string value = Camps_From_values[J].Trim();
                        objmodel.List_Camps_From.Add(value);
                    }
                }
                if (objmodel.Camps_To != null)
                {
                    string[] Camps_To_values = objmodel.Camps_To.Split(',');
                    for (int J = 0; J < Camps_To_values.Length; J++)
                    {
                        string value = Camps_To_values[J].Trim();
                        objmodel.List_Camps_To.Add(value);
                    }
                }
                if (objmodel.Camps_To != null)
                {
                    string[] Camps_No_Of_Days_values = objmodel.Camps_No_Of_Days.Split(',');
                    for (int J = 0; J < Camps_No_Of_Days_values.Length; J++)
                    {
                        string value = Camps_No_Of_Days_values[J].Trim();
                        objmodel.List_Camps_No_Of_Days.Add(value);
                    }
                }
                if (objmodel.Camps_Remarks != null)
                {
                    string[] Camps_Remarks_values = objmodel.Camps_Remarks.Split(',');
                    string[] Camps_From_values = objmodel.Camps_From.Split(',');
                    for (int J = 0; J < Camps_From_values.Length; J++)
                    {
                        string value = Camps_Remarks_values[J].Trim();
                        objmodel.List_Camps_Remarks.Add(value);
                    }
                }
                List<MPRWorkmaster> lstFPOmaster = _objMPRMasterModel.ViewMPRWorkMaster(objworkmodel);
                ViewBag.ViewList = lstFPOmaster;
                return View(objmodel);
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
        #region Dropdowns
        /// <summary>
        /// To bind Officer details in view
        /// </summary>
        /// <param name="objmodel"></param>
        public void GetOfficerNameAndDesignation(MPRmaster objmodel)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            MPRmaster ofcdata = new MPRmaster();
            try
            {             
                ofcdata.UserId = profile.UserId;
                ofcdata = _objMPRMasterModel.GetOfficerNameAndDesignation(ofcdata);
                objmodel.ApplicantName = ofcdata.ApplicantName;
                objmodel.Designation = ofcdata.Designation;
                objmodel.MobileNo = ofcdata.MobileNo;
                objmodel.EmailId = ofcdata.EmailId;
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                objmodel = null;
                ofcdata = null;
            }
        }
        /// <summary>
        /// To get FPO details by FPO code
        /// </summary>
        /// <param name="FPOId"></param>
        /// <returns></returns>
        public JsonResult GetFPOdetailsByFPOCode(int? FPOId)
        {
            objmodel = new MPRmaster();
            try
            {
                objmodel.FPO_Id = FPOId;
                objmodel = _objMPRMasterModel.GetFPOdetailsByFPOCode(objmodel);
                return Json(objmodel);
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                objmodel = null;
            }
        }
        /// <summary>
        /// To get District details by Region
        /// </summary>
        /// <param name="RegionalID"></param>
        /// <returns></returns>
        public JsonResult GetDistrictdetailsByRegionId(int? RegionalID)
        {
            List<MPRmaster> lstdistrictModels = new List<MPRmaster>();
            objmodel = new MPRmaster();
            try
            {
                objmodel.RegionalID = RegionalID;              
                lstdistrictModels = _objMPRMasterModel.GetDistrictList(objmodel);
                return Json(lstdistrictModels);
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                lstdistrictModels = null;
                objmodel = null;
            }
        }
        /// <summary>
        /// To get Tehsil details by District
        /// </summary>
        /// <param name="DistrictID"></param>
        /// <returns></returns>
        public JsonResult GetTehsildetailsByDistrictId(int? DistrictID)
        {
            List<MPRmaster> lsttehsilModels = new List<MPRmaster>();
            objmodel = new MPRmaster();
            try
            {
                objmodel.DistrictID = DistrictID;               
                lsttehsilModels = _objMPRMasterModel.GetTehsilList(objmodel);
                return Json(lsttehsilModels);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                lsttehsilModels = null;
                objmodel = null;
            }
        }
        /// <summary>
        /// To get Village details by Tehsil
        /// </summary>
        /// <param name="TehsilID"></param>
        /// <returns></returns>
        public JsonResult GetVillagedetailsByTehsilId(int? TehsilID)
        {
            objmodel = new MPRmaster();
            List<MPRmaster> lstvillageModels = new List<MPRmaster>();
            try
            {
                objmodel.TehsilID = TehsilID;                
                lstvillageModels = _objMPRMasterModel.GetVillageList(objmodel);
                return Json(lstvillageModels);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                lstvillageModels = null;
                objmodel = null;
            }
        }
        /// <summary>
        /// To bind Regional Office Details in view
        /// </summary>
        /// <returns></returns>
        public JsonResult GetRegionalOfficeList()
        {
            objmodel = new MPRmaster();
            List<MPRmaster> listRegionalOfficeResult = new List<MPRmaster>();
            try
            {
                listRegionalOfficeResult = _objMPRMasterModel.GetRegionalOfficeList(objmodel);
                return Json(listRegionalOfficeResult);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                listRegionalOfficeResult = null;
                objmodel = null;
            }
        }
        #endregion
        #region MPR Approver
        /// <summary>
        /// To bind MPR details for approval
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        public IActionResult MPRApproval(MPRmaster objmodel)
        {
            List<MPRmaster> lstFPOmaster = new List<MPRmaster>();
            try
            {
                lstFPOmaster = _objMPRMasterModel.ViewMPRApprover(objmodel);
                ViewBag.ViewList = lstFPOmaster;
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                lstFPOmaster = null;
                objmodel = null;
            }
        }
        /// <summary>
        /// To Update MPR Approval status in view
        /// </summary>
        /// <param name="MPR_Id"></param>
        /// <param name="Remarks"></param>
        /// <returns></returns>
        public JsonResult UpdateMPR_Status(int? MPR_Id, string Remarks)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel = new MPRmaster();
            try
            {
                objmodel.MPR_Id = MPR_Id;
                objmodel.Remarks = Remarks;
                objmodel.UserId = profile.UserId;
                objobjmodel = _objMPRMasterModel.UpdateMPR_Status(objmodel);
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
        /// To Update Reject Status in view
        /// </summary>
        /// <param name="MPR_Id"></param>
        /// <param name="Remarks"></param>
        /// <returns></returns>
        public JsonResult UpdateMPR_Referback(int? MPR_Id, string Remarks)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel = new MPRmaster();
            try
            {
                objmodel.MPR_Id = MPR_Id;
                objmodel.Remarks = Remarks;
                objmodel.UserId = profile.UserId;
                objobjmodel = _objMPRMasterModel.UpdateMPR_Referback(objmodel);
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
        #region MPR Forwarder
        /// <summary>
        /// To Forward MPR details to Regional Office in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        public IActionResult MPRForwarder(MPRmaster objmodel)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            List<MPRmaster> lstFPOmaster = new List<MPRmaster>();
            objmodel = new MPRmaster();
            try
            {
                objmodel.UserId = profile.UserId;
                objmodel.UserName = profile.UserName;
                lstFPOmaster = _objMPRMasterModel.ViewMPRForwarder(objmodel);
                ViewBag.ViewList = lstFPOmaster;
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objmodel = null;
                lstFPOmaster = null;
            }
        }
        /// <summary>
        /// To Forward MPR details to DGM Office in view
        /// </summary>
        /// <param name="MPR_Id"></param>
        /// <returns></returns>
        public JsonResult FORWARD_TO_DGM(int? MPR_Id)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel = new MPRmaster();
            try
            {
                objmodel.MPR_Id = MPR_Id;
                objmodel.UserId = profile.UserId;
                objobjmodel = _objMPRMasterModel.FORWARD_TO_DGM(objmodel);
                SendMaildata(MPR_Id, "FORWARD_DGM");
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
        /// To Revert MPR details
        /// </summary>
        /// <param name="MPR_Id"></param>
        /// <param name="Remarks"></param>
        /// <returns></returns>
        public JsonResult FORWARDER_REFER_BACK(int? MPR_Id,string Remarks)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel = new MPRmaster();
            try
            {
                objmodel.MPR_Id = MPR_Id;
                objmodel.Remarks = Remarks;
                objmodel.UserId = profile.UserId;
                objobjmodel = _objMPRMasterModel.FORWARDER_REFER_BACK(objmodel);
                return Json(objobjmodel.Satus);
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                objmodel = null;
            }
        }
        #endregion
        #region Download files
        /// <summary>
        /// To download MPR files
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public ActionResult DowuloadMPRs(string filename, string filepath)
        {
            var absolutePath = filename;
            var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadMPRWorkPath"));
            if (filename != null)
            {
                if (filepath == null)
                    filepath = Path.Combine(RootPath, filename);
                if (filename.Contains("_"))
                {
                    string[] splitfilename = filename.Split('_');
                    filename = splitfilename[1];
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
        #endregion
    }
}