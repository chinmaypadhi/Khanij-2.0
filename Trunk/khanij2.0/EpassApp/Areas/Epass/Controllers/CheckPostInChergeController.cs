using EpassApp.Areas.Epass.Models.CheckPostInCharge;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpassEF;
using Microsoft.AspNetCore.Mvc.Rendering;
using EpassApp.Web;

namespace EpassApp.Areas.Epass.Controllers
{
    [Area("EPass")]
    public class CheckPostInChergeController : Controller
    {
      
        private IcheckPostInChargeModel _objicheckPostInCharge;
        CheckPostIrrgModel checkPostIrrgModel = new CheckPostIrrgModel();
        List<CheckPostIrrgModel> lstcheckPostIrrgModel = new List<CheckPostIrrgModel>();
        public CheckPostInChergeController(IcheckPostInChargeModel objicheckPostInCharge)
        {
            _objicheckPostInCharge = objicheckPostInCharge;
        }
        public IActionResult CaseOfIrregularity(CheckPostIrrgModel obj)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                obj.UserId = (int)profile.UserId;
               
                ViewBag.List = Enumerable.Empty<SelectListItem>();
                var Data = _objicheckPostInCharge.ExcessMineralForCheckPost(obj);

                return View();
            }
            catch(Exception ex) 
            { 
                throw ex;
            }           
        }
    }
}
