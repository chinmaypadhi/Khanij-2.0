// ***********************************************************************
//  Controller Name          : LicenseApplication
//  Desciption               : LicenseApplication Application Details 
//  Created By               : Akshaya Dalei
//  Created On               : 23 July 2021
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using userregistrationApp.ActionFilter;
using userregistrationApp.Areas.Licensee.Models.LicenseeApplication;
using userregistrationApp.Helper;
using userregistrationApp.Models.EncryptDecrypt;
using userregistrationApp.Models.MailService;
using userregistrationApp.Models.SMSService;
using userregistrationApp.Models.WebsiteMenu;
using userregistrationApp.Web;
using userregistrationEF;

namespace userregistrationApp.Areas.License.Controllers
{
    [Area("Licensee")]
    public class LicenseApplicationController : Controller
    {
        private readonly ILicenseeApplicationModel licenseeApplicationModel;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        private readonly IWebsiteMenuModel websiteMenuModel;
        private readonly IMailModel mailModel;
        private readonly ISMSModel sMSModel;
        LicenseMail licenseMail = new LicenseMail();
        IOptions<KeyList> _objKeyList;
        MessageEF messageEF = new MessageEF();
        LicenseApplication licenseApplication = new LicenseApplication();
        List<LicenseApplication> lstlicenseApplication = new List<LicenseApplication>();
        LicenseeDocUploadModel licenseeDocUploadModel = new LicenseeDocUploadModel();
        LicenseFinalApproval LicenseFinalApproval = new LicenseFinalApproval();
        LeaseDeedModel leaseDeedModel = new LeaseDeedModel();
        string OutputResult = "";
        public LicenseApplicationController(ILicenseeApplicationModel licenseeApplicationModel, IHostingEnvironment hostingEnvironment,
            IConfiguration configuration, IWebsiteMenuModel websiteMenuModel, IMailModel mailModel, ISMSModel sMSModel, IOptions<KeyList> objKeyList)
        {
            this.licenseeApplicationModel = licenseeApplicationModel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
            this.websiteMenuModel = websiteMenuModel;
            this.mailModel = mailModel;
            this.sMSModel = sMSModel;
            _objKeyList = objKeyList;
        }

        #region Form 4
        #region Form4 View
        /// <summary>
        /// To View Form4 Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SkipImportantTask]
        [SkipEncryptedTask]
        public IActionResult Form4(string id)
        {
            ViewData["MainmenuTable"] = websiteMenuModel.GetMainmenulist();
            ViewData["FootermenuTable"] = websiteMenuModel.GetFootermenulist();
            if (TempData["result"] != null)
            {
                ViewBag.msg = TempData["result"].ToString();
            }

            lstlicenseApplication = licenseeApplicationModel.GetDistrictListForm4(licenseApplication);
            ViewData["ApplicationForDistrict"] = lstlicenseApplication;

            lstlicenseApplication = licenseeApplicationModel.GetLicenseeType(licenseApplication);
            ViewData["LicenseeType"] = lstlicenseApplication;

            lstlicenseApplication = licenseeApplicationModel.GetMineralTypeList(licenseApplication);
            ViewData["MineralType"] = lstlicenseApplication;

            lstlicenseApplication = licenseeApplicationModel.GetDistrictList(licenseApplication);
            ViewData["District"] = lstlicenseApplication;

            lstlicenseApplication = licenseeApplicationModel.GetApplicantTypeForForm4(licenseApplication);
            ViewData["ApplicantTypeForForm4"] = lstlicenseApplication;

            lstlicenseApplication = licenseeApplicationModel.GetCompanyList(licenseApplication);
            ViewData["Company"] = lstlicenseApplication;

            if (id != null && id != "0")
            {
                licenseApplication.LicenseAppId = Convert.ToInt32(id);
                licenseApplication = licenseeApplicationModel.Edit(licenseApplication);

                licenseApplication.UserId = Convert.ToInt32(id);
                lstlicenseApplication = licenseeApplicationModel.GetMineralNameFromMineralType(licenseApplication);
                ViewData["MineralName"] = lstlicenseApplication;

                lstlicenseApplication = licenseeApplicationModel.GetTehsilListByDistrictID(licenseApplication);
                ViewData["Tehsil"] = lstlicenseApplication;

                licenseApplication.TehsilID = licenseApplication.AppTehsilId;
                lstlicenseApplication = licenseeApplicationModel.GetvillageFromTehsilID(licenseApplication);
                ViewData["Village"] = lstlicenseApplication;
            }

            return View(licenseApplication);
            // return RedirectToAction("Form4", "LicenseApplication", new {area="Licensee", id=11 });
        }
        #endregion

