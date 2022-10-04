using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.WorkFlowEngine.Controllers
{
    [Area("WorkFlowEngine")]
    public class WorkFlowEngineeController : Controller
    {
        public IActionResult ModuleMaster()
        {
            return View();
        }

        public IActionResult SubModuleMaster()
        {
            return View();
        }

        public IActionResult ActivityMaster()
        {
            return View();
        }

        public IActionResult WorkFlow()
        {
            return View();
        }
    }
}
