using EstablishmentApp.Areas.Aec.Models.AppraisalDriver;
using EstablishmentEf;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApp.Areas.Aec.Controllers
{

    [Area("Aec")]
    public class AppraisalDriverController : Controller
    {
        public IAppraisalDriverModel _ObjAppraisalDriverModel;
        public AppraisalDriverController(IAppraisalDriverModel objAppraisalDriverModel)
        {
            _ObjAppraisalDriverModel = objAppraisalDriverModel;
        }
        public IActionResult AddAppraisal(int id=0)
        {
            AppraisalDriverEF objAppraisalDriverEF = new AppraisalDriverEF();
            if (id!=0)
            {
                objAppraisalDriverEF.id = id;
                objAppraisalDriverEF.Action = "E";
                objAppraisalDriverEF = _ObjAppraisalDriverModel.getdataedit(objAppraisalDriverEF);
                ViewBag.Button = "Update";
                return View(objAppraisalDriverEF);
                
            }
            ViewBag.Button = "Submit";
            return View();
        }
        [HttpPost]
        public IActionResult AddAppraisal(AppraisalDriverEF objAppraisalDriverEF, String Submit)
        {
            MessageEF objMessageEF = new MessageEF();
            objAppraisalDriverEF.dateCreatedOn = DateTime.Now;
            objAppraisalDriverEF.intCreatedBy = 1;
            objAppraisalDriverEF.dateUpdatedOn  = DateTime.Now;
            objAppraisalDriverEF.intUpdatedBy  = 1;

            if (Submit== "Update")
            {
                objAppraisalDriverEF.Action = "U";
            }
            else
            {
                objAppraisalDriverEF.Action = "A";
            }
            objMessageEF=_ObjAppraisalDriverModel.AddAppraisal(objAppraisalDriverEF);
            if(objMessageEF.Satus =="1")
            {
                TempData["Masg"] = "Data save Sucessfully";
                ModelState.Clear();
                return View("AddAppraisal");
            }
            else if(objMessageEF.Satus == "2")
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
            List<AppraisalDriverEF> ObjListAppraisalDriverEF = new List<AppraisalDriverEF>();
            try
            {
                AppraisalDriverEF objAppraisalDriverEF = new AppraisalDriverEF();
                objAppraisalDriverEF.Action = "V";
                ObjListAppraisalDriverEF= _ObjAppraisalDriverModel.getList(objAppraisalDriverEF);
                return View(ObjListAppraisalDriverEF);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
            return View();
        }
    }
}
