using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using Microsoft.AspNetCore.Hosting;
using MasterApp.Areas.Licensee.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using MasterApp.Controllers;
using Microsoft.Extensions.Configuration;
using MasterApp.Web;
using MasterApp.ActionFilter;

namespace MasterApp.Areas.Licensee.Controllers
{
    [Area("Licensee")]
    public class UserInformationLienseeController : Controller
    {
        #region Global Variable Decalaration
        /// <summary>
        /// Global Variable Declaration
        /// </summary>
        IUserInformationLicenseeModel _userInformation;
        MessageEF objMSmodel = new MessageEF();
        List<IBMDetails> objlistmodel = new List<IBMDetails>();
        List<CTEDetails> objCTEList = new List<CTEDetails>();
        public object JsonRequestBehavior { get; private set; }
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        private string filepath = string.Empty;
        string Signature = string.Empty;
        string OutputResult = string.Empty;
        
        #endregion
        public UserInformationLienseeController(IUserInformationLicenseeModel objUserInformation, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _userInformation = objUserInformation;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }
        #region IBM Details
        /// <summary>
        /// To Get IBM Details of Licensee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> IBMDetails()
        {
            IBMDetails model = new IBMDetails();
            LicenseeResult objAppl = new LicenseeResult();
            try
            {
                UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                if (session.UserId != 0)
                {
                    model.UserLoginId = session.UserLoginId.ToString();
                    model.CREATED_BY= session.UserId;
                    model.UserID = session.UserId;
                    objAppl = await _userInformation.GetLicenseeIBMDetail(model);
                    if (objAppl.IBMDetailsLst != null)
                        return View(objAppl.IBMDetailsLst.FirstOrDefault());
                    else
                        return View(new IBMDetails());
                }
                else
                {
                    return View(new IBMDetails());
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                model = null;
                objAppl = null;
            }
        }
        /// <summary>
        /// To  Update, Forward and Delete IBM Details of Licensee
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cmd"></param>
        /// <param name="approve"></param>
        /// <param name="reject"></param>
        /// <param name="id"></param>
        /// <param name="selectedFile"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult IBMDetails(IBMDetails model, string cmd, string approve, string reject, int? id, IFormFile selectedFile)
        {
            try
            {
                UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                string DD_DMO = "Forward To DD";
               
                if (model.SubResion == "Forward To DD")
                {
                    cmd = DD_DMO;
                }
                if (cmd == "Approve")
                {
                    approve = "Approve";
                }
                if (cmd == "Reject")
                {
                    reject = "Reject";
                }
                #region for Validation
                if (string.IsNullOrEmpty(model.IBM_NUMBER))
                {
                    ModelState.AddModelError("IBM_NUMBER", "IBM NUMBER is Required");
                }
                if(string.IsNullOrEmpty(model.IBM_APPLICATON_DATE))
                {
                    ModelState.AddModelError("IBM_APPLICATON_DATE", "Applicatiion No is Required");
                }
                if(string.IsNullOrEmpty(model.IBM_APPLICATION_NUMBER))
                {
                    ModelState.AddModelError("IBM_APPLICATION_NUMBER", "IBM Registration No is Required");
                }
                #endregion
                if (ModelState.IsValid)
                {
                    if (approve == null && reject == null)
                    {
                        #region Upload File in flRegistrationCopy

                        if (selectedFile != null && selectedFile.Length > 0)
                        {
                            if (!string.IsNullOrEmpty(selectedFile.FileName))
                            {
                                string hosting = _hostingEnvironment.ContentRootPath;
                                string wwwPath = this._hostingEnvironment.WebRootPath;
                                string strName = DateTime.Now.Date.Day.ToString() + DateTime.Now.Date.Month.ToString() + DateTime.Now.Date.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                                var fileName = strName + "_" + selectedFile.FileName;
                                filepath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("IBMPath"), fileName);
                                var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("IBMPath"));
                                string UploadFolderPath = Path.Combine(RootPath, fileName);
                                //For Checking Folder Exists or not
                                if (!Directory.Exists(RootPath))
                                Directory.CreateDirectory(RootPath);
                                DirectoryInfo di = new DirectoryInfo(RootPath);
                                di.Attributes = FileAttributes.Normal;
                                using (var stream = new FileStream(UploadFolderPath, FileMode.Create))
                                {
                                    selectedFile.CopyTo(stream);
                                }
                                model.IBM_REGISTRATION_FORM_PATH = filepath;
                                model.FILE_IBM_REGISTRATION_FORM = fileName;
                                filepath = null;
                            }

                        }

                        #endregion
                        if (model.LICENSEE_IBM_ID == 0)
                        {
                            if (cmd == DD_DMO)
                            {
                                model.STATUS = 1;
                                model.UserID = Convert.ToInt32(session.UserId);
                                model.CREATED_BY = Convert.ToInt32(session.UserId);
                                model.UserLoginId = session.UserLoginId.ToString();
                                objMSmodel = _userInformation.UpdateLicenseeIBMDetail(model);
                                if (objMSmodel.Satus == "1")
                                {
                                    TempData["Message"] = "IBM Details forwarded to DD/DMO successfully";
                                }
                                else
                                {
                                    TempData["Message"] = "Error ! while forwarding IBM Details to DD/DMO";
                                }
                                return RedirectToAction("IBMDetails");
                            }
                            else
                            {
                                model.STATUS = 0;
                                model.UserID = Convert.ToInt32(session.UserId);
                                model.CREATED_BY = Convert.ToInt32(session.UserId);
                                model.UserLoginId = session.UserLoginId.ToString();
                                objMSmodel = _userInformation.NewLicenseeIBMDetail(model);
                                if (objMSmodel.Satus == "1")
                                {
                                    TempData["Message"] = "IBM Details Saved Successfully";
                                }
                                else
                                {
                                    TempData["Message"] = "Error ! while Saving IBM Details";
                                }

                                return RedirectToAction("IBMDetails",new {id= model.UserID});
                            }
                        }
                        else
                        {
                            if (cmd == DD_DMO)
                            {
                                model.STATUS = 1;
                                model.UserID = Convert.ToInt32(session.UserId);
                                model.CREATED_BY = Convert.ToInt32(session.UserId);
                                model.UserLoginId = session.UserLoginId.ToString();
                                objMSmodel = _userInformation.UpdateLicenseeIBMDetail(model);
                                if (objMSmodel.Satus == "1")
                                {
                                    TempData["Message"] = "IBM Details forwarded to DD/DMO successfully";
                                }
                                else
                                {
                                    TempData["Message"] = "Error ! while forwarding IBM Details to DD/DMO";
                                }
                                return RedirectToAction("IBMDetails");
                            }
                            else if (cmd == "Delete")
                            {
                                model.UserID = Convert.ToInt32(id);
                                model.UserLoginId = session.UserLoginId.ToString();
                                objMSmodel = _userInformation.DeleteLicenseeIBMDetail(model);
                                if (objMSmodel.Satus == "1")
                                {
                                    TempData["Message"] = "IBM Details Deleted Successfully";
                                }
                                else
                                {
                                    TempData["Message"] = "Error ! while Deleting IBM Details";
                                }

                                return RedirectToAction("IBMDetails");
                            }
                            else
                            {
                                model.STATUS = 0;
                                model.UserID = Convert.ToInt32(session.UserId);
                                model.CREATED_BY = Convert.ToInt32(session.UserId);
                                model.UserLoginId = session.UserLoginId.ToString();
                                objMSmodel = _userInformation.UpdateLicenseeIBMDetail(model);
                                if (objMSmodel.Satus == "1")
                                {
                                    TempData["Message"] = "IBM Details Updated Successfully";
                                }
                                else
                                {
                                    TempData["Message"] = "Error ! while Updating IBM Details";
                                }

                                return RedirectToAction("IBMDetails");
                            }
                        }
                    }
                }
                return View(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// To Comapre IBM Details of Licensee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Decryption]
        public IActionResult CompareIBMDetails(string id="0")
        {
            IBMDetails obj = new IBMDetails();
            try
            {
                if (!string.IsNullOrEmpty(id) && id != "0")
                {
                    obj.UserID = Convert.ToInt32(id);
                    obj.CREATED_BY= Convert.ToInt32(id);
                    List<IBMDetails> listobj = _userInformation.CompareIBMDetails(obj);
                    return View(listobj);
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
            finally { obj = null; }
        }
        /// <summary>
        /// To Approve and Reject IBM details of Licensee
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CompareIBMDetails(IBMDetails model)
        {
            UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserLoginId = session.UserLoginId.ToString();
            if(model.SubApprove=="Approve")
            {
                model.UserID = Convert.ToInt32(session.UserId);
                objMSmodel = _userInformation.ApproveLicenseeIBMDetails(model);
                if (objMSmodel.Satus == "1")
                {
                    TempData["Message"] = "Licensee IBM Details Approved successfully";
                }
                else
                {
                    TempData["Message"] = "Error ! while Approving Licensee IBM Details";
                }
            }
            else if(model.SubReject=="Reject")
            {
                model.UserID = Convert.ToInt32(session.UserId);
                model.UserLoginId = session.UserLoginId.ToString();
                objMSmodel = _userInformation.RejectLicenseeIBMDetails(model);
                if (objMSmodel.Satus == "1")
                {
                    TempData["Message"] = "Lessee IBM Details Rejected successfully";
                }
                else
                {
                    TempData["Message"] = "Error ! while Rejecting Lessee IBM Details";
                }
            }

            //return RedirectToAction("CompareIBMDetails", "UserInformationLiensee", new {Area="Licensee" });
            string EncryptUrl = CustomQueryStringHelper.EncryptString("Licensee", "CompareIBMDetails", "UserInformationLiensee", new { id = model.CREATED_BY });
            return LocalRedirect(EncryptUrl);
        }
        /// <summary>
        /// To Bind View and Log of IBM Details
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ViewIBMDetails()
        {
            UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            IBMDetails model = new IBMDetails();
            try
            {
                model.CREATED_BY = session.UserId;
                // UserInformationLicenseeEF obj = _userInformation.ViewIBMDetails(model);
                LicenseeResult listobj = await _userInformation.GetLicenseeIBMDetail(model);
                if (listobj.IBMDetailsLst != null)
                {
                    ViewBag.tableLA = await IBMTable(model.CREATED_BY);
                    return View(listobj.IBMDetailsLst.FirstOrDefault());
                }
                else
                {
                    return View(new IBMDetails());
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                model = null;
            }
        }
        /// <summary>
        /// To bind IBM Log Details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public async Task<string> IBMTable(int? Created_By)
        {
            string div = "";
            IBMDetails objmodel = new IBMDetails();
            objmodel.CREATED_BY = Created_By;
            objlistmodel = await _userInformation.GetIBMLogDetails(objmodel);
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
                else if (item.STATUS == 1)
                {
                    div = div + "<div class='message-highlighter forwarded'>";
                }
                else if (item.STATUS == 3)
                {
                    div = div + "<div class='message-highlighter rejected'>";
                }
                else
                {
                    div = div + "<div class='message-highlighter draft'>";
                }
                div = div + "<div class='row'>";
                div = div + "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>IBM Mine Code</label>";
                div = div + "<div class='col-lg-2 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.IBM_NUMBER + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>Registration Number</label>";
                div = div + "<div class='col-lg-2 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.IBM_APPLICATION_NUMBER + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>IBM Registration Date</label>";
                div = div + "<div class='col-lg-2 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.IBM_APPLICATON_DATE + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>Registration Form</label>";
                div = div + "<div class='col-lg-4 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.FILE_IBM_REGISTRATION_FORM + "";
                if (item.FILE_IBM_REGISTRATION_FORM != null && item.FILE_IBM_REGISTRATION_FORM != "")
                {
                    div = div + "<a href='" + @Url.Content("~/" + item.IBM_REGISTRATION_FORM_PATH) + "' class='ml-2' data-original-title='Download Registration Form' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                }
                div = div + "</div>";
                div = div + "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>Remarks</label>";
                div = div + "<div class='col-lg-2 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.Remarks + "</label>";
                div = div + "</div>";
                div = div + "</div>";
                div = div + "</div>";
                
                div = div + "</li>";
            }
            return div;
        }
        #endregion

        #region CTE Details of Licensee
        /// <summary>
        /// To get CTE Details of Licensee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> CTEDetails()
        {
            CTEDetails model = new CTEDetails();
            LicenseeResult objAppl = new LicenseeResult();
            try
            {
                UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                if (session.UserId != 0)
                {
                    model.CREATED_BY = session.UserId;
                    model.UserID = session.UserId;
                    objAppl = await _userInformation.GetLicenseeCTEDetail(model);
                    if(objAppl.CTEDetailsLst !=null)
                    {
                        return View(objAppl.CTEDetailsLst.FirstOrDefault());
                    }
                    else
                    {
                        return View(new CTEDetails());
                    }
                }
                else
                {
                    return View(new CTEDetails());
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                model = null;
                objAppl = null;
            }
            
        }
        /// <summary>
        /// To Add, Update, Forward and Delte CTE Details of Licensee
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cmd"></param>
        /// <param name="approve"></param>
        /// <param name="reject"></param>
        /// <param name="id"></param>
        /// <param name="selectedFile"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult CTEDetails(CTEDetails model, string cmd, string approve, string reject, int? id, IFormFile selectedFile)
        {
            try
            {
                UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                
                model.UserLoginId = session.UserLoginId.ToString();
                #region Validation
                if (string.IsNullOrEmpty(model.CTE_ORDER_NO))
                {
                    ModelState.AddModelError("CTE_ORDER_NO", "CTE order No is Required");
                }
                if (string.IsNullOrEmpty(model.CTE_ORDER_DATE))
                {
                    ModelState.AddModelError("CTE_ORDER_DATE", "CTE order Date is Required");
                }
                if (string.IsNullOrEmpty(model.CTE_VALID_FROM))
                {
                    ModelState.AddModelError("CTE_VALID_FROM", "CTE Valid From is Required");
                }
                if (string.IsNullOrEmpty(model.CTE_VALID_TO))
                {
                    ModelState.AddModelError("CTE_VALID_TO", "CTE Valid To is Required");
                }
                #endregion
                if (ModelState.IsValid)
                {
                    var DD_DMO = "Forward To DD";

                    if (model.SubResion == "Forward To DD")
                    {
                        cmd = "Forward To DD";
                    }
                    if (model.SubApprove == "Approve")
                    {
                        approve = "Approve";
                    }
                    if (model.SubReject == "Reject")
                    {
                        reject = "Reject";
                    }
                    if (approve == null && reject == null)
                    {
                        #region Upload File in flCTELetter

                        if (selectedFile != null && selectedFile.Length > 0)
                        {

                            if (!string.IsNullOrEmpty(selectedFile.FileName))
                            {
                                string hosting = _hostingEnvironment.ContentRootPath;
                                string strName = DateTime.Now.Date.Day.ToString() + DateTime.Now.Date.Month.ToString() + DateTime.Now.Date.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                                var fileName = strName + "_" + selectedFile.FileName;
                                filepath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("CTEPath"), fileName);
                                var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("CTEPath"));
                                string UploadFolderPath = Path.Combine(RootPath, fileName);
                                if (!Directory.Exists(RootPath))
                                    Directory.CreateDirectory(RootPath);
                                DirectoryInfo di = new DirectoryInfo(RootPath);
                                di.Attributes = FileAttributes.Normal;
                               
                                using (var stream = new FileStream(UploadFolderPath, FileMode.Create))
                                {
                                    selectedFile.CopyTo(stream);
                                }
                                model.CTE_LETTER_PATH = filepath;
                                model.FILE_CTE_LETTER = fileName;
                                filepath = null;
                            }

                        }

                        #endregion
                        if (model.CTE_ID == null || model.CTE_ID == 0)
                        {
                            if (cmd == DD_DMO)
                            {
                                model.STATUS = 1;
                                model.UserID = Convert.ToInt32(session.UserId);
                                model.CREATED_BY= Convert.ToInt32(session.UserId);
                                model.UserLoginId = session.UserLoginId.ToString();
                                objMSmodel = _userInformation.NewLicenseeCTEDetail(model);
                                if (objMSmodel.Satus == "1")
                                {
                                    TempData["Message"] = "Consent to Establish Details forwarded to DD/DMO successfully";
                                }
                                else
                                    TempData["Message"] = "Error ! while forwarding Consent to Establish Details to DD/DMO";
                            }
                            else
                            {
                                model.STATUS = 0;
                                model.UserID = Convert.ToInt32(session.UserId);
                                model.CREATED_BY = Convert.ToInt32(session.UserId);
                                model.UserLoginId = session.UserLoginId.ToString();
                                objMSmodel = _userInformation.NewLicenseeCTEDetail(model);
                                if (objMSmodel.Satus == "1")
                                {
                                    TempData["Message"] = "Consent to Establish Details Saved Successfully";
                                }
                                else
                                {
                                    TempData["Message"] = "Error ! while Saving Consent to Establish Details";
                                }

                            }
                        }
                        else
                        {
                            if (cmd == DD_DMO)
                            {
                                model.STATUS = 1;
                                model.UserID = Convert.ToInt32(session.UserId);
                                model.CREATED_BY = Convert.ToInt32(session.UserId);
                                model.UserLoginId = session.UserLoginId.ToString();
                                objMSmodel = _userInformation.UpdateLicenseeCTEDetail(model);
                                if (objMSmodel.Satus == "1")
                                {
                                    TempData["Message"] = "Consent to Establish Details forwarded to DD/DMO successfully";
                                }
                                else
                                    TempData["Message"] = "Error ! while forwarding Consent to Establish Details to DD/DMO";
                            }
                            else if (cmd == "Delete")
                            {
                                model.UserID = Convert.ToInt32(session.UserId);
                                model.CREATED_BY = Convert.ToInt32(session.UserId);
                                model.UserLoginId = session.UserLoginId.ToString();
                                objMSmodel = _userInformation.DeleteCTEDetail(model);
                                if (objMSmodel.Satus == "1")
                                {
                                    TempData["Message"] = "CTE Details Deleted Successfully";
                                }
                                else
                                {
                                    TempData["Message"] = "Error ! while Deleting CTE Details";
                                }

                                return RedirectToAction("CTEDetails");
                            }
                            else
                            {
                                model.STATUS = 0;
                                model.UserID = Convert.ToInt32(session.UserId);
                                model.CREATED_BY = Convert.ToInt32(session.UserId);
                                model.UserLoginId = session.UserLoginId.ToString();
                                objMSmodel = _userInformation.UpdateLicenseeCTEDetail(model);
                                if (objMSmodel.Satus == "1")
                                {
                                    TempData["Message"] = "Consent to Establish Details Updated Successfully";
                                }
                                else
                                    TempData["Message"] = "Error ! while Updating Consent to Establish Details ";
                            }
                        }
                    }
                    return RedirectToAction("CTEDetails");

                }
                return View(model);
            }
            catch (Exception)
            { 
                throw;
            }
            
        }
        /// <summary>
        /// To Comapre CTE Details of Licensee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet,Decryption]
        public IActionResult CompareCTEDetails(string id)
        {
            CTEDetails objcTEDetails = new CTEDetails();
            try
            {
                if (!string.IsNullOrEmpty(id) && id != "0")
                {
                    objcTEDetails.UserID = Convert.ToInt32(id);
                    objcTEDetails.CREATED_BY = Convert.ToInt32(id);
                    List<CTEDetails> cTEDetailsList = _userInformation.CompareCTEDetails(objcTEDetails);
                    return View(cTEDetailsList);
                }
                else
                    return View();
            }
            catch (Exception)
            {
                throw;
            }
            finally { objcTEDetails = null; }
        }
        /// <summary>
        /// To Approve and Reject CTE Details of Licensee
        /// </summary>
        /// <param name="cTEDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CompareCTEDetails(CTEDetails cTEDetails)
        {
            try
            {
                UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                if (cTEDetails.SubApprove == "Approve")
                {
                    cTEDetails.UserLoginId = session.UserLoginId.ToString();
                    cTEDetails.UserID = session.UserId;
                    objMSmodel = _userInformation.ApproveLicenseeCTEDetails(cTEDetails);
                    if (objMSmodel.Satus == "1")
                    {
                        TempData["Message"] = "Consent to Establish Details Approved successfully";
                    }
                    else
                    {
                        TempData["Message"] = "Error ! while Approving Licensee Consent to Establish Details";
                    }
                }
                else if (cTEDetails.SubReject == "Reject")
                {

                    cTEDetails.UserID = Convert.ToInt32(session.UserId);
                    cTEDetails.UserLoginId = session.UserLoginId.ToString();
                    objMSmodel = _userInformation.RejectLicenseeCTEDetails(cTEDetails);
                    if (objMSmodel.Satus == "1")
                    {
                        TempData["Message"] = "Licensee Consent to Establish Details Rejected successfully";
                    }
                    else
                    {
                        TempData["Message"] = "Error ! while Rejecting Licensee Consent to Establish";
                    }
                }

                //return RedirectToAction("CompareCTEDetails", "UserInformationLiensee", new { Area = "Licensee" });
                string EncryptUrl = CustomQueryStringHelper.EncryptString("Licensee", "CompareCTEDetails", "UserInformationLiensee", new { id = cTEDetails.CREATED_BY });
                return LocalRedirect(EncryptUrl);
            }
            catch (Exception)
            {
                throw;
            }
            //finally { cTEDetails = null; objMSmodel = null;  }
        }
        /// <summary>
        /// To Bind View and Log of CTE Details 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ViewCTEDetails()
        {
            CTEDetails model = new CTEDetails();
            try
            {
                UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                model.CREATED_BY = session.UserId;
                LicenseeResult listobj = await _userInformation.GetLicenseeCTEDetail(model);
                if (listobj.CTEDetailsLst !=null)
                {
                    ViewBag.tableLA = await CTETable(model.CREATED_BY);
                    return View(listobj.CTEDetailsLst.FirstOrDefault());
                }
                else
                {
                    return View(new CTEDetails());
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                model = null;
            }
        }
        /// <summary>
        /// To bind CTE Log Details in view
        /// </summary>
        /// <param name = "Created_By" ></ param >
        /// < returns ></ returns >
        public async Task<string> CTETable(int? Created_By)
        {
            string div = "";
            CTEDetails objmodel = new CTEDetails();
            objmodel.CREATED_BY = Created_By;
            objCTEList = await _userInformation.GetCTELogDetails(objmodel);
            foreach (var item in objCTEList)
            {
                div += "<li class='timeline-item'>";
                div += "<div class='date-box'>";
                div += "<p><span class='date'>" + item.ModifyDate + "</span><span class='month-year'>" + item.ModifyYear + "</span></p>";
                div += "</div>";
                if (item.STATUS == 2)
                {
                    div = div + "<div class='message-highlighter approved'>";
                }
                else
                {
                    div = div + "<div class='message-highlighter draft'>";
                }
                div += "<div class='row'>";
                div += "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>CTE Approval Number</label>";
                div += "<div class='col-lg-4 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.CTE_ORDER_NO + "</label>";
                div += "</div>";
                div += "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>Consent To Establish Order Date</label>";
                div += "<div class='col-lg-4 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.CTE_ORDER_DATE + "</label>";
                div += "</div>";
                div += "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>CTE Valid From</label>";
                div += "<div class='col-lg-4 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.CTE_VALID_FROM + "</label>";
                div += "</div>";
                div += "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>CTE Valid To</label>";
                div += "<div class='col-lg-4 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.CTE_VALID_TO + "</label>";
                div += "</div>";
                div += "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>CTE Letter</label>";
                div += "<div class='col-lg-4 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.FILE_CTE_LETTER + "";
                if (item.FILE_CTE_LETTER != null && item.FILE_CTE_LETTER != "")
                {
                    div = div + "<a href='" + @Url.Content("~/" + item.CTE_LETTER_PATH) + "' class='ml-2' data-original-title='Download CTE Letter' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                }
                div += "</div>";
                div += "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>Remarks</label>";
                div += "<div class='col-lg-4 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.Remarks + "</label>";
                div += "</div>";
                div += "</div>";
                div += "</div>";
                div += "</li>";
            }
            return div;
        }
        #endregion
        #region DSC   
        /// <summary>
        /// Digital Signature
        /// </summary>
        /// <param name="contentType"></param>
        /// <param name="signDataBase64Encoded"></param>
        /// <param name="responseType"></param>
        /// <returns></returns>
        public string CheckVerifyResponse(string contentType, string signDataBase64Encoded, string responseType)
        {
            try
            {
                if (signDataBase64Encoded.Contains("signing canceled"))
                {
                    OutputResult = "";
                }
                else
                {
                    signDataBase64Encoded = signDataBase64Encoded.Replace("IssuerCommonName", " Issuer");
                    signDataBase64Encoded = signDataBase64Encoded.Replace("CommonName", " CommonName").Replace("SerialNo", " SerialNo").Replace("IssuedDate", " IssuedDate").Replace("ExpiryDate", " ExpiryDate").Replace("Email", " Email").Replace("Country", " Country").Replace("CertificateClass", " CertificateClass").Replace("\r\n", "");
                    string[] tokens = signDataBase64Encoded.Split(new[] { " " }, StringSplitOptions.None);
                    string strSign = GetDSCRespnseData(tokens);
                    TempData["DSCResponse"] = signDataBase64Encoded;
                    TempData["Base64Data"] = strSign;
                    OutputResult = "SUCCESS";
                }
            }
            catch
            {
            }
            return OutputResult.ToUpper();
        }
        public string GetDSCRespnseData(string[] parameters)
        {
            string strSign = string.Empty;
            string[] strGetMerchantParamForCompare;
            for (int i = 0; i < parameters.Length; i++)
            {
                strGetMerchantParamForCompare = parameters[i].ToString().Split('=');
                if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "SIGNATURE")
                {
                    Signature = Convert.ToString(strGetMerchantParamForCompare[1]);
                    break;
                }
            }
            strSign = Signature;
            return strSign;
        }
        #endregion
    }
}
