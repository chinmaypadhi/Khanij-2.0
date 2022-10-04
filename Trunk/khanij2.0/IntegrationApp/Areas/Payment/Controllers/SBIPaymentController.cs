using Microsoft.AspNetCore.Mvc;
using System.Web;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationEF;
using IntegrationApp.Areas.Payment.Models.SBIPayment;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using DotNetIntegrationKit;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Microsoft.AspNetCore.Cors;
using SBICINBPaymentStatus;
using IntegrationApp.Helper;
using IntegrationApp.Web;
using IntegrationApp.Areas.Payment.Models.VehiclePaymentDetails;
using System.Text.RegularExpressions;
using IntegrationApp.ActionFilter;
using System.Data;
//using System.Web.Mvc;

namespace IntegrationApp.Areas.Payment.Controllers
{
    [Area("Payment")]

    public class SBIPaymentController : Controller
    {
        ISBIPaymentModel _objSBIModel;
        const string SessionBank = "_Name";
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IVehiclePaymentModel vehiclePaymentModel;
        private IConfiguration configuration;
        MessageEF messageEF = new MessageEF();
        string SBIENCKeyPath = "";
        string strHEX, strPGActualReponseWithChecksum, strPGActualReponseEncrypted, strPGActualReponseDecrypted, strPGresponseChecksum, strPGTxnStatusCode;
        string PayableRoyalty, TCS, Cess, eCess, DMF, NMET, MonthlyPeriodicAmount, UpforntPayment, PayableRoyalty2, GIB_TXN_NO;
        string[] strPGChecksum, strPGTxnString;
        string[] strSplitDecryptedResponse;
        MessageEF objMSmodel = new MessageEF();
        string OutputResult = "";
        string strPG_TxnStatus = string.Empty, strPG_TxnStatusDesc = string.Empty,
        strPG_ClintTxnRefNo = string.Empty,
                strPG_TPSLTxnBankCode = string.Empty, strPG_Paymode = string.Empty,
                strPG_TPSLTxnID = string.Empty,
                strPG_TxnAmount = string.Empty,
                strPG_TxnDateTime = string.Empty,
                strPG_TxnDate = string.Empty,
                strPG_TxnTime = string.Empty;
        string[] strArrPG_TxnDateTime;
        List<FinalPaymentModel> objList = new List<FinalPaymentModel>();
        string SBI_TXN_ID = string.Empty;
        string _CLNT_TXN_NO = string.Empty;
        string strPG_TRANSACTIONDATE;
        public SBIPaymentController(ISBIPaymentModel objSBIModel, IHostingEnvironment hostingEnvironment,
            IConfiguration _configuration, IVehiclePaymentModel vehiclePaymentModel)
        {
            try
            {
                _objSBIModel = objSBIModel;
                this.hostingEnvironment = hostingEnvironment;
                this.configuration = _configuration;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            this.vehiclePaymentModel = vehiclePaymentModel;
        }
        [HttpGet]
        [SkipImportantTask]
        public IActionResult SBIPayment(string Id, string Prefix, string OrderNo, string PaymentHead,string total)
        {
            PaymentEF model = new PaymentEF();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserId = Convert.ToInt32(profile.UserId);
            // model.UserId = 83;
            model.BulkPermitId = Id.ToString();
            model.Prefix = Prefix;
            model.OrderNo = OrderNo;
            model.TotalPayableAmount = Convert.ToDecimal(total);
            if (PaymentHead == null || PaymentHead =="")
            {
                model.PayDeptId = 0;
            }
            else
            {
                model.PayDeptId = Convert.ToInt32(PaymentHead);
            }
            return View(model);
        }
        #region Vehicle Payment
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
                        vehiclePayment.PaymentBank = PaymentBank;
                        vehiclePayment.total = total;
                        vehiclePayment.ReturnID = messageEF.Satus;
                        payment = vehiclePaymentModel.GetVehiclePaymentGateway(vehiclePayment);

                        #region SBI

                        HttpContext.Session.SetString(SessionBank, "SBI");
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

                        string checksum = GetSHA256(SBIRequestString);
                        SBIRequestString += "|checkSum=" + checksum;
                        string SBIPostRequest = EncryptWithKey(SBIRequestString);
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



                        #endregion


                        return null;
                    }
                    else
                    {
                        TempData["AckMessage"] = "Payment cannot done.Please try again!";
                        return RedirectToAction("vehicle", "Transporter", new { Area = "Transporters" });
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
                TempData["AckMessage"] = "Payment cannot done.Please try again!";
                return RedirectToAction("vehicle", "Transporter", new { Area = "Transporters" });
            }


        }
        #endregion

