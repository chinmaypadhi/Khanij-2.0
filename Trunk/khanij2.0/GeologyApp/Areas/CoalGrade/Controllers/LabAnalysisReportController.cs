using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GeologyApp.Areas.CoalGrade.Controllers
{
    [Area("CoalGrade")]
    public class LabAnalysisReportController : Controller
    {
        public IActionResult RHGNew()
        {
            return View();
        }

        public IActionResult SubordinateNew()
        {
            return View();
        }

        public IActionResult LabAnalysisReportNew()
        {
            return View();
        }

        public IActionResult DGMNew()
        {
            return View();
        }
    }
}
