// ***********************************************************************
//  Controller Name          : LesseeCTODetailsController
//  Description              : Lessee Consent To Operate View Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 29 July 2021
// ***********************************************************************
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.Areas.LesseeProfile.Models.CTODetails;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.AspNetCore.Http;
using MasterApp.Web;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.MineralUnit;

namespace MasterApp.Areas.LesseeProfile.Controllers
{
    [Area("LesseeProfile")]
    public class LesseeCTODetailsController : Controller
    {
        /// <summary>
        /// Global Variable,object declaration
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        ILesseeCTOModel _objILesseeCTOModel;
        IMineralUnitModel _objIMineralUnitModel;
        LesseeCTOViewModel objmodel = new LesseeCTOViewModel();
        List<LesseeCTOViewModel> objlistmodel = new List<LesseeCTOViewModel>();
        List<LesseeCTOViewModel> objlistmodelview = new List<LesseeCTOViewModel>();
        MiningProductionModel pmodel = new MiningProductionModel();
        List<MiningProductionModel> pmodellist = new List<MiningProductionModel>();
        MineralUnitmaster objmumodel = new MineralUnitmaster();
        List<MineralUnitmaster> objmulistmodel = new List<MineralUnitmaster>();
        MessageEF objobjmodel = new MessageEF();
        string uniqueFileName = string.Empty;
        string filePath = string.Empty;
        string ExtensionId = string.Empty;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objLesseeDetailsModel"></param>
        public LesseeCTODetailsController(ILesseeCTOModel objILesseeCTOModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration, IMineralUnitModel objIMineralUnitModel)
        {
            _objILesseeCTOModel = objILesseeCTOModel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
            _objIMineralUnitModel = objIMineralUnitModel;
        }
        /// <summary>
        /// HTTP GET method of Create Consent To Operate
        /// </summary>
        /// <returns></returns>
        [Decryption]
        public async Task<IActionResult> Create(string id = "0")
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
                objmodel = await _objILesseeCTOModel.GetCTODetails(objmodel);
                ViewBag.tableLA = await Tables(objmodel.CREATED_BY,profile.MineralTypeName);
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
        public async Task<IActionResult> Create(LesseeCTOViewModel objmodel, IFormCollection collection, string cmd, string delete)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.CREATED_BY = profile.UserId;
            objmodel.UserLoginId = profile.UserLoginId;
            ExtensionId = Convert.ToString(objmodel.CREATED_BY);
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
                if (string.IsNullOrEmpty(objmodel.CTO_ORDER_NO))
                {
                    ModelState.AddModelError("CTO_ORDER_NO", "Consent To Operate Order Number field is required");
                }
                if (string.IsNullOrEmpty(objmodel.CTO_Order_Date))
                {
                    ModelState.AddModelError("CTO_Order_Date", "Consent To Operate Order Date field is required");
                }
                if (string.IsNullOrEmpty(objmodel.CTO_VALID_FROM))
                {
                    ModelState.AddModelError("CTO_Order_Date", "Consent To Operate From Date field is required");
                }
                if (string.IsNullOrEmpty(objmodel.CTO_VALID_TO))
                {
                    ModelState.AddModelError("CTO_Order_Date", "Consent To Operate To Date field is required");
                }
                #endregion
                if (ModelState.IsValid)
                {
                    #region File Upload
                    if (objmodel.CTO_FORM_UPLOAD != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.CTO_FORM_UPLOAD.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadCTOPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadCTOPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.CTO_FORM_UPLOAD.CopyTo(fileStream);
                        objmodel.FILE_CTO_LETTER = uniqueFileName;
                        objmodel.CTO_LETTER_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    objmodel.CTO_FORM_UPLOAD = null;
                    #endregion
                    var checkDMO = "Forward To DD";
                    if (objmodel.SubResion == "Forward To DD")
                    {
                        cmd = "Forward To DD";
                    }
                    if (checkDMO == cmd)
                    {
                        objmodel.STATUS = 1;
                        objobjmodel = _objILesseeCTOModel.UpdateCTODetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Lessee Consent To Operate Details forwarded to DD/DMO successfully";
                        }
                        else if (objobjmodel.Satus == "2")
                        {
                            TempData["Message"] = "Lessee Consent To Operate Details forwarded to DD/DMO successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while forwarding Lessee Consent To Operate Details to DD/DMO";
                        }
                    }
                    else if (delete == "Delete")
                    {
                        objobjmodel = _objILesseeCTOModel.DeleteLesseeCTODetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Lessee Consent To Operate Details Deleted Sucessfully.";
                        }
                        else
                        {
                            TempData["Message"] = "Lessee Consent To Operate Details not Deleted Sucessfully.";
                        }
                    }
                    else
                    {
                        objmodel.STATUS = 0;
                        objobjmodel = _objILesseeCTOModel.UpdateCTODetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Lessee Consent To Operate Details Saved successfully";
                        }
                        else if (objobjmodel.Satus == "2")
                        {
                            TempData["Message"] = "Lessee Consent To Operate  Details Updated successfully";
                        }
                        else
                        {
                            TempData["Message"] = "Error ! while Updating Lessee Consent To Operate Details";
                        }

                    }
                    return RedirectToAction("Create", "LesseeCTODetails", new { Area = "LesseeProfile" });
                }
                else
                {
                    objmodel = await _objILesseeCTOModel.GetCTODetails(objmodel);
                    ViewBag.tableLA = await Tables(objmodel.CREATED_BY,profile.MineralTypeName);
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
                objmodel = await _objILesseeCTOModel.GetCTODetails(objmodel);
                ViewBag.tableLA = await CTOTable(objmodel.CREATED_BY);
                ViewBag.tableLB = await CTOQuantityTable(objmodel.CREATED_BY,"Log");
                ViewBag.tableLC = await CTOQuantityTable(objmodel.CREATED_BY,"");
                return View(objmodel);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objmodel = null;
                objlistmodel = null;
                objlistmodelview = null;
            }
        }
        /// <summary>
        /// To bind Consent To Operate Log Details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public async Task<string> CTOTable(int? Created_By)
        {
            string div = "";
            objmodel.CREATED_BY = Created_By;
            objlistmodel = await _objILesseeCTOModel.GetCTOLogDetails(objmodel);
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
                div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Approval Number</label>";
                div += "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.CTO_ORDER_NO + "</label>";
                div += "</div>";
                div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Order Date</label>";
                div += "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.CTO_Order_Date + "</label>";
                div += "</div>";
                div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Valid From</label>";
                div += "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.CTO_VALID_FROM + "</label>";
                div += "</div>";
                div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Valid To</label>";
                div += "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.CTO_VALID_TO + "</label>";
                div += "</div>";
                div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Letter</label>";
                div += "<div class='col-lg-9 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div += "<span class='colon'>:</span>" + item.FILE_CTO_LETTER + "";
                if (item.FILE_CTO_LETTER != null && item.FILE_CTO_LETTER != "")
                {
                    div = div + "<a href='" + @Url.Content("~/" + item.CTO_LETTER_PATH) + "' class='ml-2' data-original-title='Download CTO Letter' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
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
        /// To bind Consent To Operate Log Details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public async Task<string> CTOQuantityTable(int? Created_By,string type)
        {
            string div = "";
            objmodel.CREATED_BY = pmodel.CREATED_BY = Created_By;
            if (type == "Log")
            {
                objmodel.Product = await _objILesseeCTOModel.GetCTOApprovedQuantityCompareDetails(pmodel);
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
                objlistmodel = await _objILesseeCTOModel.GetCTOApprovedQuantityLogDetails(objmodel);
                for (int i = 0; i < objlistmodel.Count; i++)
                {
                    objmodel.MODIFIED_ON = objlistmodel[i].MODIFIED_ON;
                    objmodel.CTO_ID = objlistmodel[i].CTO_ID;
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
                    objlistmodelview = await _objILesseeCTOModel.GetCTOApprovedQuantityLogDetailsView(objmodel);
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
                    div += "</div>";
                }
            }
            return div;
        }
        /// <summary>
        /// To Compare Lessee Consent To Operate Request Data in view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public async Task<IActionResult> Compare(string id="0")
        {
            try
            {
                objmodel.CREATED_BY = Convert.ToInt32(id);
                objlistmodel = await _objILesseeCTOModel.GetCTOCompareDetails(objmodel);
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
        /// To Approve,Reject Lessee Consent To Operate Profile Request Data in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Compare(LesseeCTOViewModel objmodel)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserLoginId = profile.UserLoginId;
                if (objmodel.SubApprove == "Approve")
                {
                    objobjmodel = _objILesseeCTOModel.ApproveLesseeCTODetails(objmodel);
                }
                else
                {
                    objobjmodel = _objILesseeCTOModel.RejectLesseeCTODetails(objmodel);
                }
                if (objobjmodel.Satus == "1")
                {
                    TempData["Message"] = "Lessee Consent To Operate Details Approved successfully";
                }
                else if (objobjmodel.Satus == "2")
                {
                    TempData["Message"] = "Lessee Consent To Operate Details Rejected successfully";
                }
                else
                {
                    TempData["Message"] = "Error ! while " + objmodel.SubApprove + " Lessee Consent To Operate Details";
                }
                string EncryptUrl = CustomQueryStringHelper.EncryptString("LesseeProfile", "Compare", "LesseeCTODetails", new { id = objmodel.CREATED_BY });
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
        /// Method to bind dropdowns
        /// </summary>
        public void BindDropdowns()
        {
            ViewData["FY"] = GetFYListDetails();
        }
        /// <summary>
        /// To Bind the Financial Year Dropdown Details Data in View
        /// </summary>
        /// <returns></returns>
        private async Task<List<LesseeCTOViewModel>> GetFYListDetails()
        {
            objlistmodel = await _objILesseeCTOModel.GetFYDetails(objmodel);
            return objlistmodel;
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
                objmodel.Product = await _objILesseeCTOModel.GetCTOApprovedQuantityCompareDetails(pmodel);
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
                    List<LesseeCTOViewModel> AreaType = new List<LesseeCTOViewModel>();
                    AreaType = await _objILesseeCTOModel.GetFYDetails(objmodel);
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
                objmodel.Product = await _objILesseeCTOModel.GetCTOApprovedQuantityCompareDetails(pmodel);
                pmodellist = await _objILesseeCTOModel.GetApprovedQuantityDetails(pmodel);
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
                            tbl2 = tbl2 + "<td>Year</td>";
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
                objmodel.Product = await _objILesseeCTOModel.GetCTOApprovedQuantityCompareDetails(pmodel);
                pmodellist = await _objILesseeCTOModel.GetApprovedQuantityDetails(pmodel);
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
                            tbl2 = tbl2 + "<td>Approved Quantity</td>";
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
                objmodel.Product = await _objILesseeCTOModel.GetCTOApprovedQuantityCompareDetails(pmodel);
                pmodellist = await _objILesseeCTOModel.GetApprovedQuantityDetails(pmodel);
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
                            tbl2 = tbl2 + "<td>Unit</td>";
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
    }
}
