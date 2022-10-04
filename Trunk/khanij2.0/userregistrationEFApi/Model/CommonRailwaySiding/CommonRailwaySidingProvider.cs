using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
using userregistrationEFApi.Repository;
using System.Data;
using Dapper;
using MasterApi.Factory;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace userregistrationEFApi.Model.CommonRailwaySiding
{
    public class CommonRailwaySidingProvider : RepositoryBase, ICommonRailwaySidingProvider
    {

        public CommonRailwaySidingProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public MessageEF AddCommonRailwaySiding(CommonRailwaySidingModel objCRS)
        {
            MessageEF objMessageEf = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Check", objCRS.Check);
                p.Add("@P_CRSId", objCRS.CRSId);
                p.Add("@P_RSId", objCRS.RSId);
                p.Add("@P_RSArea", objCRS.Area);
                p.Add("@P_RailwayZoneId", objCRS.RailwayZoneId);
                p.Add("@P_RSAddress", objCRS.RSAddress);
                p.Add("@P_RSLatitute", objCRS.RSLatitute);
                p.Add("@P_RSLongitute", objCRS.RSLongitute);
                p.Add("@P_RSGradeid", objCRS.RSGradeid);
                p.Add("@P_RSGradeDoc", objCRS.RSGradeDoc);
                p.Add("@P_RsGradeDocPath", objCRS.RsGradeDocPath);
                p.Add("@P_LesseeIdList", objCRS.LesseeList);
                p.Add("@P_intCreatedBy", objCRS.intCreatedBy);

                p.Add("@P_Representname", objCRS.RepresentitiveName);
                p.Add("@P_email", objCRS.EmailId);
                p.Add("@P_districtid", objCRS.DistrictId);
                p.Add("@P_mobno", objCRS.MobileNo);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspCommonRailwaySiding", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEf.Satus = newID.ToString();

            }
            catch (Exception)
            {

                throw;
            }
            return objMessageEf;
        }

        public async Task<List<CRSDropDown>> BindCRSDDL(CRSDropDown objWorkFlow)
        {
            List<CRSDropDown> listBindState = new List<CRSDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objWorkFlow.Check);
                p.Add("@P_CRSId", objWorkFlow.Id);
                var output = await Connection.QueryAsync<CRSDropDown>("uspCommonRailwaySiding_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listBindState = output.ToList();
                }
                return listBindState;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF DeleteCommonRailwaySiding(CommonRailwaySidingModel objCRS)
        {
            MessageEF objMessageEf = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Check", objCRS.Check);
                p.Add("@P_CRSId", objCRS.CRSId);
                p.Add("@P_intCreatedBy", objCRS.intCreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspCommonRailwaySiding", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEf.Satus = newID.ToString();
                return objMessageEf;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<CommonRailwaySidingModel_Query>> ViewCommonRailwaySiding(CommonRailwaySidingModel_Query objCommon)
        {
            List<CommonRailwaySidingModel_Query> listCommon = new List<CommonRailwaySidingModel_Query>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objCommon.Check);
                //p.Add("@P_CRSId", objCommon.CRSId);
                var output = await Connection.QueryAsync<CommonRailwaySidingModel_Query>("uspCommonRailwaySiding_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listCommon = output.ToList();
                }
                return listCommon;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CommonRailwaySidingModel> ViewCommonRailwaySidingDetails(CommonRailwaySidingModel objCommon)
        {
            CommonRailwaySidingModel _objCommon = new CommonRailwaySidingModel();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objCommon.Check);
                p.Add("@P_CRSId", objCommon.CRSId);
                var output = await Connection.QueryAsync<CommonRailwaySidingModel>("uspCommonRailwaySiding_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    _objCommon = output.FirstOrDefault();
                }
                return _objCommon;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<CommonRailwaySidingInboxEF_Query>> CommonRailwaySidinginbox(CommonRailwaySidingInboxEF_Query objCommon)
        {
            List<CommonRailwaySidingInboxEF_Query> listInbox = new List<CommonRailwaySidingInboxEF_Query>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objCommon.Check);
                p.Add("@P_intCreatedBy", objCommon.intCreatedBy);
                var output = await Connection.QueryAsync<CommonRailwaySidingInboxEF_Query>("uspCommonRailwayInbox_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listInbox = output.ToList();
                }
                return listInbox;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF TakeAction(CommonRailwaySidingTakeAction objCommon)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objCommon.Check);
                p.Add("@P_CRSId", objCommon.CRSId);
                p.Add("@P_intStatus", objCommon.intStatus);
                p.Add("@P_Remarks", objCommon.vchRemarks);
                p.Add("@P_intCreatedBy", objCommon.intCreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspCommonRailwayTakeAction", p, commandType: CommandType.StoredProcedure);
                int id = p.Get<int>("P_Message");
                objMessage.Satus = id.ToString();
                return objMessage;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public MessageEF CreatenewUser(CommonRailwaySidingTakeAction objCRS)
        {
            MessageEF objMessageEf = new MessageEF();
            try
            {
                var p = new DynamicParameters();

                //p.Add("@P_intCreatedBy", objCRS.intCreatedBy);
                
                p.Add("@P_chk", objCRS.Check);
                p.Add("@P_Representname", objCRS.RepresentitiveName);
                p.Add("@P_email", objCRS.EmailId);
                p.Add("@P_districtid", objCRS.DistrictId);
                p.Add("@P_mobno", objCRS.MobileNo);
                p.Add("@P_userid", objCRS.UserId);
                p.Add("@P_password", objCRS.Password);
                p.Add("@P_usernm", objCRS.UserName);
                p.Add("@P_userlogin", objCRS.UserLoginId);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspCommonRailwayTakeAction", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEf.Satus = newID.ToString();

            }
            catch (Exception)
            {

                throw;
            }
            return objMessageEf;
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
                    ReturnType = "FAILURE",
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

        public MessageEF ExcelfileUpload(ExcelDataValues objupload)
        {
            MessageEF msg = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@userDefindVal", objupload.CommonRailwaySidingFile_Upload, dbType: DbType.Object);
                p.Add("@ACTION", "E");
                var a = Connection.Query<string>("USP_SECLDOdetails", p, commandType: CommandType.StoredProcedure).ToList();
                if (a.Count() >= 0)
                {
                    msg.Satus = "SUCCESS";
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return msg;
        }
        //string str = Newtonsoft.Json.JsonConvert.SerializeObject(objmodel2.CommonRailwaySidingFile_Upload).Replace("\\", "").Replace("\r\n", "'").Trim(new char[1] { '"' });
        /// <summary>
        /// Method to get Encrypted the password 
        /// </summary>
        /// <param name="password"> password as String"












    }
}
