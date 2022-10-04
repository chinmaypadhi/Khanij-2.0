using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MineralConcessionApp.Controllers
{
    [Area("MinorMineralQL")]
    public class OtherMineralController : Controller
    {
        public IActionResult QLEAuction()
        {
            return View();
        }
        public IActionResult QLNonAuction()
        {
            return View();
        }
    }
}
