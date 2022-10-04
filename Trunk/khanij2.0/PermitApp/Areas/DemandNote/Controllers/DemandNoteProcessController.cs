using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PermitApp.Areas.DemandNote.Controllers
{
    public class DemandNoteProcessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
