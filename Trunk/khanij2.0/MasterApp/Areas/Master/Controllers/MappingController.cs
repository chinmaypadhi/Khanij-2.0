using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MasterApp.Areas.Master.Controllers
{
    public class MappingController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult ViewLIst()
        {
            return View();
        }
    }
}