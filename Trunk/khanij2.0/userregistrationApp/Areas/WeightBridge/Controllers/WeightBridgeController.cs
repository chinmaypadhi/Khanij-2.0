// ***********************************************************************
//  Controller Name          : WeightBridge
//  Desciption               : Add,View,Edit,Forward WeighBridge
//  Created By               : Ranjan Kumar Behera
//  Created On               : 28 February 2022
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using userregistrationApp.ActionFilter;
using userregistrationApp.Areas.Contractor.Models.VTDVendor;
using userregistrationApp.Areas.WeightBridge.Models;
using userregistrationApp.Models.EncryptDecrypt;
using userregistrationApp.Models.MailService;
using userregistrationApp.Models.SMSService;
using userregistrationApp.Web;
using userregistrationEF;

namespace userregistrationApp.Areas.WeightBridge.Controllers
{
    [Area("WeightBridge")]
    public class WeightBridgeController : Controller
    {
        #region declaration and constructor dependency injection
        private readonly IAreaType objIareaType;
        private readonly IConfiguration configuration;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IWeighbridgeMake objIwbmake;
        private readonly IWeighBridgeModelType objIwbmodeltype;
        private readonly IWeighBridge objIweighbridge;

        private readonly IVTDVendor vTDVendor;
        private readonly ISMSModel sMSModel;
        private readonly IMailModel mailModel;
        string Signature = string.Empty;
        string OutputResult = string.Empty;

        AddWeighBridgeModel objaddweighbridemodel = new AddWeighBridgeModel();
        List<ViewWeighBridgeModel> objviewweighbridgelist = new List<ViewWeighBridgeModel>();
        ViewWeighBridgeModel objviewweighbridge = new ViewWeighBridgeModel();
        MessageEF objmessage;

