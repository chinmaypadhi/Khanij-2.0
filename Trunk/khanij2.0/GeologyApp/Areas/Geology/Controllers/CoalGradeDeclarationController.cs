using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GeologyApp.Areas.Geology.Controllers
{
    [Area("Geology")]
    public class CoalGradeDeclarationController : Controller
    {
        public IActionResult GrantQuarryPermit()
        {
            return View();
        }
        public IActionResult RegionalHead()
        {
            return View();
        }
        public IActionResult OICGeology()
        {
            return View();
        }
        public IActionResult GrantQuarryPermitView()
        {
            return View();
        }
    }
}
