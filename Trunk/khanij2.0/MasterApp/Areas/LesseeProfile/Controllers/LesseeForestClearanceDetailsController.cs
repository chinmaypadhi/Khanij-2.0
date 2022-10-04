// ***********************************************************************
//  Controller Name          : LesseeForestClearanceDetailsController
//  Description              : Lessee Forest Clearance View Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 27 July 2021
// ***********************************************************************
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.Areas.LesseeProfile.Models.ForestClearanceDetails;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MasterApp.Web;
using MasterApp.ActionFilter;

namespace MasterApp.Areas.LesseeProfile.Controllers
{ 
    [Area("LesseeProfile")]
    public class LesseeForestClearanceDetailsController : Controller
    {
        /// <summary>
        /// Global Variable,object declaration
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        ILesseeForestClearanceModel _objILesseeForestClearanceModel;
        LesseeForestClearanceViewModel objmodel = new LesseeForestClearanceViewModel();
        List<LesseeForestClearanceViewModel> objlistmodel = new List<LesseeForestClearanceViewModel>();
        MessageEF objobjmodel = new MessageEF();
        string uniqueFileName = string.Empty;
        string filePath = string.Empty;
        string ExtensionId = string.Empty;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objLesseeDetailsModel"></param>
        public LesseeForestClearanceDetailsController(ILesseeForestClearanceModel objILesseeForestClearanceModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _objILesseeForestClearanceModel = objILesseeForestClearanceModel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }
        /// <summary>
        /// HTTP GET method of Create Forest Clearance
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
                objmodel = await _objILesseeForestClearanceModel.GetForestClearanceDetails(objmodel);
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
        public async Task<IActionResult> Create(LesseeForestClearanceViewModel objmodel, string cmd, string delete)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.CREATED_BY = profile.UserId;
            objmodel.UserLoginId = profile.UserLoginId;
            ExtensionId = Convert.ToString(objmodel.CREATED_BY);
            try
            {
                #region Validation
                if (string.IsNullOrEmpty(objmodel.FC_APPROVAL_NUMBER))
                {
                    ModelState.AddModelError("FC_APPROVAL_NUMBER", "Approval Number field is required");
                }
                if (string.IsNullOrEmpty(objmodel.FC_APPROVAL_DATE))
                {
                    ModelState.AddModelError("FC_APPROVAL_DATE", "Order date field is required");
                }
                #endregion
                if (ModelState.IsValid)
                {
                    #region File Upload
                    if (objmodel.FC_LETTER != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.FC_LETTER.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadForestClearancePath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadForestClearancePath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.FC_LETTER.CopyTo(fileStream);
                        objmodel.FC_LETTER_FILE_NAME = uniqueFileName;
                        objmodel.FC_LETTER_FILE_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    objmodel.FC_LETTER = null;
                    #endregion
                    var checkDMO = "Forward To DD";
                    if (objmodel.SubResion == "Forward To DD")
                    {
                        cmd = "Forward To DD";
                    }
                    if (checkDMO == cmd)
                    {
                        objmodel.STATUS = 1;
                        objobjmodel = _objILesseeForestClearanceModel.UpdateForestClearanceDetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Lessee Forest Clearance Details forwarded to DD/DMO successfully";
                        }
                        else if (objobjmodel.Satus == "2")
                        {
                            TempData["Message"] = "Lessee Forest Clearance Details forwarded to DD/DMO successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while forwarding Lessee Forest Clearance Details to DD/DMO";
                        }
                    }
                    else if (delete == "Delete")
                    {
                        objobjmodel = _objILesseeForestClearanceModel.DeleteLesseeForestClearanceDetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Lessee Forest Clearance Details Deleted Sucessfully.";
                        }
                        else
                        {
                            TempData["Message"] = "Lessee Forest Clearance Details not Deleted Sucessfully.";
                        }
                    }
                    else
                    {
                        objmodel.STATUS = 0;
                        objobjmodel = _objILesseeForestClearanceModel.UpdateForestClearanceDetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Lessee Forest Clearance Details Saved successfully";
                        }
                        else if (objobjmodel.Satus == "2")
                        {
                            TempData["Message"] = "Lessee Forest Clearance  Details Updated successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while Updating Lessee Forest Clearance Details";
                        }

                    }
                    return RedirectToAction("Create", "LesseeForestClearanceDetails", new { Area = "LesseeProfile" });
                }
                else
                {
                    objmodel = await _objILesseeForestClearanceModel.GetForestClearanceDetails(objmodel);
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
                objmodel = await _objILesseeForestClearanceModel.GetForestClearanceDetails(objmodel);
                ViewBag.tableLA = await ForestClearanceTable(objmodel.CREATED_BY);
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
        /// To bind Forest Clearance Log Details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public async Task<string> ForestClearanceTable(int? Created_By)
        {
            string div = "";
            objmodel.CREATED_BY = Created_By;
            objlistmodel = await _objILesseeForestClearanceModel.GetForestClearanceLogDetails(objmodel);
            foreach (var item in objlistmodel)
            {
                div+= "<li class='timeline-item'>";
                div+= "<div class='date-box'>";
                div+= "<p><span class='date'>" + item.ModifyDate + "</span><span class='month-year'>" + item.ModifyYear + "</span></p>";
                div+= "</div>";
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

                div += "<div class='row'>";
                div+= "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Approval Number</label>";
                div+= "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div+= "<span class='colon'>:</span>" + item.FC_APPROVAL_NUMBER + "</label>";
                div+= "</div>";
                div+= "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Order Date</label>";
                div+= "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div+= "<span class='colon'>:</span>" + item.FC_APPROVAL_DATE + "</label>";
                div+= "</div>";
                div+= "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Valid From</label>";
                div+= "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div+= "<span class='colon'>:</span>" + item.VALID_FROM + "</label>";
                div+= "</div>";
                div+= "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Valid To</label>";
                div+= "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div+= "<span class='colon'>:</span>" + item.VALID_TO + "</label>";
                div+= "</div>";
                div+= "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Approval Letter</label>";
                div+= "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div+= "<span class='colon'>:</span>" + item.FC_LETTER_FILE_NAME + "";
                if (item.FC_LETTER_FILE_NAME != null && item.FC_LETTER_FILE_NAME != "")
                {
                    div = div + "<a href='" + @Url.Content("~/" + item.FC_LETTER_FILE_PATH) + "' class='ml-2' data-original-title='Download Approval Letter' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                }
                div+= "</div>";
                div+= "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Remarks</label>";
                div+= "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div+= "<span class='colon'>:</span>" + item.Remarks + "</label>";
                div+= "</div>";
                div+= "</div>";
                div+= "</div>";
                div+= "</li>";
            }
            return div;
        }
        /// <summary>
        /// To Compare Lessee Forest Clearance Request Data in view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public async Task<IActionResult> Compare(string id="0")
        {
            try
            {
                objmodel.CREATED_BY = Convert.ToInt32(id);
                objlistmodel = await _objILesseeForestClearanceModel.GetForestClearanceCompareDetails(objmodel);
                if (objlistmodel.Count == 2)
                    return View(objlistmodel);
                else
                    return View();
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
        /// To Approve,Reject Lessee Forest Clearance Profile Request Data in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Compare(LesseeForestClearanceViewModel objmodel)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserLoginId = profile.UserLoginId;
                if (objmodel.SubApprove == "Approve")
                {
                    objobjmodel = _objILesseeForestClearanceModel.ApproveLesseeForestClearanceDetails(objmodel);
                }
                else
                {
                    objobjmodel = _objILesseeForestClearanceModel.RejectLesseeForestClearanceDetails(objmodel);
                }
                if (objobjmodel.Satus == "1")
                {
                    TempData["Message"] = "Lessee Forest Clearance Details Approved successfully";
                }
                else if (objobjmodel.Satus == "2")
                {
                    TempData["Message"] = "Lessee Forest Clearance Details Rejected successfully";
                }
                else
                {
                    TempData["Message"] = "Error ! while " + objmodel.SubApprove + " Lessee Forest Clearance Details";
                }
                string EncryptUrl = CustomQueryStringHelper.EncryptString("LesseeProfile", "Compare", "LesseeForestClearanceDetails", new { id = objmodel.CREATED_BY });
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
