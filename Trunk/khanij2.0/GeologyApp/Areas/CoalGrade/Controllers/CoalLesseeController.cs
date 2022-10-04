using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GeologyApp.Areas.CoalGrade.Controllers
{
    [Area("CoalGrade")]
    public class CoalLesseeController : Controller
    {
        public IActionResult AddCoalLessee()
        {
            return View();
        }
        public IActionResult ViewCoalLessee()
        {
            return View();
        }
    }
}
