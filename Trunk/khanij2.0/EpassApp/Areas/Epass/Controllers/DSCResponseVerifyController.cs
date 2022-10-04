using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApp.Areas.Epass.Controllers
{
    public class DSCResponseVerifyController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        string OutputResult = "";
        public DSCResponseVerifyController( IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }
        #region DSC Response Verify
        string Signature = string.Empty;
        ///Note
        ///\EpassApp\appsettings.json
        /// "FNDSCReadFilePATH": "DSC/WithoutDSC/",
        /// "FNDSCCreateFilePATH": "DSC/WithDSC/"
        /// \EpassApp\wwwroot add folder and permission
        /// save path to database after save file
      
        /// <summary>
        /// Check Verify DSC Response
        /// </summary>
        /// <param name="contentType,signDataBase64Encoded,responseType"></param>
        /// <returns></returns>
        public string CheckVerifyResponse(string contentType, string signDataBase64Encoded, string responseType)
        {
            try
            {
                if (signDataBase64Encoded.Contains("signing canceled"))
                {
                    OutputResult = "";
                }
                else
                {
                    signDataBase64Encoded = signDataBase64Encoded.Replace("IssuerCommonName", " Issuer");
                    signDataBase64Encoded = signDataBase64Encoded.Replace("CommonName", " CommonName").Replace("SerialNo", " SerialNo").Replace("IssuedDate", " IssuedDate").Replace("ExpiryDate", " ExpiryDate").Replace("Email", " Email").Replace("Country", " Country").Replace("CertificateClass", " CertificateClass").Replace("\r\n", "");
                    string[] tokens = signDataBase64Encoded.Split(new[] { " " }, StringSplitOptions.None);

                    string strSign = GetDSCRespnseData(tokens);

                    TempData["DSCResponse"] = signDataBase64Encoded;
                    TempData["Base64Data"] = strSign;
                    OutputResult = "SUCCESS";
                }
            }
            catch
            {
            }
            return OutputResult.ToUpper();
        }

        /// <summary>
        /// Get DSC Response Data
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public string GetDSCRespnseData(string[] parameters)
        {
            string strSign = string.Empty;
            string[] strGetMerchantParamForCompare;
            for (int i = 0; i < parameters.Length; i++)
            {
                strGetMerchantParamForCompare = parameters[i].ToString().Split('=');
                if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "SIGNATURE")
                {
                    Signature = Convert.ToString(strGetMerchantParamForCompare[1]);
                    break;
                }
            }
            strSign = Signature;
            return strSign;
        }

        /// <summary>
        /// Save DSC PDF File
        /// </summary>
        /// <param name="base64BinaryStr,fileName,ID,UpdateIn"></param>
        /// <returns></returns>

        public JsonResult SavePdfFile(string base64BinaryStr, string fileName, int ID, string UpdateIn, string Month_Year)
        {
            string OutputResult = "SUCCESS";
            try
            {
                var ServerPath = "/DSC/WithDSC/" + fileName;
                var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration["FNDSCCreateFilePATH"]);
                var savepath = Path.Combine(RootPath, fileName);
                try
                {
                    string strFinalString = string.Empty;
                    if (base64BinaryStr.Contains("Signature="))
                    {
                        string strWithoutSign = base64BinaryStr.Replace("Signature=", string.Empty);
                        strFinalString = strWithoutSign.Substring(0, strWithoutSign.IndexOf("CommonName"));
                        strFinalString = strFinalString.Replace("==", string.Empty).Replace("\r", string.Empty);
                    }
                    else
                    {
                        strFinalString = base64BinaryStr.Substring(0, base64BinaryStr.IndexOf("CommonName"));
                        strFinalString = strFinalString.Replace("==", string.Empty).Replace("\r", string.Empty);
                    }

                    if ((System.IO.File.Exists(savepath)))
                    {
                        string file = "File Already Exists";
                    }
                    else
                    {
                        byte[] bytes = Convert.FromBase64String(strFinalString);
                        System.IO.FileStream stream = new FileStream(savepath, FileMode.CreateNew);
                        System.IO.BinaryWriter writer = new BinaryWriter(stream);
                        writer.Write(bytes, 0, bytes.Length);
                        writer.Close();
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    OutputResult = "PDF File Save failed. Please try after some time";
                    return Json(OutputResult.ToUpper());
                }

                //UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                //messageEF = licenseeApplicationModel.UpdatedDSCPath(new UpdateDSCPath()
                //{
                //    fileName = ServerPath,
                //    ID = ID,
                //    UpdateIn = UpdateIn,
                //    UserId = profile.UserId,
                //    MonthYear = Month_Year
                //});

                //if (string.IsNullOrEmpty(messageEF.Satus))
                //{
                //    OutputResult = "FAILED";
                //}

                //if (UpdateIn.ToUpper() == "LICENSE_APP_ACK")
                //{
                //    #region Sent Mail & MSG
                //    LicenseFinalApproval = licenseeApplicationModel.LICENSE_APP_ACK(new UpdateDSCPath()
                //    {
                //        UserId = profile.UserId,
                //        ID = ID
                //    });
                //    string message = "Your application for Storage License has been received by the sanctioning authority. CHiMMS, GoCG";
                //    string templateid = "1307161883499215951";
                //    sMSModel.Main(new SMS() { mobileNo = LicenseFinalApproval.MOBILENO, message = message, templateid = templateid });
                //    #endregion
                //}

                //if (UpdateIn.ToUpper() == "LICENSE_APP_GRANT_ORDER")
                //{
                //    #region Sent Mail & MSG
                //    LicenseFinalApproval = licenseeApplicationModel.LICENSE_APP_GRANT_ORDER(new UpdateDSCPath()
                //    {
                //        UserId = profile.UserId,
                //        ID = ID
                //    });
                //    string message = "Dear " + LicenseFinalApproval.APPLICANTNAME + " , Your Storage Permit application Ref ID " + LicenseFinalApproval.LICENSE_APP_CODE + " dated " + LicenseFinalApproval.ApprovedGrantOn + " has been approved and your permit order " + LicenseFinalApproval.License_SI_NO + " has been approved on dated " + System.DateTime.Now.Date.ToString("dd/MM/yyyy") + " . Please login in your portal and pay security fees within 7 days of approved grant order. CHiMMS, GoCG";


                //    string templateid = "1307161883503430214";
                //    sMSModel.Main(new SMS() { mobileNo = LicenseFinalApproval.MOBILENO, message = message, templateid = templateid });
                //    #endregion
                //}
            }
            catch (Exception ex)
            {
                OutputResult = "FAILED";
            }
            return Json(OutputResult.ToUpper());
        }

        /// <summary>
        /// Save Normal PDF File
        /// </summary>
        /// <param name="base64BinaryStr,fileName,ID,UpdateIn"></param>
        /// <returns></returns>

        public JsonResult SaveNormalPdfFile(string base64BinaryStr, string fileName, int ID, string UpdateIn)
        {
            string OutputResult = "SUCCESS";
            try
            {

                var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration["FNDSCReadFilePATH"]);
                var savepath = Path.Combine(RootPath, fileName);
                using (FileStream fs = new FileStream(savepath, FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        byte[] data = Convert.FromBase64String(base64BinaryStr);
                        bw.Write(data);
                        bw.Close();
                    }
                    fs.Close();
                }

            }
            catch (Exception ex)
            {
                OutputResult = "FAILED";
            }
            return Json(OutputResult.ToUpper());
        }
        #endregion
    }
}
