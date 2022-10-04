using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using DotNetIntegrationKit;
using IntegrationApp.Areas.Payment.Models.DemandNotePayDetails;
using IntegrationApp.Areas.Payment.Models.SBIPayment;
using IntegrationApp.Helper;
using IntegrationApp.Models.EncryptDecrypt;
using IntegrationApp.Models.SBIEncryptDecryptKey;
using IntegrationApp.Web;
using IntegrationEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using System.IO;
using IntegrationApp.ActionFilter;

namespace IntegrationApp.Areas.Payment.Controllers
{
    [Area("Payment")]
    public class DemandNotePaymentController : Controller
    {
        private readonly IDemandNotePaymentDetailModel _DemandnoteModel;
        DemandNotePaymentEF payment = new DemandNotePaymentEF();
        RequestURL objRequestURL = new RequestURL();
        EncryptDecrypts objencdec = new EncryptDecrypts();
        //ePermitModel epermit = new ePermitModel();
        IOptions<KeyList> _objKeyList;
        MessageEF messageEF = new MessageEF();
        private IConfiguration configuration;
        private readonly IsbiIncriptDecript sbiIncriptDecript;
        ISBIPaymentModel _objSBIModel;
        string OutputResult = "";

        public DemandNotePaymentController(ISBIPaymentModel objSBIModel,IConfiguration _configuration,
           IsbiIncriptDecript sbiIncriptDecript, IOptions<KeyList> objKeyList, IDemandNotePaymentDetailModel DemandnoteModel)
        {
            _objSBIModel = objSBIModel;
            this._DemandnoteModel = DemandnoteModel;
            this.configuration = _configuration;
            this.sbiIncriptDecript = sbiIncriptDecript;
            _objKeyList = objKeyList;
        }


        [HttpGet]
        [SkipImportantTask]
        public ActionResult Paymentss(string DemandnoteId)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            List<DemandNotePaymentEF> list1 = new List<DemandNotePaymentEF>();
            List<DemandNotePaymentEF> payment = new List<DemandNotePaymentEF>();
            DemandNotePaymentEF obj = new DemandNotePaymentEF() { UserId= profile .UserId,DemandNoteCode= DemandnoteId };
            try
            {
                list1 = _DemandnoteModel.getDemandNoteSummaryData(obj);
                ViewBag.listtype = list1;
                payment = _DemandnoteModel.getDemandNoteSummaryDataAll(obj);
                if (payment != null && payment.Count > 0)
                {
                    ViewBag.total = payment[0].TotalPayableAmount;
                    payment[0].DemandNoteCode = DemandnoteId;
                    return View(payment[0]);
                }
                return View(obj);
            }
            catch (Exception)
            {

                throw;
            }


        }

