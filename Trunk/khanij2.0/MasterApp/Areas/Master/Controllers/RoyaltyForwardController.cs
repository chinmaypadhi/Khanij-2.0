
using System;
using System.Collections.Generic;
using MasterApp.Areas.Master.Models.RoyaltyForward;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class RoyaltyForwardController : Controller
    {
        IRoyaltyForwardModel _objRoyaltyForwardmasterModel;
        MessageEF objobjmodel = new MessageEF();

        string Signature = string.Empty;
        string OutputResult = string.Empty;

        public RoyaltyForwardController(IRoyaltyForwardModel objRoyaltyForwardmasterModel)
        {
            _objRoyaltyForwardmasterModel = objRoyaltyForwardmasterModel;
        }
        public IActionResult ViewList()
        {
            RoyaltyForwardmaster objmodel = new RoyaltyForwardmaster();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.CreatedBy = profile.UserId;
            objmodel.intModuleId = 1;
            objmodel.intSubModuleId = 5;
            objmodel.Check = 1;
            try
            {
                ViewBag.ViewList = _objRoyaltyForwardmasterModel.View(objmodel);
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public JsonResult Submit(string arr)
        {
            try
            {
                RoyaltyForwardmaster objmodel = new RoyaltyForwardmaster();
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.CreatedBy = profile.UserId;

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
                            objmodel.RoyaltyId = Convert.ToInt32(id);
                            objmodel.Check = 2;
                            objmodel.intModuleId = 1;
                            objmodel.intSubModuleId = 5;
                            objobjmodel = _objRoyaltyForwardmasterModel.Submit(objmodel);
                        }
                        OutputResult = Convert.ToString(xyz);
                        //list.Add(id);
                    }

                    //val = list.ToArray();
                }

                //bool result = objobjmodel.Satus == "1" ? true : false;
                //ViewBag.msg = objobjmodel.Satus;
                //return View(objmodel);
                return Json(OutputResult);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Download_Royalty(int? id)
        {
            try
            {
                RoyaltyForwardmaster objmodel = new RoyaltyForwardmaster();
                objmodel.RoyaltyId = id;
                objmodel = _objRoyaltyForwardmasterModel.Download(objmodel)[0];
                return View(objmodel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region royaltyInbox
        public IActionResult RoyaltyInbox()
        {
            RoyaltyForwardmaster objmodel = new RoyaltyForwardmaster();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.CreatedBy = profile.UserId;
            objmodel.intModuleId = 1;
            objmodel.intSubModuleId = 5;
            objmodel.Check = 1;
            try
            {
                ViewBag.ViewList = _objRoyaltyForwardmasterModel.RoyaltyInbox(objmodel);
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public JsonResult TakeAction(int RoyaltyId, int IsApproved, string Remarks)
        {
            RoyaltyForwardmaster objRoyalty = new RoyaltyForwardmaster();
            MessageEF objMessage = new MessageEF();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objRoyalty.ModifiedBy = profile.UserId;
            try
            {
                objRoyalty.Check = 1;//---approve/Reject by Asst Director
                objRoyalty.RoyaltyId = RoyaltyId;
                objRoyalty.IsApproved = IsApproved;
                objRoyalty.Remarks = Remarks;

                objRoyalty.intModuleId = 1;//----master module
                objRoyalty.intSubModuleId = 5;//---royalty submodule

                objMessage = _objRoyaltyForwardmasterModel.TakeAction(objRoyalty);
                //objobjmodel = _objRoyaltyForwardmasterModel.Submit(objmodel);
                return Json(objMessage);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult RoyaltyInboxView()
        {
            List<RoyaltyApprovedEF> listRoyalty = new List<RoyaltyApprovedEF>();
            RoyaltyApprovedEF objRoyalty = new RoyaltyApprovedEF();

            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objRoyalty.CreatedBy = profile.UserId;
            try
            {
                //ViewBag.ActionType = Enumerable.Empty<SelectListItem>();
                objRoyalty.Check = 2;
                objRoyalty.intModuleId = 1;//----master module
                objRoyalty.intSubModuleId = 5;//---royalty submodule--RoyaltyInboxView
                listRoyalty = _objRoyaltyForwardmasterModel.RoyaltyInboxView(objRoyalty);
            }
            catch (Exception)
            {

                throw;
            }
            return View(listRoyalty);
        }

        public JsonResult ViewRoyaltyActionHistory(int? intRoyaltyId)
        {
            try
            {
                RoyaltyApprovedLogEF objEmpDropDown = new RoyaltyApprovedLogEF();
                objEmpDropDown.Check = 3;
                objEmpDropDown.RoyaltyId = intRoyaltyId;
                var ActionHistory = _objRoyaltyForwardmasterModel.ViewRoyaltyActionHistory(objEmpDropDown);
                return Json(ActionHistory);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region DSC   
        /// <summary>
        /// Digital Signature
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