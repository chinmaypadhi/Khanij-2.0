// ***********************************************************************
//  Controller Name          : HomeController
//  Desciption               : Logout,Get Menu details in Home controller
//  Created By               : Lingaraj Dalai
//  Created On               : 28 Dec 2021
// ***********************************************************************
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PermitApp.Models;
using PermitEF;
using Microsoft.AspNetCore.Authentication;
using PermitApp.Helper;
using Microsoft.AspNetCore.Http;
using PermitApp.Web;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using PermitApp.Model.ExceptionList;
using System.Collections.Generic;

namespace PermitApp.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        public readonly IOptions<KeyList> _objKeyList;
        private readonly IConfiguration _configuration;
        private readonly IExceptionProvider exceptionProvider;
        public HomeController(IOptions<KeyList> objKeyList, IConfiguration configuration, IExceptionProvider exceptionProvider)
        {
            _objKeyList = objKeyList;
            _configuration = configuration;
            this.exceptionProvider = exceptionProvider;
            //_objIIdentity = objIIdentity;
        }
        public IActionResult Index(string MMenuId = "0")
        { 
            HttpContext.Session.SetInt32("MMenuId", Convert.ToInt32(MMenuId));
            HttpContext.Session.Set<List<MenuEF>>("Index", GetIndexMenuList());
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
         
        /// <summary>
        /// Bind Index menu list details in view
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
        public async Task<RedirectResult> Logout()
        {


            HttpContext.Response.Cookies.Delete(".AspNet.SharedCookie");
            //HttpContext.Response.Cookies.Delete("Identity.Application");
            await HttpContext.SignOutAsync("Identity.Application");
            HttpContext.Session.Clear();
            string LogoutPath = _configuration.GetSection("Logout").GetValue<string>("LogoutPath");
            return Redirect(LogoutPath);

            //HttpContext.Response.Cookies.Delete("Identity.Application");
            //await HttpContext.SignOutAsync("Identity.Application");
            //HttpContext.Session.Clear();
            //return Redirect("http://khanij.com/");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
