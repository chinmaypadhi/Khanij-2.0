using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeEF;
using HomeApp.Models.DashboardSub;
namespace HomeApp.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class DashboardSubController : Controller
    {
        IDashboardSubModel _IDashboardSubModel;
        List<MainMenuMaster> objMainmenuList = new List<MainMenuMaster>();
        MainMenuMaster objMainMenu = new MainMenuMaster();
        public DashboardSubController(IDashboardSubModel dashboardSubModel)
        {
            _IDashboardSubModel = dashboardSubModel;
        }
        public IActionResult DashboardSub()
        {
            ViewBag.MainmenuList = MainmenuList(objMainMenu);
            return View();
        }
        private List<MainMenuMaster> MainmenuList(MainMenuMaster mainMenuMaster)
        {
            objMainmenuList = _IDashboardSubModel.ViewMainMenu(mainMenuMaster);
            return objMainmenuList.ToList();
        }
    }
}
