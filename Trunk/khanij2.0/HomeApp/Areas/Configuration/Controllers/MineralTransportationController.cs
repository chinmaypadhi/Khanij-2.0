using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HomeApp.Areas.Configuration.Controllers
{
    [Area("Configuration")]
    public class MineralTransportationController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult ViewList()
        {
            return View();
        }
    }
}
