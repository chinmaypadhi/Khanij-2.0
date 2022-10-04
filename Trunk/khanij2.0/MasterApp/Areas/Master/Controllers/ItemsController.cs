using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MasterApp.Areas.Master.Controllers
{
    public class ItemsController : Controller
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