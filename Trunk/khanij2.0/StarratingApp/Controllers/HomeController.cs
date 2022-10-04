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
using StarratingApp.Web;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StarratingApp.Models;
using StarratingEF;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using StarratingApp.Model.ExceptionList;
using System.Collections.Generic;

namespace StarratingApp.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        /// <summary>
        /// Global object & variable declaration
        /// </summary>
        public readonly IOptions<KeyList> _objKeyList;
        private readonly IConfiguration _configuration;
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
            //var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //public JsonResult getmenu()
        //{
        //    try
        //    {
        //        string s = "";
        //        UserLoginSession objUserLoginSession = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
        //        foreach (MenuEF item in objUserLoginSession.Listmenu)
        //        {
        //            s += "<li class='";
        //            s += item.MenuId;
        //            s += "'>";
        //            s += "<a href = 'javascript:void(0);'>";
        //            s += "<i class='fa fa-columns'></i ><span class='title'>";
        //            s += item.MenuName + "</span><span class='arrow' ></span ></a >";
        //            s += "<ul class='sub-menu' >";

        //            foreach (childMenu items in item.childMenuList)
        //            {

        //                s += "<li>";
        //                s += "<a class='plUser' href='http://" + items.url + "" + _objKeyList.Value.DomenNAme + "/" + items.Area + "/" + items.Controller + "/" + items.ActionName + "'>";
        //                s += items.MenuName;
        //                s += "</a>";
        //                s += "</li>";
        //            }
        //            s += "</ul >";
        //            s += "</li > ";
        //        }
        //        return Json(s);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    //UserLoginSession objUserLoginSession = HttpContext.Session.Get<UserLoginSession>(HomeApp.Web.KeyHelper.UserKey );
        //}
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
