
// ***********************************************************************
//  Controller Name          : DSCResponseController
//  Desciption               : Used to managed Digital signature
//  Created By               : Suroj Kumar Pradhan
//  Created On               : 11-apr-2021
// ***********************************************************************
using System.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using Appkey;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserInformationEF;
using UserInformationApp.Areas.UserInformationsystem.Models.Mineral;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UserInformationApp.Areas.UserInformationsystem.Controllers
{
    [Area("UserInformationsystem")]
    public class DSCResponseController : Controller
    {
        string CommonName = string.Empty;
        string SerialNo = string.Empty;
        string IssuerCommonName = string.Empty;
        string IssuedDate = string.Empty;
        string ExpiryDate = string.Empty;
        string Email = string.Empty;
        string Country = string.Empty;
        string CertificateClass = string.Empty;
        string Signature = string.Empty;
        public Imineral _objIticketmodel;

        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        /// <summary>
        /// Added by suroj on 16-apr-2021 to implement dependency injection.
        /// </summary>
        /// <param name="objtickettypemastermodel"></param>
        /// <param name="hostingEnvironment"></param>
        /// <param name="configuration"></param>
        public DSCResponseController(Imineral objtickettypemastermodel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _objIticketmodel = objtickettypemastermodel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }
        
        public IActionResult Index()
        {
            return View();
        }
       /// <summary>
       /// Added by suroj 14-apr-2021 to getDSCResponse for digital signature
       /// </summary>
       /// <param name="response"></param>
       /// <param name="DSCFor"></param>
       /// <param name="DSCForId"></param>
       /// <returns></returns>
        public int getDSCResponse(string response, string DSCFor, int DSCForId)
        {
            int Response;
           
            DSCResponseModel objResponse = new DSCResponseModel();
            try
            {
                response = response.Replace("IssuerCommonName", " Issuer");
                response = response.Replace("CommonName", " CommonName").Replace("SerialNo", " SerialNo").Replace("IssuedDate", " IssuedDate").Replace("ExpiryDate", " ExpiryDate").Replace("Email", " Email").Replace("Country", " Country").Replace("CertificateClass", " CertificateClass").Replace("\r\n", "");
                string[] tokens = response.Split(new[] { " " }, StringSplitOptions.None);
                GetDSCRespnseData(tokens);
                objResponse.DSCCertificateClass = CertificateClass;
                objResponse.DSCSerialNo = SerialNo;
                objResponse.DSCCommonName = CommonName;
                objResponse.DSCIssuerCommonName = IssuerCommonName;
                objResponse.DSCCountry = Country;
                objResponse.DSCEmail = Email;
                objResponse.DSCExpiredDate = ExpiryDate;
                objResponse.DSCIssuedDate = IssuedDate;
                objResponse.Response = Signature;
                objResponse.DSCUsedBy = Convert.ToInt16(ConfigurationManager.MySettings["MySettings:Userid"]);
                objResponse.DSCFor = DSCFor;
                objResponse.DSCForId = DSCForId;

                Response = _objIticketmodel.InsertDSCRespnseData(objResponse);
                return Response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objResponse = null;
            }

        }
        /// <summary>
        /// Added by suroj 14-apr-2021 to getDSCResponse for digital signature
        /// </summary>
        /// <param name="response"></param>
        /// <param name="DSCFor"></param>
        /// <param name="DSCForId"></param>
        /// <returns></returns>
        public void GetDSCRespnseData(string[] parameters)
        {

            
            string[] strGetMerchantParamForCompare;
            for (int i = 0; i < parameters.Length; i++)
            {
                strGetMerchantParamForCompare = parameters[i].ToString().Split('=');
                if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "SIGNATURE")
                {
                    Signature = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "COMMONNAME")
                {
                    CommonName = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "SERIALNO")
                {
                    SerialNo = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "ISSUER")
                {
                    IssuerCommonName = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "ISSUEDDATE")
                {
                    IssuedDate = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "EXPIRYDATE")
                {
                    ExpiryDate = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "EMAIL")
                {
                    Email = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "COUNTRY")
                {
                    Country = Convert.ToString(strGetMerchantParamForCompare[1]);
                }
                else if (Convert.ToString(strGetMerchantParamForCompare[0]).ToUpper().Trim() == "CERTIFICATECLASS")
                {
                    CertificateClass = Convert.ToString(strGetMerchantParamForCompare[1]);
                }


            }
        }
      
          
      
    }
}
