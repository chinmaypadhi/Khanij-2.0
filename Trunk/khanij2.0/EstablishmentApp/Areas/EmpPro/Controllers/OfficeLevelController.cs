using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstablishmentApp.Areas.EmpPro.Models;
using EstablishmentEf;
using Microsoft.AspNetCore.Mvc;

namespace EstablishmentApp.Areas.EmpPro.Controllers
{
    [Area("EmpPro")]
    public class OfficeLevelController : Controller
    {
        private readonly IofficeLevelModul objIofficeLevelModul;
        public OfficeLevelController(IofficeLevelModul objIofficeLevelModul)
        {
            this.objIofficeLevelModul = objIofficeLevelModul;
        }

        public IActionResult Add(int id=0)
        {
            if (id != 0)
            {
                officeLevelEF objofficeLevelEF = new officeLevelEF();
                objofficeLevelEF.IntOfficeTypeId = id;
                objofficeLevelEF = objIofficeLevelModul.EditOfficeLevel(objofficeLevelEF);
                ViewBag.Button = "Update";
                return View(objofficeLevelEF);
            }
            else
            {
                ViewBag.Button = "Submit";
                return View();
            }
        }
        [HttpPost]
        public IActionResult Add(officeLevelEF objofficeLevelEF,string Submit)
        {

            try
            {
                MessageEF objMessageEF = new MessageEF();
                if (Submit == "Update")
                {
                    objofficeLevelEF.Status = "U";
                    objofficeLevelEF.intCreatedBy = 1;
                    objofficeLevelEF.dateCreatedOn = DateTime.Now;
                    objMessageEF = objIofficeLevelModul.AddUpdateDelete(objofficeLevelEF);
                    
                }
                else
                {
                    objofficeLevelEF.Status = "A";
                    objofficeLevelEF.intCreatedBy = 1;
                    objofficeLevelEF.dateCreatedOn = DateTime.Now;
                    objMessageEF = objIofficeLevelModul.AddUpdateDelete(objofficeLevelEF);
                }
                if(objMessageEF.Satus=="1")
                {
                    TempData["msg"] = "1";//---save
                    return RedirectToAction("Add");
                }
                if (objMessageEF.Satus == "2")
                {
                    TempData["msg"] = "2";//---update
                }
                else
                {
                    TempData["msg"] = "Data not Submit SucessFully";
                }
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
           

            return View();
        }

        public IActionResult ViewList()
        {
            try
            {
                officeLevelEF objofficeLevelEF = new officeLevelEF();
                objofficeLevelEF.Status = "V";
                List<officeLevelEF> ListofficeLevelEF = new List<officeLevelEF>();
                ListofficeLevelEF = objIofficeLevelModul.GetOfficeLevel(objofficeLevelEF);
                return View(ListofficeLevelEF);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
        public IActionResult Delete(int id = 0)
        {
            try
            {            
                MessageEF objMessageEF = new MessageEF();
                officeLevelEF objofficeLevelEF = new officeLevelEF();
                objofficeLevelEF.Status = "D";
                objofficeLevelEF.intCreatedBy = 1;
                objofficeLevelEF.dateCreatedOn = DateTime.Now;
                objofficeLevelEF.IntOfficeTypeId = id;
                objMessageEF = objIofficeLevelModul.AddUpdateDelete(objofficeLevelEF);
                if(objMessageEF.Satus =="3")
                {
                    TempData["msg"] = "3";//deleted
                }
                else
                {
                    TempData["msg"] = "Data Not Deleted sucessfully";
                }

                return RedirectToAction("ViewList", "OfficeLevel");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}