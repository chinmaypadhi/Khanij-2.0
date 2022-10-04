using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DashboardApp.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class LicenseController : Controller
    {
        public IActionResult LicenseDashboard()
        {
            return View();
        }
    }
}