        public WeightBridgeController(IWeighBridge objIweighbridge, IAreaType objIareaType, IConfiguration configuration,
            IHostingEnvironment hostingEnvironment, IWeighbridgeMake objIwbmake, IWeighBridgeModelType objIwbmodeltype,
            IVTDVendor vTDVendor, ISMSModel sMSModel, IMailModel mailModel)
        {
            this.objIareaType = objIareaType;
            this.configuration = configuration;
            this.hostingEnvironment = hostingEnvironment;
            this.objIwbmake = objIwbmake;
            this.objIwbmodeltype = objIwbmodeltype;
            this.objIweighbridge = objIweighbridge;
            this.vTDVendor = vTDVendor;
            this.sMSModel = sMSModel;
            this.mailModel = mailModel;
        }
        #endregion
        /// <summary>
        /// WeighBridge Registration View
        /// </summary>
        /// <returns>View</returns>
        public IActionResult IndividualRegistration()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            ViewBag.Loginid = profile.UserName;
            ViewBag.Name = profile.ApplicantName;
            ViewBag.UserType = profile.UserType;
            ViewBag.District = profile.DistrictName;
            ViewBag.UserRoleInfo = profile.UserRoleInfo;
            ViewBag.UserTypeId = profile.UserTypeId;
            AreaDetails objareadetails = new AreaDetails();
            ViewData["AreaType"] = objIareaType.GetLandTypeList(objareadetails);
            ViewWeighBridgeMakeModel objmakemodel = new ViewWeighBridgeMakeModel();
            ViewData["WBMake"] = objIwbmake.View(objmakemodel);
            ViewData["Location"] = LocationList();
            ViewBag.submit = "SAVE";
            ViewBag.cancel = "RESET";
            return View(objaddweighbridemodel);
        }
        /// <summary>
        /// Get Weighbridge Model to Dropdown
        /// </summary>
        /// <param name="makeid"></param>
        /// <returns>Json</returns>
        public JsonResult GetWBModelByMake(string makeid)
        {
            ViewWeighBridgeModelTypeModel obj = new ViewWeighBridgeModelTypeModel();
            obj.WeighBridgeMakeID = makeid;
            List<ViewWeighBridgeModelTypeModel> list = objIwbmodeltype.ViewByMake(obj);
            return Json(list);
        }
        /// <summary>
        /// Get WeighBridge Details by ID for details popup
        /// </summary>
        /// <param name="weighbridgeID"></param>
        /// <returns>Json</returns>
        public JsonResult GetWBDetailsByID(string weighbridgeID)
        {
            ViewWeighBridgeModel obj = new ViewWeighBridgeModel();
            obj.WeighBridgeID = Convert.ToInt32(weighbridgeID);
            obj = objIweighbridge.ViewWBByWeighBridgeID(obj);
            return Json(obj);
        }
        /// <summary>
        /// Get WeighBridge History By ID
        /// </summary>
        /// <param name="weighbridgeID"></param>
        /// <returns>Json</returns>
        public JsonResult GetHistoryByID(string weighbridgeID)
        {
            ViewWeighBridgeModel obj = new ViewWeighBridgeModel();
            obj.WeighBridgeID = Convert.ToInt32(weighbridgeID);
            List<ViewWeighBridgeModel> list = new List<ViewWeighBridgeModel>();
            list = objIweighbridge.HistoryWBByID(obj);
            return Json(list);
        }
        /// <summary>
        /// Post of WeighBridge Registration
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="submit"></param>
        /// <returns>View</returns>
        [HttpPost]
        public IActionResult Register(AddWeighBridgeModel obj, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            ViewBag.Loginid = profile.UserLoginId;
            ViewBag.Name = profile.ApplicantName;
            ViewBag.UserType = profile.UserRoleInfo;
            ViewBag.District = profile.DistrictName;
            obj.CreatedBy = profile.UserId;
            obj.UserID = profile.UserId;
            obj.UserType = profile.UserType;
            obj.District = profile.DistrictName;

            //checking stamp validity is valid or not
            if (obj.StampValidFrom >= obj.StampValidTo)
            {
                ModelState.AddModelError("StampValidTo", "Stamp Valid From cannot be same or greater than Stamp Valid To");
            }
            //checking if weibridgename already exists
            objviewweighbridge.WeighBridgeName = obj.WeighBridgeName;
            objmessage = objIweighbridge.WBCheck(objviewweighbridge);
            if (objmessage.Satus == "1" && submit == "SAVE")
            {
                ModelState.AddModelError("WeighBridgeName", "Weigh Bridge Name already Exists");
            }
            //chekcing if contact numbe already exists
            objviewweighbridge.SupervisorContact = obj.SupervisorContact;
            objmessage = objIweighbridge.WBCheckContact(objviewweighbridge);
            //duplicate contact number allowed now according to CTL
            //if (objmessage.Satus == "1" && submit == "SAVE")
            //{
            //    ModelState.AddModelError("SupervisorContact", "Contact number already exists");
            //}
            if (ModelState.IsValid)
            {
                string uniquestampcopy = "";
                string uniquestampcopypath = "";
                if (obj.StampCopy != null)
                {

                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Upload/WeighBridge");
                    uniquestampcopy = Guid.NewGuid().ToString() + "_" + obj.StampCopy.FileName;
                    uniquestampcopypath = Path.Combine(uploadsFolder, uniquestampcopy);
                    obj.StampCopy.CopyTo(new FileStream(uniquestampcopypath, FileMode.Create));
                    obj.StampCopyFilePath = uniquestampcopy;
                }
                string fdfd = obj.StampCopyFilePath;
                obj.StampCopy = null;
                if (submit == "SAVE")
                {
                    objmessage = objIweighbridge.WBRegister(obj);
                    if (objmessage.Satus == "1")
                    {
                        TempData["Message"] = "wbsaved";
                    }
                    else
                    {
                        TempData["Message"] = "error";
                    }
                }
                else
                {
                    objmessage = objIweighbridge.WBRegisterEdit(obj);
                    if (objmessage.Satus == "1")
                    {
                        TempData["Message"] = "wbupdated";
                    }
                    else
                    {
                        TempData["Message"] = "error";
                    }
                }
                return RedirectToAction("IndividualRegistrationView");
            }
            else
            {
                AreaDetails objareadetails = new AreaDetails();
                ViewData["AreaType"] = objIareaType.GetLandTypeList(objareadetails);
                ViewWeighBridgeMakeModel objmakemodel = new ViewWeighBridgeMakeModel();
                ViewData["WBMake"] = objIwbmake.View(objmakemodel);
                ViewData["Location"] = LocationList();
                ViewBag.submit = submit;
                if (submit == "SAVE")
                {
                    ViewBag.cancel = "RESET";
                }
                else
                {
                    ViewBag.cancel = "CANCEL";
                }

                TempData["Message"] = "3";
                return View("IndividualRegistration", obj);
            }
        }
        /// <summary>
        /// Get WeighBridge Details by ID for edit
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>View</returns>
        /// 
        [SkipEncryptedTask]
        public IActionResult WBByID(string ID)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            ViewBag.Loginid = profile.UserLoginId;
            ViewBag.Name = profile.ApplicantName;
            ViewBag.UserType = profile.UserType;
            ViewBag.District = profile.DistrictName;
            AreaDetails objareadetails = new AreaDetails();
            ViewData["AreaType"] = objIareaType.GetLandTypeList(objareadetails);
            ViewWeighBridgeMakeModel objmakemodel = new ViewWeighBridgeMakeModel();
            ViewData["WBMake"] = objIwbmake.View(objmakemodel);
            ViewData["Location"] = LocationList();
            objviewweighbridge.WeighBridgeID = Convert.ToInt32(ID);
            objaddweighbridemodel = objIweighbridge.WBByID(objviewweighbridge);
            ViewBag.submit = "UPDATE";
            ViewBag.cancel = "CANCEL";
            return View("IndividualRegistration", objaddweighbridemodel);
        }
        /// <summary>
        /// Get Location List for Dropdown
        /// </summary>
        /// <returns>list<string></returns>
        public List<string> LocationList()
        {
            List<string> list = new List<string>();
            list.Add("Inside Lease");
            list.Add("Outside Lease");
            return list;
        }
        /// <summary>
        /// WeighBridge Renewal View
        /// </summary>
        /// <returns>View</returns>
        public IActionResult IndividualRegistrationRenewal()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objviewweighbridge.UserID = profile.UserId;
            ViewData["WBList"] = objIweighbridge.RenewalWBByUserID(objviewweighbridge);
            return View();
        }
        /// <summary>
        /// WeighBridge Renewal View by User ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>View</returns>
        [SkipEncryptedTask]
        public IActionResult UpdateWBValidity(string ID)
        {

            objviewweighbridge.WeighBridgeID = Convert.ToInt32(ID);
            objviewweighbridge = objIweighbridge.ViewWBByWeighBridgeID(objviewweighbridge);
            return View(objviewweighbridge);
        }
        /// <summary>
        /// Post of WeighBridge Renew
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>View</returns>
        [HttpPost]
        public IActionResult RequestWBValidity(AddWeighBridgeRenewal obj)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            obj.UserID = profile.UserId;
            if (ModelState.IsValid)
            {
                string uniqueordercopy = "";
                string uniqueordercopypath = "";
                if (obj.StampCopy != null)
                {

                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Upload/WeighBridge");
                    uniqueordercopy = Guid.NewGuid().ToString() + "_" + obj.StampCopy.FileName;
                    uniqueordercopypath = Path.Combine(uploadsFolder, uniqueordercopy);
                    obj.StampCopy.CopyTo(new FileStream(uniqueordercopypath, FileMode.Create));
                }
                obj.StampCopy = null;
                obj.StampCopyFilePath = uniqueordercopy;
                objmessage = objIweighbridge.WBRenewal(obj);
                if (objmessage.Satus == "1")
                {
                    TempData["Message"] = "renewalrequested";
                }
                else
                {
                    TempData["Message"] = "error";
                }
            }
            return RedirectToAction("IndividualRegistrationView");
        }
        /// <summary>
        /// WeighBridge View by User ID
        /// </summary>
        /// <returns>View</returns>
        public IActionResult IndividualRegistrationView()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objviewweighbridge.UserID = profile.UserId;
            ViewBag.UserType = profile.UserType;
            ViewData["WBList"] = objIweighbridge.ViewWBByUserID(objviewweighbridge);
            return View();
        }
        /// <summary>
        /// Post of WeighBridge Forward
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>View</returns>
        [HttpPost]
        public IActionResult Forward(int ID ,int ActivityId)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objviewweighbridge.UserID = profile.UserId;
            objviewweighbridge.WeighBridgeID = Convert.ToInt32(ID);
            objviewweighbridge.ActivityId = Convert.ToInt32(ActivityId);
            objmessage = objIweighbridge.WBForward(objviewweighbridge);
            if (objmessage.Satus == "1")
            {
                TempData["Message"] = "forwarded";
            }
            else
            {
                TempData["Message"] = "error";
            }
            return RedirectToAction("IndividualRegistrationView");
        }
        /// <summary>
        /// Approval View of WeighBridge to be done by DD/MO
        /// </summary>
        /// <returns>View</returns>
        public IActionResult WBApproval()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            if (profile.UserTypeId == 5)
            {
                objviewweighbridge.District = profile.DistrictName;
                ViewData["WBList"] = objIweighbridge.ViewWBByDistrict(objviewweighbridge);
            }
            else
            {
                ViewData["WBList"] = objviewweighbridgelist;
            }
            return View();
        }
        /// <summary>
        /// Post of WEighbridge Approve to be done by DD/MO
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>View</returns>
        [HttpPost]
        public IActionResult Approve(ViewWeighBridgeModel obj)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            obj.UserID = profile.UserId;
            if (ModelState.IsValid)
            {
                string uniqueordercopy = "";
                string uniqueordercopypath = "";
                if (obj.ApprovalOrderFile != null)
                {

                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Upload/WeighBridge");
                    uniqueordercopy = Guid.NewGuid().ToString() + "_" + obj.ApprovalOrderFile.FileName;
                    uniqueordercopypath = Path.Combine(uploadsFolder, uniqueordercopy);
                    obj.ApprovalOrderFile.CopyTo(new FileStream(uniqueordercopypath, FileMode.Create));
                }
                obj.ApprovalOrderFile = null;
                obj.ApprovalOrderFilePath = uniqueordercopy;
                objmessage = objIweighbridge.WBApprove(obj);
                if (objmessage.Satus == "1")
                {
                    TempData["Status"] = "1";
                    if(obj.ApproveType== "2")//Approve
                        TempData["Message"] = "Weighbridge application number approved successfully..";
                    else if(obj.ApproveType == "4")//object
                        TempData["Message"] = "Weighbridge application number objected successfully..";
                    else if (obj.ApproveType == "3")//Reject
                        TempData["Message"] = "Weighbridge application number rejected successfully..";
                }
                else
                {
                    int Outputres = Convert.ToInt32(objmessage.Satus);
                    if (Outputres > 0)
                    {
                        ViewIndependentUserDetailModel viewindependentmodel = new ViewIndependentUserDetailModel();
                        viewindependentmodel.UserId = Convert.ToInt32(objmessage.Satus);
                        viewindependentmodel = objIweighbridge.ViewIndependentByUserID(viewindependentmodel);
                        if (viewindependentmodel.UserName != null && viewindependentmodel.Password != null)
                        {
                            if (viewindependentmodel.UserName != "" && viewindependentmodel.Password != "")
                            {
                                #region encryptPassword

                                string s = EncryptDecryptSha256.ComputeSha256Hash(viewindependentmodel.Password).ToUpper();
                                string s1 = EncryptDecryptSha256.ComputeSha256Hash(s).ToUpper();
                                vTDVendor.UpdateEncryptPassword(new UpdateEncryptPasswordModel() { UserName = viewindependentmodel.UserName, EncryptPassword = s1 });

                                #endregion

                                #region Send SMS
                                try
                                {
                                    string message = "";

                                    message = "Dear Weighbridge Owner, Approval of your Application is Approved. Please check your e-mail for details of registration";

                                    string templateid = "1307161883515998678";
                                    sMSModel.Main(new SMS() { mobileNo = viewindependentmodel.SupervisorContact, message = message, templateid = templateid });
                                }
                                catch (Exception)
                                {

                                }
                                #endregion

                                #region Send Mail
                                try
                                {
                                    mailModel.SendMail(new TransporterMail()
                                    {
                                        EmailId = viewindependentmodel.Email,
                                        TransporterName = viewindependentmodel.SupervisorName,
                                        UserName = viewindependentmodel.UserName,
                                        Password = viewindependentmodel.Password,
                                        UserCode = viewindependentmodel.UserName,
                                    });

                                }
                                catch (Exception)
                                {

                                }
                                #endregion

                            }
                        }
                    }
                    TempData["Status"] = "1";
                    TempData["Message"] = "WeighBridge " + obj.ApproveType + "d Successfully";
                }
            }
            return RedirectToAction("WBApproval");
        }
        /// <summary>
        /// Gets Digital Signature
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>strSign</returns>
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
        /// Verification of Digital Signature
        /// </summary>
        /// <param name="contentType"></param>
        /// <param name="signDataBase64Encoded"></param>
        /// <returns>OutputResult</returns>
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
        [HttpPost]
        public IActionResult viewActionList(ViewWeighBridgeModel obj)
        {

            return Json(objIweighbridge.ViewWeighBridgeTagActionList(obj));
        }
    }
}
