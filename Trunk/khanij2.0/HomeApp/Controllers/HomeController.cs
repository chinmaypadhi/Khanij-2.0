// ***********************************************************************
// Assembly         : Khanij
// Author           : Kumar jeevan jyoti
// Created          : 28-dec-2020
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HomeApp.Models;
using HomeEF;
using HomeApp.Models.Login;
using HomeApp.Web;
using System.Security.Claims;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using HomeApp.Models.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading;
using System.Security.Principal;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Security.Cryptography;
using HomeApp.Models.ForgotPasswordApp;
using HomeApp.Models.DashboardSub;
using HomeApp.ActionFilter;
using HomeApp.Models.ChangePassword;

namespace HomeApp.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        /// <summary>
        /// Global Declaration
        /// </summary>
        ILoginModel _objILoginModel;
        UserLoginSession objUserLoginSession;
        private readonly IConfiguration _configuration;
        public readonly IOptions<KeyList> _objKeyList;
        private readonly IForgotPwdModel _forgotPwdModel;
        private readonly IChangePasswordModel _objIChangePasswordModel;
        IDashboardSubModel _IDashboardSubModel;
        List<MainMenuMaster> objMainmenuList = new List<MainMenuMaster>();
        MainMenuMaster objMainMenu = new MainMenuMaster();
        MessageEF objobjmodel = new MessageEF();
        private string strLclSalt;
        private string strLclPwd1;
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        /// <param name="ObjILoginModel"></param>
        /// <param name="objKeyList"></param>
        /// <param name="configuration"></param>
        public HomeController(IDashboardSubModel dashboardSubModel, ILoginModel ObjILoginModel, IOptions<KeyList> objKeyList, IConfiguration configuration, IForgotPwdModel forgotPwdModel, IChangePasswordModel objIChangePasswordModel)
        {
            _objILoginModel = ObjILoginModel;
            _objKeyList = objKeyList;
            _configuration = configuration;
            _forgotPwdModel = forgotPwdModel;
            _IDashboardSubModel = dashboardSubModel;
            //_objIIdentity = objIIdentity;
            _objIChangePasswordModel = objIChangePasswordModel;

        }
        [SkipSessionTask]
        public IActionResult Wellcom()
        {
            return View();
        }
        [SkipSessionTask]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        [SkipSessionTask]
        public async Task<IActionResult> Index(LoginEF loginEF)
        {
            #region Validation
            if (string.IsNullOrEmpty(loginEF.UserName))
            {
                ModelState.AddModelError("UserName", "User Name is Required");
            }
            if (string.IsNullOrEmpty(loginEF.Password))
            {
                ModelState.AddModelError("Password", "Password is Required");
            }

            #endregion
            if (ModelState.IsValid)
            {
                objUserLoginSession = new UserLoginSession();
                objUserLoginSession = _objILoginModel.LoginUser(loginEF);
                string pwdString1 = "";

                if (objUserLoginSession != null)
                {

                    if (objUserLoginSession.UserId > 0)
                    {
                        string strLclPwd1 = objUserLoginSession.EncryptPassword;
                        string pwd2 = ComputeSha256Hash(strLclPwd1) + strLclSalt;
                        pwdString1 = ComputeSha256Hash(pwd2).ToUpper();
                        if (strLclPwd1 == (objUserLoginSession.EncryptPassword))
                        {
                            if (objUserLoginSession.IsPasswordChange == 1)
                            {

                                List<MenuEF> Listmenu = new List<MenuEF>();
                                menuonput objmenu = new menuonput();
                                objmenu.UserID = Convert.ToInt32(objUserLoginSession.UserId);
                                objmenu.MineralId = Convert.ToInt32(objUserLoginSession.MineralId);
                                objmenu.MineralName = objUserLoginSession.MineralName;
                                objmenu.MMenuId= null;
                                Listmenu = _objILoginModel.MenuList(objmenu);
                                objUserLoginSession.Listmenu = Listmenu;
                                HttpContext.Session.Set<UserLoginSession>(KeyHelper.UserKey, objUserLoginSession);

                                var claims = new List<Claim>
                                {
                                    new Claim(ClaimTypes.Email, objUserLoginSession.EmailID ),
                                    new Claim(ClaimTypes.Name, objUserLoginSession.ApplicantName == null ? objUserLoginSession.UserType : objUserLoginSession.ApplicantName),
                                    new Claim(ClaimTypes.GivenName, objUserLoginSession. UserType),
                                    new Claim(ClaimTypes.NameIdentifier, objUserLoginSession.UserId.ToString()),
                                    new Claim(ClaimTypes.Role , objUserLoginSession.RoleId.ToString()),
                                    new Claim(ClaimTypes.PrimarySid , objUserLoginSession.UserLoginId.ToString()),
                                    new Claim(ClaimTypes.UserData , objUserLoginSession.UserName.ToString())

                                };
                                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                                var authProperties = new AuthenticationProperties
                                {
                                    IsPersistent = false
                                };
                                await HttpContext.SignInAsync("Identity.Application", claimsPrincipal, authProperties);

                                string ss = User.Identity.Name;

                                if(objUserLoginSession.UserType== "License Application")
                                {
                                    return Redirect(_objKeyList.Value.LicenseApplicationUrl);
                                }
                                else
                                {
                                    return RedirectToAction("DashboardSub");
                                }
                            }
                            else
                            {
                                HttpContext.Session.SetInt32("UserId", Convert.ToInt32(objUserLoginSession.UserId));
                                HttpContext.Session.SetString("CurPassword", objUserLoginSession.Password);
                                return RedirectToAction("ChangePassword", "Home");
                            }
                        }                    
                    }
                    else
                    {
                        TempData["msg"] = "Invalid user name password";
                    }
                }
                else
                {
                    TempData["msg"] = "Invalid user name password";
                }

            }
            return View(loginEF);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<RedirectResult> Logout()
        {
            HttpContext.Response.Cookies.Delete("Identity.Application");
            await HttpContext.SignOutAsync("Identity.Application");
            HttpContext.Session.Clear();
            string LogoutPath = _configuration.GetSection("Logout").GetValue<string>("LogoutPath");
            return Redirect(LogoutPath);
            //return Redirect(_objKeyList.Value.LoginUrl);
        }
        #region biligual
        [HttpPost]
        [SkipSessionTask]
        public IActionResult CultureManagement(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });
            //return RedirectToAction(nameof(Index));
            return LocalRedirect(returnUrl);
        }
        #endregion
        public IActionResult DashboardSub()
        {
            ViewBag.MainmenuList = MainmenuList(objMainMenu);
            return View();
        }
        [SkipSessionTask]
        public IActionResult ForgotPassword()
        {          
            return View();
        }
        [HttpPost]
        [SkipSessionTask]
        public IActionResult ForgotPassword(ForgotPasswordModel forgotPasswordModel)
        {
            #region Validation

            #endregion
            if (ModelState.IsValid)
            {
                if (forgotPasswordModel.NewPassword== forgotPasswordModel.ConfirmPassword)
                {
                    forgotPasswordModel.EncryptPassword= ComputeSha256Hash(forgotPasswordModel.NewPassword);
                    objobjmodel = _forgotPwdModel.ResetPassword(forgotPasswordModel);
                }
                TempData["Message"] = objobjmodel.Satus;
            }
            return View();
        }
        [SkipSessionTask]
        public IActionResult ChangePassword()
        {
           
            return View();
        }
        [HttpPost]
        [SkipSessionTask]
        public IActionResult ChangePassword(ChangePasswordEF objChangePasswordEF)
        {
            #region Validation
            if (string.IsNullOrEmpty(objChangePasswordEF.OldPassword))
            {
                ModelState.AddModelError("OldPassword", "Old Password Field is required");
            }
            else if (string.IsNullOrEmpty(objChangePasswordEF.NewPassword))
            {
                ModelState.AddModelError("NewPassword", "New Password Field is required");
            }
            else if (string.IsNullOrEmpty(objChangePasswordEF.ConfirmPassword))
            {
                ModelState.AddModelError("ConfirmPassword", "Confirm Password Field is required");
            }
            #endregion
            if (ModelState.IsValid)
            {
                if (objChangePasswordEF.NewPassword == objChangePasswordEF.ConfirmPassword)
                {
                    objChangePasswordEF.UserId = HttpContext.Session.GetInt32("UserId");
                    string curpassword = HttpContext.Session.GetString("CurPassword");
                    objChangePasswordEF.EncryptPassword = ComputeSha256Hash(objChangePasswordEF.NewPassword);
                    if (curpassword != objChangePasswordEF.OldPassword)
                    {
                        TempData["Message"] = "2";
                    }
                    else
                    {
                        objobjmodel = _objIChangePasswordModel.ChangeUserPassword(objChangePasswordEF);
                        TempData["Message"] = objobjmodel.Satus;
                    }
                }               
            }
            
            return View(objChangePasswordEF);
        }
        [SkipSessionTask]
        public JsonResult GetMobileEmail(ForgotPasswordModel forgotPasswordModel)
        {
            ForgotPasswordModel objforgotPasswordModel = new ForgotPasswordModel();
            MessageEF messageEF= new MessageEF();
            try
            {
                objforgotPasswordModel = _forgotPwdModel.GetMobileEmail(forgotPasswordModel);
                if(forgotPasswordModel.MOBILENO !="")
                {
                    OTPModel oTPModel = new OTPModel();
                    oTPModel.UserName = forgotPasswordModel.UserName;
                    oTPModel.MobileNumber = objforgotPasswordModel.MOBILENO;
                    OTPModel objOtPModel = _forgotPwdModel.SendOTP(oTPModel);
                    if (!string.IsNullOrEmpty(objOtPModel.OTP))
                    {
                        //if(objOtPModel.status=="3")
                        //{
                        //    messageEF.Satus= "Please enter a valid Email Id.";
                        //    ViewBag.msg = "Please enter a valid Email Id.";
                        //}
                        //else if(objOtPModel.status=="1")
                        //{
                        //    ViewBag.msg = "You can not resend the OTP within 3 minute.";
                        //    messageEF.Satus = "You can not resend the OTP within 3 minute.";
                        //}
                        //else
                        //{
                        //}
                        SMS obj = new SMS();
                        string message = "Your One time code for Khanij Online application is : " + objOtPModel.OTP + ". CHiMMS, GoCG";
                        string templateid = "1307161883520738720";
                        obj.mobileNo = objforgotPasswordModel.MOBILENO;
                        obj.message = message;
                        obj.templateid = templateid;
                        messageEF = _forgotPwdModel.Main(obj);
                    }               
                }
                return Json(messageEF.Satus);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #region Captcha Code
        /// <summary>
        /// To Generate Captcha
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SkipSessionTask]
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
        #region password encript 
        public static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i <= bytes.Length - 1; i++)
                    builder.Append(bytes[i].ToString("x2"));

                return builder.ToString();
            }
        }
        //Added by sanjay kumar on 10-09-2021 for Invalid login
        [HttpGet]
        public JsonResult GenerateRandom()
        {
            Random random = new Random();
            string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder CSRFRandNum = new StringBuilder();
            for (int i = 0; i < 13; i++)
                CSRFRandNum.Append(combination[random.Next(combination.Length)]);
            TempData["UNIQUERANDOM"] = CSRFRandNum.ToString();
            string randNo = CSRFRandNum.ToString();
            return Json(randNo);
        }
        //End
        #endregion
        private List<MainMenuMaster> MainmenuList(MainMenuMaster mainMenuMaster)
        {
            objMainmenuList = _IDashboardSubModel.ViewMainMenu(mainMenuMaster);
            return objMainmenuList.ToList();
        }
        [SkipSessionTask]
        public IActionResult Profile()
        {
            return View();
        }
    }
}