        [HttpPost]
        public IActionResult SBIPaymentNew(PaymentEF modelEF)
        {

            SBIENCKeyPath = configuration.GetSection("Path").GetSection("SBIENCKey").Value;
            string strAlert = string.Empty;
            PaymentResult objTotalAppl = new PaymentResult();
            PaymentEF model = new PaymentEF();
            model.BulkPermitId = modelEF.BulkPermitId;
            model.PaymentBank = modelEF.PaymentBank;
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            model.UserId = Convert.ToInt32(profile.UserId);

            PaymentResult objcheck = new PaymentResult();
            PaymentEF checkmodel = new PaymentEF();
            checkmodel.UserId = Convert.ToInt32(profile.UserId);
            // model.UserId = 83;
            if (Convert.ToInt32(model.BulkPermitId) > 0)
            {

                #region Online Payment
                string propertyPath = configuration.GetSection("Path").GetSection("PropertyPath").Value;
                //string propertyPath = ConfigurationManager.AppSettings["PropertyPath"].ToString();

                PaymentEF payment = new PaymentEF();
                RequestURL objRequestURL = new RequestURL();
                String response = string.Empty;
                objTotalAppl = _objSBIModel.GetPaymentGateway(model);
                if (objTotalAppl != null && objTotalAppl.TransLst.Count > 0)
                {

                    foreach (var app in objTotalAppl.TransLst)
                    {
                        payment.RequestType = app.RequestType;
                        payment.MerchantCode = app.MerchantCode;
                        payment.ErrorFile = app.ErrorFile;
                        payment.PropertyPath = app.PropertyPath;
                        payment.LogFilePath = app.LogFilePath;
                        payment.BankCode = app.BankCode;

                        payment.UniqueCustomerID = app.UniqueCustomerID;
                        payment.CustomerName = app.CustomerName;
                        payment.MobileNo = app.UserMobileNumber;
                        payment.Email = app.UserEmail;
                        payment.TxnDate = app.TxnDate;

                        ////BULK PERMIT ID
                       
                        payment.MerchantTxnRefNumber = modelEF.OrderNo;
                        #region SBI

                        if (model.PaymentBank.ToUpper() == "SBI")
                        {
                            HttpContext.Session.SetString(SessionBank, "SBI");
                            var SBIRequestString = string.Empty;
                            decimal DMF = 0;
                            decimal NMET = 0;
                            decimal Royalty = 0;
                            decimal MonthlyPeriodicAmount = 0;
                            decimal total = 0;

                            //objRequestURL.TPSLService = Convert.ToString(ConfigurationManager.AppSettings["SBIService"]);
                            objRequestURL.TPSLService = Convert.ToString(configuration.GetSection("Path").GetSection("SBIService").Value);
                            objRequestURL.LogFilePath = string.Empty;
                            objRequestURL.ErrorFile = string.Empty;

                            payment.TPSLTXNID = model.BulkPermitId.ToString();
                            foreach (var app1 in objTotalAppl.PaymentLst)
                            {
                                if (objTotalAppl.PaymentLst.Count > 0)
                                {
                                    //DataTable dtPayment = ds.Tables[1];

                                    payment.AMOUNT = Convert.ToDecimal(modelEF.TotalPayableAmount).ToString("0.00");

                                    payment.Shoppingcartdetails = ("test_" + Convert.ToDecimal(modelEF.TotalPayableAmount).ToString("0.00") + "_0.0").ToUpper();

                                    string strITC = string.Empty;
                                    //decimal total = 0;
                                    int count = 0;
                                    int i = 0;
                                    if (modelEF.OrderNo != null || modelEF.OrderNo != "")
                                    {
                                        foreach (var app2 in objTotalAppl.PaymentLst)
                                        {
                                            if (app2.PayDeptId == Convert.ToInt32(modelEF.PayDeptId))
                                            {
                                                if (app2.MappingValue != 0)
                                                {
                                                    count += 1;
                                                }
                                            }
                                        }
                                    }
                                    
                                    if (modelEF.OrderNo.StartsWith("ORDMIN"))
                                    {
                                        foreach (var app2 in objTotalAppl.PaymentLst)
                                        {
                                            if (app2.PayDeptId == Convert.ToInt32(modelEF.PayDeptId))
                                            {
                                                if (app2.MappingValue != 0)
                                                {
                                                    if (i == (count - 1))
                                                    {
                                                        //strITC += "" + Convert.ToString(ds.Tables[1].Rows[i]["SBI"]) + "~" + Convert.ToDecimal(ds.Tables[1].Rows[i]["MappingValue"]).ToString("0.00");
                                                        strITC += "" + Convert.ToString(app2.SBI) + "~" + Convert.ToDecimal(app2.MappingValue).ToString("0.00");
                                                    }
                                                    else
                                                    {
                                                        //strITC += "" + Convert.ToString(ds.Tables[1].Rows[i]["SBI"]) + "~" + Convert.ToDecimal(ds.Tables[1].Rows[i]["MappingValue"]).ToString("0.00") + ":";
                                                        strITC += "" + Convert.ToString(app2.SBI) + "~" + Convert.ToDecimal(app2.MappingValue).ToString("0.00") + ":";
                                                    }
                                                    total += Convert.ToDecimal(app2.MappingValue);
                                                    i++;
                                                }
                                            }
                                        }
                                    }
                                    if (modelEF.OrderNo.StartsWith("ORDINC"))
                                    {
                                        foreach (var app2 in objTotalAppl.PaymentLst)
                                        {
                                            if (app2.PayDeptId == Convert.ToInt32(modelEF.PayDeptId))
                                            {
                                                if (app2.MappingValue != 0)
                                                {
                                                    if (i == (count - 1))
                                                    {
                                                        //strITC += "" + Convert.ToString(ds.Tables[1].Rows[i]["SBI"]) + "~" + Convert.ToDecimal(ds.Tables[1].Rows[i]["MappingValue"]).ToString("0.00");
                                                        strITC += "" + Convert.ToString(app2.SBI) + "~" + Convert.ToDecimal(app2.MappingValue).ToString("0.00");
                                                    }
                                                    else
                                                    {
                                                        //strITC += "" + Convert.ToString(ds.Tables[1].Rows[i]["SBI"]) + "~" + Convert.ToDecimal(ds.Tables[1].Rows[i]["MappingValue"]).ToString("0.00") + ":";
                                                        strITC += "" + Convert.ToString(app2.SBI) + "~" + Convert.ToDecimal(app2.MappingValue).ToString("0.00") + ":";
                                                    }
                                                    total += Convert.ToDecimal(app2.MappingValue);
                                                    i++;
                                                }
                                            }
                                        }

                                    }
                                    if (modelEF.OrderNo.StartsWith("ORDEVS"))
                                    {
                                        foreach (var app2 in objTotalAppl.PaymentLst)
                                        {
                                            if (app2.PayDeptId == Convert.ToInt32(modelEF.PayDeptId))
                                            {
                                                if (app2.MappingValue != 0)
                                                {
                                                    if (i == (count - 1))
                                                    {
                                                        //strITC += "" + Convert.ToString(ds.Tables[1].Rows[i]["SBI"]) + "~" + Convert.ToDecimal(ds.Tables[1].Rows[i]["MappingValue"]).ToString("0.00");
                                                        strITC += "" + Convert.ToString(app2.SBI) + "~" + Convert.ToDecimal(app2.MappingValue).ToString("0.00");
                                                    }
                                                    else
                                                    {
                                                        //strITC += "" + Convert.ToString(ds.Tables[1].Rows[i]["SBI"]) + "~" + Convert.ToDecimal(ds.Tables[1].Rows[i]["MappingValue"]).ToString("0.00") + ":";
                                                        strITC += "" + Convert.ToString(app2.SBI) + "~" + Convert.ToDecimal(app2.MappingValue).ToString("0.00") + ":";
                                                    }
                                                    total += Convert.ToDecimal(app2.MappingValue);
                                                    i++;
                                                }
                                            }
                                        }
                                    }
                                    if (modelEF.OrderNo == null || modelEF.OrderNo == "")
                                    {
                                        foreach (var app2 in objTotalAppl.PaymentLst)
                                        {
                                            if (i == (objTotalAppl.PaymentLst.Count - 1))
                                            {
                                                //strITC += "" + Convert.ToString(ds.Tables[1].Rows[i]["SBI"]) + "~" + Convert.ToDecimal(ds.Tables[1].Rows[i]["MappingValue"]).ToString("0.00");
                                                strITC += "" + Convert.ToString(app2.SBI) + "~" + Convert.ToDecimal(app2.MappingValue).ToString("0.00");
                                            }
                                            else
                                            {
                                                //strITC += "" + Convert.ToString(ds.Tables[1].Rows[i]["SBI"]) + "~" + Convert.ToDecimal(ds.Tables[1].Rows[i]["MappingValue"]).ToString("0.00") + ":";
                                                strITC += "" + Convert.ToString(app2.SBI) + "~" + Convert.ToDecimal(app2.MappingValue).ToString("0.00") + ":";
                                            }

                                            total += Convert.ToDecimal(app2.MappingValue);
                                            i++;
                                        }
                                    }


                                    payment.ITC = strITC;
                                    payment.AMOUNT = total.ToString("0.00");
                                    payment.Shoppingcartdetails = ("test_" + Convert.ToDecimal(total).ToString("0.00") + "_0.0").ToUpper();

                                    SBIRequestString = "ApplicantName=" + payment.CustomerName.ToString() //ApplicantName
                                                       + "|EmailId=" + payment.Email.ToString() //EmailId
                                                       + "|MobileNo=" + payment.MobileNo.ToString() //MobileNo
                                                       + "|CLNT_TXN_NO=" + payment.MerchantTxnRefNumber.ToString() //CLNT_TXN_NO
                                                       + "|Amount=" + Convert.ToDecimal(total).ToString("0.00") //TXN_AMOUNT
                                                       + "|Payment_Bifurcation=" + payment.ITC
                                                       + "|ReturnUrl=" + Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrl").Value);


                                }
                                #region Old Code
                                else
                                {

                                    // DataTable dtPayment = ds.Tables[1];
                                    string strITC = string.Empty;
                                    int i = 0;

                                    foreach (var app2 in objTotalAppl.PaymentLst)
                                    {
                                        if (i == (objTotalAppl.PaymentLst.Count - 1))
                                        {
                                            strITC += "" + Convert.ToString(app2.SBI) + "~" + Convert.ToDecimal(app2.MappingValue).ToString("0.00");
                                        }
                                        else
                                        {
                                            strITC += "" + Convert.ToString(app2.SBI) + "~" + Convert.ToDecimal(app2.MappingValue).ToString("0.00") + ":";
                                        }
                                        total += Convert.ToDecimal(app2.MappingValue);
                                        i++;
                                    }

                                    payment.ITC = strITC;
                                    payment.AMOUNT = total.ToString("0.00");
                                    payment.Shoppingcartdetails = ("test_" + Convert.ToDecimal(total).ToString("0.00") + "_0.0").ToUpper();


                                    // payment.ITC = "PayableRoyalty:" + Convert.ToDecimal(model.PayableRoyalty).ToString("0.00") + "~TCS:" + Convert.ToDecimal(model.TCS).ToString("0.00") + "~Cess:" + Convert.ToDecimal(model.Cess).ToString("0.00") + "~eCess:" + Convert.ToDecimal(model.eCess).ToString("0.00") + "~DMF:" + Convert.ToDecimal(model.DMF).ToString("0.00") + "~NMET:" + Convert.ToDecimal(model.NMET).ToString("0.00") + "";
                                    // SBIRequestString = "CLNT_TXN_NO=" + model.BulkPermitId.ToString() + "|TXN_AMOUNT=" + Convert.ToDecimal(model.TotalPayableAmount).ToString("0.00") + "|DMF=" + Convert.ToDecimal(model.DMF).ToString("0.00") + "|NMET=" + Convert.ToDecimal(model.NMET).ToString("0.00") + "|CESS=" + Convert.ToDecimal(model.Cess).ToString("0.00") + "|eCESS=" + Convert.ToDecimal(model.eCess).ToString("0.00") + "|TCS=" + Convert.ToDecimal(model.TCS).ToString("0.00") + "|RoyaltiPaid=" + Convert.ToDecimal(model.RoyaltyRate).ToString("0.00") + "";


                                    SBIRequestString = "ApplicantName=" + payment.CustomerName.ToString() //ApplicantName
                                                      + "|EmailId=" + payment.Email.ToString() //EmailId
                                                      + "|MobileNo=" + payment.MobileNo.ToString() //MobileNo
                                                      + "|CLNT_TXN_NO=" + payment.MerchantTxnRefNumber.ToString() //CLNT_TXN_NO
                                                      + "|Amount=" + Convert.ToDecimal(total).ToString("0.00") //TXN_AMOUNT
                                                      + "|Payment_Bifurcation=" + payment.ITC
                                                      + "|ReturnUrl=" + Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrl").Value);


                                }
                                #endregion
                                String checksum = GetSHA256(SBIRequestString);
                                SBIRequestString += "|checkSum=" + checksum;
                                string SBIPostRequest = EncryptWithKey(SBIRequestString);
                                string SBIURL = Convert.ToString(configuration.GetSection("Path").GetSection("SBIService").Value);

                                #region Insert Payment Request Data
                                InsertPaymentRequest(payment.RequestType, payment.MerchantCode, payment.MerchantTxnRefNumber,
                                    payment.ITC, payment.AMOUNT, "INR", payment.UniqueCustomerID,
                                   Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrl").Value),
                                   Convert.ToString(configuration.GetSection("Path").GetSection("S2SReturnURL").Value),
                                    payment.TPSLTXNID, payment.Shoppingcartdetails, payment.TxnDate,
                                    payment.Email, payment.MobileNo, payment.BankCode,
                                    payment.CustomerName, Convert.ToString(configuration.GetSection("Path").GetSection("ICICIPropertyPath").Value), SBIPostRequest);
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
                        }
                        #endregion
                        #region ICICI
                        else if (model.PaymentBank.ToUpper() == "ICICI")
                        {
                            decimal sum = 0;
                            bool check = true;
                            HttpContext.Session.SetString(SessionBank, "ICICI");

                            if (modelEF.P_Mode.ToUpper() == "NEFT")
                            {
                                check = true;
                            }
                            else
                            {
                                check = false;
                            }

                            //Session["isNEFT"] = isNEFT;
                            HttpContext.Session.SetString("isNEFT", check.ToString());
                            objRequestURL.TPSLService = Convert.ToString(configuration.GetSection("Path").GetSection("ICICITPSLService").Value);
                            objRequestURL.LogFilePath = Convert.ToString(configuration.GetSection("Path").GetSection("ICICILogFilePath").Value);
                            objRequestURL.ErrorFile = Convert.ToString(configuration.GetSection("Path").GetSection("ICICIErrorFile").Value);

                            payment.TPSLTXNID = model.BulkPermitId.ToString();
                            int i = 0;
                            string strITC = string.Empty;
                            int count = 0;
                            if (modelEF.OrderNo != null || modelEF.OrderNo != "")
                            {
                                foreach (var app2 in objTotalAppl.PaymentLst)
                                {
                                    if (app2.PayDeptId == Convert.ToInt32(modelEF.PayDeptId))
                                    {
                                        if (app2.MappingValue != 0)
                                        {
                                            count += 1;
                                        }
                                    }
                                }
                            }
                            if (modelEF.OrderNo.StartsWith("ORDMIN"))
                            {
                                foreach (var app2 in objTotalAppl.PaymentLst)
                                {
                                    if (app2.PayDeptId == Convert.ToInt32(modelEF.PayDeptId))
                                    {
                                        if (app2.MappingValue != 0)
                                        {
                                            if (i == (count - 1))
                                            {
                                                //strITC += "" + Convert.ToString(ds.Tables[1].Rows[i]["SBI"]) + "~" + Convert.ToDecimal(ds.Tables[1].Rows[i]["MappingValue"]).ToString("0.00");
                                                strITC += "" + Convert.ToString(app2.ICICI).Trim() + ":" + Convert.ToDecimal(app2.MappingValue).ToString("0.00");
                                            }
                                            else
                                            {
                                                //strITC += "" + Convert.ToString(ds.Tables[1].Rows[i]["SBI"]) + "~" + Convert.ToDecimal(ds.Tables[1].Rows[i]["MappingValue"]).ToString("0.00") + ":";
                                                strITC += "" + Convert.ToString(app2.ICICI).Trim() + ":" + Convert.ToDecimal(app2.MappingValue).ToString("0.00") + ",";
                                            }
                                            sum += Convert.ToDecimal(app2.MappingValue);
                                            i++;
                                        }
                                    }
                                }
                            }
                            if (modelEF.OrderNo.StartsWith("ORDINC"))
                            {
                                foreach (var app2 in objTotalAppl.PaymentLst)
                                {
                                    if (app2.PayDeptId == Convert.ToInt32(modelEF.PayDeptId))
                                    {
                                        if (app2.MappingValue != 0)
                                        {
                                            if (i == (count - 1))
                                            {
                                                //strITC += "" + Convert.ToString(ds.Tables[1].Rows[i]["SBI"]) + "~" + Convert.ToDecimal(ds.Tables[1].Rows[i]["MappingValue"]).ToString("0.00");
                                                strITC += "" + Convert.ToString(app2.ICICI).Trim() + ":" + Convert.ToDecimal(app2.MappingValue).ToString("0.00");
                                            }
                                            else
                                            {
                                                //strITC += "" + Convert.ToString(ds.Tables[1].Rows[i]["SBI"]) + "~" + Convert.ToDecimal(ds.Tables[1].Rows[i]["MappingValue"]).ToString("0.00") + ":";
                                                strITC += "" + Convert.ToString(app2.ICICI).Trim() + ":" + Convert.ToDecimal(app2.MappingValue).ToString("0.00") + ",";
                                            }
                                            sum += Convert.ToDecimal(app2.MappingValue);
                                            i++;
                                        }
                                    }
                                }
                            }
                            if (modelEF.OrderNo.StartsWith("ORDEVS"))
                            {
                                foreach (var app2 in objTotalAppl.PaymentLst)
                                {
                                    if (app2.PayDeptId == Convert.ToInt32(modelEF.PayDeptId))
                                    {
                                        if (app2.MappingValue != 0)
                                        {
                                            if (i == (count - 1))
                                            {
                                                //strITC += "" + Convert.ToString(ds.Tables[1].Rows[i]["SBI"]) + "~" + Convert.ToDecimal(ds.Tables[1].Rows[i]["MappingValue"]).ToString("0.00");
                                                strITC += "" + Convert.ToString(app2.ICICI).Trim() + ":" + Convert.ToDecimal(app2.MappingValue).ToString("0.00");
                                            }
                                            else
                                            {
                                                //strITC += "" + Convert.ToString(ds.Tables[1].Rows[i]["SBI"]) + "~" + Convert.ToDecimal(ds.Tables[1].Rows[i]["MappingValue"]).ToString("0.00") + ":";
                                                strITC += "" + Convert.ToString(app2.ICICI).Trim() + ":" + Convert.ToDecimal(app2.MappingValue).ToString("0.00") + ",";
                                            }
                                            sum += Convert.ToDecimal(app2.MappingValue);
                                            i++;
                                        }
                                    }
                                }
                            }
                            if (modelEF.OrderNo == null || modelEF.OrderNo == "")
                            {
                                foreach (var app2 in objTotalAppl.PaymentLst)
                                {
                                    if (objTotalAppl.PaymentLst.Count > 0)
                                    {
                                        if (i == (objTotalAppl.PaymentLst.Count - 1))
                                        {
                                            strITC += "" + Convert.ToString(app2.ICICI).Trim() + ":" + Convert.ToDecimal(app2.MappingValue).ToString("0.00");
                                        }
                                        else
                                        {
                                            strITC += "" + Convert.ToString(app2.ICICI).Trim() + ":" + Convert.ToDecimal(app2.MappingValue).ToString("0.00") + ",";
                                        }
                                        sum += Convert.ToDecimal(app2.MappingValue);

                                        i++;
                                    }
                                    #region Old Code
                                    //else
                                    //{
                                    //    //payment.Amount = model.TotalPayableAmount.ToString("0.00");
                                    //    //payment.Shoppingcartdetails = ("test_" + Convert.ToDecimal(model.TotalPayableAmount).ToString("0.00") + "_0.0").ToUpper();
                                    //    ////payment.ITC = "PayableRoyalty:" + Convert.ToDecimal(model.PayableRoyalty).ToString("0.00") + "~TCS:" + Convert.ToDecimal(model.TCS).ToString("0.00") + "~Cess:" + Convert.ToDecimal(model.Cess).ToString("0.00") + "~eCess:" + Convert.ToDecimal(model.eCess).ToString("0.00") + "~DMF:" + Convert.ToDecimal(model.DMF).ToString("0.00") + "~NMET:" + Convert.ToDecimal(model.NMET).ToString("0.00") + "";
                                    //    //if (!isNEFT)
                                    //    //{
                                    //    //    payment.ITC = "PayableRoyalty:" + Convert.ToDecimal(model.PayableRoyalty).ToString("0.00") + ",TCS:" + Convert.ToDecimal(model.TCS).ToString("0.00") + ",Cess:" + Convert.ToDecimal(model.Cess).ToString("0.00") + ",eCess:" + Convert.ToDecimal(model.eCess).ToString("0.00") + ",DMF:" + Convert.ToDecimal(model.DMF).ToString("0.00") + ",NMET:" + Convert.ToDecimal(model.NMET).ToString("0.00") + "";
                                    //    //}
                                    //    //else
                                    //    //{
                                    //    //    payment.ITC = "PayableRoyalty~" + Convert.ToDecimal(model.PayableRoyalty).ToString("0.00") + ",TCS~" + Convert.ToDecimal(model.TCS).ToString("0.00") + ",Cess~" + Convert.ToDecimal(model.Cess).ToString("0.00") + ",eCess~" + Convert.ToDecimal(model.eCess).ToString("0.00") + ",DMF~" + Convert.ToDecimal(model.DMF).ToString("0.00") + ",NMET~" + Convert.ToDecimal(model.NMET).ToString("0.00") + "";
                                    //    //}
                                    //}
                                    #endregion
                                }
                            }
                            payment.ITC = strITC;
                            payment.AMOUNT = sum.ToString("0.00");
                            payment.Shoppingcartdetails = ("test_" + sum.ToString("0.00") + "_0.0").ToUpper();

                            #region NEFT / RTGS
                            if (Convert.ToBoolean(check))
                            {
                                //// Follwoing Code for NEFT/RTGS

                                var ICICIURL = Convert.ToString(configuration.GetSection("Path").GetSection("ICICINEFTService").Value);
                                var dat = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
                                var dat1 = dat.Replace("-", "/");

                                #region Old ICICI bank code

                                #endregion

                                #region New ICICI Bank Code

                                //string GIB_URL = "https://gibtaxadm.icicibankltd.com/corp/AuthenticationController?FORMSGROUP_ID__=AuthenticationFG&__START_TRAN_FLAG__=Y&FG_BUTTONS__=LOAD&ACTION.LOAD=Y&AuthenticationFG.LOGIN_FLAG=1&BANK_ID=ICI&JS_ENABLED_FLAG=Y&ITC=00000015&CRN=INR&IS_GIB_SESSION=Y&MD=P&AppType=corporate&URLencoding=Y&CG=Y&STATFLG=H&IsCORDYS=Y&PID=220";
                                //string GIB_URL = "https://gibtax.icicibank.com/corp/AuthenticationController?FORMSGROUP_ID__=AuthenticationFG&__START_TRAN_FLAG__=Y&FG_BUTTONS__=LOAD&ACTION.LOAD=Y&AuthenticationFG.LOGIN_FLAG=1&BANK_ID=ICI&JS_ENABLED_FLAG=Y&ITC=00000015&CRN=INR&IS_GIB_SESSION=Y&MD=P&AppType=corporate&URLencoding=Y&CG=Y&STATFLG=H&IsCORDYS=Y&PID=220";

                                //updated on 18/02/2021
                                string GIB_URL = "https://gibtaxcug.icicibank.com/corp/AuthenticationController?FORMSGROUP_ID__=AuthenticationFG&__START_TRAN_FLAG__=Y&FG_BUTTONS__=LOAD&ACTION.LOAD=Y&AuthenticationFG.LOGIN_FLAG=1&BANK_ID=ICI&JS_ENABLED_FLAG=Y&ITC=00000015&CRN=INR&IS_GIB_SESSION=Y&MD=P&AppType=corporate&URLencoding=Y&CG=Y&STATFLG=H&CYBERR=Y&CATEGORY_ID=264&PID=220";

                                //Updated By Avneesh for ICICI Net Banking
                                string GIB_Parm = "Paymode=NEFT&DEP_CODE=MDGC&REF_NO=" + payment.MerchantTxnRefNumber + "&AMT=" + payment.AMOUNT + "&RU=" + Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrlICICI").Value) + "&SRC_ITC=" + payment.ITC + ",ApplicantName:" + payment.CustomerName.Trim();
                                //string GIB_Parm = "Paymode=NEFT&DEP_CODE=MDGC&REF_NO=" + payment.MerchantTxnRefNumber + "&AMT=" + payment.Amount + "&RU=" + ConfigurationManager.AppSettings["ReturnUrl"].ToString() + "&SRC_ITC=" + payment.ITC + ",ApplicantName:" + payment.customerName.Trim();
                                string test = GIB_URL + GIB_Parm;
                                string GIB_encrpt = EncryptAES(GIB_Parm);
                                string finalSent = GIB_URL + "&encdata=" + GIB_encrpt;
                                #endregion
                                #region Insert Payment Request Data
                                InsertPaymentRequest(payment.RequestType, payment.MerchantCode, payment.MerchantTxnRefNumber,
                                    payment.ITC, payment.AMOUNT, "INR", payment.UniqueCustomerID,
                                   Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrlICICI").Value),
                                   Convert.ToString(configuration.GetSection("Path").GetSection("S2SReturnURLICICI").Value),
                                    payment.TPSLTXNID, payment.Shoppingcartdetails, payment.TxnDate,
                                    payment.Email, payment.MobileNo, payment.BankCode,
                                    payment.CustomerName, Convert.ToString(configuration.GetSection("Path").GetSection("ICICIPropertyPath").Value), finalSent, "NEFT/RTGS");
                                #endregion


                                var msgdisp = "<html><form name='s1_2' id='s1_2' action='" + finalSent + "' method='post'> ";
                                msgdisp += "<script type='text/javascript' language='javascript' >document.getElementById('s1_2').submit();";
                                msgdisp += "</script>";
                                msgdisp += "<script language='javascript' >";
                                msgdisp += "</ script >";
                                msgdisp += "</form></html> ";
                                return Content(msgdisp, "text/html");
                            }
                            #endregion

                            #region NetBanking
                            else
                            {

                                var PID = Convert.ToString(configuration.GetSection("Path").GetSection("ICICIPID").Value);
                                #region New ICICI Bank Code -- Live Code
                                //UAT URL
                                //string GIB_URL = "https://gibtaxcug.icicibank.com/corp/AuthenticationController?FORMSGROUP_ID__=AuthenticationFG&__START_TRAN_FLAG__=Y&FG_BUTTONS__=LOAD&ACTION.LOAD=Y&AuthenticationFG.LOGIN_FLAG=1&BANK_ID=ICI&JS_ENABLED_FLAG=Y&ITC=00000015&PRN=11&CRN=INR&MD=P&PID=220&IS_GIB_SESSION=Y&CATEGORY_ID=264&AppType=corporate&URLencoding=Y&CG=Y&CYBERR=Y";

                                // LIVE URL 

                                //string GIB_URL = "https://gibtax.icicibank.com/corp/AuthenticationController?FORMSGROUP_ID__=AuthenticationFG&__START_TRAN_FLAG__=Y&FG_BUTTONS__=LOAD&ACTION.LOAD=Y&AuthenticationFG.LOGIN_FLAG=1&BANK_ID=ICI&JS_ENABLED_FLAG=Y&ITC=00000015&PRN=11&CRN=INR&MD=P&PID=220&IS_GIB_SESSION=Y&CATEGORY_ID=264&AppType=corporate&URLencoding=Y&CG=Y&CYBERR=Y";

                                // Updated on 06-03-2021
                                //string GIB_URL = https://gibtaxcug.icicibank.com/corp/AuthenticationController?FORMSGROUP_ID__=AuthenticationFG&__START_TRAN_FLAG__=Y&FG_BUTTONS__=LOAD&ACTION.LOAD=Y&AuthenticationFG.LOGIN_FLAG=1&BANK_ID=ICI&JS_ENABLED_FLAG=Y&ITC=00000015&CRN=INR&IS_GIB_SESSION=Y&MD=P&AppType=corporate&URLencoding=Y&CG=Y&STATFLG=H&CYBERR=Y&CATEGORY_ID=264&PID=220
                                var ICICIreqString = "FORMSGROUP_ID__=AuthenticationFG&__START_TRAN_FLAG__=Y&FG_BUTTONS__=LOAD&ACTION.LOAD=Y&AuthenticationFG.LOGIN_FLAG=1&BANK_ID=ICI&JS_ENABLED_FLAG=Y&ITC=00000015&PRN=11&CRN=INR&MD=P&PID=220&IS_GIB_SESSION=Y&CATEGORY_ID=264&AppType=corporate&URLencoding=Y&CG=Y&CYBERR=Y";

                                var ICICINETBankingURL = Convert.ToString(configuration.GetSection("Path").GetSection("ICICITPSLService").Value) + ICICIreqString;

                                string GIB_URL = ICICINETBankingURL;

                                //updated by Avneesh for ICICI net banking

                                string GIB_Parm = "PRN=" + payment.ITC + ",REF_NO:" + payment.MerchantTxnRefNumber + ",ApplicantName:" + payment.CustomerName.Trim() + "&AMT=" + payment.AMOUNT + "&RU=" + Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrlICICI").Value);


                                //string GIB_Parm = "PRN=" + payment.ITC + ",REF_NO:" + payment.MerchantTxnRefNumber + ",ApplicantName:" + payment.customerName.Trim() + "&AMT=" + payment.Amount + "&RU=" + ConfigurationManager.AppSettings["ReturnUrl"].ToString();


                                string test = GIB_URL + GIB_Parm;
                                string GIB_encrpt = EncryptAES(GIB_Parm);
                                ICICINETBankingURL = GIB_URL + "&encdata=" + GIB_encrpt;
                                #endregion
                                #region Insert Payment Request Data
                                InsertPaymentRequest(payment.RequestType, payment.MerchantCode, payment.MerchantTxnRefNumber,
                                    payment.ITC, payment.AMOUNT, "INR", payment.UniqueCustomerID,
                                   Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrlICICI").Value),
                                   Convert.ToString(configuration.GetSection("Path").GetSection("S2SReturnURLICICI").Value),
                                    payment.TPSLTXNID, payment.Shoppingcartdetails, payment.TxnDate,
                                    payment.Email, payment.MobileNo, payment.BankCode,
                                    payment.CustomerName, Convert.ToString(configuration.GetSection("Path").GetSection("ICICIPropertyPath").Value), ICICINETBankingURL);
                                #endregion
                                var msgdisp = "<html><form name='s1_2' id='s1_2' action='" + ICICINETBankingURL + "' method='post'> ";
                                msgdisp += "<script type='text/javascript' language='javascript' >document.getElementById('s1_2').submit();";
                                msgdisp += "</script>";
                                msgdisp += "<script language='javascript' >";
                                msgdisp += "</ script >";
                                msgdisp += "</form></html> ";
                                return Content(msgdisp, "text/html");
                            }
                            #endregion
                        }
                        #endregion

                    }



                    return null;

                }
                else
                {
                    return RedirectToAction("ePermitList", "BulkPermit");
                }

                #endregion
            }
            return View();
        }

        public static string GetSHA256(string name)
        {

            SHA256 SHA256 = new SHA256CryptoServiceProvider();
            byte[] ba = SHA256.ComputeHash(System.Text.Encoding.Default.GetBytes(name));
            System.Text.StringBuilder hex = new System.Text.StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public string EncryptAES(string cipherString, string PrivateKey = "i&4d$v3@ibank15s")
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(cipherString);
            string key = PrivateKey;
            keyArray = UTF8Encoding.UTF8.GetBytes(key);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.KeySize = 128;
            aes.Key = keyArray;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.ECB;
            ICryptoTransform cTransform = aes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            aes.Clear();
            return Convert.ToBase64String(resultArray);
        }


        public string DecryptAES(string cipherString, string PrivateKey = "i&4d$v3@ibank15s")
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(replaceSpecialChars(cipherString));
            string key = PrivateKey;
            keyArray = UTF8Encoding.UTF8.GetBytes(key);
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.KeySize = 128;
            aes.Key = keyArray;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.ECB;
            ICryptoTransform cTransform = aes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            aes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        private static String replaceSpecialChars(string str)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in str)
            {
                if (c == ' ')
                    sb.Append('+');
                else
                    sb.Append(c);

            }

