using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetIntegrationKit;
using IntegrationApp.ActionFilter;
using IntegrationApp.Areas.Payment.Models.NoticeLtrDetails;
using IntegrationApp.Areas.Payment.Models.SBIPayment;
using IntegrationApp.Helper;
using IntegrationApp.Models.EncryptDecrypt;
using IntegrationApp.Models.SBIEncryptDecryptKey;
using IntegrationApp.Web;
using IntegrationEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace IntegrationApp.Areas.Payment.Controllers
{
    [Area("Payment")]
    public class NoticeAndletterController : Controller
    {

        private readonly INoticeLtr _INoticeLtr;
        Notice payment = new Notice();
        RequestURL objRequestURL = new RequestURL();
        EncryptDecrypts objencdec = new EncryptDecrypts();
        //ePermitModel epermit = new ePermitModel();
        IOptions<KeyList> _objKeyList;
        MessageEF messageEF = new MessageEF();
        private IConfiguration configuration;
        private readonly IsbiIncriptDecript sbiIncriptDecript;
        ISBIPaymentModel _objSBIModel;
        string OutputResult = "";

        public NoticeAndletterController(ISBIPaymentModel objSBIModel, IConfiguration _configuration, IsbiIncriptDecript sbiIncriptDecript, IOptions<KeyList> objKeyList, INoticeLtr INoticeLtr)
        {
            _objSBIModel = objSBIModel;
            this._INoticeLtr = INoticeLtr;
            this.configuration = _configuration;
            this.sbiIncriptDecript = sbiIncriptDecript;
            _objKeyList = objKeyList;
        }

        [HttpGet]
        [SkipImportantTask]
        public ActionResult NoticeLtrPenalty(string arr, string totalPayableAmt, string PaymentType, string ArrtotalPayableAmt)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            List<Notice> list1 = new List<Notice>();

            Notice obj = new Notice() { arr= arr, totalPayableAmt= totalPayableAmt, OtherPaymentType = PaymentType, ArrtotalPayableAmt= ArrtotalPayableAmt,MineralTypeName= profile.MineralTypeName,UserId=profile.UserId, Check="4" } ;
            try
            {
                list1 = _INoticeLtr.NoticeLtrPaynalty(obj);
                ViewBag.total = list1[0].ArrtotalPayableAmt;
   
                //payment = _DemandnoteModel.getDemandNoteSummaryDataAll(obj);
                //if (payment != null && payment.Count > 0)
                //{
                //    ViewBag.total = payment[0].TotalPayableAmount;
                //    payment[0].DemandNoteCode = DemandnoteId;
                //    return View(payment[0]);
                //}



                return View(list1[0]);
            }
            catch (Exception)
            {

                throw;
            }

            return View();
        }


        [HttpPost]
        public ActionResult NoticeLtrPenalty(Notice objmodel)
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




                //try
                //{

                //    payment = _DemandnoteModel.getDemandNoteSummaryDataAll(objmodel);

                //    objmodel.PayableRoyalty = Convert.ToDecimal(payment[0].PayableRoyalty);
                //    objmodel.DMF = Convert.ToDecimal(payment[0].DMF);
                //    objmodel.NMET = Convert.ToDecimal(payment[0].NMET);
                //    objmodel.TCS = Convert.ToDecimal(payment[0].TCS);
                //    objmodel.Infrastructure_Development_Cess = Convert.ToDecimal(payment[0].Infrastructure_Development_Cess);
                //    objmodel.Environmental_Cess = Convert.ToDecimal(payment[0].Environmental_Cess);
                //    // _total += Convert.ToDecimal(PaymentData.Rows[i]["TotalPayableAmount"]);
                //    objmodel.Monthly_Periodic_Amount = Convert.ToDecimal(payment[0].Monthly_Periodic_Amount);
                //    objmodel.differnceDays = Convert.ToInt32(payment[0].differnceDays);
                //    decimal DemandNoteIntersetRate = payment[0].DemandNoteIntersetRate / 100;
                //    int days = Convert.ToInt32(payment[0].TotalDaysPassed);
                //    if (payment[0].differnceDays == 1)
                //    {


                //        if (DateTime.IsLeapYear(Convert.ToInt32(payment[0].DemandYear)))
                //        {
                //            objmodel.INT_PayableRoyalty = Math.Round(((days * DemandNoteIntersetRate) / 366) * payment[0].PayableRoyalty);
                //            objmodel.INT_DMF = Math.Round(((days * DemandNoteIntersetRate) / 366) * payment[0].DMF);
                //            objmodel.INT_NMET = Math.Round(((days * DemandNoteIntersetRate) / 366) * payment[0].NMET);
                //            objmodel.INT_TCS = Math.Round(((days * DemandNoteIntersetRate) / 366) * payment[0].TCS);
                //            objmodel.INT_iCess = Math.Round(((days * DemandNoteIntersetRate) / 366) * payment[0].Infrastructure_Development_Cess);
                //            objmodel.INT_eCess = Math.Round(((days * DemandNoteIntersetRate) / 366) * payment[0].Environmental_Cess);
                //            objmodel.INT_monthlyPeriodicAmount = Math.Round(((days * DemandNoteIntersetRate) / 366) * payment[0].Monthly_Periodic_Amount);
                //        }
                //        else
                //        {
                //            objmodel.INT_PayableRoyalty = Math.Round(((days * DemandNoteIntersetRate) / 365) * payment[0].PayableRoyalty);
                //            objmodel.INT_DMF = Math.Round(((days * DemandNoteIntersetRate) / 365) * payment[0].DMF);
                //            objmodel.INT_NMET = Math.Round(((days * DemandNoteIntersetRate) / 365) * payment[0].NMET);
                //            objmodel.INT_TCS = Math.Round(((days * DemandNoteIntersetRate) / 365) * payment[0].TCS);
                //            objmodel.INT_iCess = Math.Round(((days * DemandNoteIntersetRate) / 365) * payment[0].Infrastructure_Development_Cess);
                //            objmodel.INT_eCess = Math.Round(((days * DemandNoteIntersetRate) / 365) * payment[0].Environmental_Cess);
                //            objmodel.INT_monthlyPeriodicAmount = Math.Round(((days * DemandNoteIntersetRate) / 365) * payment[0].Monthly_Periodic_Amount);

                //        }


                //        TotalIntersetCalc = Convert.ToDecimal(objmodel.INT_PayableRoyalty + objmodel.INT_DMF + objmodel.INT_NMET + objmodel.INT_monthlyPeriodicAmount);
                //    }


                //    _totalPayable = Convert.ToDecimal(payment[0].PayableRoyalty + payment[0].DMF + payment[0].NMET + payment[0].Monthly_Periodic_Amount + TotalIntersetCalc);
                //    objmodel.TotalPaidAmount = _totalPayable;
                //    objmodel.TotalPayableAmount = (_totalPayable - TotalIntersetCalc);
                //    objmodel.TotalAmount = (_totalPayable - TotalIntersetCalc);




                //    messageEF = _DemandnoteModel.AddpayStatus(objmodel);

                //    if (messageEF.Msg != null && !string.IsNullOrEmpty(Convert.ToString(messageEF.Msg)))
                //    {

                //        String response = string.Empty;
                //        RequestURL objRequestURL = new RequestURL();
                //        //List<DemandNotePaymentEF> getpayment = new List<DemandNotePaymentEF>();
                //        PaymentDetailsQmultiple getpayment = new PaymentDetailsQmultiple();


                //        getpayment = _DemandnoteModel.GetpayStatus(objmodel);


                //        if (getpayment != null && getpayment.PaymentDetailsList.Count > 0)
                //        {
                //            getpayment.PaymentDetailsList[0].MerchantTxnRefNumber = messageEF.Msg.ToString();
                //            #region ICICI
                //            if (objmodel.PaymentBank.ToUpper() == "ICICI")
                //            {

                //                var isNEFT = false;
                //                if (objmodel.PMode.ToUpper() == "NEFT")
                //                {
                //                    isNEFT = true;
                //                }
                //                else     // ADD By Kavita
                //                {
                //                    // Added by Avneesh for ICICI Net Banking
                //                    string Nmode = objmodel.NetBanking_mode;
                //                    isNEFT = false;
                //                    //if (NetBanking_mode.ToUpper() == "CORPORATE")
                //                    //{
                //                    //    string Nmode = NetBanking_mode;
                //                    //    isNEFT = false;
                //                    //}
                //                    //else
                //                    //{
                //                    //    string Nmode = NetBanking_mode;
                //                    //}
                //                    //------------------------------
                //                }

                //                objRequestURL.TPSLService = Convert.ToString(configuration.GetSection("Path").GetSection("ICICITPSLService").Value);
                //                objRequestURL.LogFilePath = Convert.ToString(configuration.GetSection("Path").GetSection("ICICILogFilePath").Value);
                //                objRequestURL.ErrorFile = Convert.ToString(configuration.GetSection("Path").GetSection("ICICIErrorFile").Value);

                //                objmodel.TPSLTXNID = "NA";

                //                objmodel.Amount = _totalPayable.ToString("0.00");

                //                objmodel.Shoppingcartdetails = ("test_" + _totalPayable.ToString("0.00") + "_0.0").ToUpper();

                //                string strITC = string.Empty;
                //                decimal total_Amt = 0;
                //                int count = 0;
                //                foreach (var item in getpayment.PaymentHeadList)
                //                {

                //                    if (count == (getpayment.PaymentHeadList.Count - 1))
                //                    {
                //                        strITC += "" + Convert.ToString(item.ICICI).Trim() + ":" + Convert.ToDecimal(item.MappingValue).ToString("0.00");
                //                    }
                //                    else
                //                    {
                //                        strITC += "" + Convert.ToString(item.ICICI).Trim() + ":" + Convert.ToDecimal(item.MappingValue).ToString("0.00") + ",";
                //                    }
                //                    count++;
                //                    total_Amt += Convert.ToDecimal(item.MappingValue);
                //                }
                //                objmodel.ITC = strITC;

                //                //payment.Amount = (total_Amt).ToString("0.00");
                //                objmodel.Shoppingcartdetails = ("test_" + (total_Amt).ToString("0.00") + "_0.0").ToUpper();

                //                #region old Code
                //                //payment.ITC = "PayableRoyalty:" + _PayableRoyalty.ToString("0.00") + "~TCS:" + _TCS.ToString("0.00")
                //                //+ "~Cess:" + _iCess.ToString("0.00") 
                //                //+ "~eCess:" + _eCess.ToString("0.00") 
                //                //+ "~DMF:" + _DMF.ToString("0.00") + "~NMET:" 
                //                //+ _NMET.ToString("0.00") + "~Monthly Periodic Amount:" 
                //                //+ _monthlyPeriodicAmount.ToString("0.00") + "";
                //                #endregion

                //                //response = objRequestURL.SendRequest(payment.RequestType, payment.MerchantCode, payment.MerchantTxnRefNumber,
                //                //    payment.ITC, payment.Amount, "INR", payment.uniqueCustomerID,
                //                //    ConfigurationManager.AppSettings["ReturnUrl"].ToString(),
                //                //    ConfigurationManager.AppSettings["S2SReturnURL"].ToString(),
                //                //    payment.TPSLTXNID, payment.Shoppingcartdetails, payment.TxnDate,
                //                //    payment.Email, payment.mobileNo, payment.Bankcode,
                //                //    payment.customerName, Convert.ToString(ConfigurationManager.AppSettings["ICICIPropertyPath"]));


                //                #region NEFT / RTGS
                //                if (isNEFT)
                //                {


                //                    //// Follwoing Code for NEFT/RTGS
                //                    var dat = System.DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
                //                    var dat1 = dat.Replace("-", "/");
                //                    string finalSent = string.Empty;

                //                    #region Old ICICI bank code

                //                    //string ICICIPostRequest = "";
                //                    //string original = "TPSL_PG_Mer_ID=" + ConfigurationManager.AppSettings["TPSLPGMERID"].ToString() + "|TPSL_EFMS_DEP_CODE=" + ConfigurationManager.AppSettings["TPSLEFMSDEPCODE"].ToString() + "|Merchant_Ref_no=" + payment.MerchantTxnRefNumber + "|Amount=" + payment.Amount + "|Paymode=NEFT|Scheme_Code=" + ConfigurationManager.AppSettings["SCHEMECODE"].ToString() + "|RU=" + ConfigurationManager.AppSettings["ReturnUrl"].ToString() + "|SRC_ITC=" + payment.ITC;
                //                    //// string original = "TPSL_PG_Mer_ID=" + ConfigurationManager.AppSettings["TPSLPGMERID"].ToString() + "|TPSL_EFMS_DEP_CODE=" + ConfigurationManager.AppSettings["TPSLEFMSDEPCODE"].ToString() + "|Merchant_Ref_no=" + payment.MerchantTxnRefNumber + "|Amount=" + payment.Amount + "|Paymode=NEFT|Scheme_Code=" + ConfigurationManager.AppSettings["SCHEMECODE"].ToString() + "|RU=" + ConfigurationManager.AppSettings["ReturnUrl"].ToString() + "|SRC_ITC=" + payment.ITC + ",challanenddate~" + dat1;
                //                    //string strRequestPlainText, strChecksum, strRequestWithChecksum = "";
                //                    //strRequestPlainText = original;
                //                    //strChecksum = EncryptValWithHex(strRequestPlainText, ConfigurationManager.AppSettings["NEFTICICIKey"].ToString(), ConfigurationManager.AppSettings["NEFTICICIIV"].ToString());
                //                    //strRequestWithChecksum = strRequestPlainText + "|checkSum=" + strChecksum;
                //                    //ICICIPostRequest = EncryptValWithHex(strRequestWithChecksum, ConfigurationManager.AppSettings["NEFTICICIKey"].ToString(), ConfigurationManager.AppSettings["NEFTICICIIV"].ToString());
                //                    //finalSent = ICICIURL + "encdata=" + ICICIPostRequest + "&TPSL_PG_Mer_ID=" + ConfigurationManager.AppSettings["TPSLPGMERID"].ToString() + "";

                //                    #endregion

                //                    #region New ICICI Bank Code
                //                    var SBIRequestString = string.Empty;
                //                    //string GIB_URL = "https://gibtaxadm.icicibankltd.com/corp/AuthenticationController?FORMSGROUP_ID__=AuthenticationFG&__START_TRAN_FLAG__=Y&FG_BUTTONS__=LOAD&ACTION.LOAD=Y&AuthenticationFG.LOGIN_FLAG=1&BANK_ID=ICI&JS_ENABLED_FLAG=Y&ITC=00000015&CRN=INR&IS_GIB_SESSION=Y&MD=P&AppType=corporate&URLencoding=Y&CG=Y&STATFLG=H&IsCORDYS=Y&PID=220";
                //                    string GIB_URL = "https://gibtax.icicibank.com/corp/AuthenticationController?FORMSGROUP_ID__=AuthenticationFG&__START_TRAN_FLAG__=Y&FG_BUTTONS__=LOAD&ACTION.LOAD=Y&AuthenticationFG.LOGIN_FLAG=1&BANK_ID=ICI&JS_ENABLED_FLAG=Y&ITC=00000015&CRN=INR&IS_GIB_SESSION=Y&MD=P&AppType=corporate&URLencoding=Y&CG=Y&STATFLG=H&IsCORDYS=Y&PID=220";
                //                    string GIB_Parm = "Paymode=NEFT&DEP_CODE=MDGC&REF_NO=" + getpayment.PaymentDetailsList[0].MerchantTxnRefNumber + "&AMT=" + objmodel.Amount + "&RU=" + ConfigurationManager.AppSettings["ReturnUrl"].ToString() + "&SRC_ITC=" + objmodel.ITC + ",ApplicantName:" + getpayment.PaymentDetailsList[0].CustomerName.Trim();
                //                    string test = GIB_URL + GIB_Parm;
                //                    string GIB_encrpt = objencdec.EncryptAES(GIB_Parm);
                //                    finalSent = GIB_URL + "&encdata=" + GIB_encrpt;
                //                    #endregion

                //                    SBIRequestString = "ApplicantName=" + getpayment.PaymentDetailsList[0].CustomerName.ToString() //ApplicantName
                //                                     + "|EmailId=" + getpayment.PaymentDetailsList[0].USEREMAIL.ToString() //EmailId
                //                                     + "|MobileNo=" + getpayment.PaymentDetailsList[0].USERMOBILENUMBER.ToString() //MobileNo
                //                                     + "|CLNT_TXN_NO=" + getpayment.PaymentDetailsList[0].MerchantTxnRefNumber.ToString() //CLNT_TXN_NO
                //                                     + "|Amount=" + Convert.ToDecimal(total_Amt).ToString("0.00") //TXN_AMOUNT
                //                                     + "|Payment_Bifurcation=" + objmodel.ITC
                //                                     + "|ReturnUrl=" + Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrl").Value);

                //                    String checksum = GetSHA256(SBIRequestString);
                //                    SBIRequestString += "|checkSum=" + checksum;
                //                    string SBIPostRequest = EncryptWithKey(SBIRequestString);
                //                    #region Insert Payment Request Data
                //                    InsertPaymentRequest(getpayment.PaymentDetailsList[0].RequestType, getpayment.PaymentDetailsList[0].MERCHANTCODE, getpayment.PaymentDetailsList[0].MerchantTxnRefNumber,
                //                        objmodel.ITC, objmodel.Amount, "INR", getpayment.PaymentDetailsList[0].UNIQUECUSTOMERID,
                //                        Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrlICICI").Value),
                //                          Convert.ToString(configuration.GetSection("Path").GetSection("S2SReturnURLICICI").Value),
                //                        objmodel.TPSLTXNID, objmodel.Shoppingcartdetails, getpayment.PaymentDetailsList[0].TXNDATE,
                //                        getpayment.PaymentDetailsList[0].USEREMAIL, getpayment.PaymentDetailsList[0].USERMOBILENUMBER, getpayment.PaymentDetailsList[0].BANKCODE,
                //                       getpayment.PaymentDetailsList[0].CustomerName, Convert.ToString(configuration.GetSection("Path").GetSection("ICICIPropertyPath").Value), finalSent, "NEFT/RTGS");
                //                    #endregion

                //                    var msgdisp = "<html><form name='s1_2' id='s1_2' action='" + finalSent + "' method='post'> ";
                //                    msgdisp += "<input name='encdata' value='" + SBIPostRequest + "' type='hidden'>";
                //                    msgdisp += "<input name='merchant_code' value='MINERAL_DEPT' type='hidden'>";
                //                    msgdisp += "<script type='text/javascript' language='javascript' >document.getElementById('s1_2').submit();";
                //                    msgdisp += "</script>";
                //                    msgdisp += "<script language='javascript' >";
                //                    msgdisp += "</ script >";
                //                    msgdisp += "</form> </html>";
                //                    return Content(msgdisp, "text/html");

                //                }
                //                #endregion

                //                #region NetBanking
                //                else
                //                {
                //                    #region New ICICI Bank Code -- Live Code
                //                    var ICICIreqString = "FORMSGROUP_ID__=AuthenticationFG&__START_TRAN_FLAG__=Y&FG_BUTTONS__=LOAD&ACTION.LOAD=Y&AuthenticationFG.LOGIN_FLAG=1&BANK_ID=ICI&JS_ENABLED_FLAG=Y&ITC=00000015&PRN=11&CRN=INR&MD=P&PID=220&IS_GIB_SESSION=Y&CATEGORY_ID=264&AppType=corporate&URLencoding=Y&CG=Y&CYBERR=Y";

                //                    var ICICINETBankingURL = Convert.ToString(configuration.GetSection("Path").GetSection("ICICITPSLService").Value) + ICICIreqString;

                //                    string GIB_URL = ICICINETBankingURL;

                //                    //updated by Avneesh for ICICI net banking

                //                    string GIB_Parm = "PRN=" + objmodel.ITC + ",REF_NO:" + getpayment.PaymentDetailsList[0].MerchantTxnRefNumber + ",ApplicantName:" + getpayment.PaymentDetailsList[0].CustomerName.Trim() + "&AMT=" + objmodel.Amount + "&RU=" + Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrlICICI").Value).ToString();


                //                    //string GIB_Parm = "PRN=" + payment.ITC + ",REF_NO:" + payment.MerchantTxnRefNumber + ",ApplicantName:" + payment.customerName.Trim() + "&AMT=" + payment.Amount + "&RU=" + ConfigurationManager.AppSettings["ReturnUrl"].ToString();


                //                    string test = GIB_URL + GIB_Parm;
                //                    string GIB_encrpt = objencdec.EncryptAES(GIB_Parm);
                //                    ICICINETBankingURL = GIB_URL + "&encdata=" + GIB_encrpt;
                //                    #endregion


                //                    #region Insert Payment Request Data
                //                    InsertPaymentRequest(getpayment.PaymentDetailsList[0].RequestType, getpayment.PaymentDetailsList[0].MERCHANTCODE, getpayment.PaymentDetailsList[0].MerchantTxnRefNumber,
                //                        objmodel.ITC, objmodel.Amount, "INR", getpayment.PaymentDetailsList[0].UNIQUECUSTOMERID,

                //                         //Updated by Avneesh for ICICI net banking
                //                         Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrlICICI").Value),
                //                         Convert.ToString(configuration.GetSection("Path").GetSection("S2SReturnURLICICI").Value),


                //                        //ConfigurationManager.AppSettings["ReturnUrl"].ToString(),
                //                        //ConfigurationManager.AppSettings["S2SReturnURL"].ToString(),
                //                        objmodel.TPSLTXNID, objmodel.Shoppingcartdetails, getpayment.PaymentDetailsList[0].TXNDATE,
                //                        getpayment.PaymentDetailsList[0].USEREMAIL, getpayment.PaymentDetailsList[0].USERMOBILENUMBER, getpayment.PaymentDetailsList[0].BANKCODE,
                //                        getpayment.PaymentDetailsList[0].CustomerName, Convert.ToString(configuration.GetSection("Path").GetSection("ICICIPropertyPath").Value), ICICINETBankingURL);
                //                    #endregion

                //                    var msgdisp = "<html><form name='s1_2' id='s1_2' action='" + ICICINETBankingURL + "' method='post'> ";
                //                    msgdisp += "<script type='text/javascript' language='javascript' >document.getElementById('s1_2').submit();";
                //                    msgdisp += "</script>";
                //                    msgdisp += "<script language='javascript' >";
                //                    msgdisp += "</ script >";
                //                    msgdisp += "</form></html> ";
                //                    return Content(msgdisp, "text/html");


                //                }
                //                #endregion
                //            }

                //            #endregion

                //            #region SBI
                //            else
                //            {

                //                var SBIRequestString = string.Empty;
                //                decimal total_Amt = 0;
                //                objRequestURL.TPSLService = Convert.ToString(ConfigurationManager.AppSettings["SBIService"]);
                //                objRequestURL.LogFilePath = string.Empty;
                //                objRequestURL.ErrorFile = string.Empty;
                //                objmodel.TPSLTXNID = "NA";

                //                objmodel.Amount = _totalPayable.ToString("0.00");

                //                objmodel.Shoppingcartdetails = ("test_" + _totalPayable.ToString("0.00") + "_0.0").ToUpper();

                //                string strITC = string.Empty;
                //                int count = 0;
                //                foreach (var item in getpayment.PaymentHeadList)
                //                {

                //                    if (count == (getpayment.PaymentHeadList.Count - 1))
                //                    {
                //                        strITC += "" + Convert.ToString(item.ICICI).Trim() + "~" + Convert.ToDecimal(item.MappingValue).ToString("0.00");
                //                    }
                //                    else
                //                    {
                //                        strITC += "" + Convert.ToString(item.ICICI).Trim() + "~" + Convert.ToDecimal(item.MappingValue).ToString("0.00") + ":";
                //                    }
                //                    count++;
                //                    total_Amt += Convert.ToDecimal(item.MappingValue);
                //                }
                //                objmodel.ITC = strITC;
                //                objmodel.Amount = (total_Amt).ToString("0.00");
                //                objmodel.Shoppingcartdetails = ("test_" + (total_Amt).ToString("0.00") + "_0.0").ToUpper();

                //                SBIRequestString = "ApplicantName=" + getpayment.PaymentDetailsList[0].CustomerName.ToString() //ApplicantName
                //                             + "|EmailId=" + getpayment.PaymentDetailsList[0].USEREMAIL.ToString() //EmailId
                //                             + "|MobileNo=" + getpayment.PaymentDetailsList[0].USERMOBILENUMBER.ToString() //MobileNo
                //                             + "|CLNT_TXN_NO=" + getpayment.PaymentDetailsList[0].MerchantTxnRefNumber.ToString() //CLNT_TXN_NO
                //                             + "|Amount=" + Convert.ToDecimal(total_Amt).ToString("0.00") //TXN_AMOUNT
                //                             + "|Payment_Bifurcation=" + objmodel.ITC
                //                             + "|ReturnUrl=" + Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrl").Value);

                //                //String Result = GetMD5Hash(SBIRequestString);
                //                //string str1 = SBIRequestString + "|checkSum=" + Result;
                //                //string SBIPostRequest = Encrypt(str1);

                //                //jeevan  add  aec 265  /01-Jun-2021
                //                string checksum = sbiIncriptDecript.GetSHA256(SBIRequestString);
                //                SBIRequestString += "|checkSum=" + checksum;
                //                string SBIPostRequest = sbiIncriptDecript.EncryptWithKey(SBIRequestString);
                //                string SBIURL = Convert.ToString(configuration.GetSection("Path").GetSection("SBIService").Value);

                //                #region Insert Payment Request Data
                //                InsertPaymentRequest(getpayment.PaymentDetailsList[0].RequestType, getpayment.PaymentDetailsList[0].MERCHANTCODE, getpayment.PaymentDetailsList[0].MerchantTxnRefNumber,
                //                         objmodel.ITC, objmodel.Amount, "INR", getpayment.PaymentDetailsList[0].UNIQUECUSTOMERID,

                //                          //Updated by Avneesh for ICICI net banking
                //                          Convert.ToString(configuration.GetSection("Path").GetSection("ReturnUrl").Value),
                //                   Convert.ToString(configuration.GetSection("Path").GetSection("S2SReturnURL").Value),


                //                         //ConfigurationManager.AppSettings["ReturnUrl"].ToString(),
                //                         //ConfigurationManager.AppSettings["S2SReturnURL"].ToString(),
                //                         objmodel.TPSLTXNID, objmodel.Shoppingcartdetails, getpayment.PaymentDetailsList[0].TXNDATE,
                //                         getpayment.PaymentDetailsList[0].USEREMAIL, getpayment.PaymentDetailsList[0].USERMOBILENUMBER, getpayment.PaymentDetailsList[0].BANKCODE,
                //                         getpayment.PaymentDetailsList[0].CustomerName, Convert.ToString(configuration.GetSection("Path").GetSection("ICICIPropertyPath").Value), SBIPostRequest);
                //                #endregion

                //                var msgdisp = "<html><form name='s1_2' id='s1_2' action='" + SBIURL + "' method='post'> ";
                //                msgdisp += "<input name='encdata' value='" + SBIPostRequest + "' type='hidden'>";
                //                msgdisp += "<input name='merchant_code' value='MINERAL_DEPT' type='hidden'>";
                //                msgdisp += "<script type='text/javascript' language='javascript' >document.getElementById('s1_2').submit();";
                //                msgdisp += "</script>";
                //                msgdisp += "<script language='javascript' >";
                //                msgdisp += "</ script >";
                //                msgdisp += "</form> </html>";
                //                return Content(msgdisp, "text/html");


                //            }
                //            #endregion
                //        }

                //        #region Commented Code
                //        //if (string.IsNullOrEmpty(response) == true || response.ToUpper().StartsWith("ERROR"))
                //        //{
                //        //    //lblError = response;
                //        //    TempData["AckMessage"] = "Payment cannot done.Please try again!";
                //        //    return RedirectToAction("Payment", "DemandNotePayment", new { Area = "DemandNote" });
                //        //}
                //        //else
                //        //{
                //        //    if (payment.RequestType == "T")
                //        //    {
                //        //        Response.Write("<form name='s1_2' id='s1_2' action='" + response + "' method='post'> ");
                //        //        Response.Write("<script type='text/javascript' language='javascript' >document.getElementById('s1_2').submit();");
                //        //        Response.Write("</script>");
                //        //        Response.Write("<script language='javascript' >");
                //        //        Response.Write("</script>");
                //        //        Response.Write("</form> ");
                //        //    }
                //        //}
                //        #endregion
                //        return null;
                //    }
                //    else
                //    {
                //        TempData["AckMessage"] = "Payment cannot done.Please try again!";
                //        return RedirectToAction("DemandNoteSummary", "DemandNotePayment", new { Area = "DemandNote" });
                //    }

                //}
                //catch (Exception ex)
                //{
                //    // Roll_back if payment not done // or getting some error in code.

                //    //using (SqlCommand cmd = new SqlCommand())
                //    //{
                //    //    cmd.CommandText = "uspGetDemandNotePaymentList";
                //    //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //    //    cmd.Parameters.AddWithValue("@DemandNoteCode", TransactionalID);
                //    //    cmd.Parameters.AddWithValue("@UserId", SessionWrapper.UserId);
                //    //    cmd.Parameters.AddWithValue("@SpMode", "MakePayment_RollBack");
                //    //    cmd.Parameters.AddWithValue("@UserLoginId", SessionWrapper.UserLoginId);

                //    //    bool result = objCon.InsertData(cmd);
                //    //}
                //}

                TempData["AckMessage"] = "Payment cannot done.Please try again!";
                return RedirectToAction("NoticeLtrPenalty", "NoticeAndletter", new { Area = "DemandNote" });
                #endregion
            }
            else
            {
                TempData["AckMessage"] = "Payment cannot done.Please try again!";
                return RedirectToAction("NoticeLtrPenalty", "NoticeAndletter", new { Area = "DemandNote" });
            }
        }
    }
}
