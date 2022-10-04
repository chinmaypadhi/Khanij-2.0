using HomeApp.Models.Login;
using HomeApp.Web;
using HomeEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class CMSController : Controller
    {
        ILoginModel _objILoginModel;
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        /// <param name="ObjILoginModel"></param>
        public CMSController(ILoginModel ObjILoginModel)
        {
            _objILoginModel = ObjILoginModel;
        }
        public IActionResult CMSDashboard(int MMenuId = 0)
        {
            HttpContext.Session.SetInt32("MMenuId", MMenuId);
            HttpContext.Session.Set<List<MenuEF>>("CMSDashboard", GetIndexMenuList());
            ViewBag.MMenuId = MMenuId;
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
                Listmenu = _objILoginModel.MenuList(objmenu);
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
