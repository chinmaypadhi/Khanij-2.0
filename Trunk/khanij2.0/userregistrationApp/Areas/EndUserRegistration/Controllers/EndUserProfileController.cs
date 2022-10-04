// ***********************************************************************
//  Controller Name          : EndUserProfile
//  Desciption               : Add End User Data
//  Created By               : Debaraj Swain
//  Created On               : 30 March 2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationApp.Web;
using userregistrationEF;
using userregistrationApp.Areas.EndUserRegistration.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Net.Mail;
using Microsoft.AspNetCore.Hosting;
using userregistrationApp.ActionFilter;
using userregistrationApp.Models.WebsiteMenu;
using userregistrationApp.Models.SMSService;
using userregistrationApp.Models.MailService;
using userregistrationApp.Models.EncryptDecrypt;

namespace userregistrationApp.Areas.EndUserRegistration.Controllers
{
    [Area("EndUserRegistration")]
    public class EndUserProfileController : Controller
    {
        IEndUserRegModel _objIEndUserRegModel;
        MessageEF objobjmodel = new MessageEF();
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IWebsiteMenuModel websiteMenuModel;
        private readonly ISMSModel sMSModel;
        private readonly IMailModel mailModel;
        string OutputResult = "";
        public EndUserProfileController(IEndUserRegModel objEndUserRegModel, IHostingEnvironment hostingEnvironment,
            IWebsiteMenuModel websiteMenuModel, ISMSModel sMSModel, IMailModel mailModel)
        {
            _objIEndUserRegModel = objEndUserRegModel;
            this.hostingEnvironment = hostingEnvironment;
            this.websiteMenuModel = websiteMenuModel;
            this.sMSModel = sMSModel;
            this.mailModel = mailModel;
        }

