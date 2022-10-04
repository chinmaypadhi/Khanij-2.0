using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Controllers
{
    [Area("Website")]
    public class SetPermissionController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }
    }
}
