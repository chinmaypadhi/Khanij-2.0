using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MineralConcessionApp.Controllers
{
    [Area("MinorMineralCL")]
    public class PrivateLandController : Controller
    {
        public IActionResult CLAdd()
        {
            return View();
        }
    }
}
