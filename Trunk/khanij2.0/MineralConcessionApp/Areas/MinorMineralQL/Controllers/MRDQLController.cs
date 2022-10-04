using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MineralConcessionApp.Controllers
{
    [Area("MinorMineralQL")]
    public class MRDQLController : Controller
    {     
        public IActionResult QuarryLeaseNew()
        {
            return View();
        }
        public IActionResult QuarryLeaseApproval()
        {
            return View();
        }
    }
}
