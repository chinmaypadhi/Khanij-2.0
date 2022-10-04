using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MineralConcessionApp.Controllers
{
    [Area("MinorMineralCL")]
    public class DDMOController : Controller
    {     
        public IActionResult CompositeViewList()
        {
            return View();
        }
        public IActionResult CompositeViewListAgreement()
        {
            return View();
        }
        public IActionResult CompositeViewListApprove()
        {
            return View();
        }
    }
}
