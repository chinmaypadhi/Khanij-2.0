using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class EndUserController : Controller
    {
        public IActionResult EndUserDashboard()
        {
            return View();
        }
    }
}