        [HttpPost]
        public ActionResult Paymentss(DemandNotePaymentEF objmodel)
        {
            
            if (objmodel.PaymentMode == "1")
            {
                #region Online Payment
                string abc = string.Empty;
                string xyz = string.Empty;

                if (!string.IsNullOrEmpty(objmodel.arr))
                {
                    abc = objmodel.arr.Remove(0, 1);
                    xyz = abc.Remove(abc.Length - 1, 1);
                }
                decimal _totalPayable = 0;

                decimal TotalIntersetCalc = 0;
                List<DemandNotePaymentEF> payment = new List<DemandNotePaymentEF>();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserId = profile.UserId;
                try
                {

                    payment = _DemandnoteModel.getDemandNoteSummaryDataAll(objmodel);

                    objmodel.PayableRoyalty = Convert.ToDecimal(payment[0].PayableRoyalty);
                    objmodel.DMF = Convert.ToDecimal(payment[0].DMF);
                    objmodel.NMET = Convert.ToDecimal(payment[0].NMET);
                    objmodel.TCS = Convert.ToDecimal(payment[0].TCS);
                    objmodel.Infrastructure_Development_Cess = Convert.ToDecimal(payment[0].Infrastructure_Development_Cess);
                    objmodel.Environmental_Cess = Convert.ToDecimal(payment[0].Environmental_Cess);
                    // _total += Convert.ToDecimal(PaymentData.Rows[i]["TotalPayableAmount"]);
                    objmodel.Monthly_Periodic_Amount = Convert.ToDecimal(payment[0].Monthly_Periodic_Amount);
                    objmodel.differnceDays = Convert.ToInt32(payment[0].differnceDays);
                    decimal DemandNoteIntersetRate = payment[0].DemandNoteIntersetRate / 100;
                    int days = Convert.ToInt32(payment[0].TotalDaysPassed);
                    if (payment[0].differnceDays == 1)
                    {


                        if (DateTime.IsLeapYear(Convert.ToInt32(payment[0].DemandYear)))
                        {
                            objmodel.INT_PayableRoyalty = Math.Round(((days * DemandNoteIntersetRate) / 366) * payment[0].PayableRoyalty);
                            objmodel.INT_DMF = Math.Round(((days * DemandNoteIntersetRate) / 366) * payment[0].DMF);
                            objmodel.INT_NMET = Math.Round(((days * DemandNoteIntersetRate) / 366) * payment[0].NMET);
                            objmodel.INT_TCS = Math.Round(((days * DemandNoteIntersetRate) / 366) * payment[0].TCS);
                            objmodel.INT_iCess = Math.Round(((days * DemandNoteIntersetRate) / 366) * payment[0].Infrastructure_Development_Cess);
                            objmodel.INT_eCess = Math.Round(((days * DemandNoteIntersetRate) / 366) * payment[0].Environmental_Cess);
                            objmodel.INT_monthlyPeriodicAmount = Math.Round(((days * DemandNoteIntersetRate) / 366) * payment[0].Monthly_Periodic_Amount);
                        }
                        else
                        {
                            objmodel.INT_PayableRoyalty = Math.Round(((days * DemandNoteIntersetRate) / 365) * payment[0].PayableRoyalty);
                            objmodel.INT_DMF = Math.Round(((days * DemandNoteIntersetRate) / 365) * payment[0].DMF);
                            objmodel.INT_NMET = Math.Round(((days * DemandNoteIntersetRate) / 365) * payment[0].NMET);
                            objmodel.INT_TCS = Math.Round(((days * DemandNoteIntersetRate) / 365) * payment[0].TCS);
                            objmodel.INT_iCess = Math.Round(((days * DemandNoteIntersetRate) / 365) * payment[0].Infrastructure_Development_Cess);
                            objmodel.INT_eCess = Math.Round(((days * DemandNoteIntersetRate) / 365) * payment[0].Environmental_Cess);
                            objmodel.INT_monthlyPeriodicAmount = Math.Round(((days * DemandNoteIntersetRate) / 365) * payment[0].Monthly_Periodic_Amount);

                        }


                        TotalIntersetCalc = Convert.ToDecimal(objmodel.INT_PayableRoyalty + objmodel.INT_DMF + objmodel.INT_NMET + objmodel.INT_monthlyPeriodicAmount);
                    }


                    _totalPayable = Convert.ToDecimal(payment[0].PayableRoyalty + payment[0].DMF + payment[0].NMET + payment[0].Monthly_Periodic_Amount + TotalIntersetCalc);
                    objmodel.TotalPaidAmount = _totalPayable;
                    objmodel.TotalPayableAmount = (_totalPayable - TotalIntersetCalc);
                    objmodel.TotalAmount = (_totalPayable - TotalIntersetCalc);




                    messageEF = _DemandnoteModel.AddpayStatus(objmodel);

                    if (messageEF.Msg != null && !string.IsNullOrEmpty(Convert.ToString(messageEF.Msg)))
                    {
                       
                        String response = string.Empty;
                        RequestURL objRequestURL = new RequestURL();
                        //List<DemandNotePaymentEF> getpayment = new List<DemandNotePaymentEF>();
                        PaymentDetailsQmultiple getpayment = new PaymentDetailsQmultiple();

                        
                        getpayment = _DemandnoteModel.GetpayStatus(objmodel);


                        if (getpayment != null && getpayment.PaymentDetailsList.Count > 0)
                        {
                            getpayment.PaymentDetailsList[0].MerchantTxnRefNumber = messageEF.Msg.ToString();
                            #region ICICI
                            if (objmodel.PaymentBank.ToUpper() == "ICICI")
                            {

                                var isNEFT = false;
                                if (objmodel.PMode.ToUpper() == "NEFT")
                                {
                                    isNEFT = true;
                                }
                                else     // ADD By Kavita
                                {
                                    // Added by Avneesh for ICICI Net Banking
                                    string Nmode = objmodel.NetBanking_mode;
                                    isNEFT = false;
                                    //if (NetBanking_mode.ToUpper() == "CORPORATE")
                                    //{
                                    //    string Nmode = NetBanking_mode;
                                    //    isNEFT = false;
                                    //}
                                    //else
                                    //{
                                    //    string Nmode = NetBanking_mode;
                                    //}
                                    //------------------------------
                                }

                                objRequestURL.TPSLService = Convert.ToString(configuration.GetSection("Path").GetSection("ICICITPSLService").Value);
                                objRequestURL.LogFilePath = Convert.ToString(configuration.GetSection("Path").GetSection("ICICILogFilePath").Value);
                                objRequestURL.ErrorFile = Convert.ToString(configuration.GetSection("Path").GetSection("ICICIErrorFile").Value);

                                objmodel.TPSLTXNID = "NA";

                                objmodel.Amount = _totalPayable.ToString("0.00");

                                objmodel.Shoppingcartdetails = ("test_" + _totalPayable.ToString("0.00") + "_0.0").ToUpper();

                                string strITC = string.Empty;
                                decimal total_Amt = 0;
                                int count = 0;
                                foreach (var item in getpayment.PaymentHeadList)
                                {

                                    if (count == (getpayment.PaymentHeadList.Count - 1))
                                    {
                                        strITC += "" + Convert.ToString(item.ICICI).Trim() + ":" + Convert.ToDecimal(item.MappingValue).ToString("0.00");
                                    }
                                    else
                                    {
                                        strITC += "" + Convert.ToString(item.ICICI).Trim() + ":" + Convert.ToDecimal(item.MappingValue).ToString("0.00") + ",";
                                    }
                                    count++;
                                    total_Amt += Convert.ToDecimal(item.MappingValue);
                                }
                                objmodel.ITC = strITC;

                                //payment.Amount = (total_Amt).ToString("0.00");
                                objmodel.Shoppingcartdetails = ("test_" + (total_Amt).ToString("0.00") + "_0.0").ToUpper();

                                #region old Code
                                //payment.ITC = "PayableRoyalty:" + _PayableRoyalty.ToString("0.00") + "~TCS:" + _TCS.ToString("0.00")
                                //+ "~Cess:" + _iCess.ToString("0.00") 
                                //+ "~eCess:" + _eCess.ToString("0.00") 
                                //+ "~DMF:" + _DMF.ToString("0.00") + "~NMET:" 
                                //+ _NMET.ToString("0.00") + "~Monthly Periodic Amount:" 
                                //+ _monthlyPeriodicAmount.ToString("0.00") + "";
                                #endregion

                                //response = objRequestURL.SendRequest(payment.RequestType, payment.MerchantCode, payment.MerchantTxnRefNumber,
                                //    payment.ITC, payment.Amount, "INR", payment.uniqueCustomerID,
                                //    ConfigurationManager.AppSettings["ReturnUrl"].ToString(),
                                //    ConfigurationManager.AppSettings["S2SReturnURL"].ToString(),
                                //    payment.TPSLTXNID, payment.Shoppingcartdetails, payment.TxnDate,
                                //    payment.Email, payment.mobileNo, payment.Bankcode,
                                //    payment.customerName, Convert.ToString(ConfigurationManager.AppSettings["ICICIPropertyPath"]));


                                #region NEFT / RTGS
                                if (isNEFT)
                                {


                                    //// Follwoing Code for NEFT/RTGS
                                    var dat = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
                                    var dat1 = dat.Replace("-", "/");
                                    string finalSent = string.Empty;

                                    #region Old ICICI bank code

                                    //string ICICIPostRequest = "";
                                    //string original = "TPSL_PG_Mer_ID=" + ConfigurationManager.AppSettings["TPSLPGMERID"].ToString() + "|TPSL_EFMS_DEP_CODE=" + ConfigurationManager.AppSettings["TPSLEFMSDEPCODE"].ToString() + "|Merchant_Ref_no=" + payment.MerchantTxnRefNumber + "|Amount=" + payment.Amount + "|Paymode=NEFT|Scheme_Code=" + ConfigurationManager.AppSettings["SCHEMECODE"].ToString() + "|RU=" + ConfigurationManager.AppSettings["ReturnUrl"].ToString() + "|SRC_ITC=" + payment.ITC;
                                    //// string original = "TPSL_PG_Mer_ID=" + ConfigurationManager.AppSettings["TPSLPGMERID"].ToString() + "|TPSL_EFMS_DEP_CODE=" + ConfigurationManager.AppSettings["TPSLEFMSDEPCODE"].ToString() + "|Merchant_Ref_no=" + payment.MerchantTxnRefNumber + "|Amount=" + payment.Amount + "|Paymode=NEFT|Scheme_Code=" + ConfigurationManager.AppSettings["SCHEMECODE"].ToString() + "|RU=" + ConfigurationManager.AppSettings["ReturnUrl"].ToString() + "|SRC_ITC=" + payment.ITC + ",challanenddate~" + dat1;
                                    //string strRequestPlainText, strChecksum, strRequestWithChecksum = "";
                                    //strRequestPlainText = original;
                                    //strChecksum = EncryptValWithHex(strRequestPlainText, ConfigurationManager.AppSettings["NEFTICICIKey"].ToString(), ConfigurationManager.AppSettings["NEFTICICIIV"].ToString());
                                    //strRequestWithChecksum = strRequestPlainText + "|checkSum=" + strChecksum;
                                    //ICICIPostRequest = EncryptValWithHex(strRequestWithChecksum, ConfigurationManager.AppSettings["NEFTICICIKey"].ToString(), ConfigurationManager.AppSettings["NEFTICICIIV"].ToString());
                                    //finalSent = ICICIURL + "encdata=" + ICICIPostRequest + "&TPSL_PG_Mer_ID=" + ConfigurationManager.AppSettings["TPSLPGMERID"].ToString() + "";

                                    #endregion

                                    #region New ICICI Bank Code
                                    var SBIRequestString = string.Empty;
                                    //string GIB_URL = "https://gibtaxadm.icicibankltd.com/corp/AuthenticationController?FORMSGROUP_ID__=AuthenticationFG&__START_TRAN_FLAG__=Y&FG_BUTTONS__=LOAD&ACTION.LOAD=Y&AuthenticationFG.LOGIN_FLAG=1&BANK_ID=ICI&JS_ENABLED_FLAG=Y&ITC=00000015&CRN=INR&IS_GIB_SESSION=Y&MD=P&AppType=corporate&URLencoding=Y&CG=Y&STATFLG=H&IsCORDYS=Y&PID=220";
                                    string GIB_URL = "https://gibtax.icicibank.com/corp/AuthenticationController?FORMSGROUP_ID__=AuthenticationFG&__START_TRAN_FLAG__=Y&FG_BUTTONS__=LOAD&ACTION.LOAD=Y&AuthenticationFG.LOGIN_FLAG=1&BANK_ID=ICI&JS_ENABLED_FLAG=Y&ITC=00000015&CRN=INR&IS_GIB_SESSION=Y&MD=P&AppType=corporate&URLencoding=Y&CG=Y&STATFLG=H&IsCORDYS=Y&PID=220";
                                    string GIB_Parm = "Paymode=NEFT&DEP_CODE=MDGC&REF_NO=" + getpayment.PaymentDetailsList[0].MerchantTxnRefNumber + "&AMT=" + objmodel.Amount + "&RU=" + ConfigurationManager.AppSettings["ReturnUrl"].ToString() + "&SRC_ITC=" + objmodel.ITC + ",ApplicantName:" + getpayment.PaymentDetailsList[0].CustomerName.Trim();
                                    string test = GIB_URL + GIB_Parm;
                                    string GIB_encrpt = objencdec.EncryptAES(GIB_Parm);
                                    finalSent = GIB_URL + "&encdata=" + GIB_encrpt;
                                    #endregion

                                    SBIRequestString = "ApplicantName=" + getpayment.PaymentDetailsList[0].CustomerName.ToString() //ApplicantName
                                                     + "|EmailId=" + getpayment.PaymentDetailsList[0].USEREMAIL.ToString() //EmailId
                                                     + "|MobileNo=" + getpayment.PaymentDetailsList[0].USERMOBILENUMBER.ToString() //MobileNo
                                                     + "|CLNT_TXN_NO=" + getpayment.PaymentDetailsList[0].MerchantTxnRefNumber.ToString() //CLNT_TXN_NO
                                                     + "|Amount=" + Convert.ToDecimal(total_Amt).ToString("0.00") //TXN_AMOUNT
                                                     + "|Payment_Bifurcation=" + objmodel.ITC
                                                     + "|ReturnUrl=" + Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrl").Value);

                                    String checksum = GetSHA256(SBIRequestString);
                                    SBIRequestString += "|checkSum=" + checksum;
                                    string SBIPostRequest = EncryptWithKey(SBIRequestString);
                                    #region Insert Payment Request Data
                                    InsertPaymentRequest(getpayment.PaymentDetailsList[0].RequestType, getpayment.PaymentDetailsList[0].MERCHANTCODE, getpayment.PaymentDetailsList[0].MerchantTxnRefNumber,
                                        objmodel.ITC, objmodel.Amount, "INR", getpayment.PaymentDetailsList[0].UNIQUECUSTOMERID,
                                        Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrlICICI").Value),
                                          Convert.ToString(configuration.GetSection("Path").GetSection("S2SReturnURLICICI").Value),
                                        objmodel.TPSLTXNID, objmodel.Shoppingcartdetails, getpayment.PaymentDetailsList[0].TXNDATE,
                                        getpayment.PaymentDetailsList[0].USEREMAIL, getpayment.PaymentDetailsList[0].USERMOBILENUMBER, getpayment.PaymentDetailsList[0].BANKCODE,
                                       getpayment.PaymentDetailsList[0].CustomerName, Convert.ToString(configuration.GetSection("Path").GetSection("ICICIPropertyPath").Value), finalSent, "NEFT/RTGS");
                                    #endregion

                                    var msgdisp = "<html><form name='s1_2' id='s1_2' action='" + finalSent + "' method='post'> ";
                                    msgdisp += "<input name='encdata' value='" + SBIPostRequest + "' type='hidden'>";
                                    msgdisp += "<input name='merchant_code' value='MINERAL_DEPT' type='hidden'>";
                                    msgdisp += "<script type='text/javascript' language='javascript' >document.getElementById('s1_2').submit();";
                                    msgdisp += "</script>";
                                    msgdisp += "<script language='javascript' >";
                                    msgdisp += "</ script >";
                                    msgdisp += "</form> </html>";
                                    return Content(msgdisp, "text/html");

                                }
                                #endregion

                                #region NetBanking
                                else
                                {

                                    //// Follwoing code for NetBanking
                                    //var PID = ConfigurationManager.AppSettings["ICICIPID"].ToString();

                                    ////var ICICIreqString = "Action.ShoppingMall.Login.Init=Y&BankId=ICI&USER_LANG_ID=001&AppType=corporate&UserType=2?ShowOnSamePage=Y&MD=P&PID=" + PID + "&PRN=" + payment.ITC.Replace(" ", "") + "&ITC=41270000&AMT=" + payment.Amount + "&CRN=INR&CG=Y&CYBERR=Y&RU=" + ConfigurationManager.AppSettings["ReturnUrl"].ToString();
                                    //var ICICIreqString = "Action.ShoppingMall.Login.Init=Y&BankId=ICI&USER_LANG_ID=001&AppType=corporate&UserType=2?ShowOnSamePage=Y&MD=P&PID=" + PID + "&PRN=" + payment.ITC.Replace(" ", "") + ",REF_NO:" + payment.MerchantTxnRefNumber + "&ITC=" + ConfigurationManager.AppSettings["ITC"].ToString() + "&AMT=" + payment.Amount + "&CRN=INR&CG=Y&CYBERR=Y&RU=" + ConfigurationManager.AppSettings["ReturnUrl"].ToString();

                                    //var ICICINETBankingURL = ConfigurationManager.AppSettings["ICICITPSLService"].ToString() + ICICIreqString;

                                    //#region Insert Payment Request Data
                                    //CHiMMS_MVC.Controllers.PaymentRequest objPaymentRequest = new CHiMMS_MVC.Controllers.PaymentRequest();
                                    //objPaymentRequest.InsertPaymentRequest(payment.RequestType, payment.MerchantCode, payment.MerchantTxnRefNumber,
                                    //    payment.ITC, payment.Amount, "INR", payment.uniqueCustomerID,
                                    //    ConfigurationManager.AppSettings["ReturnUrl"].ToString(),
                                    //    ConfigurationManager.AppSettings["S2SReturnURL"].ToString(),
                                    //    payment.TPSLTXNID, payment.Shoppingcartdetails, payment.TxnDate,
                                    //    payment.Email, payment.mobileNo, payment.Bankcode,
                                    //    payment.customerName, Convert.ToString(ConfigurationManager.AppSettings["ICICIPropertyPath"]), ICICINETBankingURL);
                                    //#endregion

                                    //Updated By Avneesh

                                    //// Follwoing code for NetBanking

                                    //var ICICIreqString = "Action.ShoppingMall.Login.Init=Y&BankId=ICI&USER_LANG_ID=001&AppType=corporate&UserType=2?ShowOnSamePage=Y&MD=P&PID=" + PID + "&PRN=" + payment.ITC.Replace(" ", "") + "&ITC=41270000&AMT=" + payment.Amount + "&CRN=INR&CG=Y&CYBERR=Y&RU=" + ConfigurationManager.AppSettings["ReturnUrl"].ToString();
                                    //var ICICIreqString = "Action.ShoppingMall.Login.Init=Y&BankId=ICI&USER_LANG_ID=001&AppType=corporate&UserType=2?ShowOnSamePage=Y&MD=P&PID=" + PID + "&PRN=" + payment.ITC.Replace(" ", "") + ",REF_NO:" + payment.MerchantTxnRefNumber + "&ITC=" + ConfigurationManager.AppSettings["ITC"].ToString() + "&AMT=" + payment.Amount + "&CRN=INR&CG=Y&CYBERR=Y&RU=" + ConfigurationManager.AppSettings["ReturnUrl"].ToString();




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

                                    string GIB_Parm = "PRN=" + objmodel.ITC + ",REF_NO:" + getpayment.PaymentDetailsList[0].MerchantTxnRefNumber + ",ApplicantName:" + getpayment.PaymentDetailsList[0].CustomerName.Trim() + "&AMT=" + objmodel.Amount + "&RU=" + Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrlICICI").Value).ToString();


                                    //string GIB_Parm = "PRN=" + payment.ITC + ",REF_NO:" + payment.MerchantTxnRefNumber + ",ApplicantName:" + payment.customerName.Trim() + "&AMT=" + payment.Amount + "&RU=" + ConfigurationManager.AppSettings["ReturnUrl"].ToString();


                                    string test = GIB_URL + GIB_Parm;
                                    string GIB_encrpt = objencdec.EncryptAES(GIB_Parm);
                                    ICICINETBankingURL = GIB_URL + "&encdata=" + GIB_encrpt;
                                    #endregion

                                    //#region New ICICI Bank Code -- UAT Code
                                    // string GIB_URL = "https://gibtaxcug.icicibank.com/corp/AuthenticationController?FORMSGROUP_ID__=AuthenticationFG&__START_TRAN_FLAG__=Y&FG_BUTTONS__=LOAD&ACTION.LOAD=Y&AuthenticationFG.LOGIN_FLAG=1&BANK_ID=ICI&JS_ENABLED_FLAG=Y&ITC=00000015&CRN=INR&IS_GIB_SESSION=Y&MD=P&AppType=corporate&URLencoding=Y&CG=Y&STATFLG=H&CATEGORY_ID=264&PID=220&CYBERR=Y";
                                    ////     string GIB_URL = "http://10.50.75.12:9086/corp/AuthenticationController?FORMSGROUP_ID__=AuthenticationFG&__START_TRAN_FLAG__=Y&FG_BUTTONS__=LOAD&ACTION.LOAD=Y&AuthenticationFG.LOGIN_FLAG=1&BANK_ID=ICI&JS_ENABLED_FLAG=Y&ITC=00000015&CRN=INR&IS_GIB_SESSION=Y&MD=P&AppType=corporate&URLencoding=Y&CG=Y&STATFLG=H";
                                    //string GIB_Parm = "PRN=" + payment.ITC + ",REF_NO:" + payment.MerchantTxnRefNumber + ",ApplicantName:" + payment.customerName.Trim() + "&AMT=" + payment.Amount + "&RU=" + ConfigurationManager.AppSettings["ReturnUrl"].ToString();
                                    //string test = GIB_URL + GIB_Parm;
                                    //string GIB_encrpt = objencdec.EncryptAES(GIB_Parm);
                                    //ICICINETBankingURL = GIB_URL + "&encdata=" + GIB_encrpt;
                                    //#endregion

                                    #region Insert Payment Request Data
                                    InsertPaymentRequest(getpayment.PaymentDetailsList[0].RequestType, getpayment.PaymentDetailsList[0].MERCHANTCODE, getpayment.PaymentDetailsList[0].MerchantTxnRefNumber,
                                        objmodel.ITC, objmodel.Amount, "INR", getpayment.PaymentDetailsList[0].UNIQUECUSTOMERID,

                                         //Updated by Avneesh for ICICI net banking
                                         Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrlICICI").Value),
                                         Convert.ToString(configuration.GetSection("Path").GetSection("S2SReturnURLICICI").Value),


                                        //ConfigurationManager.AppSettings["ReturnUrl"].ToString(),
                                        //ConfigurationManager.AppSettings["S2SReturnURL"].ToString(),
                                        objmodel.TPSLTXNID, objmodel.Shoppingcartdetails, getpayment.PaymentDetailsList[0].TXNDATE,
                                        getpayment.PaymentDetailsList[0].USEREMAIL, getpayment.PaymentDetailsList[0].USERMOBILENUMBER, getpayment.PaymentDetailsList[0].BANKCODE,
                                        getpayment.PaymentDetailsList[0].CustomerName, Convert.ToString(configuration.GetSection("Path").GetSection("ICICIPropertyPath").Value), ICICINETBankingURL);
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

                            #region SBI
                            else
                            {

                                var SBIRequestString = string.Empty;
                                decimal total_Amt = 0;
                                objRequestURL.TPSLService = Convert.ToString(ConfigurationManager.AppSettings["SBIService"]);
                                objRequestURL.LogFilePath = string.Empty;
                                objRequestURL.ErrorFile = string.Empty;
                                objmodel.TPSLTXNID = "NA";

                                    objmodel.Amount = _totalPayable.ToString("0.00");

                                    objmodel.Shoppingcartdetails = ("test_" + _totalPayable.ToString("0.00") + "_0.0").ToUpper();

                                    string strITC = string.Empty;
                                    int count = 0;
                                    foreach (var item in getpayment.PaymentHeadList)
                                    {

                                        if (count == (getpayment.PaymentHeadList.Count - 1))
                                        {
                                            strITC += "" + Convert.ToString(item.ICICI).Trim() + "~" + Convert.ToDecimal(item.MappingValue).ToString("0.00");
                                        }
                                        else
                                        {
                                            strITC += "" + Convert.ToString(item.ICICI).Trim() + "~" + Convert.ToDecimal(item.MappingValue).ToString("0.00") + ":";
                                        }
                                        count++;
                                        total_Amt += Convert.ToDecimal(item.MappingValue);
                                    }
                                    objmodel.ITC = strITC;
                                    objmodel.Amount = (total_Amt).ToString("0.00");
                                    objmodel.Shoppingcartdetails = ("test_" + (total_Amt).ToString("0.00") + "_0.0").ToUpper();

                                    SBIRequestString = "ApplicantName=" + getpayment.PaymentDetailsList[0].CustomerName.ToString() //ApplicantName
                                                 + "|EmailId=" + getpayment.PaymentDetailsList[0].USEREMAIL.ToString() //EmailId
                                                 + "|MobileNo=" + getpayment.PaymentDetailsList[0].USERMOBILENUMBER.ToString() //MobileNo
                                                 + "|CLNT_TXN_NO=" + getpayment.PaymentDetailsList[0].MerchantTxnRefNumber.ToString() //CLNT_TXN_NO
                                                 + "|Amount=" + Convert.ToDecimal(total_Amt).ToString("0.00") //TXN_AMOUNT
                                                 + "|Payment_Bifurcation=" + objmodel.ITC
                                                 + "|ReturnUrl=" + Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrl").Value);
                                
                                //String Result = GetMD5Hash(SBIRequestString);
                                //string str1 = SBIRequestString + "|checkSum=" + Result;
                                //string SBIPostRequest = Encrypt(str1);

                                //jeevan  add  aec 265  /01-Jun-2021
                                string checksum = sbiIncriptDecript.GetSHA256(SBIRequestString);
                                SBIRequestString += "|checkSum=" + checksum;
                                string SBIPostRequest = sbiIncriptDecript.EncryptWithKey(SBIRequestString);
                                string SBIURL = Convert.ToString(configuration.GetSection("Path").GetSection("SBIService").Value);

                                #region Insert Payment Request Data
                                InsertPaymentRequest(getpayment.PaymentDetailsList[0].RequestType, getpayment.PaymentDetailsList[0].MERCHANTCODE, getpayment.PaymentDetailsList[0].MerchantTxnRefNumber,
                                         objmodel.ITC, objmodel.Amount, "INR", getpayment.PaymentDetailsList[0].UNIQUECUSTOMERID,

                                          //Updated by Avneesh for ICICI net banking
                                          Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrl").Value),
                                   Convert.ToString(configuration.GetSection("Path").GetSection("S2SReturnURL").Value),


                                         //ConfigurationManager.AppSettings["ReturnUrl"].ToString(),
                                         //ConfigurationManager.AppSettings["S2SReturnURL"].ToString(),
                                         objmodel.TPSLTXNID, objmodel.Shoppingcartdetails, getpayment.PaymentDetailsList[0].TXNDATE,
                                         getpayment.PaymentDetailsList[0].USEREMAIL, getpayment.PaymentDetailsList[0].USERMOBILENUMBER, getpayment.PaymentDetailsList[0].BANKCODE,
                                         getpayment.PaymentDetailsList[0].CustomerName, Convert.ToString(configuration.GetSection("Path").GetSection("ICICIPropertyPath").Value), SBIPostRequest);
                                #endregion

                                var msgdisp = "<html><form name='s1_2' id='s1_2' action='" + SBIURL + "' method='post'> ";
                                msgdisp += "<input name='encdata' value='" + SBIPostRequest + "' type='hidden'>";
                                msgdisp += "<input name='merchant_code' value='MINERAL_DEPT' type='hidden'>";
                                msgdisp += "<script type='text/javascript' language='javascript' >document.getElementById('s1_2').submit();";
                                msgdisp += "</script>";
                                msgdisp += "<script language='javascript' >";
                                msgdisp += "</ script >";
                                msgdisp += "</form> </html>";
                                return Content(msgdisp, "text/html");


                            }
                            #endregion
                        }

                        #region Commented Code
                        //if (string.IsNullOrEmpty(response) == true || response.ToUpper().StartsWith("ERROR"))
                        //{
                        //    //lblError = response;
                        //    TempData["AckMessage"] = "Payment cannot done.Please try again!";
                        //    return RedirectToAction("Payment", "DemandNotePayment", new { Area = "DemandNote" });
                        //}
                        //else
                        //{
                        //    if (payment.RequestType == "T")
                        //    {
                        //        Response.Write("<form name='s1_2' id='s1_2' action='" + response + "' method='post'> ");
                        //        Response.Write("<script type='text/javascript' language='javascript' >document.getElementById('s1_2').submit();");
                        //        Response.Write("</script>");
                        //        Response.Write("<script language='javascript' >");
                        //        Response.Write("</script>");
                        //        Response.Write("</form> ");
                        //    }
                        //}
                        #endregion
                        return null;
                    }
                    else
                    {
                        TempData["AckMessage"] = "Payment cannot done.Please try again!";
                        return RedirectToAction("DemandNoteSummary", "DemandNotePayment", new { Area = "DemandNote" });
                    }

                }
                catch(Exception ex)
                {
                    // Roll_back if payment not done // or getting some error in code.

                    //using (SqlCommand cmd = new SqlCommand())
                    //{
                    //    cmd.CommandText = "uspGetDemandNotePaymentList";
                    //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //    cmd.Parameters.AddWithValue("@DemandNoteCode", TransactionalID);
                    //    cmd.Parameters.AddWithValue("@UserId", SessionWrapper.UserId);
                    //    cmd.Parameters.AddWithValue("@SpMode", "MakePayment_RollBack");
                    //    cmd.Parameters.AddWithValue("@UserLoginId", SessionWrapper.UserLoginId);

                    //    bool result = objCon.InsertData(cmd);
                    //}
                }

                TempData["AckMessage"] = "Payment cannot done.Please try again!";
                return RedirectToAction("DemandNoteSummary", "DemandNotePayment", new { Area = "DemandNote" });
                #endregion
            }
            else
            {
                TempData["AckMessage"] = "Payment cannot done.Please try again!";
                return RedirectToAction("DemandNoteSummary", "DemandNotePayment", new { Area = "DemandNote" });
            }


        }
        public bool InsertPaymentRequest(string RequestType, string MerchantCode, string MerchantTxnRefNumber, string ITC, string Amount, string CurrencyCode,
   string UniqueCustomerId, string ReturnURL, string S2SReturnURL, string TPSLTxnID, string ShoppingCartDetails, string txnDate, string Email,
   string MobileNumber, string BankCode, string CustomerName, string PropertyPath, string PaymentEncryptedData, string PaymentMode)
        {
            MessageEF objMSmodel = new MessageEF();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            PaymentEF model = new PaymentEF();
            model.PAYMENTFOR = 0;
            model.UserId=Convert.ToInt32(profile.UserId);
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

        public static string GetSHA256(string name)
        {

            SHA256 SHA256 = new SHA256CryptoServiceProvider();
            byte[] ba = SHA256.ComputeHash(System.Text.Encoding.Default.GetBytes(name));
            System.Text.StringBuilder hex = new System.Text.StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
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
            messageEF = _objSBIModel.InsertPaymentRequest(model);
            OutputResult = messageEF.Satus;

        }

    }
}
