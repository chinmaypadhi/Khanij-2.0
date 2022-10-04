// ***********************************************************************
//  Controller Name          : CTODetail
//  Desciption               : Liecensee Consent To Operate Details 
//  Created By               : Prakash Chandra Biswal
//  Created On               : 25 June 2021
// ***********************************************************************
using MasterApp.Areas.Licensee.Models;
using MasterEF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MasterApp.Web;
using MasterApp.ActionFilter;

namespace MasterApp.Areas.Licensee.Controllers
{
    [Area("Licensee")]
    public class CTODetailController : Controller
    {
        #region Global Variables
        /// <summary>
        /// Global Variable Declaration
        /// </summary>
        IUserInformationLicenseeModel _userInformation;
        MessageEF objMSmodel = new MessageEF();
        List<CTODetails> objlistmodel = new List<CTODetails>();
        public object JsonRequestBehavior { get; private set; }
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        string uniqueFileName = string.Empty;
        string filePath = string.Empty;
        string ExtensionId = string.Empty;
        #endregion

        public CTODetailController(IUserInformationLicenseeModel objUserInformation, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _userInformation = objUserInformation;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }
        /// <summary>
        /// To Bind CTO Details of Licensee in View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            CTODetails model = new CTODetails();
            try
            {
                UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                LicenseeResult licenseeResult = new LicenseeResult();
                if (session.UserId != 0)
                {
                    model.UserLoginId = session.UserLoginId.ToString();
                    model.UserID = session.UserId;
                    model.CREATED_BY = session.UserId;
                    licenseeResult = await _userInformation.GetLicenseeCTODetail(model);
                    if (licenseeResult.CTODetailsLst != null)
                    {
                        return View(licenseeResult.CTODetailsLst.FirstOrDefault());
                    }
                    else
                        return View(new CTODetails());
                }
                else
                {
                    return View(new CTODetails());
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
        /// To Add, Update, Forward adn d IBM Details of Licensee
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cmd"></param>
        /// <param name="approve"></param>
        /// <param name="reject"></param>
        /// <param name="id"></param>
        /// <param name="selectedFile"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(CTODetails model, string cmd, IFormFile selectedFile)
        {
            try
            {
                UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                var DD_DMO = "Forward To DD";

                if (model.SubResion == "Forward To DD")
                {
                    cmd= "Forward To DD";
                }

                #region for Validation
                if (string.IsNullOrEmpty(model.CTO_ORDER_NO))
                {
                    ModelState.AddModelError("CTO_ORDER_NO", "CTO Order Number is required");
                }
                if (string.IsNullOrEmpty(model.CTO_ORDER_DATE))
                {
                    ModelState.AddModelError("CTO_ORDER_DATE", "CTO Order Date is required");
                }
                if (string.IsNullOrEmpty(model.CTO_ORDER_DATE))
                {
                    ModelState.AddModelError("CTO_VALID_FROM", "CTO Valid To Date is required");
                }
                if (string.IsNullOrEmpty(model.CTO_ORDER_DATE))
                {
                    ModelState.AddModelError("CTO_VALID_TO", "CTO Valid To Date is required");
                }
                #endregion
                if (ModelState.IsValid)
                {

                    #region Upload File 

                    if (selectedFile != null && selectedFile.Length > 0)
                    {

                        if (!string.IsNullOrEmpty(selectedFile.FileName))
                        {
                            string hosting = _hostingEnvironment.ContentRootPath;
                            string wwwPath = this._hostingEnvironment.WebRootPath;
                            string strName = DateTime.Now.Date.Day.ToString() + DateTime.Now.Date.Month.ToString() + DateTime.Now.Date.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var fileName = strName + "_" + selectedFile.FileName;
                            filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("CTOPath"), fileName);
                            var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("CTOPath"));
                            string UploadFolderPath = Path.Combine(RootPath, fileName);
                            if (!Directory.Exists(RootPath))
                                Directory.CreateDirectory(RootPath);
                            DirectoryInfo di = new DirectoryInfo(RootPath);
                            di.Attributes = FileAttributes.Normal;
                            using (var stream = new FileStream(UploadFolderPath, FileMode.Create))
                            {
                                selectedFile.CopyTo(stream);
                            }
                            model.CTO_LETTER_PATH = filePath;
                            model.FILE_CTO_LETTER = fileName;
                        }

                    }
                    #endregion
                    if (model.CTO_ID == 0)
                    {
                        if (cmd == DD_DMO)
                        {
                            model.STATUS = 1;
                            model.UserID = Convert.ToInt32(session.UserId);
                            model.CREATED_BY = Convert.ToInt32(session.UserId);
                            model.UserLoginId = session.UserLoginId.ToString();
                            objMSmodel = _userInformation.UpdateLicenseeCTODetail(model);
                            if (objMSmodel.Satus == "1")
                            {
                                TempData["Message"] = "CTO Details forwarded to DD/DMO successfully";
                            }
                            else
                            {
                                TempData["Message"] = "Error ! while forwarding CTO Details to DD/DMO";
                            }
                            return RedirectToAction("Create");
                        }
                        else
                        {
                            model.STATUS = 0;
                            model.UserID = Convert.ToInt32(session.UserId);
                            model.CREATED_BY = Convert.ToInt32(session.UserId);
                            model.UserLoginId = session.UserLoginId.ToString();
                            objMSmodel = _userInformation.NewLicenseeCTODetail(model);
                            if (objMSmodel.Satus == "1")
                            {
                                TempData["Message"] = "CTO Details Saved Successfully";
                            }
                            else
                            {
                                TempData["Message"] = "Error ! while Saving CTO Details";
                            }
                            return RedirectToAction("Create", new { Areas = "Licensee" });
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
                            objMSmodel = _userInformation.UpdateLicenseeCTODetail(model);
                            if (objMSmodel.Satus == "1")
                            {
                                TempData["Message"] = "CTO Details forwarded to DD/DMO successfully";
                            }
                            else
                            {
                                TempData["Message"] = "Error ! while forwarding CTO Details to DD/DMO";
                            }

                            return RedirectToAction("Create");
                        }
                        else if (cmd == "Delete")
                        {
                            model.UserID = Convert.ToInt32(session.UserId);
                            model.CREATED_BY = Convert.ToInt32(session.UserId);
                            model.UserLoginId = session.UserLoginId.ToString();
                            objMSmodel = _userInformation.DeleteCTODetail(model);
                            if (objMSmodel.Satus == "1")
                            {
                                TempData["Message"] = "CTO Details Deleted Successfully";
                            }
                            else
                            {
                                TempData["Message"] = "Error ! while Deleting CTO Details";
                            }
                            return RedirectToAction("Create");
                        }
                        else
                        {
                            model.STATUS = 0;
                            model.UserID = Convert.ToInt32(session.UserId);
                            model.CREATED_BY = Convert.ToInt32(session.UserId);
                            model.UserLoginId = session.UserLoginId.ToString();
                            objMSmodel = _userInformation.UpdateLicenseeCTODetail(model);
                            if (objMSmodel.Satus == "1")
                            {
                                TempData["Message"] = "CTO Details Updated Successfully";
                            }
                            else
                            {
                                TempData["Message"] = "Error ! while Updating CTO Details";
                            }
                            return RedirectToAction("Create", new { area = "Licensee" });
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
        /// TO Bind View and Log Details of CTO Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> ViewList()
        {
            UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            CTODetails objmodel = new CTODetails();
            try
            {
                objmodel.UserID = session.UserId;
                objmodel.CREATED_BY = session.UserId;
                objmodel.UserLoginId = session.UserLoginId.ToString();
                LicenseeResult listobj = await _userInformation.GetLicenseeCTODetail(objmodel);
                if (listobj.CTODetailsLst != null)
                {
                    ViewBag.tableLA = await CTOTable(objmodel.CREATED_BY);
                    return View(listobj.CTODetailsLst.FirstOrDefault());
                }
                else
                {
                    return View(new CTODetails());
                }
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
        /// To Bind CTO Log Details of Licensee
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public async Task<string> CTOTable(int? Created_By)
        {
            string div = "";
            CTODetails objmodel = new CTODetails();
            objmodel.CREATED_BY = Created_By;
            objlistmodel = await _userInformation.GetCTOLogDetails(objmodel);
            foreach (var item in objlistmodel)
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
                div += "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>Approval Number</label>";
                div += "<div class='col-lg-4 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.CTO_ORDER_NO + "</label>";
                div += "</div>";
                div += "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>Order Date</label>";
                div += "<div class='col-lg-4 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.CTO_ORDER_DATE + "</label>";
                div += "</div>";
                div += "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>Valid From</label>";
                div += "<div class='col-lg-4 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.CTO_VALID_FROM + "</label>";
                div += "</div>";
                div += "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>Valid To</label>";
                div += "<div class='col-lg-4 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.CTO_VALID_TO + "</label>";
                div += "</div>";
                div += "<label class='col-lg-2 col-md-4 col-sm-12 col-form-label'>Letter</label>";
                div += "<div class='col-lg-4 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.FILE_CTO_LETTER + "";
                if (item.FILE_CTO_LETTER != null && item.FILE_CTO_LETTER != "")
                {
                    div = div + "<a href='" + @Url.Content("~/" + item.CTO_LETTER_PATH) + "' class='ml-2' data-original-title='Download CTO Letter' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
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
        /// <summary>
        /// To Compare CTE Details of Licenee
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Decryption]
        public IActionResult Compare(string id = "0")
        {
            CTODetails obj = new CTODetails();
            try
            {
                if (!string.IsNullOrEmpty(id) && id != "0")
                {
                    UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                    obj.UserID = Convert.ToInt32(id);
                    obj.CREATED_BY = Convert.ToInt32(id);
                    List<CTODetails> listobj = _userInformation.CompareCTODetails(obj);
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
        /// TO Approve and Reject of CTE Details of Licensee
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Compare(CTODetails cTODetails)
        {
            UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            cTODetails.UserLoginId = session.UserLoginId.ToString();
            if (cTODetails.SubApprove == "Approve")
            {
                cTODetails.UserID = session.UserId;

                objMSmodel = _userInformation.ApproveLicenseeCTODetails(cTODetails);
                if (objMSmodel.Satus == "1")
                {
                    TempData["Message"] = "Licensee CTO Details Approved successfully";
                }
                else
                {
                    TempData["Message"] = "Error ! while Approving Licensee CTO Details";
                }
            }
            else if (cTODetails.SubReject == "Reject")
            {
                cTODetails.UserID = Convert.ToInt32(cTODetails.CREATED_BY);
                objMSmodel = _userInformation.RejectLicenseeCTODetails(cTODetails);
                if (objMSmodel.Satus == "1")
                {
                    TempData["Message"] = "CTO Details Rejected successfully";
                }
                else
                {
                    TempData["Message"] = "Error ! while Rejecting Licensee CTO Details";
                }
            }
            //return RedirectToAction("Compare", "CTODetail", new { Area = "Licensee" });
            string EncryptUrl = CustomQueryStringHelper.EncryptString("Licensee", "Compare", "CTODetail", new { id = cTODetails.CREATED_BY });
            return LocalRedirect(EncryptUrl);
        }
    }
}
