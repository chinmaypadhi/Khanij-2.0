using Dapper;
using PermitApi.Factory;
using PermitApi.Repository;
using PermitEF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PermitApi.Model.SMSService
{
    public class SMSProvider: RepositoryBase,ISMSProvider
    {
        public SMSProvider(IConnectionFactory connectionFactory): base(connectionFactory)
        {

        }
        #region User Details
        static String username = "CGCHIPS-CHIMMS";
        static String password = "CHiMMS@54321";
        static String senderid = "DIGSEC";
        static String secureKey = "e0a83fe1-9943-42d1-a4a5-84cee2c9e87f";
        static String message = "Hi......";
        static String mobileNo = "7069042466";
        // static String mobileNos = "9856XXXXX, 9856XXXXX ";
        static String scheduledTime = "20110819 13:26:00";
        #endregion

        /// <summary>
        /// Send OTP
        /// </summary>
        /// <param name="sMS"></param>
        /// <returns></returns>
        public MessageEF Main(SMS sMS)
        {
            MessageEF messageEF = new MessageEF();
            if (!string.IsNullOrEmpty(sMS.mobileNo))
            {
                try
                {
                    bool isSMS = true;

                    if (sMS.UserId > 0 && sMS.SMS_SENT == "0")
                    {
                        isSMS = false;
                    }

                    if (isSMS == true)
                    {
                        HttpWebRequest request;


                        System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        //request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequest");
                        request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequestDLT");
                        request.ProtocolVersion = HttpVersion.Version10;
                        request.KeepAlive = false;
                        request.ServicePoint.ConnectionLimit = 1;
                        //((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";
                        ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
                        request.Method = "POST";
                        //Console.WriteLine("Before Calling Method");
                        //ServicePointManager.CertificatePolicy = new MyPolicy();
                        var handler = new HttpClientHandler();
                        handler.ServerCertificateCustomValidationCallback = delegate { return true; };
                        var http = new HttpClient(handler);
                        // added by Avneesh on 12-04-2021
                        sendOTPMSG(sMS.UserId, username, password, senderid, sMS.mobileNo, sMS.message, secureKey, request, sMS.templateid);
                        messageEF.Satus = "success";
                        //sendOTPMSG(username, password, senderid, mobileNo, message, secureKey, request);
                    }
                }
                catch (Exception)
                {
                    messageEF.Satus = "failure";
                }
                
            }
            return messageEF;
        }

        public void sendOTPMSG(int? UserId, String username, String password, String senderid, String mobileNo, String message, String secureKey, HttpWebRequest request, string templateid)
        {
           

            try
            {
                Stream dataStream;
                String encryptedPassword = string.Empty;
                byte[] encPwd = Encoding.UTF8.GetBytes(password);
                //static byte[] pwd = new byte[encPwd.Length];
                HashAlgorithm sha1 = HashAlgorithm.Create("SHA1");
                byte[] pp = sha1.ComputeHash(encPwd);
                // static string result = System.Text.Encoding.UTF8.GetString(pp);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in pp)
                {
                    sb.Append(b.ToString("x2"));
                }
                encryptedPassword = sb.ToString();
                StringBuilder sbHash = new StringBuilder();
                sbHash.Append(username).Append(senderid).Append(message).Append(secureKey);
                byte[] genkey = Encoding.UTF8.GetBytes(sbHash.ToString());
                //static byte[] pwd = new byte[encPwd.Length];
                HashAlgorithm shaHas1 = HashAlgorithm.Create("SHA512");
                byte[] sec_key = shaHas1.ComputeHash(genkey);
                StringBuilder sbHash11 = new StringBuilder();
                for (int i = 0; i < sec_key.Length; i++)
                {
                    sbHash11.Append(sec_key[i].ToString("x2"));
                }
                String Key = sbHash11.ToString();
                // String smsservicetype = "otpmsg"; //For OTP message.
                String smsservicetype = "singlemsg"; //For single message.
                                                     //String query = "username=" + HttpUtility.UrlEncode(username.Trim()) +
                                                     //                "&password=" + HttpUtility.UrlEncode(encryptedPassword) +
                                                     //                "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
                                                     //                "&content=" + HttpUtility.UrlEncode(message.Trim()) +
                                                     //                "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
                                                     //                "&senderid=" + HttpUtility.UrlEncode(senderid.Trim()) +
                                                     //                "&key=" + HttpUtility.UrlEncode(Key.Trim());





                // added by Avneesh on 12-04-2021
                String query = "username=" + HttpUtility.UrlEncode(username.Trim()) +
                                "&password=" + HttpUtility.UrlEncode(encryptedPassword) +
                                "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
                                "&content=" + HttpUtility.UrlEncode(message.Trim()) +
                                "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
                                "&senderid=" + HttpUtility.UrlEncode(senderid.Trim()) +
                                "&key=" + HttpUtility.UrlEncode(Key.Trim()) +
                                "&templateid=" + HttpUtility.UrlEncode(templateid);
                //"&templateid=" + HttpUtility.UrlEncode("khanijonline02");





                byte[] byteArray = Encoding.ASCII.GetBytes(query);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
                //dataStream = request.GetRequestStream();
                //dataStream.Write(byteArray, 0, byteArray.Length);
                using (dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }
                dataStream.Close();
                WebResponse response = request.GetResponse();
                String Status = ((HttpWebResponse)response).StatusDescription;
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                String responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();

                #region OTP Log
                var paramList = new
                {
                    Area = "SMSService.cs",
                    Controller = "SMSHttpPostClient.cs",
                    Action = "SMSService.cs",
                    ReturnType = "SUCCESS",
                    ErrorMessage = message,
                    StackTrace = mobileNo,
                    UserId = UserId,
                    UserLoginID = UserId
                };
                var resultSuccess = Connection.Execute("ReportErrorLog", paramList, commandType: System.Data.CommandType.StoredProcedure);

               
                #endregion
            }
            catch (Exception ex)
            {
                #region OTP Log
                var paramList = new
                {
                    Area = "SMSService.cs",
                    Controller = mobileNo,
                    Action = "SMSService.cs",
                    ReturnType ="FAILURE",
                    ErrorMessage = ex.Message,
                    StackTrace = message,
                    UserId = UserId,
                    UserLoginID = UserId
                };
                var resultFailure = Connection.Execute("ReportErrorLog", paramList, commandType: System.Data.CommandType.StoredProcedure);
                 
                #endregion
            }
            //return responseFromServer;
        }

        /// <summary>
        /// Method to get Encrypted the password 
        /// </summary>
        /// <param name="password"> password as String"

        protected String encryptedPasswod(String password)
        {

            byte[] encPwd = Encoding.UTF8.GetBytes(password);
            //static byte[] pwd = new byte[encPwd.Length];
            HashAlgorithm sha1 = HashAlgorithm.Create("SHA1");
            byte[] pp = sha1.ComputeHash(encPwd);
            // static string result = System.Text.Encoding.UTF8.GetString(pp);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in pp)
            {

                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();

        }

        /// <summary>
        /// Method to Generate hash code  
        /// </summary>
        /// <param name="secure_key">your last generated Secure_key 

        protected String hashGenerator(String Username, String sender_id, String message, String secure_key)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append(Username).Append(sender_id).Append(message).Append(secure_key);
            byte[] genkey = Encoding.UTF8.GetBytes(sb.ToString());
            //static byte[] pwd = new byte[encPwd.Length];
            HashAlgorithm sha1 = HashAlgorithm.Create("SHA512");
            byte[] sec_key = sha1.ComputeHash(genkey);

            StringBuilder sb1 = new StringBuilder();
            for (int i = 0; i < sec_key.Length; i++)
            {
                sb1.Append(sec_key[i].ToString("x2"));
            }
            return sb1.ToString();
        }

        
    }

   

}
