using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GeologyApp.Areas.CoalGrade.Controllers
{
    [Area("CoalGrade")]
    public class AnnextureController : Controller
    {
        public IActionResult AnnextureD()
        {
            return View();
        }

        public IActionResult DAnnextureDownload()
        {
            return View();
        }

        public IActionResult BAnnextureDownload()
        {
            return View();
        }
    }
}