        /// <summary>
        /// Get portion of EndUser Registration data
        /// </summary>
        /// <returns>View</returns>
        [SkipImportantTask]
        public IActionResult ProfileView()
        {
            ViewData["MainmenuTable"] = websiteMenuModel.GetMainmenulist();
            ViewData["FootermenuTable"] = websiteMenuModel.GetFootermenulist();

            //UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            EndUserModel objmodel = new EndUserModel();
            objmodel.UserId = null; //1;
            var x = _objIEndUserRegModel.GetIType(objmodel);

            if (x.IndustryType != null)
            {
                ViewBag.ViewIndustryList = x.IndustryType.Select(c => new SelectListItem
                {
                    Text = c.Type,
                    Value = c.EUP_Id.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewIndustryList = Enumerable.Empty<SelectListItem>();
            }

            var y = _objIEndUserRegModel.GetState(objmodel);

            if (y.ListOfState != null)
            {
                ViewBag.ViewStateList = y.ListOfState.Select(c => new SelectListItem
                {
                    Text = c.StateName,
                    Value = c.StateId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewStateList = Enumerable.Empty<SelectListItem>();
            }

            var Z = _objIEndUserRegModel.GetState_O(objmodel);

            if (Z.ListOfState != null)
            {
                ViewBag.ViewStateList_O = Z.ListOfState.Select(c => new SelectListItem
                {
                    Text = c.StateName_O,
                    Value = c.StateId_O.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewStateList_O = Enumerable.Empty<SelectListItem>();
            }

            var S = _objIEndUserRegModel.GetSQ(objmodel);

            if (S.ListOfState != null)
            {
                ViewBag.ViewSQ = S.ListOfState.Select(c => new SelectListItem
                {
                    Text = c.SQuestion,
                    Value = c.SQuestionId.ToString(),
                }).ToList();
            }
            else
            {
                ViewBag.ViewSQ = Enumerable.Empty<SelectListItem>();
            }


            objmodel.EndUserTypeStatus = "Individual/Proprietor";
            objmodel.Firm = "Partnership";
            objmodel.Company = "Private";
            var list = new SelectList(new[]
{
    new { ID = "Captive", Name = "Captive" },
    new { ID = "Non-Captive", Name = "Non-Captive" },

},
"ID", "Name", 1);
            ViewBag.ViewPuppose = list;

            if (TempData["AckMessage"] != null)
            {
                ViewBag.AckMessage = TempData["AckMessage"];
            }
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"];
            }



            return View(objmodel);
        }

        /// <summary>
        /// Post portion of End User Registration Data
        /// </summary>
        /// <param name="model"></param>
        /// <param name="submit"></param>
        /// <returns>View</returns>
        [SkipImportantTask]
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult ProfileView(EndUserModel model, List<int> MineralCount, List<int> MineralFormCount, List<int> MineralGradeCount, string submit)
        {
            string mineralid = "", mineralformid = "", mineralgradeid = "";
            string MobileNo = model.MobileNo;
            string EmailId = model.EMailId;

            //if (Int32.Equals(RecordCount, 0))
            //{
            #region Save User Profile
            string AAdharFileName = null; string AAdharfilePath = null;
            string PanFileName = null; string PanfilePath = null;
            string TinFileName = null; string TinfilePath = null;
            string GSTFileName = null; string GSTfilePath = null;
            string RCopyFileName = null; string RCopyfilePath = null;
            string AffitFileName = null; string AffitfilePath = null;
            string EBillFileName = null; string EBillfilePath = null;
            string CTOFileName = null; string CTOfilePath = null;
            model.RegistrationNo = "EUP" + string.Format("{0:yyyyMMdd}", DateTime.Now);
            if (model.AAdharDocument != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "EndUserRegistration\\Aadhar");
                AAdharFileName = Guid.NewGuid().ToString() + "_" + model.AAdharDocument.FileName;
                AAdharfilePath = Path.Combine(uploadsFolder, AAdharFileName);
                using (var fileStream = new FileStream(AAdharfilePath, FileMode.Create))
                    model.AAdharDocument.CopyTo(fileStream);
            }
            if (model.PanDocument != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "EndUserRegistration\\Pan");
                PanFileName = Guid.NewGuid().ToString() + "_" + model.PanDocument.FileName;
                PanfilePath = Path.Combine(uploadsFolder, PanFileName);
                using (var fileStream = new FileStream(PanfilePath, FileMode.Create))
                    model.PanDocument.CopyTo(fileStream);
            }
            if (model.TinDocument != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "EndUserRegistration\\Tin");
                TinFileName = Guid.NewGuid().ToString() + "_" + model.TinDocument.FileName;
                TinfilePath = Path.Combine(uploadsFolder, TinFileName);
                using (var fileStream = new FileStream(TinfilePath, FileMode.Create))
                    model.TinDocument.CopyTo(fileStream);
            }
            if (model.GstDocument != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "EndUserRegistration\\GST");
                GSTFileName = Guid.NewGuid().ToString() + "_" + model.GstDocument.FileName;
                GSTfilePath = Path.Combine(uploadsFolder, GSTFileName);
                using (var fileStream = new FileStream(GSTfilePath, FileMode.Create))
                    model.GstDocument.CopyTo(fileStream);
            }
            if (model.RcopyDocument != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "EndUserRegistration\\RCopy");
                RCopyFileName = Guid.NewGuid().ToString() + "_" + model.RcopyDocument.FileName;
                RCopyfilePath = Path.Combine(uploadsFolder, RCopyFileName);
                using (var fileStream = new FileStream(RCopyfilePath, FileMode.Create))
                    model.RcopyDocument.CopyTo(fileStream);
            }
            if (model.AffitDocument != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "EndUserRegistration\\ADoc");
                AffitFileName = Guid.NewGuid().ToString() + "_" + model.AffitDocument.FileName;
                AffitfilePath = Path.Combine(uploadsFolder, AffitFileName);
                using (var fileStream = new FileStream(AffitfilePath, FileMode.Create))
                    model.AffitDocument.CopyTo(fileStream);
            }
            if (model.EbillDocument != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "EndUserRegistration\\Ebill");
                EBillFileName = Guid.NewGuid().ToString() + "_" + model.EbillDocument.FileName;
                EBillfilePath = Path.Combine(uploadsFolder, EBillFileName);
                using (var fileStream = new FileStream(EBillfilePath, FileMode.Create))
                    model.EbillDocument.CopyTo(fileStream);
            }
            if (model.CTODocument != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "EndUserRegistration\\CTO");
                CTOFileName = Guid.NewGuid().ToString() + "_" + model.CTODocument.FileName;
                CTOfilePath = Path.Combine(uploadsFolder, CTOFileName);
                using (var fileStream = new FileStream(CTOfilePath, FileMode.Create))
                    model.CTODocument.CopyTo(fileStream);
            }
            model.IsSMS = true;
            model.IsMailed = true;
            model.IsMailedDateTime = DateTime.Now;
            model.IsSMSDate = DateTime.Now;
            string strAlert = string.Empty;



            if (AAdharFileName != null && AAdharfilePath != null)
            {
                model.Aadhaar_FILE_PATH = AAdharfilePath;
                model.Aadhaar_FILE_NAME = AAdharFileName;
            }

            if (PanFileName != null && PanfilePath != null)
            {
                model.PAN_FILE_PATH = PanfilePath;
                model.PAN_FILE_NAME = PanFileName;
            }

            if (TinFileName != null && TinfilePath != null)
            {
                model.TIN_FILE_PATH = TinfilePath;
                model.TIN_FILE_NAME = TinFileName;
            }

            if (GSTFileName != null && GSTfilePath != null)
            {
                model.GST_FILE_PATH = GSTfilePath;
                model.GST_FILE_NAME = GSTFileName;
            }

            if (CTOFileName != null && CTOfilePath != null)
            {
                model.CTO_FILE_PATH = CTOfilePath;
                model.CTO_FILE_NAME = CTOFileName;
            }

            if (AffitfilePath != null && AffitFileName != null)
            {
                model.ProductionCertificate_FILE_PATH = AffitfilePath;
                model.ProductionCertificate_FILE_NAME = AffitFileName;
            }

            if (EBillfilePath != null && EBillFileName != null)
            {
                model.ElectricityBill_FILE_PATH = EBillfilePath;
                model.ElectricityBill_FILE_NAME = EBillFileName;
            }

            if (RCopyFileName != null && RCopyfilePath != null)
            {
                model.RegistrationCopy_FILE_PATH = RCopyfilePath;
                model.RegistrationCopy_FILE_NAME = RCopyFileName;
            }


            if (MineralCount != null)
            {
                if (MineralCount.Count > 0)
                {
                    for (int i = 0; i < MineralCount.Count; i++)
                    {
                        mineralid += MineralCount[i].ToString();
                        mineralid += ",";
                    }
                }
            }

            model.MineralCnt = (MineralCount != null ? MineralCount.Count : 0);
            model.MineralId = mineralid;
            if (MineralFormCount != null)
            {
                if (MineralFormCount.Count > 0)
                {
                    for (int i = 0; i < MineralFormCount.Count; i++)
                    {
                        mineralformid += MineralFormCount[i].ToString();
                        mineralformid += ",";
                    }
                }
            }
            model.MineralFormCnt = (MineralFormCount != null ? MineralFormCount.Count : 0);
            model.MineralFormId = mineralformid;

            if (MineralGradeCount != null)
            {
                if (MineralGradeCount.Count > 0)
                {
                    for (int i = 0; i < MineralGradeCount.Count; i++)
                    {
                        mineralgradeid += MineralGradeCount[i].ToString();
                        mineralgradeid += ",";
                    }
                }
            }
            model.MineralGradeCnt = (MineralGradeCount != null ? MineralGradeCount.Count : 0);
            model.MineralGradeId = mineralgradeid;

            model.AAdharDocument = null;
            model.PanDocument = null;
            model.TinDocument = null;
            model.GstDocument = null;
            model.RcopyDocument = null;
            model.AffitDocument = null;
            model.EbillDocument = null;
            model.CTODocument = null;
            objobjmodel = _objIEndUserRegModel.AddEuser(model);
            int Outputres = Convert.ToInt32(objobjmodel.Satus);
            EndUserModel EUModel = new EndUserModel();
            if (Outputres > 0)
            {
                TempData["AckMessage"] = "1";
                EUModel.OutPutResult = Outputres;
                EUModel = _objIEndUserRegModel.GetUDModel(EUModel);

                TempData["UserCode"] = EUModel.UserCode;
                TempData["UserName"] = EUModel.UserName;
                TempData["Password"] = EUModel.Password;
                TempData["RegistrationNo"] = EUModel.RegistrationNo;

                string msg = "";
                if (string.Equals(model.NatureOfBusiness, "Industry") || string.Equals(model.NatureOfBusiness, "1"))
                {
                    if (model.StateId == 7)
                    {
                        msg = " Your Registration Number is " + EUModel.RegistrationNo + ". Approval of your Application is Pending at " + EUModel.DistrictName + " Mining Office, Chhattisgarh";
                    }
                    else { msg = " Your Registration Number is " + EUModel.RegistrationNo + ". Approval of your Application is Pending at Directorate of Geology and Mining, Chhattisgarh"; }
                }
                else
                {
                    msg = " Your Registration Number is " + EUModel.RegistrationNo + ". Approval of your Application is Pending at Directorate of Geology and Mining, Chhattisgarh";
                }
                TempData["SuccessMessage"] = msg;
                if (EUModel.UserName != null && EUModel.Password != null)
                {
                    if (EUModel.UserName != "" && EUModel.Password != "")
                    {
                        #region encryptPassword

                        string s = EncryptDecryptSha256.ComputeSha256Hash(EUModel.Password).ToUpper();
                        string s1 = EncryptDecryptSha256.ComputeSha256Hash(s).ToUpper();
                        _objIEndUserRegModel.UpdateEncryptPassword(new UpdateEncryptPasswordModel() { UserName = EUModel.UserName, EncryptPassword = s1 });

                        #endregion

                        #region Send SMS
                        try
                        {
                            string message = "";
                            if (string.Equals(model.NatureOfBusiness, "Industry") || string.Equals(model.NatureOfBusiness, "1"))
                            {
                                if (model.StateId == 7)
                                {
                                    message = "End User Registration, " + Environment.NewLine + Environment.NewLine + "You have successfully applied for Registration with Khanij Online Portal. Your Registration Number is " + EUModel.RegistrationNo + " Dated " + System.DateTime.Now + Environment.NewLine + Environment.NewLine +
                                                "Approval of your Application is Pending at District's Mining Office." + Environment.NewLine + Environment.NewLine +
                                                 "Please check your e-mail for details of registration";
                                }
                                else
                                {
                                    message = "End User Registration, " + Environment.NewLine + Environment.NewLine + "You have successfully applied for Registration with Khanij Online Portal. Your Registration Number is " + EUModel.RegistrationNo + " Dated " + System.DateTime.Now + Environment.NewLine + Environment.NewLine +
                                             "Approval of your Application is Pending at Directorate of Geology and Mining, Chhattisgarh." + Environment.NewLine + Environment.NewLine +
                                              "Please check your e-mail for details of registration";
                                }
                            }
                            else
                            {
                                message = "End User Registration, " + Environment.NewLine + Environment.NewLine + "You have successfully applied for Registration with Khanij Online Portal. Your Registration Number is " + EUModel.RegistrationNo + " Dated " + System.DateTime.Now + Environment.NewLine + Environment.NewLine +
                                      "Approval of your Application is Pending at Directorate of Geology and Mining, Chhattisgarh." + Environment.NewLine + Environment.NewLine +
                                       "Please check your e-mail for details of registration";
                            }

                            string templateid = "1307161883515998678";
                            sMSModel.Main(new SMS() { mobileNo = MobileNo, message = message, templateid = templateid });
                        }
                        catch (Exception)
                        {

                        }
                        #endregion

                        #region Send Mail
                        try
                        {

                            mailModel.SendMail_EUP(new TransporterMail()
                            {
                                EmailId = EmailId,
                                TransporterName = model.ApplicantName,
                                UserName = model.UserName,
                                Password = model.Password,
                                UserCode = model.UserCode,
                                RegistrationNo = model.RegistrationNo,
                                Type = "REGISTRATION"
                            });
                            //return RedirectToAction("ProfileView", "EndUserProfile");
                        }
                        catch (Exception)
                        {
                            TempData["AckMessage"] = "0";
                            return RedirectToAction("ProfileView", "EndUserProfile");
                        }
                        #endregion

                    }
                }

            }
            #endregion
            //}
            //else
            //{
            //    TempData["AckMessage"] = "3";
            //    // return View(model);
            //    return RedirectToAction("ProfileView", "EndUserProfile");
            //}


            return RedirectToAction("ProfileView", "EndUserProfile");
        }

        /// <summary>
        /// Create captcha Image
        /// </summary>
        /// <returns>Json String</returns>
        [SkipImportantTask]
        public JsonResult CaptchaImage()
        {
            var rand = new Random((int)DateTime.Now.Ticks);

            int a = rand.Next(10, 99);
            int b = rand.Next(0, 9);

            var captcha = GetRandomText();
            return Json(captcha);

        }

        /// <summary>
        /// Get random text for captcha
        /// </summary>
        /// <returns>String</returns>
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

        #region Send OTP
        /// <summary>
        /// Send OTP to mobile no
        /// </summary>
        /// <param name="MobileNumber"></param>
        /// <param name="EmailID"></param>
        /// <returns>String</returns>
        [SkipImportantTask]
        public JsonResult SendOTP(string MobileNumber, string EmailID)
        {
            if (!string.IsNullOrEmpty(MobileNumber))
            {
                try
                {
                    objobjmodel = _objIEndUserRegModel.ViewEndUserProfDetails(new EndUserModel1() { MobileNo = MobileNumber, EMailId = EmailID });
                    int RecordCount = int.Parse(objobjmodel.Msg);
                    if (Int32.Equals(RecordCount, 0))
                    {
                        EndUserModel ObjeU = new EndUserModel();
                        ObjeU.MobileNo = MobileNumber;
                        ObjeU.EMailId = EmailID;
                        ObjeU = _objIEndUserRegModel.GetOTPModel(ObjeU);
                        ViewBag.OTP = ObjeU.OTP;
                        ObjeU = null;

                        string OTP = ViewBag.OTP;

                        if (!string.IsNullOrEmpty(OTP))
                        {
                            string message = "Your One time code for Khanij Online application is : " + OTP + " CHiMMS, GoCG";
                            string templateid = "1307161883520738720";
                            sMSModel.Main(new SMS() { mobileNo = MobileNumber, message = message, templateid = templateid });
                            mailModel.SendMail_EUP(new TransporterMail() { EmailId = EmailID, MobileNo = OTP, Type = "OTP" });

                            return Json("SUCCESS");
                        }
                        else
                        {
                            return Json("FAILED");
                        }
                    }
                    else
                    {
                        return Json("Mobile Number Already Exist.Please Try another Mobile No");
                    }

                }
                catch (Exception)
                {
                    return Json("FAILED");

                }
            }
            else
            {
                return Json("No Mobile Number Entered");
            }
        }
        #endregion

        #region Verify OTP
        /// <summary>
        /// Verify OTP for Mobile No
        /// </summary>
        /// <param name="MobileNumber"></param>
        /// <param name="EmailID"></param>
        /// <param name="OTP"></param>
        /// <returns>String</returns>
        [SkipImportantTask]
        public string VerifyOTP(string MobileNumber, string EmailID, string OTP)
        {
            try
            {
                EndUserModel objER = null;
                objobjmodel = null;
                if (!string.IsNullOrEmpty(MobileNumber) && !string.IsNullOrEmpty(EmailID) && !string.IsNullOrEmpty(OTP))
                {
                    objER = new EndUserModel();
                    objER.MobileNo = MobileNumber;
                    objER.EMailId = EmailID;
                    objER.OTP = OTP;


                    objobjmodel = _objIEndUserRegModel.VerifyOTP(objER);
                    if (objobjmodel.Msg == "SUCCESS")
                    {
                        return "SUCCESS";
                    }
                    else
                    {
                        return "FAILED";
                    }
                }
                else
                {
                    return "REQUIRED";
                }
            }
            catch (Exception)
            {
                return "FAILED";
            }
        }
        #endregion

        /// <summary>
        /// Get all District List
        /// </summary>
        /// <param name="stateID"></param>
        /// <returns>Json Result</returns>
        [SkipImportantTask]
        public JsonResult GetDistrictList(int stateID)
        {
            EndUserModel objER = null;
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objER = new EndUserModel();
                objER.UserId = null; //profile.UserId; //1;
                objER.StateId = stateID;
                var x = _objIEndUserRegModel.GetDistrict(objER);
                var SList = x.ListOfState.ToList();
                return Json(SList);

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                throw;
            }
            finally
            {
                objER = null;
            }

        }

        /// <summary>
        /// Get district list for other
        /// </summary>
        /// <param name="stateID"></param>
        /// <returns>Json Result</returns>
        [SkipImportantTask]
        public JsonResult GetDistrictList_O(int stateID)
        {
            EndUserModel objER = null;
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objER = new EndUserModel();
                objER.UserId = null; //profile.UserId; //1;
                objER.StateId = stateID;

                var x = _objIEndUserRegModel.GetDistrict_O(objER);
                var SList = x.ListOfState.ToList();
                return Json(SList);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                throw;
            }
            finally
            {
                objER = null;
            }

        }

        /// <summary>
        /// Registration Check
        /// </summary>
        /// <returns>View</returns>
        [SkipImportantTask]
        public IActionResult RegistrationCheck()
        {
            return View();
        }

        /// <summary>
        /// Get Mineral List
        /// </summary>
        /// <param name="SearchTerm"></param>
        /// <returns>Json Result</returns>
        [SkipImportantTask]
        public JsonResult GetMineralList(string SearchTerm)
        {
            EndUserModel objER = null;
            try
            {
                objER = new EndUserModel();


                var MineralList = _objIEndUserRegModel.GetMineral(objER);
                if (MineralList.ListOfState != null)
                {
                    var SList = MineralList.ListOfState.ToList();
                    var modifiedData = SList.Select(x => new
                    {
                        id = x.MineralId,
                        text = x.MineralName
                    });
                    return Json(modifiedData);
                }
                else
                {
                    return Json("");
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                throw;
            }
            finally
            {
                objER = null;
            }

        }

        /// <summary>
        /// Get Mineral from list
        /// </summary>
        /// <param name="SearchTerm"></param>
        /// <param name="MinID"></param>
        /// <returns>Json Result</returns>
        [SkipImportantTask]
        public JsonResult GetMineralFormList(string SearchTerm, string MinID)
        {
            EndUserModel objER = null;
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objER = new EndUserModel();
                objER.UserId = null; //profile.UserId; //1;
                objER.MineralFormIdList = MinID;


                var MineralList = _objIEndUserRegModel.GetMineralForm(objER);
                if (MineralList.ListOfState != null)
                {
                    var SList = MineralList.ListOfState.ToList();
                    var modifiedData = SList.Select(x => new
                    {
                        id = x.MineralNatureId,
                        text = x.MineralNature
                    });
                    return Json(modifiedData);
                }
                else
                {
                    return Json("");
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                throw;
            }
            finally
            {
                objER = null;
            }

        }

        /// <summary>
        /// Get Grade List
        /// </summary>
        /// <param name="MineralNatureId"></param>
        /// <param name="MineralForm"></param>
        /// <param name="SearchTerm"></param>
        /// <returns>Json Rejult</returns>
        [SkipImportantTask]
        public JsonResult GetMineralGradeList(string MineralNatureId, string MineralForm, string SearchTerm)
        {
            EndUserModel objER = null;
            try
            {
                //UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objER = new EndUserModel();
                objER.UserId = null; //profile.UserId; //1;
                objER.MineralNatureId = MineralNatureId;
                objER.MineralFormIdList = MineralForm;


                var MineralList = _objIEndUserRegModel.GetMineralGrade(objER);
                if (MineralList.ListOfState != null)
                {
                    var SList = MineralList.ListOfState.ToList();
                    var modifiedData = SList.Select(x => new
                    {
                        id = x.MineralGradeId,
                        text = x.MineralGrade
                    });
                    return Json(modifiedData);
                }
                else
                {
                    return Json("");
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
                throw;
            }
            finally
            {
                objER = null;
            }

        }

        /// <summary>
        /// Get All Request
        /// </summary>
        /// <param name="model"></param>
        /// <returns>View</returns>
        public IActionResult AllRequest(EndUserModel model)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                model.UserId = profile.UserId; //1;
                ViewBag.AllReport = _objIEndUserRegModel.ViewAllReport(model);
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// Get End User Force data View
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>

        [SkipEncryptedTask]
        public IActionResult EndUserForceDataView(string id)
        {
            //EndUserModel BaseModel = new EndUserModel();
            //BaseModel.EndUserId =Convert.ToInt32(id);
            //EndUserBasicInfoModel Modelobj = new EndUserBasicInfoModel();
            EndUserBasicInfoModel Modelobj = _objIEndUserRegModel.GetallUserWiseData(new EndUserModel() { EndUserId = Convert.ToInt32(id) });
            return View(Modelobj);
        }

        /// <summary>
        /// Download files
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="foldername"></param>
        /// <returns>View</returns>
        public IActionResult DownloadFiles(string filename, string foldername)
        {
            string filepath = null;
            var absolutePath = filename;
            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "EndUserRegistration\\" + foldername + "");
            if (filename != null)
            {
                if (filepath == null)
                    filepath = Path.Combine(uploadsFolder, filename);
                if (filename.Contains("_"))
                {
                    string[] splitFileName = filename.Split('_');
                    filename = splitFileName[1];
                }
                if (System.IO.File.Exists(filepath))
                {
                    return File(new FileStream(filepath, FileMode.Open), "application/octetstream", filename);
                }
                return null;
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// Post portion of End User Force data view
        /// </summary>
        /// <param name="model"></param>
        /// <param name="approve"></param>
        /// <param name="reject"></param>
        /// <param name="MineralCount"></param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult EndUserForceDataView(EndUserBasicInfoModel model, string approve, string reject, List<int> MineralCount)
        {
            if (!string.IsNullOrEmpty(approve))
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                model.UserId = profile.UserId; //1;
                objobjmodel = _objIEndUserRegModel.ApproveEuser(model);
                int output = 0;
                output = int.Parse(objobjmodel.Msg);
                if (output >= 1)
                {
                    model.ProfileUserID = output;
                    model = _objIEndUserRegModel.GetallUserDataDetails(model);
                    TempData["UserCode"] = model.UserCode;
                    TempData["UserName"] = model.UserName;
                    TempData["Password"] = model.Password;
                    TempData["RegistrationNo"] = model.RegistrationNo;
                    if (model.UserName != null && model.Password != null)
                    {
                        if (model.UserName != "" && model.Password != "")
                        {
                            #region Send SMS
                            try
                            {
                                string message = "End User Registration" + Environment.NewLine + Environment.NewLine + "You have successfully registered with Khanij Online Portal. Your Registration Number is " + model.UserCode + " Dated " + System.DateTime.Now + Environment.NewLine + Environment.NewLine +
                                                    "You can login into Khanij Online Portal using below login credential" + Environment.NewLine + Environment.NewLine +
                                                     "User Name : " + model.UserName + Environment.NewLine + "Password : " + model.Password + Environment.NewLine + Environment.NewLine +
                                                     "Please check your e-mail for details of registration";

                                string templateid = "1307161883515998678";
                                sMSModel.Main(new SMS() { mobileNo = model.MobileNo, message = message, templateid = templateid });

                            }
                            catch (Exception)
                            {

                            }
                            #endregion


                        }
                    }

                    ViewBag.AcknowledgementMessage = "1";
                    TempData["AcknowledgementMessage"] = "1";
                }
                else
                {
                    ViewBag.AcknowledgementMessage = "0";
                    TempData["AcknowledgementMessage"] = "0";
                }
            }

            if (!string.IsNullOrEmpty(reject))
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                model.UserId = profile.UserId; //1;
                objobjmodel = _objIEndUserRegModel.RejectEuser(model);
                int output = 0;
                output = int.Parse(objobjmodel.Msg);
                if (output >= 1)
                {
                    model.ProfileUserID = output;
                    model = _objIEndUserRegModel.GetallUserDataDetails(model);
                    TempData["UserCode"] = model.UserCode;
                    TempData["UserName"] = model.UserName;
                    TempData["Password"] = model.Password;
                    TempData["RegistrationNo"] = model.RegistrationNo;
                    if (model.UserName != null && model.Password != null)
                    {
                        if (model.UserName != "" && model.Password != "")
                        {
                            #region Send SMS
                            try
                            {
                                string message = "";

                                if (string.Equals(model.NatureOfBusiness, "Industry") || string.Equals(model.NatureOfBusiness, "1"))
                                {
                                    if (model.StateId == 7)
                                    {
                                        message = "End User Registration, " + Environment.NewLine + Environment.NewLine + "Your End User registration in Khanij Online with Registration Number " + model.RegistrationNo + " has been rejected by District's Mining Office.";
                                    }
                                    else { message = "End User Registration, " + Environment.NewLine + Environment.NewLine + "Your End User registration in Khanij Online with Registration Number " + model.RegistrationNo + " has been rejected by Directorate of Geology and Mining, Chhattisgarh."; }
                                }
                                else
                                {
                                    message = "End User Registration, " + Environment.NewLine + Environment.NewLine + "Your End User registration in Khanij Online with Registration Number " + model.RegistrationNo + " has been rejected by Directorate of Geology and Mining, Chhattisgarh.";
                                }


                                string templateid = "1307161883515998678";
                                sMSModel.Main(new SMS() { mobileNo = model.MobileNo, message = message, templateid = templateid });

                            }
                            catch (Exception)
                            {

                            }
                            #endregion

                        }
                    }

                    ViewBag.AcknowledgementMessage = "2";
                    TempData["AcknowledgementMessage"] = "2";
                }
                else
                {
                    ViewBag.AcknowledgementMessage = "0";
                    TempData["AcknowledgementMessage"] = "0";
                }


            }
            TempData.Keep("AcknowledgementMessage");
            TempData.Keep("RegistrationNo");
            return View("EndUserForceDataView", model);
        }

        /// <summary>
        /// Get all updated Request
        /// </summary>
        /// <param name="model"></param>
        /// <returns>View</returns>
        public IActionResult AllUpdationRequest(EndUserModel model)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                model.UserId = profile.UserId; //1;
                ViewBag.AllReport = _objIEndUserRegModel.ViewUpdationReport(model);
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// Get all action taken request
        /// </summary>
        /// <param name="model"></param>
        /// <returns>View</returns>

        public IActionResult ActionTakenRequest(EndUserModel model)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                model.UserId = profile.UserId; //1;
                ViewBag.AllReport = _objIEndUserRegModel.AllActionTakenReport(model);
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// Get End User Particular Data View
        /// </summary>
        /// <param name="id"></param>
        /// <returns>View</returns>
        [SkipEncryptedTask]
        public IActionResult EndUserDataView(string id)
        {
            EndUserModel BaseModel = new EndUserModel();
            BaseModel.EndUserId =Convert.ToInt32(id);
            EndUserBasicInfoModel Modelobj = new EndUserBasicInfoModel();
            Modelobj = _objIEndUserRegModel.GetActionTakenUserWiseData(BaseModel);
            return View(Modelobj);
        }

        /// <summary>
        /// Check End User Application Status
        /// </summary>
        /// <param name="UserCode"></param>
        /// <param name="Captcha"></param>
        /// <returns>View</returns>
        [SkipImportantTask]
        public JsonResult CheckEndUserApplicationStatus(string UserCode, string Captcha)
        {

            var IsAvailable = 0;
            try
            {
                EndUserBasicInfoModel model = new EndUserBasicInfoModel();
                model.UserCode = UserCode;
                objobjmodel = _objIEndUserRegModel.ViewEndUserDetails(model);
                IsAvailable = int.Parse(objobjmodel.Msg);
                return Json(IsAvailable);
            }
            catch (Exception ex)
            {
                return Json(IsAvailable);
            }
        }

        /// <summary>
        /// Get End User Registration
        /// </summary>
        /// <param name="UserCode"></param>
        /// <param name="design"></param>
        /// <returns>View</returns>
        [SkipImportantTask]
        public ActionResult EUPRegistration(string UserCode, string design)
        {
            EndUserModel data = new EndUserModel();
            try
            {
                data.UserCode = UserCode;

                data = _objIEndUserRegModel.GetEuserStatus(data);
                if (!(data.Is_Approved is DBNull))
                {
                    if (data.Is_Approved > 0)
                    {
                        data.ApprovalStatus = (data.Is_Approved == 1) ? "APPROVED" : "REJECTED";
                    }
                    else { data.ApprovalStatus = "PENDING"; }
                }
            }
            catch (Exception)
            {
            }
            return View(data);
        }

        #region DSC Response Verify
        string Signature = string.Empty;

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


        #endregion

    }
}
