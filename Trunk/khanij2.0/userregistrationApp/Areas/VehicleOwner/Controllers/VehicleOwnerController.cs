// ***********************************************************************
//  Controller Name          : VehicleOwner
//  Desciption               : Vehicle Owner Details 
//  Created By               : Akshaya Dalei
//  Created On               : 24 July 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using userregistrationApp.ActionFilter;
using userregistrationApp.Areas.VehicleOwner.Models.VehicleRegistration;
using userregistrationApp.Models.EncryptDecrypt;
using userregistrationApp.Models.MailService;
using userregistrationApp.Models.SMSService;
using userregistrationApp.Models.WebsiteMenu;
using userregistrationApp.Web;
using userregistrationEF;

namespace userregistrationApp.Areas.VehicleOwner.Controllers
{
    [Area("VehicleOwner")]
    public class VehicleOwnerController : Controller
    {
        private readonly IVehicleRegistrationModel vehicleRegistrationModel;
        private readonly IWebsiteMenuModel websiteMenuModel;
        private readonly IMailModel mailModel;
        private readonly ISMSModel sMSModel;
        MessageEF messageEF = new MessageEF();
        List<TransporterModel> lsttransporterModels = new List<TransporterModel>();
        TransporterModel transporterModel = new TransporterModel();

        public VehicleOwnerController(IVehicleRegistrationModel vehicleRegistrationModel, IWebsiteMenuModel websiteMenuModel, IMailModel mailModel, ISMSModel sMSModel)
        {
            this.vehicleRegistrationModel = vehicleRegistrationModel;
            this.websiteMenuModel = websiteMenuModel;
            this.mailModel = mailModel;
            this.sMSModel = sMSModel;
        }

        #region Vehicle Owner Registration View
        /// <summary>
        ///View Registration Page
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [SkipImportantTask]
        public IActionResult Registration()
        {
             
            //ViewData["TopmenuTable"] = websiteMenuModel.GetTopmenulist();
            ViewData["MainmenuTable"] =websiteMenuModel.GetMainmenulist();
            ViewData["FootermenuTable"] =websiteMenuModel.GetFootermenulist();

            if (TempData["AckMessage"] != null)
            {
                ViewBag.msg = TempData["AckMessage"].ToString();
            }
            if (TempData["UserName"] != null)
            {
                ViewBag.UserName = TempData["UserName"].ToString();
            }
            if (TempData["UserCode"] != null)
            {
                ViewBag.UserCode = TempData["UserCode"].ToString();
            }
            if (TempData["Password"] != null)
            {
                ViewBag.Password = TempData["Password"].ToString();
            }

            lsttransporterModels =vehicleRegistrationModel.ViewState(transporterModel);
            ViewData["StateDetails"] =lsttransporterModels;

            lsttransporterModels =vehicleRegistrationModel.GetSQuestion(transporterModel);
            ViewData["SQuestion"] =lsttransporterModels;

            transporterModel = vehicleRegistrationModel.GetRecordForReport(transporterModel);

            return View(transporterModel);
        }
        #endregion