            return sb.ToString();
        }

        string Encrypt(string textToEncrypt)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Mode = CipherMode.CBC;
            rijndaelCipher.Padding = PaddingMode.PKCS7;
            rijndaelCipher.KeySize = 0x80;
            rijndaelCipher.BlockSize = 0x80;
            byte[] pwdBytes = GetFileBytes(SBIENCKeyPath);
            byte[] keyBytes = new byte[0x10];
            int len = pwdBytes.Length;
            if (len > keyBytes.Length)
            {
                len = keyBytes.Length;
            }
            Array.Copy(pwdBytes, keyBytes, len);
            rijndaelCipher.Key = keyBytes;
            rijndaelCipher.IV = keyBytes;
            ICryptoTransform transform = rijndaelCipher.CreateEncryptor();
            byte[] plainText = Encoding.UTF8.GetBytes(textToEncrypt);
            return Convert.ToBase64String(transform.TransformFinalBlock(plainText, 0, plainText.Length));
        }

        public string EncryptWithKey(String messageToEncrypt, byte[] nonSecretPayload = null)
        {
            string SBIENCKeyPath = Convert.ToString(configuration.GetSection("Path").GetSection("SBIENCKey").Value);
            byte[] key = System.IO.File.ReadAllBytes(SBIENCKeyPath);//File.ReadAllBytes(@"D:/MINERAL_DEPT.key");
            if (string.IsNullOrEmpty(messageToEncrypt))
            {
                throw new ArgumentException("Secret Message Required!", "messageToEncrypt");
            }
            byte[] msgToEncryptByte = System.Text.Encoding.UTF8.GetBytes(messageToEncrypt);

            //Non-secret Payload Optional
            nonSecretPayload = nonSecretPayload ?? new byte[] { };

            //Using random nonce large enough not to repeat
            byte[] cipherText = null;
            byte[] nonce = null;
            var cipher = new GcmBlockCipher(new AesEngine());
            try
            {
                Random rnd = new Random();
                nonce = new byte[16];
                rnd.NextBytes(nonce);
                var parameters = new AeadParameters(new KeyParameter(key), 128, nonce, nonSecretPayload);
                cipher.Init(true, parameters);
                cipherText = new byte[cipher.GetOutputSize(msgToEncryptByte.Length)];
                var len = cipher.ProcessBytes(msgToEncryptByte, 0, msgToEncryptByte.Length, cipherText, 0);
                cipher.DoFinal(cipherText, len);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error {0}", ex.Message);
                Console.ReadKey();
            }

            //Assemble Message
            using (var combinedStream = new MemoryStream())
            {
                using (var binaryWriter = new BinaryWriter(combinedStream))
                {
                    //Prepend Nonce
                    binaryWriter.Write(nonce);
                    //Write Cipher Text
                    binaryWriter.Write(cipherText);
                }
                return Convert.ToBase64String(combinedStream.ToArray());
            }
        }

        string Decrypt(string textToDecrypt)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Mode = CipherMode.CBC;
            rijndaelCipher.Padding = PaddingMode.PKCS7;
            rijndaelCipher.KeySize = 0x80;
            rijndaelCipher.BlockSize = 0x80;
            byte[] encryptedData = Convert.FromBase64String(textToDecrypt);
            byte[] pwdBytes = GetFileBytes(SBIENCKeyPath);
            byte[] keyBytes = new byte[0x10];
            int len = pwdBytes.Length;
            if (len > keyBytes.Length)
            {
                len = keyBytes.Length;
            }
            Array.Copy(pwdBytes, keyBytes, len);
            rijndaelCipher.Key = keyBytes;
            rijndaelCipher.IV = keyBytes;
            byte[] plainText = rijndaelCipher.CreateDecryptor().TransformFinalBlock(encryptedData, 0, encryptedData.Length);
            return Encoding.UTF8.GetString(plainText);
        }

        public string DecryptWithKey(string encryptedMessage, int nonSecretPayloadLength = 0)
        {
            string SBIENCKeyPath = Convert.ToString(configuration.GetSection("Path").GetSection("SBIENCKey").Value);
            byte[] key = System.IO.File.ReadAllBytes(SBIENCKeyPath);
            if (encryptedMessage == null || encryptedMessage.Length == 0)
            {
                throw new ArgumentException("Encrypted Message Required!", "encryptedMessage");
            }
            byte[] msgToEncryptByte = Convert.FromBase64String(encryptedMessage);

            using (var cipher_stream = new MemoryStream(msgToEncryptByte))
            using (var cipher_reader = new BinaryReader(cipher_stream))
            {
                var payload = cipher_reader.ReadBytes(nonSecretPayloadLength);
                var nonce = cipher_reader.ReadBytes(16);
                var aesgcm_engine = new GcmBlockCipher(new AesFastEngine());
                var parameters = new AeadParameters(
                    new KeyParameter(key), 128, nonce, payload);
                aesgcm_engine.Init(false, parameters);
                var encrypted_text = cipher_reader.ReadBytes(
                    msgToEncryptByte.Length - (payload.Length + nonce.Length));
                var plaintext_size = aesgcm_engine.GetOutputSize(encrypted_text.Length);
                var plaintext = new byte[plaintext_size];
                var bytes_processed = aesgcm_engine.ProcessBytes(
                    encrypted_text,
                    0,
                    encrypted_text.Length,
                    plaintext,
                    0);
                try
                {
                    aesgcm_engine.DoFinal(plaintext, bytes_processed);
                }

                catch (Exception e)
                {
                    throw e;
                }

                return System.Text.Encoding.UTF8.GetString(plaintext);
            }

        }

        Byte[] GetFileBytes(String filePath)
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;
                buffer = new byte[length];
                int count;
                int sum = 0;
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }

        [HttpPost]
        public IActionResult PaymentResponse()
        {
            string documentContents = null;
            PaymentTransaction response = new PaymentTransaction();
            string strDecryptedVal = string.Empty;
            using (Stream receiveStream = HttpContext.Request.Body)
            {
                using (StreamReader readStream = new StreamReader(receiveStream, System.Text.Encoding.UTF8))
                {
                    documentContents = readStream.ReadToEnd();
                }
            }
            documentContents = HttpUtility.UrlDecode(documentContents.Replace("encdata=", string.Empty));

            //jeevan 01-May-2021
            strDecryptedVal = DecryptWithKey(documentContents);
            strSplitDecryptedResponse = strDecryptedVal.Split('|');
            SBINETGetPGRespnseData(strSplitDecryptedResponse);

            if (strPG_TxnStatusDesc.ToUpper().Contains("COMPLETED") || strPG_TxnStatusDesc.ToUpper().Contains("PENDING") || strPG_TxnStatusDesc.ToUpper() == "SUCCESS" || strPG_TxnStatusDesc.ToUpper() == "AWAITED" || strPG_TxnStatusDesc.ToUpper() == "NEFT" || strPG_TxnStatusDesc.ToUpper().Contains("P") || strPG_TxnStatusDesc.ToUpper() == "RECEIVED" || strPG_TxnStatusDesc.ToUpper() == "H")
            {
                response.TXN_STATUS = strPG_TxnStatusDesc.ToUpper(); //STATUS_DESC
                response.CLNT_TXN_REF = strPG_ClintTxnRefNo; //REF_NO
                response.PayMode = strPG_Paymode; // PAYMODE
                response.TPSL_TXN_ID = strPG_TPSLTxnID; // ICICI_REF_NO
                response.TXN_AMT = strPG_TxnAmount; // AMOUNT
                response.TPSL_TXN_TIME = strPG_TxnDateTime;//Challan Date time
                response.strPGRESPONSE = strDecryptedVal == string.Empty ? documentContents : strDecryptedVal;
                response.PayableRoyalty = PayableRoyalty;
                response.eCess = eCess;
                response.DMF = DMF;
                response.Cess = Cess;
                response.NMET = NMET;
                response.TCS = TCS;
                response.MonthlyPeriodicAmount = MonthlyPeriodicAmount;
                response.GIBNo = GIB_TXN_NO;
            }
            else
            {
                response.TXN_STATUS = "FAILED";
                response.CLNT_TXN_REF = strPG_ClintTxnRefNo; //REF_NO
                response.PayMode = strPG_Paymode; // PAYMODE
                response.TPSL_TXN_ID = strPG_TPSLTxnID; // ICICI_REF_NO
                response.TXN_AMT = strPG_TxnAmount; // AMOUNT
                response.TPSL_TXN_TIME = strPG_TxnDateTime;//Challan Date time
                response.strPGRESPONSE = strDecryptedVal == string.Empty ? documentContents : strDecryptedVal;
                response.PayableRoyalty = PayableRoyalty;
                response.eCess = eCess;
                response.DMF = DMF;
                response.Cess = Cess;
                response.NMET = NMET;
                response.TCS = TCS;
                response.MonthlyPeriodicAmount = MonthlyPeriodicAmount;
                response.GIBNo = GIB_TXN_NO;
            }


            return View(response);
        }

        public void SBINETGetPGRespnseData(string[] parameters)
        {
            try
            {
                string[] strGetMerchantParamForCompare;
                strPG_Paymode = "ONLINE";
                strPG_TxnDateTime = System.DateTime.Now.ToString();
                strArrPG_TxnDateTime = strPG_TxnDateTime.Split(' ');
                strPG_TxnDate = Convert.ToString(strArrPG_TxnDateTime[0]);
                strPG_TxnTime = Convert.ToString(strArrPG_TxnDateTime[1]);

                for (int i = 0; i < parameters.Length; i++)
                {
                    strGetMerchantParamForCompare = parameters[i].ToString().Split('=');
                    if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "CLNT_TXN_NO")
                    {
                        strPG_ClintTxnRefNo = Convert.ToString(strGetMerchantParamForCompare[1]);
                    }
                    else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "AMOUNT") // TXN_AMOUNT
                    {
                        strPG_TxnAmount = Convert.ToString(strGetMerchantParamForCompare[1]);
                    }
                    else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TXREFNO") // Bank Transaction Number
                    {
                        strPG_TPSLTxnID = Convert.ToString(strGetMerchantParamForCompare[1]);
                    }
                    else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TXSTATUS")
                    {
                        strPG_TxnStatus = Convert.ToString(strGetMerchantParamForCompare[1]);
                    }
                    else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TXSTATUSDESC")
                    {
                        strPG_TxnStatusDesc = Convert.ToString(strGetMerchantParamForCompare[1]);
                    }

                    else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "PAYMENT_BIFURCATION")
                    {
                        string metaData = Convert.ToString(strGetMerchantParamForCompare[1]);
                        string[] obj = strGetMerchantParamForCompare[1].Split(':');

                        if (obj != null && obj.Length > 0)
                        {
                            for (int j = 0; j < obj.Length; j++)
                            {
                                try
                                {
                                    FinalPaymentModel objModel = new FinalPaymentModel();
                                    objModel.PaymentAmount = Convert.ToString(obj[j].Split('~')[1]).ToString();
                                    objModel.PaymentType = Convert.ToString(obj[j].Split('~')[0]).Trim();
                                    objList.Add(objModel);

                                    if (Convert.ToString(obj[j].Split('~')[0]).Trim() == "KO01" || Convert.ToString(obj[j].Split('~')[0]).Trim() == "KO02")
                                    {
                                        PayableRoyalty = Convert.ToString(obj[j].Split('~')[1]).ToString();
                                    }
                                    else if (Convert.ToString(obj[j].Split('~')[0]).Trim() == "KO03")
                                    {
                                        TCS = Convert.ToString(obj[j].Split('~')[1]).ToString();
                                    }
                                    else if (Convert.ToString(obj[j].Split('~')[0]).Trim() == "KO04")
                                    {
                                        Cess = Convert.ToString(obj[j].Split('~')[1]).ToString();
                                    }
                                    else if (Convert.ToString(obj[j].Split('~')[0]).Trim() == "KO05")
                                    {
                                        eCess = Convert.ToString(obj[j].Split('~')[1]).ToString();
                                    }
                                    else if (Convert.ToString(obj[j].Split('~')[0]).Trim() == "DMF")
                                    {
                                        DMF = Convert.ToString(obj[j].Split('~')[1]).ToString();
                                    }
                                    else if (Convert.ToString(obj[j].Split('~')[0]).Trim() == "KO31")
                                    {
                                        NMET = Convert.ToString(obj[j].Split('~')[1]).ToString();
                                    }
                                    else if (Convert.ToString(obj[j].Split('~')[0]).Trim() == "KO19")
                                    {
                                        MonthlyPeriodicAmount = Convert.ToString(obj[j].Split('~')[1]).ToString();
                                    }

                                }
                                catch { }
                            }
                        }
                    }


                }
            }
            catch (Exception Exception)
            {
            }

        }

        public IActionResult OnlinePaymentStatus_SBI()
        {
            List<BankRemittanceModel> SBIPaymentStatusList = new List<BankRemittanceModel>();
            List<BankRemittanceModel> List = new List<BankRemittanceModel>();
            PaymentEF objmodel = new PaymentEF();
            objmodel.PaymentBank = "SBI";
            objmodel.FromDATE = "";
            objmodel.ToDATE = "";

            SBIPaymentStatusList = _objSBIModel.GetSBIPaymentStatus(objmodel);
            if (SBIPaymentStatusList != null && SBIPaymentStatusList.Count > 0)
            {
                int cnt = 1;
                for (var i = 0; i < SBIPaymentStatusList.Count; i++)
                {
                    BankRemittanceModel lst = new BankRemittanceModel();
                    lst.ClientTxnRefNumber = (SBIPaymentStatusList[i].MerchantRefNo); ;
                    lst.Amount = SBIPaymentStatusList[i].Amount;
                    lst.TPSL_TXN_TIME = SBIPaymentStatusList[i].TPSL_TXN_TIME;

                    lst.TXN_STATUS = SBIPaymentStatusList[i].TXN_STATUS;
                    //lst.TXN_STATUS = lst.TXN_STATUS.Replace(" ", "");
                    List.Add(lst);
                    cnt++;
                }
            }
            ViewBag.ViewList = List;
            return View();

        }

        public void GetPGRespnseData(string[] parameters)
        {
            string[] strGetMerchantParamForCompare;
            for (int i = 0; i < parameters.Length; i++)
            {
                strGetMerchantParamForCompare = parameters[i].ToString().Split('=');
                if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TXN_STATUS")
                {
                    strPG_TxnStatus = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TXN_AMOUNT")
                {
                    strPG_TxnAmount = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "SBI_TXN_ID")
                {
                    SBI_TXN_ID = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "CLNT_TXN_NO")
                {
                    _CLNT_TXN_NO = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TXN_STATUS_DESC")
                {
                    strPG_TxnStatusDesc = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TRANSACTION_DATE")
                {
                    strPG_TRANSACTIONDATE = Convert.ToString(strGetMerchantParamForCompare[1]);
                }

            }
        }
        [HttpPost]
        public JsonResult SBICheckStatus(string TxnId, string Amount)
        {
            object _result = 0;
            string response = string.Empty;
            string result = string.Empty;
            int _flag = 0;
            try
            {
                DoubleVerifyMerchantServicePortTypeClient objSBI = new DoubleVerifyMerchantServicePortTypeClient();

                var PostRequest = "CLNT_TXN_NO=" + TxnId + "|TXN_AMOUNT=" + Amount;

                String Result = GetSHA256(PostRequest);
                string str1 = PostRequest + "|checkSum=" + Result;
                string SBIPostRequest = EncryptWithKey(str1) + "^MINERAL_DEPT";


                string str = objSBI.DoubleVerification(SBIPostRequest);

                response = DecryptWithKey(str);
                strSplitDecryptedResponse = response.Split('|');
                GetPGRespnseData(strSplitDecryptedResponse);
                _flag = 1;

                if (_flag == 1)
                {
                    return Json(strPG_TxnStatus.ToString());
                }
                else
                {
                    if (strPG_TxnStatus.ToUpper() == "SUCCESS" && _flag == 0)
                    {
                        return Json("PENDING");
                    }
                    else
                    {
                        return Json("");
                    }
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
                result = "0";
                return Json(result.ToString());
            }

        }

        public bool InsertPaymentRequest(string RequestType, string MerchantCode, string MerchantTxnRefNumber, string ITC, string Amount, string CurrencyCode,
           string UniqueCustomerId, string ReturnURL, string S2SReturnURL, string TPSLTxnID, string ShoppingCartDetails, string txnDate, string Email,
           string MobileNumber, string BankCode, string CustomerName, string PropertyPath, string PaymentEncryptedData, string PaymentMode)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            PaymentEF model = new PaymentEF();
            model.PAYMENTFOR = 0;
            model.UserId = 83; //Convert.ToInt32(profile.UserId);
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
            model.PaymentModeString = PaymentMode;

            objMSmodel = _objSBIModel.InsertPaymentRequest(model);
            OutputResult = objMSmodel.Satus;
            return (Convert.ToInt32(OutputResult) > 0 ? true : false);

        }
        [HttpGet]
        public void InsertPaymentRequest(string RequestType, string MerchantCode, string MerchantTxnRefNumber, string ITC, string Amount, string CurrencyCode,
            string UniqueCustomerId, string ReturnURL, string S2SReturnURL, string TPSLTxnID, string ShoppingCartDetails, string txnDate, string Email,
            string MobileNumber, string BankCode, string CustomerName, string PropertyPath, string PaymentEncryptedData)

        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            PaymentEF model = new PaymentEF();
            model.PAYMENTFOR = 0;
            model.UserId = Convert.ToInt32(profile.UserId);
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
            objMSmodel = _objSBIModel.InsertPaymentRequest(model);
            OutputResult = objMSmodel.Satus;

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
    }
}
