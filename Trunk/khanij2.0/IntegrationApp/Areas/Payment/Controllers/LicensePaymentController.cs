using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetIntegrationKit;
using IntegrationApp.ActionFilter;
using IntegrationApp.Areas.Payment.Models.LicensePaymentDetails;
using IntegrationApp.Helper;
using IntegrationApp.Models.SBIEncryptDecryptKey;
using IntegrationApp.Web;
using IntegrationEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace IntegrationApp.Areas.Payment.Controllers
{
    [Area("Payment")]
    public class LicensePaymentController : Controller
    {
        private readonly ILicensePaymentModel licensePaymentModel;
        private IConfiguration configuration;
        private readonly IsbiIncriptDecript sbiIncriptDecript;
        IOptions<KeyList> _objKeyList;
        MessageEF messageEF = new MessageEF();
        LicenseApplication licenseApplication = new LicenseApplication();
        LicensePaymentDetail licensePaymentDetail = new LicensePaymentDetail();
        PaymentModel payment = new PaymentModel();
        RequestURL objRequestURL = new RequestURL();
        public LicensePaymentController(ILicensePaymentModel licensePaymentModel, IConfiguration _configuration,
            IsbiIncriptDecript sbiIncriptDecript, IOptions<KeyList> objKeyList)
        {
            this.licensePaymentModel = licensePaymentModel;
            this.configuration = _configuration;
            this.sbiIncriptDecript = sbiIncriptDecript;
            _objKeyList = objKeyList;
        }

        #region Registration Fee
        [SkipImportantTask]
        public IActionResult LicensePaymentProcess(string TotalPayment, string ApplicantName, string LicenseAppId, string StorageCapicity)
        {
            licenseApplication.TotalPayment = Convert.ToDecimal(TotalPayment);
            licenseApplication.ApplicantName = ApplicantName;
            licenseApplication.LicenseAppId = Convert.ToInt32(LicenseAppId);
            licenseApplication.StorageCapicity = StorageCapicity;
            return View(licenseApplication);
        }

        [HttpPost]
        public IActionResult LicensePaymentProcess(LicenseApplication licenseApplication)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            licensePaymentDetail.UserId =profile.UserId;//30742;
            licensePaymentDetail.UserLoginId =profile.UserLoginId;//1599804;
            licensePaymentDetail.LicenseAppId = licenseApplication.LicenseAppId;
            licensePaymentDetail.TotalPayment = licenseApplication.TotalPayment;
            licensePaymentDetail.PaymentBank = (licenseApplication.PaymentBank == "DEMOBANK" ? "SBI" : licenseApplication.PaymentBank); 
            licensePaymentDetail.PaymentMode = licenseApplication.PaymentMode;
            messageEF = licensePaymentModel.GetLicensePaymentDetails(licensePaymentDetail);
            if (string.IsNullOrEmpty(messageEF.Satus))
            {
                //TempData["AckMessage"] = "Payment cannot done.Please try again!";
                return Redirect(_objKeyList.Value.Redirecturl + "Licensee/LicenseApplication/LicensePaymentProcess?LicenseAppId=" + licenseApplication.LicenseAppId);
            }
            else
            {

                string response = string.Empty;
                licensePaymentDetail.PaymentRefId = messageEF.Satus;
                payment = licensePaymentModel.GetLicensePaymentGateway(licensePaymentDetail);

                #region SBI
                if (licenseApplication.PaymentBank == "SBI")
                {
                    var SBIRequestString = string.Empty;


                    objRequestURL.TPSLService = Convert.ToString(configuration.GetSection("Path").GetSection("SBIService").Value); //Convert.ToString(ConfigurationManager.AppSettings["SBIService"]);
                    objRequestURL.LogFilePath = string.Empty;
                    objRequestURL.ErrorFile = string.Empty;

                    payment.TPSLTXNID = licensePaymentDetail.PaymentRefId;
                    payment.Amount = Convert.ToDecimal(licenseApplication.TotalPayment).ToString("0.00");
                    payment.Shoppingcartdetails = "TEST_" + licenseApplication.TotalPayment + "_0.0";


                    SBIRequestString = "ApplicantName=" + payment.customerName.ToString() //ApplicantName
                                                          + "|EmailId=" + payment.Email.ToString() //EmailId
                                                          + "|MobileNo=" + payment.mobileNo.ToString() //MobileNo
                                                          + "|CLNT_TXN_NO=" + payment.MerchantTxnRefNumber.ToString() //CLNT_TXN_NO
                                                          + "|Amount=" + Convert.ToDecimal(licenseApplication.TotalPayment).ToString("0.00") //TXN_AMOUNT
                                                          + "|Payment_Bifurcation=" + payment.ITC
                                                          + "|ReturnUrl=" + Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrl").Value);








                    string checksum = sbiIncriptDecript.GetSHA256(SBIRequestString);
                    SBIRequestString += "|checkSum=" + checksum;
                    string SBIPostRequest = sbiIncriptDecript.EncryptWithKey(SBIRequestString);

                    string SBIURL = Convert.ToString(configuration.GetSection("Path").GetSection("SBIService").Value);

                    #region Insert Payment Request Data
                    payment.UserId = profile.UserId;
                    payment.returnURL = Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrl").Value);
                    payment.S2SReturnURL = Convert.ToString(configuration.GetSection("Path").GetSection("S2SReturnURL").Value);
                    payment.PropertyPath = Convert.ToString(configuration.GetSection("Path").GetSection("SBIPropertyPath").Value);
                    payment.PaymentEncryptedData = SBIPostRequest;
                    payment.Currencycode = "INR";
                    licensePaymentModel.InsertLicensePaymentRequest(payment);
                    #endregion

                    var msgdisp = "<html><form name='s1_2' id='s1_2' action='" + SBIURL + "' method='post'> ";
                    msgdisp += "<input name='encdata' value='" + SBIPostRequest + "' type='hidden'>";
                    msgdisp += "<input name='merchant_code' value='MINERAL_DEPT' type='hidden'>";
                    msgdisp += "<script type='text/javascript' language='javascript' >document.getElementById('s1_2').submit();";
                    msgdisp += "</script>";
                    msgdisp += "<script language='javascript' >";
                    msgdisp += "</ script >";
                    msgdisp += "</form></html> ";
                    return Content(msgdisp, "text/html");
                }
                #endregion

                #region DEMO BANK
                if (licenseApplication.PaymentBank == "DEMOBANK")
                {
                    var DEMOBANKRequestString = string.Empty;


                    objRequestURL.TPSLService = Convert.ToString(configuration.GetSection("Path").GetSection("DemoBankUrl").Value); //Convert.ToString(ConfigurationManager.AppSettings["SBIService"]);
                    objRequestURL.LogFilePath = string.Empty;
                    objRequestURL.ErrorFile = string.Empty;

                    payment.TPSLTXNID = licensePaymentDetail.PaymentRefId;
                    payment.Amount = Convert.ToDecimal(licenseApplication.TotalPayment).ToString("0.00");
                    payment.Shoppingcartdetails = "TEST_" + licenseApplication.TotalPayment + "_0.0";


                    DEMOBANKRequestString = "ApplicantName=" + payment.customerName.ToString() //ApplicantName
                                                      + "|EmailId=" + payment.Email.ToString() //EmailId
                                                      + "|MobileNo=" + payment.mobileNo.ToString() //MobileNo
                                                      + "|CLNT_TXN_NO=" + payment.MerchantTxnRefNumber.ToString() //CLNT_TXN_NO
                                                      + "|Amount=" + Convert.ToDecimal(licenseApplication.TotalPayment).ToString("0.00") //TXN_AMOUNT
                                                      + "|Payment_Bifurcation=" + payment.ITC
                                                      + "|ReturnUrl=" + Convert.ToString(configuration.GetSection("Path").GetSection("DemoBankReturnUrl").Value);

                    string checksum = sbiIncriptDecript.GetSHA256(DEMOBANKRequestString);
                    DEMOBANKRequestString += "|checkSum=" + checksum;
                    string DEMOBANKPostRequest = sbiIncriptDecript.EncryptWithKey(DEMOBANKRequestString);
                    string DEMOBANKURL = Convert.ToString(configuration.GetSection("Path").GetSection("DemoBankUrl").Value);

                    #region Insert Payment Request Data
                    payment.UserId =profile.UserId;
                    payment.returnURL = Convert.ToString(configuration.GetSection("Path").GetSection("DemoBankReturnUrl").Value);
                    payment.S2SReturnURL = Convert.ToString(configuration.GetSection("Path").GetSection("DemoBankReturnUrl").Value);
                    payment.PropertyPath = Convert.ToString(configuration.GetSection("Path").GetSection("SBIPropertyPath").Value);
                    payment.PaymentEncryptedData = DEMOBANKPostRequest;
                    payment.Currencycode = "INR";
                    licensePaymentModel.InsertLicensePaymentRequest(payment);
                    #endregion
                    HttpContext.Session.Set<PaymentModel>("DemoBank", payment);
                    return RedirectToAction("DEMOBANK", "DEMOBANK", new { area = "Payment" });

                }
                #endregion
                return null;
            }

        }
        #endregion

        #region Security Deposit
        [SkipImportantTask]
        public IActionResult LicenseSecurityDeposit(string TotalPayment, string ApplicantName, string LicenseAppId, string StorageCapicity)
        {
            licenseApplication.TotalPayment = Convert.ToDecimal(TotalPayment);
            licenseApplication.ApplicantName = ApplicantName;
            licenseApplication.LicenseAppId = Convert.ToInt32(LicenseAppId);
            licenseApplication.StorageCapicity = StorageCapicity;
            return View(licenseApplication);
        }

        [HttpPost]
        public IActionResult LicenseSecurityDeposit(LicenseApplication licenseApplication)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            licenseApplication.UserId = profile.UserId; //29648;
            licenseApplication.UserLoginId = profile.UserLoginId;
            messageEF = licensePaymentModel.AddSecurityDeposit(licenseApplication);
            if (string.IsNullOrEmpty(messageEF.Satus))
            {
                return Redirect(_objKeyList.Value.Redirecturl + "Licensee/LicenseApplication/LicenseSecurityDeposit?id=" + licenseApplication.LicenseAppId);
            }
            else
            {
                string response = string.Empty;
                licensePaymentDetail.UserId = profile.UserId;//30742;
                licensePaymentDetail.UserLoginId = profile.UserLoginId;//1599804;
                licensePaymentDetail.LicenseAppId = licenseApplication.LicenseAppId;
                licensePaymentDetail.TotalPayment = licenseApplication.TotalPayment;
                licensePaymentDetail.PaymentBank = (licenseApplication.PaymentBank == "DEMOBANK" ? "SBI" : licenseApplication.PaymentBank);
                licensePaymentDetail.PaymentMode = licenseApplication.PaymentMode;
                licensePaymentDetail.PaymentRefId = messageEF.Satus;
                payment = licensePaymentModel.GetLicensePaymentGateway(licensePaymentDetail);

                #region SBI
                if (licenseApplication.PaymentBank == "SBI")
                {
                    var SBIRequestString = string.Empty;


                    objRequestURL.TPSLService = Convert.ToString(configuration.GetSection("Path").GetSection("SBIService").Value); //Convert.ToString(ConfigurationManager.AppSettings["SBIService"]);
                    objRequestURL.LogFilePath = string.Empty;
                    objRequestURL.ErrorFile = string.Empty;

                    payment.TPSLTXNID = licensePaymentDetail.PaymentRefId;
                    payment.Amount = Convert.ToDecimal(licenseApplication.TotalPayment).ToString("0.00");
                    payment.Shoppingcartdetails = "TEST_" + licenseApplication.TotalPayment + "_0.0";


                    SBIRequestString = "ApplicantName=" + payment.customerName.ToString() //ApplicantName
                                                          + "|EmailId=" + payment.Email.ToString() //EmailId
                                                          + "|MobileNo=" + payment.mobileNo.ToString() //MobileNo
                                                          + "|CLNT_TXN_NO=" + payment.MerchantTxnRefNumber.ToString() //CLNT_TXN_NO
                                                          + "|Amount=" + Convert.ToDecimal(licenseApplication.TotalPayment).ToString("0.00") //TXN_AMOUNT
                                                          + "|Payment_Bifurcation=" + payment.ITC
                                                          + "|ReturnUrl=" + Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrl").Value);








                    string checksum = sbiIncriptDecript.GetSHA256(SBIRequestString);
                    SBIRequestString += "|checkSum=" + checksum;
                    string SBIPostRequest = sbiIncriptDecript.EncryptWithKey(SBIRequestString);

                    string SBIURL = Convert.ToString(configuration.GetSection("Path").GetSection("SBIService").Value);

                    #region Insert Payment Request Data
                    payment.UserId = profile.UserId;
                    payment.returnURL = Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrl").Value);
                    payment.S2SReturnURL = Convert.ToString(configuration.GetSection("Path").GetSection("S2SReturnURL").Value);
                    payment.PropertyPath = Convert.ToString(configuration.GetSection("Path").GetSection("SBIPropertyPath").Value);
                    payment.PaymentEncryptedData = SBIPostRequest;
                    payment.Currencycode = "INR";
                    licensePaymentModel.InsertLicensePaymentRequest(payment);
                    #endregion

                    var msgdisp = "<html><form name='s1_2' id='s1_2' action='" + SBIURL + "' method='post'> ";
                    msgdisp += "<input name='encdata' value='" + SBIPostRequest + "' type='hidden'>";
                    msgdisp += "<input name='merchant_code' value='MINERAL_DEPT' type='hidden'>";
                    msgdisp += "<script type='text/javascript' language='javascript' >document.getElementById('s1_2').submit();";
                    msgdisp += "</script>";
                    msgdisp += "<script language='javascript' >";
                    msgdisp += "</ script >";
                    msgdisp += "</form></html> ";
                    return Content(msgdisp, "text/html");
                }
                #endregion

                #region DEMO BANK
                if (licenseApplication.PaymentBank == "DEMOBANK")
                {
                    var DEMOBANKRequestString = string.Empty;


                    objRequestURL.TPSLService = Convert.ToString(configuration.GetSection("Path").GetSection("DemoBankUrl").Value); //Convert.ToString(ConfigurationManager.AppSettings["SBIService"]);
                    objRequestURL.LogFilePath = string.Empty;
                    objRequestURL.ErrorFile = string.Empty;

                    payment.TPSLTXNID = licensePaymentDetail.PaymentRefId;
                    payment.Amount = Convert.ToDecimal(licenseApplication.TotalPayment).ToString("0.00");
                    payment.Shoppingcartdetails = "TEST_" + licenseApplication.TotalPayment + "_0.0";


                    DEMOBANKRequestString = "ApplicantName=" + payment.customerName.ToString() //ApplicantName
                                                      + "|EmailId=" + payment.Email.ToString() //EmailId
                                                      + "|MobileNo=" + payment.mobileNo.ToString() //MobileNo
                                                      + "|CLNT_TXN_NO=" + payment.MerchantTxnRefNumber.ToString() //CLNT_TXN_NO
                                                      + "|Amount=" + Convert.ToDecimal(licenseApplication.TotalPayment).ToString("0.00") //TXN_AMOUNT
                                                      + "|Payment_Bifurcation=" + payment.ITC
                                                      + "|ReturnUrl=" + Convert.ToString(configuration.GetSection("Path").GetSection("DemoBankReturnUrl").Value);

                    string checksum = sbiIncriptDecript.GetSHA256(DEMOBANKRequestString);
                    DEMOBANKRequestString += "|checkSum=" + checksum;
                    string DEMOBANKPostRequest = sbiIncriptDecript.EncryptWithKey(DEMOBANKRequestString);
                    string DEMOBANKURL = Convert.ToString(configuration.GetSection("Path").GetSection("DemoBankUrl").Value);

                    #region Insert Payment Request Data
                    payment.UserId = profile.UserId;
                    payment.returnURL = Convert.ToString(configuration.GetSection("Path").GetSection("DemoBankReturnUrl").Value);
                    payment.S2SReturnURL = Convert.ToString(configuration.GetSection("Path").GetSection("DemoBankReturnUrl").Value);
                    payment.PropertyPath = Convert.ToString(configuration.GetSection("Path").GetSection("SBIPropertyPath").Value);
                    payment.PaymentEncryptedData = DEMOBANKPostRequest;
                    payment.Currencycode = "INR";
                    licensePaymentModel.InsertLicensePaymentRequest(payment);
                    #endregion
                    HttpContext.Session.Set<PaymentModel>("DemoBank", payment);
                    return RedirectToAction("DEMOBANK", "DEMOBANK", new { area = "Payment" });

                }
                #endregion
                return null;
            }
        }

        #endregion
        #region Lease deed Payment
        [SkipImportantTask]
        public IActionResult LicenseLeaseDeedFine(string TotalPayment, string ApplicantName, string LicenseAppId)
        {
            licenseApplication.TotalPayment = Convert.ToDecimal(TotalPayment);
            licenseApplication.ApplicantName = ApplicantName;
            licenseApplication.LicenseAppId = Convert.ToInt32(LicenseAppId);
            return View(licenseApplication);
        }

        [HttpPost]
        public IActionResult LicenseLeaseDeedFine(LicenseApplication licenseApplication)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            licenseApplication.UserId = profile.UserId; //29648;
            licenseApplication.UserLoginId = profile.UserLoginId;
            messageEF = licensePaymentModel.AddLeaseDeedFine(licenseApplication);
            if (string.IsNullOrEmpty(messageEF.Satus))
            {
                return Redirect(_objKeyList.Value.Redirecturl + "Licensee/LicenseApplication/LicenseLeaseDeedFine?id=" + licenseApplication.LicenseAppId);
            }
            else
            {
                string response = string.Empty;
                licensePaymentDetail.UserId = profile.UserId;//30742;
                licensePaymentDetail.UserLoginId = profile.UserLoginId;//1599804;
                licensePaymentDetail.LicenseAppId = licenseApplication.LicenseAppId;
                licensePaymentDetail.TotalPayment = licenseApplication.TotalPayment;
                licensePaymentDetail.PaymentBank = (licenseApplication.PaymentBank == "DEMOBANK" ? "SBI" : licenseApplication.PaymentBank);
                licensePaymentDetail.PaymentMode = licenseApplication.PaymentMode;
                licensePaymentDetail.PaymentRefId = messageEF.Satus;
                payment = licensePaymentModel.GetLicensePaymentGateway(licensePaymentDetail);

                #region SBI
                if (licenseApplication.PaymentBank == "SBI")
                {
                    var SBIRequestString = string.Empty;


                    objRequestURL.TPSLService = Convert.ToString(configuration.GetSection("Path").GetSection("SBIService").Value); //Convert.ToString(ConfigurationManager.AppSettings["SBIService"]);
                    objRequestURL.LogFilePath = string.Empty;
                    objRequestURL.ErrorFile = string.Empty;

                    payment.TPSLTXNID = licensePaymentDetail.PaymentRefId;
                    payment.Amount = Convert.ToDecimal(licenseApplication.TotalPayment).ToString("0.00");
                    payment.Shoppingcartdetails = "TEST_" + licenseApplication.TotalPayment + "_0.0";


                    SBIRequestString = "ApplicantName=" + payment.customerName.ToString() //ApplicantName
                                                          + "|EmailId=" + payment.Email.ToString() //EmailId
                                                          + "|MobileNo=" + payment.mobileNo.ToString() //MobileNo
                                                          + "|CLNT_TXN_NO=" + payment.MerchantTxnRefNumber.ToString() //CLNT_TXN_NO
                                                          + "|Amount=" + Convert.ToDecimal(licenseApplication.TotalPayment).ToString("0.00") //TXN_AMOUNT
                                                          + "|Payment_Bifurcation=" + payment.ITC
                                                          + "|ReturnUrl=" + Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrl").Value);








                    string checksum = sbiIncriptDecript.GetSHA256(SBIRequestString);
                    SBIRequestString += "|checkSum=" + checksum;
                    string SBIPostRequest = sbiIncriptDecript.EncryptWithKey(SBIRequestString);

                    string SBIURL = Convert.ToString(configuration.GetSection("Path").GetSection("SBIService").Value);

                    #region Insert Payment Request Data
                    payment.UserId = profile.UserId;
                    payment.returnURL = Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrl").Value);
                    payment.S2SReturnURL = Convert.ToString(configuration.GetSection("Path").GetSection("S2SReturnURL").Value);
                    payment.PropertyPath = Convert.ToString(configuration.GetSection("Path").GetSection("SBIPropertyPath").Value);
                    payment.PaymentEncryptedData = SBIPostRequest;
                    payment.Currencycode = "INR";
                    licensePaymentModel.InsertLicensePaymentRequest(payment);
                    #endregion

                    var msgdisp = "<html><form name='s1_2' id='s1_2' action='" + SBIURL + "' method='post'> ";
                    msgdisp += "<input name='encdata' value='" + SBIPostRequest + "' type='hidden'>";
                    msgdisp += "<input name='merchant_code' value='MINERAL_DEPT' type='hidden'>";
                    msgdisp += "<script type='text/javascript' language='javascript' >document.getElementById('s1_2').submit();";
                    msgdisp += "</script>";
                    msgdisp += "<script language='javascript' >";
                    msgdisp += "</ script >";
                    msgdisp += "</form></html> ";
                    return Content(msgdisp, "text/html");
                }
                #endregion

                #region DEMO BANK
                if (licenseApplication.PaymentBank == "DEMOBANK")
                {
                    var DEMOBANKRequestString = string.Empty;


                    objRequestURL.TPSLService = Convert.ToString(configuration.GetSection("Path").GetSection("DemoBankUrl").Value); //Convert.ToString(ConfigurationManager.AppSettings["SBIService"]);
                    objRequestURL.LogFilePath = string.Empty;
                    objRequestURL.ErrorFile = string.Empty;

                    payment.TPSLTXNID = licensePaymentDetail.PaymentRefId;
                    payment.Amount = Convert.ToDecimal(licenseApplication.TotalPayment).ToString("0.00");
                    payment.Shoppingcartdetails = "TEST_" + licenseApplication.TotalPayment + "_0.0";


                    DEMOBANKRequestString = "ApplicantName=" + payment.customerName.ToString() //ApplicantName
                                                      + "|EmailId=" + payment.Email.ToString() //EmailId
                                                      + "|MobileNo=" + payment.mobileNo.ToString() //MobileNo
                                                      + "|CLNT_TXN_NO=" + payment.MerchantTxnRefNumber.ToString() //CLNT_TXN_NO
                                                      + "|Amount=" + Convert.ToDecimal(licenseApplication.TotalPayment).ToString("0.00") //TXN_AMOUNT
                                                      + "|Payment_Bifurcation=" + payment.ITC
                                                      + "|ReturnUrl=" + Convert.ToString(configuration.GetSection("Path").GetSection("DemoBankReturnUrl").Value);

                    string checksum = sbiIncriptDecript.GetSHA256(DEMOBANKRequestString);
                    DEMOBANKRequestString += "|checkSum=" + checksum;
                    string DEMOBANKPostRequest = sbiIncriptDecript.EncryptWithKey(DEMOBANKRequestString);
                    string DEMOBANKURL = Convert.ToString(configuration.GetSection("Path").GetSection("DemoBankUrl").Value);

                    #region Insert Payment Request Data
                    payment.UserId = profile.UserId;
                    payment.returnURL = Convert.ToString(configuration.GetSection("Path").GetSection("DemoBankReturnUrl").Value);
                    payment.S2SReturnURL = Convert.ToString(configuration.GetSection("Path").GetSection("DemoBankReturnUrl").Value);
                    payment.PropertyPath = Convert.ToString(configuration.GetSection("Path").GetSection("SBIPropertyPath").Value);
                    payment.PaymentEncryptedData = DEMOBANKPostRequest;
                    payment.Currencycode = "INR";
                    licensePaymentModel.InsertLicensePaymentRequest(payment);
                    #endregion
                    HttpContext.Session.Set<PaymentModel>("DemoBank", payment);
                    return RedirectToAction("DEMOBANK", "DEMOBANK", new { area = "Payment" });

                }
                #endregion
                return null;
            }
        }
        #endregion

    }
}