        #region Save Vehicle Owner Registration
        /// <summary>
        /// To Save Vehicle Owner
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [SkipImportantTask]
        [HttpPost]
        public IActionResult Registration(TransporterModel model)
        {
           // messageEF = vehicleRegistrationModel.VerifyMobile(model);
            //if (string.IsNullOrEmpty(messageEF.Satus))
            //{

                if (model.PaymentMode == null)
                {
                    #region Offline Payment 
                    string EmailId = model.EmailID;
                    string TransporterName = model.TransporterName;
                    string MobileNo = model.MobileNo;
                    messageEF = vehicleRegistrationModel.Add(model);

                    if (Convert.ToInt32(messageEF.Satus) > 0)
                    {
                        TempData["AckMessage"] = "1";
                        model.TransactionalID = messageEF.Satus;
                        model = vehicleRegistrationModel.GetUserNamePassword(model);
                        TempData["UserName"] = model.UserName;
                        TempData["UserCode"] = model.UserCode;
                        TempData["Password"] = model.Password;
                        model.EmailID = EmailId;
                        model.TransporterName = TransporterName;
                        model.MobileNo= MobileNo;
                        if (model.UserName != null && model.Password != null)
                        {
                            if (model.UserName != "" && model.Password != "")
                            {
                                //----added on 2-dec-2021 for password encrypt
                                #region encryptPassword

                                string s = EncryptDecryptSha256.ComputeSha256Hash(model.Password).ToUpper();
                                string s1 = EncryptDecryptSha256.ComputeSha256Hash(s).ToUpper();
                                vehicleRegistrationModel.UpdateEncryptPassword(new UpdateEncryptPasswordModel() {UserName= model.UserName,EncryptPassword=s1 });
                                
                                #endregion

                                #region Send Mail
                                try
                                {
                                    TransporterMail uModel = new TransporterMail();
                                    uModel.EmailId = model.EmailID;
                                    uModel.TransporterName = model.TransporterName;
                                    uModel.UserName = model.UserName;
                                    uModel.Password = model.Password;
                                    uModel.UserCode = model.UserCode;
                                    messageEF = mailModel.SendMail(uModel);
                                }
                                catch (Exception)
                                {
                                    TempData["AckMessage"] = "0";
                                    return RedirectToAction("Registration", "VehicleOwner");
                                }
                                #endregion

                                #region Send SMS

                                try
                                { 
                                    string message = "Vehicle Owner Registration" + Environment.NewLine + Environment.NewLine + "You have successfully registered with Khanij Online Portal as a Vehicle Owner. Your Registration Number is " + model.UserCode + " Dated " + System.DateTime.Now + Environment.NewLine + Environment.NewLine +
                                                       "You can login into Khanij Online Portal using below login credential " + Environment.NewLine + Environment.NewLine +
                                                        "User Name : " + model.UserName + Environment.NewLine + Environment.NewLine +
                                                        "Password : " + model.Password + Environment.NewLine + Environment.NewLine + Environment.NewLine + 
                                                        "Please check your e-mail for details of registration. CHiMMS, GoCG";
                                    string templateid = "1307161883535317675";// 1307161883535317675
                                    SMS sMS = new SMS();
                                    sMS.mobileNo = model.MobileNo;
                                    sMS.message = message;
                                    sMS.templateid = templateid;
                                    messageEF = sMSModel.Main(sMS);

                                }
                                catch (Exception)
                                {

                                }

                                return RedirectToAction("Registration", "VehicleOwner");
                                #endregion
                            }

                        }

                        return RedirectToAction("Registration", "VehicleOwner");
                    }
                    else
                    {
                        TempData["AckMessage"] = "0";
                        return RedirectToAction("Registration", "VehicleOwner");
                    }
                    #endregion
                }

            //}
            

            return RedirectToAction("Registration", "VehicleOwner", new { area = "VehicleOwner" });

        }
        #endregion

        #region Get District By State
        /// <summary>
        /// To Get District By State Id
        /// </summary>
        /// <param name="StateId"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public JsonResult GetDistrictByStateId(int? StateId)
        {
            transporterModel.StateId = StateId;
            lsttransporterModels = vehicleRegistrationModel.ViewDistrict(transporterModel);
            return Json(lsttransporterModels);
        }
        #endregion

