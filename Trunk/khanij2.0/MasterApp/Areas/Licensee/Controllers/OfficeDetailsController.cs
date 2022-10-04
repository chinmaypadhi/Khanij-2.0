using MasterApp.ActionFilter;
using MasterApp.Areas.Licensee.Models;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Licensee.Controllers
{
    [Area("Licensee")]
    public class OfficeDetailsController : Controller
    {
        /// <summary>
        /// Global Declaration
        /// </summary>
        IUserInformationLicenseeModel _userInformation;
        MessageEF objMsgmodel = new MessageEF();
        List<LicenseeDetails> objlistmodel = new List<LicenseeDetails>();
        LicenseeDetails objlicenseeDetails = new LicenseeDetails();
        LicenseeResult objlicenseeResult = new LicenseeResult();
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        string uniqueFileName = string.Empty;
        string filePath = string.Empty;
        string ExtensionId = string.Empty;
        /// <summary>
        /// Constructor Dependency Injection
        /// </summary>
        /// <param name="userInformationLicenseeModel"></param>
        /// <param name="hostingEnvironment"></param>
        /// <param name="configuration"></param>
        public OfficeDetailsController(IUserInformationLicenseeModel userInformationLicenseeModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _userInformation = userInformationLicenseeModel;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;

        }
        public async Task<IActionResult> Create()
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objlicenseeDetails.UserID = profile.UserId;
                objlicenseeDetails.CREATED_BY = profile.UserId;
                objlicenseeResult = await _userInformation.GetLicenseeOfficeDetails(objlicenseeDetails);
                if(objlicenseeResult.LicesenseeOfficeDetailsList !=null)
                {
                    return View(objlicenseeResult.LicesenseeOfficeDetailsList.FirstOrDefault());
                }
                else
                {
                    return View(new LicenseeDetails());
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objlicenseeResult = null;
            }
        }
        [HttpPost,ValidateAntiForgeryToken]
        
        public async Task <IActionResult> Create(LicenseeDetails objmodel, string cmd, string delete, IFormFile selectedFile)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserID = profile.UserId;
            objmodel.CREATED_BY = profile.UserId;
            try
            {
                #region Validation
                if (string.IsNullOrEmpty(objmodel.CategoryOfLicensee))
                {
                    ModelState.AddModelError("CategoryOfLicensee", "Licensee Category field is required");
                }
                if (objmodel.CategoryOfLicensee == "Firm")
                {
                    if (string.IsNullOrEmpty(objmodel.FirmAs))
                    {
                        ModelState.AddModelError("Firm", "Firm field is required");
                    }
                    if (objmodel.CompanyId == 0)
                    {
                        ModelState.AddModelError("CompanyId", "Company Name field is required");
                    }
                }
                if (objmodel.CategoryOfLicensee == "Association")
                {
                    if (objmodel.CompanyId == 0)
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
                    if (objmodel.CompanyId == 0)
                    {
                        ModelState.AddModelError("CompanyId", "Association/Company field is required");
                    }
                }
                //if (objmodel.Company == "PSU")
                //{
                //    if (string.IsNullOrEmpty(objmodel.CollieryCode))
                //    {
                //        ModelState.AddModelError("CollieryCode", "Colliery Code field is required");
                //    }
                //}
                //if (string.IsNullOrEmpty(objmodel.GSTNo))
                //{
                //    ModelState.AddModelError("GSTNo", "GST Number field is required");
                //}
                //if (objmodel.MinesType == null)
                //{
                //    ModelState.AddModelError("MinesType", "Mines Type field is required");
                //}
                if (string.IsNullOrEmpty(objmodel.CORPORATE_NAME))
                {
                    ModelState.AddModelError("CORPORATE_NAME", "Corporate Name field is required");
                }
                if (string.IsNullOrEmpty(objmodel.CORPORATE_ADDRESS))
                {
                    ModelState.AddModelError("CORPORATE_ADDRESS", "Corporate Address field is required");
                }
                if (string.IsNullOrEmpty(objmodel.CORPORATE_CONTACT_DETAILS1))
                {
                    ModelState.AddModelError("CORPORATE_CONTACT_DETAILS", "Corporate Mobile Number field is required");
                }
                //if (objmodel.CORPORATE_CONTACT_DETAILS1.Length != 10)
                //{
                //    ModelState.AddModelError("CORPORATE_CONTACT_DETAILS", "Enter valid Corporate Mobile Number");
                //}
                if (string.IsNullOrEmpty(objmodel.BRANCH_NAME))
                {
                    ModelState.AddModelError("BRANCH_NAME", "Branch Name field is required");
                }
                if (string.IsNullOrEmpty(objmodel.BRANCH_ADDRESS))
                {
                    ModelState.AddModelError("BRANCH_ADDRESS", "Branch Address field is required");
                }
                if (string.IsNullOrEmpty(objmodel.BRANCH_CONTACT_DETAILS1))
                {
                    ModelState.AddModelError("BRANCH_CONTACT_DETAILS", "Branch Mobile Number field is required");
                }
                //if (!string.IsNullOrEmpty(objmodel.BRANCH_CONTACT_DETAILS1))
                //{
                //    if (objmodel.BRANCH_CONTACT_DETAILS1.Length != 10)
                //    {
                //        ModelState.AddModelError("BRANCH_CONTACT_DETAILS", "Enter valid Branch Mobile Number");
                //    }
                //}
                if (string.IsNullOrEmpty(objmodel.SITE_NAME))
                {
                    ModelState.AddModelError("SITE_NAME", "Site Name field is required");
                }
                if (string.IsNullOrEmpty(objmodel.SITE_ADDRESS))
                {
                    ModelState.AddModelError("SITE_ADDRESS", "Site Address field is required");
                }
                if (string.IsNullOrEmpty(objmodel.SITE_CONTACT_DETAILS1))
                {
                    ModelState.AddModelError("SITE_CONTACT_DETAILS", "Site Mobile Number field is required");
                }
                if (!string.IsNullOrEmpty(objmodel.SITE_CONTACT_DETAILS1))
                {
                    if (objmodel.SITE_CONTACT_DETAILS1.Length != 10)
                    {
                        ModelState.AddModelError("SITE_CONTACT_DETAILS", "Enter valid Site Mobile Number");
                    }
                }
                
                if (string.IsNullOrEmpty(objmodel.AGENT_NAME))
                {
                    ModelState.AddModelError("AGENT_NAME", "Agent Name field is required");
                }
                if (string.IsNullOrEmpty(objmodel.AGENT_ADDRESS))
                {
                    ModelState.AddModelError("AGENT_ADDRESS", "Agent Address field is required");
                }
                if (string.IsNullOrEmpty(objmodel.AGENT_CONTACT_DETAILS1))
                {
                    ModelState.AddModelError("AGENT_CONTACT_DETAILS", "Agent Mobile Number field is required");
                }
                if (!string.IsNullOrEmpty(objmodel.AGENT_CONTACT_DETAILS1))
                {
                    if (objmodel.AGENT_CONTACT_DETAILS1.Length != 10)
                    {
                        ModelState.AddModelError("AGENT_CONTACT_DETAILS", "Enter valid Agent Mobile Number");
                    }
                }
                #endregion
                if (ModelState.IsValid)
                {
                    #region File Upload
                    if (objmodel.LETTER_OF_APPOINTMENT_OF_AGENT != null)
                    {
                        var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("OfficePath"));
                        string uploadsFolder = Path.Combine(RootPath, objmodel.LETTER_OF_APPOINTMENT_OF_AGENT.FileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        uniqueFileName = objmodel.LETTER_OF_APPOINTMENT_OF_AGENT.FileName;
                        filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("OfficePath"), uniqueFileName);
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.LETTER_OF_APPOINTMENT_OF_AGENT.CopyTo(fileStream);
                        objmodel.FILE_LETTER_OF_APPOINTMENT_OF_AGENT = uniqueFileName;
                        objmodel.LETTER_OF_APPOINTMENT_OF_AGENT_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                        objmodel.LETTER_OF_APPOINTMENT_OF_AGENT = null;
                    }
                    
                    #endregion
                    var checkDMO = "Forward To DD";
                    if (objmodel.SubResion == "Forward To DD")
                    {
                        cmd = "Forward To DD";
                    }
                    if (checkDMO == cmd)
                    {
                        objmodel.STATUS = 1;
                        objMsgmodel = _userInformation.UpdateLicenseeOfficeDetails(objmodel);
                        if (objMsgmodel.Satus == "1")
                        {
                            TempData["Message"] = "Licensee Office Details forwarded to DD/DMO successfully";
                        }
                        else if (objMsgmodel.Satus == "2")
                        {
                            TempData["Message"] = "Licensee Office Details forwarded to DD/DMO successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while forwarding Licensee Details to DD/DMO";
                        }
                    }
                    else if (delete == "Delete")
                    {
                        objMsgmodel = _userInformation.DeleteLicenseeOfficeDetails(objmodel);
                        if (objMsgmodel.Satus == "1")
                        {
                            TempData["Message"] = "Licensee Office Details Deleted Sucessfully.";
                        }
                        else
                        {
                            TempData["Message"] = "Licensee Office Details not Deleted Sucessfully.";
                        }
                    }
                    else
                    {
                        objmodel.STATUS = 0;
                        objMsgmodel = _userInformation.UpdateLicenseeOfficeDetails(objmodel);
                        if (objMsgmodel.Satus == "1")
                        {
                            TempData["Message"] = "Licensee Office Details Saved Successfully";
                        }
                        else if (objMsgmodel.Satus == "2")
                        {
                            TempData["Message"] = "Licensee Office Details Updated Successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while Updating Licensee Details";
                        }
                    }
                    return RedirectToAction("Create", "OfficeDetails", new { Area = "Licensee" });
                }
                else
                {
                    objlicenseeResult = await _userInformation.GetLicenseeOfficeDetails(objmodel);
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
                objMsgmodel = null;
            }
        }
        [HttpGet, Decryption]
        public IActionResult CompareOfficeDetails(string id ="0")
        {
            try
            {
                if(!string.IsNullOrEmpty(id) && id!="0")
                {
                    UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                    objlicenseeDetails.CREATED_BY = Convert.ToInt32(id);
                    objlicenseeDetails.UserID = Convert.ToInt32(id);
                    objlistmodel = _userInformation.CompareLicenseeOfficeDetails(objlicenseeDetails);
                    return View(objlistmodel);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objlicenseeDetails = null;
                objlistmodel = null;
            }
        }
        [HttpPost]
        public IActionResult CompareOfficeDetails(LicenseeDetails objmodel, int id = 0)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserID = profile.UserId;
                
                if (objmodel.SubApprove == "Approve")
                {
                    objMsgmodel = _userInformation.ApproveLicenseeOfficeDetails(objmodel);
                }
                else
                {
                    objMsgmodel = _userInformation.RejectLicenseeOfficeDetails(objmodel);
                }
                if (objMsgmodel.Satus == "1")
                {
                    TempData["msg"] = "Licensee Office Details Approved successfully";
                }
                else if (objMsgmodel.Satus == "2")
                {
                    TempData["msg"] = "Licensee Office Details Rejected successfully";
                }
                else
                {
                    TempData["msg"] = "Error ! while Updating Lessee Office Details";
                }
                //return RedirectToAction("CompareOfficeDetails", "OfficeDetails", new { Area = "Licensee" });
                string EncryptUrl = CustomQueryStringHelper.EncryptString("Licensee", "CompareOfficeDetails", "OfficeDetails", new { id = objmodel.CREATED_BY });
                return LocalRedirect(EncryptUrl);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objmodel = null;
                objMsgmodel = null;
            }
        }
        public async Task<IActionResult> ViewList(int id=0)
        {
            UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            LicenseeDetails objlicenseedetails = new LicenseeDetails();
            try
            {
                objlicenseedetails.UserID = session.UserId;
                objlicenseedetails.CREATED_BY = session.UserId;
                objlicenseedetails.UserLoginId = session.UserLoginId.ToString();
                LicenseeResult listobj = await _userInformation.GetLicenseeOfficeDetails(objlicenseedetails);
                ViewBag.tableLA = LesseeCategoryTable(objlicenseedetails.CREATED_BY);
                ViewBag.tableLB = CorporateOfficeTable(objlicenseedetails.CREATED_BY);
                ViewBag.tableLC = BranchOfficeTable(objlicenseedetails.CREATED_BY);
                ViewBag.tableLD = SiteOfficeTable(objlicenseedetails.CREATED_BY);
                ViewBag.tableLE = AgentOfficeTable(objlicenseedetails.CREATED_BY);
                return View(listobj.LicesenseeOfficeDetailsList.FirstOrDefault());
            }
            catch (Exception)
            {
                throw;
            }
            finally { objlicenseedetails = null; }
        }
        /// <summary>
        /// To bind Licensee Category Log Details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public string LesseeCategoryTable(int? Created_By)
        {
            string div = "";
            objlicenseeDetails.CREATED_BY = Created_By;
            objlicenseeDetails.UserID = Created_By;

            objlistmodel =  _userInformation.GetLicenseeOfficeLogDetails(objlicenseeDetails);
            foreach (var item in objlistmodel)
            {
                div = div + "<li class='timeline-item'>";
                div = div + "<div class='date-box'>";
                div = div + "<p><span class='date'>" + item.ModifyDate + "</span><span class='month-year'>" + item.ModifyYear + "</span></p>";
                div = div + "</div>";
                if (item.STATUS == 2)
                {
                    div = div + "<div class='message-highlighter approved'>";
                }
                else
                {
                    div = div + "<div class='message-highlighter draft'>";
                }
                div = div + "<div class='row'>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Category Of Lessee</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.CategoryOfLicensee + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Firm as</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.FirmAs + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Company as</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.Company + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Company Name</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.CompanyName + "</label>";
                div = div + "</div>";
                //if (item.Company == "PSU")
                //{
                //    div = div + "<label class='col-lg-4 col-md-4 col-sm-12 col-form-label'>Colliery Code</label>";
                //    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                //    div = div + "<span class='colon'>:</span>" + item.CollieryCode + "</label>";
                //    div = div + "</div>";
                //}
                //div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>GST No.</label>";
                //div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                //div = div + "<span class='colon'>:</span>" + item.GSTNo + "</label>";
                //div = div + "</div>";
                //div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Mines Type</label>";
                //div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                //div = div + "<span class='colon'>:</span>" + item.MinesType + "</label>";
                //div = div + "</div>";
                div = div + "</div>";
                div = div + "</div>";
                div = div + "</li>";
            }
            return div;
        }
        /// <summary>
        /// To bind Licensee Corporate Office Log Details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public string CorporateOfficeTable(int? Created_By)
        {
            string div = "";
            objlicenseeDetails.CREATED_BY = Created_By;
            objlicenseeDetails.UserID = Created_By;
            objlistmodel = _userInformation.GetLicenseeOfficeLogDetails(objlicenseeDetails);
            foreach (var item in objlistmodel)
            {
                div = div + "<li class='timeline-item'>";
                div = div + "<div class='date-box'>";
                div = div + "<p><span class='date'>" + item.ModifyDate + "</span><span class='month-year'>" + item.ModifyYear + "</span></p>";
                div = div + "</div>";
                if (item.STATUS == 2)
                {
                    div = div + "<div class='message-highlighter approved'>";
                }
                else
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
                div = div + "<span class='colon'>:</span>" + item.CORPORATE_CONTACT_DETAILS1 + "</label>";
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
        /// To bind Licensee Branch Office Log Details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public string BranchOfficeTable(int? Created_By)
        {
            string div = "";
            objlicenseeDetails.CREATED_BY = Created_By;
            objlicenseeDetails.UserID = Created_By;
            objlistmodel = _userInformation.GetLicenseeOfficeLogDetails(objlicenseeDetails);
            foreach (var item in objlistmodel)
            {
                div = div + "<li class='timeline-item'>";
                div = div + "<div class='date-box'>";
                div = div + "<p><span class='date'>" + item.ModifyDate + "</span><span class='month-year'>" + item.ModifyYear + "</span></p>";
                div = div + "</div>";
                if (item.STATUS == 2)
                {
                    div = div + "<div class='message-highlighter approved'>";
                }
                else
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
                div = div + "<span class='colon'>:</span>" + item.BRANCH_CONTACT_DETAILS1 + "</label>";
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
        /// To bind Licensee Site Office Log Details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public string SiteOfficeTable(int? Created_By)
        {
            string div = "";
            objlicenseeDetails.CREATED_BY = Created_By;
            objlicenseeDetails.UserID = Created_By;
            objlistmodel = _userInformation.GetLicenseeOfficeLogDetails(objlicenseeDetails);
            foreach (var item in objlistmodel)
            {
                div = div + "<li class='timeline-item'>";
                div = div + "<div class='date-box'>";
                div = div + "<p><span class='date'>" + item.ModifyDate + "</span><span class='month-year'>" + item.ModifyYear + "</span></p>";
                div = div + "</div>";
                if (item.STATUS == 2)
                {
                    div = div + "<div class='message-highlighter approved'>";
                }
                else
                {
                    div = div + "<div class='message-highlighter draft'>";
                }
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
                div = div + "<span class='colon'>:</span>" + item.SITE_CONTACT_DETAILS1 + "</label>";
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

                div = div + "</div>";
                div = div + "</li>";
            }
            return div;
        }
        /// <summary>
        /// To bind Licensee Agent Office Log Details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public string AgentOfficeTable(int? Created_By)
        {
            string div = "";
            objlicenseeDetails.CREATED_BY = Created_By;
            objlicenseeDetails.UserID = Created_By;
            objlistmodel = _userInformation.GetLicenseeOfficeLogDetails(objlicenseeDetails);
            foreach (var item in objlistmodel)
            {
                div = div + "<li class='timeline-item'>";
                div = div + "<div class='date-box'>";
                div = div + "<p><span class='date'>" + item.ModifyDate + "</span><span class='month-year'>" + item.ModifyYear + "</span></p>";
                div = div + "</div>";
                if (item.STATUS == 2)
                {
                    div = div + "<div class='message-highlighter approved'>";
                }
                else
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
                div = div + "<span class='colon'>:</span>" + item.AGENT_CONTACT_DETAILS1 + "</label>";
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
        public async Task<JsonResult> GetAssociationListDetails()
        {
            try
            {
                objlistmodel = await _userInformation.GetAssociationListDetails(objlicenseeDetails);
                return Json(objlistmodel);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objlistmodel = null;
            }
        }
    }
}
