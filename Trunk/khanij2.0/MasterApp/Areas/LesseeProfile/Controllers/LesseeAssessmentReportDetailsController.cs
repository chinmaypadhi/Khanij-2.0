// ***********************************************************************
//  Controller Name          : LesseeAssessmentDetailsController
//  Description              : Lessee Assessment Report View Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 29 July 2021
// ***********************************************************************
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.Areas.LesseeProfile.Models.AssessmentReportDetails;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MasterApp.Web;
using MasterApp.ActionFilter;

namespace MasterApp.Areas.LesseeProfile.Controllers
{
    [Area("LesseeProfile")]
    public class LesseeAssessmentReportDetailsController : Controller
    {
        /// <summary>
        /// Global Variable,object declaration
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        ILesseeAssessmentReportModel _objILesseeAssessmentReportModel;
        LesseeAssessmentReportViewModel objmodel = new LesseeAssessmentReportViewModel();
        List<LesseeAssessmentReportViewModel> objlistmodel = new List<LesseeAssessmentReportViewModel>();
        MessageEF objobjmodel = new MessageEF();
        string uniqueFileName = string.Empty;
        string filePath = string.Empty;
        string ExtensionId = string.Empty;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objLesseeDetailsModel"></param>
        public LesseeAssessmentReportDetailsController(ILesseeAssessmentReportModel objILesseeAssessmentReportModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _objILesseeAssessmentReportModel = objILesseeAssessmentReportModel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }
        /// <summary>
        /// HTTP GET method of Create Assessment Report
        /// </summary>
        /// <returns></returns>
        [Decryption]
        public async Task<IActionResult> Create(string id = "0")
        {
            try
            {
                UserLoginSession profile =HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                if (id == "0")
                {
                    objmodel.CREATED_BY = profile.UserId;
                }
                else
                {
                    objmodel.CREATED_BY = Convert.ToInt32(id);
                }
                objmodel = await _objILesseeAssessmentReportModel.GetAssessmentReportDetails(objmodel);
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
        public async Task<IActionResult> Create(LesseeAssessmentReportViewModel objmodel, string cmd, string delete)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.CREATED_BY = profile.UserId;
            objmodel.UserLoginId = profile.UserLoginId;
            ExtensionId = Convert.ToString(objmodel.CREATED_BY);
            objmodel.Assessmentdate = profile.MineralTypeName == "Minor Mineral" ? null : objmodel.Assessmentdate;
            try
            {
                #region Validation
                if (profile.MineralTypeName != "Minor Mineral" && string.IsNullOrEmpty(objmodel.Assessmentdate))
                {
                    ModelState.AddModelError("Assessmentdate", "Revenue Recovery Date field is required");
                }
                if (profile.MineralTypeName != "Minor Mineral" && objmodel.RecoveryReportFileName == null || objmodel.RecoveryReportFileName == "")
                {
                    if (objmodel.RecoveryHttpBase == null)
                    {
                        ModelState.AddModelError("RecoveryHttpBase", "Upload Revenue Recovery Copy");
                    }
                }
                if (string.IsNullOrEmpty(objmodel.HalfYearAssesmentDate))
                {
                    ModelState.AddModelError("HalfYearAssesmentDate", "Half Yearly Date field is required");
                }
                if (objmodel.HalfyearassesmentFileName == null || objmodel.HalfyearassesmentFileName == "")
                {
                    if (objmodel.HalfYearHttpBase == null)
                    {
                        ModelState.AddModelError("HalfYearHttpBase", "Upload Half Yearly Copy");
                    }
                }
                #endregion
                if (ModelState.IsValid)
                {
                    #region File Upload
                    if (objmodel.RecoveryHttpBase != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.RecoveryHttpBase.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadAssessmentReportPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadAssessmentReportPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.RecoveryHttpBase.CopyTo(fileStream);
                        objmodel.RecoveryReportFileName = uniqueFileName;
                        objmodel.RecoveryReportFilePath = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.HalfYearHttpBase != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.HalfYearHttpBase.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadAssessmentReportPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadAssessmentReportPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.HalfYearHttpBase.CopyTo(fileStream);
                        objmodel.HalfyearassesmentFileName = uniqueFileName;
                        objmodel.HalfyearassesmentFilePath = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    objmodel.RecoveryHttpBase = null;
                    objmodel.HalfYearHttpBase = null;
                    #endregion
                    var checkDMO = "Forward To DD";
                    if (objmodel.SubResion == "Forward To DD")
                    {
                        cmd = "Forward To DD";
                    }
                    if (checkDMO == cmd)
                    {
                        objmodel.Status = 1;
                        objobjmodel = _objILesseeAssessmentReportModel.UpdateAssessmentReportDetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Lessee Assessment Report Details forwarded to DD/DMO successfully";
                        }
                        else if (objobjmodel.Satus == "2")
                        {
                            TempData["Message"] = "Lessee Assessment Report Details forwarded to DD/DMO successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while forwarding Lessee Assessment Report Details to DD/DMO";
                        }
                    }
                    else if (delete == "Delete")
                    {
                        objobjmodel = _objILesseeAssessmentReportModel.DeleteLesseeAssessmentReportDetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Lessee Assessment Report Details Deleted Sucessfully.";
                        }
                        else
                        {
                            TempData["Message"] = "Lessee Assessment Report Details not Deleted Sucessfully.";
                        }
                    }
                    else
                    {
                        objmodel.Status = 0;
                        objobjmodel = _objILesseeAssessmentReportModel.UpdateAssessmentReportDetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Lessee Assessment Report Details Saved successfully";
                        }
                        else if (objobjmodel.Satus == "2")
                        {
                            TempData["Message"] = "Lessee Assessment Report  Details Updated successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while Updating Lessee Assessment Report Details";
                        }

                    }
                    return RedirectToAction("Create", "LesseeAssessmentReportDetails", new { Area = "LesseeProfile" });
                }
                else
                {
                    objmodel = await _objILesseeAssessmentReportModel.GetAssessmentReportDetails(objmodel);
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
                objmodel = await _objILesseeAssessmentReportModel.GetAssessmentReportDetails(objmodel);
                ViewBag.tableLA = await AssessmentReportTable(objmodel.CREATED_BY);
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
        /// To bind Assessment Report Log Details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public async Task<string> AssessmentReportTable(int? Created_By)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            string div = "";
            objmodel.CREATED_BY = Created_By;
            objlistmodel = await _objILesseeAssessmentReportModel.GetAssessmentReportLogDetails(objmodel);
            foreach (var item in objlistmodel)
            {
                div += "<li class='timeline-item'>";
                div += "<div class='date-box'>";
                div += "<p><span class='date'>" + item.ModifyDate + "</span><span class='month-year'>" + item.ModifyYear + "</span></p>";
                div += "</div>";
                if (item.Status == 2) //Approved
                {
                    div = div + "<div class='message-highlighter approved'>";
                }
                else if (item.Status == 1) //Forwarded
                {
                    div = div + "<div class='message-highlighter forwarded'>";
                }
                else if (item.Status == 3) //Rejected
                {
                    div = div + "<div class='message-highlighter rejected'>";
                }
                else //Draft
                {
                    div = div + "<div class='message-highlighter draft'>";
                }

                div += "<div class='row'>";
                if (profile.MineralTypeName != "Minor Mineral")
                {
                    div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Date of Revenue Recovery Assessment</label>";
                    div += "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div += "<span class='colon'>:</span>" + item.Assessmentdate + "</label>";
                    div += "</div>";
                    div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Copy of Revenue Recovery Assessment</label>";
                    div += "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div += "<span class='colon'>:</span>" + item.RecoveryReportFileName + "";
                    if (item.RecoveryReportFileName != null && item.RecoveryReportFileName != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.RecoveryReportFilePath) + "' class='ml-2' data-original-title='Download Recovery Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div += "</div>";
                }
                div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Date of Half Yearly Assessment</label>";
                div += "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.HalfYearAssesmentDate + "</label>";
                div += "</div>";
                div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Copy of Half Yearly Assessment</label>";
                div += "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.HalfyearassesmentFileName + "";
                if (item.HalfyearassesmentFileName != null && item.HalfyearassesmentFileName != "")
                {
                    div = div + "<a href='" + @Url.Content("~/" + item.HalfyearassesmentFilePath) + "' class='ml-2' data-original-title='Download Half Yearly Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                }
                div += "</div>";
                div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Remarks</label>";
                div += "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.Remarks + "</label>";
                div += "</div>";
                div += "</div>";
                div += "</div>";
                div += "</li>";
            }
            return div;
        }
        /// <summary>
        /// To Compare Lessee Assessment Report Request Data in view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public async Task<IActionResult> Compare(string id = "0")
        {
            try
            {
                objmodel.CREATED_BY = Convert.ToInt32(id);
                objlistmodel = await _objILesseeAssessmentReportModel.GetAssessmentReportCompareDetails(objmodel);
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
        /// To Approve,Reject Lessee Assessment Report Profile Request Data in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Compare(LesseeAssessmentReportViewModel objmodel)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserLoginId = profile.UserLoginId;
                if (objmodel.SubApprove == "Approve")
                {
                    objobjmodel = _objILesseeAssessmentReportModel.ApproveLesseeAssessmentReportDetails(objmodel);
                }
                else
                {
                    objobjmodel = _objILesseeAssessmentReportModel.RejectLesseeAssessmentReportDetails(objmodel);
                }
                if (objobjmodel.Satus == "1")
                {
                    TempData["Message"] = "Lessee Assessment Report Details Approved successfully";
                }
                else if (objobjmodel.Satus == "2")
                {
                    TempData["Message"] = "Lessee Assessment Report Details Rejected successfully";
                }
                else
                {
                    TempData["Message"] = "Error ! while " + objmodel.SubApprove + " Lessee Assessment Report Details";
                }
                string EncryptUrl = CustomQueryStringHelper.EncryptString("LesseeProfile", "Compare", "LesseeAssessmentReportDetails", new { id = objmodel.CREATED_BY });
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
