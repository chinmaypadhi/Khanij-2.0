using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GeologyApp.Areas.Geology.Controllers
{
    [Area("Geology")]
    public class CommercialLabAnalysisReportController : Controller
    {
        public IActionResult Payment()
        {
            return View();
        }
        public IActionResult TakeAction()
        {
            return View();
        }
    }
}