        #region Save Form4
        /// <summary>
        /// Save Form4
        /// </summary>
        /// <param name="model,CapMineralQuantity,CapMineralID,MineralFormCount,MineralGradeCount"></param>
        /// <returns></returns>
        [SkipImportantTask]
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public ActionResult Form4(CreateLicenseApplication model, List<string> CapMineralQuantity, List<string> CapMineralID, List<int?> MineralFormCount, List<int?> MineralGradeCount)
        {
            #region Validate Form4
            //if (string.IsNullOrEmpty(model.DistrictId.ToString()))
            //{
            //    ModelState.AddModelError("DistrictId", "Application District required");
            //}

            #endregion
            //if (ModelState.IsValid)
            //{
            model.MineralFormCount = MineralFormCount;
            model.MineralGradeCount = MineralGradeCount;

            // var application_tyep = "";
            string _mineralId = "";
            string _mineralForm = "";
            string _mineralGrade = "";
            var application_tyep = "";

            DataTable dataTable = new DataTable("Mineral_Wise_Capacity_Quantity");

            if (CapMineralQuantity != null && CapMineralID != null)
            {
                dataTable.Columns.Add("ID", typeof(int));
                dataTable.Columns.Add("MineralId", typeof(int));
                dataTable.Columns.Add("Quantity", typeof(decimal));

                //and fill in some values 

                CreateLicenseApplication.CapacityQuantityModel _productModel;
                List<CreateLicenseApplication.CapacityQuantityModel> _objListModel = new List<CreateLicenseApplication.CapacityQuantityModel>();

                for (var j = 0; j < CapMineralQuantity.Count; j++)
                {
                    _productModel = new CreateLicenseApplication.CapacityQuantityModel();
                    _productModel.MineralId = Convert.ToInt32(CapMineralID[j]);
                    _productModel.Quantity = Convert.ToDecimal(CapMineralQuantity[j]);
                    _objListModel.Add(_productModel);
                }

                for (var i = 0; i < _objListModel.Count; i++)
                {
                    if (_objListModel[i].MineralId != 0 && _objListModel[i].Quantity != 0 && !string.IsNullOrEmpty(_objListModel[i].Quantity.ToString()))
                    {
                        if (i != 0)
                            _mineralId += ",";
                        dataTable.Rows.Add(i + 1, _objListModel[i].MineralId, _objListModel[i].Quantity);
                        _mineralId += _objListModel[i].MineralId.ToString();

                    }
                }

                for (var i = 0; i < MineralFormCount.Count; i++)
                {
                    if (MineralFormCount[i].Value != 0 && MineralFormCount[i].Value != 0 && !string.IsNullOrEmpty(MineralFormCount[i].Value.ToString()))
                    {
                        if (i != 0)
                            _mineralForm += ",";
                        _mineralForm += MineralFormCount[i].Value.ToString();

                    }
                }

                for (var i = 0; i < MineralGradeCount.Count; i++)
                {
                    if (MineralGradeCount[i].Value != 0 && MineralGradeCount[i].Value != 0 && !string.IsNullOrEmpty(MineralGradeCount[i].Value.ToString()))
                    {
                        if (i != 0)
                            _mineralGrade += ",";
                        _mineralGrade += MineralGradeCount[i].Value.ToString();

                    }
                }

            }

            string uniqueNO_MINING_DUE_CERTIFICATE = null;
            string uniqueAFFIDAVITE = null;
            string fileRuniqueNO_MINING_DUE_CERTIFICATEPath = null;
            string fileAFFIDAVITEPath = null;

            string uniqueAFFIDAVITE_JOINTLY_FILE_NAME = null;
            string fileAFFIDAVITE_JOINTLY_FILE_NAMEPath = null;

            string uniqueMAP_LAND_CERTIFICATE = null;
            string fileMAP_LAND_CERTIFICATEPath = null;

            string uniqueLATEST_REVENEW_CERTIFICATE = null;
            string fileLATEST_REVENEW_CERTIFICATEPath = null;

            string uniqueOWNER_LAND_CERTIFICATE = null;
            string fileOWNER_LAND_CERTIFICATEPath = null;

            string uniqueNOC_OTHER_CERTIFICATE = null;
            string fileNOC_OTHER_CERTIFICATEPath = null;

            #region NO_MINING_DUE_CERTIFICATE
            if (model.NO_MINING_DUE_CERTIFICATE != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "FORM4/NO_DUE");
                uniqueNO_MINING_DUE_CERTIFICATE = Guid.NewGuid().ToString() + "_" + model.NO_MINING_DUE_CERTIFICATE.FileName;
                fileRuniqueNO_MINING_DUE_CERTIFICATEPath = Path.Combine(uploadsFolder, uniqueNO_MINING_DUE_CERTIFICATE);
                model.NO_MINING_DUE_CERTIFICATE.CopyTo(new FileStream(fileRuniqueNO_MINING_DUE_CERTIFICATEPath, FileMode.Create));
            }
            #endregion

            #region AFFIDAVITE
            if (model.AFFIDAVITE != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "FORM4/Affidavit_Mineral_Concession");
                uniqueAFFIDAVITE = Guid.NewGuid().ToString() + "_" + model.AFFIDAVITE.FileName;
                fileAFFIDAVITEPath = Path.Combine(uploadsFolder, uniqueAFFIDAVITE);
                model.AFFIDAVITE.CopyTo(new FileStream(fileAFFIDAVITEPath, FileMode.Create));
            }
            #endregion

