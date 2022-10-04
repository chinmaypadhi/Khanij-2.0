using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarryPlanApprovalApp.Areas.QuarryPlan.Controllers
{
    [Area("QuarryPlan")]
    public class QuarryPlanApprovalController : Controller
    {
        public IActionResult QuarryPlanApprovalLessee()
        {
            return View();
        }

        public IActionResult QuarryPlanApprovalLesseeView()
        {
            return View();
        }

        public IActionResult QuarryPlanApprovalDDMO()
        {
            return View();
        }

        public IActionResult QuarryPlanApprovalMI()
        {
            return View();
        }

        public IActionResult QuarryPlanApprovalDGM()
        {
            return View();
        }

        public IActionResult QuarryPlanDownload()
        {
            return View();
        }

        public IActionResult QuarryPlanCertificate()
        {
            return View();
        }
    }
}
