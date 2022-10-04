// ***********************************************************************
//  Controller Name          : LesseeGrantOrderDetailsController
//  Description              : Lessee Grant Order View Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 16 July 2021
// ***********************************************************************
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.Areas.LesseeProfile.Models.GrantOrderDetails;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MasterApp.Web;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.MineralUnit;
using MasterApp.Areas.LesseeProfile.Models.EnvironmentClearanceDetails;
using System.Data;
using Microsoft.AspNetCore.Http;

namespace MasterApp.Areas.LesseeProfile.Controllers
{
    [Area("LesseeProfile")]
    public class LesseeGrantOrderDetailsController : Controller
    {
        /// <summary>
        /// Global Variable,object declaration
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        ILesseeGrantOrderModel _objLesseeGrantOrderModel;
        IMineralUnitModel _objIMineralUnitModel;
        ILesseEnvironmentClearanceModel _objILesseEnvironmentClearanceModel;
        GrantOrderViewModel objmodel = new GrantOrderViewModel();
        MineralUnitmaster objmumodel = new MineralUnitmaster();
        MiningProductionModel pmodel = new MiningProductionModel();
        LesseeEnvironmentClearanceViewModel objecmodel = new LesseeEnvironmentClearanceViewModel();
        List<GrantOrderViewModel> objlistmodel = new List<GrantOrderViewModel>();
        List<GrantOrderViewModel> objlistmodelview = new List<GrantOrderViewModel>();
        List<MineralUnitmaster> objmulistmodel = new List<MineralUnitmaster>();
        List<MiningProductionModel> pmodellist = new List<MiningProductionModel>();
        MessageEF objobjmodel = new MessageEF();
        string uniqueFileName = string.Empty;
        string filePath = string.Empty;
        string ExtensionId = string.Empty;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objLesseeGrantOrderModel"></param>
        /// <param name="hostingEnvironment"></param>
        /// <param name="configuration"></param>
        /// <param name="objIMineralUnitModel"></param>
        /// <param name="objILesseEnvironmentClearanceModel"></param>
        public LesseeGrantOrderDetailsController(ILesseeGrantOrderModel objLesseeGrantOrderModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration, IMineralUnitModel objIMineralUnitModel, ILesseEnvironmentClearanceModel objILesseEnvironmentClearanceModel)
        {
            _objLesseeGrantOrderModel = objLesseeGrantOrderModel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
            _objIMineralUnitModel = objIMineralUnitModel;
            _objILesseEnvironmentClearanceModel = objILesseEnvironmentClearanceModel;
        }
        /// <summary>
        /// HTTP GET method of Grant
        /// </summary>
        /// <returns></returns>
        [Decryption]
        public async Task<IActionResult> Grant(string id = "0")
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                profile.MineralTypeName = "Major Mineral";
                if (id == "0")
                {
                    objmodel.UserId = profile.UserId;
                }
                else
                {
                    objmodel.UserId = Convert.ToInt32(id);
                }
                ViewBag.Auctiontype = await GetAuctiontype(null);
                ViewBag.tableLA = await Tables(objmodel.UserId, profile.MineralTypeName);
                objmodel = await _objLesseeGrantOrderModel.GetGrantOrderDetails(objmodel);
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
        public async Task<IActionResult> Grant(GrantOrderViewModel objmodel, string cmd, string delete, IFormCollection collection)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserId = profile.UserId;
            ExtensionId = Convert.ToString(objmodel.UserId);
            objmodel.IsMinesSection = objmodel.Mines_Section == "Yes" ? 1 : 2;
            #region Add data to datatable
            DataTable dt = new DataTable("LESSEE_FY_YEAR_WISE_APPROVEDCTOQUANTITY");
            //we create column names as per the type in DB 
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("YEAR", typeof(string));
            dt.Columns.Add("PRODUCTION", typeof(decimal));
            dt.Columns.Add("UNIT_ID", typeof(Int32));
            dt.Columns.Add("CREATED_BY", typeof(Int32));
            string[] YEAR = collection["YEAR"].ToString().Split(char.Parse(","));
            string[] PRODUCTIONS = collection["PRODUCTIONS"].ToString().Split(char.Parse(","));
            string[] UNIT_ID = collection["UNIT_ID"].ToString().Split(char.Parse(","));
            for (int i = 0; i < YEAR.Length; i++)
            {
                if (string.IsNullOrEmpty(YEAR[i].ToString()) == false)
                {
                    dt.Rows.Add(i + 1, YEAR[i], PRODUCTIONS[i], UNIT_ID[i], objmodel.CREATED_BY);
                }
            }
            objmodel.dtFYApprovedQuantity = dt;
            #endregion     
            try
            {
                #region Validation
                if (string.IsNullOrEmpty(objmodel.GRANT_ORDER_NUMBER))
                {
                    ModelState.AddModelError("GRANT_ORDER_NUMBER", "Order Number field is required");
                }
                if (string.IsNullOrEmpty(objmodel.GRANT_ORDER_DATE))
                {
                    ModelState.AddModelError("GRANT_ORDER_DATE", "Order date field is required");
                }
                if (string.IsNullOrEmpty(objmodel.LEASE_PERIOD))
                {
                    ModelState.AddModelError("LEASE_PERIOD", "Lease Period field is required");
                }
                if (string.IsNullOrEmpty(objmodel.FROM_VALIDITY))
                {
                    ModelState.AddModelError("FROM_VALIDITY", "Lease Validity From field is required");
                }
                if (string.IsNullOrEmpty(objmodel.TO_VALIDITY))
                {
                    ModelState.AddModelError("TO_VALIDITY", "Lease Validity To field is required");
                }
                if (string.IsNullOrEmpty(objmodel.MDPA_GRANT_ORDER_NUMBER) && profile.MineralTypeName != "Minor Mineral")
                {
                    ModelState.AddModelError("MDPA_GRANT_ORDER_NUMBER", "MDPA Grant Order Number field is required");
                }
                if (string.IsNullOrEmpty(objmodel.MDPA_GRANT_ORDER_DATE) && profile.MineralTypeName != "Minor Mineral")
                {
                    ModelState.AddModelError("MDPA_GRANT_ORDER_DATE", "MDPA Grant Order Date field is required");
                }
                if (string.IsNullOrEmpty(objmodel.MDPA_GRANT_AGREEMENT_DATE) && profile.MineralTypeName != "Minor Mineral")
                {
                    ModelState.AddModelError("MDPA_GRANT_AGREEMENT_DATE", "Agreement Date field is required");
                }
                #endregion
                //var error = ModelState.Values.SelectMany(v => v.Errors).ElementAt(0);
                if (ModelState.IsValid)
                {
                    #region File Upload
                    if (objmodel.GRANT_ORDER_COPY != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.GRANT_ORDER_COPY.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadGrantOrderPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadGrantOrderPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.GRANT_ORDER_COPY.CopyTo(fileStream);
                        objmodel.FILE_GRANT_ORDER_COPY = uniqueFileName;
                        objmodel.PATH_GRANT_ORDER_COPY = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.EXECUTION_OF_DEED_COPY != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.EXECUTION_OF_DEED_COPY.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadLeaseDeedPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadLeaseDeedPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.EXECUTION_OF_DEED_COPY.CopyTo(fileStream);
                        objmodel.FILE_EXECUTION_OF_DEED_COPY = uniqueFileName;
                        objmodel.PATH_EXECUTION_OF_DEED_COPY = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.GRANT_MDPA_COPY != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.GRANT_MDPA_COPY.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadMDPAPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadMDPAPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.GRANT_MDPA_COPY.CopyTo(fileStream);
                        objmodel.FILE_MDPA_COPY = uniqueFileName;
                        objmodel.PATH_MDPA_COPY = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.LEASEEXTENSION_ORDER_COPY != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.LEASEEXTENSION_ORDER_COPY.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadLeaseExtensionPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadLeaseExtensionPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.LEASEEXTENSION_ORDER_COPY.CopyTo(fileStream);
                        objmodel.FILE_LEASEEXTENSION = uniqueFileName;
                        objmodel.PATH_LEASEEXTENSION = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.ALLOTTMENT_ORDER_COPY != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.ALLOTTMENT_ORDER_COPY.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadAllottmentPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadAllottmentPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.ALLOTTMENT_ORDER_COPY.CopyTo(fileStream);
                        objmodel.FILE_ALLOTTMENT = uniqueFileName;
                        objmodel.PATH_ALLOTTMENT = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.DEMARCATION_COPY != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.DEMARCATION_COPY.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadDemarcationPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadDemarcationPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.DEMARCATION_COPY.CopyTo(fileStream);
                        objmodel.FILE_DEMARCATION_COPY = uniqueFileName;
                        objmodel.PATH_DEMARCATION_COPY = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    objmodel.GRANT_ORDER_COPY = null;
                    objmodel.EXECUTION_OF_DEED_COPY = null;
                    objmodel.GRANT_MDPA_COPY = null;
                    objmodel.LEASEEXTENSION_ORDER_COPY = null;
                    objmodel.ALLOTTMENT_ORDER_COPY = null;
                    objmodel.DEMARCATION_COPY = null;
                    #endregion
                    var checkDMO = "Forward To DD";
                    if (objmodel.SubResion == "Forward To DD")
                    {
                        cmd = "Forward To DD";
                    }
                    if (checkDMO == cmd)
                    {
                        objmodel.STATUS = 1;
                        objobjmodel = _objLesseeGrantOrderModel.UpdateGrantOrderDetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Lessee Grant Order Details forwarded to DD/DMO successfully";
                        }
                        else if (objobjmodel.Satus == "2")
                        {
                            TempData["Message"] = "Lessee Grant Order Details forwarded to DD/DMO successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while forwarding Lessee Grant Order Details to DD/DMO";
                        }
                    }
                    else if (delete == "Delete")
                    {
                        objobjmodel = _objLesseeGrantOrderModel.DeleteLesseeGrantOrderDetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Lessee Grant Order Details Deleted Sucessfully.";
                        }
                        else
                        {
                            TempData["Message"] = "Lessee Grant Order Details not Deleted Sucessfully.";
                        }
                    }
                    else
                    {
                        objmodel.STATUS = 0;
                        objobjmodel = _objLesseeGrantOrderModel.UpdateGrantOrderDetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Lessee Grant Order Details Saved successfully";
                        }
                        else if (objobjmodel.Satus == "2")
                        {
                            TempData["Message"] = "Lessee Grant Order  Details Updated successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while Updating Lessee Grant Order Details";
                        }

                    }
                    return RedirectToAction("Grant", "LesseeGrantOrderDetails", new { Area = "LesseeProfile" });
                }
                else
                {
                    ViewBag.Auctiontype = await GetAuctiontype(null);
                    objmodel = await _objLesseeGrantOrderModel.GetGrantOrderDetails(objmodel);
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
                    objmodel.UserId = Convert.ToInt32(UserId);
                }
                else
                {
                    objmodel.UserId = profile.UserId;
                }
                //profile.MineralTypeName = "Major Mineral";
                //profile.MineralName = "NON COAL";
                objmodel = await _objLesseeGrantOrderModel.GetGrantOrderDetails(objmodel);
                ViewBag.tableLA = await GrantOrderLeaseTable(objmodel.CREATED_BY, profile.MineralTypeName, profile.MineralName);
                ViewBag.tableLB = await MDPTable(objmodel.CREATED_BY, profile.MineralName);
                ViewBag.tableLC = await LeaseExtensionTable(objmodel.CREATED_BY);
                ViewBag.tableLD = await NoncaptiveTable(objmodel.CREATED_BY);
                ViewBag.tableLE = await MineralQuantityTable(objmodel.CREATED_BY, "Log");
                ViewBag.tableLF = await MineralQuantityTable(objmodel.CREATED_BY, "");
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
        /// To bind Grant Order Log Details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public async Task<string> GrantOrderLeaseTable(int? Created_By, string MineralTypeName, string MineralName)
        {
            string div = "";
            objmodel.UserId = Created_By;
            objlistmodel = await _objLesseeGrantOrderModel.GetGrantOrderLogDetails(objmodel);
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
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Order Number</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.GRANT_ORDER_NUMBER + "";
                if (item.FILE_GRANT_ORDER_COPY != null && item.FILE_GRANT_ORDER_COPY != "")
                {
                    div = div + "<a href='" + @Url.Content("~/" + item.PATH_GRANT_ORDER_COPY) + "' class='ml-2' data-original-title='Download Grant Order' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                }
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Order Date</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.GRANT_ORDER_DATE + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Lease Validity From</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.FROM_VALIDITY + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Lease Validity Upto</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.TO_VALIDITY + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Lease Deed No.</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.EXECUTION_OF_DEED_NUMBER + "";
                if (item.FILE_EXECUTION_OF_DEED_COPY != null && item.FILE_EXECUTION_OF_DEED_COPY != "")
                {
                    div = div + "<a href='" + @Url.Content("~/" + item.PATH_EXECUTION_OF_DEED_COPY) + "' class='ml-2' data-original-title='Download Execution Deed' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                }
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Lease Deed Date</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.EXECUTION_OF_DEED_DATE + "</label>";
                div = div + "</div>";
                if (MineralTypeName == "Minor Mineral")
                {
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Demarcation Copy</label>";
                    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.FILE_DEMARCATION_COPY + "";
                    if (item.FILE_DEMARCATION_COPY != null && item.FILE_DEMARCATION_COPY != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.PATH_DEMARCATION_COPY) + "' class='ml-2' data-original-title='Download Demarcation Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                }
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Lease Period (In Years)</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.LEASE_PERIOD + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Remarks</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.Remarks + "</label>";
                div = div + "</div>";
                if (MineralTypeName != "Minor Mineral")/*Show only for Minor Lessee Users*/
                {
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Mines Allotted As Per Act</label>";
                    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.MinesAlloted + "</label>";
                    div = div + "</div>";
                    if (item.MinesAlloted == "MMDR")
                    {
                        div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Mines Under Section(17A) ?</label>";
                        div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div = div + "<span class='colon'>:</span>" + item.Mines_Section + "</label>";
                        div = div + "</div>";
                        if (item.Mines_Section == "Yes")
                        {
                            div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Mines Section</label>";
                            div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                            div = div + "<span class='colon'>:</span>" + item.MinesSection + "</label>";
                            div = div + "</div>";
                        }
                    }
                    if (MineralName.ToUpper() == "COAL") /*Show only for Coal Major Lessee Users*/
                    {
                        div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Type of Mines</label>";
                        div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div = div + "<span class='colon'>:</span>" + item.MinesType + "</label>";
                        div = div + "</div>";
                    }
                }
                div = div + "</div>";
                div = div + "</div>";
                div = div + "</li>";
            }
            return div;
        }
        /// <summary>
        /// To bind Grant Order MDPA Log Details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public async Task<string> MDPTable(int? Created_By, string MineralName)
        {
            string div = "";
            objmodel.UserId = Created_By;
            objlistmodel = await _objLesseeGrantOrderModel.GetGrantOrderLogDetails(objmodel);
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
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Order Number</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.MDPA_GRANT_ORDER_NUMBER + "";
                if (item.FILE_MDPA_COPY != null && item.FILE_MDPA_COPY != "")
                {
                    div = div + "<a href='" + @Url.Content("~/" + item.PATH_MDPA_COPY) + "' class='ml-2' data-original-title='Download MDPA Order' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                }
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Order Date</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.MDPA_GRANT_ORDER_DATE + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Agreement Date</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.MDPA_GRANT_AGREEMENT_DATE + "</label>";
                div = div + "</div>";
                if (MineralName.ToUpper() == "COAL")/*Show only for Coal Major Lessee Users*/
                {
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Final Offer <small>(Revenue Sharing in %)</small></label>";
                    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.FINAL_OFFER + "</label>";
                    div = div + "</div>";
                }
                div = div + "</div>";
                div = div + "</div>";
                div = div + "</li>";
            }
            return div;
        }
        /// <summary>
        /// To bind Grant Order MDPA Log Details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public async Task<string> LeaseExtensionTable(int? Created_By)
        {
            string div = "";
            objmodel.UserId = Created_By;
            objlistmodel = await _objLesseeGrantOrderModel.GetGrantOrderLogDetails(objmodel);
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
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Application Type</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.AuctionName + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Lease Extended as per MMDR Amendment 2021</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.LeaseExtender + "</label>";
                div = div + "</div>";
                if (item.LeaseExtender == "Yes")
                {
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Lease Extension Validity From</label>";
                    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.LEASEEXTENSION_FROM_VALIDITY + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Lease Extension Validity Upto</label>";
                    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.LEASEEXTENSION_TO_VALIDITY + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Lease Extension Document</label>";
                    div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.FILE_LEASEEXTENSION + "";
                    if (item.FILE_LEASEEXTENSION != null && item.FILE_LEASEEXTENSION != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.PATH_LEASEEXTENSION) + "' class='ml-2' data-original-title='Download MDPA Order' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                }
                div = div + "</div>";
                div = div + "</div>";
                div = div + "</li>";
            }
            return div;
        }
        /// <summary>
        /// To bind Grant Order MDPA Log Details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public async Task<string> NoncaptiveTable(int? Created_By)
        {
            string div = "";
            objmodel.UserId = Created_By;
            objlistmodel = await _objLesseeGrantOrderModel.GetGrantOrderLogDetails(objmodel);
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
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Mineral Sale Percentage </label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.MineralSalePercentage + "</label>";
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Tender/Allotment Document </label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.FILE_ALLOTTMENT + "</label>";
                if (item.FILE_ALLOTTMENT != null && item.FILE_ALLOTTMENT != "")
                {
                    div = div + "<a href='" + @Url.Content("~/" + item.PATH_ALLOTTMENT) + "' class='ml-2' data-original-title='Download Allottment Order' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                }
                div = div + "</div>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Amount/Percentage</label>";
                div = div + "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + item.AllotmentAmount + "</label>";
                div = div + "</div>";
                div = div + "</div>";
                div = div + "</div>";
                div = div + "</li>";
            }
            return div;
        }
        /// <summary>
        /// To Compare Lessee Grant Order Request Data in view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public async Task<IActionResult> CompareGrantOrderDetails(string id = "0")
        {
            try
            {
                objmodel.UserId = Convert.ToInt32(id);          
                objlistmodel = await _objLesseeGrantOrderModel.GetGrantOrderCompareDetails(objmodel);
                ViewBag.tableLA = await CompareTable(Convert.ToInt32(id));
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
        /// To Approve,Reject Lessee Grant Order Profile Request Data in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult CompareGrantOrderDetails(GrantOrderViewModel objmodel)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserLoginId = profile.UserLoginId;
                if (objmodel.SubApprove == "Approve")
                {
                    objobjmodel = _objLesseeGrantOrderModel.ApproveLesseeGrantOrderDetails(objmodel);
                }
                else
                {
                    objobjmodel = _objLesseeGrantOrderModel.RejectLesseeGrantOrderDetails(objmodel);
                }
                if (objobjmodel.Satus == "1")
                {
                    TempData["Message"] = "Lessee Grant Order Details Approved successfully";
                }
                else if (objobjmodel.Satus == "2")
                {
                    TempData["Message"] = "Lessee Grant Order Details Rejected successfully";
                }
                else
                {
                    TempData["Message"] = "Error ! while " + objmodel.SubApprove + " Lessee Grant Order Details";
                }
                string EncryptUrl = CustomQueryStringHelper.EncryptString("LesseeProfile", "CompareGrantOrderDetails", "LesseeGrantOrderDetails", new { id = objmodel.CREATED_BY });
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
        /// To Bind the Auction Type Details data in view
        /// </summary>
        /// <param name="AuctionTypeId"></param>
        /// <returns></returns>
        private async Task<SelectList> GetAuctiontype(int? AuctionTypeId)
        {
            List<GrantOrderViewModel> listAuctionTypeResult = new List<GrantOrderViewModel>();
            listAuctionTypeResult = await _objLesseeGrantOrderModel.GetAuctionTypeList(objmodel);
            return new SelectList(listAuctionTypeResult, "AuctionTypeId", "AuctionName", AuctionTypeId);
        }
        /// <summary>
        /// Bind Financial Year wise mineral quantity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> Tables(int? id, string MineralType)
        {
            try
            {
                string tbl = "";
                pmodel.CREATED_BY = id;
                objmodel.Product = await _objLesseeGrantOrderModel.GetLesseeGrantOrderApprovedQuantityCompareDetails(pmodel);
                string tbl2 = "";
                tbl2 = "<table id='MiningPlanTable' class='table table-sm table-bordered mb-0'>";
                tbl2 = tbl2 + "<thead>";
                tbl2 = tbl2 + "<tr>";
                tbl2 = tbl2 + "<th width='40px' class='font-weight-bolder'>Sl#</th><th> Year </th><th> Approved Quantity </th><th> Unit </th>";
                tbl2 = tbl2 + "</tr>";
                tbl2 = tbl2 + "</thead>";
                tbl2 = tbl2 + "<tbody>";
                int colLA = 1;
                foreach (var item in objmodel.Product)
                {
                    tbl2 = tbl2 + "<tr>";
                    tbl2 = tbl2 + "<td>" + colLA + "</td>";
                    tbl2 = tbl2 + "<td>";
                    tbl2 = tbl2 + "<select class='form-control' id='YEAR' name='YEAR'>";
                    tbl2 = tbl2 + "<option value='0'>--select--</option>";
                    List<LesseeEnvironmentClearanceViewModel> AreaType = new List<LesseeEnvironmentClearanceViewModel>();
                    AreaType = await _objILesseEnvironmentClearanceModel.GetFYDetails(objecmodel);
                    foreach (var item2 in AreaType)
                    {
                        if (item2.YEAR == item.YEAR)
                        {
                            tbl2 = tbl2 + "<option value=" + item2.YEAR + " selected='selected'>" + item2.YEAR + "</option>";
                        }
                        else
                        {
                            tbl2 = tbl2 + "<option value=" + item2.YEAR + ">" + item2.YEAR + "</option>";
                        }
                    }
                    tbl2 = tbl2 + "</select>";
                    tbl2 = tbl2 + "</td>";
                    tbl2 = tbl2 + "<td>";
                    tbl2 = tbl2 + "<input class='form-control' name='PRODUCTIONS' value='" + string.Format("{0:0.00}", item.PRODUCTION) + "'>";
                    tbl2 = tbl2 + "</td>";
                    tbl2 = tbl2 + "<td>";
                    if (MineralType == "Major Mineral")
                    {
                        tbl2 = tbl2 + "<select class='form-control' id='UNIT_ID' name='UNIT_ID' style='pointer-events: none;'>";
                        tbl2 = tbl2 + "<option value='3'>Metric Tonne</option>";
                        //objmulistmodel = _objIMineralUnitModel.ViewLesseeUnit(objmumodel);
                        //foreach (var item3 in objmulistmodel)
                        //{
                        //    if (item3.MineralUnitID == item.UNIT_ID)
                        //    {
                        //        tbl2 = tbl2 + "<option value=" + item3.MineralUnitID + " selected='selected'>" + item3.MineralUnitName + "</option>";
                        //    }
                        //    else
                        //    {
                        //        tbl2 = tbl2 + "<option value=" + item3.MineralUnitID + ">" + item3.MineralUnitName + "</option>";
                        //    }
                        //}
                        tbl2 = tbl2 + "</select>";
                        tbl2 = tbl2 + "</td>";
                    }
                    else
                    {
                        tbl2 = tbl2 + "<select class='form-control' id='UNIT_ID' name='UNIT_ID'>";
                        tbl2 = tbl2 + "<option value='0'>--select--</option>";
                        objmulistmodel = _objIMineralUnitModel.ViewLesseeUnit(objmumodel);
                        foreach (var item3 in objmulistmodel)
                        {
                            if (item3.MineralUnitID == item.UNIT_ID)
                            {
                                tbl2 = tbl2 + "<option value=" + item3.MineralUnitID + " selected='selected'>" + item3.MineralUnitName + "</option>";
                            }
                            else
                            {
                                tbl2 = tbl2 + "<option value=" + item3.MineralUnitID + ">" + item3.MineralUnitName + "</option>";
                            }
                        }
                        tbl2 = tbl2 + "</select>";
                        tbl2 = tbl2 + "</td>";
                    }
                    //tbl2 = tbl2 + "<option value='0'>--select--</option>";
                    //objmulistmodel = _objIMineralUnitModel.ViewLesseeUnit(objmumodel);
                    //foreach (var item3 in objmulistmodel)
                    //{
                    //    if (item3.MineralUnitID == item.UNIT_ID)
                    //    {
                    //        tbl2 = tbl2 + "<option value=" + item3.MineralUnitID + " selected='selected'>" + item3.MineralUnitName + "</option>";
                    //    }
                    //    else
                    //    {
                    //        tbl2 = tbl2 + "<option value=" + item3.MineralUnitID + ">" + item3.MineralUnitName + "</option>";
                    //    }
                    //}
                    //tbl2 = tbl2 + "</select>";
                    //tbl2 = tbl2 + "</td>";
                    tbl2 = tbl2 + "<td style='border-color: black; visibility: hidden; display: none'></td>";
                    tbl2 = tbl2 + "</tr>";
                    colLA++;
                }
                tbl2 = tbl2 + "</tbody>";
                tbl2 = tbl2 + "</table>";
                tbl = tbl2;
                return tbl;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objlistmodel = null;
                objecmodel = null;
                pmodel = null;
            }
        }
        /// <summary>
        /// Bind Financial Year wise mineral quantity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> CompareTable(int? id)
        {
            try
            {
                string tbl = "";
                pmodel.CREATED_BY = id;
                objmodel.Product = await _objLesseeGrantOrderModel.GetLesseeGrantOrderApprovedQuantityCompareDetails(pmodel);
                pmodellist = await _objLesseeGrantOrderModel.GetApprovedQuantityDetails(pmodel);
                string tbl2 = "";
                tbl2 = "<table id='datatable' class='table table-sm table-bordered compare'>";
                tbl2 = tbl2 + "<thead>";
                tbl2 = tbl2 + "<tr>";
                tbl2 = tbl2 + "<th>Field Names</th><th>Existing Data</th><th>Modified Data</th><th></th>";
                tbl2 = tbl2 + "</tr>";
                tbl2 = tbl2 + "</thead>";
                tbl2 = tbl2 + "<tbody>";
                int count = objmodel.Product.Count > pmodellist.Count ? objmodel.Product.Count : pmodellist.Count;
                int colLA = 0;
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < count; j++)
                    {
                        int k = 1;
                        j = colLA;
                        if (tbl2.Contains("Year"))
                        {
                            tbl2 = tbl2 + "<tr>";
                            tbl2 = tbl2 + "<td></td>";
                        }
                        else
                        {
                            tbl2 = tbl2 + "<tr>";
                            tbl2 = tbl2 + "<td class='field-name'>Year</td>";
                        }
                        if (i <= objmodel.Product.Count - 1)
                            tbl2 = tbl2 + "<td>" + objmodel.Product[i].YEAR + "</td>";
                        else
                            tbl2 = tbl2 + "<td>--</td>";
                        if (j <= pmodellist.Count - 1)
                            tbl2 = tbl2 + "<td>" + pmodellist[j].YEAR + "</td>";
                        else
                            tbl2 = tbl2 + "<td>--</td>";
                        if (i <= objmodel.Product.Count - 1 && j <= pmodellist.Count - 1)
                        {
                            if (objmodel.Product[i].YEAR != pmodellist[j].YEAR)
                            {
                                tbl2 = tbl2 + "<td class='text-center'><i class='icon-arrow-alt-circle-left-solid text-danger h4'></i></td>";
                            }
                            else
                                tbl2 = tbl2 + "<td></td>";
                        }
                        else
                            tbl2 = tbl2 + "<td class='text-center'><i class='icon-arrow-alt-circle-left-solid text-danger h4'></i></td>";
                        if (k == 1)
                            break;
                    }
                    colLA++;
                }
                objmodel.Product = await _objLesseeGrantOrderModel.GetLesseeGrantOrderApprovedQuantityCompareDetails(pmodel);
                pmodellist = await _objLesseeGrantOrderModel.GetApprovedQuantityDetails(pmodel);
                colLA = 0;
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < count; j++)
                    {
                        int L = 1;
                        j = colLA;
                        if (tbl2.Contains("Approved Quantity"))
                        {
                            tbl2 = tbl2 + "<tr>";
                            tbl2 = tbl2 + "<td></td>";
                        }
                        else
                        {
                            tbl2 = tbl2 + "<tr>";
                            tbl2 = tbl2 + "<td class='field-name'>Approved Quantity</td>";
                        }
                        if (i <= objmodel.Product.Count - 1)
                            tbl2 = tbl2 + "<td>" + string.Format("{0:0.00}", objmodel.Product[i].PRODUCTION) + "</td>";
                        else
                            tbl2 = tbl2 + "<td>--</td>";
                        if (j <= pmodellist.Count - 1)
                            tbl2 = tbl2 + "<td>" + string.Format("{0:0.00}", pmodellist[j].PRODUCTION) + "</td>";
                        else
                            tbl2 = tbl2 + "<td>--</td>";
                        if (i <= objmodel.Product.Count - 1 && j <= pmodellist.Count - 1)
                        {
                            if (objmodel.Product[i].PRODUCTION != pmodellist[j].PRODUCTION)
                            {
                                tbl2 = tbl2 + "<td class='text-center'><i class='icon-arrow-alt-circle-left-solid text-danger h4'></i></td>";
                            }
                            else
                                tbl2 = tbl2 + "<td></td>";
                        }
                        else
                            tbl2 = tbl2 + "<td class='text-center'><i class='icon-arrow-alt-circle-left-solid text-danger h4'></i></td>";
                        if (L == 1)
                            break;
                    }
                    colLA++;
                }
                objmodel.Product = await _objLesseeGrantOrderModel.GetLesseeGrantOrderApprovedQuantityCompareDetails(pmodel);
                pmodellist = await _objLesseeGrantOrderModel.GetApprovedQuantityDetails(pmodel);
                colLA = 0;
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < count; j++)
                    {
                        int m = 1;
                        j = colLA;
                        if (tbl2.Contains("Unit"))
                        {
                            tbl2 = tbl2 + "<tr>";
                            tbl2 = tbl2 + "<td></td>";
                        }
                        else
                        {
                            tbl2 = tbl2 + "<tr>";
                            tbl2 = tbl2 + "<td class='field-name'>Unit</td>";
                        }
                        if (i <= objmodel.Product.Count - 1)
                            tbl2 = tbl2 + "<td>" + objmodel.Product[i].UNITNAME + "</td>";
                        else
                            tbl2 = tbl2 + "<td>--</td>";
                        if (j <= pmodellist.Count - 1)
                            tbl2 = tbl2 + "<td>" + pmodellist[j].UNITNAME + "</td>";
                        else
                            tbl2 = tbl2 + "<td>--</td>";
                        if (i <= objmodel.Product.Count - 1 && j <= pmodellist.Count - 1)
                        {
                            if (objmodel.Product[i].UNITNAME != pmodellist[j].UNITNAME)
                            {
                                tbl2 = tbl2 + "<td class='text-center'><i class='icon-arrow-alt-circle-left-solid text-danger h4'></i></td>";
                            }
                            else
                                tbl2 = tbl2 + "<td></td>";
                        }
                        else
                            tbl2 = tbl2 + "<td class='text-center'><i class='icon-arrow-alt-circle-left-solid text-danger h4'></i></td>";
                        if (m == 1)
                            break;
                    }
                    colLA++;
                }
                tbl2 = tbl2 + "</tbody>";
                tbl2 = tbl2 + "</table>";
                tbl = tbl2;
                return tbl;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objmodel = null;
                pmodellist = null;
            }
        }
        /// <summary>
        /// To bind Environment Clearance Log Details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public async Task<string> MineralQuantityTable(int? Created_By, string type)
        {
            string div = "";
            objmodel.CREATED_BY = pmodel.CREATED_BY = Created_By;
            if (type == "Log")
            {
                objmodel.Product = await _objLesseeGrantOrderModel.GetLesseeGrantOrderApprovedQuantityCompareDetails(pmodel);
                foreach (var item in objmodel.Product)
                {
                    div += "<div class='row'>";
                    div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Year</label>";
                    div += "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div += "<span class='colon'>:</span>" + item.YEAR + "</label>";
                    div += "</div>";
                    div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Approved Quantity</label>";
                    div += "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div += "<span class='colon'>:</span>" + string.Format("{0:0.00}", item.PRODUCTION) + "</label>";
                    div += "</div>";
                    div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Unit</label>";
                    div += "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div += "<span class='colon'>:</span>" + item.UNITNAME + "</label>";
                    div += "</div>";
                    div += "</div>";
                }
            }
            else
            {
                objlistmodel = await _objLesseeGrantOrderModel.GetLesseeGrantOrderApprovedQuantityLogDetails(objmodel);
                for (int i = 0; i < objlistmodel.Count; i++)
                {
                    objmodel.MODIFIED_ON = objlistmodel[i].MODIFIED_ON;
                    objmodel.GRANT_ORDER_ID = objlistmodel[i].GRANT_ORDER_ID;
                    objmodel.STATUS = objlistmodel[i].STATUS;
                    div += "<li class='timeline-item'>";
                    div += "<div class='date-box'>";
                    div += "<p><span class='date'>" + objlistmodel[i].ModifyDate + "</span><span class='month-year'>" + objlistmodel[i].ModifyYear + "</span></p>";
                    div += "</div>";                   
                    if (objlistmodel[i].STATUS == 2) //Approved
                    {
                        div = div + "<div class='message-highlighter approved'>";
                    }
                    else if (objlistmodel[i].STATUS == 1) //Forwarded
                    {
                        div = div + "<div class='message-highlighter forwarded'>";
                    }
                    else if (objlistmodel[i].STATUS == 3) //Rejected
                    {
                        div = div + "<div class='message-highlighter rejected'>";
                    }
                    else //Draft
                    {
                        div = div + "<div class='message-highlighter draft'>";
                    }

                    div += "<div class='row'>";                  
                    objlistmodelview = await _objLesseeGrantOrderModel.GetLesseeGrantOrderApprovedQuantityLogDetailsView(objmodel);
                    foreach (var item in objlistmodelview)
                    {
                        div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Year</label>";
                        div += "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div += "<span class='colon'>:</span>" + item.YEAR + "</label>";
                        div += "</div>";
                        div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Approved Quantity</label>";
                        div += "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div += "<span class='colon'>:</span>" + item.PRODUCTIONS + "</label>";
                        div += "</div>";
                        div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Unit</label>";
                        div += "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div += "<span class='colon'>:</span>" + item.UNITNAME + "</label>";
                        div += "</div>";
                    }
                    div = div + "</div>";
                    div = div + "</div>";
                    div = div + "</li>";
                }
            }
            return div;
        }
    }
}
