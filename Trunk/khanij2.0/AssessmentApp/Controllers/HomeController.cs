using AssessmentApp.Model.ExceptionList;
using AssessmentApp.Web;
using AssessmentEF;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentApp.Controllers
{
    [Route("[controller]/[action]")]
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
        public IActionResult Index(int MMenuId = 0)
        {
            HttpContext.Session.SetInt32("MMenuId", MMenuId);
            return View();
        }

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
            ///UserLoginSession profile = new UserLoginSession();
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            menuonput objmenu = new menuonput();
            objmenu.UserID = Convert.ToInt32(profile.UserId);//29576;
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
                    s += "<a class='dropdown-item' href='http://" + items.url + "" + _objKeyList.Value.DomenNAme + _objKeyList.Value.Port + items.Area + "/" + items.Controller + "/" + items.ActionName + "'>";
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
