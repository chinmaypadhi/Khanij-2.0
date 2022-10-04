using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using IntegrationApp.ActionFilter;
using IntegrationApp.Areas.Payment.Models.VehiclePaymentDetails;
using IntegrationApp.Helper;
using IntegrationApp.Models.SBIEncryptDecryptKey;
using IntegrationApp.Web;
using IntegrationEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace IntegrationApp.Areas.Payment.Controllers
{
    [Area("Payment")]
    public class VehiclePaymentController : Controller
    {
        private readonly IVehiclePaymentModel vehiclePaymentModel;
        private IConfiguration configuration;
        private readonly IsbiIncriptDecript sbiIncriptDecript;
        private readonly IOptions<KeyList> objKeyList;
        MessageEF messageEF = new MessageEF();
        public VehiclePaymentController(IVehiclePaymentModel vehiclePaymentModel, IConfiguration _configuration,
            IsbiIncriptDecript sbiIncriptDecript, IOptions<KeyList> objKeyList)
        {
            this.vehiclePaymentModel = vehiclePaymentModel;
            this.configuration = _configuration;
            this.sbiIncriptDecript = sbiIncriptDecript;
            this.objKeyList = objKeyList;
        }

        #region Vehicle Payment 
        [SkipImportantTask]
        [HttpGet]
        public IActionResult VehiclePayment(string arr, string total, string tranid)
        {
            ViewBag.TransactionalID = tranid;
            ViewBag.arr = arr;
            ViewBag.total = total;
            return View();
        }
        [HttpPost]
        //ValidateAntiForgeryToken]
        public ActionResult VehiclePayment(string arr, string Fees, string total, string PaymentMode, string PaymentBank,
           string TransactionalID, string ChallanNumber, DateTime? ChallanDate, string Pmode, string NetBanking_mode)
        {
            // arr= Regex.Replace(arr, @"[^0-9a-zA-Z\._]", string.Empty);
            List<int> list = new List<int>();
            int[] val;
            var fileName = "";
            var destinationPath = "";
            var PhysicalPath = "";

            if (PaymentMode == "1")
            {
                #region Online Payment
                string abc = arr.Remove(0, 2);
                string xyz = abc.Remove(abc.Length - 2, 2);
                xyz = Regex.Replace(xyz, @"[^0-9,.]", string.Empty);

                try
                {
                    UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                    VehiclePayment vehiclePayment = new VehiclePayment();
                    vehiclePayment.PaymentVehicleID = xyz;
                    vehiclePayment.UserId = Convert.ToInt32(profile.UserId);//29576;//
                    messageEF = vehiclePaymentModel.GetVehiclePaymentDetails(vehiclePayment);

                    if (messageEF.Satus != null && !string.IsNullOrEmpty(messageEF.Satus))
                    {
                        PaymentModel payment = new PaymentModel();
                        DotNetIntegrationKit.RequestURL objRequestURL = new DotNetIntegrationKit.RequestURL();
                        String response = string.Empty;
                        vehiclePayment.UserName = profile.UserName;//"4270023688"; //
                        vehiclePayment.PaymentBank = (PaymentBank=="DEMOBANK"?"SBI": PaymentBank);
                        vehiclePayment.total = total;
                        vehiclePayment.ReturnID = messageEF.Satus;
                        payment = vehiclePaymentModel.GetVehiclePaymentGateway(vehiclePayment);

                        #region SBI

                        if (PaymentBank == "SBI")
                        {
                            var SBIRequestString = string.Empty;


                            objRequestURL.TPSLService = Convert.ToString(configuration.GetSection("Path").GetSection("SBIService").Value); //Convert.ToString(ConfigurationManager.AppSettings["SBIService"]);
                            objRequestURL.LogFilePath = string.Empty;
                            objRequestURL.ErrorFile = string.Empty;

                            payment.TPSLTXNID = "NA";
                            // payment.ITC = "VehiclePayment" + Convert.ToDecimal(total).ToString("0.00");
                            payment.ITC = "KO30~" + Convert.ToDecimal(total).ToString("0.00");
                            payment.Amount = Convert.ToDecimal(total).ToString("0.00");
                            payment.Shoppingcartdetails = "TEST_" + total + "_0.0";


                            SBIRequestString = "ApplicantName=" + payment.customerName.ToString() //ApplicantName
                                                              + "|EmailId=" + payment.Email.ToString() //EmailId
                                                              + "|MobileNo=" + payment.mobileNo.ToString() //MobileNo
                                                              + "|CLNT_TXN_NO=" + payment.MerchantTxnRefNumber.ToString() //CLNT_TXN_NO
                                                              + "|Amount=" + Convert.ToDecimal(total).ToString("0.00") //TXN_AMOUNT
                                                              + "|Payment_Bifurcation=" + payment.ITC
                                                              + "|ReturnUrl=" + Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrl").Value);

                            string checksum = sbiIncriptDecript.GetSHA256(SBIRequestString);
                            SBIRequestString += "|checkSum=" + checksum;
                            string SBIPostRequest = sbiIncriptDecript.EncryptWithKey(SBIRequestString);
                            string SBIURL = Convert.ToString(configuration.GetSection("Path").GetSection("SBIService").Value);

                            #region Insert Payment Request Data 
                            InsertVehiclePaymentRequest(payment.RequestType, payment.MerchantCode, payment.MerchantTxnRefNumber,
                                        payment.ITC, payment.Amount, "INR", payment.uniqueCustomerID,
                                       Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrl").Value),
                                       Convert.ToString(configuration.GetSection("Path").GetSection("S2SReturnURL").Value),
                                        payment.TPSLTXNID, payment.Shoppingcartdetails, payment.TxnDate,
                                        payment.Email, payment.mobileNo, payment.Bankcode,
                                        payment.customerName, Convert.ToString(configuration.GetSection("Path").GetSection("SBIPropertyPath").Value), SBIPostRequest);

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
                        if (PaymentBank == "DEMOBANK")
                        {
                            var DEMOBANKRequestString = string.Empty;


                            objRequestURL.TPSLService = Convert.ToString(configuration.GetSection("Path").GetSection("DemoBankUrl").Value); //Convert.ToString(ConfigurationManager.AppSettings["SBIService"]);
                            objRequestURL.LogFilePath = string.Empty;
                            objRequestURL.ErrorFile = string.Empty;

                            payment.TPSLTXNID = "NA";
                            // payment.ITC = "VehiclePayment" + Convert.ToDecimal(total).ToString("0.00");
                            payment.ITC = "KO30~" + Convert.ToDecimal(total).ToString("0.00");
                            payment.Amount = Convert.ToDecimal(total).ToString("0.00");
                            payment.Shoppingcartdetails = "TEST_" + total + "_0.0";


                            DEMOBANKRequestString = "ApplicantName=" + payment.customerName.ToString() //ApplicantName
                                                              + "|EmailId=" + payment.Email.ToString() //EmailId
                                                              + "|MobileNo=" + payment.mobileNo.ToString() //MobileNo
                                                              + "|CLNT_TXN_NO=" + payment.MerchantTxnRefNumber.ToString() //CLNT_TXN_NO
                                                              + "|Amount=" + Convert.ToDecimal(total).ToString("0.00") //TXN_AMOUNT
                                                              + "|Payment_Bifurcation=" + payment.ITC
                                                              + "|ReturnUrl=" + Convert.ToString(configuration.GetSection("Path").GetSection("DemoBankReturnUrl").Value);

                            string checksum = sbiIncriptDecript.GetSHA256(DEMOBANKRequestString);
                            DEMOBANKRequestString += "|checkSum=" + checksum;
                            string DEMOBANKPostRequest = sbiIncriptDecript.EncryptWithKey(DEMOBANKRequestString);
                            string DEMOBANKURL = Convert.ToString(configuration.GetSection("Path").GetSection("DemoBankUrl").Value);

                            #region Insert Payment Request Data 
                            InsertVehiclePaymentRequest(payment.RequestType, payment.MerchantCode, payment.MerchantTxnRefNumber,
                                        payment.ITC, payment.Amount, "INR", payment.uniqueCustomerID,
                                       Convert.ToString(configuration.GetSection("Path").GetSection("DemoBankReturnUrl").Value),
                                       Convert.ToString(configuration.GetSection("Path").GetSection("DemoBankReturnUrl").Value),
                                        payment.TPSLTXNID, payment.Shoppingcartdetails, payment.TxnDate,
                                        payment.Email, payment.mobileNo, payment.Bankcode,
                                        payment.customerName, Convert.ToString(configuration.GetSection("Path").GetSection("SBIPropertyPath").Value), DEMOBANKPostRequest);

                            #endregion
                             HttpContext.Session.Set<PaymentModel>("DemoBank",payment);
                            return RedirectToAction("DEMOBANK","DEMOBANK",new {area="Payment"});
                            
                        }
                        #endregion
                        return null;
                    }
                    else
                    {
                        return Redirect(objKeyList.Value.Redirecturl + "VehicleOwner/Vehicle/VehicleDetails");
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }


                #endregion
            }
            else
            {
                return Redirect(objKeyList.Value.Redirecturl + "VehicleOwner/Vehicle/VehicleDetails");
            }


        }

        public MessageEF InsertVehiclePaymentRequest(string RequestType, string MerchantCode, string MerchantTxnRefNumber, string ITC, string Amount, string CurrencyCode,
          string UniqueCustomerId, string ReturnURL, string S2SReturnURL, string TPSLTxnID, string ShoppingCartDetails, string txnDate, string Email,
          string MobileNumber, string BankCode, string CustomerName, string PropertyPath, string PaymentEncryptedData)

        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            PaymentEF model = new PaymentEF();
            model.PAYMENTFOR = 0;
            model.UserId = Convert.ToInt32(profile.UserId);//29576;//
            model.RequestType = RequestType;
            model.MerchantCode = MerchantCode;
            model.MerchantTxnRefNumber = MerchantTxnRefNumber;
            model.ITC = ITC;
            model.AMOUNT = Amount;
            model.Currencycode = CurrencyCode;
            model.UniqueCustomerID = UniqueCustomerId;
            model.returnURL = ReturnURL;
            model.S2SReturnURL = S2SReturnURL;
            model.TPSLTXNID = TPSLTxnID;
            model.Shoppingcartdetails = ShoppingCartDetails;
            model.TxnDate = txnDate;
            model.Email = Email;
            model.MobileNo = MobileNumber;
            model.BankCode = BankCode;
            model.CustomerName = CustomerName;
            model.PropertyPath = PropertyPath;
            model.PaymentEncryptedData = PaymentEncryptedData;
            model.PaymentModeString = "NET-BANKING";
            messageEF = vehiclePaymentModel.InsertVehiclePaymentRequest(model);
            return messageEF;

        }
        #endregion
    }
}
