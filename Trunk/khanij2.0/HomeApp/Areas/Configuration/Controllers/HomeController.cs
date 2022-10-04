using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HomeApp.Areas.Configuration.Controllers
{
    [Area("Configuration")]
    public class HomeController : Controller
    {
        public IActionResult Configuration()
        {
            return View();
        }
        public IActionResult ViewList()
        {
            return View();
        }
        public IActionResult StatusUpdate()
        {
            return View();
        }
        public IActionResult StatusView()
        {
            return View();
        }
        public IActionResult Transitpass()
        {
            return View();
        }
        public IActionResult TransitpassView()
        {
            return View();
        }
        public IActionResult PyamentView()
        {
            return View();
        }
        public IActionResult Payment()
        {
            return View();
        }
    }
}