        #region View Vehicle Owner Profile
        /// <summary>
        /// To Get Vehicle Owner Profile
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        
        public IActionResult Profile()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.msg = TempData["Message"];
            }
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            transporterModel.TransactionalID = profile.UserId.ToString();
            transporterModel = vehicleRegistrationModel.VehicleRegistrationProfile(transporterModel);
            return View(transporterModel);
        }
        #endregion

        #region Edit Vehicle Owner
        /// <summary>
        /// To Edit Vehicle Owner
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        
        public IActionResult EditProfile()
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            lsttransporterModels = vehicleRegistrationModel.ViewState(transporterModel);
            ViewData["StateDetails"] = lsttransporterModels;

            lsttransporterModels = vehicleRegistrationModel.GetSQuestion(transporterModel);
            ViewData["SQuestion"] = lsttransporterModels;

            transporterModel.TransactionalID =profile.UserId.ToString(); //"30728"; //"29576";
            transporterModel = vehicleRegistrationModel.Edit(transporterModel);


            lsttransporterModels = vehicleRegistrationModel.ViewDistrict(transporterModel);
            ViewData["District"] = lsttransporterModels;

            return View(transporterModel);
        }
        #endregion

        #region Update Vehicle Owner Profile
        /// <summary>
        /// To Update Vehicle Owner Profile
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns></returns>
        public IActionResult UpdateProfile(TransporterModel transporterModel)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            if (transporterModel.TINNo == "Not/Applicable")
                transporterModel.TINNo = null;
            transporterModel.UserId = profile.UserId;
            messageEF = vehicleRegistrationModel.Update(transporterModel);
            if (messageEF.Satus == "1")
                TempData["Message"] = "Profile updated successfully.";
            else if (messageEF.Satus == "2")
                TempData["Message"] = "This mobile number or email-id already in use! Please enter with new mobile number or email-id.";
            else
                TempData["Message"] = "Profile can not updated !";
            return RedirectToAction("Profile", "VehicleOwner");
        }
        #endregion

        #region Print PDF 
        /// <summary>
        /// To Print PDF
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SkipEncryptedTask]
        public ActionResult PrintGetUserDetails(string Type)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            ViewBag.Type = Type;
            transporterModel.TransactionalID = profile.UserId.ToString(); //"29576";
            transporterModel = vehicleRegistrationModel.Edit(transporterModel);
            return View(transporterModel);
        }
        #endregion

        #region Send OTP
        /// <summary>
        /// To Send OTP
        /// </summary>
        /// <param name="MobileNumber,EmailID"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public JsonResult SendOTP(string MobileNumber, string EmailID)
        {
            if (!string.IsNullOrEmpty(MobileNumber))
            {
                messageEF = vehicleRegistrationModel.VerifyMobile(new TransporterModel() {MobileNo= MobileNumber,EmailID= EmailID });
                if (string.IsNullOrEmpty(messageEF.Satus))
                {
                    try
                    {
                        messageEF = vehicleRegistrationModel.GetOTP(new TransporterModel() { MobileNo = MobileNumber, EmailID = EmailID });
                        if (!string.IsNullOrEmpty(messageEF.Satus))
                        {

                            string message = "Your One time code for Khanij Online application is : " + messageEF.Satus + " CHiMMS, GoCG";
                            string templateid = "1307161883520738720";
                            sMSModel.Main(new SMS() { mobileNo = MobileNumber, message = message, templateid = templateid });
                            mailModel.SendMail_EUP(new TransporterMail() { EmailId = EmailID, MobileNo = messageEF.Satus, Type = "OTP" });

                            return Json("SUCCESS");
                        }
                        else
                        {
                            return Json("FAILED");
                        }


                    }
                    catch (Exception ex)
                    {
                        return Json("FAILED");
                    }
                }
                else
                {
                    return Json("Mobile Number Already Exist.Duplicate Not Allowed.");
                }
            }
            else
            {
                return Json("No Mobile Number Entered");
            }
        }
        #endregion

        #region VerifyOTP
        /// <summary>
        /// To Verify OTP
        /// </summary>
        /// <param name="MobileNumber,EmailID,OTP"></param>
        /// <returns></returns>
       [SkipImportantTask]
        public JsonResult VerifyOTP(string MobileNumber, string EmailID, string OTP)
        {
            if (!string.IsNullOrEmpty(MobileNumber) && !string.IsNullOrEmpty(EmailID) && !string.IsNullOrEmpty(OTP))
            {
                transporterModel.MobileNo = MobileNumber;
                transporterModel.EmailID = EmailID;
                transporterModel.VerifyOTP = OTP;
                messageEF = vehicleRegistrationModel.VerifyOTP(transporterModel);
                return Json(messageEF.Satus);
            }
            else
            {
                return Json("REQUIRED");
            }
        }
        #endregion

        #region Captcha Code
        /// <summary>
        /// To Generate Captcha
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public JsonResult CaptchaImage()
        {
            var rand = new Random((int)DateTime.Now.Ticks);

            int a = rand.Next(10, 99);
            int b = rand.Next(0, 9);
            var captcha = GetRandomText();



            return Json(captcha);
        }

        private string GetRandomText()
        {
            StringBuilder randomText = new StringBuilder();
            string alphabets = "012345679ACEFGHKLMNPRSWXZabcdefghijkhlmnopqrstuvwxyz";
            Random r = new Random();
            for (int j = 0; j <= 5; j++)
            {
                randomText.Append(alphabets[r.Next(alphabets.Length)]);
            }
            return randomText.ToString();
        }

        #endregion




    }


}