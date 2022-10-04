using EstablishmentApp.Areas.Aec.Models.ClassIIIAppraisal;
using EstablishmentApp.Areas.Aec.Models.SelfAppraisal;
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
    public class SelfAppraisalController : Controller
    {
        ISelfAppraisalModel _Self;
        IClassIIIAppraisalModel _IClassIIIAppraisalModel;
        public SelfAppraisalController(ISelfAppraisalModel Self, IClassIIIAppraisalModel IIClassIIIAppraisalModel)
        {
            _Self = Self;
            _IClassIIIAppraisalModel = IIClassIIIAppraisalModel;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddSelfAppraisal(int id=0)
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
            SalfeAprasialEf objSalfeAprasialEf = new SalfeAprasialEf();
            if (id!=0)
            {
                objSalfeAprasialEf.intID = id;
                objSalfeAprasialEf = _Self.GetAprasialDetails(objSalfeAprasialEf);
                ViewBag.Designation = Designation.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),
                    Selected = (c.value == objSalfeAprasialEf.intDesignation.ToString())

                }).ToList();
                ViewBag.Department = Department.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),
                    Selected = (c.value == objSalfeAprasialEf.intDepartment .ToString())

                }).ToList();
                ViewBag.User = User.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),
                    Selected = (c.value == objSalfeAprasialEf.intPersonname.ToString())

                }).ToList();
                ViewBag.Button = "Update";
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
                ViewBag.Button = "Submit";
            }





            return View(objSalfeAprasialEf);
        }
        [HttpPost]
        public IActionResult AddSelfAppraisal(SalfeAprasialEf objSalfeAprasialEf, string Submit)
        {
            MessageEF objMessageEF = new MessageEF();
            if (Submit == "Submit")
            {
                objSalfeAprasialEf.action  = "A";
            }
            else
            {
                objSalfeAprasialEf.action = "U";
            }
            objSalfeAprasialEf.dateCreatedOn = DateTime.Now;
            objSalfeAprasialEf.dateUpdatedOn = DateTime.Now;
            objSalfeAprasialEf.intUpdatedBy = 1;
            objSalfeAprasialEf.intCreatedBy = 1;
            objMessageEF= _Self.AddSalfeAprasial(objSalfeAprasialEf);
            if (objMessageEF.Satus == "1")
            {
                TempData["Masg"] = "Data Submitd SucessFully";
                return RedirectToAction("ViewSelfAppraisal", "SelfAppraisal");
            }
            if (objMessageEF.Satus == "2")
            {
                TempData["Masg"] = "Data Updated SucessFully";
                return RedirectToAction("ViewSelfAppraisal", "SelfAppraisal");
            }
            else
            {
                TempData["Masg"] = "Data not Submit SucessFully";
            }
            ModelState.Clear();
            return View();
        }

        
        public IActionResult ViewSelfAppraisal()
        {
            SalfeAprasialEf objSalfeAprasialEf = new SalfeAprasialEf();
            List<SalfeAprasialEf> ListSalfeAprasialEf = new List<SalfeAprasialEf>();
            ListSalfeAprasialEf = _Self.GetListData(objSalfeAprasialEf);
            return View(ListSalfeAprasialEf);
        }
        public IActionResult AddReportingAuthority(int id=0)
        {
            SalfeAprasialEf objSalfeAprasialEf = new SalfeAprasialEf();
            try
            {
                objSalfeAprasialEf.intID = id;
                objSalfeAprasialEf = _Self.GetAprasialDetails(objSalfeAprasialEf);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(objSalfeAprasialEf);
        }
        [HttpPost]
        public IActionResult AddReportingAuthority(SalfeAprasialEf objSalfeAprasialEf)
        {
            MessageEF objMessageEF = new MessageEF();
           
                objSalfeAprasialEf.action = "UU";
            
            objSalfeAprasialEf.dateCreatedOn = DateTime.Now;
            objSalfeAprasialEf.dateUpdatedOn = DateTime.Now;
            objSalfeAprasialEf.intUpdatedBy = 1;
            objSalfeAprasialEf.intCreatedBy = 1;
          
            objMessageEF = _Self.AddSalfeAprasial(objSalfeAprasialEf);
            if (objMessageEF.Satus == "1")
            {
                TempData["Masg"] = "Data Submitd SucessFully";
                return RedirectToAction("ViewReportingAuthority", "SelfAppraisal");
            }
            if (objMessageEF.Satus == "2")
            {
                TempData["Masg"] = "Data Updated SucessFully";
                return RedirectToAction("ViewReportingAuthority", "SelfAppraisal");
            }
            else
            {
                TempData["Masg"] = "Data not Submit SucessFully";
            }
            ModelState.Clear();
            return View();
        }


            public IActionResult ViewReportingAuthority()
        {
            SalfeAprasialEf objSalfeAprasialEf = new SalfeAprasialEf();
            List<SalfeAprasialEf> ListSalfeAprasialEf = new List<SalfeAprasialEf>();
            ListSalfeAprasialEf = _Self.GetListData(objSalfeAprasialEf);
            return View(ListSalfeAprasialEf);
        }
        public IActionResult RevAutView()
        {
            SalfeAprasialEf objSalfeAprasialEf = new SalfeAprasialEf();
            List<SalfeAprasialEf> ListSalfeAprasialEf = new List<SalfeAprasialEf>();
            ListSalfeAprasialEf = _Self.GetListData(objSalfeAprasialEf);            
            return View(ListSalfeAprasialEf);
        }
        public IActionResult RevAutAction(int id)
        {
            SalfeAprasialEf objSalfeAprasialEf = new SalfeAprasialEf();
            try
            {           
                objSalfeAprasialEf.intID = id;
                objSalfeAprasialEf = _Self.GetAprasialDetails(objSalfeAprasialEf);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return View(objSalfeAprasialEf);
        }
        [HttpPost]
        public IActionResult RevAutAction(SalfeAprasialEf objSalfeAprasialEf)
        {
            MessageEF objMessageEF = new MessageEF();

            try
            {           
                objSalfeAprasialEf.action = "R";
                objSalfeAprasialEf.intReviewingBy = 1;
                objSalfeAprasialEf.dateCreatedOn  = DateTime.Now;
                objSalfeAprasialEf.dateUpdatedOn = DateTime.Now;
                objSalfeAprasialEf.intUpdatedBy = 1;
                objSalfeAprasialEf.intCreatedBy = 1;

                objMessageEF = _Self.RevAuthoReviewUpdate(objSalfeAprasialEf);
            
                if (objMessageEF.Satus == "1")
                {
                    TempData["Masg"] = "Data Submitd SucessFully";
                    return RedirectToAction("RevAutView", "SelfAppraisal");
                }
                if (objMessageEF.Satus == "2")
                {
                    TempData["Masg"] = "Data Updated SucessFully";
                    return RedirectToAction("RevAutView", "SelfAppraisal");
                }
                else
                {
                    TempData["Masg"] = "Data not Submit SucessFully";
                }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            return View();

        }

        public IActionResult AccAutView()
        {
            SalfeAprasialEf objSalfeAprasialEf = new SalfeAprasialEf();
            List<SalfeAprasialEf> ListSalfeAprasialEf = new List<SalfeAprasialEf>();
            ListSalfeAprasialEf = _Self.GetListData(objSalfeAprasialEf);
            return View(ListSalfeAprasialEf);
        }

        public IActionResult AccAutAction(int id)
        {
            SalfeAprasialEf objSalfeAprasialEf = new SalfeAprasialEf();
            try
            {
                objSalfeAprasialEf.intID = id;
                objSalfeAprasialEf = _Self.GetAprasialDetails(objSalfeAprasialEf);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return View(objSalfeAprasialEf);
        }
        [HttpPost]
        public IActionResult AccAutAction(SalfeAprasialEf objSalfeAprasialEf)
        {
            MessageEF objMessageEF = new MessageEF();

            try
            {
                objSalfeAprasialEf.action = "A";
                objSalfeAprasialEf.VchReviewingGrade = objSalfeAprasialEf.VchAcceptingGrade;
                objSalfeAprasialEf.intReviewingBy = 1;
                objMessageEF = _Self.RevAuthoReviewUpdate(objSalfeAprasialEf);

                if (objMessageEF.Satus == "1")
                {
                    TempData["Masg"] = "Data Submitd SucessFully";
                    return RedirectToAction("AccAutView", "SelfAppraisal");
                }
                if (objMessageEF.Satus == "2")
                {
                    TempData["Masg"] = "Data Updated SucessFully";
                    return RedirectToAction("AccAutView", "SelfAppraisal");
                }
                else
                {
                    TempData["Masg"] = "Data not Submit SucessFully";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View();

        }

    }

}
