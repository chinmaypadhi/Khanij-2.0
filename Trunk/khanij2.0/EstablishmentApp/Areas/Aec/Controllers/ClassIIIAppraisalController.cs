using EstablishmentApp.Areas.Aec.Models.ClassIIIAppraisal;
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
    public class ClassIIIAppraisalController : Controller
    {
        IClassIIIAppraisalModel _IClassIIIAppraisalModel;
        public ClassIIIAppraisalController(IClassIIIAppraisalModel IClassIIIAppraisalModel)
        {
            _IClassIIIAppraisalModel = IClassIIIAppraisalModel;
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
            if (id != 0)
            {
                ClassIIIAppraisalEF objClassIIIAppraisalEF = new ClassIIIAppraisalEF();
                objClassIIIAppraisalEF.Satus = "E";
                objClassIIIAppraisalEF.AppraisalId = id;
                objClassIIIAppraisalEF= _IClassIIIAppraisalModel.GetDetails(objClassIIIAppraisalEF);
                ViewBag.Designation = Designation.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),
                    Selected=(c.value== objClassIIIAppraisalEF.Designation.ToString())

                }).ToList();
                ViewBag.Department = Department.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),
                    Selected = (c.value == objClassIIIAppraisalEF.Department.ToString())

                }).ToList();
                ViewBag.User = User.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.value.ToString(),
                    Selected = (c.value == objClassIIIAppraisalEF.Personname.ToString())

                }).ToList();
                ViewBag.Button = "Update";
                return View(objClassIIIAppraisalEF);

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
                return View();
            }

           
        }
        [HttpPost]
        public IActionResult AddAppraisal(ClassIIIAppraisalEF objClassIIIAppraisalEF,string Submit)
        {
            MessageEF objMessageEF = new MessageEF();
            if (Submit== "Submit")
            {
                objClassIIIAppraisalEF.Satus = "REM";
            }
            else
            {
                objClassIIIAppraisalEF.Satus = "UREM";
            }
            objClassIIIAppraisalEF.intCreatedBy = 1;
            objClassIIIAppraisalEF.intUpdatedBy = 1;
            objClassIIIAppraisalEF.dateCreatedOn = DateTime.Now;
            objClassIIIAppraisalEF.dateUpdatedOn = DateTime.Now;            
            objMessageEF =_IClassIIIAppraisalModel.AddPersonaldetails(objClassIIIAppraisalEF);
            if(objMessageEF.Satus=="1")
            {
                TempData["Masg"] = "Data added Sucessfully";
            }
            else if(objMessageEF.Satus == "2")
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
            ModelState.Clear();
            return View();
        }
        public IActionResult ViewAppraisal()
        {
            ClassIIIAppraisalEF objClassIIIAppraisalEF = new ClassIIIAppraisalEF();
            objClassIIIAppraisalEF.Satus = "V";
            List<ClassIIIAppraisalEF> objListClassIIIAppraisalEF = new List<ClassIIIAppraisalEF>();
            objListClassIIIAppraisalEF = _IClassIIIAppraisalModel.GetList(objClassIIIAppraisalEF);
            return View(objListClassIIIAppraisalEF);
        }

        public IActionResult ViewRevAuthority()
        {
            ClassIIIAppraisalEF objClassIIIAppraisalEF = new ClassIIIAppraisalEF();
            objClassIIIAppraisalEF.Satus = "V";
            List<ClassIIIAppraisalEF> objListClassIIIAppraisalEF = new List<ClassIIIAppraisalEF>();
            objListClassIIIAppraisalEF = _IClassIIIAppraisalModel.GetList(objClassIIIAppraisalEF);
            return View(objListClassIIIAppraisalEF);
        }
        public IActionResult ViewAccAuthority()
        {
            ClassIIIAppraisalEF objClassIIIAppraisalEF = new ClassIIIAppraisalEF();
            objClassIIIAppraisalEF.Satus = "V";
            List<ClassIIIAppraisalEF> objListClassIIIAppraisalEF = new List<ClassIIIAppraisalEF>();
            objListClassIIIAppraisalEF = _IClassIIIAppraisalModel.GetList(objClassIIIAppraisalEF);
            return View(objListClassIIIAppraisalEF);
        }
        public IActionResult updateRevAuth(int id=0)
        {
            ClassIIIAppraisalEF objClassIIIAppraisalEF = new ClassIIIAppraisalEF();
            objClassIIIAppraisalEF.AppraisalId = id;
            objClassIIIAppraisalEF.Satus = "E";
            objClassIIIAppraisalEF = _IClassIIIAppraisalModel.GetDetails(objClassIIIAppraisalEF);
            return View(objClassIIIAppraisalEF);
        }
        public IActionResult updateAccAuth(int id = 0)
        {
            ClassIIIAppraisalEF objClassIIIAppraisalEF = new ClassIIIAppraisalEF();
            objClassIIIAppraisalEF.AppraisalId = id;
            objClassIIIAppraisalEF.Satus = "E";
            objClassIIIAppraisalEF = _IClassIIIAppraisalModel.GetDetails(objClassIIIAppraisalEF);
            return View(objClassIIIAppraisalEF);
            
        }
        [HttpPost]
        public IActionResult updateRevAuth(ClassIIIAppraisalEF objClassIIIAppraisalEF)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {

           
            objClassIIIAppraisalEF.intCreatedBy = 1;
            objClassIIIAppraisalEF.intUpdatedBy = 1;
            objClassIIIAppraisalEF.dateCreatedOn = DateTime.Now;
            objClassIIIAppraisalEF.dateUpdatedOn = DateTime.Now;
            objClassIIIAppraisalEF.Reviewingdate = DateTime.Now;
                objClassIIIAppraisalEF.Acceptingdate = DateTime.Now;
                objClassIIIAppraisalEF.Reviewingby = 1;
                objClassIIIAppraisalEF.Satus = "REV";
                objMessageEF = _IClassIIIAppraisalModel.AddPersonaldetails(objClassIIIAppraisalEF);
                if (objMessageEF.Satus == "1")
                {
                    TempData["Masg"] = "Data added Sucessfully";
                    return RedirectToAction("ViewRevAuthority", "ClassIIIAppraisal");
                }
                else 
                {
                    TempData["Masg"] = "Data not updated Sucessfully";
                    return View();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost]
        public IActionResult updateAccAuth(ClassIIIAppraisalEF objClassIIIAppraisalEF)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {


                objClassIIIAppraisalEF.intCreatedBy = 1;
                objClassIIIAppraisalEF.intUpdatedBy = 1;
                objClassIIIAppraisalEF.dateCreatedOn = DateTime.Now;
                objClassIIIAppraisalEF.dateUpdatedOn = DateTime.Now;
                objClassIIIAppraisalEF.Reviewingdate = DateTime.Now;
                objClassIIIAppraisalEF.Acceptingdate = DateTime.Now;
                objClassIIIAppraisalEF.Acceptingby = 1;
                objClassIIIAppraisalEF.Satus = "ACC";
                objMessageEF = _IClassIIIAppraisalModel.AddPersonaldetails(objClassIIIAppraisalEF);
                if (objMessageEF.Satus == "1")
                {
                    TempData["Masg"] = "Data added Sucessfully";
                    return RedirectToAction("ViewAccAuthority", "ClassIIIAppraisal");
                }
                else
                {
                    TempData["Masg"] = "Data not updated Sucessfully";
                    return View();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
