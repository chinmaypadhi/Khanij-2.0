// ***********************************************************************
//  Controller Name          : LesseeLeaseAreaDetailsController
//  Description              : Lessee Lease Area Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 21 July 2021
// ***********************************************************************
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.Areas.LesseeProfile.Models.LeaseAreaDetails;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MasterApp.Web;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.Block;
using System.Data.OleDb;
using System.Data;
using System.Xml;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;

namespace MasterApp.Areas.LesseeProfile.Controllers
{
    [Area("LesseeProfile")]
    public class LesseeLeaseAreaDetailsController : Controller
    {
        /// <summary>
        /// Global Variable,object declaration
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        ILesseeLeaseAreaModel _objILeaseAreaModel;
        IBlockModel _objIBlockModel;
        LeaseAreaViewModel objmodel = new LeaseAreaViewModel();
        List<LeaseAreaViewModel> objlistmodel = new List<LeaseAreaViewModel>();
        BlockMaster objBlockmodel = new BlockMaster();
        List<BlockMaster> objlistBlockmodel = new List<BlockMaster>();
        MessageEF objobjmodel = new MessageEF();
        string uniqueFileName = string.Empty;
        string filePath = string.Empty;
        string ExtensionId = string.Empty;
        DataTable dt = new DataTable();
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objLesseeDetailsModel"></param>
        public LesseeLeaseAreaDetailsController(ILesseeLeaseAreaModel objILeaseAreaModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration, IBlockModel objIBlockModel)
        {
            _objILeaseAreaModel = objILeaseAreaModel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
            _objIBlockModel = objIBlockModel;
        }
        /// <summary>
        /// HTTP GET method of Grant
        /// </summary>
        /// <returns></returns>
        [Decryption]
        public async Task<IActionResult> Create(string id = "0")
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                profile.MineralTypeName = "Major Mineral";
                if (id == "0")
                {
                    objmodel.CREATED_BY = profile.UserId;
                }
                else
                {
                    objmodel.CREATED_BY = Convert.ToInt32(id);
                }
                ViewBag.State = await GetStateList(null);
                ViewBag.Land = await GetLandList(null);
                ViewBag.VidhanSabha = GetVidhanSabhaList();
                ViewBag.LokSabha = GetLokSabhaList();
                objmodel = await _objILeaseAreaModel.GetLeaseAreaDetails(objmodel);
                if (profile.MineralTypeName == "Minor Mineral")
                {
                    objmodel.FOREST_RANGE = objmodel.FOREST_RANGE == null ? "Protected" : objmodel.FOREST_RANGE;
                }
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
        /// HTTP POST method of Grant
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Create(LeaseAreaViewModel objmodel, string cmd, string delete)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.CREATED_BY = profile.UserId;
            profile.MineralTypeName = "Major Mineral";
            ExtensionId = Convert.ToString(objmodel.CREATED_BY);
            objmodel.LEASELAND_AREA_TYPE = Convert.ToString(objmodel.LAND_ID);
            if(objmodel.IsForestRangeProtected == true && objmodel.IsForestRangeRevenue == true)
            {
                objmodel.FOREST_RANGE = "Protected,Revenue";
            }
            else if(objmodel.IsForestRangeProtected == true)
            {
                objmodel.FOREST_RANGE = "Protected";
            }
            else
            {
                objmodel.FOREST_RANGE = "Revenue";
            }
            objmodel.VidhanSabha = Convert.ToString(objmodel.VidhanSabhaId);
            objmodel.LokSabha = Convert.ToString(objmodel.LokSabhaId);
            #region Bind LeaseLand Area values
            objmodel.Forest = objmodel.LandForest;
            objmodel.RevenueForest = objmodel.LandRevenueForest;
            objmodel.RevenueGovernmentLand = objmodel.LandRevenueGovernmentLand;
            objmodel.PrivateTribal = objmodel.LandPrivateTribal;
            objmodel.PrivateNonTribal = objmodel.LandPrivateNonTribal;
            #endregion
            try
            {
                #region Validation
                //if (objmodel.StateId == null)
                //{
                //    ModelState.AddModelError("StateId", "State field is required");
                //}
                //if (objmodel.DistrictId == null)
                //{
                //    ModelState.AddModelError("DistrictId", "District field is required");
                //}
                //if (objmodel.BlockId == null)
                //{
                //    ModelState.AddModelError("BlockId", "Block field is required");
                //}
                //if (objmodel.TehsilID == null)
                //{
                //    ModelState.AddModelError("TehsilID", "Tehsil field is required");
                //}
                //if (profile.MineralTypeName == "Major Mineral")
                //{
                //    if (string.IsNullOrEmpty(Convert.ToString(objmodel.Forest)))
                //    {
                //        ModelState.AddModelError("Forest", "Forest field is required");
                //    }
                //    if (string.IsNullOrEmpty(Convert.ToString(objmodel.RevenueForest)))
                //    {
                //        ModelState.AddModelError("RevenueForest", "Revenue Forest field is required");
                //    }
                //    if (string.IsNullOrEmpty(Convert.ToString(objmodel.RevenueGovernmentLand)))
                //    {
                //        ModelState.AddModelError("RevenueGovernmentLand", "Revenue Government Land field is required");
                //    }
                //    if (string.IsNullOrEmpty(Convert.ToString(objmodel.PrivateTribal)))
                //    {
                //        ModelState.AddModelError("PrivateTribal", "Private Tribal field is required");
                //    }
                //    if (string.IsNullOrEmpty(Convert.ToString(objmodel.PrivateNonTribal)))
                //    {
                //        ModelState.AddModelError("PrivateNonTribal", "Private NonTribal field is required");
                //    }
                //}
                //if (string.IsNullOrEmpty(Convert.ToString(objmodel.Nistar)))
                //{
                //    ModelState.AddModelError("Nistar", "Nistar field is required");
                //}
                //if (profile.MineralTypeName != "Minor Mineral" && objmodel.LAND_ID == 0)
                //{
                //    ModelState.AddModelError("LAND_ID", "Lease Land Area field is required");
                //}
                //if (profile.MineralTypeName == "Minor Mineral")
                //{
                //    if (string.IsNullOrEmpty(Convert.ToString(objmodel.LandForest)))
                //    {
                //        ModelState.AddModelError("LandForest", "Forest field is required");
                //    }
                //    if (string.IsNullOrEmpty(Convert.ToString(objmodel.LandRevenueForest)))
                //    {
                //        ModelState.AddModelError("LandRevenueForest", "Revenue Forest field is required");
                //    }
                //    if (string.IsNullOrEmpty(Convert.ToString(objmodel.LandRevenueGovernmentLand)))
                //    {
                //        ModelState.AddModelError("LandRevenueGovernmentLand", "Revenue Government Land field is required");
                //    }
                //    if (string.IsNullOrEmpty(Convert.ToString(objmodel.LandPrivateTribal)))
                //    {
                //        ModelState.AddModelError("LandPrivateTribal", "Private Tribal field is required");
                //    }
                //    if (string.IsNullOrEmpty(Convert.ToString(objmodel.LandPrivateNonTribal)))
                //    {
                //        ModelState.AddModelError("LandPrivateNonTribal", "Private NonTribal field is required");
                //    }
                //}
                #endregion
                #region File Upload
                if (objmodel.COORDINATES_PILLARS != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.COORDINATES_PILLARS.FileName);
                    filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadPillarCoordinatesPath"), uniqueFileName);
                    var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadPillarCoordinatesPath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        objmodel.COORDINATES_PILLARS.CopyTo(fileStream);
                    objmodel.FILE_COORDINATES_PILLARS = uniqueFileName;
                    objmodel.PATH_COORDINATES_PILLARS = filePath;
                    uniqueFileName = null;
                    filePath = null;
                    #region Excel upload code
                    string fileExtension = Path.GetExtension(objmodel.COORDINATES_PILLARS.FileName);
                    if (fileExtension == ".xls" || fileExtension == ".xlsx")
                    {
                        string fileLocation = uploadsFolder;
                        string excelConnectionString = string.Empty;
                        //connection String for xls file format.
                        if (fileExtension == ".xls" || fileExtension == ".xlsx")
                        {
                            excelConnectionString = configuration.GetSection("ConnectionStrings").GetValue<string>("ExcelConString");
                        }
                        excelConnectionString = string.Format(excelConnectionString, uploadsFolder);
                        using (OleDbConnection connExcel = new OleDbConnection(excelConnectionString))
                        {
                            using (OleDbCommand cmdExcel = new OleDbCommand())
                            {
                                using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                                {
                                    cmdExcel.Connection = connExcel;
                                    connExcel.Open();
                                    DataTable dtExcelSchema;
                                    dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                                    connExcel.Close();
                                    //Read Data from First Sheet.
                                    connExcel.Open();
                                    cmdExcel.CommandText = "SELECT * From [Sheet1$]";
                                    odaExcel.SelectCommand = cmdExcel;
                                    odaExcel.Fill(dt);
                                    connExcel.Close();
                                }
                            }
                        }
                        // Ending Here
                    }
                    objmodel.dtCoordinatePillars = dt;
                    #endregion
                }
                if (objmodel.LEASE_AREA_MAP != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.LEASE_AREA_MAP.FileName);
                    filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadLeaseAreaPath"), uniqueFileName);
                    var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadLeaseAreaPath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        objmodel.LEASE_AREA_MAP.CopyTo(fileStream);
                    objmodel.FILE_LEASE_AREA_MAP = uniqueFileName;
                    objmodel.PATH_LEASE_AREA_MAP = filePath;
                    uniqueFileName = null;
                    filePath = null;
                }
                if (objmodel.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES.FileName);
                    filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadDemarcationPath"), uniqueFileName);
                    var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadDemarcationPath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        objmodel.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES.CopyTo(fileStream);
                    objmodel.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_NAME = uniqueFileName;
                    objmodel.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_PATH = filePath;
                    uniqueFileName = null;
                    filePath = null;
                }
                if (objmodel.WORKING_PERMISSION_COPY != null)
                {
                    uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.WORKING_PERMISSION_COPY.FileName);
                    filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadWorkPermissionPath"), uniqueFileName);
                    var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadWorkPermissionPath"));
                    string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                    if (!Directory.Exists(RootPath))
                        Directory.CreateDirectory(RootPath);
                    DirectoryInfo di = new DirectoryInfo(RootPath);
                    di.Attributes = FileAttributes.Normal;
                    using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                        objmodel.WORKING_PERMISSION_COPY.CopyTo(fileStream);
                    objmodel.WORKING_PERMISSION_COPY_NAME = uniqueFileName;
                    objmodel.WORKING_PERMISSION_COPY_PATH = filePath;
                    uniqueFileName = null;
                    filePath = null;
                }
                objmodel.COORDINATES_PILLARS = null;
                objmodel.LEASE_AREA_MAP = null;
                objmodel.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES = null;
                objmodel.WORKING_PERMISSION_COPY = null;
                #endregion
                //if (ModelState.IsValid)
                //{
                    var checkDMO = "Forward To DD";
                    if (objmodel.SubResion == "Forward To DD")
                    {
                        cmd = "Forward To DD";
                    }
                    if (checkDMO == cmd)
                    {
                        objmodel.STATUS = 1;
                        objobjmodel = _objILeaseAreaModel.UpdateLeaseAreaDetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Lessee Area Details forwarded to DD/DMO successfully";
                        }
                        else if (objobjmodel.Satus == "2")
                        {
                            TempData["Message"] = "Lessee Area Details forwarded to DD/DMO successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while forwarding Lessee License Area Details to DD/DMO";
                        }
                    }
                    else if (delete == "Delete")
                    {
                        objobjmodel = _objILeaseAreaModel.DeleteLesseeLeaseAreaDetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Lessee Area Details Details Deleted Sucessfully.";
                        }
                        else
                        {
                            TempData["Message"] = "Lessee Area Details Details not Deleted Sucessfully.";
                        }
                    }
                    else
                    {
                        objmodel.STATUS = 0;
                        objobjmodel = _objILeaseAreaModel.UpdateLeaseAreaDetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Lessee Area Details Saved successfully";
                        }
                        else if (objobjmodel.Satus == "2")
                        {
                            TempData["Message"] = "Lessee Area Details updated successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while Updating Lessee License Area Details";
                        }
                    }
                    return RedirectToAction("Create", "LesseeLeaseAreaDetails", new { Area = "LesseeProfile" });
                //}
                //else
                //{
                //    ViewBag.State = await GetStateList(null);
                //    ViewBag.Land = await GetLandList(null);
                //    objmodel = await _objILeaseAreaModel.GetLeaseAreaDetails(objmodel);
                //    return View(objmodel);
                //}
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
                objmodel = await _objILeaseAreaModel.GetLeaseAreaDetails(objmodel);
                ViewBag.tableLA = await LeaseLocationTable(objmodel.CREATED_BY);
                ViewBag.tableLB = await LeaseLocationAreaTable(objmodel.CREATED_BY);
                ViewBag.tableLC = await LeaseLocationLandTable(objmodel.CREATED_BY);
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
        /// To Compare Lessee Lease Lease Area Request Data in view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public async Task<IActionResult> Compare(string id = "0")
        {
            try
            {
                objmodel.UserId = Convert.ToInt32(id);
                objlistmodel = await _objILeaseAreaModel.GetLeaseAreaCompareDetails(objmodel);
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
        /// To Approve/Reject Lessee Lease Lease Area Request Data in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Compare(LeaseAreaViewModel objmodel)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserId = profile.UserId;
                if (objmodel.SubApprove == "Approve")
                {
                    objobjmodel = _objILeaseAreaModel.ApproveLeaseAreaDetails(objmodel);
                }
                else
                {
                    objobjmodel = _objILeaseAreaModel.RejectLeaseAreaDetails(objmodel);
                }
                if (objobjmodel.Satus == "1")
                {
                    TempData["Message"] = "Lessee Area  Details Approved successfully";
                }
                else if (objobjmodel.Satus == "2")
                {
                    TempData["Message"] = "Lessee Area  Details Rejected successfully";
                }
                else
                {
                    TempData["Message"] = "Error ! while " + objmodel.SubApprove + " Lessee License Area Details";
                }
                string EncryptUrl = CustomQueryStringHelper.EncryptString("LesseeProfile", "Compare", "LesseeLeaseAreaDetails", new { id = objmodel.CREATED_BY });
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
        /// To bind Lease Location Table Details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public async Task<string> LeaseLocationTable(int? Created_By)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            //profile.MineralTypeName = "Major Mineral";
            string div = "";
            objmodel.UserId = Created_By;
            objlistmodel = await _objILeaseAreaModel.GetLeaseAreaLogDetails(objmodel);
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
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>State</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.StateName + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>District</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.DistrictName + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Block</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.BlockName + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Tehsil</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.TehsilName + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Vidhan Sabha</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.VidhanSabha + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Lok Sabha</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.LokSabha + "</label>";
                div = div + "</div>";
                //if (profile.MineralTypeName != "Minor Mineral")
                //{
                //    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Village/Forest Range</label>";
                //    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                //    div = div + "<span class='colon'>:</span>" + item.VillageName + "</label>";
                //    div = div + "</div>";
                //    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Block Forest Range</label>";
                //    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                //    div = div + "<span class='colon'>:</span>" + item.BLOCK_FOREST_RANGE + "</label>";
                //    div = div + "</div>";
                //}
                if (profile.MineralTypeName == "Major Mineral" || profile.MineralTypeName == "Minor Mineral")
                {
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Forest Range</label>";
                    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.FOREST_RANGE + "</label>";
                    div = div + "</div>";
                    if (item.FOREST_RANGE == "Protected,Revenue")
                    {
                        div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Protected <small>(in Hectare)</small></label>";
                        div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div = div + "<span class='colon'>:</span>" + item.ForestRangeProtected + "</label>";
                        div = div + "</div>";
                        div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Revenue <small>(in Hectare)</small></label>";
                        div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div = div + "<span class='colon'>:</span>" + item.ForestRangeRevenue + "</label>";
                        div = div + "</div>";
                        div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Compartment Number</label>";
                        div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div = div + "<span class='colon'>:</span>" + item.COMPARTMENT_NUMBER + "</label>";
                        div = div + "</div>";
                    }
                    else if (item.FOREST_RANGE == "Protected")
                    {
                        div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Protected <small>(in Hectare)</small></label>";
                        div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div = div + "<span class='colon'>:</span>" + item.ForestRangeProtected + "</label>";
                        div = div + "</div>";
                    }
                    else
                    {
                        div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Revenue <small>(in Hectare)</small></label>";
                        div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div = div + "<span class='colon'>:</span>" + item.ForestRangeRevenue + "</label>";
                        div = div + "</div>";
                        div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Compartment Number</label>";
                        div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div = div + "<span class='colon'>:</span>" + item.COMPARTMENT_NUMBER + "</label>";
                        div = div + "</div>";
                    }
                }
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Pin Code</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.PIN_CODE + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Police Station</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.POLICE_STATION + "</label>";
                div = div + "</div>";
                if (profile.MineralTypeName != "Minor Mineral")
                {
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Gram Panchayat</label>";
                    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.GRAM_PANCHAYAT + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Forest</label>";
                    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.Forest + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Revenue Forest</label>";
                    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.RevenueForest + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Revenue Government Land</label>";
                    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.RevenueGovernmentLand + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Private Tribal</label>";
                    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.PrivateTribal + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Private Non Tribal</label>";
                    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.PrivateNonTribal + "</label>";
                    div = div + "</div>";
                }
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Nistar</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.Nistar + "</label>";
                div = div + "</div>";
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
            objmodel.UserId = Created_By;
            objlistmodel = await _objILeaseAreaModel.GetLeaseAreaLogDetails(objmodel);
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
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Area <small>(in Hectare)</small></label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.AREA_IN_HECT + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Toposheet Number</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.TOPOSHEET_NO + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Co-ordinates of all Pillars</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.FILE_COORDINATES_PILLARS + "";
                if (item.FILE_COORDINATES_PILLARS != null && item.FILE_COORDINATES_PILLARS != "")
                {
                    div = div + "<a href='" + @Url.Content("~/" + item.PATH_COORDINATES_PILLARS) + "' class='ml-2' data-original-title='Download' target='_blank'><i class='icon-file-excel-solid h5 text-success'></i></a></label>";
                }
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Lease Area Map</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.FILE_LEASE_AREA_MAP + "";
                if (item.FILE_LEASE_AREA_MAP != null && item.FILE_LEASE_AREA_MAP != "")
                {
                    div = div + "<a href='" + @Url.Content("~/" + item.PATH_LEASE_AREA_MAP) + "' class='ml-2' data-original-title='Download' target='_blank'></a></label>";
                }
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Demarcation</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_NAME + "";
                if (item.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_NAME != null && item.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_NAME != "")
                {
                    div = div + "<a href='" + @Url.Content("~/" + item.DEMARCATION_REPORT_DGPS_GPS_TOTAL_STATION_SURVEY_REPORT_COORDINATES_FILE_PATH) + "' class='ml-2' data-original-title='Download' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                }
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Date Of Working Permission</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.WORKING_PERMISSION_DATE + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Working permission Copy</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.WORKING_PERMISSION_COPY_NAME + "";
                if (item.WORKING_PERMISSION_COPY_NAME != null && item.WORKING_PERMISSION_COPY_NAME != "")
                {
                    div = div + "<a href='" + @Url.Content("~/" + item.WORKING_PERMISSION_COPY_PATH) + "' class='ml-2' data-original-title='Download' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                }
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Agreement Date</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.DATE_OF_EXECUTION + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Remarks</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.Remarks + "</label>";
                div = div + "</div>";
                div = div + "</div>";
                div = div + "</div>";
                div = div + "</li>";
            }
            return div;
        }
        /// <summary>
        /// To bind Lease Location Land Table Details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public async Task<string> LeaseLocationLandTable(int? Created_By)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            //profile.MineralTypeName = "Major Mineral";
            string div = "";
            objmodel.UserId = Created_By;
            objlistmodel = await _objILeaseAreaModel.GetLeaseAreaLogDetails(objmodel);
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
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>District</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.LEASELAND_DISRICT_NAME + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Block</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.LEASELAND_BLOCK_NAME + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Village</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.LEASELAND_VILLAGE_NAME + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Gram Panchayat</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.LEASELAND_DISRICT_NAME + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Patwari Circle Number</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.LEASELAND_BASRA_NO + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Patwari Halka Number</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.LEASELAND_DHARANADIKAR + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Khasra No </label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.LEASELAND_KHASRA_NO + "</label>";
                div = div + "</div>";
                if (profile.MineralTypeName != "Minor Mineral")
                {
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>AreaType/Land Information</label>";
                    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.LEASELAND_AREA_TYPE + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Area/Rakaba <small>(in Hectare)</small></label>";
                    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.LEASELAND_AREA + "</label>";
                    div = div + "</div>";
                }
                if (profile.MineralTypeName == "Minor Mineral")
                {
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Forest <small>(in Hectare)</small></label>";
                    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.Forest + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Revenue Forest <small>(in Hectare)</small></label>";
                    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.RevenueForest + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Revenue Government Land <small>(in Hectare)</small></label>";
                    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.RevenueGovernmentLand + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Private Tribal <small>(in Hectare)</small></label>";
                    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.PrivateTribal + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Private Non Tribal <small>(in Hectare)</small></label>";
                    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.PrivateNonTribal + "</label>";
                    div = div + "</div>";
                }
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Surface Right Area <small>(in Hectare)</small></label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.LEASELAND_SURFACE_RIGHT_AREA + "</label>";
                div = div + "</div>";
                if (profile.MineralTypeName != "Minor Mineral")
                {
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Map</label>";
                    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.LEASELAND_MAP + "</label>";
                    div = div + "</div>";
                }
                div = div + "</div>";
                div = div + "</div>";
                div = div + "</li>";
            }
            return div;
        }
        #region Binddropdowns
        /// <summary>
        /// To Bind the State Details data in view
        /// </summary>
        /// <param name="STATE_ID"></param>
        /// <returns></returns>
        private async Task<SelectList> GetStateList(int? StateId)
        {
            objlistmodel = await _objILeaseAreaModel.GetStateList(objmodel);
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
                objmodel.StateId = StateId;
                objlistmodel = await _objILeaseAreaModel.GetDistrictList(objmodel);
                return Json(objlistmodel);
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
        /// To bind Tehsil Dropdown based on DistrictId
        /// </summary>
        /// <param name="DistrictId"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetTehsildetailsByDistrictId(int? DistrictId)
        {
            try
            {
                objmodel.DistrictId = DistrictId;
                objlistmodel = await _objILeaseAreaModel.GetTehsilList(objmodel);
                return Json(objlistmodel);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objmodel = null;
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
                objmodel.TehsilID = TehsilID;
                objlistmodel = await _objILeaseAreaModel.GetVillageList(objmodel);
                return Json(objlistmodel);
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
        /// To bind Lease Land District Dropdown based on StateId
        /// </summary>
        /// <param name="StateId"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetLeaseLandDistrictdetailsByRegionId(int? StateId)
        {
            try
            {
                objmodel.StateId = StateId;
                objlistmodel = await _objILeaseAreaModel.GetLeaseLandDistrictList(objmodel);
                return Json(objlistmodel);
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
        /// To bind Village Dropdown based on TehsilID
        /// </summary>
        /// <param name="TehsilID"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetLeaseLandVillagedetailsByTehsilId(int? TehsilID)
        {
            try
            {
                objmodel.TehsilID = TehsilID;
                objlistmodel = await _objILeaseAreaModel.GetLeaseLandVillageList(objmodel);
                return Json(objlistmodel);
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
        /// To bind Block Dropdown based on DistrictId
        /// </summary>
        /// <param name="DistrictId"></param>
        /// <returns></returns>
        public JsonResult GetBlockdetailsByDistrictId(int? DistrictId)
        {
            try
            {
                objBlockmodel.DistrictId = DistrictId;
                objlistBlockmodel = _objIBlockModel.View(objBlockmodel);
                return Json(objlistBlockmodel);
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
        /// To Bind the Land Details data in view
        /// </summary>
        /// <param name="LandId"></param>
        /// <returns></returns>
        private async Task<SelectList> GetLandList(int? LandId)
        {
            objlistmodel = await _objILeaseAreaModel.GetLandList(objmodel);
            return new SelectList(objlistmodel, "LAND_ID", "LEASELAND_AREA_TYPE", LandId);
        }
        /// <summary>
        /// To bind Lease Land Block Dropdown based on DistrictId
        /// </summary>
        /// <param name="DistrictId"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetLeaseLandBlockdetailsByDistrictId(int? DistrictId)
        {
            try
            {
                objmodel.LEASELAND_DISRICT_ID = DistrictId;
                objlistmodel = await _objILeaseAreaModel.GetLeaseLandBlockList(objmodel);
                return Json(objlistmodel);
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
        /// To Bind the Vidhan Sabha Details data in view
        /// </summary>
        /// <returns></returns>
        private SelectList GetVidhanSabhaList()
        {
            objlistmodel = _objILeaseAreaModel.GetVidhanSabhaList(objmodel);
            return new SelectList(objlistmodel, "VidhanSabhaId", "VidhanSabha");
        }
        /// <summary>
        /// To Bind the Lok Sabha Details data in view
        /// </summary>
        /// <returns></returns>
        private SelectList GetLokSabhaList()
        {
            objlistmodel =  _objILeaseAreaModel.GetLokSabhaList(objmodel);
            return new SelectList(objlistmodel, "LokSabhaId", "LokSabha");
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ViewKml()
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.CREATED_BY = profile.UserId;
                objmodel = await _objILeaseAreaModel.GetLeaseAreaDetails(objmodel);
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
        public IActionResult Index(IFormFile postedFile)
        {
            if (postedFile != null)
            {
                string path = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadPillarCoordinatesPath"));
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                //Save the uploaded Excel file.
                string fileName = Path.GetFileName(postedFile.FileName);
                string filePath = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                //Read the connection string for the Excel file.
                string conString = configuration.GetSection("ConnectionStrings").GetValue<string>("ExcelConString");
                DataTable dt = new DataTable();
                conString = string.Format(conString, filePath);

                using (OleDbConnection connExcel = new OleDbConnection(conString))
                {
                    using (OleDbCommand cmdExcel = new OleDbCommand())
                    {
                        using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                        {
                            cmdExcel.Connection = connExcel;
                            //Get the name of First Sheet.
                            connExcel.Open();
                            DataTable dtExcelSchema;
                            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            //string sheetName = dtExcelSchema.Rows[0]["Sheet1"].ToString();
                            connExcel.Close();
                            //Read Data from First Sheet.
                            connExcel.Open();
                            cmdExcel.CommandText = "SELECT * From [Sheet1$]";
                            odaExcel.SelectCommand = cmdExcel;
                            odaExcel.Fill(dt);
                            connExcel.Close();
                        }
                    }
                }
                //Insert the Data read from the Excel file to Database Table.
                conString = configuration.GetSection("ConnectionStrings").GetValue<string>("CIMSConnectionString");
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name.
                        sqlBulkCopy.DestinationTableName = "[dbo].[LESSEE_LEASEAREA_PILLARS]";

                        //[OPTIONAL]: Map the Excel columns with that of the database table.
                        //sqlBulkCopy.ColumnMappings.Add("GEOFENCE_NAME", "GEOFENCE_NAME");
                        //sqlBulkCopy.ColumnMappings.Add("LATITUDE", "LATITUDE");
                        //sqlBulkCopy.ColumnMappings.Add("LONGITUDE", "LONGITUDE");
                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                    }
                }
            }
            return View();
        }
    }
}
