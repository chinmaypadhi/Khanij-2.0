// ***********************************************************************
//  Controller Name          : HomeController
//  Desciption               : Logout,Get Menu details in Home controller
//  Created By               : sanjay kumar
//  Created On               : 28 Dec 2021
// ***********************************************************************
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IntegrationApp.Models;
using IntegrationEF;
using Microsoft.AspNetCore.Authentication;
using IntegrationApp.Helper;
using Microsoft.AspNetCore.Http;
using IntegrationApp.Web;
using Microsoft.Extensions.Options;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace IntegrationApp.Controllers
{
   // [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        public readonly IOptions<KeyList> _objKeyList;
        public HomeController(IOptions<KeyList> objKeyList)
        {
            _objKeyList = objKeyList;
            //_objIIdentity = objIIdentity;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public JsonResult getmenu()
        {
            try
            {

                string s = "";
                UserLoginSession objUserLoginSession = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);

                foreach (MenuEF item in objUserLoginSession.Listmenu)
                {
                    s += "<li class='";
                    s += item.MenuId;
                    s += "'>";
                    s += "<a href = 'javascript:void(0);'>";
                    s += "<i class='fa fa-columns'></i ><span class='title'>";
                    s += item.MenuName + "</span><span class='arrow' ></span ></a >";
                    s += "<ul class='sub-menu' >";

                    foreach (childMenu items in item.childMenuList)
                    {

                        s += "<li>";
                        s += "<a class='plUser' href='http://" + items.url + "" + _objKeyList.Value.DomenNAme + "/" + items.Area + "/" + items.Controller + "/" + items.ActionName + "'>";
                        s += items.MenuName;
                        s += "</a>";
                        s += "</li>";
                    }
                    s += "</ul >";
                    s += "</li > ";
                }



                return Json(s);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<RedirectResult> Logout()
        {
            HttpContext.Response.Cookies.Delete("Identity.Application");
            await HttpContext.SignOutAsync("Identity.Application");
            HttpContext.Session.Clear();
            return Redirect(_objKeyList.Value.LoginUrl);
        }

       
    }
   
}
