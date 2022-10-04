// ***********************************************************************
//  Controller Name          : HomeController
//  Desciption               : Logout,Get Menu details in Home controller
//  Created By               : Lingaraj Dalai
//  Created On               : 04 Feb 2022
// ***********************************************************************
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DashboardApp.Models;
using DashboardEF;
using Microsoft.AspNetCore.Authentication;
using DashboardApp.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using DashboardApp.Model.ExceptionList;

namespace DashboardApp.Controllers
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
        public IActionResult Index()
        {
            UserLoginSession objUserLoginSession = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            if (objUserLoginSession.UserTypeId == 8)//End User
            {
                return RedirectToAction("EndUserDashboard", "EndUser", new { Area = "Dashboard" });
            }
            else if (objUserLoginSession.UserTypeId == 9)//Vehicle Owner
            {
                return RedirectToAction("VehicleDashboard", "VehicleOwner", new { Area = "Dashboard" });
            }
            else if (objUserLoginSession.UserTypeId == 11)//Check post
            {
                return RedirectToAction("VehicleDashboard", "VehicleOwner", new { Area = "Dashboard" });//not done
            }
            else if (objUserLoginSession.UserTypeId == 7)//Lessee
            {
                return RedirectToAction("LesseeDashboard", "Lessee", new { Area = "Dashboard" });
            }
            else if (objUserLoginSession.UserTypeId == 10)//Licensee
            {
                return RedirectToAction("LicenseDashboard", "License", new { Area = "Dashboard" });
            }
            else if (objUserLoginSession.UserTypeId == 12)//supper Lessee
            {
                return RedirectToAction("LicenseDashboard", "License", new { Area = "Dashboard" });//not done
            }
            else if (objUserLoginSession.UserTypeId == 5)//DD User
            {
                return RedirectToAction("DDDashboard", "DD", new { Area = "Dashboard" });//not done
            }
            else if (objUserLoginSession.UserTypeId ==3)//DD User
            {
                return RedirectToAction("DGMDashboard", "DGM", new { Area = "Dashboard" });//not done
            }
            else
            {
                return RedirectToAction("AdminDashboard", "Admin", new { Area = "Dashboard" });
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
