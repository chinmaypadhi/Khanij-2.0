// ***********************************************************************
//  Controller Name          : HomeController
//  Desciption               : Logout,Get Menu details in Home controller
//  Created By               : Lingaraj Dalai
//  Created On               : 23 Jan 2022
// ***********************************************************************
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuarryPlanApprovalApp.Models;
using QuarryPlanApprovalEF;
using Microsoft.AspNetCore.Authentication;
using QuarryPlanApprovalApp.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using QuarryPlanApprovalApp.Model.ExceptionList;

namespace QuarryPlanApprovalApp.Controllers
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
        /// Bind Menu list details in view
        /// </summary>
        /// <returns></returns>
        public JsonResult getcmsmenu()
        {
            try
            {
                string s = GetMenuList();
                return Json(s);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private string GetMenuList()
        {
            List<MenuEF> Listmenu = new List<MenuEF>();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            menuonput objmenu = new menuonput();
            objmenu.UserID = Convert.ToInt32(profile.UserId);
            objmenu.MineralId = Convert.ToInt32(profile.MineralId);
            objmenu.MineralName = profile.MineralName;
            objmenu.MMenuId = HttpContext.Session.GetInt32("MMenuId");
            Listmenu = _objIExceptionProvider.MenuList(objmenu);
            profile.Listmenu = Listmenu;
            string s = "";
            foreach (MenuEF item in profile.Listmenu)
            {
                s += "<li class='nav-item dropdown '>";
                s += "<a class='nav-link dropdown-toggle' id='navbarDropdownMenuLink' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>";
                if (item.GifIcon == "" || item.GifIcon == null)
                {
                    s += "<i class='icon-chess-solid'></i>";
                }
                else
                {
                    s += item.GifIcon;
                }
                s += "<span>" + item.MenuName + "</span></a>";
                s += "<div class='dropdown-menu ' aria-labelledby='navbarDropdownMenuLink'>";
                foreach (childMenu items in item.childMenuList)
                {
                    s += "<a class='dropdown-item' href='http://" + items.url + "" + _objKeyList.Value.DomenNAme + "/" + items.Area + "/" + items.Controller + "/" + items.ActionName + "'>";
                    s += "<i class='icon-long-arrow-alt-right-solid'></i>";
                    s += items.MenuName;
                    s += "</a>";
                }
                s += "</div>";
                s += "</li> ";
            }

            return s;
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
