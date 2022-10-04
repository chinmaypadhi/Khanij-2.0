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
using GeologyApp.Models;
using GeologyEF;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using GeologyApp.Web;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using GeologyApp.Model.ExceptionList;

namespace GeologyApp.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        /// <summary>
        /// Global object & variable declaration
        /// </summary>
        private readonly IConfiguration _configuration;
        public readonly IOptions<KeyList> _objKeyList;
        private readonly IExceptionProvider _objIExceptionProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objKeyList"></param>
        /// <param name="configuration"></param>
        public HomeController(IOptions<KeyList> objKeyList, IConfiguration configuration, IExceptionProvider objIExceptionProvider)
        {
            _objKeyList = objKeyList;
            _configuration = configuration;
            _objIExceptionProvider = objIExceptionProvider;
        }
        /// <summary>
        /// Index view
        /// </summary>
        /// <returns></returns>
        public IActionResult Index(int MMenuId = 0)
        {
            HttpContext.Session.SetInt32("MMenuId", MMenuId);
            HttpContext.Session.Set<List<MenuEF>>("Index",GetIndexMenuList());
            ViewBag.MMenuId = MMenuId;
            return View();
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
                Listmenu = _objIExceptionProvider.MenuList(objmenu);
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
            HttpContext.Response.Cookies.Delete("Identity.Application");
            await HttpContext.SignOutAsync("Identity.Application");
            HttpContext.Session.Clear();
            string LogoutPath = _configuration.GetSection("Logout").GetValue<string>("LogoutPath");
            return Redirect(LogoutPath);
        }
    }
}
