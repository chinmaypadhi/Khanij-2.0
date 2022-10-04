using EstablishmentApp.Areas.Aec.Models.ClassIIIAppraisal;
using EstablishmentApp.Areas.Aec.Models.PastaffAppraisal;
using EstablishmentEf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApp.Areas.Aec.Controllers
{
    [Area("Aec")]
    public class PastaffController : Controller
    {
        IClassIIIAppraisalModel _IClassIIIAppraisalModel;
        IPAstaffApprasalModel _IPAstaffApprasalModel;
        public PastaffController(IClassIIIAppraisalModel IClassIIIAppraisalModel, IPAstaffApprasalModel IPAstaffApprasalModel)
        {
            _IClassIIIAppraisalModel = IClassIIIAppraisalModel;
            _IPAstaffApprasalModel = IPAstaffApprasalModel;
        }

        public IActionResult AddAppraisal(int id=0)
        {
            ViewBag.Designation = Enumerable.Empty<SelectListItem>();
            ViewBag.Department = Enumerable.Empty<SelectListItem>();
            ViewBag.User = Enumerable.Empty<SelectListItem>();
            EmpDropDown objEmpDropDown = new EmpDropDown();
            objEmpDropDown.Action = "Designation";
            var Designation = _IClassIIIAppraisalModel.Dropdown(objEmpDropDown);
            objEmpDropDown.Action = "Department";
            var Department = _IClassIIIAppraisalModel.Dropdown(objEmpDropDown);
            objEmpDropDown.Action = "PersonName";
            var User = _IClassIIIAppraisalModel.Dropdown(objEmpDropDown);
            objEmpDropDown.Action = "PersonName";
            var RepAutname = _IClassIIIAppraisalModel.Dropdown(objEmpDropDown);
            

            if (id != 0)
            {
                PastaffEF objobjPastaffEF = new PastaffEF();
                objobjPastaffEF.Action  = "Erepo";
                objobjPastaffEF.intApprisalld = id;
                objobjPastaffEF = _IPAstaffApprasalModel.ReportingAuthorityEdit(objobjPastaffEF);
                ViewBag.Designation = Designation.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),
                    Selected = (c.value == objobjPastaffEF.Designation.ToString())

                }).ToList();
                ViewBag.Department = Department.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),
                    Selected = (c.value == objobjPastaffEF.Department.ToString())

                }).ToList();
                ViewBag.User = User.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),
                    Selected = (c.value == objobjPastaffEF.Person_name.ToString())

                }).ToList();


                ViewBag.RepAutname = RepAutname.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),
                    Selected = (c.value == objobjPastaffEF.RepAutname.ToString())

                }).ToList();
                ViewBag.Button = "Update";



                return View(objobjPastaffEF);

            }
            else
            {
                ViewBag.Designation = Designation.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),


                }).ToList();
                ViewBag.Department = Department.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),


                }).ToList();
                ViewBag.User = User.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),


                }).ToList();
                ViewBag.RepAutname = RepAutname.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),


                }).ToList();



                ViewBag.Button = "Submit";
                return View();
            }
            return View();
        }
        [HttpPost]
        public IActionResult AddAppraisal(PastaffEF objPastaffEF, string Submit)
        {
            objPastaffEF.intCreatedBy = 1;
            objPastaffEF.dateCreatedOn = DateTime.Now;
            MessageEF objMessageEF = new MessageEF();
            if (Submit == "Submit")
            {

                objPastaffEF.Action = "Add";
            }
            else
            {
                objPastaffEF.Action = "Urepo";
            }
            objMessageEF=_IPAstaffApprasalModel.ReportingAuthority(objPastaffEF);
            if (objMessageEF.Satus == "1")
            {
                TempData["Masg"] = "Data added Sucessfully";
            }
            else if (objMessageEF.Satus == "2")
            {
                TempData["Masg"] = "Data Updated Sucessfully";
                return RedirectToAction("ViewAppraisal", "ClassIIIAppraisal");

            }
            else
            {
                TempData["Masg"] = "Data not Updated Sucessfully";

            }

            ViewBag.Designation = Enumerable.Empty<SelectListItem>();
            ViewBag.Department = Enumerable.Empty<SelectListItem>();
            ViewBag.User = Enumerable.Empty<SelectListItem>();
            EmpDropDown objEmpDropDown = new EmpDropDown();
            objEmpDropDown.Action = "Designation";
            var Designation = _IClassIIIAppraisalModel.Dropdown(objEmpDropDown);
            objEmpDropDown.Action = "Department";
            var Department = _IClassIIIAppraisalModel.Dropdown(objEmpDropDown);
            objEmpDropDown.Action = "PersonName";
            var User = _IClassIIIAppraisalModel.Dropdown(objEmpDropDown);
            objEmpDropDown.Action = "PersonName";
            var RepAutname = _IClassIIIAppraisalModel.Dropdown(objEmpDropDown);


            
                ViewBag.Designation = Designation.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),


                }).ToList();
                ViewBag.Department = Department.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),


                }).ToList();
                ViewBag.User = User.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),


                }).ToList();
                ViewBag.RepAutname = RepAutname.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),


                }).ToList();



                ViewBag.Button = "Submit";


                return View();
        }
        public IActionResult ViewAppraisal()
        {
            return View();
        }
    }
}
