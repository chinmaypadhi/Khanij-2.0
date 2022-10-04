using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using MasterApp.Models;
using Microsoft.AspNetCore.Diagnostics;
using EstablishmentEf;
using EstablishmentApp.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using EstablishmentApp.Model.ExceptionList;
using Microsoft.AspNetCore.Http;
using EstablishmentApp.Models;

namespace EstablishmentApp.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Global object & variable declaration
        /// </summary>
        public readonly IOptions<KeyList> _objKeyList;
        private readonly IConfiguration _configuration;
        private readonly IExceptionProvider exceptionProvider;

        public HomeController(IOptions<KeyList> objKeyList, IConfiguration configuration, IExceptionProvider exceptionProvider)
        {
            _objKeyList = objKeyList;
            _configuration = configuration;
            this.exceptionProvider = exceptionProvider;
        }
        public IActionResult Index(int MMenuId = 0)
        {
            HttpContext.Session.SetInt32("MMenuId", MMenuId);
            ViewData["Index"] = GetIndexMenuList();
            return View();
        }

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
            //UserLoginSession objUserLoginSession = HttpContext.Session.Get<UserLoginSession>(HomeApp.Web.KeyHelper.UserKey );

        }

        private string GetMenuList()
        {
            List<MenuEF> Listmenu = new List<MenuEF>();
            UserLoginSession profile =HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            menuonput objmenu = new menuonput();
            objmenu.UserID = Convert.ToInt32(profile.UserId);//;
            objmenu.MineralId = Convert.ToInt32(profile.MineralId);
            objmenu.MineralName = profile.MineralName;
            objmenu.MMenuId = HttpContext.Session.GetInt32("MMenuId");//Convert.ToInt32(TempData["MMenuId"].ToString());
            Listmenu = exceptionProvider.MenuList(objmenu);
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
                    s += "<i class=" + items.GifIcon + "></i>";//---added on 15-feb-2022
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

            HttpContext.Response.Cookies.Delete(".AspNet.SharedCookie");
            //HttpContext.Response.Cookies.Delete("Identity.Application");
            await HttpContext.SignOutAsync("Identity.Application");
            HttpContext.Session.Clear();
            string LogoutPath = _configuration.GetSection("Logout").GetValue<string>("LogoutPath");
            return Redirect(LogoutPath);
        }
        //---added on 15-feb-2022
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

    }
}
