using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MineralConcessionApp.Controllers
{
    [Area("MinorMineralQL")]
    public class PrivateLandQLController : Controller
    {
        public IActionResult QLAdd()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewList()
        {
            return View();
        }
    }
}
