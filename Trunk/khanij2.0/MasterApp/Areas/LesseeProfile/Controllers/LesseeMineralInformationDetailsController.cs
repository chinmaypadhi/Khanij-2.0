// ***********************************************************************
//  Controller Name          : LesseeMineralInformationDetailsController
//  Description              : Lessee Mineral Information Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 20 July 2021
// ***********************************************************************
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.Areas.LesseeProfile.Models.MineralInformation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MasterApp.Web;
using MasterApp.ActionFilter;

namespace MasterApp.Areas.LesseeProfile.Controllers
{
    [Area("LesseeProfile")]
    public class LesseeMineralInformationDetailsController : Controller
    {
        /// <summary>
        /// Global Variable,object declaration
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        IMineralInformationModel _objIMineralInformationModel;
        LesseeMineralInformationModel objmodel = new LesseeMineralInformationModel();
        List<LesseeMineralInformationModel> objlistmodel = new List<LesseeMineralInformationModel>();
        MessageEF objobjmodel = new MessageEF();
        string uniqueFileName = string.Empty;
        string filePath = string.Empty;
        string ExtensionId = string.Empty;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objIMineralInformationModel"></param>
        public LesseeMineralInformationDetailsController(IMineralInformationModel objIMineralInformationModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _objIMineralInformationModel = objIMineralInformationModel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }
        /// <summary>
        /// HTTP GET method of Create
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
                ViewBag.MineralCategory = await GetMineralCategoryDetails(null);
                objmodel = await _objIMineralInformationModel.GetMineralInformationDetails(objmodel);
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
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Create(LesseeMineralInformationModel objmodel, string cmd, string delete)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.CREATED_BY = profile.UserId;
            objmodel.UserLoginId = profile.UserLoginId;
            ExtensionId = Convert.ToString(objmodel.CREATED_BY);
            try
            {
                #region Validation
                if (objmodel.MINERAL_CATEGORY_ID ==null)
                {
                    ModelState.AddModelError("MINERAL_CATEGORY_ID", "Mineral Category field is required");
                }
                if (objmodel.MineralCount == null)
                {
                    ModelState.AddModelError("MineralCount", "Mineral Name field is required");
                }
                if (objmodel.MineralFormCount == null)
                {
                    ModelState.AddModelError("MineralFormCount", "Mineral Form field is required");
                }
                if (objmodel.MineralGradeCount == null)
                {
                    ModelState.AddModelError("MineralGradeCount", "Mineral Grade field is required");
                }
                #endregion
                if (ModelState.IsValid)
                {
                    #region File Upload
                    if (objmodel.FILE != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.FILE.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadMineralInformationPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadMineralInformationPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.FILE.CopyTo(fileStream);
                        objmodel.COPY_OF_MP_SOM_ESTIMATION_FILE_NAME = uniqueFileName;
                        objmodel.COPY_OF_MP_SOM_ESTIMATION_FILE_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    objmodel.FILE = null;
                    #endregion
                    var checkDMO = "Forward To DD";
                    if (objmodel.SubResion == "Forward To DD")
                    {
                        cmd = "Forward To DD";
                    }
                    if (checkDMO == cmd)
                    {
                        objmodel.STATUS = 1;
                        objobjmodel = _objIMineralInformationModel.UpdateMineralInformationDetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Lessee Mineral Information Details forwarded to DD/DMO successfully";
                        }
                        else if (objobjmodel.Satus == "2")
                        {
                            TempData["Message"] = "Lessee Mineral Information Details forwarded to DD/DMO successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while forwarding Lessee Mineral Information Details to DD/DMO";
                        }
                    }
                    else if (delete == "Delete")
                    {
                        objobjmodel = _objIMineralInformationModel.DeleteLesseeMineralInformationDetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Lessee Mineral Information Details Deleted Sucessfully.";
                        }
                        else
                        {
                            TempData["Message"] = "Lessee Mineral Information Details not Deleted Sucessfully.";
                        }
                    }
                    else
                    {
                        objmodel.STATUS = 0;
                        objobjmodel = _objIMineralInformationModel.UpdateMineralInformationDetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Lessee Mineral Information Details Saved successfully";
                        }
                        else if (objobjmodel.Satus == "2")
                        {
                            TempData["Message"] = "Lessee Mineral Information  Details Updated successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while Updating Lessee Mineral Information Details";
                        }

                    }
                    return RedirectToAction("Create", "LesseeMineralInformationDetails", new { Area = "LesseeProfile" });
                }
                else
                {
                    ViewBag.MineralCategory = await GetMineralCategoryDetails(null);
                    objmodel = await _objIMineralInformationModel.GetMineralInformationDetails(objmodel);
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
                objmodel = await _objIMineralInformationModel.GetMineralInformationDetails(objmodel);
                ViewBag.tableLA = await MineralInformationLogDetails(objmodel.CREATED_BY);
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
        /// To bind Mineral Information Log Details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public async Task<string> MineralInformationLogDetails(int? Created_By)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            string div = "";
            objmodel.CREATED_BY = Created_By;
            objlistmodel = await _objIMineralInformationModel.GetMineralInformationLogDetails(objmodel);
            foreach (var item in objlistmodel)
            {
                div += "<li class='timeline-item'>";
                div += "<div class='date-box'>";
                div += "<p><span class='date'>" + item.ModifyDate + "</span><span class='month-year'>" + item.ModifyYear + "</span></p>";
                div += "</div>";
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
                div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Mineral Category</label>";
                div += "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.MINERAL_CATEGORY_NAME + "</label>";
                div += "</div>";
                div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Mineral Name</label>";
                div += "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.MineralName + "</label>";
                div += "</div>";
                div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Mineral Form</label>";
                div += "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.MineralFormName + "</label>";
                div += "</div>";
                div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Mineral Grade</label>";
                div += "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.MineralGradeName + "</label>";
                div += "</div>";
                div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Reserve Estimated</label>";
                div += "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.ESTIMATED_RESERVE + "</label>";
                div += "</div>";
                div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Minable Reserve</label>";
                div += "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.MINABLE_RESERVE + "</label>";
                div += "</div>";
                if (profile.MineralTypeName == "Minor Mineral")
                {
                    div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Copy of the relevant page Quarry Plan</label>";
                }
                else
                {
                    div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Copy of the relevant page of MP/SOM whereby reserve</label>";
                }
                div += "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.COPY_OF_MP_SOM_ESTIMATION_FILE_NAME + "";
                if (item.COPY_OF_MP_SOM_ESTIMATION_FILE_NAME != null && item.COPY_OF_MP_SOM_ESTIMATION_FILE_NAME != "")
                {
                    div = div + "<a href='" + @Url.Content("~/" + item.COPY_OF_MP_SOM_ESTIMATION_FILE_PATH) + "' class='ml-2' data-original-title='Download' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
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
        /// To Compare Lessee Mineral Information Request Data in view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public async Task<IActionResult> Compare(string id="0")
        {
            try
            {
                objmodel.CREATED_BY = Convert.ToInt32(id);
                objlistmodel = await _objIMineralInformationModel.GetMineralInformationCompareDetails(objmodel);
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
        /// To Approve,Reject Lessee Mineral Information Profile Request Data in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Compare(LesseeMineralInformationModel objmodel)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserLoginId = profile.UserLoginId;
                if (objmodel.SubApprove == "Approve")
                {
                    objobjmodel = _objIMineralInformationModel.ApproveLesseeMineralInformationDetails(objmodel);
                }
                else
                {
                    objobjmodel = _objIMineralInformationModel.RejectLesseeMineralInformationDetails(objmodel);
                }
                if (objobjmodel.Satus == "1")
                {
                    TempData["Message"] = "Lessee Mineral Information Details Approved successfully";
                }
                else if (objobjmodel.Satus == "2")
                {
                    TempData["Message"] = "Lessee Mineral Information Details Rejected successfully";
                }
                else
                {
                    TempData["Message"] = "Error ! while " + objmodel.SubApprove + " Lessee Mineral Information Details";
                }
                string EncryptUrl = CustomQueryStringHelper.EncryptString("LesseeProfile", "Compare", "LesseeMineralInformationDetails", new { id = objmodel.CREATED_BY });
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
        #region Binddropdowns
        /// <summary>
        /// To Bind the Mineral Category Details data in view
        /// </summary>
        /// <param name="AuctionTypeId"></param>
        /// <returns></returns>
        private async Task<SelectList> GetMineralCategoryDetails(int? MINERAL_CATEGORY_ID)
        {
            try
            {
                objlistmodel = await _objIMineralInformationModel.GetMineralCategoryDetails(objmodel);
                return new SelectList(objlistmodel, "MINERAL_CATEGORY_ID", "MINERAL_CATEGORY_NAME", MINERAL_CATEGORY_ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objlistmodel = null;
            }
        }
        /// <summary>
        /// To Bind the Mineral Name Details data in view
        /// </summary>
        /// <param name="mineralType"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetMineralNameDetails(int? mineralType)
        {
            try
            {
                if (mineralType != 0)
                {
                    UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                    objmodel.CREATED_BY = profile.UserId;
                    objmodel.MINERAL_CATEGORY_ID = mineralType;
                    objlistmodel = await _objIMineralInformationModel.GetMineralNameDetails(objmodel);
                }
                if (objlistmodel != null)
                {
                    var modifiedData = objlistmodel.Select(x => new
                    {
                        mineralId = x.MineralID,
                        mineralName = x.MineralName
                    });
                    return Json(modifiedData);
                }
                else
                {
                    return Json("");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objlistmodel = null;
            }
        }
        /// <summary>
        /// To Bind the Mineral Form Details data in view
        /// </summary>
        /// <param name="mineralId"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetMineralFormInformationDetails(string mineralId)
        {
            try
            {
                if (mineralId != "0")
                {
                    UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                    objmodel.CREATED_BY = profile.UserId;
                    objmodel.MineralIdList = mineralId;
                    objlistmodel = await _objIMineralInformationModel.GetMineralFormDetails(objmodel);
                }
                if (objlistmodel != null)
                {
                    var modifiedData1 = objlistmodel.Select(x => new
                    {
                        mineralNatureId = x.MineralNatureId,
                        mineralNature = x.MineralNature
                    });
                    return Json(modifiedData1);
                }
                else
                {
                    return Json("");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objlistmodel = null;
            }
        }
        /// <summary>
        /// To Bind the Mineral Grade Details data in view
        /// </summary>
        /// <param name="mineralId"></param>
        /// <param name="MineralNatureList"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetMineralGradeInformationDetails(string mineralId, string MineralNatureList)
        {
            try
            {
                if (mineralId != "0")
                {
                    UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                    objmodel.CREATED_BY = profile.UserId;
                    objmodel.MineralIdList = mineralId;
                    objmodel.MineralNatureId = MineralNatureList;
                    objlistmodel = await _objIMineralInformationModel.GetMineralGradeDetails(objmodel);
                }
                if (objlistmodel != null)
                {
                    var modifiedData1 = objlistmodel.Select(x => new
                    {
                        mineralGradeId = x.MineralGradeId,
                        mineralGrade = x.MineralGrade
                    });
                    return Json(modifiedData1);
                }
                else
                {
                    return Json("");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objlistmodel = null;
            }
        }
        #endregion
    }
}
