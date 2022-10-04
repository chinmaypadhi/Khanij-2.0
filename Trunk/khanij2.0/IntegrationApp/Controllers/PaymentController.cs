using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using IntegrationApp.ActionFilter;
using IntegrationApp.Areas.Payment.Models.MineralConcession;
using IntegrationApp.Areas.Payment.Models.SBIPayment;
using IntegrationApp.Helper;
using IntegrationApp.Models.EncryptDecrypt;
using IntegrationApp.Models.MailService;
using IntegrationApp.Models.PaymentResponses;
using IntegrationApp.Models.SBIEncryptDecryptKey;
using IntegrationApp.Models.SMSService;
using IntegrationApp.Web;
using IntegrationEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace IntegrationApp.Controllers
{
    [Route("[controller]/[action]")]
    public class PaymentController : Controller
    {
        #region Variable Declaration

        EncryptDecrypts objencdec = new EncryptDecrypts();
        string strHEX, strPGActualReponseWithChecksum, strPGActualReponseEncrypted, strPGActualReponseDecrypted, strPGresponseChecksum, strPGTxnStatusCode;
        string PayableRoyalty, TCS, Cess, eCess, DMF, NMET, MonthlyPeriodicAmount, UpforntPayment, PayableRoyalty2, GIB_TXN_NO;
        //Mukesh RoyaltyWithAdditional150PerInclusion Added 22-Oct-2021
        //Begin
        string AdditionalAmount;
        //End
        string[] strPGChecksum, strPGTxnString;
        bool isDecryptable = false;

        string strPG_TxnStatus = string.Empty, strPG_TxnStatusDesc = string.Empty,
        strPG_ClintTxnRefNo = string.Empty,
                strPG_TPSLTxnBankCode = string.Empty, strPG_Paymode = string.Empty,
                strPG_TPSLTxnID = string.Empty,
                strPG_TxnAmount = string.Empty,
                strPG_TxnDateTime = string.Empty,
                strPG_TxnDate = string.Empty,
                strPG_TxnTime = string.Empty;



        string strPGResponse;
        string strPG_MerchantCode;
        string[] strSplitDecryptedResponse;
        string[] strArrPG_TxnDateTime;


        #endregion

        //Getting Payment Response here
        List<FinalPaymentModel> objList = new List<FinalPaymentModel>();
        private readonly IPaymentResponseModel paymentResponseModel;
        private readonly IsbiIncriptDecript isbiIncriptDecript;
        private readonly ISMSModel sMSModel;
        private readonly IMailModel mailModel;
        private readonly ISBIPaymentModel SBIpaymentmodel;
        private readonly IMineralConcessionModel _objIticketmodel;
        private readonly IConfiguration configuration;
        MessageEF messageEF = new MessageEF();
        PaymentTransaction response = new PaymentTransaction();
        public PaymentController(IPaymentResponseModel paymentResponseModel, IsbiIncriptDecript isbiIncriptDecript,
            ISMSModel sMSModel, IMailModel mailModel, ISBIPaymentModel SBIpaymentmodel, IMineralConcessionModel _objIticketmodel, IConfiguration configuration)
        {
            this.paymentResponseModel = paymentResponseModel;
            this.isbiIncriptDecript = isbiIncriptDecript;
            this.sMSModel = sMSModel;
            this.mailModel = mailModel;
            this.SBIpaymentmodel = SBIpaymentmodel;
            this._objIticketmodel = _objIticketmodel;
        }
        public IActionResult Index()
        {
            string strPaymentResponseID = string.Empty;
            string strDecryptedVal = string.Empty;
            //Decrypting the PG response
            string strIsKey = string.Empty;
            string strIsIv = string.Empty;
            string documentContents = null;
            string sessionUserName = string.Empty;
            var bnk = "NoBank";
            //Verify Response using Key and Iv 
            #region Insert Payment Response Received in request from the bank Site
            try
            {

                using (Stream receiveStream = HttpContext.Request.Body)
                {
                    using (StreamReader readStream = new StreamReader(receiveStream, System.Text.Encoding.UTF8))
                    {
                        documentContents = readStream.ReadToEnd();
                    }
                }


                if (!string.IsNullOrEmpty(documentContents) && documentContents.Contains("encdata"))
                {
                    bnk = "SBI";
                }

                //if (!string.IsNullOrEmpty(documentContents))
                //{
                //    messageEF = paymentResponseModel.GetPaymentResponseID(new PaymentResponseDetails() { SessionBank = bnk, DocContent = documentContents });
                //    strPaymentResponseID = messageEF.Satus;
                //}

            }
            catch { }
            #endregion
            ViewBag.documentContents = documentContents;
            ViewBag.bank = bnk;
            return View();
        }
        [SkipSession]
        public IActionResult PaymentResponse()
        {
            List<MCPaymentUserDetails> objuserdeatils = new List<MCPaymentUserDetails>();
            MCPaymentUserDetails loginuserdetailsInfo = new MCPaymentUserDetails();
            try
            {
                //UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);

                string strPaymentResponseID = string.Empty;
                string strDecryptedVal = string.Empty;
                //Decrypting the PG response
                string strIsKey = string.Empty;
                string strIsIv = string.Empty;
                string documentContents = null;
                string sessionUserName = string.Empty;
                //Verify Response using Key and Iv 
                #region Insert Payment Response Received in request from the bank Site
                try
                {

                    var bnk = "";

                    using (Stream receiveStream = HttpContext.Request.Body)
                    {
                        using (StreamReader readStream = new StreamReader(receiveStream, System.Text.Encoding.UTF8))
                        {
                            documentContents = readStream.ReadToEnd();
                        }
                    }


                    if (!string.IsNullOrEmpty(documentContents) && documentContents.Contains("encdata"))
                    {
                        bnk = "SBI";
                    }

                    if (!string.IsNullOrEmpty(documentContents))
                    {
                        messageEF = paymentResponseModel.GetPaymentResponseID(new PaymentResponseDetails() { SessionBank = bnk, DocContent = documentContents });
                        strPaymentResponseID = messageEF.Satus;
                    }

                }
                catch { }
                #endregion

                #region NEW SBI

                if ((documentContents != null || documentContents != ""))
                {
                    response.TPSL_BANK_CD = "SBI";
                    documentContents = HttpUtility.UrlDecode(documentContents.Replace("encdata=", string.Empty));
                    strDecryptedVal = isbiIncriptDecript.DecryptWithKey(documentContents);
                    strSplitDecryptedResponse = strDecryptedVal.Split('|');
                    SBINETGetPGRespnseData(strSplitDecryptedResponse);
                }

                #endregion

                #region Insert Response Details in DB for all banks


                if (strPG_TxnStatusDesc.ToUpper().Contains("COMPLETED") || strPG_TxnStatusDesc.ToUpper().Contains("PENDING") || strPG_TxnStatusDesc.ToUpper() == "SUCCESS" || strPG_TxnStatusDesc.ToUpper() == "AWAITED" || strPG_TxnStatusDesc.ToUpper() == "NEFT" || strPG_TxnStatusDesc.ToUpper() == "RECEIVED" || strPG_TxnStatusDesc.ToUpper() == "H" || strPG_TxnStatusDesc.ToUpper() == "P")
                {
                    response.TXN_STATUS = strPG_TxnStatusDesc.ToUpper(); //STATUS_DESC
                    response.CLNT_TXN_REF = strPG_ClintTxnRefNo; //REF_NO
                    response.PayMode = strPG_Paymode; // PAYMODE
                    response.TPSL_TXN_ID = strPG_TPSLTxnID; // ICICI_REF_NO
                    response.TXN_AMT = strPG_TxnAmount; // AMOUNT
                    response.TPSL_TXN_TIME = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");//Challan Date time
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
                    response.TPSL_TXN_TIME = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");//Challan Date time
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

                #endregion


                #region Insert Data

                if (strPG_TxnStatusDesc.ToUpper().Contains("PENDING") || strPG_TxnStatusDesc.ToUpper().Contains("NEFT") || strPG_TxnStatusDesc.ToUpper() == "P" || strPG_TxnStatusDesc.ToUpper() == "RECEIVED" || strPG_TxnStatusDesc.ToUpper() == "H")
                {
                    strPG_TxnStatusDesc = "PENDING";
                    response.TXN_STATUS = "PENDING";
                }
                if (strPG_TxnStatusDesc.ToUpper().Contains("COMPLETED"))
                {
                    strPG_TxnStatusDesc = "SUCCESS";
                    response.TXN_STATUS = "SUCCESS";
                }




                //PreferredBidder objmodel = new PreferredBidder();
                //try
                //{
                //    objTicket = new List<PreferredBidder>();
                //    objmodel.userid = Convert.ToInt16(profile.UserId);//Convert.ToInt16(ConfigurationManager.MySettings["MySettings:Userid"]);
                //    objTicket = _objIticketmodel.GetAuctionType(objmodel);

                //    if (objTicket.Count > 0)
                //    {
                //        ViewBag.AuctionList = new SelectList(objTicket, "Auctiontypeid

                UserLoginSession loginEF = new UserLoginSession();
                MCPaymentUserDetails loginuserdetails = new MCPaymentUserDetails();
                //string[] s= strSplitDecryptedResponse[2].Split("=");
                loginuserdetails.CLNT_TXN_REF = strPG_ClintTxnRefNo;
                loginuserdetails.Check = "1";
                List<MCPaymentUserDetails> objTicket = new List<MCPaymentUserDetails>();
                //var txn = strSplitDecryptedResponse[
                objTicket = SBIpaymentmodel.GetReLoginUser(loginuserdetails);
                foreach (var obj in objTicket)
                {
                    loginuserdetails.USR_NAME = obj.USR_NAME;
                    loginuserdetails.USR_PW = obj.USR_PW;
                }


                var remoteIp = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                //var localIp = Convert.ToString(Request.["LOCAL_ADDR"]);
                var localIp = Request.HttpContext.Connection.LocalIpAddress.ToString();
                var browserInfo = Request.Headers["User-Agent"].ToString();
                loginuserdetailsInfo.USR_NAME = loginuserdetails.USR_NAME;
                loginuserdetailsInfo.USR_PW = loginuserdetails.USR_PW;
                loginuserdetailsInfo.Check = "2";
                loginuserdetailsInfo.RemoteIp = remoteIp;
                loginuserdetailsInfo.LocalIp = localIp;
                loginuserdetailsInfo.UserAgent = browserInfo;



                objuserdeatils = SBIpaymentmodel.GetReLoginUserDetailsInfo(loginuserdetailsInfo);
                UserLoginSession profile = new UserLoginSession();
                foreach (var d in objuserdeatils)
                {

                    profile.UserId = d.UserId;
                    profile.UserName = d.UserName;
                    profile.UserLoginId = d.UserLoginId;
                    profile.ApplicantName = d.ApplicantName;
                    profile.Password = d.Password;
                    profile.UserType = d.UserType;
                    profile.SubUserID = d.SubUserID;
                    profile.RoleId = d.RoleId;
                }

                response.UserType = profile.UserType;
                response.UserId = profile.UserId;
                response.PaymentResponseID = strPaymentResponseID;
                messageEF = paymentResponseModel.AddPaymentResponse(response);
                #endregion

                #region------------------------------------------------------------------Data-----------------------------------



                if (response.TXN_STATUS == "SUCCESS" || response.TXN_STATUS == "AWAITED" || strPG_TxnStatusDesc.ToUpper().Contains("PENDING") || strPG_TxnStatusDesc == "NEFT" || strPG_TxnStatusDesc.ToUpper() == "RECEIVED" || strPG_TxnStatusDesc.ToUpper() == "H") // if transaction is success then only update record for bulkpermit and sent sms and email.
                {
                    if (response.CLNT_TXN_REF.StartsWith("VP"))
                    {
                        #region Vehicle Payments
                        string strBulkPermitID = response.CLNT_TXN_REF.Trim();
                        TransporterModel transporterModel = paymentResponseModel.AddVehiclePaymentResponse(
                            new PaymentResponseDetails()
                            {
                                PaymentVehicleID = strBulkPermitID,
                                UserId = profile.UserId,
                                TXN_STATUS = response.TXN_STATUS,
                                UserLoginId = profile.UserLoginId
                            });

                        if (strPG_TxnStatus == "SUCCESS" || strPG_TxnStatusDesc.ToUpper().Contains("COMPLETED"))//Success
                        {
                            #region Send SMS

                            try
                            {
                                string message = "Dear " + transporterModel.ApplicantName + Environment.NewLine + "Vehicles are successfully registered in Khanij Online System dated on " + System.DateTime.Now + ". Please login to Khanij Online portal for further. CHiMMS, GoCG";
                                string templateid = "1307161883599887989";
                                sMSModel.Main(new SMS() { mobileNo = transporterModel.MobileNo, message = message, templateid = templateid });
                            }
                            catch (Exception)
                            {
                            }
                            #endregion

                            #region Send Mail
                            try
                            {

                                mailModel.SendMail_AddVehiclesAck(new TransporterMail()
                                {
                                    EmailId = transporterModel.EmailID,
                                    TotalVehiclesPayment = transporterModel.TotalVehiclesPayment,
                                    VehicleCount = transporterModel.VehicleCount,
                                    TransporterName = transporterModel.ApplicantName
                                });
                            }
                            catch (Exception)
                            {
                                TempData["AckMessage"] = "0";
                                return RedirectToAction("Registration", "VehicleOwner", new { area = "VehicleOwner" });
                            }
                            #endregion
                        }
                        else if (response.TXN_STATUS == "AWAITED" || strPG_TxnStatusDesc.ToUpper().Contains("PENDING") || strPG_TxnStatusDesc == "NEFT")//Awaited
                        {
                            #region Send SMS
                            try
                            {
                                string message = "Dear " + transporterModel.ApplicantName + Environment.NewLine + "Your Vehicle Registration payment process has been completed & your payment status is awaited."
                                                    + Environment.NewLine +
                                                    "Your Transaction Reference Number is " + response.CLNT_TXN_REF + Environment.NewLine +
                                                    "Use this for Future reference. Please login to Khanij Online portal for further. CHiMMS, GoCG";
                                string templateid = "1307161883603544306";
                                sMSModel.Main(new SMS() { mobileNo = transporterModel.MobileNo, message = message, templateid = templateid });
                            }
                            catch (Exception)
                            {

                            }
                            #endregion

                            #region Send Mail
                            try
                            {
                                mailModel.SendPaymentAwaitedMail(new TransporterMail()
                                {
                                    EmailId = transporterModel.EmailID,
                                    CLNT_TXN_REF = response.CLNT_TXN_REF,
                                    TransporterName = transporterModel.ApplicantName
                                });
                            }
                            catch (Exception)
                            {
                                TempData["AckMessage"] = "0";
                                return RedirectToAction("Registration", "VehicleOwner", new { area = "VehicleOwner" });
                            }
                            #endregion
                        }


                        #endregion
                    }
                    else if (response.CLNT_TXN_REF.StartsWith("MAP"))
                    {
                        #region Daily Production payment
                        string strMAPTXNID = response.CLNT_TXN_REF.Trim();
                        string paymentStatus = response.TXN_STATUS;

                        //using (SqlCommand cmdupdate1 = new SqlCommand())
                        //{
                        //cmdupdate1.CommandText = "uspDailyProduction_Insertion";
                        //cmdupdate1.CommandType = System.Data.CommandType.StoredProcedure;

                        //cmdupdate1.Parameters.AddWithValue("@Check", "PaymentResponseCheck_Initiate");
                        //cmdupdate1.Parameters.AddWithValue("@MAPID", strMAPTXNID);
                        //cmdupdate1.Parameters.AddWithValue("@UserId", SessionWrapper.UserId);
                        //cmdupdate1.Parameters.AddWithValue("@ChallanNumber", response.TPSL_TXN_ID);
                        //cmdupdate1.Parameters.AddWithValue("@PaymentStatus", paymentStatus);


                        //using (DataTable dt = objDb.ExecuteStoreProcedure(cmdupdate1))
                        // {
                        //if (dt != null && dt.Rows.Count > 0)
                        // {
                        //UserMasterModel UModel = new UserMasterModel();

                        //UModel.EMailId = Convert.ToString(dt.Rows[0]["EmailID"]); 
                        //UModel.ApplicantName = Convert.ToString(dt.Rows[0]["ApplicantName"]);
                        //UModel.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                        //UModel.MobileNo = Convert.ToString(dt.Rows[0]["MobileNo"]);

                        if (strPG_TxnStatus == "SUCCESS" || strPG_TxnStatusDesc.ToUpper().Contains("COMPLETED"))//Success
                        {
                            #region Send SMS

                            try
                            {
                                //string message = "Dear " + SessionWrapper.ApplicantName + Environment.NewLine + "Your payment for daily production has been proceed successfully and your payment status is " + response.TXN_STATUS
                                //                     + Environment.NewLine +
                                //                     "Your Transaction Reference Number is " + response.CLNT_TXN_REF + Environment.NewLine +
                                //                     "Use this for Future reference. Please login to Khanij Online portal for further. CHiMMS, GoCG";


                                //string templateid = "1307161883661883402";
                                //SMSHttpPostClient.Main(UModel.MobileNo, message, templateid); 
                            }
                            catch (Exception)
                            {
                            }
                            #endregion

                            #region Send Mail
                            try
                            {
                                //MailService mail = new MailService();
                                //mail.SendNonPermitPaymentMail(SessionWrapper.UserLoginId.ToString(), UModel.EMailId,
                                //        DateTime.Now.ToString("dd/MM/yyyy"), SessionWrapper.UserId.ToString(),
                                //        UModel.ApplicantName,
                                //        "Daily Production payment status is " + response.TXN_STATUS + " ",
                                //        Convert.ToString(response.TXN_AMT));

                            }
                            catch (Exception)
                            {
                                TempData["AckMessage"] = "0";
                            }
                            #endregion
                        }
                        else if (response.TXN_STATUS == "AWAITED" || strPG_TxnStatusDesc.ToUpper().Contains("PENDING") || strPG_TxnStatusDesc == "NEFT")//Awaited
                        {
                            #region Send SMS
                            try
                            {

                                //string message = "Dear " + SessionWrapper.ApplicantName + Environment.NewLine + "Your payment for daily production has been proceed successfully and your payment status is " + response.TXN_STATUS
                                //                    + Environment.NewLine +
                                //                    "Your Transaction Reference Number is " + response.CLNT_TXN_REF + Environment.NewLine +
                                //                    "Use this for Future reference. Please login to Khanij Online portal for further. CHiMMS, GoCG";


                                //string templateid = "1307161883661883402";
                                //SMSHttpPostClient.Main(UModel.MobileNo, message, templateid); 
                            }
                            catch (Exception)
                            {

                            }
                            #endregion

                            #region Send Mail
                            try
                            {
                                // MailService mail = new MailService();
                                // mail.SendPaymentAwaitedMail(UModel, response.CLNT_TXN_REF);
                            }
                            catch (Exception)
                            {
                                TempData["AckMessage"] = "0";
                            }
                            #endregion
                        }
                        // }
                        // }
                        //}
                        #endregion
                    }
                    else if (response.CLNT_TXN_REF.StartsWith("FLIC"))
                    {
                        #region Licensee Application First payment
                        string strLICTXNID = response.CLNT_TXN_REF.Trim();
                        string paymentStatus = response.TXN_STATUS;
                        UserMasterModel userMasterModel = paymentResponseModel.AddLicenseFirstPayment(
                            new PaymentResponseDetails()
                            {
                                PaymentRecieptId = strLICTXNID,
                                UserId = profile.UserId,
                                ChallanNumber = response.TPSL_TXN_ID,
                                PaymentStatus = paymentStatus
                            });


                        if (strPG_TxnStatus == "SUCCESS" || strPG_TxnStatusDesc.ToUpper().Contains("COMPLETED"))//Success
                        {
                            #region Send SMS

                            try
                            {
                                string message = "Dear " + userMasterModel.ApplicantName + Environment.NewLine + "Your payment has been proceed successfully and your payment status is " + response.TXN_STATUS
                                                     + Environment.NewLine +
                                                     "Your Transaction Reference Number is " + response.CLNT_TXN_REF + Environment.NewLine +
                                                     "Use this for Future reference. Please login to Khanij Online portal for further. CHiMMS, GoCG";


                                string templateid = "1307161883628029116";
                                sMSModel.Main(new SMS() { mobileNo = userMasterModel.MobileNo, message = message, templateid = templateid });
                            }
                            catch (Exception)
                            {
                            }
                            #endregion

                            #region Send Mail
                            try
                            {
                                mailModel.SendNonPermitPaymentMail(new LicensePaymentMail()
                                {
                                    PaymentReceiptID = profile.UserLoginId.ToString(),
                                    EmailID = userMasterModel.EMailId,
                                    ForwardDate = DateTime.Now.ToString("dd/MM/yyyy"),
                                    TransactionId = profile.UserId.ToString(),
                                    ApplicantName = userMasterModel.ApplicantName,
                                    PaymentType = "payment status is " + response.TXN_STATUS + " ",
                                    PayableAmount = Convert.ToString(response.TXN_AMT)
                                });

                            }
                            catch (Exception)
                            {
                                TempData["AckMessage"] = "0";
                            }
                            #endregion
                        }
                        else if (response.TXN_STATUS == "AWAITED" || strPG_TxnStatusDesc.ToUpper().Contains("PENDING") || strPG_TxnStatusDesc == "NEFT")//Awaited
                        {
                            #region Send SMS
                            try
                            {

                                string message = "Dear " + userMasterModel.ApplicantName + Environment.NewLine + "Your payment has been proceed successfully and your payment status is " + response.TXN_STATUS
                                                    + Environment.NewLine +
                                                    "Your Transaction Reference Number is " + response.CLNT_TXN_REF + Environment.NewLine +
                                                    "Use this for Future reference. Please login to Khanij Online portal for further. CHiMMS, GoCG";


                                string templateid = "1307161883628029116";
                                sMSModel.Main(new SMS() { mobileNo = userMasterModel.MobileNo, message = message, templateid = templateid });
                            }
                            catch (Exception)
                            {

                            }
                            #endregion

                            #region Send Mail
                            try
                            {
                                mailModel.SendPaymentAwaitedMail(new TransporterMail()
                                {
                                    EmailId = userMasterModel.EMailId,
                                    CLNT_TXN_REF = response.CLNT_TXN_REF,
                                    TransporterName = userMasterModel.ApplicantName
                                });
                            }
                            catch (Exception)
                            {
                                TempData["AckMessage"] = "0";
                            }
                            #endregion
                        }

                        #endregion
                    }
                    else if (response.CLNT_TXN_REF.StartsWith("SEQL"))
                    {
                        #region Licensee Application Security payment
                        string strLICTXNID = response.CLNT_TXN_REF.Trim();
                        string paymentStatus = response.TXN_STATUS;
                        UserMasterModel userMasterModel = paymentResponseModel.AddLicenseFirstPayment(
                           new PaymentResponseDetails()
                           {
                               PaymentRecieptId = strLICTXNID,
                               UserId = profile.UserId,
                               ChallanNumber = response.TPSL_TXN_ID,
                               PaymentStatus = paymentStatus
                           });



                        if (strPG_TxnStatus == "SUCCESS" || strPG_TxnStatusDesc.ToUpper().Contains("COMPLETED"))//Success
                        {
                            #region Send SMS

                            try
                            {
                                string message = "Dear " + userMasterModel.ApplicantName + Environment.NewLine + "Your payment has been proceed successfully and your payment status is " + response.TXN_STATUS
                                                     + Environment.NewLine +
                                                     "Your Transaction Reference Number is " + response.CLNT_TXN_REF + Environment.NewLine +
                                                     "Use this for Future reference. Please login to Khanij Online portal for further. CHiMMS, GoCG";


                                string templateid = "1307161883628029116";
                                sMSModel.Main(new SMS() { mobileNo = userMasterModel.MobileNo, message = message, templateid = templateid });
                            }
                            catch (Exception)
                            {
                            }
                            #endregion

                            #region Send Mail
                            try
                            {
                                mailModel.SendNonPermitPaymentMail(new LicensePaymentMail()
                                {
                                    PaymentReceiptID = profile.UserLoginId.ToString(),
                                    EmailID = userMasterModel.EMailId,
                                    ForwardDate = DateTime.Now.ToString("dd/MM/yyyy"),
                                    TransactionId = profile.UserId.ToString(),
                                    ApplicantName = userMasterModel.ApplicantName,
                                    PaymentType = "payment status is " + response.TXN_STATUS + " ",
                                    PayableAmount = Convert.ToString(response.TXN_AMT)
                                });
                            }
                            catch (Exception)
                            {
                                TempData["AckMessage"] = "0";
                            }
                            #endregion
                        }
                        else if (response.TXN_STATUS == "AWAITED" || strPG_TxnStatusDesc.ToUpper().Contains("PENDING") || strPG_TxnStatusDesc == "NEFT")//Awaited
                        {
                            #region Send SMS
                            try
                            {

                                string message = "Dear " + userMasterModel.ApplicantName + Environment.NewLine + "Your payment has been proceed successfully and your payment status is " + response.TXN_STATUS
                                                    + Environment.NewLine +
                                                    "Your Transaction Reference Number is " + response.CLNT_TXN_REF + Environment.NewLine +
                                                    "Use this for Future reference. Please login to Khanij Online portal for further. CHiMMS, GoCG";


                                string templateid = "1307161883628029116";
                                sMSModel.Main(new SMS() { mobileNo = userMasterModel.MobileNo, message = message, templateid = templateid });
                            }
                            catch (Exception)
                            {

                            }
                            #endregion

                            #region Send Mail
                            try
                            {
                                mailModel.SendPaymentAwaitedMail(new TransporterMail()
                                {
                                    EmailId = userMasterModel.EMailId,
                                    CLNT_TXN_REF = response.CLNT_TXN_REF,
                                    TransporterName = userMasterModel.ApplicantName
                                });
                            }
                            catch (Exception)
                            {
                                TempData["AckMessage"] = "0";
                            }
                            #endregion
                        }

                        #endregion
                    }
                    else if (response.CLNT_TXN_REF.StartsWith("FLOI")) // Added By Prakash Sahoo
                    {
                        LeaseApplicationModel model = new LeaseApplicationModel();
                        model.UserId = profile.UserId;
                        model.SpMode = "FirstInstallment";
                        model.PaymentStatus = response.TXN_STATUS.ToUpper();
                        MessageEF objMessage = new MessageEF();
                        objMessage = _objIticketmodel.AddPayment(model);
                        objMessage.Satus = "1";
                        if (objMessage.Satus == "1" && model.SpMode == "FirstInstallment")
                        {
                            TempData["LOIAckMessage"] = "First Installment Done successfully.";
                            //return RedirectToAction("PreferredBidderRequest", "LeaseApplication");

                        }
                    }
                    else if (response.CLNT_TXN_REF.StartsWith("SLOI")) // Added By Prakash Sahoo on 29-06-2022
                    {
                        #region-----------------------SecondLOI Payment----------------
                        LeaseApplicationModel model = new LeaseApplicationModel();
                        model.UserId = profile.UserId;
                        model.SpMode = "UpdateStatus_Second_Installment";
                        model.PaymentStatus = response.TXN_STATUS.ToUpper();
                        MessageEF objMessage = new MessageEF();
                        objMessage = _objIticketmodel.AddPayment(model);
                        objMessage.Satus = "1";

                        if (objMessage.Satus == "1" && model.SpMode == "UpdateStatus_Second_Installment")
                        {
                            response.UserType = "SecondpayLoI";
                            TempData["LOIAckMessage"] = "Second Installment Done successfully.";
                        }
                        //#region second LOI Payment
                        //// string strLOITXNID = response.CLNT_TXN_REF.Replace("LOI_", "").Trim();
                        //string paymentStatus = response.TXN_STATUS;

                        //using (SqlCommand cmdupdate1 = new SqlCommand())
                        //{
                        //    cmdupdate1.CommandText = "uspSubmissionOfStatutoryClearance";
                        //    cmdupdate1.CommandType = System.Data.CommandType.StoredProcedure;

                        //    cmdupdate1.Parameters.AddWithValue("@SubmissionId", response.CLNT_TXN_REF);
                        //    cmdupdate1.Parameters.AddWithValue("@UserId", SessionWrapper.UserId);
                        //    cmdupdate1.Parameters.AddWithValue("@TransactionalID", response.TPSL_TXN_ID);
                        //    cmdupdate1.Parameters.AddWithValue("@UserLoginId", SessionWrapper.UserLoginId);
                        //    cmdupdate1.Parameters.AddWithValue("@PaymentStatus", paymentStatus);
                        //    cmdupdate1.Parameters.AddWithValue("@SpMode", "UpdateStatus_Second_Installment");

                        //    using (DataTable dt = objDb.ExecuteStoreProcedure(cmdupdate1))
                        //    {
                        //        if (dt != null && dt.Rows.Count > 0)
                        //        {
                        //            UserMasterModel UModel = new UserMasterModel();

                        //            UModel.EMailId = Convert.ToString(dt.Rows[0]["EmailID"]);
                        //            //UModel.TotalVehiclesPayment = Convert.ToString(dt.Rows[0]["TotalPaidAmount"]);
                        //            //UModel.VehicleCount = Convert.ToInt32(dt.Rows[0]["TotalDemandNoteCount"]);
                        //            UModel.ApplicantName = Convert.ToString(dt.Rows[0]["ApplicantName"]);
                        //            UModel.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                        //            UModel.MobileNo = Convert.ToString(dt.Rows[0]["MobileNo"]);
                        //            UModel.Password = Convert.ToString(dt.Rows[0]["Password"]);
                        //            UModel.UserId = Convert.ToInt32(dt.Rows[0]["userId"]);
                        //            UModel.UserCode = Convert.ToString(dt.Rows[0]["UserName"]);

                        //            if (strPG_TxnStatus == "SUCCESS" || strPG_TxnStatusDesc.ToUpper().Contains("COMPLETED"))//Success
                        //            {
                        //                #region Send SMS

                        //                try
                        //                {
                        //                    string message = "Dear " + SessionWrapper.ApplicantName + Environment.NewLine + "Your payment for LOI has been credited successfully and your payment status is " + response.TXN_STATUS + " in Khanij Online System dated on " + System.DateTime.Now + " Please check your e-mail for details for Payment. CHiMMS, GoCG";

                        //                    //Modified by Avneesh on 12-04-2021
                        //                    string templateid = "1307161883621479838";
                        //                    SMSHttpPostClient.Main(UModel.MobileNo, message, templateid);


                        //                    //SMSHttpPostClient.Main(UModel.MobileNo, message);
                        //                }
                        //                catch (Exception)
                        //                {
                        //                }
                        //                #endregion

                        //                #region Send Mail
                        //                try
                        //                {
                        //                    MailService mail = new MailService();
                        //                    mail.SendNonPermitPaymentMail(SessionWrapper.UserLoginId.ToString(), UModel.EMailId,
                        //                            DateTime.Now.ToString("dd/MM/yyyy"), SessionWrapper.UserId.ToString(),
                        //                            UModel.ApplicantName,
                        //                            "LOI and your payment status is " + response.TXN_STATUS + " ",
                        //                            Convert.ToString(response.TXN_AMT));

                        //                }
                        //                catch (Exception)
                        //                {
                        //                    TempData["AckMessage"] = "0";
                        //                }
                        //                #endregion
                        //            }
                        //            else if (response.TXN_STATUS == "AWAITED" || strPG_TxnStatusDesc.ToUpper().Contains("PENDING") || strPG_TxnStatusDesc == "NEFT")//Awaited
                        //            {
                        //                #region Send SMS
                        //                try
                        //                {
                        //                    //string message = "Dear " + SessionWrapper.ApplicantName + Environment.NewLine + "Your payment for LOI has been credited successfully and your payment status is " + response.TXN_STATUS + " in Khanij Online System dated on " + System.DateTime.Now + " Please check your e-mail for details for Payment.";
                        //                    string message = "Dear " + SessionWrapper.ApplicantName + Environment.NewLine + "Your payment for LOI has been credited successfully and your payment status is " + response.TXN_STATUS
                        //                                        + Environment.NewLine +
                        //                                        "Your Transaction Reference Number is " + response.CLNT_TXN_REF + Environment.NewLine +
                        //                                        "Use this for Future reference. Please login to Khanij Online portal for further. CHiMMS, GoCG";

                        //                    //Modified by Avneesh on 12-04-2021
                        //                    string templateid = "1307161883650652355";
                        //                    SMSHttpPostClient.Main(UModel.MobileNo, message, templateid);


                        //                    //SMSHttpPostClient.Main(UModel.MobileNo, message);

                        //                }
                        //                catch (Exception)
                        //                {

                        //                }
                        //                #endregion

                        //                #region Send Mail
                        //                try
                        //                {
                        //                    MailService mail = new MailService();
                        //                    mail.SendPaymentAwaitedMail(UModel, response.CLNT_TXN_REF);
                        //                }
                        //                catch (Exception)
                        //                {
                        //                    TempData["AckMessage"] = "0";
                        //                }
                        //                #endregion
                        //            }
                        //        }
                        //    }
                        //}
                        //#endregion
                        #endregion--------------------------------------------------
                    }
                    else if (response.CLNT_TXN_REF.StartsWith("TLOI")) // Added By Prakash Sahoo on 14-07-2022
                    {
                        #region-----------------------SecondLOI Payment----------------
                        LeaseApplicationModel model = new LeaseApplicationModel();
                        model.UserId = profile.UserId;
                        model.SpMode = "ThirdInstallment";
                        model.PaymentStatus = response.TXN_STATUS.ToUpper();
                        MessageEF objMessage = new MessageEF();
                        objMessage = _objIticketmodel.AddPayment(model);
                        objMessage.Satus = "1";

                        if (objMessage.Satus == "1" && model.SpMode == "ThirdInstallment")
                        {
                            response.UserType = "ThirdLoI";
                            TempData["LOIAckMessage"] = "Third Installment Done successfully.";
                        }
                       
                       #endregion--------------------------------------------------
                    }
                    else if (response.CLNT_TXN_REF.StartsWith("ORD"))
                    {
                        #region e-Permit Payment
                        PaymentEF objmodel = new PaymentEF();
                        PaymentEF objmodel2 = new PaymentEF();
                        if (response.CLNT_TXN_REF.StartsWith("ORDMIN"))
                        {
                            objmodel.BulkPermitId = response.CLNT_TXN_REF.Replace("ORDMIN", "").Trim();
                        }
                        if (response.CLNT_TXN_REF.StartsWith("ORDINC"))
                        {
                            objmodel.BulkPermitId = response.CLNT_TXN_REF.Replace("ORDINC", "").Trim();
                        }
                        if (response.CLNT_TXN_REF.StartsWith("ORDEVS"))
                        {
                            objmodel.BulkPermitId = response.CLNT_TXN_REF.Replace("ORDEVS", "").Trim();
                        }
                        if (!string.IsNullOrEmpty(objmodel.BulkPermitId))
                        {
                            objmodel.OrderNo = response.CLNT_TXN_REF;
                            objmodel.Txn_Status = strPG_Paymode.Contains("NEFT") == true ? "OFFLINE" : response.TXN_STATUS;
                            objmodel.UserId = profile.UserId;
                            objmodel.Challan_Number = strPG_TPSLTxnID;
                            objmodel.Challan_Initiate_Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                            Object objReturnData1 = paymentResponseModel.AddSBIDetails(objmodel);
                            if (objReturnData1 != null && !string.IsNullOrEmpty(Convert.ToString(objReturnData1)))
                            {
                                #region Sent Mail & MSG
                                objmodel2.BulkPermitId = objmodel.BulkPermitId;
                                objmodel2.UserId = profile.UserId;
                                objmodel2 = paymentResponseModel.SBIDetails(objmodel2);
                                objmodel2.TotalPayableAmount = Convert.ToDecimal(response.TXN_AMT);
                                #endregion
                            }
                            if (objReturnData1 != null && !string.IsNullOrEmpty(Convert.ToString(objReturnData1)))
                            {
                                if (objmodel.Txn_Status == "OFFLINE")
                                {
                                    string msg = "Your have successfully Generate eChallan for your e-Permit No.: " + objmodel2.BulkPermitNo + Environment.NewLine + " Dated " + System.DateTime.Now + Environment.NewLine +
                                                    "Quantity : " + objmodel2.ApprovedQty + " " + objmodel2.UnitName + "" + Environment.NewLine +
                                                    "Total Paid Amount : Rs " + objmodel2.TotalPayableAmount + "/-" + Environment.NewLine +
                                                    "Mineral Name : " + objmodel2.CardID + "" + Environment.NewLine +
                                                    "Mineral Form : " + objmodel2.IsIv + "" + Environment.NewLine +
                                                    "Mineral Grade : " + objmodel2.IsKey + "" + Environment.NewLine +
                                                    "Requesting to you please fill amount to the bank for further process of ePermit. CHiMMS, GoCG";
                                    //Modified by Avneesh on 12-04-2021
                                    string templateid = "1307161883584178590";
                                    sMSModel.Main(new SMS() { mobileNo = objmodel2.MobileNo, message = msg, templateid = templateid });
                                    //SMSHttpPostClient.Main(mobile, msg);
                                }
                                else
                                {
                                    try
                                    {
                                        if (!string.IsNullOrEmpty(objmodel2.EMailId))
                                        {
                                            mailModel.SendPermitPaymentAck(new PaymentEF()
                                            {
                                                BulkPermitNo= objmodel2.BulkPermitNo,
                                                ApprovedQty= objmodel2.ApprovedQty,
                                                TotalPayableAmount= objmodel2.TotalPayableAmount,
                                                CardID = objmodel2.CardID,
                                                IsKey= objmodel2.IsKey,
                                                IsIv= objmodel2.IsIv,
                                                Txn_Status= objmodel.Txn_Status,
                                                TransactionalId = objmodel2.TransactionalId,
                                                ApplicantName = objmodel2.ApplicantName,
                                                UTR_Number = profile.UserName,
                                                UserId=profile.UserId,
                                                EMailId= objmodel2.EMailId

                                            });
                                        }
                                        if (!string.IsNullOrEmpty(objmodel2.MobileNo))
                                        {
                                            if (response.TXN_STATUS == "AWAITED" || response.TXN_STATUS == "PENDING")
                                            {
                                                string msg = "Your payment have been initiate successfully and your payment status is awaited.Your Transaction No. is: " + objmodel2.TransactionalId + Environment.NewLine + " Dated " + System.DateTime.Now + Environment.NewLine +
                                                    "Quantity : " + objmodel2.ApprovedQty + " " + objmodel2.PropertyPath + "" + Environment.NewLine +
                                                    "Total Paid Amount : Rs " + objmodel2.TotalPayableAmount + "/-" + Environment.NewLine +
                                                    "Mineral Name : " + objmodel2.CardID + "" + Environment.NewLine +
                                                    "Mineral Form : " + objmodel2.IsIv + "" + Environment.NewLine +
                                                    "Mineral Grade : " + objmodel2.IsKey + ". CHiMMS, GoCG";
                                                //Modified by Avneesh on 12-04-2021
                                                string templateid = "1307161883587991005";
                                                sMSModel.Main(new SMS() { mobileNo = objmodel2.MobileNo, message = msg, templateid = templateid });
                                                //SMSHttpPostClient.Main(mobile, msg);
                                            }
                                            else
                                            {
                                                string msg = "Your payment has been credited successfully and Your e-Permit No. is: " + objmodel2.BulkPermitNo + Environment.NewLine + " Dated " + System.DateTime.Now + Environment.NewLine +
                                                    "Quantity : " + objmodel2.ApprovedQty + " " + objmodel2.PropertyPath + "" + Environment.NewLine +
                                                    "Total Paid Amount : Rs " + objmodel2.TotalPayableAmount + "/-" + Environment.NewLine +
                                                    "Mineral Name : " + objmodel2.CardID + "" + Environment.NewLine +
                                                    "Mineral Form : " + objmodel2.IsIv + "" + Environment.NewLine +
                                                    "Mineral Grade : " + objmodel2.IsKey + ". CHiMMS, GoCG";
                                                //Modified by Avneesh on 12-04-2021
                                                string templateid = "1307161883464434423";
                                                sMSModel.Main(new SMS() { mobileNo = objmodel2.MobileNo, message = msg, templateid = templateid });
                                                //SMSHttpPostClient.Main(mobile, msg);
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                    }
                                    if (objmodel2 != null)
                                    {
                                        ViewBag.PaymentSuccess = objmodel2;
                                    }
                                }
                            }
                        }
                        #endregion
                    } //Added by Priyabrat Das
                }

                #endregion

                ViewBag.PaymentDetails = objList;
                return View(response);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            ViewBag.PaymentDetails = objList;
            return View();
        }

        #region SBI Bifurcation
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
        #endregion


        #region----------------ICIC Bank Response Code------------------------------
        [SkipSession]
        public ActionResult PaymentResponseICICI()
        {
            try
            {
                List<MCPaymentUserDetails> objuserdeatils = new List<MCPaymentUserDetails>();
                MCPaymentUserDetails loginuserdetailsInfo = new MCPaymentUserDetails();
                PaymentTransaction response = new PaymentTransaction();
                string strPaymentResponseID = string.Empty;
                string strDecryptedVal = string.Empty;
                //Decrypting the PG response
                string strIsKey = string.Empty;
                string strIsIv = string.Empty;
                string documentContents = null;
                string sessionUserName = string.Empty;
                //Verify Response using Key and Iv

                #region Insert Payment Response Received in request from the bank Site
                try
                {

                    var bnk = "";
                    using (Stream receiveStream = HttpContext.Request.Body)
                    {
                        using (StreamReader readStream = new StreamReader(receiveStream, System.Text.Encoding.UTF8))
                        {
                            documentContents = readStream.ReadToEnd();
                        }
                    }



                    if (!string.IsNullOrEmpty(documentContents) && documentContents.Contains("encdata"))
                    {
                        bnk = "ICIC";
                    }

                    if (!string.IsNullOrEmpty(documentContents))
                    {
                        messageEF = paymentResponseModel.GetPaymentResponseID(new PaymentResponseDetails() { SessionBank = bnk, DocContent = documentContents });
                        strPaymentResponseID = messageEF.Satus;
                    }
                }
                catch { }
                #endregion

                #region NEW ICICI

                response.TPSL_BANK_CD = "ICICI";

                if (!string.IsNullOrEmpty(documentContents) && documentContents.Contains("encdata")) //// For Online Net Banking
                {

                    strDecryptedVal = objencdec.DecryptAES(HttpUtility.UrlDecode(documentContents.Replace("encdata=", "")));

                    strSplitDecryptedResponse = strDecryptedVal.Split('|');

                    ICICINETGetPGRespnseData(strSplitDecryptedResponse);
                }
                else  // For NEFT / RTGS
                {
                    strIsKey = Convert.ToString(configuration.GetSection("Path").GetSection("NEFTICICIKey").Value);
                    strIsIv = Convert.ToString(configuration.GetSection("Path").GetSection("NEFTICICIIV").Value);

                    strDecryptedVal = objencdec.DecryptAES(HttpUtility.UrlDecode(documentContents.Replace("encdata=", "")));

                    strSplitDecryptedResponse = strDecryptedVal.Split('|');
                    ICICIGetPGRespnseData(strSplitDecryptedResponse);
                    strPG_TxnStatusDesc = strPG_TxnStatusDesc == "P" ? "NEFT" : strPG_TxnStatusDesc;
                }


                #endregion



                #region Insert Response Details in DB for all banks


                if (strPG_TxnStatusDesc.ToUpper().Contains("COMPLETED") || strPG_TxnStatusDesc.ToUpper().Contains("PENDING") || strPG_TxnStatusDesc.ToUpper() == "SUCCESS" || strPG_TxnStatusDesc.ToUpper() == "AWAITED" || strPG_TxnStatusDesc.ToUpper() == "NEFT" || strPG_TxnStatusDesc.ToUpper() == "P" || strPG_TxnStatusDesc.ToUpper() == "RECEIVED" || strPG_TxnStatusDesc.ToUpper() == "H")
                {
                    response.TXN_STATUS = strPG_TxnStatusDesc.ToUpper(); //STATUS_DESC
                    response.CLNT_TXN_REF = strPG_ClintTxnRefNo; //REF_NO
                    response.PayMode = strPG_Paymode; // PAYMODE
                    response.TPSL_TXN_ID = strPG_TPSLTxnID; // ICICI_REF_NO
                    response.TXN_AMT = strPG_TxnAmount; // AMOUNT
                    response.TPSL_TXN_TIME = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");//Challan Date time
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
                    response.TPSL_TXN_TIME = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");//Challan Date time
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

                #endregion

                #region Payment Data Updated on specific request

                if (strPG_TxnStatusDesc.ToUpper().Contains("PENDING") || strPG_TxnStatusDesc.ToUpper().Contains("NEFT") || strPG_TxnStatusDesc.ToUpper() == "P" || strPG_TxnStatusDesc.ToUpper() == "RECEIVED" || strPG_TxnStatusDesc.ToUpper() == "H")
                {
                    strPG_TxnStatusDesc = "PENDING";
                    response.TXN_STATUS = "PENDING";
                }
                if (strPG_TxnStatusDesc.ToUpper().Contains("COMPLETED"))
                {
                    strPG_TxnStatusDesc = "SUCCESS";
                    response.TXN_STATUS = "SUCCESS";
                }



                UserLoginSession loginEF = new UserLoginSession();
                MCPaymentUserDetails loginuserdetails = new MCPaymentUserDetails();
                //string[] s= strSplitDecryptedResponse[2].Split("=");
                loginuserdetails.CLNT_TXN_REF = strPG_ClintTxnRefNo;
                loginuserdetails.Check = "1";
                List<MCPaymentUserDetails> objTicket = new List<MCPaymentUserDetails>();
                //var txn = strSplitDecryptedResponse[
                objTicket = SBIpaymentmodel.GetReLoginUser(loginuserdetails);
                foreach (var obj in objTicket)
                {
                    loginuserdetails.USR_NAME = obj.USR_NAME;
                    loginuserdetails.USR_PW = obj.USR_PW;
                }


                var remoteIp = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                //var localIp = Convert.ToString(Request.["LOCAL_ADDR"]);
                var localIp = Request.HttpContext.Connection.LocalIpAddress.ToString();
                var browserInfo = Request.Headers["User-Agent"].ToString();
                loginuserdetailsInfo.USR_NAME = loginuserdetails.USR_NAME;
                loginuserdetailsInfo.USR_PW = loginuserdetails.USR_PW;
                loginuserdetailsInfo.Check = "2";
                loginuserdetailsInfo.RemoteIp = remoteIp;
                loginuserdetailsInfo.LocalIp = localIp;
                loginuserdetailsInfo.UserAgent = browserInfo;



                objuserdeatils = SBIpaymentmodel.GetReLoginUserDetailsInfo(loginuserdetailsInfo);
                UserLoginSession profile = new UserLoginSession();
                foreach (var d in objuserdeatils)
                {

                    profile.UserId = d.UserId;
                    profile.UserName = d.UserName;
                    profile.UserLoginId = d.UserLoginId;
                    profile.ApplicantName = d.ApplicantName;
                    profile.Password = d.Password;
                    profile.UserType = d.UserType;
                    profile.SubUserID = d.SubUserID;
                    profile.RoleId = d.RoleId;
                }

                response.UserType = profile.UserType;
                response.UserId = profile.UserId;
                response.PaymentResponseID = strPaymentResponseID;
                messageEF = paymentResponseModel.AddPaymentResponse(response);
                var sts = strPG_TxnStatus;

                if (response.TXN_STATUS == "SUCCESS" || response.TXN_STATUS == "AWAITED" || strPG_TxnStatusDesc.ToUpper().Contains("PENDING") || strPG_TxnStatusDesc == "NEFT" || strPG_TxnStatusDesc.ToUpper() == "RECEIVED" || strPG_TxnStatusDesc.ToUpper() == "H") // if transaction is success then only update record for bulkpermit and sent sms and email.
                {
                    if (response.CLNT_TXN_REF.StartsWith("FLOI"))
                    {
                        #region First LOI Payment
                        // string strLOITXNID = response.CLNT_TXN_REF.Replace("LOI_", "").Trim();
                        string paymentStatus = response.TXN_STATUS;
                        LeaseApplicationModel model = new LeaseApplicationModel();
                        model.UserId = profile.UserId;
                        model.SpMode = "FirstInstallment";
                        MessageEF objMessage = new MessageEF();
                        objMessage = _objIticketmodel.AddPayment(model);
                        objMessage.Satus = "1";
                        if (objMessage.Satus == "1" && model.SpMode == "FirstInstallment")
                        {
                            TempData["LOIAckMessage"] = "First Installment Done successfully.";
                            //return RedirectToAction("PreferredBidderRequest", "LeaseApplication");

                        }

                        if (strPG_TxnStatus == "SUCCESS" || strPG_TxnStatusDesc.ToUpper().Contains("COMPLETED"))//Success
                        {
                            #region Send SMS

                            //try
                            //{
                            //    string message = "Dear " + SessionWrapper.ApplicantName + Environment.NewLine + "Your payment for LOI has been credited successfully and your payment status is " + response.TXN_STATUS + " in Khanij Online System dated on " + System.DateTime.Now + " Please check your e-mail for details for Payment. CHiMMS, GoCG";
                            //    //Modified by Avneesh on 12-04-2021
                            //    string templateid = "1307161883654049519";
                            //    SMSHttpPostClient.Main(UModel.MobileNo, message, templateid);


                            //    //SMSHttpPostClient.Main(UModel.MobileNo, message);

                            //}
                            //catch (Exception)
                            //{
                            //}
                            #endregion

                            #region Send Mail
                            //try
                            //{
                            //    MailService mail = new MailService();
                            //    mail.SendNonPermitPaymentMail(SessionWrapper.UserLoginId.ToString(), UModel.EMailId,
                            //            DateTime.Now.ToString("dd/MM/yyyy"), SessionWrapper.UserId.ToString(),
                            //            UModel.ApplicantName,
                            //            "LOI and your payment status is " + response.TXN_STATUS + " ",
                            //            Convert.ToString(response.TXN_AMT));

                            //}
                            //catch (Exception)
                            //{
                            //    TempData["AckMessage"] = "0";
                            //}
                            #endregion
                        }
                        else if (response.TXN_STATUS == "AWAITED" || strPG_TxnStatusDesc.ToUpper().Contains("PENDING") || strPG_TxnStatusDesc == "NEFT")//Awaited
                        {
                            #region Send SMS
                            //try
                            //{

                            //    string message = "Dear " + response.ApplicantName + Environment.NewLine + "Your payment for LOI has been credited successfully and your payment status is " + response.TXN_STATUS
                            //                        + Environment.NewLine +
                            //                        "Your Transaction Reference Number is " + response.CLNT_TXN_REF + Environment.NewLine +
                            //                        "Use this for Future reference. Please login to Khanij Online portal for further. CHiMMS, GoCG";

                            //    //Modified by Avneesh on 12-04-2021
                            //    string templateid = "1307161883650652355";
                            //    SMSHttpPostClient.Main(UModel.MobileNo, message, templateid);


                            //    //SMSHttpPostClient.Main(UModel.MobileNo, message);

                            //}
                            //catch (Exception)
                            //{

                            //}
                            #endregion

                            #region Send Mail
                            //try
                            //{
                            //    MailService mail = new MailService();
                            //    mail.SendPaymentAwaitedMail(UModel, response.CLNT_TXN_REF);
                            //}
                            //catch (Exception)
                            //{
                            //    TempData["AckMessage"] = "0";
                            //}
                            #endregion
                        }
                        // }

                        //  }
                        #endregion
                    }

                    else if (response.CLNT_TXN_REF.StartsWith("SLOI")) // Added By Prakash Sahoo on 29-06-2022
                    {
                        #region-----------------------SecondLOI Payment----------------
                        LeaseApplicationModel model = new LeaseApplicationModel();
                        model.UserId = profile.UserId;
                        model.SpMode = "UpdateStatus_Second_Installment";
                        model.PaymentStatus = response.TXN_STATUS.ToUpper();
                        MessageEF objMessage = new MessageEF();
                        objMessage = _objIticketmodel.AddPayment(model);
                        objMessage.Satus = "1";

                        if (objMessage.Satus == "1" && model.SpMode == "UpdateStatus_Second_Installment")
                        {
                            response.UserType = "SecondpayLoI";
                            TempData["LOIAckMessage"] = "Second Installment Done successfully.";
                        }
                        #endregion--------------------------------------------------
                    }
                    else if (response.CLNT_TXN_REF.StartsWith("TLOI")) // Added By Prakash Sahoo on 14-07-2022
                    {
                        #region-----------------------SecondLOI Payment----------------
                        LeaseApplicationModel model = new LeaseApplicationModel();
                        model.UserId = profile.UserId;
                        model.SpMode = "ThirdInstallment";
                        model.PaymentStatus = response.TXN_STATUS.ToUpper();
                        MessageEF objMessage = new MessageEF();
                        objMessage = _objIticketmodel.AddPayment(model);
                        objMessage.Satus = "1";

                        if (objMessage.Satus == "1" && model.SpMode == "ThirdInstallment")
                        {
                            response.UserType = "ThirdLoI";
                            TempData["LOIAckMessage"] = "Third Installment Done successfully.";
                        }

                        #endregion--------------------------------------------------
                    }

                    else if (response.CLNT_TXN_REF.StartsWith("ORD"))
                    {
                        #region e-Permit Payment
                        PaymentEF objmodel = new PaymentEF();
                        PaymentEF objmodel2 = new PaymentEF();
                        if (response.CLNT_TXN_REF.StartsWith("ORDMIN"))
                        {
                            objmodel.BulkPermitId = response.CLNT_TXN_REF.Replace("ORDMIN", "").Trim();
                        }
                        if (response.CLNT_TXN_REF.StartsWith("ORDINC"))
                        {
                            objmodel.BulkPermitId = response.CLNT_TXN_REF.Replace("ORDINC", "").Trim();
                        }
                        if (response.CLNT_TXN_REF.StartsWith("ORDEVS"))
                        {
                            objmodel.BulkPermitId = response.CLNT_TXN_REF.Replace("ORDEVS", "").Trim();
                        }
                        if (!string.IsNullOrEmpty(objmodel.BulkPermitId))
                        {
                            objmodel.OrderNo = response.CLNT_TXN_REF;
                            objmodel.Txn_Status = strPG_Paymode.Contains("NEFT") == true ? "OFFLINE" : response.TXN_STATUS;
                            objmodel.UserId = profile.UserId;
                            objmodel.Challan_Number = strPG_TPSLTxnID;
                            objmodel.Challan_Initiate_Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                            Object objReturnData1 = paymentResponseModel.AddSBIDetails(objmodel);
                            if (objReturnData1 != null && !string.IsNullOrEmpty(Convert.ToString(objReturnData1)))
                            {
                                #region Sent Mail & MSG

                                objmodel2.BulkPermitId = objmodel.BulkPermitId;
                                objmodel2.UserId = profile.UserId;
                                objmodel2 = paymentResponseModel.SBIDetails(objmodel2);
                                objmodel2.TotalPayableAmount = Convert.ToDecimal(response.TXN_AMT);
                                #endregion
                            }
                            if (objReturnData1 != null && !string.IsNullOrEmpty(Convert.ToString(objReturnData1)))
                            {
                                if (objmodel.Txn_Status == "OFFLINE")
                                {
                                    string msg = "Your have successfully Generate eChallan for your e-Permit No.: " + objmodel2.BulkPermitNo + Environment.NewLine + " Dated " + System.DateTime.Now + Environment.NewLine +
                                                    "Quantity : " + objmodel2.ApprovedQty + " " + objmodel2.UnitName + "" + Environment.NewLine +
                                                    "Total Paid Amount : Rs " + objmodel2.TotalPayableAmount + "/-" + Environment.NewLine +
                                                    "Mineral Name : " + objmodel2.CardID + "" + Environment.NewLine +
                                                    "Mineral Form : " + objmodel2.IsIv + "" + Environment.NewLine +
                                                    "Mineral Grade : " + objmodel2.IsKey + "" + Environment.NewLine +
                                                    "Requesting to you please fill amount to the bank for further process of ePermit. CHiMMS, GoCG";

                                    //Modified by Avneesh on 12-04-2021
                                    string templateid = "1307161883584178590";
                                    sMSModel.Main(new SMS() { mobileNo = objmodel2.MobileNo, message = msg, templateid = templateid });


                                    //SMSHttpPostClient.Main(mobile, msg);
                                }
                                else
                                {
                                    try
                                    {

                                        if (!string.IsNullOrEmpty(objmodel2.EMailId))
                                        {

                                            mailModel.SendPermitPaymentAck(new PaymentEF()
                                            {
                                                BulkPermitNo = objmodel2.BulkPermitNo,
                                                ApprovedQty = objmodel2.ApprovedQty,
                                                TotalPayableAmount = objmodel2.TotalPayableAmount,
                                                CardID = objmodel2.CardID,
                                                IsKey = objmodel2.IsKey,
                                                IsIv = objmodel2.IsIv,
                                                Txn_Status = objmodel.Txn_Status,
                                                TransactionalId = objmodel2.TransactionalId,
                                                ApplicantName = objmodel2.ApplicantName,
                                                UTR_Number = profile.UserName,
                                                UserId = profile.UserId,
                                                EMailId = objmodel2.EMailId

                                            });
                                        }

                                        if (!string.IsNullOrEmpty(objmodel2.MobileNo))
                                        {
                                            if (response.TXN_STATUS == "AWAITED" || response.TXN_STATUS == "PENDING")
                                            {
                                                string msg = "Your payment have been initiate successfully and your payment status is awaited.Your Transaction No. is: " + objmodel2.TransactionalId + Environment.NewLine + " Dated " + System.DateTime.Now + Environment.NewLine +
                                                    "Quantity : " + objmodel2.ApprovedQty + " " + objmodel2.PropertyPath + "" + Environment.NewLine +
                                                    "Total Paid Amount : Rs " + objmodel2.TotalPayableAmount + "/-" + Environment.NewLine +
                                                    "Mineral Name : " + objmodel2.CardID + "" + Environment.NewLine +
                                                    "Mineral Form : " + objmodel2.IsIv + "" + Environment.NewLine +
                                                    "Mineral Grade : " + objmodel2.IsKey + ". CHiMMS, GoCG";

                                                //Modified by Avneesh on 12-04-2021
                                                string templateid = "1307161883587991005";
                                                sMSModel.Main(new SMS() { mobileNo = objmodel2.MobileNo, message = msg, templateid = templateid });


                                                //SMSHttpPostClient.Main(mobile, msg);
                                            }
                                            else
                                            {
                                                string msg = "Your payment has been credited successfully and Your e-Permit No. is: " + objmodel2.BulkPermitNo + Environment.NewLine + " Dated " + System.DateTime.Now + Environment.NewLine +
                                                    "Quantity : " + objmodel2.ApprovedQty + " " + objmodel2.PropertyPath + "" + Environment.NewLine +
                                                    "Total Paid Amount : Rs " + objmodel2.TotalPayableAmount + "/-" + Environment.NewLine +
                                                    "Mineral Name : " + objmodel2.CardID + "" + Environment.NewLine +
                                                    "Mineral Form : " + objmodel2.IsIv + "" + Environment.NewLine +
                                                    "Mineral Grade : " + objmodel2.IsKey + ". CHiMMS, GoCG";

                                                //Modified by Avneesh on 12-04-2021
                                                string templateid = "1307161883464434423";
                                                sMSModel.Main(new SMS() { mobileNo = objmodel2.MobileNo, message = msg, templateid = templateid });


                                                //SMSHttpPostClient.Main(mobile, msg);
                                            }
                                        }

                                    }
                                    catch (Exception)
                                    {

                                    }
                                    if (objmodel2 != null)
                                    {
                                        ViewBag.PaymentSuccess = objmodel2;
                                    }

                                }
                            }
                        }

                        #endregion
                    } //Added by Priyabrat Das
                }
                //else if (response.CLNT_TXN_REF.StartsWith("OBP"))
                //{
                //    #region Bulk Permit - Other Online Payment
                //    string strBulkPermitID = response.CLNT_TXN_REF.Replace("OBP", "").Trim();

                //    using (SqlCommand cmdupdate1 = new SqlCommand())
                //    {
                //        cmdupdate1.CommandText = "uspLesseeWisePaymentDetails";
                //        cmdupdate1.CommandType = System.Data.CommandType.StoredProcedure;

                //        cmdupdate1.Parameters.AddWithValue("@UserID", SessionWrapper.UserId);
                //        cmdupdate1.Parameters.AddWithValue("@SubUserID", SessionWrapper.SubUserID);
                //        cmdupdate1.Parameters.AddWithValue("@PaymentTypeId", strBulkPermitID);
                //        cmdupdate1.Parameters.AddWithValue("@PaymentStatus", response.TXN_STATUS);
                //        cmdupdate1.Parameters.AddWithValue("@PayableAmount", response.TXN_AMT);
                //        cmdupdate1.Parameters.AddWithValue("@Check", 3);

                //        using (DataTable dt = objDb.ExecuteStoreProcedure(cmdupdate1))
                //        {
                //            if (dt != null && dt.Rows.Count > 0)
                //            {
                //                #region Send Mail
                //                try
                //                {
                //                    if (response.TXN_STATUS == "AWAITED")
                //                    {
                //                        MailService mail = new MailService();
                //                        mail.SendNonPermitPaymentMail(response.TPSL_TXN_ID, Convert.ToString(dt.Rows[0]["EmailID"]),
                //                                DateTime.Now.ToString("dd/MM/yyyy"), response.TPSL_TXN_ID,
                //                                Convert.ToString(dt.Rows[0]["ApplicantName"]),
                //                                Convert.ToString(dt.Rows[0]["PaymentType"]),
                //                                Convert.ToString(dt.Rows[0]["PayableAmount"]));
                //                    }
                //                    else
                //                    {
                //                        MailService mail = new MailService();
                //                        mail.SendNonPermitPaymentMail(response.TPSL_TXN_ID, Convert.ToString(dt.Rows[0]["EmailID"]),
                //                                DateTime.Now.ToString("dd/MM/yyyy"), response.TPSL_TXN_ID,
                //                                Convert.ToString(dt.Rows[0]["ApplicantName"]),
                //                                Convert.ToString(dt.Rows[0]["PaymentType"]),
                //                                Convert.ToString(dt.Rows[0]["PayableAmount"]));
                //                    }
                //                }
                //                catch (Exception)
                //                {
                //                    TempData["AckMessage"] = "0";
                //                }
                //                #endregion

                //                #region Send SMS

                //                try
                //                {
                //                    string message = "Your Payments for " + Convert.ToString(dt.Rows[0]["PaymentType"]) + " has been credited successfully in Khanij Online System dated on " + System.DateTime.Now + " Please check your e-mail for details for Payment. CHiMMS, GoCG";

                //                    //Modified by Avneesh on 12-04-2021
                //                    string templateid = "1307161883631948644";
                //                    SMSHttpPostClient.Main(Convert.ToString(dt.Rows[0]["MobileNo"]), message, templateid);


                //                    //SMSHttpPostClient.Main(Convert.ToString(dt.Rows[0]["MobileNo"]), message);

                //                }
                //                catch (Exception)
                //                {

                //                }
                //                #endregion
                //            }
                //        }
                //    }
                //    #endregion
                //}
                //else if (response.CLNT_TXN_REF.StartsWith("BP"))
                //{
                //    #region e-Permit Payment
                //    string strBulkPermitID = response.CLNT_TXN_REF.Replace("BP", "").Trim();

                //    if (!string.IsNullOrEmpty(strBulkPermitID))
                //    {
                //        string paymentStatus = strPG_Paymode.Contains("NEFT") == true ? "OFFLINE" : response.TXN_STATUS;
                //        using (SqlCommand cmdupdate1 = new SqlCommand())
                //        {
                //            cmdupdate1.CommandText = "MakeFinalCoalPaymentNew";
                //            cmdupdate1.CommandType = System.Data.CommandType.StoredProcedure;
                //            cmdupdate1.Parameters.AddWithValue("@BulkPermitId", strBulkPermitID);
                //            cmdupdate1.Parameters.AddWithValue("@UserId", SessionWrapper.UserId);
                //            cmdupdate1.Parameters.AddWithValue("@PaymentStatus", paymentStatus);
                //            //if (paymentStatus == "OFFLINE") // if Offline then only challan number and date should be passed.
                //            //{
                //            cmdupdate1.Parameters.AddWithValue("@ChallanNumber", strPG_TPSLTxnID);
                //            cmdupdate1.Parameters.AddWithValue("@ChallanDate", strPG_TxnDateTime);
                //            //}
                //            Object objReturnData1 = objDb.GetSingleValue(cmdupdate1);

                //            if (objReturnData1 != null && !string.IsNullOrEmpty(Convert.ToString(objReturnData1)))
                //            {
                //                #region Sent Mail & MSG
                //                using (var cmd1 = new SqlCommand())
                //                {
                //                    var mobile = "";
                //                    var email = "";
                //                    var TransactionId = "";
                //                    var PaymentReceiptID = "";
                //                    var forwadedDate = "";
                //                    var ApplicantName = "";

                //                    cmd1.CommandText = "GetePermitForMailMsgAfterPayment";
                //                    cmd1.CommandType = System.Data.CommandType.StoredProcedure;

                //                    cmd1.Parameters.AddWithValue("@BulkPermitId", objReturnData1);
                //                    cmd1.Parameters.AddWithValue("@UserID", SessionWrapper.UserId);

                //                    using (var ds = objDb.ExecuteStoreProcedureDS(cmd1))
                //                    {
                //                        if (ds != null && ds.Tables.Count > 0)
                //                        {
                //                            using (DataTable dt = ds.Tables[0])
                //                            {
                //                                if (dt != null && dt.Rows.Count > 0)
                //                                {
                //                                    mobile = dt.Rows[0]["MobileNo"].ToString();
                //                                    email = dt.Rows[0]["EMailId"].ToString();
                //                                    ApplicantName = dt.Rows[0]["ApplicantName"].ToString();
                //                                    TransactionId = dt.Rows[0]["TransactionalId"].ToString();
                //                                    PaymentReceiptID = dt.Rows[0]["PaymentReceiptID"].ToString();
                //                                    forwadedDate = dt.Rows[0]["forwadedDate"].ToString();
                //                                    string BulkPermitNo = dt.Rows[0]["BulkPermitNo"].ToString();
                //                                    string ApprovedQty = Convert.ToString(dt.Rows[0]["ApprovedQty"]);
                //                                    string TotalPayableAmount = response.TXN_AMT; //Convert.ToString(dt.Rows[0]["TotalPayableAmount"]);
                //                                    string MineralName = Convert.ToString(dt.Rows[0]["MineralName"]);
                //                                    string MineralGrade = Convert.ToString(dt.Rows[0]["MineralGrade"]);
                //                                    string MineralNature = Convert.ToString(dt.Rows[0]["MineralNature"]);
                //                                    string UnitName = Convert.ToString(dt.Rows[0]["UnitName"]);

                //                                    if (paymentStatus == "OFFLINE")
                //                                    {
                //                                        string msg = "Your have successfully Generate eChallan for your e-Permit No.: " + BulkPermitNo + Environment.NewLine + " Dated " + System.DateTime.Now + Environment.NewLine +
                //                                                        "Quantity : " + ApprovedQty + " " + UnitName + "" + Environment.NewLine +
                //                                                        "Total Paid Amount : Rs " + TotalPayableAmount + "/-" + Environment.NewLine +
                //                                                        "Mineral Name : " + MineralName + "" + Environment.NewLine +
                //                                                        "Mineral Form : " + MineralNature + "" + Environment.NewLine +
                //                                                        "Mineral Grade : " + MineralGrade + "" + Environment.NewLine +
                //                                                        "Requesting to you please fill amount to the bank for further process of ePermit. CHiMMS, GoCG";

                //                                        //Modified by Avneesh on 12-04-2021
                //                                        string templateid = "1307161883584178590";
                //                                        SMSHttpPostClient.Main(mobile, msg, templateid);


                //                                        //SMSHttpPostClient.Main(mobile, msg);
                //                                    }
                //                                    else
                //                                    {
                //                                        #region Send SMS

                //                                        try
                //                                        {

                //                                            if (!string.IsNullOrEmpty(email))
                //                                            {
                //                                                MailService dmoMail = new MailService();
                //                                                dmoMail.SendPermitPaymentAck(email, BulkPermitNo, ApprovedQty, TotalPayableAmount, MineralName, MineralGrade, MineralNature, response.TXN_STATUS, TransactionId);
                //                                            }

                //                                            if (!string.IsNullOrEmpty(mobile))
                //                                            {
                //                                                if (response.TXN_STATUS == "AWAITED" || response.TXN_STATUS == "PENDING")
                //                                                {
                //                                                    string msg = "Your payment have been initiate successfully and your payment status is awaited.Your Transaction No. is: " + TransactionId + Environment.NewLine + " Dated " + System.DateTime.Now + Environment.NewLine +
                //                                                        "Quantity : " + ApprovedQty + " " + UnitName + "" + Environment.NewLine +
                //                                                        "Total Paid Amount : Rs " + TotalPayableAmount + "/-" + Environment.NewLine +
                //                                                        "Mineral Name : " + MineralName + "" + Environment.NewLine +
                //                                                        "Mineral Form : " + MineralNature + "" + Environment.NewLine +
                //                                                        "Mineral Grade : " + MineralGrade + ". CHiMMS, GoCG";

                //                                                    //Modified by Avneesh on 12-04-2021
                //                                                    string templateid = "1307161883587991005";
                //                                                    SMSHttpPostClient.Main(mobile, msg, templateid);


                //                                                    //SMSHttpPostClient.Main(mobile, msg);
                //                                                }
                //                                                else
                //                                                {
                //                                                    string msg = "Your payment has been credited successfully and Your e-Permit No. is: " + BulkPermitNo + Environment.NewLine + " Dated " + System.DateTime.Now + Environment.NewLine +
                //                                                        "Quantity : " + ApprovedQty + " " + UnitName + "" + Environment.NewLine +
                //                                                        "Total Paid Amount : Rs " + TotalPayableAmount + "/-" + Environment.NewLine +
                //                                                        "Mineral Name : " + MineralName + "" + Environment.NewLine +
                //                                                        "Mineral Form : " + MineralNature + "" + Environment.NewLine +
                //                                                        "Mineral Grade : " + MineralGrade + ". CHiMMS, GoCG";

                //                                                    //Modified by Avneesh on 12-04-2021
                //                                                    string templateid = "1307161883464434423";
                //                                                    SMSHttpPostClient.Main(mobile, msg, templateid);


                //                                                    //SMSHttpPostClient.Main(mobile, msg);
                //                                                }
                //                                            }

                //                                        }
                //                                        catch (Exception)
                //                                        {

                //                                        }


                //                                        #endregion
                //                                    }
                //                                }
                //                            }
                //                        }

                //                        if (ds != null && ds.Tables.Count > 1)
                //                        {
                //                            ViewBag.PaymentSuccess = ds.Tables[1];
                //                        }
                //                    }
                //                }

                //                #endregion
                //            }
                //        }
                //    }
                //    #endregion
                //}
                //else if (response.CLNT_TXN_REF.StartsWith("SL"))
                //{
                //    #region e-Permit Payment
                //    string strBulkPermitID = response.CLNT_TXN_REF.Replace("SL", "").Trim();

                //    if (!string.IsNullOrEmpty(strBulkPermitID))
                //    {
                //        using (SqlCommand cmdupdate1 = new SqlCommand())
                //        {
                //            cmdupdate1.CommandText = "uspSuperLesseeDashboardData";
                //            cmdupdate1.CommandType = System.Data.CommandType.StoredProcedure;
                //            cmdupdate1.Parameters.AddWithValue("@PaymentID", strBulkPermitID);
                //            cmdupdate1.Parameters.AddWithValue("@UserId", SessionWrapper.UserId);
                //            cmdupdate1.Parameters.AddWithValue("@PaymentStatus", response.TXN_STATUS);
                //            cmdupdate1.Parameters.AddWithValue("@Check", 10);


                //            using (var ds = objDb.ExecuteStoreProcedureDS(cmdupdate1))
                //            {
                //                if (ds != null && ds.Tables.Count > 0)
                //                {
                //                    using (DataTable dt = ds.Tables[0])
                //                    {
                //                        if (dt != null && dt.Rows.Count > 0 && !string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["PaymentID"])))
                //                        {
                //                            #region Send SMS
                //                            try
                //                            {
                //                                #region Send Mail
                //                                try
                //                                {

                //                                    MailService mail = new MailService();
                //                                    mail.SendNonPermitPaymentMail(SessionWrapper.UserLoginId.ToString(), SessionWrapper.EmailId,
                //                                            DateTime.Now.ToString("dd/MM/yyyy"), SessionWrapper.UserId.ToString(),
                //                                            SessionWrapper.UserName,
                //                                            "Your payment for bulk e-Permit has been done successfully and your payment status is " + response.TXN_STATUS + " ",
                //                                            Convert.ToString(response.TXN_AMT));
                //                                }
                //                                catch (Exception)
                //                                {
                //                                    TempData["AckMessage"] = "0";
                //                                }
                //                                #endregion

                //                                #region Send SMS

                //                                try
                //                                {
                //                                    string strAlert = "Your payment for bulk e-Permit has been done successfully and your payment status is " + response.TXN_STATUS + " in Khanij Online System dated on " + System.DateTime.Now + " Please check your e-mail for details for Payment. CHiMMS, GoCG";

                //                                    //Modified by Avneesh on 12-04-2021
                //                                    string templateid = "1307161883595634167";
                //                                    SMSHttpPostClient.Main(SessionWrapper.MobileNumber, strAlert, templateid);


                //                                    //SMSHttpPostClient.Main(SessionWrapper.MobileNumber, strAlert);

                //                                }
                //                                catch (Exception)
                //                                {

                //                                }
                //                                #endregion
                //                            }
                //                            catch (Exception)
                //                            {

                //                            }
                //                            #endregion
                //                        }
                //                    }

                //                    if (ds != null && ds.Tables.Count > 1)
                //                    {
                //                        ViewBag.PaymentSuccess = ds.Tables[1];
                //                    }
                //                }
                //            }
                //        }
                //    }
                //    #endregion
                //}
                //else if (response.CLNT_TXN_REF.StartsWith("VP"))
                //{
                //    #region Vehicle Payments
                //    string strBulkPermitID = response.CLNT_TXN_REF.Trim();

                //    using (SqlCommand cmdupdate1 = new SqlCommand())
                //    {
                //        cmdupdate1.CommandText = "upsInsertVehicleMasterPaymentDetails";
                //        cmdupdate1.CommandType = System.Data.CommandType.StoredProcedure;

                //        cmdupdate1.Parameters.AddWithValue("@PaymentVehicleID", strBulkPermitID);
                //        cmdupdate1.Parameters.AddWithValue("@UserId", SessionWrapper.UserId);
                //        cmdupdate1.Parameters.AddWithValue("@PaymentStatus", response.TXN_STATUS);
                //        cmdupdate1.Parameters.AddWithValue("@UserLoginId", SessionWrapper.UserLoginId);
                //        cmdupdate1.Parameters.AddWithValue("@CHECK", 2);

                //        using (DataTable dt = objDb.ExecuteStoreProcedure(cmdupdate1))
                //        {
                //            if (dt != null && dt.Rows.Count > 0)
                //            {
                //                CHiMMS_MVC.Areas.Transporters.Models.TransporterMasterModel TModel = new CHiMMS_MVC.Areas.Transporters.Models.TransporterMasterModel();
                //                TModel.EmailID = Convert.ToString(dt.Rows[0]["EmailID"]);
                //                TModel.TotalVehiclesPayment = Convert.ToString(dt.Rows[0]["RegFees"]);
                //                TModel.VehicleCount = Convert.ToInt32(dt.Rows[0]["TotalVehicleCount"]);
                //                TModel.ApplicantName = Convert.ToString(dt.Rows[0]["ApplicantName"]);
                //                TModel.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                //                TModel.MobileNo = Convert.ToString(dt.Rows[0]["MobileNo"]);

                //                UserMasterModel UModel = new UserMasterModel();
                //                UModel.UserName = TModel.UserName;
                //                UModel.Password = TModel.Password;
                //                UModel.UserId = TModel.UserId;
                //                UModel.UserCode = TModel.UserCode;
                //                UModel.MobileNo = TModel.MobileNo;
                //                UModel.EMailId = TModel.EmailID;

                //                if (strPG_TxnStatus == "SUCCESS" || strPG_TxnStatusDesc.ToUpper().Contains("COMPLETED"))//Success
                //                {
                //                    #region Send SMS

                //                    try
                //                    {
                //                        string message = "Dear " + SessionWrapper.ApplicantName + Environment.NewLine + "Vehicles are successfully registered in Khanij Online System dated on " + System.DateTime.Now + ". Please login to Khanij Online portal for further. CHiMMS, GoCG";

                //                        //Modified by Avneesh on 12-04-2021
                //                        string templateid = "1307161883599887989";
                //                        SMSHttpPostClient.Main(TModel.MobileNo, message, templateid);


                //                        //SMSHttpPostClient.Main(TModel.MobileNo, message);

                //                    }
                //                    catch (Exception)
                //                    {
                //                    }
                //                    #endregion

                //                    #region Send Mail
                //                    try
                //                    {
                //                        MailService mail = new MailService();
                //                        mail.SendMail_AddVehiclesAck(TModel);
                //                        // return RedirectToAction("ProfileView", "EndUserProfile");
                //                    }
                //                    catch (Exception)
                //                    {
                //                        TempData["AckMessage"] = "0";
                //                        return RedirectToAction("Registration", "TransporterRegistration");
                //                    }
                //                    #endregion
                //                }
                //                else if (response.TXN_STATUS == "AWAITED" || strPG_TxnStatusDesc.ToUpper().Contains("PENDING") || strPG_TxnStatusDesc == "NEFT")//Awaited
                //                {
                //                    #region Send SMS
                //                    try
                //                    {
                //                        string message = "Dear " + SessionWrapper.ApplicantName + Environment.NewLine + "Your Vehicle Registration payment process has been completed & your payment status is awaited."
                //                                            + Environment.NewLine +
                //                                            "Your Transaction Reference Number is " + response.CLNT_TXN_REF + Environment.NewLine +
                //                                            "Use this for Future reference. Please login to Khanij Online portal for further. CHiMMS, GoCG";

                //                        //Modified by Avneesh on 12-04-2021
                //                        string templateid = "1307161883603544306";
                //                        SMSHttpPostClient.Main(TModel.MobileNo, message, templateid);


                //                        //SMSHttpPostClient.Main(TModel.MobileNo, message);

                //                    }
                //                    catch (Exception)
                //                    {

                //                    }
                //                    #endregion

                //                    #region Send Mail
                //                    try
                //                    {
                //                        MailService mail = new MailService();
                //                        mail.SendPaymentAwaitedMail(UModel, response.CLNT_TXN_REF);
                //                    }
                //                    catch (Exception)
                //                    {
                //                        TempData["AckMessage"] = "0";
                //                        return RedirectToAction("ProfileView", "EndUserProfile");
                //                    }
                //                    #endregion
                //                }
                //            }
                //        }
                //    }
                //    #endregion
                //}
                //else if (response.CLNT_TXN_REF.StartsWith("DN"))
                //{
                //    #region Demand Note Payments
                //    string strDemandNoteTXNID = response.CLNT_TXN_REF.Trim();

                //    using (SqlCommand cmdupdate1 = new SqlCommand())
                //    {
                //        cmdupdate1.CommandText = "uspGetDemandNotePaymentList";
                //        cmdupdate1.CommandType = System.Data.CommandType.StoredProcedure;

                //        cmdupdate1.Parameters.AddWithValue("@PaymentDemandNoteID", strDemandNoteTXNID);
                //        cmdupdate1.Parameters.AddWithValue("@UserId", SessionWrapper.UserId);
                //        cmdupdate1.Parameters.AddWithValue("@PaymentStatus", response.TXN_STATUS);
                //        cmdupdate1.Parameters.AddWithValue("@UserLoginId", SessionWrapper.UserLoginId);
                //        cmdupdate1.Parameters.AddWithValue("@SpMode", "PaymentResponse");
                //        cmdupdate1.Parameters.AddWithValue("@PayableRoyalty", response.PayableRoyalty);
                //        cmdupdate1.Parameters.AddWithValue("@DMF", response.DMF);
                //        cmdupdate1.Parameters.AddWithValue("@NMET", response.NMET);
                //        cmdupdate1.Parameters.AddWithValue("@TCS", response.TCS);
                //        cmdupdate1.Parameters.AddWithValue("@iCess", response.Cess);
                //        cmdupdate1.Parameters.AddWithValue("@eCess", response.eCess);

                //        using (DataTable dt = objDb.ExecuteStoreProcedure(cmdupdate1))
                //        {
                //            if (dt != null && dt.Rows.Count > 0)
                //            {
                //                UserMasterModel UModel = new UserMasterModel();

                //                UModel.EMailId = Convert.ToString(dt.Rows[0]["EmailID"]);
                //                //UModel.TotalVehiclesPayment = Convert.ToString(dt.Rows[0]["TotalPaidAmount"]);
                //                //UModel.VehicleCount = Convert.ToInt32(dt.Rows[0]["TotalDemandNoteCount"]);
                //                UModel.ApplicantName = Convert.ToString(dt.Rows[0]["ApplicantName"]);
                //                UModel.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                //                UModel.MobileNo = Convert.ToString(dt.Rows[0]["MobileNo"]);
                //                UModel.Password = Convert.ToString(dt.Rows[0]["Password"]);
                //                UModel.UserId = Convert.ToInt32(dt.Rows[0]["userId"]);
                //                UModel.UserCode = Convert.ToString(dt.Rows[0]["UserName"]);

                //                if (strPG_TxnStatus == "SUCCESS" || strPG_TxnStatusDesc.ToUpper().Contains("COMPLETED"))//Success
                //                {
                //                    #region Send SMS

                //                    try
                //                    {
                //                        string message = "Dear " + SessionWrapper.ApplicantName + Environment.NewLine + "Your payment for demand note has been done successfully and your payment status is " + response.TXN_STATUS + " in Khanij Online System dated on " + System.DateTime.Now + " Please check your e-mail for details for Payment. CHiMMS, GoCG";

                //                        //Modified by Avneesh on 12-04-2021
                //                        string templateid = "1307161883635337442";
                //                        SMSHttpPostClient.Main(UModel.MobileNo, message, templateid);


                //                        //SMSHttpPostClient.Main(UModel.MobileNo, message);

                //                    }
                //                    catch (Exception)
                //                    {
                //                    }
                //                    #endregion

                //                    #region Send Mail
                //                    try
                //                    {
                //                        MailService mail = new MailService();
                //                        mail.SendNonPermitPaymentMail(SessionWrapper.UserLoginId.ToString(), UModel.EMailId,
                //                                DateTime.Now.ToString("dd/MM/yyyy"), SessionWrapper.UserId.ToString(),
                //                                UModel.ApplicantName,
                //                                "Demand Note and your payment status is " + response.TXN_STATUS + " ",
                //                                Convert.ToString(response.TXN_AMT));

                //                    }
                //                    catch (Exception)
                //                    {
                //                        TempData["AckMessage"] = "0";
                //                    }
                //                    #endregion
                //                }
                //                else if (response.TXN_STATUS == "AWAITED" || strPG_TxnStatusDesc.ToUpper().Contains("PENDING") || strPG_TxnStatusDesc == "NEFT")//Awaited
                //                {
                //                    #region Send SMS
                //                    try
                //                    {
                //                        string message = "Dear " + SessionWrapper.ApplicantName + Environment.NewLine + "Your demand note payment process has been completed & your payment status is awaited."
                //                                           + Environment.NewLine +
                //                                           "Your Transaction Reference Number is " + response.CLNT_TXN_REF + Environment.NewLine +
                //                                           "Use this for Future reference. Please login to Khanij Online portal for further. CHiMMS, GoCG";


                //                        //Modified by Avneesh on 12-04-2021
                //                        string templateid = "1307161883617239647";
                //                        SMSHttpPostClient.Main(UModel.MobileNo, message, templateid);


                //                        //SMSHttpPostClient.Main(UModel.MobileNo, message);

                //                    }
                //                    catch (Exception)
                //                    {

                //                    }
                //                    #endregion

                //                    #region Send Mail
                //                    try
                //                    {
                //                        MailService mail = new MailService();
                //                        mail.SendPaymentAwaitedMail(UModel, response.CLNT_TXN_REF);
                //                    }
                //                    catch (Exception)
                //                    {
                //                        TempData["AckMessage"] = "0";
                //                    }
                //                    #endregion
                //                }
                //            }
                //        }
                //    }
                //    #endregion
                //}
                //else if (response.CLNT_TXN_REF.StartsWith("UPG"))
                //{
                //    #region e-Permit Payment For Upgrade Grade

                //    string strBulkPermitID = response.CLNT_TXN_REF.Replace("UPG", "").Trim();

                //    if (!string.IsNullOrEmpty(strBulkPermitID))
                //    {
                //        string paymentStatus = strPG_Paymode.Contains("NEFT") == true ? "OFFLINE" : response.TXN_STATUS;
                //        using (SqlCommand cmdupdate1 = new SqlCommand())
                //        {
                //            cmdupdate1.CommandText = "uspSampleGrade_Master";

                //            cmdupdate1.CommandType = System.Data.CommandType.StoredProcedure;
                //            cmdupdate1.Parameters.AddWithValue("@BulkPermitId", strBulkPermitID);
                //            cmdupdate1.Parameters.AddWithValue("@CreatedBy", SessionWrapper.UserId);
                //            cmdupdate1.Parameters.AddWithValue("@Check", 6);
                //            cmdupdate1.Parameters.AddWithValue("@PaymentStatus", paymentStatus);


                //            #region Sent Mail & MSG
                //            var mobile = "";
                //            var email = "";
                //            var TransactionId = "";
                //            var PaymentReceiptID = "";
                //            var forwadedDate = "";
                //            var ApplicantName = "";


                //            using (var ds = objDb.ExecuteStoreProcedureDS(cmdupdate1))
                //            {
                //                if (ds != null && ds.Tables.Count > 0)
                //                {
                //                    using (DataTable dt = ds.Tables[0])
                //                    {
                //                        if (dt != null && dt.Rows.Count > 0)
                //                        {
                //                            mobile = dt.Rows[0]["MobileNo"].ToString();
                //                            email = dt.Rows[0]["EMailId"].ToString();
                //                            ApplicantName = dt.Rows[0]["ApplicantName"].ToString();
                //                            TransactionId = dt.Rows[0]["TransactionalId"].ToString();
                //                            PaymentReceiptID = dt.Rows[0]["PaymentReceiptID"].ToString();
                //                            forwadedDate = dt.Rows[0]["forwadedDate"].ToString();
                //                            string BulkPermitNo = dt.Rows[0]["BulkPermitNo"].ToString();
                //                            string ApprovedQty = Convert.ToString(dt.Rows[0]["ApprovedQty"]);
                //                            string TotalPayableAmount = response.TXN_AMT; //Convert.ToString(dt.Rows[0]["TotalPayableAmount"]);
                //                            string MineralName = Convert.ToString(dt.Rows[0]["MineralName"]);
                //                            string MineralGrade = Convert.ToString(dt.Rows[0]["MineralGrade"]);
                //                            string MineralNature = Convert.ToString(dt.Rows[0]["MineralNature"]);
                //                            string MineralGrade1 = Convert.ToString(dt.Rows[0]["NEWGRADE"]);
                //                            // string TOTALPAYABLEAMOUNT = Convert.ToString(dt.Rows[0]["TOTALPAYABLEAMOUNT"]);



                //                            if (paymentStatus == "OFFLINE")
                //                            {
                //                                string msg = "Your have successfully Generate eChallan for your grade updation of e-Permit No: " + BulkPermitNo + Environment.NewLine + "  on dated " + System.DateTime.Now + Environment.NewLine +
                //                                               "Sampling Grade No  : " + TransactionId + Environment.NewLine +
                //                                               "Sampling Quantity : " + ApprovedQty + Environment.NewLine +
                //                                               "Total Sampling Amount : Rs " + TotalPayableAmount + "/-" + Environment.NewLine +
                //                                               "Mineral Name : " + MineralName + "" + Environment.NewLine +
                //                                               "Mineral Form : " + MineralNature + "" + Environment.NewLine +
                //                                               "Mineral Grade : " + MineralGrade + "" + Environment.NewLine +
                //                                               "Sample Mineral Grade : " + MineralGrade1 + "" + Environment.NewLine +
                //                                               "Requesting to you please fill amount to the bank for further process of grade updation of e-Permit. CHiMMS, GoCG";

                //                                //Modified by Avneesh on 12-04-2021
                //                                string templateid = "1307161883639479602";
                //                                SMSHttpPostClient.Main(mobile, msg, templateid);


                //                                //SMSHttpPostClient.Main(mobile, msg);
                //                            }
                //                            else
                //                            {
                //                                #region Send SMS


                //                                try
                //                                {
                //                                    if (!string.IsNullOrEmpty(email))
                //                                    {
                //                                        MailService dmoMail = new MailService();
                //                                        dmoMail.SendPermitPaymentAck(email, BulkPermitNo, ApprovedQty, TotalPayableAmount, MineralName, MineralGrade, MineralNature, response.TXN_STATUS, TransactionId);
                //                                    }

                //                                    if (!string.IsNullOrEmpty(mobile))
                //                                    {
                //                                        if (response.TXN_STATUS == "AWAITED" || response.TXN_STATUS == "PENDING")
                //                                        {
                //                                            string msg = "Your payment have been initiate successfully for sampling of grade and your payment status is awaited.Your Transaction No. is: " + TransactionId + Environment.NewLine + " Dated " + System.DateTime.Now + Environment.NewLine +
                //                                                "Sampling Quantity : " + ApprovedQty + Environment.NewLine +
                //                                                "Total Sampling Amount : Rs " + TotalPayableAmount + "/-" + Environment.NewLine +
                //                                                "Mineral Name : " + MineralName + "" + Environment.NewLine +
                //                                                "Mineral Form : " + MineralNature + "" + Environment.NewLine +
                //                                                "Mineral Grade : " + MineralGrade + "" + Environment.NewLine +
                //                                                "Sample Mineral Grade : " + MineralGrade1 + "" + Environment.NewLine +
                //                                                "Requesting to you please fill amount to the bank for further process of grade updation of e-Permit. CHiMMS, GoCG";

                //                                            //Modified by Avneesh on 12-04-2021
                //                                            string templateid = "1307161883643792399";
                //                                            SMSHttpPostClient.Main(mobile, msg, templateid);


                //                                            //SMSHttpPostClient.Main(mobile, msg);
                //                                        }
                //                                        else
                //                                        {
                //                                            string msg = "Your payment has been credited successfully for sampling of grade and for e-Permit No : " + BulkPermitNo + Environment.NewLine + " Dated " + System.DateTime.Now + Environment.NewLine +
                //                                                "Sampling Grade No  : " + TransactionId + Environment.NewLine +
                //                                                "Sampling Quantity : " + ApprovedQty + Environment.NewLine +
                //                                                "Total Sampling Amount : Rs " + TotalPayableAmount + "/-" + Environment.NewLine +
                //                                                "Mineral Name : " + MineralName + "" + Environment.NewLine +
                //                                                "Mineral Form : " + MineralNature + "" + Environment.NewLine +
                //                                                "Mineral Grade : " + MineralGrade + "" + Environment.NewLine +
                //                                                "Sample Mineral Grade : " + MineralGrade1 + "" + Environment.NewLine + " CHiMMS, GoCG";

                //                                            //Modified by Avneesh on 12-04-2021
                //                                            string templateid = "1307161883647464067";
                //                                            SMSHttpPostClient.Main(mobile, msg, templateid);


                //                                            //SMSHttpPostClient.Main(mobile, msg);
                //                                        }
                //                                    }

                //                                }
                //                                catch (Exception)
                //                                {

                //                                }
                //                                #endregion
                //                            }
                //                        }
                //                    }
                //                }

                //                if (ds != null && ds.Tables.Count > 1)
                //                {
                //                    ViewBag.PaymentSuccess = ds.Tables[1];
                //                }

                //            }


                //            #endregion

                //        }
                //    }
                //    #endregion
                //}
                //else if (response.CLNT_TXN_REF.StartsWith("SLOI"))
                //{
                //    #region second LOI Payment
                //    // string strLOITXNID = response.CLNT_TXN_REF.Replace("LOI_", "").Trim();
                //    string paymentStatus = response.TXN_STATUS;

                //    using (SqlCommand cmdupdate1 = new SqlCommand())
                //    {
                //        cmdupdate1.CommandText = "uspSubmissionOfStatutoryClearance";
                //        cmdupdate1.CommandType = System.Data.CommandType.StoredProcedure;

                //        cmdupdate1.Parameters.AddWithValue("@SubmissionId", response.CLNT_TXN_REF);
                //        cmdupdate1.Parameters.AddWithValue("@UserId", SessionWrapper.UserId);
                //        cmdupdate1.Parameters.AddWithValue("@TransactionalID", response.TPSL_TXN_ID);
                //        cmdupdate1.Parameters.AddWithValue("@UserLoginId", SessionWrapper.UserLoginId);
                //        cmdupdate1.Parameters.AddWithValue("@PaymentStatus", paymentStatus);
                //        cmdupdate1.Parameters.AddWithValue("@SpMode", "UpdateStatus_Second_Installment");

                //        using (DataTable dt = objDb.ExecuteStoreProcedure(cmdupdate1))
                //        {
                //            if (dt != null && dt.Rows.Count > 0)
                //            {
                //                UserMasterModel UModel = new UserMasterModel();

                //                UModel.EMailId = Convert.ToString(dt.Rows[0]["EmailID"]);
                //                //UModel.TotalVehiclesPayment = Convert.ToString(dt.Rows[0]["TotalPaidAmount"]);
                //                //UModel.VehicleCount = Convert.ToInt32(dt.Rows[0]["TotalDemandNoteCount"]);
                //                UModel.ApplicantName = Convert.ToString(dt.Rows[0]["ApplicantName"]);
                //                UModel.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                //                UModel.MobileNo = Convert.ToString(dt.Rows[0]["MobileNo"]);
                //                UModel.Password = Convert.ToString(dt.Rows[0]["Password"]);
                //                UModel.UserId = Convert.ToInt32(dt.Rows[0]["userId"]);
                //                UModel.UserCode = Convert.ToString(dt.Rows[0]["UserName"]);

                //                if (strPG_TxnStatus == "SUCCESS" || strPG_TxnStatusDesc.ToUpper().Contains("COMPLETED"))//Success
                //                {
                //                    #region Send SMS

                //                    try
                //                    {
                //                        string message = "Dear " + SessionWrapper.ApplicantName + Environment.NewLine + "Your payment for LOI has been credited successfully and your payment status is " + response.TXN_STATUS + " in Khanij Online System dated on " + System.DateTime.Now + " Please check your e-mail for details for Payment. CHiMMS, GoCG";

                //                        //Modified by Avneesh on 12-04-2021
                //                        string templateid = "1307161883621479838";
                //                        SMSHttpPostClient.Main(UModel.MobileNo, message, templateid);


                //                        //SMSHttpPostClient.Main(UModel.MobileNo, message);
                //                    }
                //                    catch (Exception)
                //                    {
                //                    }
                //                    #endregion

                //                    #region Send Mail
                //                    try
                //                    {
                //                        MailService mail = new MailService();
                //                        mail.SendNonPermitPaymentMail(SessionWrapper.UserLoginId.ToString(), UModel.EMailId,
                //                                DateTime.Now.ToString("dd/MM/yyyy"), SessionWrapper.UserId.ToString(),
                //                                UModel.ApplicantName,
                //                                "LOI and your payment status is " + response.TXN_STATUS + " ",
                //                                Convert.ToString(response.TXN_AMT));

                //                    }
                //                    catch (Exception)
                //                    {
                //                        TempData["AckMessage"] = "0";
                //                    }
                //                    #endregion
                //                }
                //                else if (response.TXN_STATUS == "AWAITED" || strPG_TxnStatusDesc.ToUpper().Contains("PENDING") || strPG_TxnStatusDesc == "NEFT")//Awaited
                //                {
                //                    #region Send SMS
                //                    try
                //                    {
                //                        //string message = "Dear " + SessionWrapper.ApplicantName + Environment.NewLine + "Your payment for LOI has been credited successfully and your payment status is " + response.TXN_STATUS + " in Khanij Online System dated on " + System.DateTime.Now + " Please check your e-mail for details for Payment.";
                //                        string message = "Dear " + SessionWrapper.ApplicantName + Environment.NewLine + "Your payment for LOI has been credited successfully and your payment status is " + response.TXN_STATUS
                //                                            + Environment.NewLine +
                //                                            "Your Transaction Reference Number is " + response.CLNT_TXN_REF + Environment.NewLine +
                //                                            "Use this for Future reference. Please login to Khanij Online portal for further. CHiMMS, GoCG";

                //                        //Modified by Avneesh on 12-04-2021
                //                        string templateid = "1307161883650652355";
                //                        SMSHttpPostClient.Main(UModel.MobileNo, message, templateid);


                //                        //SMSHttpPostClient.Main(UModel.MobileNo, message);

                //                    }
                //                    catch (Exception)
                //                    {

                //                    }
                //                    #endregion

                //                    #region Send Mail
                //                    try
                //                    {
                //                        MailService mail = new MailService();
                //                        mail.SendPaymentAwaitedMail(UModel, response.CLNT_TXN_REF);
                //                    }
                //                    catch (Exception)
                //                    {
                //                        TempData["AckMessage"] = "0";
                //                    }
                //                    #endregion
                //                }
                //            }
                //        }
                //    }
                //    #endregion
                //}
                //else if (response.CLNT_TXN_REF.StartsWith("TLOI"))
                //{
                //    #region Third installment of LOI
                //    //string strLOITXNID = response.CLNT_TXN_REF.Replace("TLOI_", "").Trim();

                //    using (SqlCommand cmdupdate1 = new SqlCommand())
                //    {
                //        cmdupdate1.CommandText = "uspSubmissionOfStatutoryClearance";
                //        cmdupdate1.CommandType = System.Data.CommandType.StoredProcedure;

                //        cmdupdate1.Parameters.AddWithValue("@SubmissionId", response.CLNT_TXN_REF);
                //        cmdupdate1.Parameters.AddWithValue("@UserId", SessionWrapper.UserId);
                //        cmdupdate1.Parameters.AddWithValue("@TransactionalID", response.TPSL_TXN_ID);
                //        cmdupdate1.Parameters.AddWithValue("@UserLoginId", SessionWrapper.UserLoginId);
                //        cmdupdate1.Parameters.AddWithValue("@SpMode", "UpdateStatus_Third_Installment");

                //        using (DataTable dt = objDb.ExecuteStoreProcedure(cmdupdate1))
                //        {
                //            if (dt != null && dt.Rows.Count > 0)
                //            {
                //                UserMasterModel UModel = new UserMasterModel();

                //                UModel.EMailId = Convert.ToString(dt.Rows[0]["EmailID"]);
                //                //UModel.TotalVehiclesPayment = Convert.ToString(dt.Rows[0]["TotalPaidAmount"]);
                //                //UModel.VehicleCount = Convert.ToInt32(dt.Rows[0]["TotalDemandNoteCount"]);
                //                UModel.ApplicantName = Convert.ToString(dt.Rows[0]["ApplicantName"]);
                //                UModel.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                //                UModel.MobileNo = Convert.ToString(dt.Rows[0]["MobileNo"]);
                //                UModel.Password = Convert.ToString(dt.Rows[0]["Password"]);
                //                UModel.UserId = Convert.ToInt32(dt.Rows[0]["userId"]);
                //                UModel.UserCode = Convert.ToString(dt.Rows[0]["UserName"]);

                //                if (strPG_TxnStatus == "SUCCESS" || strPG_TxnStatusDesc.ToUpper().Contains("COMPLETED"))//Success
                //                {
                //                    #region Send SMS

                //                    try
                //                    {
                //                        string message = "Dear " + SessionWrapper.ApplicantName + Environment.NewLine + "Your third LOI installment of upfront payment has been credited successfully and your payment status is " + response.TXN_STATUS + " in Khanij Online System dated on " + System.DateTime.Now + " Please check your e-mail for details for Payment. CHiMMS, GoCG";

                //                        //Modified by Avneesh on 12-04-2021
                //                        string templateid = "1307161883624755733";
                //                        SMSHttpPostClient.Main(UModel.MobileNo, message, templateid);


                //                        //SMSHttpPostClient.Main(UModel.MobileNo, message);
                //                    }
                //                    catch (Exception)
                //                    {
                //                    }
                //                    #endregion

                //                    #region Send Mail
                //                    try
                //                    {
                //                        MailService mail = new MailService();
                //                        mail.SendNonPermitPaymentMail(SessionWrapper.UserLoginId.ToString(), UModel.EMailId,
                //                                DateTime.Now.ToString("dd/MM/yyyy"), SessionWrapper.UserId.ToString(),
                //                                UModel.ApplicantName,
                //                                "LOI and your third installment of upfront payment status is " + response.TXN_STATUS + " ",
                //                                Convert.ToString(response.TXN_AMT));

                //                    }
                //                    catch (Exception)
                //                    {
                //                        TempData["AckMessage"] = "0";
                //                    }
                //                    #endregion
                //                }
                //                else if (response.TXN_STATUS == "AWAITED" || strPG_TxnStatusDesc.ToUpper().Contains("PENDING") || strPG_TxnStatusDesc == "NEFT")//Awaited
                //                {
                //                    #region Send SMS
                //                    try
                //                    {
                //                        string message = "Dear " + SessionWrapper.ApplicantName + Environment.NewLine + "Your demand note payment process has been completed & your payment status is awaited."
                //                                            + Environment.NewLine +
                //                                            "Your Transaction Reference Number is " + response.CLNT_TXN_REF + Environment.NewLine +
                //                                            "Use this for Future reference. Please login to Khanij Online portal for further. CHiMMS, GoCG";

                //                        //Modified by Avneesh on 12-04-2021
                //                        string templateid = "1307161883617239647";
                //                        SMSHttpPostClient.Main(UModel.MobileNo, message, templateid);


                //                        //SMSHttpPostClient.Main(UModel.MobileNo, message);


                //                    }
                //                    catch (Exception)
                //                    {

                //                    }
                //                    #endregion

                //                    #region Send Mail
                //                    try
                //                    {
                //                        MailService mail = new MailService();
                //                        mail.SendPaymentAwaitedMail(UModel, response.CLNT_TXN_REF);
                //                    }
                //                    catch (Exception)
                //                    {
                //                        TempData["AckMessage"] = "0";
                //                    }
                //                    #endregion
                //                }
                //            }
                //        }
                //    }
                //    #endregion
                //}
                //else if (response.CLNT_TXN_REF.StartsWith("MAP"))
                //{
                //    #region Daily Production payment
                //    string strMAPTXNID = response.CLNT_TXN_REF.Trim();
                //    string paymentStatus = response.TXN_STATUS;

                //    using (SqlCommand cmdupdate1 = new SqlCommand())
                //    {
                //        cmdupdate1.CommandText = "uspDailyProduction_Insertion";
                //        cmdupdate1.CommandType = System.Data.CommandType.StoredProcedure;

                //        cmdupdate1.Parameters.AddWithValue("@Check", "PaymentResponseCheck_Initiate");
                //        cmdupdate1.Parameters.AddWithValue("@MAPID", strMAPTXNID);
                //        cmdupdate1.Parameters.AddWithValue("@UserId", SessionWrapper.UserId);
                //        cmdupdate1.Parameters.AddWithValue("@ChallanNumber", response.TPSL_TXN_ID);
                //        cmdupdate1.Parameters.AddWithValue("@PaymentStatus", paymentStatus);


                //        using (DataTable dt = objDb.ExecuteStoreProcedure(cmdupdate1))
                //        {
                //            if (dt != null && dt.Rows.Count > 0)
                //            {
                //                UserMasterModel UModel = new UserMasterModel();

                //                UModel.EMailId = Convert.ToString(dt.Rows[0]["EmailID"]);
                //                //UModel.TotalVehiclesPayment = Convert.ToString(dt.Rows[0]["TotalPaidAmount"]);
                //                //UModel.VehicleCount = Convert.ToInt32(dt.Rows[0]["TotalDemandNoteCount"]);
                //                UModel.ApplicantName = Convert.ToString(dt.Rows[0]["ApplicantName"]);
                //                UModel.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                //                UModel.MobileNo = Convert.ToString(dt.Rows[0]["MobileNo"]);

                //                if (strPG_TxnStatus == "SUCCESS" || strPG_TxnStatusDesc.ToUpper().Contains("COMPLETED"))//Success
                //                {
                //                    #region Send SMS

                //                    try
                //                    {
                //                        string message = "Dear " + SessionWrapper.ApplicantName + Environment.NewLine + "Your payment for daily production has been proceed successfully and your payment status is " + response.TXN_STATUS
                //                                             + Environment.NewLine +
                //                                             "Your Transaction Reference Number is " + response.CLNT_TXN_REF + Environment.NewLine +
                //                                             "Use this for Future reference. Please login to Khanij Online portal for further. CHiMMS, GoCG";

                //                        //Modified by Avneesh on 12-04-2021
                //                        string templateid = "1307161883661883402";
                //                        SMSHttpPostClient.Main(UModel.MobileNo, message, templateid);


                //                        //SMSHttpPostClient.Main(UModel.MobileNo, message);

                //                    }
                //                    catch (Exception)
                //                    {
                //                    }
                //                    #endregion

                //                    #region Send Mail
                //                    try
                //                    {
                //                        MailService mail = new MailService();
                //                        mail.SendNonPermitPaymentMail(SessionWrapper.UserLoginId.ToString(), UModel.EMailId,
                //                                DateTime.Now.ToString("dd/MM/yyyy"), SessionWrapper.UserId.ToString(),
                //                                UModel.ApplicantName,
                //                                "Daily Production payment status is " + response.TXN_STATUS + " ",
                //                                Convert.ToString(response.TXN_AMT));

                //                    }
                //                    catch (Exception)
                //                    {
                //                        TempData["AckMessage"] = "0";
                //                    }
                //                    #endregion
                //                }
                //                else if (response.TXN_STATUS == "AWAITED" || strPG_TxnStatusDesc.ToUpper().Contains("PENDING") || strPG_TxnStatusDesc == "NEFT")//Awaited
                //                {
                //                    #region Send SMS
                //                    try
                //                    {
                //                        //string message = "Dear " + SessionWrapper.ApplicantName + Environment.NewLine + "Your payment for LOI has been credited successfully and your payment status is " + response.TXN_STATUS + " in Khanij Online System dated on " + System.DateTime.Now + " Please check your e-mail for details for Payment.";
                //                        string message = "Dear " + SessionWrapper.ApplicantName + Environment.NewLine + "Your payment for daily production has been proceed successfully and your payment status is " + response.TXN_STATUS
                //                                            + Environment.NewLine +
                //                                            "Your Transaction Reference Number is " + response.CLNT_TXN_REF + Environment.NewLine +
                //                                            "Use this for Future reference. Please login to Khanij Online portal for further. CHiMMS, GoCG";

                //                        //Modified by Avneesh on 12-04-2021
                //                        string templateid = "1307161883661883402";
                //                        SMSHttpPostClient.Main(UModel.MobileNo, message, templateid);


                //                        //SMSHttpPostClient.Main(UModel.MobileNo, message);

                //                    }
                //                    catch (Exception)
                //                    {

                //                    }
                //                    #endregion

                //                    #region Send Mail
                //                    try
                //                    {
                //                        MailService mail = new MailService();
                //                        mail.SendPaymentAwaitedMail(UModel, response.CLNT_TXN_REF);
                //                    }
                //                    catch (Exception)
                //                    {
                //                        TempData["AckMessage"] = "0";
                //                    }
                //                    #endregion
                //                }
                //            }
                //        }
                //    }
                //    #endregion
                //}
                //else if (response.CLNT_TXN_REF.StartsWith("FLIC"))
                //{
                //    #region Licensee Application First payment
                //    string strLICTXNID = response.CLNT_TXN_REF.Trim();
                //    string paymentStatus = response.TXN_STATUS;

                //    using (SqlCommand cmdupdate1 = new SqlCommand())
                //    {
                //        cmdupdate1.CommandText = "SP_FORM4";
                //        cmdupdate1.CommandType = System.Data.CommandType.StoredProcedure;

                //        cmdupdate1.Parameters.AddWithValue("@Check", "22");
                //        cmdupdate1.Parameters.AddWithValue("@PaymentRecieptId", strLICTXNID);
                //        cmdupdate1.Parameters.AddWithValue("@UserId", SessionWrapper.UserId);
                //        cmdupdate1.Parameters.AddWithValue("@ChallanNumber", response.TPSL_TXN_ID);
                //        cmdupdate1.Parameters.AddWithValue("@PaymentStatus", paymentStatus);


                //        using (DataTable dt = objDb.ExecuteStoreProcedure(cmdupdate1))
                //        {
                //            if (dt != null && dt.Rows.Count > 0)
                //            {
                //                UserMasterModel UModel = new UserMasterModel();

                //                UModel.EMailId = Convert.ToString(dt.Rows[0]["EmailID"]);
                //                //UModel.TotalVehiclesPayment = Convert.ToString(dt.Rows[0]["TotalPaidAmount"]);
                //                //UModel.VehicleCount = Convert.ToInt32(dt.Rows[0]["TotalDemandNoteCount"]);
                //                UModel.ApplicantName = Convert.ToString(dt.Rows[0]["ApplicantName"]);
                //                UModel.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                //                UModel.MobileNo = Convert.ToString(dt.Rows[0]["MobileNo"]);

                //                if (strPG_TxnStatus == "SUCCESS" || strPG_TxnStatusDesc.ToUpper().Contains("COMPLETED"))//Success
                //                {
                //                    #region Send SMS

                //                    try
                //                    {
                //                        string message = "Dear " + SessionWrapper.ApplicantName + Environment.NewLine + "Your payment has been proceed successfully and your payment status is " + response.TXN_STATUS
                //                                             + Environment.NewLine +
                //                                             "Your Transaction Reference Number is " + response.CLNT_TXN_REF + Environment.NewLine +
                //                                             "Use this for Future reference. Please login to Khanij Online portal for further. CHiMMS, GoCG";

                //                        //Modified by Avneesh on 12-04-2021
                //                        string templateid = "1307161883628029116";
                //                        SMSHttpPostClient.Main(UModel.MobileNo, message, templateid);


                //                        //SMSHttpPostClient.Main(UModel.MobileNo, message);

                //                    }
                //                    catch (Exception)
                //                    {
                //                    }
                //                    #endregion

                //                    #region Send Mail
                //                    try
                //                    {
                //                        MailService mail = new MailService();
                //                        mail.SendNonPermitPaymentMail(SessionWrapper.UserLoginId.ToString(), UModel.EMailId,
                //                                DateTime.Now.ToString("dd/MM/yyyy"), SessionWrapper.UserId.ToString(),
                //                                UModel.ApplicantName,
                //                                "payment status is " + response.TXN_STATUS + " ",
                //                                Convert.ToString(response.TXN_AMT));

                //                    }
                //                    catch (Exception)
                //                    {
                //                        TempData["AckMessage"] = "0";
                //                    }
                //                    #endregion
                //                }
                //                else if (response.TXN_STATUS == "AWAITED" || strPG_TxnStatusDesc.ToUpper().Contains("PENDING") || strPG_TxnStatusDesc == "NEFT")//Awaited
                //                {
                //                    #region Send SMS
                //                    try
                //                    {
                //                        //string message = "Dear " + SessionWrapper.ApplicantName + Environment.NewLine + "Your payment for LOI has been credited successfully and your payment status is " + response.TXN_STATUS + " in Khanij Online System dated on " + System.DateTime.Now + " Please check your e-mail for details for Payment.";
                //                        string message = "Dear " + SessionWrapper.ApplicantName + Environment.NewLine + "Your payment has been proceed successfully and your payment status is " + response.TXN_STATUS
                //                                            + Environment.NewLine +
                //                                            "Your Transaction Reference Number is " + response.CLNT_TXN_REF + Environment.NewLine +
                //                                            "Use this for Future reference. Please login to Khanij Online portal for further. CHiMMS, GoCG";

                //                        //Modified by Avneesh on 12-04-2021
                //                        string templateid = "1307161883628029116";
                //                        SMSHttpPostClient.Main(UModel.MobileNo, message, templateid);


                //                        //SMSHttpPostClient.Main(UModel.MobileNo, message);


                //                    }
                //                    catch (Exception)
                //                    {

                //                    }
                //                    #endregion

                //                    #region Send Mail
                //                    try
                //                    {
                //                        MailService mail = new MailService();
                //                        mail.SendPaymentAwaitedMail(UModel, response.CLNT_TXN_REF);
                //                    }
                //                    catch (Exception)
                //                    {
                //                        TempData["AckMessage"] = "0";
                //                    }
                //                    #endregion
                //                }
                //            }
                //        }
                //    }
                //    #endregion
                //}
                //else if (response.CLNT_TXN_REF.StartsWith("SEQL"))
                //{
                //    #region Licensee Application Security payment
                //    string strLICTXNID = response.CLNT_TXN_REF.Trim();
                //    string paymentStatus = response.TXN_STATUS;

                //    using (SqlCommand cmdupdate1 = new SqlCommand())
                //    {
                //        cmdupdate1.CommandText = "SP_FORM4";
                //        cmdupdate1.CommandType = System.Data.CommandType.StoredProcedure;

                //        cmdupdate1.Parameters.AddWithValue("@Check", "44");
                //        cmdupdate1.Parameters.AddWithValue("@PaymentRecieptId", strLICTXNID);
                //        cmdupdate1.Parameters.AddWithValue("@UserId", SessionWrapper.UserId);
                //        cmdupdate1.Parameters.AddWithValue("@ChallanNumber", response.TPSL_TXN_ID);
                //        cmdupdate1.Parameters.AddWithValue("@PaymentStatus", paymentStatus);


                //        using (DataTable dt = objDb.ExecuteStoreProcedure(cmdupdate1))
                //        {
                //            if (dt != null && dt.Rows.Count > 0)
                //            {
                //                UserMasterModel UModel = new UserMasterModel();

                //                UModel.EMailId = Convert.ToString(dt.Rows[0]["EmailID"]);
                //                //UModel.TotalVehiclesPayment = Convert.ToString(dt.Rows[0]["TotalPaidAmount"]);
                //                //UModel.VehicleCount = Convert.ToInt32(dt.Rows[0]["TotalDemandNoteCount"]);
                //                UModel.ApplicantName = Convert.ToString(dt.Rows[0]["ApplicantName"]);
                //                UModel.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                //                UModel.MobileNo = Convert.ToString(dt.Rows[0]["MobileNo"]);

                //                if (strPG_TxnStatus == "SUCCESS" || strPG_TxnStatusDesc.ToUpper().Contains("COMPLETED"))//Success
                //                {
                //                    #region Send SMS

                //                    try
                //                    {
                //                        string message = "Dear " + SessionWrapper.ApplicantName + Environment.NewLine + "Your payment has been proceed successfully and your payment status is " + response.TXN_STATUS
                //                                             + Environment.NewLine +
                //                                             "Your Transaction Reference Number is " + response.CLNT_TXN_REF + Environment.NewLine +
                //                                             "Use this for Future reference. Please login to Khanij Online portal for further. CHiMMS, GoCG";

                //                        //Modified by Avneesh on 12-04-2021
                //                        string templateid = "1307161883628029116";
                //                        SMSHttpPostClient.Main(UModel.MobileNo, message, templateid);


                //                        //SMSHttpPostClient.Main(UModel.MobileNo, message);
                //                    }
                //                    catch (Exception)
                //                    {
                //                    }
                //                    #endregion

                //                    #region Send Mail
                //                    try
                //                    {
                //                        MailService mail = new MailService();
                //                        mail.SendNonPermitPaymentMail(SessionWrapper.UserLoginId.ToString(), UModel.EMailId,
                //                                DateTime.Now.ToString("dd/MM/yyyy"), SessionWrapper.UserId.ToString(),
                //                                UModel.ApplicantName,
                //                                "payment status is " + response.TXN_STATUS + " ",
                //                                Convert.ToString(response.TXN_AMT));

                //                    }
                //                    catch (Exception)
                //                    {
                //                        TempData["AckMessage"] = "0";
                //                    }
                //                    #endregion
                //                }
                //                else if (response.TXN_STATUS == "AWAITED" || strPG_TxnStatusDesc.ToUpper().Contains("PENDING") || strPG_TxnStatusDesc == "NEFT")//Awaited
                //                {
                //                    #region Send SMS
                //                    try
                //                    {
                //                        //string message = "Dear " + SessionWrapper.ApplicantName + Environment.NewLine + "Your payment for LOI has been credited successfully and your payment status is " + response.TXN_STATUS + " in Khanij Online System dated on " + System.DateTime.Now + " Please check your e-mail for details for Payment.";
                //                        string message = "Dear " + SessionWrapper.ApplicantName + Environment.NewLine + "Your payment has been proceed successfully and your payment status is " + response.TXN_STATUS
                //                                            + Environment.NewLine +
                //                                            "Your Transaction Reference Number is " + response.CLNT_TXN_REF + Environment.NewLine +
                //                                            "Use this for Future reference. Please login to Khanij Online portal for further. CHiMMS, GoCG";

                //                        //Modified by Avneesh on 12-04-2021
                //                        string templateid = "1307161883628029116";
                //                        SMSHttpPostClient.Main(UModel.MobileNo, message, templateid);


                //                        //SMSHttpPostClient.Main(UModel.MobileNo, message);

                //                    }
                //                    catch (Exception)
                //                    {

                //                    }
                //                    #endregion

                //                    #region Send Mail
                //                    try
                //                    {
                //                        MailService mail = new MailService();
                //                        mail.SendPaymentAwaitedMail(UModel, response.CLNT_TXN_REF);
                //                    }
                //                    catch (Exception)
                //                    {
                //                        TempData["AckMessage"] = "0";
                //                    }
                //                    #endregion
                //                }
                //            }
                //        }
                //    }
                //    #endregion

                //}
                // }
                //  }

                #endregion

                #region User Model Session is empty hence Re-filled the session

                //if (Session["UserModel"] == null)
                //{
                //    try
                //    {
                //        LoginModel model = new LoginModel();

                //        using (SqlCommand cmdupdate = new SqlCommand())
                //        {
                //            cmdupdate.CommandText = "UserModelSessionFilled";

                //            cmdupdate.CommandType = System.Data.CommandType.StoredProcedure;
                //            cmdupdate.Parameters.AddWithValue("@Check", 1);
                //            cmdupdate.Parameters.AddWithValue("@CLNT_TXN_REF", response.CLNT_TXN_REF);
                //            using (DataTable dt = objDb.ExecuteStoreProcedure(cmdupdate))
                //            {
                //                if (dt != null && dt.Rows.Count > 0)
                //                {
                //                    model.UserName = Convert.ToString(dt.Rows[0]["USR_NAME"]);
                //                    model.Password = Convert.ToString(dt.Rows[0]["USR_PW"]);
                //                }
                //            }
                //        }

                //        using (var cmdSessionUpdate = new SqlCommand())
                //        {
                //            var remoteIp = Request.UserHostAddress;
                //            var localIp = Convert.ToString(Request.ServerVariables["LOCAL_ADDR"]);
                //            var browserInfo = Request.UserAgent;
                //            cmdSessionUpdate.CommandType = System.Data.CommandType.StoredProcedure;
                //            cmdSessionUpdate.CommandText = "UserModelSessionFilled";
                //            cmdSessionUpdate.Parameters.AddWithValue("@UserName", model.UserName);
                //            cmdSessionUpdate.Parameters.AddWithValue("@Password", model.Password);
                //            cmdSessionUpdate.Parameters.AddWithValue("@Check", 2);
                //            cmdSessionUpdate.Parameters.AddWithValue("@RemoteIp", remoteIp);
                //            cmdSessionUpdate.Parameters.AddWithValue("@LocalIp", localIp);
                //            cmdSessionUpdate.Parameters.AddWithValue("@UserAgent", browserInfo);

                //            using (DataTable dt = objDb.ExecuteStoreProcedure(cmdSessionUpdate))
                //            {
                //                if (dt != null && dt.Rows.Count > 0)
                //                {

                //                    SessionWrapper.IsUserLogin = true;
                //                    UserLoginSession objUser = new UserLoginSession();

                //                    objUser.UserId = Convert.ToInt32(dt.Rows[0]["UserId"]);
                //                    objUser.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                //                    objUser.Password = Convert.ToString(dt.Rows[0]["Password"]);
                //                    objUser.ApplicantName = Convert.ToString(dt.Rows[0]["ApplicantName"]);
                //                    objUser.UserType = Convert.ToString(dt.Rows[0]["UserType"]);
                //                    objUser.UserTypeId = Convert.ToInt32(dt.Rows[0]["UserTypeId"]);
                //                    objUser.RoleId = Convert.ToInt32(dt.Rows[0]["RoleId"]);
                //                    objUser.UserLoginId = Convert.ToInt32(dt.Rows[0]["UserLoginId"]);
                //                    objUser.MineralId = !string.IsNullOrEmpty(dt.Rows[0]["MineralId"].ToString()) ? Convert.ToInt32(dt.Rows[0]["MineralId"]) : 0;
                //                    objUser.MineralName = Convert.ToString(dt.Rows[0]["MineralName"]);
                //                    objUser.MineralTypeName = Convert.ToString(dt.Rows[0]["MineralTypeName"]);

                //                    objUser.IsPasswordChange = Convert.ToInt32(dt.Rows[0]["IsPasswordChange"]);
                //                    objUser.UserRoleInfo = Convert.ToString(dt.Rows[0]["UserRoleInfo"]);
                //                    objUser.MobileNumber = Convert.ToString(dt.Rows[0]["MobileNo"]);
                //                    objUser.EmailID = Convert.ToString(dt.Rows[0]["EMailId"]);

                //                    objUser.IsSubUser = Convert.ToBoolean(dt.Rows[0]["IsSub"]);
                //                    objUser.SubUserID = Convert.ToInt32(dt.Rows[0]["SubUserID"]);
                //                    objUser.TPOffline = Convert.ToInt32(dt.Rows[0]["TPOffline"]);
                //                    objUser.DistrictName = Convert.ToString(dt.Rows[0]["DistrictName"]);
                //                    if (!(dt.Rows[0]["LeaseStatusId"] is DBNull))
                //                        objUser.LeaseStatusId = Convert.ToInt32(dt.Rows[0]["LeaseStatusId"]);
                //                    if (!(dt.Rows[0]["LesseeType"] is DBNull))
                //                        objUser.LesseeStatus = Convert.ToString(dt.Rows[0]["LesseeType"]);

                //                    if (!(dt.Rows[0]["NoticeFilePath"] is DBNull))
                //                        objUser.NoticeFilePath = Convert.ToString(dt.Rows[0]["NoticeFilePath"]);


                //                    objUser.IsSidePanelHide = Convert.ToString(dt.Rows[0]["LesseeLicensseeNoticeRplPendingCount"]);
                //                    objUser.IsLowGradeLimestone = Convert.ToInt32(dt.Rows[0]["IsLowGradeLimestone"]);
                //                    if (!(dt.Rows[0]["SMS_SENT"] is DBNull))
                //                        objUser.SMS_SENT = Convert.ToString(dt.Rows[0]["SMS_SENT"]);
                //                    if (!(dt.Rows[0]["EMAIL_SENT"] is DBNull))
                //                        objUser.EMAIL_SENT = Convert.ToString(dt.Rows[0]["EMAIL_SENT"]);
                //                    Session["UserModel"] = objUser;

                //                    CHiMMS_MVC.Areas.Admin.Models.MenuGeneratorModel objmodel = new CHiMMS_MVC.Areas.Admin.Models.MenuGeneratorModel();

                //                    using (DataSet ds = objmodel.GetUserWiseMenuData(objUser.MineralId, objUser.MineralName))
                //                    {
                //                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                //                        {
                //                            if (ds.Tables[0].Rows.Count == 1 && Convert.ToString(ds.Tables[0].Rows[0]["MenuName"]) == "e-Transit Pass")
                //                            {
                //                                objUser.IsOnlyTP = true;
                //                                Session["UserModel"] = objUser;
                //                            }
                //                            else
                //                            {
                //                                objUser.IsOnlyTP = false;
                //                                Session["UserModel"] = objUser;
                //                            }
                //                        }

                //                        Session["MenuModel"] = ds;
                //                    }
                //                }
                //            }
                //        }

                //    }
                //    catch (Exception ex)
                //    {

                //    }

                //}

                #endregion


                ViewBag.PaymentDetails = objList;
                //Session["isNEFT"] = null;
                //Session["Bank"] = null;
                return View(response);
                //    }
            }
            catch (Exception ex) { }

            ViewBag.PaymentDetails = objList;

            return View();

        }



        #endregion--------------------------------------------------------------------

        public void ICICINETGetPGRespnseData(string[] parameters)
        {
            string[] strGetMerchantParamForCompare;
            strPG_TxnDateTime = System.DateTime.Now.ToString();
            strArrPG_TxnDateTime = strPG_TxnDateTime.Split(' ');
            strPG_TxnDate = Convert.ToString(strArrPG_TxnDateTime[0]);
            strPG_TxnTime = Convert.ToString(strArrPG_TxnDateTime[1]);
            for (int i = 0; i < parameters.Length; i++)
            {
                strGetMerchantParamForCompare = parameters[i].ToString().Split('=');
                if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "REF_NO")
                {
                    strPG_ClintTxnRefNo = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "AMOUNT")
                {
                    strPG_TxnAmount = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "PAYMODE")
                {
                    strPG_Paymode = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "ICICI_REF_NO")
                {
                    strPG_TPSLTxnID = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "STATUS_DESC")
                {
                    strPG_TxnStatus = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "STATUS")
                {
                    if (Convert.ToString(strGetMerchantParamForCompare[1]).ToUpper() == "S")
                    {
                        strPG_TxnStatusDesc = "SUCCESS";
                    }
                    else
                    {
                        strPG_TxnStatusDesc = Convert.ToString(strGetMerchantParamForCompare[1]);
                    }

                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "GIB_TXN_ID")
                {
                    GIB_TXN_NO = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "PRN")
                {
                    string metaData = Convert.ToString(strGetMerchantParamForCompare[1]);
                    string[] obj = strGetMerchantParamForCompare[1].Split(',');

                    if (obj != null && obj.Length > 0)
                    {
                        for (int j = 0; j < obj.Length; j++)
                        {
                            try
                            {
                                FinalPaymentModel objModel = new FinalPaymentModel();
                                objModel.PaymentAmount = Convert.ToString(obj[j].Split(':')[1]).ToString();
                                objModel.PaymentType = Convert.ToString(obj[j].Split(':')[0]).Trim();
                                objList.Add(objModel);

                                if (Convert.ToString(obj[j].Split('~')[0]).Trim() == "KO01" || Convert.ToString(obj[j].Split('~')[0]).Trim() == "KO02")
                                {
                                    PayableRoyalty = Convert.ToString(obj[j].Split(':')[1]).ToString();
                                }
                                else if (Convert.ToString(obj[j].Split(':')[0]).Trim() == "KO03")
                                {
                                    TCS = Convert.ToString(obj[j].Split(':')[1]).ToString();
                                }
                                else if (Convert.ToString(obj[j].Split(':')[0]).Trim() == "KO04")
                                {
                                    Cess = Convert.ToString(obj[j].Split(':')[1]).ToString();
                                }
                                else if (Convert.ToString(obj[j].Split(':')[0]).Trim() == "KO05")
                                {
                                    eCess = Convert.ToString(obj[j].Split(':')[1]).ToString();
                                }
                                else if (Convert.ToString(obj[j].Split(':')[0]).Trim() == "DMF")
                                {
                                    DMF = Convert.ToString(obj[j].Split(':')[1]).ToString();
                                }
                                else if (Convert.ToString(obj[j].Split(':')[0]).Trim() == "KO31")
                                {
                                    NMET = Convert.ToString(obj[j].Split(':')[1]).ToString();
                                }
                                else if (Convert.ToString(obj[j].Split(':')[0]).Trim() == "KO19")
                                {
                                    MonthlyPeriodicAmount = Convert.ToString(obj[j].Split(':')[1]).ToString();
                                }
                                else if (Convert.ToString(obj[j].Split(':')[0]).Trim() == "REF_NO")
                                {
                                    strPG_ClintTxnRefNo = Convert.ToString(obj[j].Split(':')[1]).ToString();
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
        }
        public void ICICIGetPGRespnseData(string[] parameters)
        {
            string[] strGetMerchantParamForCompare;
            strPG_TxnDateTime = System.DateTime.Now.ToString();
            strArrPG_TxnDateTime = strPG_TxnDateTime.Split(' ');
            strPG_TxnDate = Convert.ToString(strArrPG_TxnDateTime[0]);
            strPG_TxnTime = Convert.ToString(strArrPG_TxnDateTime[1]);
            for (int i = 0; i < parameters.Length; i++)
            {
                strGetMerchantParamForCompare = parameters[i].ToString().Split('=');
                if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "REF_NO")
                {
                    strPG_ClintTxnRefNo = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "AMOUNT")
                {
                    strPG_TxnAmount = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "PAYMODE")
                {
                    strPG_Paymode = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "ICICI_REF_NO")
                {
                    strPG_TPSLTxnID = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "STATUS_DESC")
                {
                    strPG_TxnStatus = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "STATUS")
                {
                    strPG_TxnStatusDesc = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "GIB_TXN_ID")
                {
                    GIB_TXN_NO = Convert.ToString(strGetMerchantParamForCompare[1]);
                }




                //else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TPSL_TXN_TIME")
                //{
                //    strPG_TxnDateTime = Convert.ToString(strGetMerchantParamForCompare[1]);
                //    strArrPG_TxnDateTime = strPG_TxnDateTime.Split(' ');
                //    strPG_TxnDate = Convert.ToString(strArrPG_TxnDateTime[0]);
                //    strPG_TxnTime = Convert.ToString(strArrPG_TxnDateTime[1]);
                //}
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "SRC_ITC")
                {
                    string metaData = Convert.ToString(strGetMerchantParamForCompare[1]);
                    string[] obj = strGetMerchantParamForCompare[1].Split(',');

                    if (obj != null && obj.Length > 0)
                    {
                        for (int j = 0; j < obj.Length; j++)
                        {
                            try
                            {
                                FinalPaymentModel objModel = new FinalPaymentModel();
                                objModel.PaymentAmount = Convert.ToString(obj[j].Split(':')[1]).ToString();
                                objModel.PaymentType = Convert.ToString(obj[j].Split(':')[0]).Trim();
                                objList.Add(objModel);

                                //if (Convert.ToString(obj[j].Split('~')[0]).Trim() == "PayableRoyalty")
                                //{
                                //    PayableRoyalty = Convert.ToString(obj[j].Split('~')[1]).ToString();
                                //}
                                //else if (Convert.ToString(obj[j].Split('~')[0]).Trim() == "TCS")
                                //{
                                //    TCS = Convert.ToString(obj[j].Split('~')[1]).ToString();
                                //}
                                //else if (Convert.ToString(obj[j].Split('~')[0]).Trim() == "Cess")
                                //{
                                //    Cess = Convert.ToString(obj[j].Split('~')[1]).ToString();
                                //}
                                //else if (Convert.ToString(obj[j].Split('~')[0]).Trim() == "eCess")
                                //{
                                //    eCess = Convert.ToString(obj[j].Split('~')[1]).ToString();
                                //}
                                //else if (Convert.ToString(obj[j].Split('~')[0]).Trim() == "DMF")
                                //{
                                //    DMF = Convert.ToString(obj[j].Split('~')[1]).ToString();
                                //}
                                //else if (Convert.ToString(obj[j].Split('~')[0]).Trim() == "NMET")
                                //{
                                //    NMET = Convert.ToString(obj[j].Split('~')[1]).ToString();
                                //}
                                //else if (Convert.ToString(obj[j].Split('~')[0]).Trim() == "Monthly Periodic Amount")
                                //{
                                //    MonthlyPeriodicAmount = Convert.ToString(obj[j].Split('~')[1]).ToString();
                                //}


                                if (Convert.ToString(obj[j].Split(':')[0]).Trim() == "KO01" || Convert.ToString(obj[j].Split(':')[0]).Trim() == "KO02")
                                {
                                    PayableRoyalty = Convert.ToString(obj[j].Split(':')[1]).ToString();
                                }
                                else if (Convert.ToString(obj[j].Split(':')[0]).Trim() == "KO03")
                                {
                                    TCS = Convert.ToString(obj[j].Split(':')[1]).ToString();
                                }
                                else if (Convert.ToString(obj[j].Split(':')[0]).Trim() == "KO04")
                                {
                                    Cess = Convert.ToString(obj[j].Split(':')[1]).ToString();
                                }
                                else if (Convert.ToString(obj[j].Split(':')[0]).Trim() == "KO05")
                                {
                                    eCess = Convert.ToString(obj[j].Split(':')[1]).ToString();
                                }
                                else if (Convert.ToString(obj[j].Split(':')[0]).Trim() == "DMF")
                                {
                                    DMF = Convert.ToString(obj[j].Split(':')[1]).ToString();
                                }
                                else if (Convert.ToString(obj[j].Split(':')[0]).Trim() == "KO31")
                                {
                                    NMET = Convert.ToString(obj[j].Split(':')[1]).ToString();
                                }
                                else if (Convert.ToString(obj[j].Split(':')[0]).Trim() == "KO19")
                                {
                                    MonthlyPeriodicAmount = Convert.ToString(obj[j].Split(':')[1]).ToString();
                                }



                            }
                            catch { }
                        }
                    }
                }
            }
        }
    }
}
