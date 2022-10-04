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
using MasterApp.Models;
using Microsoft.AspNetCore.Diagnostics;
using MasterEF;
using MasterApp.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using MasterApp.Model.ExceptionList;
using Microsoft.AspNetCore.Http;
using MasterApp.ActionFilter;

namespace MasterApp.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Global object & variable declaration
        /// </summary>
        public readonly IOptions<KeyList> _objKeyList;
        private readonly IConfiguration _configuration;
        private readonly IExceptionProvider exceptionProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objKeyList"></param>
        /// <param name="configuration"></param>
        public HomeController(IOptions<KeyList> objKeyList, IConfiguration configuration, IExceptionProvider exceptionProvider)
        {
            _objKeyList = objKeyList;
            _configuration = configuration;
            this.exceptionProvider = exceptionProvider;
        }
        /// <summary>
        /// Index view
        /// </summary>
        /// <returns></returns>
        //[Decryption]
        public IActionResult Index(string MMenuId = "0")
        {
            HttpContext.Session.SetInt32("MMenuId", Convert.ToInt32(MMenuId));
            ViewBag.MMenuId = MMenuId;
            UserLoginSession objUserLoginSession = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            HttpContext.Session.Set<List<MenuEF>>("Index", GetIndexMenuList());
            if (objUserLoginSession.UserTypeId == 7 && Convert.ToInt32(MMenuId)==10)//Lessee
            {
                return RedirectToAction("Dashboard", "Profile", new { Area = "LesseeProfile" });
            }
            if (objUserLoginSession.UserTypeId == 10 && Convert.ToInt32(MMenuId) == 11)//Licensee
            {
                return RedirectToAction("Index", "Profile", new { Area = "Licensee" });
            }
            //else if (objUserLoginSession.UserTypeId == 5)//District Office
            //{
            //    return View();
            //}
            else
            {
                return View();
            }
        }
        /// <summary>
        /// Privacy view
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }
        /// <summary>
        /// Error view
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        /// <summary>
        /// Bind Menu list details in leftsider
        /// </summary>
        /// <returns></returns>
        public List<MenuEF> GetIndexMenuList()
        {
            List<MenuEF> Listmenu = new List<MenuEF>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            menuonput objmenu = new menuonput();
            try
            {
                objmenu.UserID = Convert.ToInt32(profile.UserId);
                objmenu.MineralId = Convert.ToInt32(profile.MineralId);
                objmenu.MineralName = profile.MineralName;
                objmenu.MMenuId = HttpContext.Session.GetInt32("MMenuId");
                Listmenu = exceptionProvider.MenuList(objmenu);
                return Listmenu;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Listmenu = null;
                objmenu = null;
            }
        }
        /// <summary>
        /// Logout from view
        /// </summary>
        /// <returns></returns>
        public async Task<RedirectResult> Logout()
        {

            HttpContext.Response.Cookies.Delete(".AspNet.SharedCookie");
            //HttpContext.Response.Cookies.Delete("Identity.Application");
            await HttpContext.SignOutAsync("Identity.Application");
            HttpContext.Session.Clear();
            string LogoutPath = _configuration.GetSection("Logout").GetValue<string>("LogoutPath");
            return Redirect(LogoutPath);
        }
    }
}
