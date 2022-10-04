// ***********************************************************************
//  Controller Name          : GrantDetails
//  Desciption               : Liecensee Grant Order Details 
//  Created By               : Prakash Chandra Biswal
//  Created On               : 31 June 2021
// ***********************************************************************
using MasterApp.ActionFilter;
using MasterApp.Areas.Licensee.Models;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Licensee.Controllers
{
    [Area("Licensee")]
    public class MineralinfoController : Controller
    {
        #region Global Variables
        /// <summary>
        /// Global Variable Declaration
        /// </summary>
        IUserInformationLicenseeModel _userInformation;
        MessageEF objMSmodel = new MessageEF();
        List<MineralDetails> objlistmodel = new List<MineralDetails>();
        //LeaseAreaViewModel areaDetails = new LeaseAreaViewModel();
        MineralDetails mineralDetailsobj = new MineralDetails();
        LicenseeResult licenseeResult = new LicenseeResult();
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        #endregion
        /// <summary>
        /// Constructor Dependency Injection
        /// </summary>
        /// <param name="userInformationLicenseeModel"></param>
        /// <param name="hostingEnvironment"></param>
        /// <param name="configuration"></param>
        public MineralinfoController(IUserInformationLicenseeModel userInformationLicenseeModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
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
                mineralDetailsobj.CREATED_BY = profile.UserId;
                ViewBag.MineralCategory = await GetMineralCategoryDetails();
                mineralDetailsobj = await _userInformation.GetMineralInformationDetails(mineralDetailsobj);
                return View(mineralDetailsobj);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MineralDetails mineralDetails, string cmd, string delete)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            mineralDetails.CREATED_BY = profile.UserId;
            mineralDetails.UserLoginId = profile.UserLoginId.ToString();
            try
            {
                var checkDMO = "Forward To DD";
                #region Validation
                if (mineralDetails.MINERAL_CATEGORY_ID == null)
                {
                    ModelState.AddModelError("MINERAL_CATEGORY_ID", "Mineral Category field is required");
                }
                if (mineralDetails.MineralCount == null)
                {
                    ModelState.AddModelError("MineralCount", "Mineral Name field is required");
                }
                if (mineralDetails.MineralFormCount == null)
                {
                    ModelState.AddModelError("MineralFormCount", "Mineral Form field is required");
                }
                if (mineralDetails.MineralGradeCount == null)
                {
                    ModelState.AddModelError("MineralGradeCount", "Mineral Grade field is required");
                }
                #endregion
                if (ModelState.IsValid)
                {
                    if (mineralDetails.SubResion == "Forward To DD")
                    {
                        cmd = "Forward To DD";
                    }
                    if (checkDMO == cmd)
                    {
                        mineralDetails.STATUS = 1;
                        objMSmodel = _userInformation.UpdateMineralInformationDetails(mineralDetails);
                        if (objMSmodel.Satus == "1")
                        {
                            TempData["Message"] = "Licenee Mineral Information Details forwarded to DD/DMO successfully";
                        }
                        else if (objMSmodel.Satus == "2")
                        {
                            TempData["Message"] = "Licensee Mineral Information Details forwarded to DD/DMO successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while forwarding Licensee Mineral Information Details to DD/DMO";
                        }
                    }
                    else if (delete == "Delete")
                    {
                        objMSmodel = _userInformation.DeleteMineralInformationDetails(mineralDetails);
                        if (objMSmodel.Satus == "1")
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
                        mineralDetails.STATUS = 0;
                        objMSmodel = _userInformation.UpdateMineralInformationDetails(mineralDetails);
                        if (objMSmodel.Satus == "1")
                        {
                            TempData["Message"] = "Licensee Mineral Information Details Saved successfully";
                        }
                        else if (objMSmodel.Satus == "2")
                        {
                            TempData["Message"] = "Licensee Mineral Information  Details Updated successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while Updating Licensee Mineral Information Details";
                        }

                    }
                    return RedirectToAction("Create", "Mineralinfo", new { Area = "Licensee" });
                }
                else
                {
                    ViewBag.MineralCategory = await GetMineralCategoryDetails();
                    mineralDetailsobj = await _userInformation.GetMineralInformationDetails(mineralDetailsobj);
                    return View(mineralDetailsobj);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<IActionResult> ViewList()
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                mineralDetailsobj.CREATED_BY = profile.UserId;
                mineralDetailsobj = await _userInformation.GetMineralInformationDetails(mineralDetailsobj);
                ViewBag.tableLA = await MineralInformationLogDetails(mineralDetailsobj.CREATED_BY);
                return View(mineralDetailsobj);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                mineralDetailsobj = null;
            }
        }
        public async Task<string> MineralInformationLogDetails(int? Created_By)
        {
            string div = "";
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            mineralDetailsobj.CREATED_BY = profile.UserId;
            objlistmodel = await _userInformation.GetMineralInformationLogDetails(mineralDetailsobj);
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
        [HttpGet, Decryption]
        public async Task<IActionResult> Compare(string id="0")
        {
            try
            {
                if(!string.IsNullOrEmpty(id) && id!="0")
                {
                    mineralDetailsobj.CREATED_BY = Convert.ToInt32(id);
                    mineralDetailsobj.UserID= Convert.ToInt32(id);
                    objlistmodel = await _userInformation.GetMineralInformationCompareDetails(mineralDetailsobj);
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
                mineralDetailsobj = null;
                objlistmodel = null;
            }
        }
        /// <summary>
        /// To Approve,Reject Lessee Mineral Information Profile Request Data in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        [HttpPost]
       
        public IActionResult Compare(LesseeMineralInformationModel objmodel)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                mineralDetailsobj.UserID = profile.UserId;
                mineralDetailsobj.UserLoginId = profile.UserLoginId.ToString();
                mineralDetailsobj.CREATED_BY = objmodel.CREATED_BY;
                if (objmodel.SubApprove == "Approve")
                {
                    objMSmodel = _userInformation.ApproveMineralInformationDetails(mineralDetailsobj);
                }
                else
                {
                    objMSmodel = _userInformation.RejectMineralInformationDetails(mineralDetailsobj);
                }
                if (objMSmodel.Satus == "1")
                {
                    TempData["Message"] = "Licensee Mineral Information Details Approved successfully";
                }
                else if (objMSmodel.Satus == "2")
                {
                    TempData["Message"] = "Licensee Mineral Information Details Rejected successfully";
                }
                else
                {
                    TempData["Message"] = "Error ! while " + objmodel.SubApprove + " Lessee Mineral Information Details";
                }
                //return RedirectToAction("Compare", "Mineralinfo", new { Area = "Licensee" });
                string EncryptUrl = CustomQueryStringHelper.EncryptString("Licensee", "Compare", "Mineralinfo", new { id = objmodel.CREATED_BY });
                return LocalRedirect(EncryptUrl);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objmodel = null;
                objMSmodel = null;
            }
        }
        #region Binddropdowns
        /// <summary>
        /// To Bind the Mineral Category Details data in view
        /// </summary>
        /// <param name="AuctionTypeId"></param>
        /// <returns></returns>
        private async Task<SelectList> GetMineralCategoryDetails()
        {
            try
            {
                objlistmodel = await _userInformation.GetMineralCategoryDetails(mineralDetailsobj);
                return new SelectList(objlistmodel, "MINERAL_CATEGORY_ID", "MINERAL_CATEGORY_NAME");
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
                    mineralDetailsobj.CREATED_BY = profile.UserId;
                    mineralDetailsobj.MINERAL_CATEGORY_ID = mineralType;
                    objlistmodel = await _userInformation.GetMineralNameDetails(mineralDetailsobj);
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
                    mineralDetailsobj.CREATED_BY = profile.UserId;
                    mineralDetailsobj.MineralIdList = mineralId;
                    objlistmodel = await _userInformation.GetMineralFormDetails(mineralDetailsobj);
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
                    mineralDetailsobj.CREATED_BY = profile.UserId;
                    mineralDetailsobj.MineralIdList = mineralId;
                    mineralDetailsobj.MineralNatureId = MineralNatureList;
                    objlistmodel = await _userInformation.GetMineralGradeDetails(mineralDetailsobj);
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
