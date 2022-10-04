using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Controllers
{
    [Area("Website")]
    public class IntroductionController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult ViewList()
        {
            return View();
        }
    }
}
