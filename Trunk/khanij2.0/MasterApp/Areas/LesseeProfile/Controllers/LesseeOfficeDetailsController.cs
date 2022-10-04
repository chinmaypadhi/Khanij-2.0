// ***********************************************************************
//  Controller Name          : LesseeOfficeDetailsController
//  Description              : Lessee Office Master View Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 13 July 2021
// ***********************************************************************
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.Areas.LesseeProfile.Models.OfficeDetails;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MasterApp.Web;
using MasterApp.ActionFilter;

namespace MasterApp.Areas.LesseeProfile.Controllers
{
    [Area("LesseeProfile")]
    public class LesseeOfficeDetailsController : Controller
    {
        /// <summary>
        /// Global Variable,object declaration
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        ILesseeOfficeMasterModel _objLesseeOfficeMasterModel;
        OfficeMasterViewModel objmodel = new OfficeMasterViewModel();
        List<OfficeMasterViewModel> listCompanyResult = new List<OfficeMasterViewModel>();
        List<OfficeMasterViewModel> objlistmodel = new List<OfficeMasterViewModel>();
        LesseeProfileRequestModel objProfileRequestmodel = new LesseeProfileRequestModel();
        MessageEF objobjmodel = new MessageEF();
        string uniqueFileName = null;
        string filePath = null;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objLesseeDetailsModel"></param>
        public LesseeOfficeDetailsController(ILesseeOfficeMasterModel objLesseeOfficeMasterModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _objLesseeOfficeMasterModel = objLesseeOfficeMasterModel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }
        /// <summary>
        /// HTTP GET method of Create
        /// </summary>
        /// <returns></returns>
        [Decryption]
        public IActionResult Create(string id = "0")
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                if (id == "0")
                {
                    objmodel.User_Id = profile.UserId;
                }
                else
                {
                    objmodel.User_Id = Convert.ToInt32(id);
                }
                objmodel.MineralTypeName = profile.MineralTypeName;
                objmodel = _objLesseeOfficeMasterModel.GetOfficeMasterDetails(objmodel);
                return View(objmodel);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objmodel = null;
            }
        }
        /// <summary>
        /// HTTP POST method of Create
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Create(OfficeMasterViewModel objmodel, string cmd, string delete)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.User_Id = profile.UserId;
            try
            {
                #region Validation
                if (string.IsNullOrEmpty(objmodel.CategoryOfLicensee))
                {
                    ModelState.AddModelError("CategoryOfLicensee", "Lessee Category field is required");
                }
                if (objmodel.CategoryOfLicensee == "Firm")
                {
                    if (string.IsNullOrEmpty(objmodel.Firm))
                    {
                        ModelState.AddModelError("Firm", "Firm field is required");
                    }
                    if (objmodel.CompanyId == null)
                    {
                        ModelState.AddModelError("CompanyId", "Association/Company field is required");
                    }
                }
                if (objmodel.CategoryOfLicensee == "Association")
                {
                    if (objmodel.CompanyId == null)
                    {
                        ModelState.AddModelError("CompanyId", "Association/Company field is required");
                    }
                }
                if (objmodel.CategoryOfLicensee == "Company")
                {
                    if (string.IsNullOrEmpty(objmodel.Company))
                    {
                        ModelState.AddModelError("Company", "Company field is required");
                    }
                    if (objmodel.CompanyId == null || objmodel.CompanyId == 0)
                    {
                        ModelState.AddModelError("CompanyId", "Association/Company field is required");
                    }
                }
                if (objmodel.Company == "PSU" && profile.MineralName.ToUpper() == "COAL")
                {
                    if (string.IsNullOrEmpty(objmodel.CollieryCode))
                    {
                        ModelState.AddModelError("CollieryCode", "Colliery Code field is required");
                    }
                }
                if (string.IsNullOrEmpty(objmodel.GSTNo))
                {
                    ModelState.AddModelError("GSTNo", "GST Number field is required");
                }
                if (objmodel.MinesType == null)
                {
                    ModelState.AddModelError("MinesType", "Mines Type field is required");
                }
                if (string.IsNullOrEmpty(objmodel.CORPORATE_NAME))
                {
                    ModelState.AddModelError("CORPORATE_NAME", "Corporate Name field is required");
                }
                if (string.IsNullOrEmpty(objmodel.CORPORATE_ADDRESS))
                {
                    ModelState.AddModelError("CORPORATE_ADDRESS", "Corporate Address field is required");
                }
                if (string.IsNullOrEmpty(objmodel.CORPORATE_CONTACT_DETAILS))
                {
                    ModelState.AddModelError("CORPORATE_CONTACT_DETAILS", "Corporate Mobile Number field is required");
                }
                if (objmodel.CORPORATE_CONTACT_DETAILS.Length != 10)
                {
                    ModelState.AddModelError("CORPORATE_CONTACT_DETAILS", "Enter valid Corporate Mobile Number");
                }
                if (profile.MineralTypeName != "Minor Mineral")
                {
                    if (string.IsNullOrEmpty(objmodel.BRANCH_NAME))
                    {
                        ModelState.AddModelError("BRANCH_NAME", "Branch Name field is required");
                    }
                    if (string.IsNullOrEmpty(objmodel.BRANCH_ADDRESS))
                    {
                        ModelState.AddModelError("BRANCH_ADDRESS", "Branch Address field is required");
                    }
                    if (string.IsNullOrEmpty(objmodel.BRANCH_CONTACT_DETAILS))
                    {
                        ModelState.AddModelError("BRANCH_CONTACT_DETAILS", "Branch Mobile Number field is required");
                    }
                    if (!string.IsNullOrEmpty(objmodel.BRANCH_CONTACT_DETAILS))
                    {
                        if (objmodel.BRANCH_CONTACT_DETAILS.Length != 10)
                        {
                            ModelState.AddModelError("BRANCH_CONTACT_DETAILS", "Enter valid Branch Mobile Number");
                        }
                    }
                }
                if (string.IsNullOrEmpty(objmodel.SITE_NAME))
                {
                    ModelState.AddModelError("SITE_NAME", "Site Name field is required");
                }
                if (string.IsNullOrEmpty(objmodel.SITE_ADDRESS))
                {
                    ModelState.AddModelError("SITE_ADDRESS", "Site Address field is required");
                }
                if (string.IsNullOrEmpty(objmodel.SITE_CONTACT_DETAILS))
                {
                    ModelState.AddModelError("SITE_CONTACT_DETAILS", "Site Mobile Number field is required");
                }
                if (!string.IsNullOrEmpty(objmodel.SITE_CONTACT_DETAILS))
                {
                    if (objmodel.SITE_CONTACT_DETAILS.Length != 10)
                    {
                        ModelState.AddModelError("SITE_CONTACT_DETAILS", "Enter valid Site Mobile Number");
                    }
                }
                if (string.IsNullOrEmpty(objmodel.SECONDARY_SITE_NAME))
                {
                    ModelState.AddModelError("SECONDARY_SITE_NAME", "Secondary Site Name field is required");
                }
                if (string.IsNullOrEmpty(objmodel.SECONDARY_SITE_ADDRESS))
                {
                    ModelState.AddModelError("SECONDARY_SITE_ADDRESS", "Secondary Site Address field is required");
                }
                if (string.IsNullOrEmpty(objmodel.SECONDARY_SITE_CONTACT_DETAILS))
                {
                    ModelState.AddModelError("SECONDARY_SITE_CONTACT_DETAILS", "Secondary Site Mobile Number field is required");
                }
                if (!string.IsNullOrEmpty(objmodel.SECONDARY_SITE_CONTACT_DETAILS))
                {
                    if (objmodel.SECONDARY_SITE_CONTACT_DETAILS.Length != 10)
                    {
                        ModelState.AddModelError("SECONDARY_SITE_CONTACT_DETAILS", "Enter valid Secondary Site Mobile Number");
                    }
                }
                if (profile.MineralTypeName != "Minor Mineral")
                {
                    if (string.IsNullOrEmpty(objmodel.AGENT_NAME))
                    {
                        ModelState.AddModelError("AGENT_NAME", "Agent Name field is required");
                    }
                    if (string.IsNullOrEmpty(objmodel.AGENT_ADDRESS))
                    {
                        ModelState.AddModelError("AGENT_ADDRESS", "Agent Address field is required");
                    }
                    if (string.IsNullOrEmpty(objmodel.AGENT_CONTACT_DETAILS))
                    {
                        ModelState.AddModelError("AGENT_CONTACT_DETAILS", "Agent Mobile Number field is required");
                    }
                    if (!string.IsNullOrEmpty(objmodel.AGENT_CONTACT_DETAILS))
                    {
                        if (objmodel.AGENT_CONTACT_DETAILS.Length != 10)
                        {
                            ModelState.AddModelError("AGENT_CONTACT_DETAILS", "Enter valid Agent Mobile Number");
                        }
                    }
                }
                #endregion
                if (ModelState.IsValid)
                {
                    #region File Upload
                    if (objmodel.LETTER_OF_APPOINTMENT_OF_AGENT != null)
                    {
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadPath"));
                        string uploadsFolder = Path.Combine(RootPath, objmodel.LETTER_OF_APPOINTMENT_OF_AGENT.FileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        uniqueFileName = objmodel.LETTER_OF_APPOINTMENT_OF_AGENT.FileName;
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadPath"), uniqueFileName);
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.LETTER_OF_APPOINTMENT_OF_AGENT.CopyTo(fileStream);
                        objmodel.LETTER_OF_APPOINTMENT_OF_AGENT_FILE_NAME = uniqueFileName;
                        objmodel.LETTER_OF_APPOINTMENT_OF_AGENT_FILE_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    objmodel.LETTER_OF_APPOINTMENT_OF_AGENT = null;
                    #endregion
                    var checkDMO = "Forward To DD";
                    if (objmodel.SubResion == "Forward To DD")
                    {
                        cmd = "Forward To DD";
                    }
                    if (checkDMO == cmd)
                    {
                        objmodel.AGENT_STATUS = 1;
                        objmodel.SITE_STATUS = 1;
                        objmodel.BRANCH_STATUS = 1;
                        objmodel.CORPORATE_STATUS = 1;
                        objobjmodel = _objLesseeOfficeMasterModel.UpdateOfficeMasterDetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Lessee Office Details forwarded to DD/DMO successfully";
                        }
                        else if (objobjmodel.Satus == "2")
                        {
                            TempData["Message"] = "Lessee Office Details forwarded to DD/DMO successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while forwarding Lessee Details to DD/DMO";
                        }
                    }
                    else if (delete == "Delete")
                    {
                        objobjmodel = _objLesseeOfficeMasterModel.DeleteLesseeOfficeMasterDetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Lessee Office Details Deleted Sucessfully.";
                        }
                        else
                        {
                            TempData["Message"] = "Lessee Office Details not Deleted Sucessfully.";
                        }
                    }
                    else
                    {
                        objmodel.AGENT_STATUS = 0;
                        objmodel.SITE_STATUS = 0;
                        objmodel.BRANCH_STATUS = 0;
                        objmodel.CORPORATE_STATUS = 0;
                        objobjmodel = _objLesseeOfficeMasterModel.UpdateOfficeMasterDetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Lessee Office Details Saved Successfully";
                        }
                        else if (objobjmodel.Satus == "2")
                        {
                            TempData["Message"] = "Lessee Office Details Updated Successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while Updating Lessee Details";
                        }
                    }
                    return RedirectToAction("Create", "LesseeOfficeDetails", new { Area = "LesseeProfile" });
                }
                else
                {
                    objmodel = _objLesseeOfficeMasterModel.GetOfficeMasterDetails(objmodel);
                    return View(objmodel);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objmodel = null;
                objobjmodel = null;
            }
        }
        /// <summary>
        /// To Compare Lessee Office Request Data in view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public IActionResult CompareOfficeDetails(string id = "0")
        {
            try
            {
                objmodel.INT_CREATED_BY = Convert.ToInt32(id);
                objlistmodel = _objLesseeOfficeMasterModel.GetLesseeOfficeMasterCompareDetails(objmodel);
                return View(objlistmodel);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objmodel = null;
                objlistmodel = null;
            }
        }
        /// <summary>
        /// To Approve,Reject Lessee Office Profile Request Data in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult CompareOfficeDetails(OfficeMasterViewModel objmodel)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.User_Id = profile.UserLoginId;
                if (objmodel.SubApprove == "Approve")
                {
                    objobjmodel = _objLesseeOfficeMasterModel.ApproveLesseeOfficeMasterDetails(objmodel);
                }
                else
                {
                    objobjmodel = _objLesseeOfficeMasterModel.RejectLesseeOfficeMasterDetails(objmodel);
                }
                if (objobjmodel.Satus == "1")
                {
                    TempData["msg"] = "Lessee Office Details Approved successfully";
                }
                else if (objobjmodel.Satus == "2")
                {
                    TempData["msg"] = "Lessee Office Details Rejected successfully";
                }
                else
                {
                    TempData["msg"] = "Error ! while Updating Lessee Office Details";
                }
                string EncryptUrl = CustomQueryStringHelper.EncryptString("LesseeProfile", "CompareOfficeDetails", "LesseeOfficeDetails", new { id = objmodel.INT_CREATED_BY });
                return LocalRedirect(EncryptUrl);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objmodel = null;
                objobjmodel = null;
            }
        }
        /// <summary>
        /// HTTP GET method of ViewList
        /// </summary>
        /// <returns></returns>
        [Decryption]
        public IActionResult ViewList(OfficeMasterViewModel objmodel,string UserId)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                if (!string.IsNullOrEmpty(Convert.ToString(UserId))) //For Other than Lessee User Login
                {
                    objmodel.User_Id = Convert.ToInt32(UserId);
                }
                else
                {
                    objmodel.User_Id = profile.UserId;
                }
                objmodel.MineralTypeName = profile.MineralTypeName;
                objmodel = _objLesseeOfficeMasterModel.GetOfficeMasterDetails(objmodel);
                ViewBag.tableLA = LesseeCategoryTable(objmodel.INT_CREATED_BY);
                ViewBag.tableLB = CorporateOfficeTable(objmodel.INT_CREATED_BY);
                ViewBag.tableLC = BranchOfficeTable(objmodel.INT_CREATED_BY);
                ViewBag.tableLD = SiteOfficeTable(objmodel.INT_CREATED_BY);
                ViewBag.tableLE = AgentOfficeTable(objmodel.INT_CREATED_BY);
                return View(objmodel);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objmodel = null;
            }
        }
        /// <summary>
        /// To Bind the Association List Details Data in View
        /// </summary>
        /// <returns></returns>
        public async Task<JsonResult> GetAssociationListDetails()
        {
            try
            {
                listCompanyResult = await _objLesseeOfficeMasterModel.GetAssociationListDetails(objmodel);
                return Json(listCompanyResult);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objmodel = null;
            }
        }
        /// <summary>
        /// To bind Lessee Category Log Details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public string LesseeCategoryTable(int? Created_By)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            string div = "";
            objmodel.INT_CREATED_BY = Created_By;
            objlistmodel = _objLesseeOfficeMasterModel.GetLesseeCategoryLogDetails(objmodel);
            foreach (var item in objlistmodel)
            {
                div = div + "<li class='timeline-item'>";
                div = div + "<div class='date-box'>";
                div = div + "<p><span class='date'>" + item.ModifyDate + "</span><span class='month-year'>" + item.ModifyYear + "</span></p>";
                div = div + "</div>";
                if (item.CORPORATE_STATUS == 2) //Approved
                {
                    div = div + "<div class='message-highlighter approved'>";
                }
                else if (item.CORPORATE_STATUS == 1) //Forwarded
                {
                    div = div + "<div class='message-highlighter forwarded'>";
                }
                else if (item.CORPORATE_STATUS == 3) //Rejected
                {
                    div = div + "<div class='message-highlighter rejected'>";
                }
                else //Draft
                {
                    div = div + "<div class='message-highlighter draft'>";
                }
                div = div + "<div class='row'>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Category Of Lessee</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.CategoryOfLicensee + "</label>";
                div = div + "</div>";
                if (item.CategoryOfLicensee == "Firm")
                {
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Firm as</label>";
                    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.Firm + "</label>";
                    div = div + "</div>";
                }
                if (item.CategoryOfLicensee == "Company")
                {
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Company as</label>";
                    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.Company + "</label>";
                    div = div + "</div>";
                }
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Company Name</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.CompanyName + "</label>";
                div = div + "</div>";
                if (item.Company == "PSU" && profile.MineralName.ToUpper() == "COAL")
                {
                    div = div + "<label class='col-lg-4 col-md-4 col-sm-12 col-form-label'>Colliery Code</label>";
                    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.CollieryCode + "</label>";
                    div = div + "</div>";
                }
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>GST No.</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.GSTNo + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Mines Type</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.MinesType + "</label>";
                div = div + "</div>";
                div = div + "</div>";
                div = div + "</div>";
                div = div + "</li>";
            }
            return div;
        }
        /// <summary>
        /// To bind Lessee Corporate Office Log Details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public string CorporateOfficeTable(int? Created_By)
        {
            string div = "";
            objmodel.INT_CREATED_BY = Created_By;
            objlistmodel = _objLesseeOfficeMasterModel.GetLesseeCorporateOfficeLogDetails(objmodel);
            foreach (var item in objlistmodel)
            {
                div = div + "<li class='timeline-item'>";
                div = div + "<div class='date-box'>";
                div = div + "<p><span class='date'>" + item.ModifyDate + "</span><span class='month-year'>" + item.ModifyYear + "</span></p>";
                div = div + "</div>";
                if (item.CORPORATE_STATUS == 2) //Approved
                {
                    div = div + "<div class='message-highlighter approved'>";
                }
                else if (item.CORPORATE_STATUS == 1) //Forwarded
                {
                    div = div + "<div class='message-highlighter forwarded'>";
                }
                else if (item.CORPORATE_STATUS == 3) //Rejected
                {
                    div = div + "<div class='message-highlighter rejected'>";
                }
                else //Draft
                {
                    div = div + "<div class='message-highlighter draft'>";
                }
                div = div + "<div class='row'>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Name Prefix</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.CORPORATE_NAME_PREFIX + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Name</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.CORPORATE_NAME + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Address</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.CORPORATE_ADDRESS + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Mobile Number</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.CORPORATE_CONTACT_DETAILS + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>LandLine No</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.CORPORATE_LANDLINE_NO + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Designation</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.CORPORATE_DESIGNATION + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Email Id</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.CORPORATE_MAIL_ID + "</label>";
                div = div + "</div>";
                div = div + "</div>";
                div = div + "</div>";
                div = div + "</li>";
            }
            return div;
        }
        /// <summary>
        /// To bind Lessee Branch Office Log Details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public string BranchOfficeTable(int? Created_By)
        {
            string div = "";
            objmodel.INT_CREATED_BY = Created_By;
            objlistmodel = _objLesseeOfficeMasterModel.GetLesseeBranchOfficeLogDetails(objmodel);
            foreach (var item in objlistmodel)
            {
                div = div + "<li class='timeline-item'>";
                div = div + "<div class='date-box'>";
                div = div + "<p><span class='date'>" + item.ModifyDate + "</span><span class='month-year'>" + item.ModifyYear + "</span></p>";
                div = div + "</div>";
                if (item.BRANCH_STATUS == 2) //Approved
                {
                    div = div + "<div class='message-highlighter approved'>";
                }
                else if (item.BRANCH_STATUS == 1) //Forwarded
                {
                    div = div + "<div class='message-highlighter forwarded'>";
                }
                else if (item.BRANCH_STATUS == 3) //Rejected
                {
                    div = div + "<div class='message-highlighter rejected'>";
                }
                else //Draft
                {
                    div = div + "<div class='message-highlighter draft'>";
                }
                div = div + "<div class='row'>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Name Prefix</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.BRANCH_NAME_PREFIX + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Name</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.BRANCH_NAME + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Address</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.BRANCH_ADDRESS + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Mobile Number</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.BRANCH_CONTACT_DETAILS + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>LandLine No</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.BRANCH_LANDLINE_NO + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Designation</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.BRANCH_DESIGNATION + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Email Id</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.BRANCH_MAIL_ID + "</label>";
                div = div + "</div>";
                div = div + "</div>";
                div = div + "</div>";
                div = div + "</li>";
            }
            return div;
        }
        /// <summary>
        /// To bind Lessee Site Office Log Details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public string SiteOfficeTable(int? Created_By)
        {
            string div = "";
            objmodel.INT_CREATED_BY = Created_By;
            objlistmodel = _objLesseeOfficeMasterModel.GetLesseeSiteOfficeLogDetails(objmodel);
            foreach (var item in objlistmodel)
            {
                div = div + "<li class='timeline-item'>";
                div = div + "<div class='date-box'>";
                div = div + "<p><span class='date'>" + item.ModifyDate + "</span><span class='month-year'>" + item.ModifyYear + "</span></p>";
                div = div + "</div>";
                if (item.SITE_STATUS == 2) //Approved
                {
                    div = div + "<div class='message-highlighter approved'>";
                }
                else if (item.SITE_STATUS == 1) //Forwarded
                {
                    div = div + "<div class='message-highlighter forwarded'>";
                }
                else if (item.SITE_STATUS == 3) //Rejected
                {
                    div = div + "<div class='message-highlighter rejected'>";
                }
                else //Draft
                {
                    div = div + "<div class='message-highlighter draft'>";
                }
                div = div + "<h5 class='font-weight-bold text-brown'>Primary Contact Details</h5>";
                div = div + "<div class='row'>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Name Prefix</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.SITE_NAME_PREFIX + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Name</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.SITE_NAME + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Address</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.SITE_ADDRESS + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Mobile Number</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.SITE_CONTACT_DETAILS + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>LandLine No</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.SITE_LANDLINE_NO + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Designation</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.SITE_DESIGNATION + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Email Id</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.SITE_MAIL_ID + "</label>";
                div = div + "</div>";
                div = div + "</div>";
                div = div + "<h5 class='font-weight-bold text-brown'>Secondary Contact Details</h5>";
                div = div + "<div class='row'>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Name Prefix</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.SECONDARY_SITE_NAME_PREFIX + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Name</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.SECONDARY_SITE_NAME + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Address</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.SECONDARY_SITE_ADDRESS + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Mobile Number</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.SECONDARY_SITE_CONTACT_DETAILS + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>LandLine No</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.SECONDARY_SITE_LANDLINE_NO + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Designation</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.SECONDARY_SITE_DESIGNATION + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Email Id</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.SECONDARY_SITE_MAIL_ID + "</label>";
                div = div + "</div>";
                div = div + "</div>";
                div = div + "</div>";
                div = div + "</li>";
            }
            return div;
        }
        /// <summary>
        /// To bind Lessee Agent Office Log Details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public string AgentOfficeTable(int? Created_By)
        {
            string div = "";
            objmodel.INT_CREATED_BY = Created_By;
            objlistmodel = _objLesseeOfficeMasterModel.GetLesseeAgentOfficeLogDetails(objmodel);
            foreach (var item in objlistmodel)
            {
                div = div + "<li class='timeline-item'>";
                div = div + "<div class='date-box'>";
                div = div + "<p><span class='date'>" + item.ModifyDate + "</span><span class='month-year'>" + item.ModifyYear + "</span></p>";
                div = div + "</div>";
                if (item.AGENT_STATUS == 2) //Approved
                {
                    div = div + "<div class='message-highlighter approved'>";
                }
                else if (item.AGENT_STATUS == 1) //Forwarded
                {
                    div = div + "<div class='message-highlighter forwarded'>";
                }
                else if (item.AGENT_STATUS == 3) //Rejected
                {
                    div = div + "<div class='message-highlighter rejected'>";
                }
                else //Draft
                {
                    div = div + "<div class='message-highlighter draft'>";
                }
                div = div + "<div class='row'>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Name Prefix</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.AGENT_NAME_PREFIX + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Name</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.AGENT_NAME + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Address</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.AGENT_ADDRESS + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Mobile Number</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.AGENT_CONTACT_DETAILS + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>LandLine No</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.AGENT_LANDLINE_NO + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Designation</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.AGENT_DESIGNATION + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Email Id</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.AGENT_MAIL_ID + "</label>";
                div = div + "</div>";
                div = div + "</div>";
                div = div + "</div>";
                div = div + "</li>";
            }
            return div;
        }
    }
}
