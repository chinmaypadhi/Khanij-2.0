using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeologyApp.Areas.CoalGrade.Controllers
{
    [Area("CoalGrade")]
    public class MineralSampleController : Controller
    {
        public IActionResult MineralSample()
        {
            return View();
        }       
    }
}
