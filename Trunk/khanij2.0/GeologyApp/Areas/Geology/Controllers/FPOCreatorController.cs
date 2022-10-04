// ***********************************************************************
//  Controller Name          : FPOCreatorController
//  Desciption               : View,Update Field Program Order Approver
//  Created By               : Lingaraj Dalai
//  Created On               : 16 Feb 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using GeologyApp.Models.FPO;
using GeologyApp.Web;
using GeologyEF;
using Microsoft.AspNetCore.Mvc;

namespace GeologyApp.Controllers
{
    [Area("Geology")]
    public class FPOCreatorController : Controller
    {
        /// <summary>
        /// Global object and variable declaration
        /// </summary>
        IFPOModel _objFPOMasterModel;
        MessageEF objobjmodel = new MessageEF();
        string Signature = string.Empty;
        string OutputResult = string.Empty;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objFieldReportStatusMasterModel"></param>
        /// <param name="objInspectionReportMasterModel"></param>
        /// <param name="hostingEnvironment"></param>
        public FPOCreatorController(IFPOModel objFPOMasterModel)
        {
            _objFPOMasterModel = objFPOMasterModel;
        }
        /// <summary>
        /// To bind Field Program Order details data in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        public IActionResult ViewList(FPOOrdermaster objmodel)
        {
            try
            {
                List<FPOOrdermaster> lstFPOmaster = _objFPOMasterModel.ViewFPOCreator(objmodel);
                ViewBag.ViewList = lstFPOmaster;
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Submit with digital signature for Field Program Order approval
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public JsonResult Submit(string arr)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            FPOOrdermaster objmodel = new FPOOrdermaster();
            List<int> list = new List<int>();
            string OutputResult = "";
            if (!string.IsNullOrEmpty(arr.ToString()))
            {
                string[] multiArray = arr.Split(new Char[] { ' ', ',', '.', '-', '\n', '\t', '[', ']', '"' });
                string abc = arr.Remove(0, 1);
                string xyz = abc.Remove(abc.Length - 1, 1);
                foreach (string id in multiArray)
                {
                    if (id.Trim() != "")
                    {
                        objmodel.CreatedBy = profile.UserId;
                        objmodel.FPO_Id = Convert.ToInt32(id);
                        objobjmodel = _objFPOMasterModel.AddFPOCreator(objmodel);
                    }
                    OutputResult = Convert.ToString(xyz);
                }
            }
            return Json(OutputResult);
        }
        #region DSC  
        /// <summary>
        /// Method to check digital signature response data
        /// </summary>
        /// <param name="contentType"></param>
        /// <param name="signDataBase64Encoded"></param>
        /// <param name="responseType"></param>
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
        /// Method to get digital signature response data
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
        #endregion
    }
}