using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeRequestApp.Areas.ChangeRequest.Controllers
{
    [Area("ChangeRequest")]
    public class RequestController : Controller
    {
        
        public IActionResult InitChangeRequest()
        {
            return View();
        }
        public IActionResult SubmitTimeline()
        {
            return View();
        }
        public IActionResult UATFeedback()
        {
            return View();
        }
        public IActionResult SRSApproval()
        {
            return View();
        }
        public IActionResult TimeLineStatus()
        {
            return View();
        }
        public IActionResult UpdateDevelopmentStatus()
        {
            return View();
        }
        public IActionResult ViewInitialChangeRequest()
        {
            return View();
        }
        public IActionResult RequestDateCRLive()
        {
            return View();
        }
    }
}
