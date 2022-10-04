using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace userregistrationApp.Areas.EndUserRegistration.Controllers
{
    [Area("EndUserRegistration")]
    public class EndUserProfileRequestController : Controller
    {
        public IActionResult AllRequest()
        {
            return View();
        }
        public IActionResult UpdationRequest()
        {
            return View();
        }
        public IActionResult ActionTaken()
        {
            return View();
        }      
           public IActionResult EndUserForceDataView()
        {
            return View();
        }
        public IActionResult EndUserDataView()
        {
            return View();
        }
    }
}
