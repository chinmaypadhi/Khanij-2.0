using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentApp.Areas.Assessment.Controllers
{
    [Area("Assessment")]
    public class AssessmentReportController : Controller
    {
        public IActionResult AsstReptLessee()
        {
            return View();
        }
        public IActionResult AssessmentReportView()
        {
            return View();
        }
        public IActionResult AssessmentReportMI()
        {
            return View();
        }
        public IActionResult AssessmentReportDDMO()
        {
            return View();
        }
    }
}
