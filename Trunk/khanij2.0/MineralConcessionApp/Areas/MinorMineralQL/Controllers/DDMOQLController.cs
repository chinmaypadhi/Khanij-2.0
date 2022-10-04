using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MineralConcessionApp.Controllers
{
    [Area("MinorMineralQL")]
    public class DDMOQLController : Controller
    {
        public IActionResult QuarryLeaseNew()
        {
            return View();
        }
        public IActionResult QuarryLeaseLOI()
        {
            return View();
        }
        public IActionResult QuarryLeaseGrant()
        {
            return View();
        }
        public IActionResult QuarryLeaseFinal()
        {
            return View();
        }
    }
}
