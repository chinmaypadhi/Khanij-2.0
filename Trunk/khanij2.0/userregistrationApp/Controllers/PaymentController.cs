using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using userregistrationApp.ActionFilter;
using userregistrationApp.Models.EncryptDecrypt;
using userregistrationApp.Models.MailService;
using userregistrationApp.Models.PaymentResponses;
using userregistrationApp.Models.SBIEncryptDecryptKey;
using userregistrationApp.Models.SMSService;
using userregistrationApp.Web;
using userregistrationEF;

namespace userregistrationApp.Controllers
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
        MessageEF messageEF = new MessageEF();
        PaymentTransaction response = new PaymentTransaction();
        public PaymentController(IPaymentResponseModel paymentResponseModel, IsbiIncriptDecript isbiIncriptDecript,
            ISMSModel sMSModel, IMailModel mailModel)
        {
            this.paymentResponseModel = paymentResponseModel;
            this.isbiIncriptDecript = isbiIncriptDecript;
            this.sMSModel = sMSModel;
            this.mailModel = mailModel;
        }

        [SkipImportantTask]
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
        public IActionResult PaymentResponse()
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);

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

                #endregion

                #region Payment Data Updated on specific request 
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

                response.UserId = profile.UserId;
                response.PaymentResponseID = strPaymentResponseID;
                messageEF = paymentResponseModel.AddPaymentResponse(response);
                #endregion

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
                }

                #endregion

                ViewBag.PaymentDetails = objList;
                return View(response);

            }
            catch (Exception ex) { }

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
    }
}
