using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GeologyApp.Areas.CoalGrade.Controllers
{
    [Area("CoalGrade")]
    public class GrantQuarryPermitController : Controller
    {
        public IActionResult GrantQuarryPermit()
        {
            return View();
        }
    }
}
