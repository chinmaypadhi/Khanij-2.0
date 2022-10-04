using EstablishmentApp.Areas.Aec.Models.AppraisalClassIV;
using EstablishmentEf;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApp.Areas.Aec.Controllers
{
    [Area("Aec")]
    public class AppraisalClassIVController : Controller
    {
        IAppraisalClassIVModel _objAppraisalClassIV;
        public AppraisalClassIVController(IAppraisalClassIVModel objAppraisalClassIV)
        {
            _objAppraisalClassIV = objAppraisalClassIV;
        }
        public IActionResult AddAppraisal(int id = 0)
        {
            AppraisalClassIVEF objAppraisalClassIVEF = new AppraisalClassIVEF();
            if (id != 0)
            {
                objAppraisalClassIVEF.id = id;
                objAppraisalClassIVEF.Status = "E";
                objAppraisalClassIVEF = _objAppraisalClassIV.getdataedit(objAppraisalClassIVEF);
                ViewBag.Button = "Update";
                return View(objAppraisalClassIVEF);

            }
            ViewBag.Button = "Submit";
            return View();
        }
        [HttpPost]
        public IActionResult AddAppraisal(AppraisalClassIVEF objAppraisalClassIVEF, String Submit)
        {
            MessageEF objMessageEF = new MessageEF();
            objAppraisalClassIVEF.dateCreatedOn = DateTime.Now;
            objAppraisalClassIVEF.intCreatedBy = 1;
            objAppraisalClassIVEF.dateUpdatedOn = DateTime.Now;
            objAppraisalClassIVEF.intUpdatedBy = 1;

            if (Submit == "Update")
            {
                objAppraisalClassIVEF.Status = "U";
            }
            else
            {
                objAppraisalClassIVEF.Status = "A";
            }
            objMessageEF = _objAppraisalClassIV.AddAppraisal(objAppraisalClassIVEF);
            if (objMessageEF.Satus == "1")
            {
                TempData["Masg"] = "Data save Sucessfully";
                ModelState.Clear();
                return View("AddAppraisal");
            }
            else if (objMessageEF.Satus == "2")
            {
                TempData["Masg"] = "Data Update  Sucessfully";
                ModelState.Clear();
                return RedirectToAction("ViewAppraisal");
            }
            else
            {
                TempData["Masg"] = "Data not save Sucessfully";

                return View("AddAppraisal");
            }


        }
        public IActionResult ViewAppraisal()
        {
            List<AppraisalClassIVEF> ObjListAppraisalClassIVEF = new List<AppraisalClassIVEF>();
            try
            {
                AppraisalClassIVEF objAppraisalClassIVEF = new AppraisalClassIVEF();
                objAppraisalClassIVEF.Status = "V";
                ObjListAppraisalClassIVEF = _objAppraisalClassIV.getList(objAppraisalClassIVEF);
                return View(ObjListAppraisalClassIVEF);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return View();
        }
    }
}
