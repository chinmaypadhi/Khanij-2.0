using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MasterApp.Areas.Master.Controllers
{
    public class MineralDataController : Controller
    {
        public IActionResult add()
        {
            return View();
        }
        public IActionResult ViewList()
        {
            return View();
        }
    }
}