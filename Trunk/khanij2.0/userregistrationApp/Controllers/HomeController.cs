using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using userregistrationApp.ActionFilter;
using userregistrationApp.Model.ExceptionList;
using userregistrationApp.Models;
using userregistrationApp.Models.WebsiteMenu;
using userregistrationApp.Web;
using userregistrationEF;

namespace userregistrationApp.Controllers
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
        public IActionResult Index(int MMenuId = 0)
        {
            HttpContext.Session.SetInt32("MMenuId", MMenuId); 
            HttpContext.Session.Set<List<MenuEF>>("Index", GetIndexMenuList());
            return View();
        }

        /// <summary>
        /// Privacy view
        /// </summary>
        /// <returns></returns>
        [SkipImportantTask]
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
                if (objmenu.MMenuId != 0 && objmenu.MMenuId != null)
                {
                    Listmenu = exceptionProvider.MenuList(objmenu);
                }
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

        #region biligual
        [SkipImportantTask]
        [HttpPost]
        public IActionResult CultureManagement(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });
            //return RedirectToAction(nameof(Index));
            return LocalRedirect(returnUrl);
        }
        #endregion

        #region Captcha Code
        /// <summary>
        /// To Generate Captcha
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SkipImportantTask]
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
    }
}
