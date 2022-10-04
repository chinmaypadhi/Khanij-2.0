using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationEF;
using IntegrationApp.Areas.Payment.Models.SBIPayment;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using DotNetIntegrationKit;
using SBICINBPaymentStatus;
using ICICINEFTPaymentStatus;
using System.Net;
using MailKit;
using IntegrationApp.Helper;
using Microsoft.AspNetCore.Http;
using IntegrationApp.Web;
using Newtonsoft.Json;

namespace IntegrationApp.Areas.Payment.Controllers
{
    [Area("Payment")]
    public class PaymentRequestController : Controller
    {
        string CHALLAN_NO = string.Empty;
        string CHALLAN_INITIATE_DATE = string.Empty;
        string CHALLAN_SETTLEMENT_DATE = string.Empty;
        string UTR_NUMBER = string.Empty;
        string ICICI_TXN_NO = string.Empty;

        string strPG_TxnStatus = string.Empty;
        string[] strSplitDecryptedResponse;
        string CLNT_TXN_REF = string.Empty;
        string strPG_TxnAmount = string.Empty;
        string strPG_TRANSACTIONDATE = string.Empty;
        MessageEF objMSmodel = new MessageEF();
        ISBIPaymentModel _objSBIModel;
        string OutputResult = "";
        private IConfiguration configuration;
        string ResSBIENCKeyPath = "";
        public PaymentRequestController(ISBIPaymentModel objSBIModel, IConfiguration _configuration)
        {
            _objSBIModel = objSBIModel;
            this.configuration = _configuration;
            ResSBIENCKeyPath = configuration.GetSection("Path").GetSection("SBIENCKey").Value;
        }
        //public PaymentRequestController()
        //{ }
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
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TRANSACTION_DATE")
                {
                    strPG_TRANSACTIONDATE = Convert.ToString(strGetMerchantParamForCompare[1]);
                }

            }
        }
        //public bool InsertPaymentRequest(string RequestType, string MerchantCode, string MerchantTxnRefNumber, string ITC, string Amount, string CurrencyCode,
        //    string UniqueCustomerId, string ReturnURL, string S2SReturnURL, string TPSLTxnID, string ShoppingCartDetails, string txnDate, string Email,
        //    string MobileNumber, string BankCode, string CustomerName, string PropertyPath, string PaymentEncryptedData)
       [HttpGet]
        public bool InsertPaymentRequest()
        {
            //UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            PaymentEF payment = JsonConvert.DeserializeObject<PaymentEF>(TempData["payment"] as string);
            PaymentEF model = new PaymentEF();
            model.PAYMENTFOR = 0;
            model.UserId = 83; //Convert.ToInt32(profile.UserId); 
            model.RequestType = payment.RequestType;
            model.MerchantCode = payment.MerchantCode;
            model.MerchantTxnRefNumber = payment.MerchantTxnRefNumber;
            model.ITC = payment.ITC;
            model.AMOUNT = payment.AMOUNT;
            model.Currencycode = payment.Currencycode;
            model.UniqueCustomerID = payment.UniqueCustomerID;
            model.returnURL = payment.returnURL;
            model.S2SReturnURL = payment.S2SReturnURL;
            model.TPSLTXNID = payment.TPSLTXNID;
            model.Shoppingcartdetails = payment.Shoppingcartdetails;
            model.TxnDate = payment.TxnDate;
            model.Email = payment.Email;
            model.MobileNo = payment.MobileNo;
            model.BankCode = payment.BankCode;
            model.CustomerName = payment.CustomerName;
            model.PropertyPath = payment.PropertyPath;
            model.PaymentEncryptedData = payment.PaymentEncryptedData;
            model.PaymentModeString = "NET-BANKING";
            objMSmodel = _objSBIModel.InsertPaymentRequest(model);
            OutputResult = objMSmodel.Satus;
            return (Convert.ToInt32(OutputResult) > 0 ? true : false);
            //DataConnection objDb = new DataConnection();


            //using (SqlCommand cmd = new SqlCommand())
            //{
            //    cmd.CommandText = "InsertUpdatePaymentRecords";
            //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@PAYMENTFOR", 0);
            //    cmd.Parameters.AddWithValue("@UserId", SessionWrapper.UserId);
            //    cmd.Parameters.AddWithValue("@RequestType", RequestType);
            //    cmd.Parameters.AddWithValue("@MerchantCode", MerchantCode);
            //    cmd.Parameters.AddWithValue("@MerchantTxnRefNumber", MerchantTxnRefNumber);
            //    cmd.Parameters.AddWithValue("@ITC", ITC);
            //    cmd.Parameters.AddWithValue("@Amount", Amount);
            //    cmd.Parameters.AddWithValue("@CurrencyCode", CurrencyCode);
            //    cmd.Parameters.AddWithValue("@UniqueCustomerID", UniqueCustomerId);
            //    cmd.Parameters.AddWithValue("@ReturnUrl", ReturnURL);
            //    cmd.Parameters.AddWithValue("@S2SReturnURL", S2SReturnURL);
            //    cmd.Parameters.AddWithValue("@TPSLTXNID", TPSLTxnID);
            //    cmd.Parameters.AddWithValue("@Shoppingcartdetails", ShoppingCartDetails);
            //    cmd.Parameters.AddWithValue("@TxnDate", txnDate);
            //    cmd.Parameters.AddWithValue("@Email", Email);

            //    cmd.Parameters.AddWithValue("@MobileNo", MobileNumber);
            //    cmd.Parameters.AddWithValue("@Bankcode", BankCode);
            //    cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
            //    cmd.Parameters.AddWithValue("@PropertyPath", PropertyPath);
            //    cmd.Parameters.AddWithValue("@PaymentEncryptedData", PaymentEncryptedData);
            //    cmd.Parameters.AddWithValue("@PaymentMode", "NET-BANKING");

            //    return objDb.InsertData(cmd);
            //}
        }

        public bool InsertPaymentRequest(string RequestType, string MerchantCode, string MerchantTxnRefNumber, string ITC, string Amount, string CurrencyCode,
            string UniqueCustomerId, string ReturnURL, string S2SReturnURL, string TPSLTxnID, string ShoppingCartDetails, string txnDate, string Email,
            string MobileNumber, string BankCode, string CustomerName, string PropertyPath, string PaymentEncryptedData, string PaymentMode)
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
            model.PaymentModeString = PaymentMode;

            objMSmodel = _objSBIModel.InsertPaymentRequest(model);
            OutputResult = objMSmodel.Satus;
            return (Convert.ToInt32(OutputResult) > 0 ? true : false);

        }


        #region SBI Decryption and Bifurcation


        // Convert.ToString(ConfigurationManager.AppSettings["SBIENCKey"]);
        string Encrypt(string textToEncrypt)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Mode = CipherMode.CBC;
            rijndaelCipher.Padding = PaddingMode.PKCS7;
            rijndaelCipher.KeySize = 0x80;
            rijndaelCipher.BlockSize = 0x80;
            byte[] pwdBytes = GetFileBytes(ResSBIENCKeyPath);
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


        string Decrypt(string textToDecrypt)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Mode = CipherMode.CBC;
            rijndaelCipher.Padding = PaddingMode.PKCS7;
            rijndaelCipher.KeySize = 0x80;
            rijndaelCipher.BlockSize = 0x80;
            byte[] encryptedData = Convert.FromBase64String(textToDecrypt);
            byte[] pwdBytes = GetFileBytes(ResSBIENCKeyPath);
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

        public void SBINETGetPGRespnseData(string[] parameters)
        {
            try
            {
                string[] strGetMerchantParamForCompare;

                for (int i = 0; i < parameters.Length; i++)
                {
                    strGetMerchantParamForCompare = parameters[i].ToString().Split('=');
                    if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TXSTATUSDESC")
                    {
                        strPG_TxnStatus = Convert.ToString(strGetMerchantParamForCompare[1]);
                    }
                }
            }
            catch (Exception Exception)
            {
            }

        }

        #endregion

        protected string GetMD5Hash(string name)
        {

            MD5 md5 = new MD5CryptoServiceProvider();
            UTF8Encoding encode = new UTF8Encoding();
            byte[] ba = md5.ComputeHash(encode.GetBytes(name));
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public string PaymentStatusFromGateway(string id, string PaymentType)
        {
            string OutputResult = string.Empty;
            PaymentResult objTotalAppl = new PaymentResult();
            PaymentEF model = new PaymentEF();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            if (!string.IsNullOrEmpty(id))
            {

                String response = string.Empty;
                String strResponse = response.ToUpper();
                RequestURL objRequestURL = new RequestURL();
                string permitType = string.Empty;

                if (PaymentType == "VP")
                {
                    permitType = id;
                }
                else if (PaymentType == "CVP")
                {
                    permitType = id;
                }

                else
                {
                    permitType = PaymentType + id;
                }

                string BankTPSLId = string.Empty;
                model.UserId = Convert.ToInt32(profile.UserId);
                model.MerchantTxnRefNumber = permitType;
                model.PaymentType = PaymentType;
                objTotalAppl = _objSBIModel.PaymentStatusReport(model);
                //using (SqlCommand cmd = new SqlCommand())
                //{
                //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //    cmd.CommandText = "getPaymentStatusReport";
                //    cmd.Parameters.AddWithValue("@MerchantTxnRefNumber", permitType);
                //    cmd.Parameters.AddWithValue("@UserId", SessionWrapper.UserId);
                //    cmd.Parameters.AddWithValue("@PaymentTYpe", PaymentType);
                //DataConnection objDb = new DataConnection();
                //using (DataSet ds = objDb.getDataBy_SqlCommand_CB(cmd))
                //{
                //    if (ds != null && ds.Tables.Count > 0)
                //    {
                if (objTotalAppl != null && objTotalAppl.TransLst.Count > 0)
                {
                    //DataTable dt = ds.Tables[0];
                    //if (dt != null && dt.Rows.Count > 0)
                    foreach (var app in objTotalAppl.TransLst)

                    {
                        #region SBI Verification
                        if (app.BankCode == "SBI")
                        {

                            try
                            {
                                DoubleVerifyMerchantServicePortTypeClient objSBI = new DoubleVerifyMerchantServicePortTypeClient();
                                var CLINET_TXN_NO = app.CLINETTXNNO;
                                var AMOUNT = app.AMOUNT;

                                var PostRequest = "CLNT_TXN_NO=" + CLINET_TXN_NO + "|TXN_AMOUNT=" + AMOUNT;

                                String Result = GetMD5Hash(PostRequest);
                                string str1 = PostRequest + "|checkSum=" + Result;
                                string SBIPostRequest = Encrypt(str1) + "^MINERAL_DEPT";


                                string str = objSBI.DoubleVerification(SBIPostRequest);

                                response = Decrypt(str);
                                strSplitDecryptedResponse = response.Split('|');
                                GetPGRespnseData(strSplitDecryptedResponse);
                            }
                            catch (Exception ex)
                            {

                            }


                        }
                        #endregion


                        #region ICICI Verifaction
                        else if (app.BankCode == "ICICI")
                        {

                            #region CIB online


                            if (app.BANK_PAY_ID.ToString() == "0" || string.IsNullOrEmpty(app.BANK_PAY_ID.ToString())) // we received 0 when make online transaction using CIB
                            {

                                //// Follwoing code for NetBanking
                                ///ResSBIENCKeyPath = configuration.GetSection("Path").GetValue<string>("CutOffDate");
                                var PID = configuration.GetSection("Path").GetValue<string>("ICICIPID");


                                string str = app.ICICIRESPONSE;

                                strSplitDecryptedResponse = str.Split('&');

                                string metaData = string.Empty;
                                if (string.IsNullOrEmpty(str))
                                {
                                    metaData = app.metaData + ",REF_NO:" + permitType;
                                }
                                else
                                {
                                    strSplitDecryptedResponse = str.Split('&');

                                    string[] strGetMerchantParamForCompare;

                                    for (int i = 0; i < strSplitDecryptedResponse.Length; i++)
                                    {
                                        strGetMerchantParamForCompare = strSplitDecryptedResponse[i].ToString().Split('=');
                                        if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "PRN")
                                        {
                                            metaData = Convert.ToString(strGetMerchantParamForCompare[1]);
                                        }
                                    }
                                }


                                // https://cibnextcug.icicibank.com/corp/BANKAWAY?Action.ShoppingMall.Login.Init=Y&BankId=ICI&USER_LANG_ID=001&AppType=corporate&UserType=2?ShowOnSamePage=Y&MD=V&PID=000000001241&PRN=KO01:980.00,KO58:294.00,KO31:19.60,KO19:1050000.00,REF_NO:BP81&ITC=41270000&AMT=11.00&CRN=INR&PMT_DATE=2017-05-29&BID=&RU=http://localhost:2522/Payment/PaymentResponse

                                var ICICIreqString = "Action.ShoppingMall.Login.Init=Y&BankId=ICI&USER_LANG_ID=001&AppType=corporate&UserType=2?ShowOnSamePage=Y&MD=V&PID=" + PID + "&PRN=" + metaData + "&ITC=41270000&AMT=" + app.AMOUNT + "&CRN=INR&PMT_DATE=" + app.TxnDate + "&BID=&RU=" + configuration.GetSection("Path").GetValue<string>("ReturnUrl");
                                var ICICINETBankingURL = configuration.GetSection("Path").GetValue<string>("ICICITPSLService") + ICICIreqString;

                                OutputResult = ICICINETBankingURL;

                                return OutputResult;



                            }
                            #endregion

                            #region NEFT/RTGS
                            else
                            {

                                DateTime CutOffDate = Convert.ToDateTime(configuration.GetSection("Path").GetValue<string>("CutOffDate"));

                                // !String.IsNullOrEmpty(dt.Rows[i]["AcceptRejectOn"].ToString()) ? Convert.ToDateTime(dt.Rows[i]["AcceptRejectOn"]).ToString("dd/MM/yyyy") : "";
                                if ((!String.IsNullOrEmpty(app.TxnDate) ? Convert.ToDateTime(app.TxnDate) : System.DateTime.Now.Date) <= CutOffDate)
                                {

                                    #region Live icici bank code - Tech Process  for verification
                                    try
                                    {



                                        StatusServiceSoapClient objService = new StatusServiceSoapClient();
                                        var cln = app.CLINETTXNNO;
                                        var amt = app.AMOUNT;
                                        var status = objService.GetRefNoTrnStatus(Convert.ToString(configuration.GetSection("Path").GetValue<string>("TPSLPGMERID")), cln, amt, "NEFT");
                                        var strSplitDecryptedResponse = status.Split('|');
                                        // var strSplitSRC_ITC = strSplitDecryptedResponse[6].Split(',');
                                        string strPG_TxnStatusDesc = string.Empty;

                                        string[] strGetMerchantParamForCompare;

                                        for (int i = 0; i < strSplitDecryptedResponse.Length; i++)
                                        {
                                            strGetMerchantParamForCompare = strSplitDecryptedResponse[i].ToString().Split('=');
                                            if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "STATUS_DESC")
                                            {
                                                strPG_TxnStatus = Convert.ToString(strGetMerchantParamForCompare[1]);
                                            }
                                            else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "STATUS")
                                            {
                                                strPG_TxnStatusDesc = Convert.ToString(strGetMerchantParamForCompare[1]);
                                            }
                                            else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TXN_AMT")
                                            {
                                                strPG_TxnAmount = Convert.ToString(strGetMerchantParamForCompare[1]);
                                            }
                                        }

                                        if (!string.IsNullOrEmpty(strPG_TxnStatus) && strPG_TxnStatus.ToUpper() == "SUCCESS")
                                        {
                                            response = strPG_TxnStatus;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        response = "ERROR";
                                    }

                                    //  }
                                    #endregion
                                }
                                else
                                {
                                    #region GIB_ICICI bank Code for Verification
                                    try
                                    {

                                        var GIB_cln = app.CLINETTXNNO;
                                        var GIB_amt = app.AMOUNT;
                                        //    var GIB_Varification = "http://10.50.75.12:9095/corp/AuthenticationController?FORMSGROUP_ID__=AuthenticationFG&__START_TRAN_FLAG__=Y&FG_BUTTONS__=LOAD&ACTION.LOAD=Y&AuthenticationFG.LOGIN_FLAG=1&BANK_ID=ICI&JS_ENABLED_FLAG=Y&ITC=00000015&PRN=11&CRN=INR&IS_GIB_SESSION=Y&IS_CONSOLIDATED_VERIFICATION=N&CATEGORY_ID=264&MD=V&PID=220&STATFLG=H&Paymode=NEFT";
                                        var GIB_Varification = " https://gibtax.icicibank.com/corp/AuthenticationController?FORMSGROUP_ID__=AuthenticationFG&__START_TRAN_FLAG__=Y&FG_BUTTONS__=LOAD&ACTION.LOAD=Y&AuthenticationFG.LOGIN_FLAG=1&BANK_ID=ICI&JS_ENABLED_FLAG=Y&ITC=00000015&PRN=11&CRN=INR&IS_GIB_SESSION=Y&IS_CONSOLIDATED_VERIFICATION=N&MD=V&STATFLG=H&PID=220&Paymode=NEFT";
                                        var GIB_Request = GIB_Varification + "&REF_NO=" + GIB_cln + "&AMT=" + GIB_amt;

                                        WebClient client = new WebClient();
                                        client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                                        Stream data = client.OpenRead(GIB_Request);
                                        StreamReader reader = new StreamReader(data);
                                        string GIB_Response = reader.ReadToEnd();
                                        string strPG_TxnStatusDesc = GIB_Response;
                                        var strSplitDecryptedResponse = GIB_Response.Split('|');



                                        //Merchant_Code=MDGC|Amount=18.00|Merchant_ref_no=BP1505
                                        //|Challan_No=MDGC180423000001|Transaction_Status=P|Initiation_Date=28-01-2013 16:36:45
                                        //|Transaction_Date=28-01-2013 16:36:45|Settlement_Date=28-01-2013 16:36:45
                                        //|Paymode=ONLINE|UTR_number=|ICICI_Txn_no=1


                                        // var strSplitSRC_ITC = strSplitDecryptedResponse[6].Split(',');



                                        string[] strGetMerchantParamForCompare;

                                        for (int i = 0; i < strSplitDecryptedResponse.Length; i++)
                                        {
                                            strGetMerchantParamForCompare = strSplitDecryptedResponse[i].ToString().Split('=');
                                            if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TRANSACTION_STATUS")
                                            {
                                                if (Convert.ToString(strGetMerchantParamForCompare[1]) == "P") // Pending
                                                {
                                                    strPG_TxnStatus = "PENDING";

                                                }
                                                else if (Convert.ToString(strGetMerchantParamForCompare[1]) == "R") // Received
                                                {
                                                    strPG_TxnStatus = "SUCCESS";

                                                }
                                                else if (Convert.ToString(strGetMerchantParamForCompare[1]) == "S") //  SETTELLED
                                                {
                                                    strPG_TxnStatus = "SUCCESS";

                                                }
                                                else // Expired
                                                {
                                                    strPG_TxnStatus = "FAILED";

                                                }

                                            }
                                            else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "CHALLAN_NO")
                                            {
                                                CHALLAN_NO = Convert.ToString(strGetMerchantParamForCompare[1]);
                                            }
                                            else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "INITIATION_DATE")
                                            {
                                                CHALLAN_INITIATE_DATE = Convert.ToString(strGetMerchantParamForCompare[1]);
                                            }
                                            else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "TRANSACTION_DATE")
                                            {
                                                strPG_TRANSACTIONDATE = Convert.ToString(strGetMerchantParamForCompare[1]);
                                            }
                                            else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "SETTLEMENT_DATE")
                                            {
                                                CHALLAN_SETTLEMENT_DATE = Convert.ToString(strGetMerchantParamForCompare[1]);
                                            }
                                            else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "ICICI_TXN_NO")
                                            {
                                                ICICI_TXN_NO = Convert.ToString(strGetMerchantParamForCompare[1]);
                                            }
                                            else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "UTR_NUMBER")
                                            {
                                                UTR_NUMBER = Convert.ToString(strGetMerchantParamForCompare[1]);
                                            }
                                        }

                                        if (!string.IsNullOrEmpty(strPG_TxnStatus) && strPG_TxnStatus.ToUpper() == "SUCCESS")
                                        {
                                            response = strPG_TxnStatus;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        response = "ERROR";
                                    }


                                    #endregion
                                }
                            }
                            #endregion
                        }
                        #endregion


                        #region HDFC Verification
                        else if (app.BankCode == "HDFC")
                        {

                        }

                        #endregion

                        #region payment updation

                        if (string.IsNullOrEmpty(response) == true || response.ToUpper().StartsWith("ERROR"))
                        {

                            #region if no payment response
                            model.MerchantTxnRefNumber = permitType;

                            if (PaymentType == "VP")
                            {
                                model.PaymentType = "VPCAN";
                            }
                            else
                            {
                                model.PaymentType = "BPCAN";
                            }
                            objMSmodel = _objSBIModel.PaymentStatusReportInsert(model);
                            OutputResult = objMSmodel.Satus;
                            if (OutputResult == "1")
                            {
                                OutputResult = "REVERTED";
                            }
                            else
                            {

                                OutputResult = "FAILED";
                            }
                            //using (SqlCommand cmd1 = new SqlCommand())
                            //{
                            //    cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                            //    cmd1.CommandText = "getPaymentStatusReport";
                            //    cmd1.Parameters.AddWithValue("@MerchantTxnRefNumber", permitType);
                            //    cmd1.Parameters.AddWithValue("@UserId", SessionWrapper.UserId);
                            //    if (PaymentType == "VP")
                            //    {
                            //        cmd1.Parameters.AddWithValue("@PaymentTYpe", "VPCAN");
                            //    }
                            //    else
                            //    {
                            //        cmd1.Parameters.AddWithValue("@PaymentTYpe", "BPCAN");
                            //    }
                            //    objTotalAppl = _objSBIModel.GetPaymentGateway(model);
                            //    bool Check = objDb.InsertData(cmd);
                            //    if (Check)
                            //    {
                            //        OutputResult = "REVERTED";
                            //    }
                            //    else
                            //    {

                            //        OutputResult = "FAILED";
                            //    }

                            //}
                            #endregion
                            OutputResult = "FAILED";
                        }
                        else if (!string.IsNullOrEmpty(strPG_TxnStatus) && strPG_TxnStatus.ToUpper() == "FAILURE")
                        {
                            PaymentEF objModel = new PaymentEF();
                            objModel.Txn_Status = "FAILED";
                            objModel.UserId = Convert.ToInt32(profile.UserId);
                            objModel.Permit_Type = permitType;
                            objModel.BankCode = app.BankCode;
                            objModel.TPSLTXNID = "";
                            objModel.AMOUNT = app.AMOUNT;
                            objModel.Responce = response;


                            objMSmodel = _objSBIModel.InsertPaymentRequestOnFailed(objModel);
                            OutputResult = objMSmodel.Satus;

                            //using (SqlCommand cmdupdateVP = new SqlCommand())
                            //{
                            //    cmdupdateVP.CommandText = "InsertUpdatePaymentRecords";

                            //    cmdupdateVP.CommandType = System.Data.CommandType.StoredProcedure;

                            //    cmdupdateVP.Parameters.AddWithValue("@TXN_STATUS", "FAILED");
                            //    cmdupdateVP.Parameters.AddWithValue("@UserId", SessionWrapper.UserId);
                            //    cmdupdateVP.Parameters.AddWithValue("@CLNT_TXN_REF", permitType);
                            //    cmdupdateVP.Parameters.AddWithValue("@TPSL_BANK_CD", dt.Rows[0]["BANKCODE"].ToString());
                            //    cmdupdateVP.Parameters.AddWithValue("@TPSL_TXN_ID", "");
                            //    cmdupdateVP.Parameters.AddWithValue("@TXN_AMT", dt.Rows[0]["AMOUNT"].ToString());
                            //    cmdupdateVP.Parameters.AddWithValue("@TPSL_TXN_TIME", System.DateTime.Now);
                            //    cmdupdateVP.Parameters.AddWithValue("@strPGRESPONSE", response);
                            //    cmdupdateVP.Parameters.AddWithValue("@PAYMENTFOR", 1); // this value should be change as per payment recived.
                            //    cmdupdateVP.Parameters.AddWithValue("@PaymentResponseID", 0);

                            //    objDb.ExecuteStoreProcedure(cmdupdateVP);
                            //}
                        }
                        else
                        {
                            strResponse = response.ToUpper();
                            if (!string.IsNullOrEmpty(strResponse))
                            {

                                if (!string.IsNullOrEmpty(strPG_TxnStatus) && strPG_TxnStatus.ToUpper() == "SUCCESS")
                                {

                                    permitType = PaymentType + id;

                                    if (permitType.StartsWith("OBP"))
                                    {
                                        #region Bulk Permit - Other Online Payment
                                        string strBulkPermitID = permitType.Replace("OBP", "").Trim();

                                        model.PaymentType = strBulkPermitID;
                                        model.AMOUNT = strPG_TxnAmount;
                                        model.TxnDate = strPG_TRANSACTIONDATE;
                                        objTotalAppl = _objSBIModel.LesseeWisePaymentDetails(model);
                                        foreach (var lessee in objTotalAppl.LesseeList)

                                        {
                                            #region Send Mail
                                            try
                                            {

                                                //MailService mail = new MailService();
                                                //mail.SendNonPermitPaymentMail(BankTPSLId, Convert.ToString(dt.Rows[0]["EmailID"]),
                                                //        DateTime.Now.ToString("dd/MM/yyyy"), BankTPSLId,
                                                //        Convert.ToString(dt1.Rows[0]["ApplicantName"]),
                                                //        Convert.ToString(dt1.Rows[0]["PaymentType"]),
                                                //        Convert.ToString(dt1.Rows[0]["PayableAmount"]));
                                            }
                                            catch (Exception)
                                            {

                                            }
                                            #endregion
                                            #region Send SMS

                                            try
                                            {
                                                //string message = "Your Payments for " + Convert.ToString(dt1.Rows[0]["PaymentType"]) + " has been credited successfully in Khanij Online System dated on " + System.DateTime.Now + " Please check your e-mail for details for Payment.";
                                                //SMSHttpPostClient.Main(Convert.ToString(dt1.Rows[0]["MobileNo"]), message);

                                            }
                                            catch (Exception)
                                            {

                                            }
                                            #endregion
                                        }
                                        //using (SqlCommand cmdupdate1 = new SqlCommand())
                                        //{
                                        //    cmdupdate1.CommandText = "uspLesseeWisePaymentDetails";
                                        //    cmdupdate1.CommandType = System.Data.CommandType.StoredProcedure;

                                        //    cmdupdate1.Parameters.AddWithValue("@UserID", SessionWrapper.UserId);
                                        //    cmdupdate1.Parameters.AddWithValue("@SubUserID", SessionWrapper.SubUserID);
                                        //    cmdupdate1.Parameters.AddWithValue("@PaymentTypeId", strBulkPermitID);
                                        //    cmdupdate1.Parameters.AddWithValue("@PaymentStatus", "SUCCESS");
                                        //    cmdupdate1.Parameters.AddWithValue("@PayableAmount", strPG_TxnAmount);
                                        //    cmdupdate1.Parameters.AddWithValue("@strPG_TRANSACTION_DATE", strPG_TRANSACTIONDATE);
                                        //    cmdupdate1.Parameters.AddWithValue("@Check", 3);

                                        //    using (DataTable dt1 = objDb.ExecuteStoreProcedure(cmdupdate1))
                                        //    {
                                        //        if (dt1 != null && dt1.Rows.Count > 0)
                                        //        {
                                        //            #region Send Mail
                                        //            try
                                        //            {

                                        //                //MailService mail = new MailService();
                                        //                //mail.SendNonPermitPaymentMail(BankTPSLId, Convert.ToString(dt.Rows[0]["EmailID"]),
                                        //                //        DateTime.Now.ToString("dd/MM/yyyy"), BankTPSLId,
                                        //                //        Convert.ToString(dt1.Rows[0]["ApplicantName"]),
                                        //                //        Convert.ToString(dt1.Rows[0]["PaymentType"]),
                                        //                //        Convert.ToString(dt1.Rows[0]["PayableAmount"]));
                                        //            }
                                        //            catch (Exception)
                                        //            {

                                        //            }
                                        //            #endregion

                                        //            #region Send SMS

                                        //            try
                                        //            {
                                        //                string message = "Your Payments for " + Convert.ToString(dt1.Rows[0]["PaymentType"]) + " has been credited successfully in Khanij Online System dated on " + System.DateTime.Now + " Please check your e-mail for details for Payment.";
                                        //                SMSHttpPostClient.Main(Convert.ToString(dt1.Rows[0]["MobileNo"]), message);

                                        //            }
                                        //            catch (Exception)
                                        //            {

                                        //            }
                                        //            #endregion
                                        //        }
                                        //    }
                                        //}
                                        #endregion
                                    }
                                    else if (permitType.StartsWith("BP"))
                                    {

                                        #region e-Permit Payment
                                        string strBulkPermitID = permitType.Replace("BP", "").Trim();

                                        if (!string.IsNullOrEmpty(strBulkPermitID))
                                        {
                                            PaymentEF objModel = new PaymentEF();
                                            objModel.BulkPermitId = strBulkPermitID;
                                            objModel.UserId = Convert.ToInt32(profile.UserId);
                                            objModel.PG_Transaction_Date = strPG_TRANSACTIONDATE;
                                            objModel.Challan_Initiate_Date = CHALLAN_INITIATE_DATE;
                                            objModel.Challan_Settlement_Date = CHALLAN_SETTLEMENT_DATE;
                                            objModel.ICICI_TXN_NO = ICICI_TXN_NO;
                                            objModel.UTR_Number = UTR_NUMBER;
                                            objModel.Challan_Number = CHALLAN_NO;
                                            objModel.Responce = strResponse;
                                            objModel.BankCode = app.BankCode;

                                            objMSmodel = _objSBIModel.MakeFinalCoalPayment(objModel);
                                            OutputResult = objMSmodel.Satus;

                                            if (OutputResult != null && !string.IsNullOrEmpty(Convert.ToString(OutputResult)))
                                            {
                                                #region Sent Mail & MSG
                                                var mobile = "";
                                                var email = "";
                                                var TransactionId = "";
                                                var PaymentReceiptID = "";
                                                var forwadedDate = "";
                                                var ApplicantName = "";
                                                PaymentEF objCoalModel = new PaymentEF();
                                                objCoalModel.BulkPermitId = OutputResult;
                                                objTotalAppl = _objSBIModel.GetCoalEPermit(objCoalModel);
                                                if (objTotalAppl != null && objTotalAppl.CoalEPermitList.Count > 0)
                                                {
                                                    foreach (var coal in objTotalAppl.CoalEPermitList)
                                                    {
                                                        mobile = coal.MobileNo;
                                                        email = coal.EMailId;
                                                        ApplicantName = coal.ApplicantName;
                                                        TransactionId = coal.TransactionalId;
                                                        PaymentReceiptID = coal.PaymentReceiptID;
                                                        forwadedDate = coal.forwadedDate;
                                                        string BulkPermitNo = coal.BulkPermitNo;
                                                        string ApprovedQty = Convert.ToString(coal.ApprovedQty);
                                                        string TotalPayableAmount = strPG_TxnAmount; //Convert.ToString(dt.Rows[0]["TotalPayableAmount"]);
                                                        string MineralName = Convert.ToString(coal.MineralName);
                                                        string MineralGrade = Convert.ToString(coal.MineralGrade);
                                                        string MineralNature = Convert.ToString(coal.MineralNature);
                                                        string UnitName = Convert.ToString(coal.UnitName);
                                                    }
                                                    #region Send SMS

                                                    try
                                                    {

                                                        if (!string.IsNullOrEmpty(email))
                                                        {
                                                            //MailService dmoMail = new MailService();
                                                            //dmoMail.SendPermitPaymentAck(email, BulkPermitNo, ApprovedQty, TotalPayableAmount, MineralName, MineralGrade, MineralNature, "SUCCESS", TransactionId);
                                                        }

                                                        if (!string.IsNullOrEmpty(mobile))
                                                        {
                                                            //string msg = "Your payment has been credited successfully and Your e-Permit No. is: " + BulkPermitNo + Environment.NewLine + " Dated " + System.DateTime.Now + Environment.NewLine +
                                                            //    "Quantity : " + ApprovedQty + " " + UnitName + "" + Environment.NewLine +
                                                            //    "Total Paid Amount : Rs " + TotalPayableAmount + "/-" + Environment.NewLine +
                                                            //    "Mineral Name : " + MineralName + "" + Environment.NewLine +
                                                            //    "Mineral Form : " + MineralNature + "" + Environment.NewLine +
                                                            //    "Mineral Grade : " + MineralGrade + "";
                                                            //SMSHttpPostClient.Main(mobile, msg);

                                                            //strAlert = "Your payment has been credited successfully and Your e-Permit No. is  " + BulkPermitNo + " Dated " + System.DateTime.Now.ToString("dd/MMM/yyyy") + " Quantity : " + ApprovedQty + " " + UnitName + " Total Paid Amount : Rs " + TotalPayableAmount + "/-" + " Mineral Name : " + MineralName + " Mineral Form : " + MineralNature + " Mineral Grade : " + MineralGrade + "";
                                                            //SMSHttpPostClient.Main(mobile, msg);
                                                        }

                                                    }
                                                    catch (Exception)
                                                    {

                                                    }


                                                    #endregion
                                                }
                                                //using (var cmd1 = new SqlCommand())
                                                //{
                                                //    var mobile = "";
                                                //    var email = "";
                                                //    var TransactionId = "";
                                                //    var PaymentReceiptID = "";
                                                //    var forwadedDate = "";
                                                //    var ApplicantName = "";

                                                //    cmd1.CommandText = "uspCoalEPermit";
                                                //    cmd1.CommandType = System.Data.CommandType.StoredProcedure;
                                                //    cmd1.Parameters.AddWithValue("@Check", 18);
                                                //    cmd1.Parameters.AddWithValue("@BulkPermitId", objReturnData1);
                                                //    using (var dt1 = objDb.ExecuteStoreProcedure(cmd1))
                                                //    {
                                                //        if (dt1 != null && dt1.Rows.Count > 0)
                                                //        {
                                                //            mobile = dt1.Rows[0]["MobileNo"].ToString();
                                                //            email = dt1.Rows[0]["EMailId"].ToString();
                                                //            ApplicantName = dt1.Rows[0]["ApplicantName"].ToString();
                                                //            TransactionId = dt1.Rows[0]["TransactionalId"].ToString();
                                                //            PaymentReceiptID = dt1.Rows[0]["PaymentReceiptID"].ToString();
                                                //            forwadedDate = dt1.Rows[0]["forwadedDate"].ToString();
                                                //            string BulkPermitNo = dt1.Rows[0]["BulkPermitNo"].ToString();
                                                //            string ApprovedQty = Convert.ToString(dt1.Rows[0]["ApprovedQty"]);
                                                //            string TotalPayableAmount = strPG_TxnAmount; //Convert.ToString(dt.Rows[0]["TotalPayableAmount"]);
                                                //            string MineralName = Convert.ToString(dt1.Rows[0]["MineralName"]);
                                                //            string MineralGrade = Convert.ToString(dt1.Rows[0]["MineralGrade"]);
                                                //            string MineralNature = Convert.ToString(dt1.Rows[0]["MineralNature"]);
                                                //            string UnitName = Convert.ToString(dt1.Rows[0]["UnitName"]);

                                                //            //string message = "Your Application has been submitted successfully and payment has been credited successfully and Your treasury account Receipt ID : " + TransactionId + " Dated " + System.DateTime.Now.Date.ToString("dd/MM/yyyy") + "Payment Reference ID : " + PaymentReceiptID + ".";

                                                //            //SMSHttpPostClient.Main(mobile, message);
                                                //            //MailService mail = new MailService();
                                                //            //mail.SendMail_PaymentAck(PaymentReceiptID, email, forwadedDate, TransactionId, ApplicantName);

                                                //            #region Send SMS

                                                //            try
                                                //            {

                                                //                if (!string.IsNullOrEmpty(email))
                                                //                {
                                                //                    MailService dmoMail = new MailService();
                                                //                    dmoMail.SendPermitPaymentAck(email, BulkPermitNo, ApprovedQty, TotalPayableAmount, MineralName, MineralGrade, MineralNature, "SUCCESS", TransactionId);
                                                //                }

                                                //                if (!string.IsNullOrEmpty(mobile))
                                                //                {
                                                //                    string msg = "Your payment has been credited successfully and Your e-Permit No. is: " + BulkPermitNo + Environment.NewLine + " Dated " + System.DateTime.Now + Environment.NewLine +
                                                //                        "Quantity : " + ApprovedQty + " " + UnitName + "" + Environment.NewLine +
                                                //                        "Total Paid Amount : Rs " + TotalPayableAmount + "/-" + Environment.NewLine +
                                                //                        "Mineral Name : " + MineralName + "" + Environment.NewLine +
                                                //                        "Mineral Form : " + MineralNature + "" + Environment.NewLine +
                                                //                        "Mineral Grade : " + MineralGrade + "";
                                                //                    SMSHttpPostClient.Main(mobile, msg);

                                                //                    //strAlert = "Your payment has been credited successfully and Your e-Permit No. is  " + BulkPermitNo + " Dated " + System.DateTime.Now.ToString("dd/MMM/yyyy") + " Quantity : " + ApprovedQty + " " + UnitName + " Total Paid Amount : Rs " + TotalPayableAmount + "/-" + " Mineral Name : " + MineralName + " Mineral Form : " + MineralNature + " Mineral Grade : " + MineralGrade + "";
                                                //                    //SMSHttpPostClient.Main(mobile, msg);
                                                //                }

                                                //            }
                                                //            catch (Exception)
                                                //            {

                                                //            }


                                                //            #endregion
                                                //        }
                                                //    }
                                                //}

                                                #endregion
                                            }

                                        }
                                        #endregion
                                    }
                                    else if (permitType.StartsWith("SL"))
                                    {
                                        #region e-Permit Payment
                                        string strBulkPermitID = permitType.Replace("SL", "").Trim();

                                        if (!string.IsNullOrEmpty(strBulkPermitID))
                                        {
                                            PaymentEF objLesseeModel = new PaymentEF();
                                            objLesseeModel.PaymentID = strBulkPermitID;
                                            objLesseeModel.UserId = Convert.ToInt32(profile.UserId);
                                            objLesseeModel.PG_Transaction_Date = strPG_TRANSACTIONDATE;
                                            objMSmodel = _objSBIModel.SaveSuperLesseeDashboardData(objLesseeModel);
                                            OutputResult = objMSmodel.Satus;
                                            if (OutputResult != null && !string.IsNullOrEmpty(Convert.ToString(OutputResult)))
                                            {
                                                #region Send SMS
                                                try
                                                {
                                                    #region Send Mail
                                                    try
                                                    {

                                                        //MailService mail = new MailService();
                                                        //mail.SendNonPermitPaymentMail(SessionWrapper.UserLoginId.ToString(), SessionWrapper.EmailId,
                                                        //        DateTime.Now.ToString("dd/MM/yyyy"), SessionWrapper.UserId.ToString(),
                                                        //        SessionWrapper.UserName,
                                                        //        "Bulk e-Permit Payment",
                                                        //        Convert.ToString(strPG_TxnAmount));
                                                    }
                                                    catch (Exception)
                                                    {

                                                    }
                                                    #endregion

                                                    #region Send SMS

                                                    try
                                                    {
                                                        //string strAlert = "Your Payments for bulk e-Permit has been credited successfully in Khanij Online System dated on " + System.DateTime.Now + " Please check your e-mail for details for Payment.";
                                                        //SMSHttpPostClient.Main(SessionWrapper.MobileNumber, strAlert);

                                                    }
                                                    catch (Exception)
                                                    {

                                                    }
                                                    #endregion
                                                }
                                                catch (Exception)
                                                {

                                                }
                                                #endregion
                                            }

                                            //using (SqlCommand cmdupdate1 = new SqlCommand())
                                            //{
                                            //    cmdupdate1.CommandText = "uspSuperLesseeDashboardData";
                                            //    cmdupdate1.CommandType = System.Data.CommandType.StoredProcedure;
                                            //    cmdupdate1.Parameters.AddWithValue("@PaymentID", strBulkPermitID);
                                            //    cmdupdate1.Parameters.AddWithValue("@UserId", SessionWrapper.UserId);
                                            //    cmdupdate1.Parameters.AddWithValue("@PaymentStatus", "SUCCESS");
                                            //    cmdupdate1.Parameters.AddWithValue("@Check", 6);
                                            //    cmdupdate1.Parameters.AddWithValue("@strPG_TRANSACTION_DATE", strPG_TRANSACTIONDATE);


                                            //    Object objReturnData1 = objDb.GetSingleValue(cmdupdate1);

                                            //    if (objReturnData1 != null && !string.IsNullOrEmpty(Convert.ToString(objReturnData1)))
                                            //    {
                                            //        #region Send SMS
                                            //        try
                                            //        {
                                            //            #region Send Mail
                                            //            try
                                            //            {

                                            //                MailService mail = new MailService();
                                            //                mail.SendNonPermitPaymentMail(SessionWrapper.UserLoginId.ToString(), SessionWrapper.EmailId,
                                            //                        DateTime.Now.ToString("dd/MM/yyyy"), SessionWrapper.UserId.ToString(),
                                            //                        SessionWrapper.UserName,
                                            //                        "Bulk e-Permit Payment",
                                            //                        Convert.ToString(strPG_TxnAmount));
                                            //            }
                                            //            catch (Exception)
                                            //            {

                                            //            }
                                            //            #endregion

                                            //            #region Send SMS

                                            //            try
                                            //            {
                                            //                string strAlert = "Your Payments for bulk e-Permit has been credited successfully in Khanij Online System dated on " + System.DateTime.Now + " Please check your e-mail for details for Payment.";
                                            //                SMSHttpPostClient.Main(SessionWrapper.MobileNumber, strAlert);

                                            //            }
                                            //            catch (Exception)
                                            //            {

                                            //            }
                                            //            #endregion
                                            //        }
                                            //        catch (Exception)
                                            //        {

                                            //        }
                                            //        #endregion
                                            //    }
                                            //}
                                        }
                                        #endregion
                                    }
                                    else if (permitType.StartsWith("VP"))
                                    {
                                        #region Vehicle Payments
                                        //  string strBulkPermitID = response.CLNT_TXN_REF.Trim();
                                        string strBulkPermitID = permitType.Replace("VP", "").Trim();
                                        PaymentEF objVehicle = new PaymentEF();
                                        objVehicle.PaymentVehicleID = strBulkPermitID;
                                        objVehicle.UserId = Convert.ToInt32(profile.UserId);
                                        objVehicle.UserLoginId = Convert.ToInt32(profile.UserLoginId);
                                        objVehicle.PG_Transaction_Date = strPG_TRANSACTIONDATE;
                                        objVehicle.CHECK = 2;
                                        objTotalAppl = _objSBIModel.InsertVehicleMasterPaymentDetails(objVehicle);

                                        if (objTotalAppl != null && objTotalAppl.LesseeList.Count > 0)
                                        {
                                            #region Send Mail
                                            try
                                            {
                                                //CHiMMS_MVC.Areas.Transporters.Models.TransporterMasterModel TModel = new CHiMMS_MVC.Areas.Transporters.Models.TransporterMasterModel();
                                                //TModel.EmailID = Convert.ToString(dt1.Rows[0]["EmailID"]);
                                                //TModel.TotalVehiclesPayment = Convert.ToString(dt1.Rows[0]["RegFees"]);
                                                //TModel.VehicleCount = Convert.ToInt32(dt1.Rows[0]["TotalVehicleCount"]);

                                                //MailService mail = new MailService();
                                                //mail.SendMail_AddVehiclesAck(TModel);
                                                // return RedirectToAction("ProfileView", "EndUserProfile");
                                            }
                                            catch (Exception)
                                            {
                                                //TempData["AckMessage"] = "0";
                                            }
                                            #endregion

                                            #region Send SMS

                                            try
                                            {
                                                //string message = "Vehicles are successfully registered in Khanij Online System dated on " + System.DateTime.Now + " Please check your e-mail for details of vehicles registration";
                                                //SMSHttpPostClient.Main(Convert.ToString(dt.Rows[0]["MobileNo"]), message);

                                            }
                                            catch (Exception)
                                            {

                                            }
                                            #endregion
                                        }
                                        //using (SqlCommand cmdupdate1 = new SqlCommand())
                                        //{
                                        //    cmdupdate1.CommandText = "upsInsertVehicleMasterPaymentDetails";
                                        //    cmdupdate1.CommandType = System.Data.CommandType.StoredProcedure;

                                        //    cmdupdate1.Parameters.AddWithValue("@PaymentVehicleID", strBulkPermitID);
                                        //    cmdupdate1.Parameters.AddWithValue("@UserId", SessionWrapper.UserId);
                                        //    cmdupdate1.Parameters.AddWithValue("@PaymentStatus", "SUCCESS");
                                        //    cmdupdate1.Parameters.AddWithValue("@UserLoginId", SessionWrapper.UserLoginId);
                                        //    cmdupdate1.Parameters.AddWithValue("@CHECK", 2);
                                        //    cmdupdate1.Parameters.AddWithValue("@strPG_TRANSACTION_DATE", strPG_TRANSACTIONDATE);
                                        //    cmdupdate1.Parameters.AddWithValue("@CheckStatusCall", "1");

                                        //    using (DataTable dt1 = objDb.ExecuteStoreProcedure(cmdupdate1))
                                        //    {
                                        //        if (dt1 != null && dt1.Rows.Count > 0)
                                        //        {
                                        //            #region Send Mail
                                        //            try
                                        //            {
                                        //                CHiMMS_MVC.Areas.Transporters.Models.TransporterMasterModel TModel = new CHiMMS_MVC.Areas.Transporters.Models.TransporterMasterModel();
                                        //                TModel.EmailID = Convert.ToString(dt1.Rows[0]["EmailID"]);
                                        //                TModel.TotalVehiclesPayment = Convert.ToString(dt1.Rows[0]["RegFees"]);
                                        //                TModel.VehicleCount = Convert.ToInt32(dt1.Rows[0]["TotalVehicleCount"]);

                                        //                MailService mail = new MailService();
                                        //                mail.SendMail_AddVehiclesAck(TModel);
                                        //                // return RedirectToAction("ProfileView", "EndUserProfile");
                                        //            }
                                        //            catch (Exception)
                                        //            {
                                        //                //TempData["AckMessage"] = "0";
                                        //            }
                                        //            #endregion

                                        //            #region Send SMS

                                        //            try
                                        //            {
                                        //                string message = "Vehicles are successfully registered in Khanij Online System dated on " + System.DateTime.Now + " Please check your e-mail for details of vehicles registration";
                                        //                SMSHttpPostClient.Main(Convert.ToString(dt.Rows[0]["MobileNo"]), message);

                                        //            }
                                        //            catch (Exception)
                                        //            {

                                        //            }
                                        //            #endregion
                                        //        }
                                        //    }
                                        //}
                                        #endregion
                                    }
                                    else if (permitType.StartsWith("DN"))
                                    {
                                        #region Demand Note Payments

                                        #endregion
                                    }
                                    else if (permitType.StartsWith("CVP"))
                                    {
                                        #region Vehicle Payments
                                        //  string strBulkPermitID = response.CLNT_TXN_REF.Trim();
                                        //string strBulkPermitID = permitType.Replace("VP", "").Trim();
                                        PaymentEF objVehiclePay = new PaymentEF();
                                        objVehiclePay.PaymentVehicleID = id;
                                        objVehiclePay.UserId = Convert.ToInt32(profile.UserId);
                                        objVehiclePay.UserLoginId = Convert.ToInt32(profile.UserLoginId);
                                        objVehiclePay.PG_Transaction_Date = strPG_TRANSACTIONDATE;
                                        objVehiclePay.CHECK = 4;
                                        objTotalAppl = _objSBIModel.InsertVehicleMasterPaymentDetails(objVehiclePay);

                                        if (objTotalAppl != null && objTotalAppl.LesseeList.Count > 0)
                                        {
                                            #region Send Mail
                                            try
                                            {
                                                //CHiMMS_MVC.Areas.Transporters.Models.TransporterMasterModel TModel = new CHiMMS_MVC.Areas.Transporters.Models.TransporterMasterModel();
                                                //TModel.EmailID = Convert.ToString(dt1.Rows[0]["EmailID"]);
                                                //TModel.TotalVehiclesPayment = Convert.ToString(dt1.Rows[0]["RegFees"]);
                                                //TModel.VehicleCount = Convert.ToInt32(dt1.Rows[0]["TotalVehicleCount"]);

                                                //MailService mail = new MailService();
                                                //mail.SendMail_AddVehiclesAck(TModel);
                                                // return RedirectToAction("ProfileView", "EndUserProfile");
                                            }
                                            catch (Exception)
                                            {
                                                //TempData["AckMessage"] = "0";
                                            }
                                            #endregion

                                            #region Send SMS

                                            try
                                            {
                                                //string message = "Vehicles are successfully registered in Khanij Online System dated on " + System.DateTime.Now + " Please check your e-mail for details of vehicles registration";
                                                //SMSHttpPostClient.Main(Convert.ToString(dt.Rows[0]["MobileNo"]), message);

                                            }
                                            catch (Exception)
                                            {

                                            }
                                            #endregion
                                        }
                                        //using (SqlCommand cmdupdate1 = new SqlCommand())
                                        //{
                                        //    cmdupdate1.CommandText = "upsInsertVehicleMasterPaymentDetails";
                                        //    cmdupdate1.CommandType = System.Data.CommandType.StoredProcedure;

                                        //    cmdupdate1.Parameters.AddWithValue("@PaymentVehicleID", id);
                                        //    cmdupdate1.Parameters.AddWithValue("@UserId", SessionWrapper.UserId);
                                        //    cmdupdate1.Parameters.AddWithValue("@PaymentStatus", "SUCCESS");
                                        //    cmdupdate1.Parameters.AddWithValue("@UserLoginId", SessionWrapper.UserLoginId);
                                        //    cmdupdate1.Parameters.AddWithValue("@CHECK", 4);
                                        //    cmdupdate1.Parameters.AddWithValue("@strPG_TRANSACTION_DATE", strPG_TRANSACTIONDATE);
                                        //    cmdupdate1.Parameters.AddWithValue("@CheckStatusCall", "1");

                                        //    using (DataTable dt1 = objDb.ExecuteStoreProcedure(cmdupdate1))
                                        //    {
                                        //        if (dt1 != null && dt1.Rows.Count > 0)
                                        //        {
                                        //            #region Send Mail
                                        //            try
                                        //            {
                                        //                CHiMMS_MVC.Areas.Transporters.Models.TransporterMasterModel TModel = new CHiMMS_MVC.Areas.Transporters.Models.TransporterMasterModel();
                                        //                TModel.EmailID = Convert.ToString(dt1.Rows[0]["EmailID"]);
                                        //                TModel.TotalVehiclesPayment = Convert.ToString(dt1.Rows[0]["RegFees"]);
                                        //                TModel.VehicleCount = Convert.ToInt32(dt1.Rows[0]["TotalVehicleCount"]);

                                        //                MailService mail = new MailService();
                                        //                mail.SendMail_AddVehiclesAck(TModel);
                                        //                // return RedirectToAction("ProfileView", "EndUserProfile");
                                        //            }
                                        //            catch (Exception)
                                        //            {
                                        //                //TempData["AckMessage"] = "0";
                                        //            }
                                        //            #endregion

                                        //            #region Send SMS

                                        //            try
                                        //            {
                                        //                string message = "Vehicles are successfully registered in Khanij Online System dated on " + System.DateTime.Now + " Please check your e-mail for details of vehicles registration";
                                        //                SMSHttpPostClient.Main(Convert.ToString(dt.Rows[0]["MobileNo"]), message);

                                        //            }
                                        //            catch (Exception)
                                        //            {

                                        //            }
                                        //            #endregion
                                        //        }
                                        //    }
                                        //}
                                        #endregion
                                    }

                                    OutputResult = "SUCCESS";
                                }
                                else if (strPG_TxnStatus.ToUpper() == "AWAITED" || strPG_TxnStatus.ToUpper() == "PENDING")
                                {
                                    OutputResult = "AWAITED";
                                }
                            }
                            else
                            {
                                OutputResult = "FAILED";
                            }
                        }
                        #endregion
                    }
                }
                //    }

                //}
                //}

                return OutputResult;

            }
            else
            {
                OutputResult = "FAILED";
                return OutputResult;

            }
        }
    }
}
