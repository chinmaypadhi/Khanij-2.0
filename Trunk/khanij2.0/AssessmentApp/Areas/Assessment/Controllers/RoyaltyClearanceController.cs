using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentApp.Areas.Assessment.Controllers
{
    [Area("Assessment")]
    public class RoyaltyClearanceController : Controller
    {
        public IActionResult AddProject()
        {
            return View();
        }
        public IActionResult ReceivedMineral()
        {
            return View();
        }
        public IActionResult ApplyRoyalityClearance()
        {
            return View();
        }
        public IActionResult ViewProject()
        {
            return View();
        }

        public IActionResult DDViewProject()
        {
            return View();
        }

        public IActionResult DDMOViewProject()
        {
            return View();
        }

        public IActionResult DDMOApplyView()
        {
            return View();
        }

        public IActionResult DCView()
        {
            return View();
        }

        
    }
}
