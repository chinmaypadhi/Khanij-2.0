using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApp.Areas.Epass.Controllers
{
    [Area("EPass")]
    public class ePassOutsideStateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OutsideStateMineral()
        {
            return View();
        }
        public IActionResult OutsideStateMineralView()
        {
            return View();
        }
    }
}