            #region AFFIDAVITE_JOINTLY_FILE_NAME
            if (model.AFFIDAVITE_JOINTLY != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "FORM4/Affidavit_Mineral_Jointly");
                uniqueAFFIDAVITE_JOINTLY_FILE_NAME = Guid.NewGuid().ToString() + "_" + model.AFFIDAVITE_JOINTLY.FileName;
                fileAFFIDAVITE_JOINTLY_FILE_NAMEPath = Path.Combine(uploadsFolder, uniqueAFFIDAVITE_JOINTLY_FILE_NAME);
                model.AFFIDAVITE_JOINTLY.CopyTo(new FileStream(fileAFFIDAVITE_JOINTLY_FILE_NAMEPath, FileMode.Create));
            }
            #endregion

            #region MAP_LAND_CERTIFICATE
            if (model.MAP_LAND_CERTIFICATE != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "FORM4/Certified_Map");
                uniqueMAP_LAND_CERTIFICATE = Guid.NewGuid().ToString() + "_" + model.MAP_LAND_CERTIFICATE.FileName;
                fileMAP_LAND_CERTIFICATEPath = Path.Combine(uploadsFolder, uniqueMAP_LAND_CERTIFICATE);
                model.MAP_LAND_CERTIFICATE.CopyTo(new FileStream(fileMAP_LAND_CERTIFICATEPath, FileMode.Create));
            }
            #endregion

            #region LATEST_REVENEW_CERTIFICATE
            if (model.LATEST_REVENEW_CERTIFICATE != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "FORM4/LatestRevenew");
                uniqueLATEST_REVENEW_CERTIFICATE = Guid.NewGuid().ToString() + "_" + model.LATEST_REVENEW_CERTIFICATE.FileName;
                fileLATEST_REVENEW_CERTIFICATEPath = Path.Combine(uploadsFolder, uniqueLATEST_REVENEW_CERTIFICATE);
                model.LATEST_REVENEW_CERTIFICATE.CopyTo(new FileStream(fileLATEST_REVENEW_CERTIFICATEPath, FileMode.Create));
            }
            #endregion

            #region OWNER_LAND_CERTIFICATE
            if (model.OWNER_LAND_CERTIFICATE != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "FORM4/Affidavit_Land");
                uniqueOWNER_LAND_CERTIFICATE = Guid.NewGuid().ToString() + "_" + model.OWNER_LAND_CERTIFICATE.FileName;
                fileOWNER_LAND_CERTIFICATEPath = Path.Combine(uploadsFolder, uniqueOWNER_LAND_CERTIFICATE);
                model.OWNER_LAND_CERTIFICATE.CopyTo(new FileStream(fileOWNER_LAND_CERTIFICATEPath, FileMode.Create));
            }
            #endregion

            #region NOC_OTHER_CERTIFICATE
            if (model.NOC_OTHER_CERTIFICATE != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "FORM4/NOC_Certificate");
                uniqueNOC_OTHER_CERTIFICATE = Guid.NewGuid().ToString() + "_" + model.NOC_OTHER_CERTIFICATE.FileName;
                fileNOC_OTHER_CERTIFICATEPath = Path.Combine(uploadsFolder, uniqueNOC_OTHER_CERTIFICATE);
                model.NOC_OTHER_CERTIFICATE.CopyTo(new FileStream(fileNOC_OTHER_CERTIFICATEPath, FileMode.Create));
            }
            #endregion

            model.NO_MINING_DUE_CERTIFICATE_FILE_NAME = uniqueNO_MINING_DUE_CERTIFICATE;
            model.NO_MINING_DUE_CERTIFICATE_FILE_PATH = fileRuniqueNO_MINING_DUE_CERTIFICATEPath;

            model.AFFIDAVITE_FILE_NAME = uniqueAFFIDAVITE;
            model.AFFIDAVITE_FILE_PATH = fileAFFIDAVITEPath;

            model.AFFIDAVITE_JOINTLY_FILE_NAME = uniqueAFFIDAVITE_JOINTLY_FILE_NAME;
            model.AFFIDAVITE_JOINTLY_FILE_PATH = fileAFFIDAVITE_JOINTLY_FILE_NAMEPath;

            model.MAP_LAND_CERTIFICATE_FILE_NAME = uniqueMAP_LAND_CERTIFICATE;
            model.MAP_LAND_CERTIFICATE_FILE_PATH = fileMAP_LAND_CERTIFICATEPath;

            model.LATEST_REVENEW_CERTIFICATE_FILE_NAME = uniqueLATEST_REVENEW_CERTIFICATE;
            model.LATEST_REVENEW_CERTIFICATE_FILE_PATH = fileLATEST_REVENEW_CERTIFICATEPath;

            model.OWNER_LAND_CERTIFICATE_FILE_NAME = uniqueOWNER_LAND_CERTIFICATE;
            model.OWNER_LAND_CERTIFICATE_FILE_PATH = fileOWNER_LAND_CERTIFICATEPath;

            model.NOC_OTHER_CERTIFICATE_FILE_NAME = uniqueNOC_OTHER_CERTIFICATE;
            model.NOC_OTHER_CERTIFICATE_FILE_PATH = fileNOC_OTHER_CERTIFICATEPath;

            model._mineralId = _mineralId;
            model._mineralForm = _mineralForm;
            model._mineralGrade = _mineralGrade;
            if (dataTable.Rows.Count > 0)
                model.dataTable = dataTable;
            else
                model.dataTable = null;

            model.NO_MINING_DUE_CERTIFICATE = null;
            model.AFFIDAVITE = null;
            model.AFFIDAVITE_JOINTLY = null;
            model.MAP_LAND_CERTIFICATE = null;
            model.LATEST_REVENEW_CERTIFICATE = null;
            model.OWNER_LAND_CERTIFICATE = null;
            model.NOC_OTHER_CERTIFICATE = null;
            messageEF = licenseeApplicationModel.Add(model);
            if (messageEF.Satus != "0")
            {
                #region Sent Mail & MSG

                licenseMail.LICENSE_APP_CODE = messageEF.Satus;
                licenseMail = licenseeApplicationModel.GetLicenseDetailsByAppCode(licenseMail);

                //----added on 2-dec-2021 for password encrypt
                #region encryptPassword

                string s = EncryptDecryptSha256.ComputeSha256Hash(licenseMail.PASSWORD).ToUpper();
                string s1 = EncryptDecryptSha256.ComputeSha256Hash(s).ToUpper();
                licenseeApplicationModel.UpdateEncryptPassword(new UpdateEncryptPasswordModel() { UserName = licenseMail.USERNAME, EncryptPassword = s1 });

                #endregion

                #region Send SMS
                try
                {
                    if (!string.IsNullOrEmpty(licenseMail.EMAILADDRESS))
                    {
                        mailModel.SendLicenseApplicationAck(licenseMail);
                    }

                    if (!string.IsNullOrEmpty(licenseMail.MOBILENO))
                    {


                        string msg = "Your Application Reference ID is " + licenseMail.LICENSE_APP_CODE + Environment.NewLine +
                           "has been generated " + Environment.NewLine +
                           "successfully on" + DateTime.Now.Date.ToString("dd-MM-yyyy") + Environment.NewLine +
                          "Please check your e-mail for details of registration. CHiMMS, GoCG";
                        string templateid = "1307161883460589272";
                        sMSModel.Main(new SMS() { mobileNo = licenseMail.MOBILENO, message = msg, templateid = templateid });
                    }
                }
                catch (Exception)
                {

                }

                #endregion


                #endregion
                TempData["result"] = "Your Application Reference ID is " + messageEF.Satus + " has been generated successfully on Dated " + System.DateTime.Now.Date.ToString("dd/MM/yyyy") + ".Your User Name is " + licenseMail.LICENSE_APP_CODE + " and Password is " + licenseMail.PASSWORD + ".Please check your e-mail for details of registration. CHiMMS, GoCG"; // Success
                return RedirectToAction("Form4", "LicenseApplication", new { area = "Licensee" });
            }
            else
            {
                TempData["result"] = "Your FORM-4 has not been submitted. Please try after some time."; // Success
                return RedirectToAction("Form4", "LicenseApplication", new { area = "Licensee" });
            }
            //}
            //else
            //{
            //    return View(model);
            //}

        }

        #endregion

        #region Get Mineral Name By Mineral Type
        /// <summary>
        /// To Get Mineral Name
        /// </summary>
        /// <param name="mineraltypes"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public JsonResult GetCascadeMineral(int? mineraltypes)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                if (mineraltypes != null)
                {
                    licenseApplication.MineralTypeId = mineraltypes;
                    licenseApplication.UserId = profile == null ? null : profile.UserId;
                    lstlicenseApplication = licenseeApplicationModel.GetMineralNameFromMineralType(licenseApplication);
                    return Json(lstlicenseApplication);
                }
                else
                    return Json(null);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }
        #endregion

        #region Get Mineral Form By Mineral Id
        /// <summary>
        /// To Get Mineral Form Name
        /// </summary>
        /// <param name="mineralid"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public JsonResult GetCascadeMineralForm(string mineralid)
        {
            try
            {
                if (mineralid != null)
                {
                    UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                    licenseApplication.MineralId = Convert.ToInt32(mineralid);
                    licenseApplication.UserId = profile == null ? null : profile.UserId;
                    lstlicenseApplication = licenseeApplicationModel.GetMineralNatureListFromMineralIdList(licenseApplication);
                    return Json(lstlicenseApplication);
                }
                else
                    return Json(null);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }
        #endregion

        #region Get Mineral Grade By Mineral Id and Mineral Form Id
        /// <summary>
        /// To Get Mineral Grade
        /// </summary>
        /// <param name="mineralid,MineralNatureList"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public JsonResult GetCascadeMineralGrade(string mineralid, string MineralNatureList)
        {
            try
            {
                if (!string.IsNullOrEmpty(mineralid))
                {
                    UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                    licenseApplication.MineralIdList = mineralid;
                    licenseApplication.MineralNatureList = MineralNatureList;
                    licenseApplication.UserId = profile == null ? null : profile.UserId; //1;
                    lstlicenseApplication = licenseeApplicationModel.GetMineralGradeListFromMineralIdList(licenseApplication);
                    return Json(lstlicenseApplication);
                }
                else
                    return Json(null);
            }
            catch (Exception ex)
            {
                return Json(null);
            }
        }
        #endregion

        #region Get Tehsil Data By District Id
        /// <summary>
        /// To Get TehsilData From DistrictID
        /// </summary>
        /// <param name="DistrictId"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public JsonResult GetTehsilDataFromDistrictID(int? DistrictId)
        {
            try
            {
                licenseApplication.DistrictId = DistrictId;
                lstlicenseApplication = licenseeApplicationModel.GetTehsilListByDistrictID(licenseApplication);
                return Json(lstlicenseApplication);
            }
            catch (Exception)
            {
                return Json(null);
            }
        }
        #endregion

        #region Get Village Data By Tehsil Id
        /// <summary>
        /// To Get Village Data From TehsilID
        /// </summary>
        /// <param name="TehsilId"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public JsonResult GetVillageDataFromTehsilID(int? TehsilId)
        {
            try
            {
                licenseApplication.TehsilID = TehsilId;
                lstlicenseApplication = licenseeApplicationModel.GetvillageFromTehsilID(licenseApplication);
                return Json(lstlicenseApplication);
            }
            catch (Exception)
            {
                return Json(null);
            }
        }
        #endregion

        #endregion

        #region License Approval Detail
        /// <summary>
        /// To Get License Approval List
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>

        public IActionResult LicenseApprovalList()
        {

            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            licenseApplication.UserId = profile.UserId; //29716; //29638;//29648//30742
            lstlicenseApplication = licenseeApplicationModel.View(licenseApplication);
            return View(lstlicenseApplication);
        }
        #endregion

        #region License Payment Process
        /// <summary>
        /// To Get License Payment Process Details
        /// </summary>
        /// <param name="LicenseAppId"></param>
        /// <returns></returns>
        [SkipEncryptedTask]
        public IActionResult LicensePaymentProcess(string LicenseAppId)
        {
            licenseApplication.LicenseAppId = Convert.ToInt32(LicenseAppId);
            licenseApplication = licenseeApplicationModel.PaymentProcessDetail(licenseApplication);
            licenseApplication.LicenseAppId = Convert.ToInt32(LicenseAppId);
            var dataString = CustomQueryStringHelper.
            EncryptString("Payment", "LicensePaymentProcess", "LicensePayment", new { TotalPayment = licenseApplication.TotalPayment, ApplicantName = licenseApplication.ApplicantName, LicenseAppId = licenseApplication.LicenseAppId, StorageCapicity = licenseApplication.StorageCapicity });
            return Redirect(_objKeyList.Value.Paymenturl + dataString);
            // var url = _objKeyList.Value.Paymenturl + "/Payment/LicensePayment/LicensePaymentProcess?TotalPayment=" + licenseApplication.TotalPayment + "&&ApplicantName=" + licenseApplication.ApplicantName + "&&LicenseAppId=" + licenseApplication.LicenseAppId + "&&StorageCapicity=" + licenseApplication.StorageCapicity;
            //return Redirect(url);
            // return View(licenseApplication);
        }
        #endregion

        #region License Registered List For DD
        /// <summary>
        /// To Get License Registered List For DD
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        [SkipEncryptedTask]
        public IActionResult LicenseRegisteredList(string id = "2")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            licenseApplication.StatusId = id;
            licenseApplication.FromDate = "";
            licenseApplication.ToDate = "";
            licenseApplication.UserId = profile.UserId;//29;
            //licenseApplication.UserId = 29;
            lstlicenseApplication = licenseeApplicationModel.LicenseRegisteredList(licenseApplication);
            return View(lstlicenseApplication);
        }
        #endregion

        #region Form4 View With DSC
        /// <summary>
        /// Form4 View With DSC
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         
        [SkipEncryptedTask]
        public IActionResult Form4ViewWithDSC(string id="32")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            ViewBag.DSCReadFilePath = configuration["DSCReadFilePath"];
            licenseApplication.StatusId = id;
            licenseApplication.UserId = profile.UserId; //29;
            licenseApplication = licenseeApplicationModel.Form4Review(licenseApplication);
            return View(licenseApplication);
        }
        #endregion

        #region DSC Response Verify
        string Signature = string.Empty;

        /// <summary>
        /// Check Verify DSC Response
        /// </summary>
        /// <param name="contentType,signDataBase64Encoded,responseType"></param>
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

        /// <summary>
        /// Get DSC Response Data
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Save DSC PDF File
        /// </summary>
        /// <param name="base64BinaryStr,fileName,ID,UpdateIn"></param>
        /// <returns></returns>

        public JsonResult SavePdfFile(string base64BinaryStr, string fileName, int ID, string UpdateIn, string Month_Year)
        {
            string OutputResult = "SUCCESS";
            try
            {
                var ServerPath = "/DSC/WithDSC/" + fileName;
                var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration["FNDSCCreateFilePATH"]);
                var savepath = Path.Combine(RootPath, fileName);
                try
                {
                    string strFinalString = string.Empty;
                    if (base64BinaryStr.Contains("Signature="))
                    {
                        string strWithoutSign = base64BinaryStr.Replace("Signature=", string.Empty);
                        strFinalString = strWithoutSign.Substring(0, strWithoutSign.IndexOf("CommonName"));
                        strFinalString = strFinalString.Replace("==", string.Empty).Replace("\r", string.Empty);
                    }
                    else
                    {
                        strFinalString = base64BinaryStr.Substring(0, base64BinaryStr.IndexOf("CommonName"));
                        strFinalString = strFinalString.Replace("==", string.Empty).Replace("\r", string.Empty);
                    }

                    if ((System.IO.File.Exists(savepath)))
                    {
                        string file = "File Already Exists";
                    }
                    else
                    {
                        byte[] bytes = Convert.FromBase64String(strFinalString);
                        System.IO.FileStream stream = new FileStream(savepath, FileMode.CreateNew);
                        System.IO.BinaryWriter writer = new BinaryWriter(stream);
                        writer.Write(bytes, 0, bytes.Length);
                        writer.Close();
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    OutputResult = "PDF File Save failed. Please try after some time";
                    return Json(OutputResult.ToUpper());
                }

                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                messageEF = licenseeApplicationModel.UpdatedDSCPath(new UpdateDSCPath()
                {
                    fileName = ServerPath,
                    ID = ID,
                    UpdateIn = UpdateIn,
                    UserId = profile.UserId,
                    MonthYear = Month_Year
                });

                if (string.IsNullOrEmpty(messageEF.Satus))
                {
                    OutputResult = "FAILED";
                }

                if (UpdateIn.ToUpper() == "LICENSE_APP_ACK")
                {
                    #region Sent Mail & MSG
                    LicenseFinalApproval = licenseeApplicationModel.LICENSE_APP_ACK(new UpdateDSCPath()
                    {
                        UserId = profile.UserId,
                        ID = ID
                    });
                    string message = "Your application for Storage License has been received by the sanctioning authority. CHiMMS, GoCG";
                    string templateid = "1307161883499215951";
                    sMSModel.Main(new SMS() { mobileNo = LicenseFinalApproval.MOBILENO, message = message, templateid = templateid });
                    #endregion
                }

                if (UpdateIn.ToUpper() == "LICENSE_APP_GRANT_ORDER")
                {
                    #region Sent Mail & MSG
                    LicenseFinalApproval = licenseeApplicationModel.LICENSE_APP_GRANT_ORDER(new UpdateDSCPath()
                    {
                        UserId = profile.UserId,
                        ID = ID
                    });
                    string message = "Dear " + LicenseFinalApproval.APPLICANTNAME + " , Your Storage Permit application Ref ID " + LicenseFinalApproval.LICENSE_APP_CODE + " dated " + LicenseFinalApproval.ApprovedGrantOn + " has been approved and your permit order " + LicenseFinalApproval.License_SI_NO + " has been approved on dated " + System.DateTime.Now.Date.ToString("dd/MM/yyyy") + " . Please login in your portal and pay security fees within 7 days of approved grant order. CHiMMS, GoCG";


                    string templateid = "1307161883503430214";
                    sMSModel.Main(new SMS() { mobileNo = LicenseFinalApproval.MOBILENO, message = message, templateid = templateid });
                    #endregion
                }
            }
            catch (Exception ex)
            {
                OutputResult = "FAILED";
            }
            return Json(OutputResult.ToUpper());
        }

        /// <summary>
        /// Save Normal PDF File
        /// </summary>
        /// <param name="base64BinaryStr,fileName,ID,UpdateIn"></param>
        /// <returns></returns>

        public JsonResult SaveNormalPdfFile(string base64BinaryStr, string fileName, int ID, string UpdateIn)
        {
            string OutputResult = "SUCCESS";
            try
            {

                var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration["FNDSCReadFilePATH"]);
                var savepath = Path.Combine(RootPath, fileName);
                using (FileStream fs = new FileStream(savepath, FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        byte[] data = Convert.FromBase64String(base64BinaryStr);
                        bw.Write(data);
                        bw.Close();
                    }
                    fs.Close();
                }

            }
            catch (Exception ex)
            {
                OutputResult = "FAILED";
            }
            return Json(OutputResult.ToUpper());
        }
        #endregion

        #region License  Uploaded Document
        /// <summary>
        /// To Get License Uploaded Document
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SkipEncryptedTask]
        public ActionResult LicenseUpload(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                if (Convert.ToInt32(id) > 0)
                {
                    UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                    licenseApplication.LicenseAppId = Convert.ToInt32(id);
                    licenseApplication.UserId = profile.UserId; //29;
                    licenseeDocUploadModel = licenseeApplicationModel.LicenseeDocUpload(licenseApplication);
                    return View(licenseeDocUploadModel);
                }
            }
            return RedirectToAction("LicenseRegisteredList");
        }

        /// <summary>
        /// To Save License Uploaded Document
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LicenseUpload(LicenseeDocUploadModel model)
        {
            string uniqueFileNameDemarcation = null;
            string uniqueFileNameEnvironmentClearance = null;
            string uniqueFileNameConsentToOperate = null;
            string uniqueFileNameKhasraPanchsala = null;
            string uniqueFileNameMapPlanofAppliedArea = null;
            string uniqueFileNameForestReport = null;
            string uniqueFileNameRevenueOfficerReport = null;
            string uniqueFileNameSpotInspectionAnalysisReport = null;
            string uniqueFileNameMiningInspectorReport = null;
            string uniqueFileNameGramPanchayatProposal = null;
            //----------------------------------------
            if (model.DemarcationPhoto != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Upload/LicenseAppDocuments");
                uniqueFileNameDemarcation = Guid.NewGuid().ToString() + "_" + model.DemarcationPhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileNameDemarcation);
                model.DemarcationPhoto.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            if (model.EnvironmentalClearancePhoto != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Upload/LicenseAppDocuments");
                uniqueFileNameEnvironmentClearance = Guid.NewGuid().ToString() + "_" + model.EnvironmentalClearancePhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileNameEnvironmentClearance);
                model.EnvironmentalClearancePhoto.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            if (model.ConsentToOperatePhoto != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Upload/LicenseAppDocuments");
                uniqueFileNameConsentToOperate = Guid.NewGuid().ToString() + "_" + model.ConsentToOperatePhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileNameConsentToOperate);
                model.ConsentToOperatePhoto.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            if (model.KhasraPanchsalaPhoto != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Upload/LicenseAppDocuments");
                uniqueFileNameKhasraPanchsala = Guid.NewGuid().ToString() + "_" + model.KhasraPanchsalaPhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileNameKhasraPanchsala);
                model.KhasraPanchsalaPhoto.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            if (model.MapPlanofAppliedAreaPhoto != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Upload/LicenseAppDocuments");
                uniqueFileNameMapPlanofAppliedArea = Guid.NewGuid().ToString() + "_" + model.MapPlanofAppliedAreaPhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileNameMapPlanofAppliedArea);
                model.MapPlanofAppliedAreaPhoto.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            if (model.ForestReportPhoto != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Upload/LicenseAppDocuments");
                uniqueFileNameForestReport = Guid.NewGuid().ToString() + "_" + model.ForestReportPhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileNameForestReport);
                model.ForestReportPhoto.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            if (model.RevenueOfficerReportPhoto != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Upload/LicenseAppDocuments");
                uniqueFileNameRevenueOfficerReport = Guid.NewGuid().ToString() + "_" + model.RevenueOfficerReportPhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileNameRevenueOfficerReport);
                model.RevenueOfficerReportPhoto.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            if (model.SpotInspectionAnalysisReportPhoto != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Upload/LicenseAppDocuments");
                uniqueFileNameSpotInspectionAnalysisReport = Guid.NewGuid().ToString() + "_" + model.SpotInspectionAnalysisReportPhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileNameSpotInspectionAnalysisReport);
                model.SpotInspectionAnalysisReportPhoto.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            if (model.MiningInspectorReportPhoto != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Upload/LicenseAppDocuments");
                uniqueFileNameMiningInspectorReport = Guid.NewGuid().ToString() + "_" + model.MiningInspectorReportPhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileNameMiningInspectorReport);
                model.MiningInspectorReportPhoto.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            if (model.GramPanchayatProposalPhoto != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Upload/LicenseAppDocuments");
                uniqueFileNameGramPanchayatProposal = Guid.NewGuid().ToString() + "_" + model.GramPanchayatProposalPhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileNameGramPanchayatProposal);
                model.GramPanchayatProposalPhoto.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            //-------------------------------------------------
            model.DemarcationReport = uniqueFileNameDemarcation;
            model.EnvironmentalClearanceLetter = uniqueFileNameEnvironmentClearance;
            model.ConsentToOperateLetter = uniqueFileNameConsentToOperate;
            model.KhasraPanchsala = uniqueFileNameKhasraPanchsala;
            model.MapPlanofAppliedArea = uniqueFileNameMapPlanofAppliedArea;
            model.ForestReport = uniqueFileNameForestReport;
            model.RevenueOfficerReport = uniqueFileNameRevenueOfficerReport;
            model.SpotInspectionAnalysisReport = uniqueFileNameSpotInspectionAnalysisReport;
            model.MiningInspectorReport = uniqueFileNameMiningInspectorReport;
            model.GramPanchayatProposal = uniqueFileNameGramPanchayatProposal;
            //------------------------------------------
            model.DemarcationPhoto = null;
            model.EnvironmentalClearancePhoto = null;
            model.ConsentToOperatePhoto = null;
            model.KhasraPanchsalaPhoto = null;
            model.MapPlanofAppliedAreaPhoto = null;
            model.ForestReportPhoto = null;
            model.RevenueOfficerReportPhoto = null;
            model.SpotInspectionAnalysisReportPhoto = null;
            model.MiningInspectorReportPhoto = null;
            model.GramPanchayatProposalPhoto = null;
            //------------------------------------------------
            messageEF = licenseeApplicationModel.AddLicenseeDocUpload(model);
            if (Convert.ToInt32(messageEF.Satus) > 0)
            {
                ViewBag.AckMessage = "1";
                string dataString = CustomQueryStringHelper.EncryptString("Licensee", "Form7", "LicenseApplication", new { id = model.LicenseAppId });
                return LocalRedirect(dataString);
            }
            else
            {
                ViewBag.AckMessage = "2";
                return View(model);
            }
        }
        #endregion

        #region Form6 or Issue Acknowledgement
        /// <summary>
        /// To Get Form6 or Issue Acknowledgement
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         
        [SkipEncryptedTask]
        public IActionResult Form6(string id = "32")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            ViewBag.DSCReadFilePath = configuration["DSCReadFilePath"];
            licenseApplication.StatusId = id;
            licenseApplication.UserId =profile.UserId; //29;
            licenseApplication = licenseeApplicationModel.Form4Review(licenseApplication);
            return View(licenseApplication);
        }
        #endregion

        #region Form7 or Issue Grant Order
        /// <summary>
        /// To Get Form7 or Issue Grant Order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         
        [SkipEncryptedTask]
        public IActionResult Form7(string id="32")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            ViewBag.DSCReadFilePath = configuration["DSCReadFilePath"];
            licenseApplication.LicenseAppId = Convert.ToInt32(id);
            licenseApplication.UserId = profile.UserId; //29;
            licenseApplication.LicenseAppId = Convert.ToInt32(id);
            licenseApplication = licenseeApplicationModel.ViewForm7(licenseApplication);
            return View(licenseApplication);
        }
        #endregion

        #region Security Deposit
        /// <summary>
        /// To Get Security Deposit Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SkipEncryptedTask]
        public IActionResult LicenseSecurityDeposit(string id)
        {

            licenseApplication.LicenseAppId = Convert.ToInt32(id);
            licenseApplication = licenseeApplicationModel.ViewForm7(licenseApplication);
            licenseApplication.LicenseAppId = Convert.ToInt32(id);
            var dataString = CustomQueryStringHelper.
          EncryptString("Payment", "LicenseSecurityDeposit", "LicensePayment", new { TotalPayment = licenseApplication.SecurityAmount, ApplicantName = licenseApplication.ApplicantName, LicenseAppId = licenseApplication.LicenseAppId, StorageCapicity = licenseApplication.StorageCapicity });
            return Redirect(_objKeyList.Value.Paymenturl + dataString);
            //return Redirect(_objKeyList.Value.Paymenturl + "/Payment/LicensePayment/LicenseSecurityDeposit?TotalPayment=" + licenseApplication.SecurityAmount + "&&ApplicantName=" + licenseApplication.ApplicantName + "&&LicenseAppId=" + licenseApplication.LicenseAppId + "&&StorageCapicity=" + licenseApplication.StorageCapicity);
            ///return View(licenseApplication);
        }

        /// <summary>
        /// To Save Security Deposit Details
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LicenseSecurityDeposit(LicenseApplication licenseApplication)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            licenseApplication.UserId = profile.UserId; //29648;
            messageEF = licenseeApplicationModel.AddSecurityDeposit(licenseApplication);
            if (string.IsNullOrEmpty(messageEF.Satus))
            {
                TempData["AckMessage"] = "Payment cannot done.Please try again!";
                return RedirectToAction("LicenseSecurityDeposit", new { id = licenseApplication.LicenseAppId });
            }
            else
            {
                TempData["AckMessage"] = "Payment cannot done.Please try again!";
                return RedirectToAction("LicenseSecurityDeposit", new { id = licenseApplication.LicenseAppId });
            }
        }
        #endregion
        
        #region Final Approval Of DD for Issue Grant Order
        /// <summary>
        /// Final Approval Of DD for Issue Grant Order
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult FinalLicenseApproved(string Licid)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            LicenseFinalApproval licenseFinalApproval = new LicenseFinalApproval();
            licenseApplication.LicenseAppId = Convert.ToInt32(Licid);
            licenseApplication.UserId = profile.UserId; //29;
            licenseApplication.UserLoginId = profile.UserLoginId;
            licenseFinalApproval = licenseeApplicationModel.LicenseFinalApprovalDetails(licenseApplication);

            #region Mail & SMS
            #region encryptPassword

            string s = EncryptDecryptSha256.ComputeSha256Hash(licenseFinalApproval.PASSWORD).ToUpper();
            string s1 = EncryptDecryptSha256.ComputeSha256Hash(s).ToUpper();
            licenseeApplicationModel.UpdateEncryptPassword(new UpdateEncryptPasswordModel() { UserName = licenseFinalApproval.USERNAME, EncryptPassword = s1 });

            #endregion

            try
            {
                if (!string.IsNullOrEmpty(licenseFinalApproval.EMAILADDRESS))
                {
                    mailModel.SendLicenseApprovedAck(new LicenseMail()
                    {
                        EMAILADDRESS = licenseFinalApproval.EMAILADDRESS,
                        LICENSE_APP_CODE = licenseFinalApproval.LICENSE_APP_CODE,
                        USERNAME = licenseFinalApproval.USERNAME,
                        PASSWORD = licenseFinalApproval.PASSWORD,
                        APPLICANTNAME = licenseFinalApproval.APPLICANTNAME,
                        application_tyep = licenseFinalApproval.application_tyep
                    });


                }

                if (!string.IsNullOrEmpty(licenseFinalApproval.MOBILENO))
                {
                    string msg = "Your License Application Reference ID is " + licenseFinalApproval.LICENSE_APP_CODE + Environment.NewLine +
                       "has been approved " + Environment.NewLine +
                       "successfully on" + DateTime.Now.Date.ToString("dd-MM-yyyy") + Environment.NewLine +
                      "Please check your e-mail for details of registration. CHiMMS, GoCG ";


                    string templateid = "1307161883460589272";
                    sMSModel.Main(new SMS() { mobileNo = licenseFinalApproval.MOBILENO, message = msg, templateid = templateid });
                }
            }
            catch (Exception)
            {

            }


            #endregion
            return Json(licenseFinalApproval.Status);
        }
        #endregion

        [SkipEncryptedTask]
        public FileResult Download(string name, string path)
        {
            try
            {
                var absolutePath = Path.Combine(path);
                //var absolutePath = Path.Combine(Server.MapPath("~/Upload/"), path);

                if (System.IO.File.Exists(absolutePath))
                {
                    return File(new FileStream(absolutePath, FileMode.Open), "application/octetstream", name);
                }
                return null;
            }

            catch (Exception ex)
            {
                throw ex;
                //return null;
            }
        }

        public IActionResult LeaseDeedExtendRequest()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            licenseApplication.FromDate = "";
            licenseApplication.ToDate = "";
            licenseApplication.UserId = profile.UserId;
            lstlicenseApplication = licenseeApplicationModel.ExtendLeaseDeedDetails(licenseApplication);
            return View(lstlicenseApplication);
        }

        public JsonResult ApproveLeaseDeedExtendRequest(string LicId)
        {
            if (!string.IsNullOrEmpty(LicId))
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                licenseApplication.LicenseAppId = Convert.ToInt32(LicId);
                licenseApplication.UserId = profile.UserId;
                messageEF = licenseeApplicationModel.ApproveExtendLeaseDeedDetails(licenseApplication);
                if (messageEF.Satus == "1")
                {
                    return Json("Lease Deed Extended Successfully");
                }
                else
                {
                    return Json("Lease Deed Extended Failed");
                }
            }
            else
            {
                return Json("Lease Deed Extended Failed");
            }
        }

        #region Lease Deed Upload

        [SkipEncryptedTask]
        public IActionResult UploadDeed(string id = "5")
        {
             
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            licenseApplication.UserId = profile.UserId; //29716; //29638;//29648//30742
            lstlicenseApplication = licenseeApplicationModel.View(licenseApplication);

            leaseDeedModel.Lease_Deed_Validity = lstlicenseApplication[0].Lease_Deed_Validity;
            leaseDeedModel.LeaseUploadFirstDate = lstlicenseApplication[0].LeaseUploadFirstDate;
            leaseDeedModel.LeaseUploadLastDate = lstlicenseApplication[0].LeaseUploadLastDate;
            leaseDeedModel.ExtendedDeedStatus = lstlicenseApplication[0].ExtendedDeedStatus;
            leaseDeedModel.LicenseAppId = Convert.ToInt32(id);
            return View(leaseDeedModel);
        }
        [HttpPost]

        public IActionResult UploadDeed(LeaseDeedModel leaseDeedModel, string Extend)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                leaseDeedModel.UserId = profile.UserId;
                #region Upload File 
                string uniqueFileNameDeed = null;
                if (leaseDeedModel.LeaseDeedFile != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Upload/LicenseAppDocuments");
                    uniqueFileNameDeed = Guid.NewGuid().ToString() + "_" + leaseDeedModel.LeaseDeedFile.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileNameDeed);
                    string VirtualfilePath = Path.Combine(configuration.GetSection("UploadPath").GetValue<string>("LiceneePath"), uniqueFileNameDeed);
                    leaseDeedModel.LeaseDeedFile.CopyTo(new FileStream(filePath, FileMode.Create));
                    leaseDeedModel.Lease_Deed_File_Name = uniqueFileNameDeed;
                    leaseDeedModel.Lease_Deed_File_Path = VirtualfilePath;
                }
                leaseDeedModel.LeaseDeedFile = null;
                #endregion
                if (ModelState.IsValid)
                {

                    messageEF = licenseeApplicationModel.LeaseDeedUpload(leaseDeedModel);
                    if (messageEF.Satus == "1" && Extend == "No")
                    {
                        TempData["DeedMsg"] = "Deed Uploaded Sucessfully";
                        TempData.Keep("DeedMsg");
                        return RedirectToAction("LicenseApprovalList");

                    }
                    else if (messageEF.Satus == "1" && Extend == "Yes")
                    {
                        licenseApplication.LicenseAppId = leaseDeedModel.LicenseAppId;
                        licenseApplication = licenseeApplicationModel.ViewForm7(licenseApplication);
                        licenseApplication.LicenseAppId = leaseDeedModel.LicenseAppId;
                        var dataString = CustomQueryStringHelper.
                        EncryptString("Payment", "LicenseLeaseDeedFine", "LicensePayment", new { TotalPayment = licenseApplication.DeedFineAmount, ApplicantName = licenseApplication.ApplicantName, LicenseAppId = licenseApplication.LicenseAppId, StorageCapicity = licenseApplication.StorageCapicity });
                        return Redirect(_objKeyList.Value.Paymenturl + dataString);
                    }
                    else
                    {
                        TempData["AckMessage"] = "There is some problem in Uploading!";
                        TempData.Keep("AckMessage");
                        return RedirectToAction("UploadDeed", new { id = licenseApplication.LicenseAppId });
                    }
                }
                else
                {
                    return View(new LeaseDeedModel());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public JsonResult ApproveLeaseDeed(string Licid)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            LeaseDeedModel leaseDeedModel = new LeaseDeedModel();
            leaseDeedModel.LicenseAppId = Convert.ToInt32(Licid);
            leaseDeedModel.UserId = profile.UserId; //29;
            leaseDeedModel.ApprovedDeedBy = profile.UserId;
            messageEF = licenseeApplicationModel.ApproveLeaseDeed(leaseDeedModel);
            LicenseFinalApproval licenseFinalApproval = new LicenseFinalApproval();
            if (messageEF.Satus == "1")
            {

                #region Licensee Final Approve 
                licenseApplication.LicenseAppId = Convert.ToInt32(Licid);
                licenseApplication.UserId = profile.UserId; //29;
                licenseApplication.UserLoginId = profile.UserLoginId;
                licenseFinalApproval = licenseeApplicationModel.LicenseFinalApprovalDetails(licenseApplication);

                #region Mail & SMS
                #region encryptPassword

                string s = EncryptDecryptSha256.ComputeSha256Hash(licenseFinalApproval.PASSWORD).ToUpper();
                string s1 = EncryptDecryptSha256.ComputeSha256Hash(s).ToUpper();
                licenseeApplicationModel.UpdateEncryptPassword(new UpdateEncryptPasswordModel() { UserName = licenseFinalApproval.USERNAME, EncryptPassword = s1 });

                #endregion

                try
                {
                    if (!string.IsNullOrEmpty(licenseFinalApproval.EMAILADDRESS))
                    {
                        mailModel.SendLicenseApprovedAck(new LicenseMail()
                        {
                            EMAILADDRESS = licenseFinalApproval.EMAILADDRESS,
                            LICENSE_APP_CODE = licenseFinalApproval.LICENSE_APP_CODE,
                            USERNAME = licenseFinalApproval.USERNAME,
                            PASSWORD = licenseFinalApproval.PASSWORD,
                            APPLICANTNAME = licenseFinalApproval.APPLICANTNAME,
                            application_tyep = licenseFinalApproval.application_tyep
                        });


                    }

                    if (!string.IsNullOrEmpty(licenseFinalApproval.MOBILENO))
                    {
                        string msg = "Your License Application Reference ID is " + licenseFinalApproval.LICENSE_APP_CODE + Environment.NewLine +
                           "has been approved " + Environment.NewLine +
                           "successfully on" + DateTime.Now.Date.ToString("dd-MM-yyyy") + Environment.NewLine +
                          "Please check your e-mail for details of registration. CHiMMS, GoCG ";


                        string templateid = "1307161883460589272";
                        sMSModel.Main(new SMS() { mobileNo = licenseFinalApproval.MOBILENO, message = msg, templateid = templateid });
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                }


                #endregion
                #endregion
            }
            else
            {
                licenseFinalApproval.Status = "FAILED";
            }
            return Json(licenseFinalApproval.Status);
        }

        #endregion

        #region Lease Deed Fine Deposit
        [SkipEncryptedTask]
        public IActionResult LeaseDeedFineDeposit(string id)
        {

            licenseApplication.LicenseAppId = Convert.ToInt32(id);
            licenseApplication = licenseeApplicationModel.ViewForm7(licenseApplication);
            licenseApplication.LicenseAppId = Convert.ToInt32(id);
            var dataString = CustomQueryStringHelper.
            EncryptString("Payment", "LicenseLeaseDeedFine", "LicensePayment", new { TotalPayment = licenseApplication.DeedFineAmount, ApplicantName = licenseApplication.ApplicantName, LicenseAppId = licenseApplication.LicenseAppId, StorageCapicity = licenseApplication.StorageCapicity });
            return Redirect(_objKeyList.Value.Paymenturl + dataString);
            //return Redirect(_objKeyList.Value.Paymenturl + "/Payment/LicensePayment/LicenseSecurityDeposit?TotalPayment=" + licenseApplication.SecurityAmount + "&&ApplicantName=" + licenseApplication.ApplicantName + "&&LicenseAppId=" + licenseApplication.LicenseAppId + "&&StorageCapicity=" + licenseApplication.StorageCapicity);
            ///return View(licenseApplication);
        }
        #endregion

        #region Issue Grant Order
        public JsonResult IssueGrantOrder(string Licid,string ApplicantName,string Mobile)
        {
            try
            {
                if (!string.IsNullOrEmpty(Licid))
                {
                    UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                    licenseApplication.LicenseAppId = Convert.ToInt32(Licid);
                    licenseApplication.UserId = profile.UserId;
                    messageEF = licenseeApplicationModel.IssueGrantOrder(licenseApplication);
                    if (messageEF.Satus == "1")
                    {
                        #region SMS
                        string message = "Dear " + ApplicantName + " , Your Grant Order has been approved on dated " + System.DateTime.Now.Date.ToString("dd/MM/yyyy") + " . Please login in your portal and upload Lease Deed within 90 days of approved grant order. CHiMMS, GoCG";


                        string templateid = "1307161883499215951";
                        sMSModel.Main(new SMS() { mobileNo = Mobile, message = message, templateid = templateid });
                        #endregion

                        return Json("SUCCESS");
                    }
                    else
                    {
                        return Json("FAILED");
                    }
                }
                else
                {
                    return Json("FAILED");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }
    }
}
