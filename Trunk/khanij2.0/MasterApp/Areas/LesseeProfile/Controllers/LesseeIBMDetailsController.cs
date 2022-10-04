// ***********************************************************************
//  Controller Name          : LesseeIBMDetailsController
//  Description              : Lessee IBM View Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 26 July 2021
// ***********************************************************************
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.Areas.LesseeProfile.Models.IBMDetails;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MasterApp.Web;
using MasterApp.ActionFilter;

namespace MasterApp.Areas.LesseeProfile.Controllers
{
    [Area("LesseeProfile")]
    public class LesseeIBMDetailsController : Controller
    {
        /// <summary>
        /// Global Variable,object declaration
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        ILesseeIBMModelDetails _objILesseeIBMModelDetails;
        LesseeIBMDetailsViewModel objmodel = new LesseeIBMDetailsViewModel();
        List<LesseeIBMDetailsViewModel> objlistmodel = new List<LesseeIBMDetailsViewModel>();
        MessageEF objobjmodel = new MessageEF();
        string uniqueFileName = string.Empty;
        string filePath = string.Empty;
        string ExtensionId = string.Empty;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objLesseeDetailsModel"></param>
        public LesseeIBMDetailsController(ILesseeIBMModelDetails objILesseeIBMModelDetails, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _objILesseeIBMModelDetails = objILesseeIBMModelDetails;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }
        /// <summary>
        /// HTTP GET method of Create IBM
        /// </summary>
        /// <returns></returns>
        [Decryption]
        public async Task<IActionResult> Create(string id="0")
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                if (id == "0")
                {
                    objmodel.CREATED_BY = profile.UserId;
                }
                else
                {
                    objmodel.CREATED_BY = Convert.ToInt32(id);
                }
                objmodel = await _objILesseeIBMModelDetails.GetIBMDetails(objmodel);
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
        /// HTTP Post method of Create
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="cmd"></param>
        /// <param name="delete"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Create(LesseeIBMDetailsViewModel objmodel, string cmd,string delete)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.CREATED_BY = profile.UserId;
            objmodel.UserLoginId = profile.UserLoginId;
            ExtensionId = Convert.ToString(objmodel.CREATED_BY);
            try
            {
                #region Validation
                if (string.IsNullOrEmpty(objmodel.IBM_NUMBER))
                {
                    ModelState.AddModelError("IBM_NUMBER", "IBM Mine Code field is required");
                }
                if (string.IsNullOrEmpty(objmodel.IBM_REGISTRATION_NUMBER))
                {
                    ModelState.AddModelError("IBM_REGISTRATION_NUMBER", "IBM Registration Number field is required");
                }
                if (string.IsNullOrEmpty(objmodel.IBM_APPLICATON_DATE))
                {
                    ModelState.AddModelError("IBM_APPLICATON_DATE", "IBM Registration Date field is required");
                }
                #endregion
                if (ModelState.IsValid)
                {
                    #region File Upload
                    if (objmodel.IBM_REGISTRATION_FORM != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.IBM_REGISTRATION_FORM.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadIBMPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadIBMPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.IBM_REGISTRATION_FORM.CopyTo(fileStream);
                        objmodel.FILE_IBM_REGISTRATION_FORM = uniqueFileName;
                        objmodel.IBM_REGISTRATION_FORM_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    objmodel.IBM_REGISTRATION_FORM = null;
                    #endregion
                    var checkDMO = "Forward To DD";
                    if (objmodel.SubResion == "Forward To DD")
                    {
                        cmd = "Forward To DD";
                    }
                    if (checkDMO == cmd)
                    {
                        objmodel.STATUS = 1;
                        objobjmodel = _objILesseeIBMModelDetails.UpdateIBMDetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Lessee IBM Details forwarded to DD/DMO successfully";
                        }
                        else if (objobjmodel.Satus == "2")
                        {
                            TempData["Message"] = "Lessee IBM Details forwarded to DD/DMO successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while forwarding Lessee IBM Details to DD/DMO";
                        }
                    }
                    else if (delete == "Delete")
                    {
                        objobjmodel = _objILesseeIBMModelDetails.DeleteLesseeIBMDetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Lessee IBM Details Deleted Sucessfully.";
                        }
                        else
                        {
                            TempData["Message"] = "Lessee IBM Details not Deleted Sucessfully.";
                        }
                    }
                    else
                    {
                        objmodel.STATUS = 0;
                        objobjmodel = _objILesseeIBMModelDetails.UpdateIBMDetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Lessee IBM Details Saved successfully";
                        }
                        else if (objobjmodel.Satus == "2")
                        {
                            TempData["Message"] = "Lessee IBM  Details Updated successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while Updating Lessee IBM Details";
                        }

                    }
                    return RedirectToAction("Create", "LesseeIBMDetails", new { Area = "LesseeProfile" });
                }
                else
                {
                    objmodel = await _objILesseeIBMModelDetails.GetIBMDetails(objmodel);
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
        /// HTTP GET method of ViewList
        /// </summary>
        /// <returns></returns>
        [Decryption]
        public async Task<IActionResult> ViewList(string UserId)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                if (!string.IsNullOrEmpty(Convert.ToString(UserId))) //For Other than Lessee User Login
                {
                    objmodel.CREATED_BY = Convert.ToInt32(UserId);
                }
                else
                {
                    objmodel.CREATED_BY = profile.UserId;
                }
                objmodel = await _objILesseeIBMModelDetails.GetIBMDetails(objmodel);
                ViewBag.tableLA = await IBMTable(objmodel.CREATED_BY);
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
        /// To bind IBM Log Details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public async Task<string> IBMTable(int? Created_By)
        {
            string div = "";
            objmodel.CREATED_BY = Created_By;
            objlistmodel = await _objILesseeIBMModelDetails.GetIBMLogDetails(objmodel);
            foreach (var item in objlistmodel)
            {
                div = div + "<li class='timeline-item'>";
                div = div + "<div class='date-box'>";
                div = div + "<p><span class='date'>" + item.ModifyDate + "</span><span class='month-year'>" + item.ModifyYear + "</span></p>";
                div = div + "</div>";
                if (item.STATUS == 2) //Approved
                {
                    div = div + "<div class='message-highlighter approved'>";
                }
                else if (item.STATUS == 1) //Forwarded
                {
                    div = div + "<div class='message-highlighter forwarded'>";
                }
                else if (item.STATUS == 3) //Rejected
                {
                    div = div + "<div class='message-highlighter rejected'>";
                }
                else //Draft
                {
                    div = div + "<div class='message-highlighter draft'>";
                }

                div = div + "<div class='row'>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>IBM Mine Code</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.IBM_NUMBER + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>IBM Registration Number</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.IBM_REGISTRATION_NUMBER + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>IBM Registration Date</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.IBM_APPLICATON_DATE + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Registration Form</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.FILE_IBM_REGISTRATION_FORM + "";
                if (item.FILE_IBM_REGISTRATION_FORM != null && item.FILE_IBM_REGISTRATION_FORM != "")
                {
                    div = div + "<a href='" + @Url.Content("~/" + item.IBM_REGISTRATION_FORM_PATH) + "' class='ml-2' data-original-title='Download Registration Form' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                }
                div += "</div>";
                div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Remarks</label>";
                div += "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.Remarks + "</label>";
                div = div + "</div>";
                div = div + "</div>";
                div = div + "</div>";
                div = div + "</li>";
            }
            return div;
        }
        /// <summary>
        /// To Compare Lessee IBM Request Data in view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public async Task<IActionResult> Compare(string id="0")
        {
            try
            {
                objmodel.CREATED_BY = Convert.ToInt32(id);
                objlistmodel = await _objILesseeIBMModelDetails.GetIBMCompareDetails(objmodel);
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
        /// To Approve,Reject Lessee IBM Profile Request Data in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Compare(LesseeIBMDetailsViewModel objmodel)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserLoginId = profile.UserLoginId;
                if (objmodel.SubApprove == "Approve")
                {
                    objobjmodel = _objILesseeIBMModelDetails.ApproveLesseeIBMDetails(objmodel);
                }
                else
                {
                    objobjmodel = _objILesseeIBMModelDetails.RejectLesseeIBMDetails(objmodel);
                }
                if (objobjmodel.Satus == "1")
                {
                    TempData["Message"] = "Lessee IBM Details Approved successfully";
                }
                else if (objobjmodel.Satus == "2")
                {
                    TempData["Message"] = "Lessee IBM Details Rejected successfully";
                }
                else
                {
                    TempData["Message"] = "Error ! while " + objmodel.SubApprove + " Lessee IBM Details";
                }
                string EncryptUrl = CustomQueryStringHelper.EncryptString("LesseeProfile", "Compare", "LesseeIBMDetails", new { id = objmodel.CREATED_BY });
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
    }
}
