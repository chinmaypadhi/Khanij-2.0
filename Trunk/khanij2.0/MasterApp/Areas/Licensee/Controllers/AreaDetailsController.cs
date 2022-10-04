// ***********************************************************************
//  Controller Name          : AreaDetails
//  Desciption               : Liecensee Grant Order Details 
//  Created By               : Prakash Chandra Biswal
//  Created On               : 21 July 2021
// ***********************************************************************

using MasterApp.ActionFilter;
using MasterApp.Areas.LesseeProfile.Models.LeaseAreaDetails;
using MasterApp.Areas.Licensee.Models;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Licensee.Controllers
{
    [Area("Licensee")]
    public class AreaDetailsController : Controller
    {
        #region Global Variables
        /// <summary>
        /// Global Variable Declaration
        /// </summary>
        IUserInformationLicenseeModel _userInformation;
        //ILesseeLeaseAreaModel _objILeaseAreaModel;
        MessageEF objMSmodel = new MessageEF();
        List<AreaDetails> objlistmodel = new List<AreaDetails>();
        //LeaseAreaViewModel areaDetails = new LeaseAreaViewModel();
        AreaDetails areaDetailsobj = new AreaDetails();
        LicenseeResult licenseeResult = new LicenseeResult();
        public object JsonRequestBehavior { get; private set; }
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        string uniqueFileName = string.Empty;
        string filePath = string.Empty;
        string ExtensionId = string.Empty;
        #endregion
        public AreaDetailsController(IUserInformationLicenseeModel objUserInformation, ILesseeLeaseAreaModel objILeaseAreaModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _userInformation = objUserInformation;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
            //_objILeaseAreaModel = objILeaseAreaModel;
        }
        #region Binddropdowns
        /// <summary>
        /// To Bind the State Details data in view
        /// </summary>
        /// <param name="STATE_ID"></param>
        /// <returns></returns>
        private async Task<SelectList> GetStateList(int? StateId)
        {
            objlistmodel = await _userInformation.GetStateList(areaDetailsobj);
            return new SelectList(objlistmodel, "StateId", "StateName", StateId);
        }
        /// <summary>
        /// To bind District Dropdown based on StateId
        /// </summary>
        /// <param name="StateId"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetDistrictdetailsByRegionId(int? StateId)
        {
            try
            {
                areaDetailsobj.StateId = StateId;
                objlistmodel = await _userInformation.GetDistrictList(areaDetailsobj);
                return Json(objlistmodel);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                areaDetailsobj = null;
            }
        }
        /// <summary>
        /// To bind Tehsil Dropdown based on DistrictId
        /// </summary>
        /// <param name="DistrictId"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetTehsildetailsByDistrictId(int? DistrictId)
        {
            try
            {
                areaDetailsobj.DistrictId = DistrictId;
                objlistmodel = await _userInformation.GetTehsilList(areaDetailsobj);
                return Json(objlistmodel);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                areaDetailsobj = null;
            }
        }
        /// <summary>
        /// To bind Village Dropdown based on TehsilID
        /// </summary>
        /// <param name="TehsilID"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetVillagedetailsByTehsilId(int? TehsilID)
        {
            try
            {
                areaDetailsobj.TehsilID = TehsilID;
                objlistmodel = await _userInformation.GetVillageList(areaDetailsobj);
                return Json(objlistmodel);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                areaDetailsobj = null;
            }
        }
        /// <summary>
        /// To Bind Land Types
        /// </summary>
        /// <returns></returns>
        private async Task<SelectList> GetLandTypeList()
        {
            objlistmodel = await _userInformation.GetLandTypeList(areaDetailsobj);
            return new SelectList(objlistmodel, "LAND_ID", "LandName");
        }
        #endregion
        public async Task<IActionResult> Create()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                if(profile.UserId!=0)
                {
                    areaDetailsobj.CREATED_BY = profile.UserId;
                    areaDetailsobj.UserID = profile.UserId;
                    ViewBag.State = await GetStateList(null);
                    ViewBag.LandType = await GetLandTypeList();
                    licenseeResult = await _userInformation.GetAreaDetails(areaDetailsobj);
                    return View(licenseeResult.AreaDetalsList.FirstOrDefault());
                }
                else
                {
                    return View(new AreaDetails());
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                areaDetailsobj = null;
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AreaDetails areaDetails, string cmd, string delete, IFormFile selectedFile)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            areaDetails.CREATED_BY = profile.UserId;
            ExtensionId = Convert.ToString(areaDetails.CREATED_BY);

            //areaDetails.CREATED_BY = 461;
            ExtensionId = Convert.ToString(areaDetails.CREATED_BY);
            try
            {
                #region Validation
                if (areaDetails.StateId == null)
                {
                    ModelState.AddModelError("StateId", "State Name");
                }
                if (areaDetails.DistrictId == null)
                {
                    ModelState.AddModelError("DistrictId", "District Name");
                }
                if (areaDetails.TehsilID == null)
                {
                    ModelState.AddModelError("VillageID", "Village Name");
                }
                #endregion
                if (ModelState.IsValid)
                {
                    #region Upload File 

                    if ( selectedFile != null && selectedFile.Length > 0)
                    {

                        if (!string.IsNullOrEmpty(selectedFile.FileName))
                        {
                            string hosting = _hostingEnvironment.ContentRootPath;
                            string wwwPath = this._hostingEnvironment.WebRootPath;
                            string strName = DateTime.Now.Date.Day.ToString() + DateTime.Now.Date.Month.ToString() + DateTime.Now.Date.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                            var fileName = strName + "_" + selectedFile.FileName;
                            filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("LicenseeAreaPath"), fileName);
                            var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("LicenseeAreaPath"));
                            string UploadFolderPath = Path.Combine(RootPath, fileName);
                            if (!Directory.Exists(RootPath))
                                Directory.CreateDirectory(RootPath);
                            DirectoryInfo di = new DirectoryInfo(RootPath);
                            di.Attributes = FileAttributes.Normal;
                            using (var stream = new FileStream(UploadFolderPath, FileMode.Create))
                            {
                                selectedFile.CopyTo(stream);
                            }
                            areaDetails.DEMARCATION_REPORT_PATH = filePath;
                            areaDetails.FILE_DEMARCATION_REPORT = fileName;
                        }

                    }
                    #endregion
                    var checkDMO = "Forward To DD";
                    if (areaDetails.SubResion == "Forward To DD")
                    {
                        cmd = "Forward To DD";
                    }
                    if (checkDMO == cmd)
                    {
                        areaDetails.STATUS = 1;
                        objMSmodel = _userInformation.UpdateAreaDetail(areaDetails);
                        if (objMSmodel.Satus == "1")
                        {
                            TempData["Message"] = "Licensee Area Details forwarded to DD/DMO successfully";
                        }
                        else if (objMSmodel.Satus == "2")
                        {
                            TempData["Message"] = "Licensee Area Details forwarded to DD/DMO successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while forwarding Lessee License Area Details to DD/DMO";
                        }
                    }
                    else if (delete == "Delete")
                    {
                        objMSmodel = _userInformation.DeleteAreaDetails(areaDetails);
                        if (objMSmodel.Satus == "1")
                        {
                            TempData["Message"] = "Licensee Area Details Details Deleted Sucessfully.";
                        }
                        else
                        {
                            TempData["Message"] = "Licensee Area Details Details not Deleted Sucessfully.";
                        }
                    }
                    else
                    {
                        areaDetails.STATUS = 0;
                        objMSmodel = _userInformation.UpdateAreaDetail(areaDetails);
                        if (objMSmodel.Satus == "1")
                        {
                            TempData["Message"] = "Licensee Area Details Saved successfully";
                        }
                        else if (objMSmodel.Satus == "2")
                        {
                            TempData["Message"] = "Licensee Area Details Saved successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while Updating License Area Details";
                        }
                    }
                    return RedirectToAction("Create", "AreaDetails", new { Area = "Licensee" });
                }
                else
                {
                    ViewBag.State = await GetStateList(null);
                    licenseeResult = await _userInformation.GetAreaDetails(areaDetailsobj);
                    return View(areaDetailsobj);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<IActionResult> ViewList(int id = 0)
        {
            UserLoginSession session = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            AreaDetails objareadetails = new AreaDetails();
            try
            {
                objareadetails.UserID = session.UserId;
                objareadetails.CREATED_BY = session.UserId;
                objareadetails.UserLoginId = session.UserLoginId.ToString();
                LicenseeResult listobj = await _userInformation.GetAreaDetails(objareadetails);
                if (listobj.AreaDetalsList != null)
                {
                    ViewBag.tableLA = await LeaseLocationTable(objareadetails.CREATED_BY);
                    ViewBag.tableLB = await LeaseLocationAreaTable(objareadetails.CREATED_BY);
                    return View(listobj.AreaDetalsList.FirstOrDefault());
                }
                else
                {
                    return View(new AreaDetails());
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { objareadetails = null; }
        }

        [HttpGet, Decryption]
        public IActionResult Compare(string id="0")
        {
            AreaDetails objareadetails = new AreaDetails();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                if(!string.IsNullOrEmpty(id) && id!="0")
                {
                    objareadetails.UserID = Convert.ToInt32(id);
                    objareadetails.CREATED_BY = Convert.ToInt32(id);
                    objareadetails.UserLoginId = profile.UserLoginId.ToString();
                    objlistmodel = _userInformation.CompareAreaDetails(objareadetails);
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
                objareadetails = null;
                objlistmodel = null;
            }
        }
        [HttpPost]
        public IActionResult Compare(AreaDetails areaDetails, int id = 0)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                areaDetails.UserID = profile.UserId;

                if (areaDetails.SubApprove == "Approve")
                {
                    objMSmodel = _userInformation.ApproveAreaDetails(areaDetails);
                }
                else
                {
                    objMSmodel = _userInformation.RejectAreaDetails(areaDetails);
                }
                if (objMSmodel.Satus == "1")
                {
                    TempData["Message"] = "Licensee Area  Details Approved successfully";
                }
                else if (objMSmodel.Satus == "2")
                {
                    TempData["Message"] = "Licensee Area  Details Rejected successfully";
                }
                else
                {
                    TempData["Message"] = "Error ! while " + areaDetails.SubApprove + " License Area Details";
                }
                //return RedirectToAction("Compare", "AreaDetails", new { Area = "Licensee" });
                string EncryptUrl = CustomQueryStringHelper.EncryptString("Licensee", "Compare", "AreaDetails", new { id = areaDetails.CREATED_BY });
                return LocalRedirect(EncryptUrl);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> LeaseLocationTable(int? Created_By)
        {
            string div = "";
            areaDetailsobj.UserID = Created_By;
            areaDetailsobj.CREATED_BY = Created_By;
            objlistmodel = await _userInformation.GetAreaDetailsLogDetails(areaDetailsobj);
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
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>State</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.StateName + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>District</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.DistrictName + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Tehsil/Forest Division</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.TehsilName + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Village/Forest Range</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.VillageName + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Block Forest Range</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.BLOCK_FOREST_RANG + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Pin Code</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.PIN_CODE + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Police Station</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.POLICE_STATION + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Gram Panchayat</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.GRAM_PANCHAYAT + "</label>";
                div = div + "</div>";
                div = div + "</div>";
                div = div + "</li>";
            }
            return div;
        }
        /// <summary>
        /// To bind Lease Location Area Table Details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public async Task<string> LeaseLocationAreaTable(int? Created_By)
        {
            string div = "";
            areaDetailsobj.UserID = Created_By;
            areaDetailsobj.CREATED_BY = Created_By;
            objlistmodel = await _userInformation.GetAreaDetailsLogDetails(areaDetailsobj);
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
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Area In Hectare</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.AREA_IN_HECT + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Toposheet Number</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.TOPOSHEET_NO + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Coordinate No</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.COORDINATES_NO + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Longitude</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.Longitude + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Latitude</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.Latitude + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Co-ordinates of all Pillars</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.FILE_ATTACHMENT + "";
                if (item.DEMARCATION_REPORT_PATH != null && item.DEMARCATION_REPORT_PATH != "")
                {
                    div = div + "<a href='" + @Url.Content("~/" + item.DEMARCATION_REPORT_PATH) + "' class='ml-2' data-original-title='Download' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                }
                div = div + "</div>";
                div = div + "</div>";
                div = div + "</li>";
            }
            return div;
        }

    }
}
