// ***********************************************************************
//  Controller Name          : LesseeDetailsController
//  Desciption               : Lessee Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 01 July 2021
// ***********************************************************************
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using MasterApp.Areas.LesseeProfile.Models.LesseeDetails;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MasterApp.Web;
using MasterApp.ActionFilter;
using MasterApp.Areas.LesseeProfile.Models.LeaseAreaDetails;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Linq;

namespace MasterApp.Areas.LesseeProfile.Controllers
{
    [Area("LesseeProfile")]
    public class LesseeDetailsController : Controller
    {
        /// <summary>
        /// Global Variable,object declaration
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        ILesseeDetailsModel _objLesseeDetailsModel;
        ILesseeLeaseAreaModel _objILeaseAreaModel;
        LesseeInfoModel objmodel = new LesseeInfoModel();
        List<LesseeInfoModel> objListmodel = new List<LesseeInfoModel>();
        List<LesseeInfoModel> objListmodelview = new List<LesseeInfoModel>();
        List<LeaseAreaViewModel> objlistareamodel = new List<LeaseAreaViewModel>();
        LesseeProfileRequestModel objProfileRequestmodel = new LesseeProfileRequestModel();
        LeaseAreaViewModel objleaseareamodel = new LeaseAreaViewModel();
        MessageEF objobjmodel = new MessageEF();
        CaptivePurposeModel pmodel = new CaptivePurposeModel();
        List<CaptivePurposeModel> pmodellist = new List<CaptivePurposeModel>();
        string uniqueFileName = null;
        string filePath = null;
        string Signature = string.Empty;
        string OutputResult = string.Empty;
        string ExtensionId = string.Empty;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objLesseeDetailsModel"></param>
        public LesseeDetailsController(ILesseeDetailsModel objLesseeDetailsModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration, ILesseeLeaseAreaModel objILeaseAreaModel)
        {
            _objLesseeDetailsModel = objLesseeDetailsModel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
            _objILeaseAreaModel = objILeaseAreaModel;
        }
        /// <summary>
        /// HTTP Get method of Add action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public IActionResult Add(string id = "0")
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
                BindDropdowns();
                ViewBag.Captive = GetCaptiveList();
                objmodel = _objLesseeDetailsModel.GetLesseeProfileDetails(objmodel);
                //ViewBag.tableLA = await Tables(objmodel.CREATED_BY);
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
        ///  HTTP POST method of Add action
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="cmd"></param>
        /// <param name="approve"></param>
        /// <param name="reject"></param>
        /// <param name="MineralCount"></param>
        /// <param name="CrusherInstalled"></param>
        /// <param name="PaymentModeType"></param>
        /// <param name="StorageCrusher"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Add(LesseeInfoModel objmodel, string cmd, List<int> MineralCount, string CrusherInstalled, string PaymentModeType, string StorageCrusher, string delete, IFormCollection collection)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.CREATED_BY = profile.UserId;
            objmodel.UserId = profile.UserLoginId;
            ExtensionId = Convert.ToString(objmodel.CREATED_BY);
            objmodel.BANK_GUARRANTEE_VALIDITY = profile.MineralTypeName == "Minor Mineral" ? objmodel.BANK_GUARRANTEE_VALIDITY : null;
            if (objmodel.LeasePurpose == 1)
            {
                #region Add data to datatable
                DataTable dt = new DataTable("LESSEE_CAPTIVE_PURPOSE");
                //we create column names as per the type in DB 
                dt.Columns.Add("ID", typeof(string));
                dt.Columns.Add("StateId", typeof(Int32));
                dt.Columns.Add("DistrictId", typeof(Int32));
                dt.Columns.Add("UserTypeId", typeof(Int32));
                dt.Columns.Add("CaptiveUserId", typeof(Int32));
                dt.Columns.Add("CREATED_BY", typeof(Int32));
                string[] StateId = collection["State_Id"].ToString().Split(char.Parse(","));
                string[] DistrictId = collection["District_Id"].ToString().Split(char.Parse(","));
                string[] UserTypeId = collection["UserType_Id"].ToString().Split(char.Parse(","));
                string[] CaptiveUserId = collection["CaptiveUser_Id"].ToString().Split(char.Parse(","));
                for (int i = 0; i < StateId.Length; i++)
                {
                    if (string.IsNullOrEmpty(StateId[i].ToString()) == false)
                    {
                        dt.Rows.Add(i + 1, StateId[i], DistrictId[i], UserTypeId[i], CaptiveUserId[i], objmodel.CREATED_BY);
                        //objmodel.StateId = Convert.ToInt32(StateId[i]);
                        //objmodel.DistrictId = Convert.ToInt32(DistrictId[i]);
                        //objmodel.UserTypeId = Convert.ToInt32(UserTypeId[i]);
                        //objmodel.CaptiveUserId = Convert.ToInt32(CaptiveUserId[i]);
                    }
                }
                objmodel.dtCaptive = dt;
            }
            #endregion 
            else
            {
                objmodel.dtCaptive = null;
            }
            try
            {
                //#region Validation
                //if (string.IsNullOrEmpty(objmodel.RECONNAISSANCE_LICENSE_NAME))
                //{
                //    ModelState.AddModelError("RECONNAISSANCE_LICENSE_NAME", "Lease Name field is required");
                //}
                //if (string.IsNullOrEmpty(objmodel.MINE_CODE))
                //{
                //    ModelState.AddModelError("MINE_CODE", "Mine Code field is required");
                //}
                //if (string.IsNullOrEmpty(objmodel.RECONNAISSANCE_LICENSE_ADDRESS))
                //{
                //    ModelState.AddModelError("RECONNAISSANCE_LICENSE_ADDRESS", "Lease Address field is required");
                //}
                //if (objmodel.WBInstalled == null)
                //{
                //    ModelState.AddModelError("WBInstalled", "WB Installed field is required");
                //}
                //if (objmodel.LabEstablished == null && profile.MineralTypeName != "Minor Mineral")
                //{
                //    ModelState.AddModelError("LabEstablished", "Lab Established field is required");
                //}
                //if (objmodel.AuctionTypeId == null)
                //{
                //    ModelState.AddModelError("AuctionTypeId", "Auction Type field is required");
                //}
                //if (objmodel.AuctionTypeId == 2)
                //{
                //    if (objmodel.PaymentModeType == null)
                //    {
                //        ModelState.AddModelError("AuctionTypeId", "Payment Mode field is required");
                //    }
                //    if (objmodel.PaymentModeType == "DD")
                //    {
                //        if (objmodel.AmountOfDD == null)
                //        {
                //            ModelState.AddModelError("AuctionTypeId", "DD Amount field is required");
                //        }
                //    }
                //}
                //if (string.IsNullOrEmpty(objmodel.RECONNAISSANCE_LICENSE_ADDRESS))
                //{
                //    ModelState.AddModelError("FC_APPROVAL_NUMBER", "Approval Number field is required");
                //}
                //if (objmodel.TillDateDispatchQty == null)
                //{
                //    ModelState.AddModelError("TillDateDispatchQty", "Till Date Dispatch Quantity field is required");
                //}
                //if (string.IsNullOrEmpty(objmodel.NAME_OF_TRANSFEREE))
                //{
                //    ModelState.AddModelError("NAME_OF_TRANSFEREE", "Transferee Name field is required");
                //}
                //if (string.IsNullOrEmpty(objmodel.ADDRESS_OF_TRANSFEREE))
                //{
                //    ModelState.AddModelError("ADDRESS_OF_TRANSFEREE", "Transferee Address field is required");
                //}
                //if (profile.MineralTypeName != "Minor Mineral" && objmodel.LeasePurpose == null)
                //{
                //    ModelState.AddModelError("LeasePurpose", "Lease Purpose field is required");
                //}
                //#endregion
                var error = ModelState.Values.SelectMany(v => v.Errors).ElementAt(0);
                //if (ModelState.IsValid)
                //{
                    #region Lease Information Upload
                    if (objmodel.APPLICATION_FORM_COPY != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.APPLICATION_FORM_COPY.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadAppFormPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadAppFormPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.APPLICATION_FORM_COPY.CopyTo(fileStream);
                        objmodel.APPLICATION_FORM_FILE_NAME = uniqueFileName;
                        objmodel.APPLICATION_FORM_FILE_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.PAN_CARD_COPY != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.PAN_CARD_COPY.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadPanCardPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadPanCardPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.PAN_CARD_COPY.CopyTo(fileStream);
                        objmodel.PAN_CARD_COPY_FILE_NAME = uniqueFileName;
                        objmodel.PAN_CARD_COPY_FILE_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.ADHAR_CARD_SCAN_COPY != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.ADHAR_CARD_SCAN_COPY.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadAadharCardPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadAadharCardPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.ADHAR_CARD_SCAN_COPY.CopyTo(fileStream);
                        objmodel.ADHAR_CARD_SCAN_COPY_FILE_NAME = uniqueFileName;
                        objmodel.ADHAR_CARD_SCAN_COPY_FILE_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.TIN_CARD_SCAN_COPY != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.TIN_CARD_SCAN_COPY.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadTincardPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadTincardPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.TIN_CARD_SCAN_COPY.CopyTo(fileStream);
                        objmodel.TIN_CARD_SCAN_COPY_FILE_NAME = uniqueFileName;
                        objmodel.TIN_CARD_SCAN_COPY_FILE_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.FIRM_REGISTRATION_DEED != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.FIRM_REGISTRATION_DEED.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadFirmRegnPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadFirmRegnPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.FIRM_REGISTRATION_DEED.CopyTo(fileStream);
                        objmodel.FIRM_REGISTRATION_DEED_FILE_NAME = uniqueFileName;
                        objmodel.FIRM_REGISTRATION_DEED_FILE_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.CERTIFICATE_OF_INCORPORATION_DOC != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.CERTIFICATE_OF_INCORPORATION_DOC.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadIncorpPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadIncorpPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.CERTIFICATE_OF_INCORPORATION_DOC.CopyTo(fileStream);
                        objmodel.CERTIFICATE_OF_INCORPORATION_DOC_FILE_NAME = uniqueFileName;
                        objmodel.CERTIFICATE_OF_INCORPORATION_DOC_FILE_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.WBExemption_Upload != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.WBExemption_Upload.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadWBPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadWBPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.WBExemption_Upload.CopyTo(fileStream);
                        objmodel.WBExemption_FILE = uniqueFileName;
                        objmodel.WBExemption_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.LabExemption_Upload != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.LabExemption_Upload.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadLabPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadLabPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.LabExemption_Upload.CopyTo(fileStream);
                        objmodel.LabExemption_FILE = uniqueFileName;
                        objmodel.LabExemption_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.StorageCrusherAttachment_Upload != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.StorageCrusherAttachment_Upload.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadMinorMineralPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadMinorMineralPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.StorageCrusherAttachment_Upload.CopyTo(fileStream);
                        objmodel.StorageCrusherAttachment_FILE = uniqueFileName;
                        objmodel.StorageCrusherAttachment_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.OrderCessRoyalty_Upload != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.OrderCessRoyalty_Upload.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadMinorMineralPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadMinorMineralPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.OrderCessRoyalty_Upload.CopyTo(fileStream);
                        objmodel.OrderAttachment_File = uniqueFileName;
                        objmodel.OrderAttachment_Path = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    objmodel.APPLICATION_FORM_COPY = null;
                    objmodel.PAN_CARD_COPY = null;
                    objmodel.ADHAR_CARD_SCAN_COPY = null;
                    objmodel.TIN_CARD_SCAN_COPY = null;
                    objmodel.FIRM_REGISTRATION_DEED = null;
                    objmodel.CERTIFICATE_OF_INCORPORATION_DOC = null;
                    objmodel.WBExemption_Upload = null;
                    objmodel.LabExemption_Upload = null;
                    objmodel.StorageCrusherAttachment_Upload = null;
                    objmodel.OrderCessRoyalty_Upload = null;
                    #endregion
                    #region Attachments Upload
                    if (objmodel.POWER_OF_ATORNY != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.POWER_OF_ATORNY.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadPowerofAtornyPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadPowerofAtornyPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.POWER_OF_ATORNY.CopyTo(fileStream);
                        objmodel.POWER_OF_ATORNY_FILE_NAME = uniqueFileName;
                        objmodel.POWER_OF_ATORNY_FILE_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.AFFIDAVITS_MINING_DUE_CERTIFICATE != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.AFFIDAVITS_MINING_DUE_CERTIFICATE.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadMiningDueCertificatePath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadMiningDueCertificatePath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.AFFIDAVITS_MINING_DUE_CERTIFICATE.CopyTo(fileStream);
                        objmodel.AFFIDAVITS_MINING_DUE_CERTIFICATE_FILE_NAME = uniqueFileName;
                        objmodel.AFFIDAVITS_MINING_DUE_CERTIFICATE_FILE_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.KHASARA_PANCHSALA != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.KHASARA_PANCHSALA.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadKhasraPanchsalaPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadKhasraPanchsalaPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.KHASARA_PANCHSALA.CopyTo(fileStream);
                        objmodel.KHASARA_PANCHSALA_FILE_NAME = uniqueFileName;
                        objmodel.KHASARA_PANCHSALA_FILE_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.MAP_PLAN_OF_APPLIED_AREA != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.MAP_PLAN_OF_APPLIED_AREA.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadMapPlanPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadMapPlanPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.MAP_PLAN_OF_APPLIED_AREA.CopyTo(fileStream);
                        objmodel.MAP_PLAN_OF_APPLIED_AREA_FILE_NAME = uniqueFileName;
                        objmodel.MAP_PLAN_OF_APPLIED_AREA_FILE_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.REVENUE_OFFICER_REPORT != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.REVENUE_OFFICER_REPORT.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadRevOffcPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadRevOffcPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.REVENUE_OFFICER_REPORT.CopyTo(fileStream);
                        objmodel.REVENUE_OFFICER_REPORT_FILE_NAME = uniqueFileName;
                        objmodel.REVENUE_OFFICER_REPORT_FILE_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.FOREST_REPORT != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.FOREST_REPORT.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadForestReportPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadForestReportPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.FOREST_REPORT.CopyTo(fileStream);
                        objmodel.FOREST_REPORT_FILE_NAME = uniqueFileName;
                        objmodel.FOREST_REPORT_FILE_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.SPOT_INSPECTION_AND_ANALYSIS_REPORT != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.SPOT_INSPECTION_AND_ANALYSIS_REPORT.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadSpotInspectionPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadSpotInspectionPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.SPOT_INSPECTION_AND_ANALYSIS_REPORT.CopyTo(fileStream);
                        objmodel.SPOT_INSPECTION_AND_ANALYSIS_REPORT_FILE_NAME = uniqueFileName;
                        objmodel.SPOT_INSPECTION_AND_ANALYSIS_REPORT_FILE_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.MINING_INSPECTOR_REPORT != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.MINING_INSPECTOR_REPORT.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadMiningReportPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadMiningReportPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.MINING_INSPECTOR_REPORT.CopyTo(fileStream);
                        objmodel.MINING_INSPECTOR_REPORT_FILE_NAME = uniqueFileName;
                        objmodel.MINING_INSPECTOR_REPORT_FILE_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.GRAM_PANCHAYAT_PROPOSAL != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.GRAM_PANCHAYAT_PROPOSAL.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadGPProposalPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadGPProposalPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.GRAM_PANCHAYAT_PROPOSAL.CopyTo(fileStream);
                        objmodel.GRAM_PANCHAYAT_PROPOSAL_FILE_NAME = uniqueFileName;
                        objmodel.GRAM_PANCHAYAT_PROPOSAL_FILE_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.MinorMineralFormAttachment != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.MinorMineralFormAttachment.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadMinorMineralPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadMinorMineralPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.MinorMineralFormAttachment.CopyTo(fileStream);
                        objmodel.MinorMineralFormAttachment_FILE = uniqueFileName;
                        objmodel.MinorMineralFormAttachment_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    objmodel.POWER_OF_ATORNY = null;
                    objmodel.AFFIDAVITS_MINING_DUE_CERTIFICATE = null;
                    objmodel.KHASARA_PANCHSALA = null;
                    objmodel.MAP_PLAN_OF_APPLIED_AREA = null;
                    objmodel.REVENUE_OFFICER_REPORT = null;
                    objmodel.FOREST_REPORT = null;
                    objmodel.SPOT_INSPECTION_AND_ANALYSIS_REPORT = null;
                    objmodel.MINING_INSPECTOR_REPORT = null;
                    objmodel.GRAM_PANCHAYAT_PROPOSAL = null;
                    objmodel.MinorMineralFormAttachment = null;
                    #endregion
                    #region Fees Details Upload
                    if (objmodel.CopyOfPerformanceSecurity != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.CopyOfPerformanceSecurity.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadMinorMineralPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadMinorMineralPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.CopyOfPerformanceSecurity.CopyTo(fileStream);
                        objmodel.PerformanceSecurity_FILE = uniqueFileName;
                        objmodel.PerformanceSecurity_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.APPLICATION_FEES_COPY != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.APPLICATION_FEES_COPY.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadApplicationFeesCopyPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadApplicationFeesCopyPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.APPLICATION_FEES_COPY.CopyTo(fileStream);
                        objmodel.APPLICATION_FEES_COPY_FILE_NAME = uniqueFileName;
                        objmodel.APPLICATION_FEES_COPY_FILE_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.CHALLAN_DD_AMOUNT_COPY != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.CHALLAN_DD_AMOUNT_COPY.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadApplicationChallanPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadApplicationChallanPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.CHALLAN_DD_AMOUNT_COPY.CopyTo(fileStream);
                        objmodel.CHALLAN_DD_AMOUNT_COPY_FILE_NAME = uniqueFileName;
                        objmodel.CHALLAN_DD_AMOUNT_COPY_FILE_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.BANK_GUARRANTEE_COPY != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.BANK_GUARRANTEE_COPY.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadBankGuaranteePath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadBankGuaranteePath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.BANK_GUARRANTEE_COPY.CopyTo(fileStream);
                        objmodel.BANK_GUARRANTEE_COPY_FILE_NAME = uniqueFileName;
                        objmodel.BANK_GUARRANTEE_COPY_FILE_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.SURITY_BOND_COPY != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.SURITY_BOND_COPY.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadSuretyBondCopyPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadSuretyBondCopyPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.SURITY_BOND_COPY.CopyTo(fileStream);
                        objmodel.SURITY_BOND_COPY_FILE_NAME = uniqueFileName;
                        objmodel.SURITY_BOND_COPY_FILE_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_COPY != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_COPY.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadFixedIncomeSchemePath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadFixedIncomeSchemePath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_COPY.CopyTo(fileStream);
                        objmodel.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_FILE_NAME = uniqueFileName;
                        objmodel.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_FILE_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.FinancialAssuranceCopy_Upload != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.FinancialAssuranceCopy_Upload.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadMinorMineralPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadMinorMineralPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.FinancialAssuranceCopy_Upload.CopyTo(fileStream);
                        objmodel.FinancialAssuranceAttachment_FILE = uniqueFileName;
                        objmodel.FinancialAssuranceAttachment_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    objmodel.CopyOfPerformanceSecurity = null;
                    objmodel.APPLICATION_FEES_COPY = null;
                    objmodel.CHALLAN_DD_AMOUNT_COPY = null;
                    objmodel.BANK_GUARRANTEE_COPY = null;
                    objmodel.SURITY_BOND_COPY = null;
                    objmodel.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_COPY = null;
                    objmodel.FinancialAssuranceCopy_Upload = null;
                    #endregion
                    #region Transfer Upload
                    if (objmodel.TRANSFER_GRANT_ORDER__COPY != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.TRANSFER_GRANT_ORDER__COPY.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadTransferGranOrderPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadTransferGranOrderPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.TRANSFER_GRANT_ORDER__COPY.CopyTo(fileStream);
                        objmodel.TRANSFER_GRANT_ORDER_COPY_FILE_NAME = uniqueFileName;
                        objmodel.TRANSFER_GRANT_ORDER_COPY_FILE_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.TRANSFER_LEASE_DEED__COPY != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.TRANSFER_LEASE_DEED__COPY.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadTransferLeaseDeedPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadTransferLeaseDeedPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.TRANSFER_LEASE_DEED__COPY.CopyTo(fileStream);
                        objmodel.TRANSFER_LEASE_DEED_COPY_FILE_NAME = uniqueFileName;
                        objmodel.TRANSFER_LEASE_DEED_COPY_FILE_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    objmodel.TRANSFER_GRANT_ORDER__COPY = null;
                    objmodel.TRANSFER_LEASE_DEED__COPY = null;
                    #endregion
                    var checkDMO = "Forward To DD";
                    if (objmodel.SubResion == "Forward To DD")
                    {
                        cmd = "Forward To DD";
                    }
                    if (checkDMO == cmd)
                    {
                        objmodel.STATUS = 1;
                        objobjmodel = _objLesseeDetailsModel.UpdateLesseeProfileDetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["msg"] = "Lessee Application Details forwarded to DD/DMO successfully";
                        }
                        else if (objobjmodel.Satus == "2")
                        {
                            TempData["msg"] = "Lessee Application Details forwarded to DD/DMO successfully";
                        }
                        else
                        {
                            TempData["msg"] = "Error ! while forwarding Lessee Application Details to DD/DMO";
                        }
                    }
                    else if (delete == "Delete")
                    {
                        objobjmodel = _objLesseeDetailsModel.DeleteLesseeProfileDetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["Message"] = "Lessee Application Details Deleted Sucessfully.";
                        }
                        else
                        {
                            TempData["Message"] = "Lessee Application Details not Deleted Sucessfully.";
                        }
                    }
                    else
                    {
                        objmodel.STATUS = 0;
                        objobjmodel = _objLesseeDetailsModel.UpdateLesseeProfileDetails(objmodel);
                        if (objobjmodel.Satus == "1")
                        {
                            TempData["msg"] = "Lessee Application Details Saved successfully";
                        }
                        else if (objobjmodel.Satus == "2")
                        {
                            TempData["msg"] = "Lessee Application Details updated successfully";
                        }
                        else
                        {
                            TempData["msg"] = "Error ! while Updating Lessee Application Details";
                        }
                    }
                    return RedirectToAction("Add", "LesseeDetails", new { Area = "LesseeProfile" });
                //}
                //else
                //{
                //    BindDropdowns();
                //    objmodel = _objLesseeDetailsModel.GetLesseeProfileDetails(objmodel);
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
        /// HTTP GET method of View action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public async Task<IActionResult> ViewList(LesseeInfoModel objmodel,string UserId)
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
                objmodel = _objLesseeDetailsModel.GetLesseeProfileDetails(objmodel);
                ViewBag.tableLA = LesseeInformationTable(objmodel.CREATED_BY);
                ViewBag.tableLB = LesseeAttachmentsInformationTable(objmodel.CREATED_BY);
                ViewBag.tableLC = LesseeFeesInformationTable(objmodel.CREATED_BY);
                ViewBag.tableLD = LesseeTransferInformationTable(objmodel.CREATED_BY);
                //ViewBag.tableLE = LesseePurpose(objmodel.CREATED_BY);
                ViewBag.tableLE = await PurposeTable(objmodel.CREATED_BY, "Log");
                ViewBag.tableLF = await PurposeTable(objmodel.CREATED_BY, "");
                //ViewBag.ViewList = _objLesseeDetailsModel.GetLesseeProfileLogList(objmodel);
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
        /// Method to bind Dropdowns
        /// </summary>
        public void BindDropdowns()
        {
            ViewBag.Lesseetype = GetLesseetype(null);
            ViewBag.Auctiontype = GetAuctiontype(null);
            ViewData["State"] = GetStateList();
            ViewData["UserType"] = GetUserTypeList();
        }
        /// <summary>
        /// To Bind the Lessee Type Details Data in View
        /// </summary>
        /// <param name="UserType"></param>
        /// <returns></returns>
        private SelectList GetLesseetype(int? APPLICATION_TYPE_ID)
        {
            List<LesseeInfoModel> listLesseeTypeResult = new List<LesseeInfoModel>();
            listLesseeTypeResult = _objLesseeDetailsModel.GetLesseeTypeList(objmodel);
            return new SelectList(listLesseeTypeResult, "ID", "Name", APPLICATION_TYPE_ID);
        }
        /// <summary>
        /// To Bind the Auction Type Details data in view
        /// </summary>
        /// <param name="AuctionTypeId"></param>
        /// <returns></returns>
        private SelectList GetAuctiontype(int? AuctionTypeId)
        {
            List<LesseeInfoModel> listAuctionTypeResult = new List<LesseeInfoModel>();
            listAuctionTypeResult = _objLesseeDetailsModel.GetAuctionTypeList(objmodel);
            return new SelectList(listAuctionTypeResult, "AuctionTypeId", "AuctionName", AuctionTypeId);
        }
        /// <summary>
        /// Method to download uploaded files from view
        /// </summary>
        /// <param name="name"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public FileResult Download(string name, string path)
        {
            try
            {
                var absolutePath = Path.Combine(hostingEnvironment.WebRootPath, "~/Upload/", path);
                if (System.IO.File.Exists(absolutePath))
                {
                    return File(new FileStream(absolutePath, FileMode.Open), "application/octetstream", name);
                }
                return null;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Lessee Profile Request Data in view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public IActionResult ViewApplicationDetails(string Request, string LesseeUserId)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objProfileRequestmodel.USER_ID = profile.UserId;
                objProfileRequestmodel.REQUEST = Request;
                objProfileRequestmodel.ID = Convert.ToInt32(LesseeUserId);
                ViewBag.Request = Request == "1" ? "Lessee Information Details" : Request == "2" ? "Lessee Application Details" : Request == "3" ? "Lessee Forest Clearance Details" : Request == "4" ? "Lessee Grant Order Details"
                    : Request == "5" ? "Lessee Lease Area Details" : Request == "6" ? "Lessee Mineral Information Details" : Request == "7" ? "Lessee Mining Plan Details" : Request == "8" ? "Lessee IBM Details" : Request == "9" ? "Lessee Environment Clearance Details" : Request == "10" ? "Lessee Consent To Establish Details" : Request == "11" ? "Lessee Consent To Operate Details" : "Lessee Assessment Report Details";
                ViewBag.ViewList = _objLesseeDetailsModel.GetLesseeProfileRequestData(objProfileRequestmodel);
                return View(objProfileRequestmodel);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objProfileRequestmodel = null;
            }
        }
        /// <summary>
        /// To Compare Lessee Profile Request Data in view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public async Task<IActionResult> CompareApplicationDetails(string id = "0")
        {
            try
            {
                objmodel.CREATED_BY = Convert.ToInt32(id);
                objListmodel = _objLesseeDetailsModel.GetLesseeProfileCompareDetails(objmodel);
                ViewBag.tableLA = await CompareTable(Convert.ToInt32(id), objListmodel.ElementAt(0).IsLeasePurpose, objListmodel.ElementAt(1).IsLeasePurpose);
                return View(objListmodel);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objmodel = null;
                objListmodel = null;
            }
        }
        /// <summary>
        /// To Approve,Reject Lessee Profile Request Data in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult CompareApplicationDetails(LesseeInfoModel objmodel)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserId = profile.UserLoginId;
                if (objmodel.SubApprove == "Approve")
                {
                    objobjmodel = _objLesseeDetailsModel.ApproveLesseeProfileDetails(objmodel);
                }
                else
                {
                    objobjmodel = _objLesseeDetailsModel.RejectLesseeProfileDetails(objmodel);
                }
                if (objobjmodel.Satus == "1")
                {
                    TempData["msg"] = "Lessee Application Details Approved successfully";
                }
                else if (objobjmodel.Satus == "2")
                {
                    TempData["msg"] = "Lessee Application Details Rejected successfully";
                }
                else
                {
                    TempData["msg"] = "Error ! while Updating Lessee Application Details";
                }
                string EncryptUrl = CustomQueryStringHelper.EncryptString("LesseeProfile", "CompareApplicationDetails", "LesseeDetails", new { id = objmodel.CREATED_BY });
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
        /// To bind Lessee Information tab log details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public string LesseeInformationTable(int? Created_By)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                //profile.MineralTypeName = "MAJOR MINERAL";
                //profile.MineralName = "COAL";
                string div = "";
                objmodel.CREATED_BY = Created_By;
                objListmodel = _objLesseeDetailsModel.GetLesseeProfileLogList(objmodel);
                foreach (var item in objListmodel)
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
                    else                       //Draft
                    {
                        div = div + "<div class='message-highlighter draft'>";
                    }
                    div = div + "<div class='row'>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Lease Type</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.LeaseTypeName + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Application No.</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.APPLICATION_NUMBER + "</label>";
                    if (item.APPLICATION_FORM_FILE_NAME != null && item.APPLICATION_FORM_FILE_NAME != "")
                    {
                        div = div + "<label class='form-control-plaintext'><a href='" + @Url.Content("~/" + item.APPLICATION_FORM_FILE_PATH) + "' class='ml-2' data-original-title='Download Application Number Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Mine Code</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.MINE_CODE + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Lease Name</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.RECONNAISSANCE_LICENSE_NAME + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Lease Address</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.RECONNAISSANCE_LICENSE_ADDRESS + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>PAN Card No.</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.PAN_CARD_NO + "";
                    if (item.PAN_CARD_COPY_FILE_NAME != null && item.PAN_CARD_COPY_FILE_NAME != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.PAN_CARD_COPY_FILE_PATH) + "' class='ml-2' data-original-title='Download PAN Card Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Adhar Card No.</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.ADHAR_CARD + "";
                    if (item.ADHAR_CARD_SCAN_COPY_FILE_NAME != null && item.ADHAR_CARD_SCAN_COPY_FILE_NAME != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.ADHAR_CARD_SCAN_COPY_FILE_PATH) + "' class='ml-2' data-original-title='Download Aadhar Card Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Tin Card No.</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.TIN_CARD + "";
                    if (item.TIN_CARD_SCAN_COPY_FILE_NAME != null && item.TIN_CARD_SCAN_COPY_FILE_NAME != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.TIN_CARD_SCAN_COPY_FILE_PATH) + "' class='ml-2' data-original-title='Download Tin Card Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Firm Registration Deed No.</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.FIRMREGISTRATION_DEED_NUMBER + "";
                    if (item.FIRM_REGISTRATION_DEED_FILE_NAME != null && item.FIRM_REGISTRATION_DEED_FILE_NAME != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.FIRM_REGISTRATION_DEED_FILE_PATH) + "' class='ml-2' data-original-title='Download Firm Registration Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Incorporation Certification No.</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.CERTIFICATE_OF_INCORPORATION_NUMBER + "";
                    if (item.CERTIFICATE_OF_INCORPORATION_DOC_FILE_NAME != null && item.CERTIFICATE_OF_INCORPORATION_DOC_FILE_NAME != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.CERTIFICATE_OF_INCORPORATION_DOC_FILE_PATH) + "' class='ml-2' data-original-title='Download Incorporation Certification Document' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>WB Installed</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.IsWBInstalled + "</label>";
                    div = div + "</div>";
                    if (item.IsWBInstalled == "Yes")
                    {
                        div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Stamping Date</label>";
                        div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div = div + "<span class='colon'>:</span>" + item.WBStampDate + "</label>";
                        div = div + "</div>";
                        div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Stamping Date Valid Upto</label>";
                        div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div = div + "<span class='colon'>:</span>" + item.WBValidUpto + "</label>";
                        div = div + "</div>";
                        div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Stamping Certificate</label>";
                        div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div = div + "<span class='colon'>:</span>";
                        if (item.WBExemption_FILE != null && item.WBExemption_FILE != "")
                        {
                            div = div + "<a href='" + @Url.Content("~/" + item.WBExemption_PATH) + "' class='ml-2' data-original-title='Download Stamping Certificate Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                        }
                        div = div + "</div>";
                    }
                    else
                    {
                        div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Order copy of WB Exemption</label>";
                        div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div = div + "<span class='colon'>:</span>";
                        if (item.WBExemption_FILE != null && item.WBExemption_FILE != "")
                        {
                            div = div + "<a href='" + @Url.Content("~/" + item.WBExemption_PATH) + "' class='ml-2' data-original-title='Download WB Exemption Order Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                        }
                        div = div + "</div>";
                    }
                    if (profile.MineralTypeName != "Minor Mineral")
                    {
                        div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Lab Established</label>";
                        div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div = div + "<span class='colon'>:</span>" + item.IsLabEstablished + "</label>";
                        div = div + "</div>";
                    }
                    if (item.IsLabEstablished == "Yes")
                    {
                        div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Upload copy of Inspection report by Officials(RH,DGM)</label>";
                        div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div = div + "<span class='colon'>:</span>";
                        if (item.LabExemption_FILE != null && item.LabExemption_FILE != "")
                        {
                            div = div + "<a href='" + @Url.Content("~/" + item.LabExemption_PATH) + "' class='ml-2' data-original-title='Download Inspection report by Officials(RH,DGM) Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                        }
                        div = div + "</div>";
                    }
                    else if (item.IsLabEstablished == "No")
                    {
                        div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Upload order copy of exemption by DGM / MRD</label>";
                        div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div = div + "<span class='colon'>:</span>";
                        if (item.LabExemption_FILE != null && item.LabExemption_FILE != "")
                        {
                            div = div + "<a href='" + @Url.Content("~/" + item.LabExemption_PATH) + "' class='ml-2' data-original-title='Download exemption by DGM / MRD Order Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                        }
                        div = div + "</div>";
                    }
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Application Type</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.IsAuctionType + "</label>";
                    div = div + "</div>";
                    if (item.AuctionTypeId == 2)
                    {
                        if (profile.MineralName.ToUpper() == "COAL")
                        {
                            div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Monthly Periodic Amount/Auction Money(in <i class='fas fa-rupee-sign'></i>)</label>";
                            div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                            div = div + "<span class='colon'>:</span>" + item.MonthlyPeriodicAmt + "</label>";
                            div = div + "</div>";
                        }
                        if (profile.MineralTypeName.ToUpper() == "MAJOR MINERAL")
                        {
                            div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Bid Premium(%)</label>";
                            div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                            div = div + "<span class='colon'>:</span>" + item.BidPremium + "</label>";
                            div = div + "</div>";
                        }
                    }
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Storage/Crusher</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.StorageCrusher + "</label>";
                    div = div + "</div>";
                    if (item.StorageCrusher == "Yes")
                    {
                        div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Crusher Installed</label>";
                        div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div = div + "<span class='colon'>:</span>" + item.CrusherInstalled + "</label>";
                        div = div + "</div>";
                        if (item.CrusherInstalled == "No")
                        {
                            div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Storage/Crusher License Copy</label>";
                            div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                            div = div + "<span class='colon'>:</span>";
                            if (item.StorageCrusherAttachment_FILE != null && item.StorageCrusherAttachment_FILE != "")
                            {
                                div = div + "<a href='" + @Url.Content("~/" + item.StorageCrusherAttachment_PATH) + "' class='ml-2' data-original-title='Download Storage/Crusher License Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                            }
                            div = div + "</div>";
                        }
                    }
                    if (profile.MineralTypeName.ToUpper() == "MAJOR MINERAL" && profile.MineralName.ToUpper() == "COAL")
                    {
                        div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Adjust E & I CESS</label>";
                        div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div = div + "<span class='colon'>:</span>" + item.AdjustCess + "</label>";
                        div = div + "</div>";
                        if (item.AdjustCess == "Yes")
                        {
                            div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Order of</label>";
                            div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                            div = div + "<span class='colon'>:</span>" + item.OrderOf + "</label>";
                            div = div + "</div>";
                            div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Order No</label>";
                            div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                            div = div + "<span class='colon'>:</span>";
                            if (item.OrderAttachment_File != null && item.OrderAttachment_File != "")
                            {
                                div = div + "<a href='" + @Url.Content("~/" + item.OrderAttachment_Path) + "' class='ml-2' data-original-title='Download Order Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                            }
                            div = div + "</div>";
                            div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Order Date</label>";
                            div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                            div = div + "<span class='colon'>:</span>" + item.OrderDate + "</label>";
                            div = div + "</div>";
                        }
                    }
                    div = div + "</div>";
                    div = div + "</div>";
                    div = div + "</li>";
                }
                return div;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objListmodel = null;
            }
        }
        /// <summary>
        /// To bind Lessee Attachments Information tab log details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public string LesseeAttachmentsInformationTable(int? Created_By)
        {
            try
            {
                string div = "";
                objmodel.CREATED_BY = Created_By;
                objListmodel = _objLesseeDetailsModel.GetLesseeProfileLogList(objmodel);
                foreach (var item in objListmodel)
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
                    else                       //Draft
                    {
                        div = div + "<div class='message-highlighter draft'>";
                    }
                    div = div + "<div class='row'>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Power of Attorney</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.POWER_OF_ATORNY + "";
                    if (item.POWER_OF_ATORNY_FILE_NAME != null && item.POWER_OF_ATORNY_FILE_NAME != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.POWER_OF_ATORNY_FILE_PATH) + "' class='ml-2' data-original-title='Download Power of Attorney Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Affidavits/Mining Due Certificate</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.AFFIDAVITS_MINING_DUE_CERTIFICATE + "";
                    if (item.PAN_CARD_COPY_FILE_NAME != null && item.PAN_CARD_COPY_FILE_NAME != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.PAN_CARD_COPY_FILE_PATH) + "' class='ml-2' data-original-title='Download Affidavits/Mining Due Certificate Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Khasara Panchsala</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.KHASARA_PANCHSALA + "";
                    if (item.KHASARA_PANCHSALA_FILE_NAME != null && item.KHASARA_PANCHSALA_FILE_NAME != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.KHASARA_PANCHSALA_FILE_PATH) + "' class='ml-2' data-original-title='Download Khasara Panchsala Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Map/Plan of applied area</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.MAP_PLAN_OF_APPLIED_AREA + "";
                    if (item.MAP_PLAN_OF_APPLIED_AREA_FILE_NAME != null && item.MAP_PLAN_OF_APPLIED_AREA_FILE_NAME != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.MAP_PLAN_OF_APPLIED_AREA_FILE_PATH) + "' class='ml-2' data-original-title='Download Map/Plan of applied area Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Forest Report</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.FOREST_REPORT + "";
                    if (item.FOREST_REPORT_FILE_NAME != null && item.FOREST_REPORT_FILE_NAME != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.FOREST_REPORT_FILE_PATH) + "' class='ml-2' data-original-title='Download Forest Report Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Revenue Officer Report</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.REVENUE_OFFICER_REPORT + "";
                    if (item.REVENUE_OFFICER_REPORT_FILE_NAME != null && item.REVENUE_OFFICER_REPORT_FILE_NAME != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.REVENUE_OFFICER_REPORT_FILE_PATH) + "' class='ml-2' data-original-title='Download Revenue Officer Report Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Spot Inspection and Analysis Report</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.SPOT_INSPECTION_AND_ANALYSIS_REPORT + "";
                    if (item.SPOT_INSPECTION_AND_ANALYSIS_REPORT_FILE_NAME != null && item.SPOT_INSPECTION_AND_ANALYSIS_REPORT_FILE_NAME != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.SPOT_INSPECTION_AND_ANALYSIS_REPORT_FILE_PATH) + "' class='ml-2' data-original-title='Download Spot Inspection and Analysis Report Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Mining Inspector Report</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.MINING_INSPECTOR_REPORT + "";
                    if (item.MINING_INSPECTOR_REPORT_FILE_NAME != null && item.MINING_INSPECTOR_REPORT_FILE_NAME != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.MINING_INSPECTOR_REPORT_FILE_PATH) + "' class='ml-2' data-original-title='Download Mining Inspector Report Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Gram Panchayat Proposal</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.GRAM_PANCHAYAT_PROPOSAL + "";
                    if (item.GRAM_PANCHAYAT_PROPOSAL_FILE_NAME != null && item.GRAM_PANCHAYAT_PROPOSAL_FILE_NAME != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.GRAM_PANCHAYAT_PROPOSAL_FILE_PATH) + "' class='ml-2' data-original-title='Download Gram Panchayat Proposal Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "</div>";
                    div = div + "</div>";
                    div = div + "</li>";
                }
                return div;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objListmodel = null;
            }
        }
        /// <summary>
        /// To bind Lessee Fees Information tab log details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public string LesseeFeesInformationTable(int? Created_By)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                //profile.MineralTypeName = "Major Mineral";
                //profile.MineralName = "Coal";
                string div = "";
                objmodel.CREATED_BY = Created_By;
                objListmodel = _objLesseeDetailsModel.GetLesseeProfileLogList(objmodel);
                foreach (var item in objListmodel)
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
                    else                       //Draft
                    {
                        div = div + "<div class='message-highlighter draft'>";
                    }
                    div = div + "<div class='row'>";
                    if (item.AuctionTypeId == 2)
                    {
                        div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Payment Mode</label>";
                        if (item.PaymentModeType == "BG")
                        {
                            div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                            div = div + "<span class='colon'>:</span>BG</label>";
                            div = div + "</div>";
                            div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Validity Upto</label>";
                            div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                            div = div + "<span class='colon'>:</span>" + item.BG_ValidityUpto + "</label>";
                            div = div + "</div>";
                            div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Copy of Performance Security</label>";
                            div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                            div = div + "<span class='colon'>:</span>" + item.CopyOfPerformanceSecurity + "</label>";
                            if (item.PerformanceSecurity_FILE != null && item.PerformanceSecurity_FILE != "")
                            {
                                div = div + "<a href='" + @Url.Content("~/" + item.PerformanceSecurity_PATH) + "' class='ml-2' data-original-title='Download Performance Security Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                            }
                            div = div + "</div>";
                        }
                        else
                        {
                            div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                            div = div + "<span class='colon'>:</span>DD</label>";
                            div = div + "</div>";
                            div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Amount of DD</label>";
                            div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                            div = div + "<span class='colon'>:</span>" + item.AmountOfDD + "</label>";
                            div = div + "</div>";
                            div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Copy of Performance Security</label>";
                            div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                            div = div + "<span class='colon'>:</span>" + item.CopyOfPerformanceSecurity + "";
                            if (item.PerformanceSecurity_FILE != null && item.PerformanceSecurity_FILE != "")
                            {
                                div = div + "<a href='" + @Url.Content("~/" + item.PerformanceSecurity_PATH) + "' class='ml-2' data-original-title='Download Performance Security Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                            }
                            div = div + "</div>";
                        }
                    }
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Application Fees (in <i class='fas fa-rupee-sign'></i>)</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.APPLICATION_FEES + "";
                    if (item.APPLICATION_FEES_COPY_FILE_NAME != null && item.APPLICATION_FEES_COPY_FILE_NAME != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.APPLICATION_FEES_COPY_FILE_PATH) + "' class='ml-2' data-original-title='Download Application Fees Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Application Fees Date</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.APPLICATION_FEES_DATE + "</label>";
                    div = div + "</div>";
                    if (profile.MineralTypeName != "Minor Mineral")
                    {
                        div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Security Deposit Challan/DD Amount (in <i class='fas fa-rupee-sign'></i>)</label>";
                        div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div = div + "<span class='colon'>:</span>" + item.CHALLAN_DD_AMOUNT + "";
                        if (item.CHALLAN_DD_AMOUNT_COPY_FILE_NAME != null && item.CHALLAN_DD_AMOUNT_COPY_FILE_NAME != "")
                        {
                            div = div + "<a href='" + @Url.Content("~/" + item.CHALLAN_DD_AMOUNT_COPY_FILE_PATH) + "' class='ml-2' data-original-title='Download Security Deposit Challan/DD Amount Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                        }
                        div = div + "</div>";
                        div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Security Deposit Challan/DD Date</label>";
                        div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div = div + "<span class='colon'>:</span>" + item.CHALLAN_DD_AMOUNT_DATE + "</label>";
                        div = div + "</div>";
                    }
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Bank Guarrantee Amount (in <i class='fas fa-rupee-sign'></i>)</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.BANK_GUARRANTEE_AMOUNT + "";
                    if (item.BANK_GUARRANTEE_COPY_FILE_NAME != null && item.BANK_GUARRANTEE_COPY_FILE_NAME != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.BANK_GUARRANTEE_COPY_FILE_PATH) + "' class='ml-2' data-original-title='Download Bank Guarrantee Amount Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Bank Guarranty Date</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.BANK_GUARRANTEE_DATE + "</label>";
                    div = div + "</div>";
                    if (profile.MineralTypeName == "Minor Mineral")
                    {
                        div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Bank Guarranty Validity Upto</label>";
                        div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div = div + "<span class='colon'>:</span>" + item.BANK_GUARRANTEE_VALIDITY + "</label>";
                        div = div + "</div>";
                    }
                    if (profile.MineralTypeName != "Minor Mineral")
                    {
                        div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Surety Bond Amount (in <i class='fas fa-rupee-sign'></i>)</label>";
                        div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div = div + "<span class='colon'>:</span>" + item.SURITY_BOND_AMOUNT + "";
                        if (item.SURITY_BOND_COPY_FILE_NAME != null && item.SURITY_BOND_COPY_FILE_NAME != "")
                        {
                            div = div + "<a href='" + @Url.Content("~/" + item.SURITY_BOND_COPY_FILE_PATH) + "' class='ml-2' data-original-title='Download Surety Bond Amount Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                        }
                        div += "</div>";
                        div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Surety Bond Amount Date</label>";
                        div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div = div + "<span class='colon'>:</span>" + item.SURITY_BOND_DATE + "</label>";
                        div = div + "</div>";
                    }
                    //div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Amount of Performance Security</label>";
                    //div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    //div = div + "<span class='colon'>:</span>" + item.UpfrontPaymentDeposited + "</label>";
                    //div = div + "</div>";
                    //div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Remaining Upfront Payment</label>";
                    //div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    //div = div + "<span class='colon'>:</span>" + item.TillDateBalanceUpfrontPayment + "</label>";
                    //div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Fixed Deposits Monthly Income Scheme Certificate</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_FILE_NAME + "";
                    if (item.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_FILE_NAME != null && item.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_FILE_NAME != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.FIXED_DEPOSITS_MONTHLY_INCOME_SCHEME_CERTIFICATE_FILE_PATH) + "' class='ml-2' data-original-title='Download Fixed Deposits Monthly Income Scheme Certificate Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Internet Connection Available dispatch Point</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.InterNetConnectionAtDistpatch + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Till Date Dispatch Quantity (MT)</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.TillDateDispatchQty + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Amount of Financial Assurance</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.FinancialAmountAssurance + "";
                    if (item.FinancialAssuranceAttachment_FILE != null && item.FinancialAssuranceAttachment_FILE != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.FinancialAssuranceAttachment_PATH) + "' class='ml-2' data-original-title='Download Amount of Financial Assurance Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "</div>";
                    div = div + "</div>";
                    div = div + "</li>";
                }
                return div;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objListmodel = null;
            }
        }
        /// <summary>
        /// To bid Lessee Transfer Information tab log details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public string LesseeTransferInformationTable(int? Created_By)
        {
            try
            {
                string div = "";
                objmodel.CREATED_BY = Created_By;
                objListmodel = _objLesseeDetailsModel.GetLesseeProfileLogList(objmodel);
                foreach (var item in objListmodel)
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
                    else                       //Draft
                    {
                        div = div + "<div class='message-highlighter draft'>";
                    }
                    div = div + "<div class='row'>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Transferee Name</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.NAME_OF_TRANSFEREE + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Transferee Address</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.ADDRESS_OF_TRANSFEREE + "</label>";
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Transfer Grant Order Copy</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.TRANSFER_GRANT_ORDER_COPY_FILE_NAME + "";
                    if (item.TRANSFER_GRANT_ORDER_COPY_FILE_NAME != null && item.TRANSFER_GRANT_ORDER_COPY_FILE_NAME != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.TRANSFER_GRANT_ORDER_COPY_FILE_PATH) + "' class='ml-2' data-original-title='Download Transfer Grant Order Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Transfer Lease Deed Copy</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.TRANSFER_GRANT_ORDER_COPY_FILE_NAME + "";
                    if (item.TRANSFER_GRANT_ORDER_COPY_FILE_NAME != null && item.TRANSFER_GRANT_ORDER_COPY_FILE_NAME != "")
                    {
                        div = div + "<a href='" + @Url.Content("~/" + item.TRANSFER_LEASE_DEED_COPY_FILE_PATH) + "' class='ml-2' data-original-title='Download Transfer Lease Deed Copy' target='_blank'><i class='icon-file-pdf-solid h5 text-danger'></i></a></label>";
                    }
                    div = div + "</div>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Transfer Date</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.DATE_OF_TRANSFER + "</label>";
                    div = div + "</div>";
                    div = div + "</div>";
                    div = div + "</div>";
                    div = div + "</li>";
                }
                return div;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objListmodel = null;
            }
        }
        /// <summary>
        /// To bid Lessee Purpose tab log details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public string LesseePurpose(int? Created_By)
        {
            try
            {
                string div = "";
                objmodel.CREATED_BY = Created_By;
                objListmodel = _objLesseeDetailsModel.GetLesseeProfileLogList(objmodel);
                foreach (var item in objListmodel)
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
                    else                       //Draft
                    {
                        div = div + "<div class='message-highlighter draft'>";
                    }
                    div = div + "<div class='row'>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Lease Purpose</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + item.IsLeasePurpose + "</label>";
                    div = div + "</div>";
                    //div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>State</label>";
                    //div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    //div = div + "<span class='colon'>:</span>" + item.StateName + "</label>";
                    //div = div + "</div>";
                    //div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>District</label>";
                    //div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    //div = div + "<span class='colon'>:</span>" + item.DisrictName + "</label>";
                    //div = div + "</div>";
                    //div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>End User Plant</label>";
                    //div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    //div = div + "<span class='colon'>:</span>" + item.EndUserPlant + "</label>";
                    //div = div + "</div>";
                    //div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Plant Capacity Per Annum</label>";
                    //div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    //div = div + "<span class='colon'>:</span>" + item.PlantCapacity + "</label>";
                    //div = div + "</div>";
                    //div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Remarks</label>";
                    //div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    //div = div + "<span class='colon'>:</span>" + item.Remarks + "</label>";
                    //div = div + "</div>";
                    div = div + "</div>";
                    div = div + "</div>";
                    div = div + "</li>";
                }
                return div;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objListmodel = null;
            }
        }
        #region DSC   
        /// <summary>
        /// Digital Signature
        /// </summary>
        /// <param name="contentType"></param>
        /// <param name="signDataBase64Encoded"></param>
        /// <param name="responseType"></param>
        /// <returns></returns>
        public string CheckVerifyResponse(string contentType, string signDataBase64Encoded, string responseType)
        {
            try
            {
                if (signDataBase64Encoded.Contains("signing canceled"))
                {
                    OutputResult = "";
                }
                else
                {
                    signDataBase64Encoded = signDataBase64Encoded.Replace("IssuerCommonName", " Issuer");
                    signDataBase64Encoded = signDataBase64Encoded.Replace("CommonName", " CommonName").Replace("SerialNo", " SerialNo").Replace("IssuedDate", " IssuedDate").Replace("ExpiryDate", " ExpiryDate").Replace("Email", " Email").Replace("Country", " Country").Replace("CertificateClass", " CertificateClass").Replace("\r\n", "");
                    string[] tokens = signDataBase64Encoded.Split(new[] { " " }, StringSplitOptions.None);
                    string strSign = GetDSCRespnseData(tokens);
                    TempData["DSCResponse"] = signDataBase64Encoded;
                    TempData["Base64Data"] = strSign;
                    OutputResult = "SUCCESS";
                }
            }
            catch
            {
            }
            return OutputResult.ToUpper();
        }
        public string GetDSCRespnseData(string[] parameters)
        {
            string strSign = string.Empty;
            string[] strGetMerchantParamForCompare;
            for (int i = 0; i < parameters.Length; i++)
            {
                strGetMerchantParamForCompare = parameters[i].ToString().Split('=');
                if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "SIGNATURE")
                {
                    Signature = Convert.ToString(strGetMerchantParamForCompare[1]);
                    break;
                }
            }
            strSign = Signature;
            return strSign;
        }
        #endregion
        /// <summary>
        /// Lessee Profile Dashboard details
        /// </summary>
        /// <returns></returns>
        public IActionResult Dashboard()
        {
            return View();
        }
        /// <summary>
        /// To Bind the State Details data in view
        /// </summary>
        /// <param name="STATE_ID"></param>
        /// <returns></returns>
        private List<LesseeInfoModel> GetStateList()
        {
            objListmodel = _objLesseeDetailsModel.GetStateList(objmodel);
            return objListmodel;
        }
        //public JsonResult GetStateList()
        //{
        //    try
        //    {
        //        objListmodel = _objLesseeDetailsModel.GetStateList(objmodel);
        //        return Json(objListmodel);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        objmodel = null;
        //        objListmodel = null;
        //    }
        //}
        /// <summary>
        /// To bind District Dropdown based on StateId
        /// </summary>
        /// <param name="StateId"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetDistrictdetailsByRegionId(int? StateId)
        {
            try
            {
                objleaseareamodel.StateId = StateId;
                objlistareamodel = await _objILeaseAreaModel.GetDistrictList(objleaseareamodel);
                return Json(objlistareamodel);
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
        /// To Bind the User Type Details data in view
        /// </summary>
        /// <param name="UserTypeId"></param>
        /// <returns></returns>
        private List<LesseeInfoModel> GetUserTypeList()
        {
            objListmodel = _objLesseeDetailsModel.GetUserTypeList(objmodel);
            //return new SelectList(objListmodel, "UserTypeId", "UserType", UserTypeId);
            return objListmodel;
        }
        /// <summary>
        /// To bind User Dropdown based on UserTypeId
        /// </summary>
        /// <param name="UserTypeId"></param>
        /// <returns></returns>
        public JsonResult GetUserdetailsByUsertypeId(int UserTypeId, int StateId, int DistrictId)
        {
            try
            {
                objmodel.UserTypeId = UserTypeId;
                objmodel.StateId = StateId;
                objmodel.DistrictId = DistrictId;
                objListmodel = _objLesseeDetailsModel.GetUserList(objmodel);
                return Json(objListmodel);
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
        /// To Bind the Captive Details data in view
        /// </summary>
        /// <returns></returns>
        private List<LesseeInfoModel> GetCaptiveList()
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.CREATED_BY = profile.UserId;
                objListmodel = _objLesseeDetailsModel.GetCaptiveList(objmodel);
                return objListmodel;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                objListmodel = null;
            }
        }
        /// <summary>
        /// Bind State,District,UserType,User list details data in view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public async Task<string> Tables(int? id)
        //{
        //    try
        //    {
        //        string tbl = "";
        //        pmodel.CREATED_BY = id;
        //        objmodel.Product = await _objLesseeDetailsModel.GetPurposeDetails(pmodel);
        //        string tbl2 = "";
        //        tbl2 = "<table id='MiningPlanTable' class='table table-sm table-bordered mb-0'>";
        //        tbl2 = tbl2 + "<thead>";
        //        tbl2 = tbl2 + "<tr>";
        //        tbl2 = tbl2 + "<th width='40px' class='font-weight-bolder'>Sl#</th><th> State </th><th> District </th><th> UserType </th><th> User </th>";
        //        tbl2 = tbl2 + "</tr>";
        //        tbl2 = tbl2 + "</thead>";
        //        tbl2 = tbl2 + "<tbody>";
        //        int colLA = 1;
        //        foreach (var item in objmodel.Product)
        //        {
        //            objlistareamodel = new List<LeaseAreaViewModel>();
        //            tbl2 = tbl2 + "<tr>";
        //            tbl2 = tbl2 + "<td>" + colLA + "</td>";
        //            tbl2 = tbl2 + "<td>";
        //            tbl2 = tbl2 + "<select class='form-control' id='ddlState&" + colLA + "' name='StateId' onchange='BindDistrictData(this.parentNode.parentNode.rowIndex-1)'>";
        //            tbl2 = tbl2 + "<option value=''>select</option>";
        //            objListmodel = _objLesseeDetailsModel.GetStateList(objmodel);
        //            foreach (var item2 in objListmodel)
        //            {
        //                if (item2.StateId == item.State_Id)
        //                {
        //                    tbl2 = tbl2 + "<option value=" + item2.StateId + " selected='selected'>" + item2.StateName + "</option>";
        //                    objlistareamodel = await GetDistrictList(item2.StateId);
        //                }
        //                else
        //                {
        //                    tbl2 = tbl2 + "<option value=" + item2.StateId + ">" + item2.StateName + "</option>";
        //                }
        //            }
        //            tbl2 = tbl2 + "</select>";
        //            tbl2 = tbl2 + "</td>";
        //            tbl2 = tbl2 + "<td>";
        //            tbl2 = tbl2 + "<select class='form-control' id='DistrictID' name='DistrictId'>";
        //            tbl2 = tbl2 + "<option value='0'>Select</option>";
        //            foreach (var item4 in objlistareamodel)
        //            {
        //                if (item4.DistrictId == item.District_Id)
        //                {
        //                    tbl2 = tbl2 + "<option value=" + item4.DistrictId + " selected='selected'>" + item4.DistrictName + "</option>";
        //                }
        //                else
        //                {
        //                    tbl2 = tbl2 + "<option value=" + item4.DistrictId + ">" + item4.DistrictName + "</option>";
        //                }
        //            }
        //            tbl2 = tbl2 + "</select>";
        //            tbl2 = tbl2 + "</td>";
        //            tbl2 = tbl2 + "<td>";
        //            tbl2 = tbl2 + "<select class='form-control' id='ddlUserType' name='UserTypeId' onchange='BindUserData(this.parentNode.parentNode.rowIndex-1,this.parentNode.parentNode.rowIndex-2,this.parentNode.parentNode.rowIndex-3)'>";
        //            tbl2 = tbl2 + "<option value='0'>select</option>";
        //            objListmodel = _objLesseeDetailsModel.GetUserTypeList(objmodel);
        //            foreach (var item3 in objListmodel)
        //            {
        //                if (item3.UserType == item.UserType)
        //                {
        //                    tbl2 = tbl2 + "<option value=" + item3.UserTypeId + " selected='selected'>" + item3.UserType + "</option>";
        //                    objListmodelview = _objLesseeDetailsModel.GetUserList(objmodel);
        //                }
        //                else
        //                {
        //                    tbl2 = tbl2 + "<option value=" + item3.UserTypeId + ">" + item3.UserType + "</option>";
        //                }
        //            }
        //            tbl2 = tbl2 + "</select>";
        //            tbl2 = tbl2 + "</td>";
        //            tbl2 = tbl2 + "<td>";
        //            tbl2 = tbl2 + "<select class='form-control' id='CaptiveUserId' name='CaptiveUserId'>";
        //            tbl2 = tbl2 + "<option value='0'>Select</option>";
        //            foreach (var item5 in objListmodelview)
        //            {
        //                if (item5.CaptiveUserId == item.CaptiveUser_Id)
        //                {
        //                    tbl2 = tbl2 + "<option value=" + item5.CaptiveUserId + " selected='selected'>" + item5.CaptiveUserName + "</option>";
        //                }
        //                else
        //                {
        //                    tbl2 = tbl2 + "<option value=" + item5.CaptiveUserId + ">" + item5.CaptiveUserName + "</option>";
        //                }
        //            }
        //            tbl2 = tbl2 + "</select>";
        //            tbl2 = tbl2 + "</td>";
        //            tbl2 = tbl2 + "<td>";
        //            tbl2 = tbl2 + "</tr>";
        //            colLA++;
        //        }
        //        tbl2 = tbl2 + "</tbody>";
        //        tbl2 = tbl2 + "</table>";
        //        tbl = tbl2;
        //        return tbl;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        objListmodel = null;
        //        pmodel = null;
        //    }
        //}
        /// <summary>
        /// To Bind the District Details data in view on State
        /// </summary>
        /// <param name="StateId"></param>
        /// <returns></returns>
        private async Task<List<LeaseAreaViewModel>> GetDistrictList(int StateId)
        {
            try
            {
                objleaseareamodel.StateId = StateId;
                objlistareamodel = await _objILeaseAreaModel.GetDistrictList(objleaseareamodel);
                return objlistareamodel;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objlistareamodel = null;
            }
        }
        /// <summary>
        /// To Bind the User Details data in view on User Type
        /// </summary>
        /// <param name="StateId"></param>
        /// <returns></returns>
        private List<LesseeInfoModel> GetUserList(int StateId,int DistrictId,int UserTypeId)
        {
            try
            {
                objmodel.UserTypeId = UserTypeId;
                objmodel.StateId = StateId;
                objmodel.DistrictId = DistrictId;
                objListmodel =  _objLesseeDetailsModel.GetUserList(objmodel);
                return objListmodel;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objmodel = null;
                objListmodel = null;
            }
        }
        /// <summary>
        /// To bind Lessee Purpose Log Details in view
        /// </summary>
        /// <param name="Created_By"></param>
        /// <returns></returns>
        public async Task<string> PurposeTable(int? Created_By, string type)
        {
            string div = "";
            objmodel.CREATED_BY = pmodel.CREATED_BY = Created_By;
            if (type == "Log")
            {
                objmodel.Product = await _objLesseeDetailsModel.GetCaptivePurposeLogDetailsCompareDetails(pmodel);
                div = div + "<div class='row'>";
                div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Lease Purpose</label>";
                div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                div = div + "<span class='colon'>:</span>" + objmodel.Product.ElementAt(0).IsLeasePurpose + "</label>";
                div = div + "</div>";
                if (objmodel.Product.ElementAt(0).IsLeasePurpose == "Captive")
                {
                    foreach (var item in objmodel.Product)
                    {
                        div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>State</label>";
                        div += "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div += "<span class='colon'>:</span>" + item.StateName + "</label>";
                        div += "</div>";
                        div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>District</label>";
                        div += "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div += "<span class='colon'>:</span>" + item.DisrictName + "</label>";
                        div += "</div>";
                        div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>User Type</label>";
                        div += "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div += "<span class='colon'>:</span>" + item.UserType + "</label>";
                        div += "</div>";
                        div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>User</label>";
                        div += "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                        div += "<span class='colon'>:</span>" + item.CaptiveUserName + "</label>";
                        div += "</div>";
                    }
                    div += "</div>";
                }
            }
            else
            {
                objListmodel = await _objLesseeDetailsModel.GetCaptivePurposeLogDetails(objmodel);
                for (int i = 0; i < objListmodel.Count; i++)
                {
                    objmodel.MODIFIED_ON = objListmodel[i].MODIFIED_ON;
                    objmodel.APPLICATION_ID = objListmodel[i].APPLICATION_ID;
                    objmodel.STATUS = objListmodel[i].STATUS;
                    objmodel.IsLeasePurpose = objListmodel[i].IsLeasePurpose;
                    div += "<li class='timeline-item'>";
                    div += "<div class='date-box'>";
                    div += "<p><span class='date'>" + objListmodel[i].ModifyDate + "</span><span class='month-year'>" + objListmodel[i].ModifyYear + "</span></p>";
                    div += "</div>";
                    if (objListmodel[i].STATUS == 2) //Approved
                    {
                        div = div + "<div class='message-highlighter approved'>";
                    }
                    else if (objListmodel[i].STATUS == 1) //Forwarded
                    {
                        div = div + "<div class='message-highlighter forwarded'>";
                    }
                    else if (objListmodel[i].STATUS == 3) //Rejected
                    {
                        div = div + "<div class='message-highlighter rejected'>";
                    }
                    else                       //Draft
                    {
                        div = div + "<div class='message-highlighter draft'>";
                    }
                    div = div + "<div class='row'>";
                    div = div + "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>Lease Purpose</label>";
                    div = div + "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                    div = div + "<span class='colon'>:</span>" + objmodel.IsLeasePurpose + "</label>";
                    div = div + "</div>";
                    objListmodelview = await _objLesseeDetailsModel.GetCaptivePurposeLogDetailsView(objmodel);
                    //if (objmodel.IsLeasePurpose == "Captive")
                    //{
                        foreach (var item in objListmodelview)
                        {
                            div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>State</label>";
                            div += "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                            div += "<span class='colon'>:</span>" + item.StateName + "</label>";
                            div += "</div>";
                            div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>District</label>";
                            div += "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                            div += "<span class='colon'>:</span>" + item.DisrictName + "</label>";
                            div += "</div>";
                            div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>User Type</label>";
                            div += "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                            div += "<span class='colon'>:</span>" + item.UserType + "</label>";
                            div += "</div>";
                            div += "<label class='col-lg-3 col-md-4 col-sm-12 col-form-label'>User</label>";
                            div += "<div class='col-lg-3 col-md-8 col-sm-12'><label class='form-control-plaintext'>";
                            div += "<span class='colon'>:</span>" + item.CaptiveUserName + "</label>";
                            div += "</div>";
                        }
                    //}
                    div = div + "</div>";
                    div = div + "</div>";
                    div = div + "</li>";
                }
            }
            return div;
        }
        /// <summary>
        /// Bind Compare Captive Purpose details data in view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> CompareTable(int? id, string ExistingPurpose, string ModifiedPurpose)
        {
            try
            {
                string tbl = "";
                pmodel.CREATED_BY = id;
                objmodel.Product = await _objLesseeDetailsModel.GetCaptivePurposeLogDetailsCompareDetails(pmodel);
                pmodellist = await _objLesseeDetailsModel.GetPurposeDetails(pmodel);
                string tbl2 = "";
                tbl2 = "<table id='datatable' class='table table-sm table-bordered compare'>";
                tbl2 = tbl2 + "<thead>";
                tbl2 = tbl2 + "<tr>";
                tbl2 = tbl2 + "<th>Field Names</th><th>Existing Data</th><th>Modified Data</th><th></th>";
                tbl2 = tbl2 + "</tr>";
                tbl2 = tbl2 + "</thead>";
                tbl2 = tbl2 + "<tbody>";
                tbl2 = tbl2 + "<tr>";
                tbl2 = tbl2 + "<td class='field-name'>Lease Purpose</td>";
                tbl2 = tbl2 + "<td>";
                if (ExistingPurpose != null)
                {
                    tbl2 = tbl2 + ExistingPurpose;
                }
                else
                {
                    tbl2 = tbl2 + "<label class='form-control-plaintext'>--</label>";
                }
                tbl2 = tbl2 + "</td>";
                tbl2 = tbl2 + "<td>";
                if (ModifiedPurpose != null)
                {
                    tbl2 = tbl2 + ModifiedPurpose;
                }
                else
                {
                    tbl2 = tbl2 + "<label class='form-control-plaintext'>--</label>";
                }
                tbl2 = tbl2 + "</td>";
                if (ExistingPurpose != ModifiedPurpose)
                {
                    tbl2 = tbl2 + "<td class='text-center'><i class='icon-arrow-alt-circle-left-solid text-danger h4'></i></td>";
                }
                else
                {
                    tbl2 = tbl2 + "<td></td>";
                }
                tbl2 = tbl2 + "</tr>";
                if (ExistingPurpose == "Captive" || ModifiedPurpose == "Captive")
                {
                    int count = objmodel.Product.Count > pmodellist.Count ? objmodel.Product.Count : pmodellist.Count;
                    int colLA = 0;
                    for (int i = 0; i < count; i++)
                    {
                        for (int j = 0; j < count; j++)
                        {
                            int k = 1;
                            j = colLA;
                            if (tbl2.Contains("State"))
                            {
                                tbl2 = tbl2 + "<tr>";
                                tbl2 = tbl2 + "<td></td>";
                            }
                            else
                            {
                                tbl2 = tbl2 + "<tr>";
                                tbl2 = tbl2 + "<td class='field-name'>State</td>";
                            }
                            if (i <= objmodel.Product.Count - 1)
                                tbl2 = tbl2 + "<td>" + objmodel.Product[i].StateName + "</td>";
                            else
                                tbl2 = tbl2 + "<td>--</td>";
                            if (j <= pmodellist.Count - 1)
                                tbl2 = tbl2 + "<td>" + pmodellist[j].StateName + "</td>";
                            else
                                tbl2 = tbl2 + "<td>--</td>";
                            if (i <= objmodel.Product.Count - 1 && j <= pmodellist.Count - 1)
                            {
                                if (objmodel.Product[i].StateName != pmodellist[j].StateName)
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
                    objmodel.Product = await _objLesseeDetailsModel.GetCaptivePurposeLogDetailsCompareDetails(pmodel);
                    pmodellist = await _objLesseeDetailsModel.GetPurposeDetails(pmodel);
                    colLA = 0;
                    for (int i = 0; i < count; i++)
                    {
                        for (int j = 0; j < count; j++)
                        {
                            int L = 1;
                            j = colLA;
                            if (tbl2.Contains("District"))
                            {
                                tbl2 = tbl2 + "<tr>";
                                tbl2 = tbl2 + "<td></td>";
                            }
                            else
                            {
                                tbl2 = tbl2 + "<tr>";
                                tbl2 = tbl2 + "<td class='field-name'>District</td>";
                            }
                            if (i <= objmodel.Product.Count - 1)
                                tbl2 = tbl2 + "<td>" + string.Format(objmodel.Product[i].DisrictName) + "</td>";
                            else
                                tbl2 = tbl2 + "<td>--</td>";
                            if (j <= pmodellist.Count - 1)
                                tbl2 = tbl2 + "<td>" + string.Format(pmodellist[j].DisrictName) + "</td>";
                            else
                                tbl2 = tbl2 + "<td>--</td>";
                            if (i <= objmodel.Product.Count - 1 && j <= pmodellist.Count - 1)
                            {
                                if (objmodel.Product[i].DisrictName != pmodellist[j].DisrictName)
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
                    objmodel.Product = await _objLesseeDetailsModel.GetCaptivePurposeLogDetailsCompareDetails(pmodel);
                    pmodellist = await _objLesseeDetailsModel.GetPurposeDetails(pmodel);
                    colLA = 0;
                    for (int i = 0; i < count; i++)
                    {
                        for (int j = 0; j < count; j++)
                        {
                            int m = 1;
                            j = colLA;
                            if (tbl2.Contains("Type"))
                            {
                                tbl2 = tbl2 + "<tr>";
                                tbl2 = tbl2 + "<td></td>";
                            }
                            else
                            {
                                tbl2 = tbl2 + "<tr>";
                                tbl2 = tbl2 + "<td class='field-name'>Type</td>";
                            }
                            if (i <= objmodel.Product.Count - 1)
                                tbl2 = tbl2 + "<td>" + objmodel.Product[i].UserType + "</td>";
                            else
                                tbl2 = tbl2 + "<td>--</td>";
                            if (j <= pmodellist.Count - 1)
                                tbl2 = tbl2 + "<td>" + pmodellist[j].UserType + "</td>";
                            else
                                tbl2 = tbl2 + "<td>--</td>";
                            if (i <= objmodel.Product.Count - 1 && j <= pmodellist.Count - 1)
                            {
                                if (objmodel.Product[i].UserType != pmodellist[j].UserType)
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
                    objmodel.Product = await _objLesseeDetailsModel.GetCaptivePurposeLogDetailsCompareDetails(pmodel);
                    pmodellist = await _objLesseeDetailsModel.GetPurposeDetails(pmodel);
                    colLA = 0;
                    for (int i = 0; i < count; i++)
                    {
                        for (int j = 0; j < count; j++)
                        {
                            int n = 1;
                            j = colLA;
                            if (tbl2.Contains("User Name"))
                            {
                                tbl2 = tbl2 + "<tr>";
                                tbl2 = tbl2 + "<td></td>";
                            }
                            else
                            {
                                tbl2 = tbl2 + "<tr>";
                                tbl2 = tbl2 + "<td class='field-name'>User Name</td>";
                            }
                            if (i <= objmodel.Product.Count - 1)
                                tbl2 = tbl2 + "<td>" + objmodel.Product[i].CaptiveUserName + "</td>";
                            else
                                tbl2 = tbl2 + "<td>--</td>";
                            if (j <= pmodellist.Count - 1)
                                tbl2 = tbl2 + "<td>" + pmodellist[j].CaptiveUserName + "</td>";
                            else
                                tbl2 = tbl2 + "<td>--</td>";
                            if (i <= objmodel.Product.Count - 1 && j <= pmodellist.Count - 1)
                            {
                                if (objmodel.Product[i].CaptiveUserName != pmodellist[j].CaptiveUserName)
                                {
                                    tbl2 = tbl2 + "<td class='text-center'><i class='icon-arrow-alt-circle-left-solid text-danger h4'></i></td>";
                                }
                                else
                                    tbl2 = tbl2 + "<td></td>";
                            }
                            else
                                tbl2 = tbl2 + "<td class='text-center'><i class='icon-arrow-alt-circle-left-solid text-danger h4'></i></td>";
                            if (n == 1)
                                break;
                        }
                        colLA++;
                    }
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
