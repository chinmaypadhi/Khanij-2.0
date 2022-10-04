using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstablishmentApp.Areas.EmpPro.Models.Section;
using EstablishmentEf;
using Microsoft.AspNetCore.Mvc;


using Microsoft.AspNetCore.Mvc.Rendering;

namespace EstablishmentApp.Areas.EmpPro.Controllers
{
    [Area("EmpPro")]
    public class SectionController : Controller
    {
        private readonly ISectionModel objIofficeLevelModul;

        private readonly KhanijSecurity.KhanijIDataProtection protector;


        public SectionController(ISectionModel objIofficeLevelModul, KhanijSecurity.KhanijIDataProtection khanijIDataProtection)
        {
            this.objIofficeLevelModul = objIofficeLevelModul;
            protector = khanijIDataProtection;
        }

        public IActionResult Add(int id = 0)
        {
            if (id != 0)
            {
                SectionEF objSectionEF = new SectionEF();
                objSectionEF.IntSectionId  = id;
                objSectionEF = objIofficeLevelModul.EditOfficeLevel(objSectionEF);
                ViewBag.Button = "Update";
                return View(objSectionEF);
            }
            else
            {
                ViewBag.Button = "Submit";
                return View();
            }
        }
        [HttpPost]
        public IActionResult Add(SectionEF objSectionEF, string Submit)
        {

            try
            {
                MessageEF objMessageEF = new MessageEF();
                if (Submit == "Update")
                {
                    objSectionEF.Status = "U";
                    
                    objSectionEF.intCreatedBy = 1;
                    objSectionEF.dateCreatedOn = DateTime.Now;
                    objMessageEF = objIofficeLevelModul.AddUpdateDelete(objSectionEF);

                }
                else
                {
                    objSectionEF.Status = "A";
                    objSectionEF.intCreatedBy = 1;
                    objSectionEF.dateCreatedOn = DateTime.Now;
                    objMessageEF = objIofficeLevelModul.AddUpdateDelete(objSectionEF);
                }
                if (objMessageEF.Satus == "1")
                {
                    ViewBag.Masg = "Data Submitd SucessFully";
                    return RedirectToAction("ViewList", "Section");
                }
                if (objMessageEF.Satus == "2")
                {
                    ViewBag.Masg = "Data Updated SucessFully";
                    return RedirectToAction("ViewList", "Section");
                }
                else
                {
                    ViewBag.Masg = "Data not Submit SucessFully";
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
                SectionEF objSectionEF = new SectionEF();
                objSectionEF.Status = "V";
                List<SectionEF> ListSectionEF = new List<SectionEF>();
                ListSectionEF = objIofficeLevelModul.GetOfficeLevel(objSectionEF);
                return View(ListSectionEF);
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
                SectionEF objofficeLevelEF = new SectionEF();
                objofficeLevelEF.Status = "D";
                objofficeLevelEF.intCreatedBy = 1;
                objofficeLevelEF.dateCreatedOn = DateTime.Now;
                objofficeLevelEF.IntSectionId = id;
                objMessageEF = objIofficeLevelModul.AddUpdateDelete(objofficeLevelEF);
                if (objMessageEF.Satus == "3")
                {
                    ViewBag.Masg = "Data Deleted sucessfully";
                }
                else
                {
                    ViewBag.Masg = "Data Not Deleted sucessfully";
                }

                return RedirectToAction("ViewList", "Section");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #region Section

        public async Task<IActionResult> AddSectionOfficerTagging(string id = "0")
        {
            SectionOfficerTaggingEF objmodel = new SectionOfficerTaggingEF();
            try
            {
                SectionDropDown objLeaveDropDown = new SectionDropDown();
                ViewBag.Section = Enumerable.Empty<SelectListItem>();
                ViewBag.SectionOfficer = Enumerable.Empty<SelectListItem>();
                ViewBag.SectionOfficer2 = Enumerable.Empty<SelectListItem>();
                //---Bind Employee class

                objLeaveDropDown.Check = 1;
                var varSection = await objIofficeLevelModul.BindSection(objLeaveDropDown);
                ViewBag.Section = varSection.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                ////---Bind section officer
                objLeaveDropDown.Check = 2;
                var varSectionOfficer = await objIofficeLevelModul.BindSectionOfficer(objLeaveDropDown);

                ViewBag.SectionOfficer = varSectionOfficer.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                ////---Bind section officer
                objLeaveDropDown.Check = 3;
                var varSectionOfficer2 = await objIofficeLevelModul.BindSectionOfficer2(objLeaveDropDown);

                ViewBag.SectionOfficer2 = varSectionOfficer2.ToList().Select(c => new SelectListItem
                {
                    Text = c.Text,
                    Value = c.Value.ToString(),

                }).ToList();

                if (id != "0")
                {
                    int iId = Convert.ToInt32(protector.Encode(id));
                    objmodel.Check = 4;
                    objmodel.IntId = iId;
                    objmodel = await objIofficeLevelModul.ViewSectionOfficerTaggingDetails(objmodel);
                    ViewBag.Button = "Update";
                    return View(objmodel);
                }
                else
                {
                    ViewBag.Button = "Submit";
                    return View(objmodel);
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult AddSectionOfficerTagging(SectionOfficerTaggingEF objSectionEF, string Submit)
        {

            try
            {
                MessageEF objMessageEF = new MessageEF();
                if (Submit == "Update")
                {
                    objSectionEF.Check = 2;
                    objSectionEF.intCreatedBy = 1;
                    objMessageEF = objIofficeLevelModul.AddSectionOfficerTagging(objSectionEF);

                }
                else
                {
                    objSectionEF.Check = 1;
                    objSectionEF.intCreatedBy = 1;
                    objMessageEF = objIofficeLevelModul.AddSectionOfficerTagging(objSectionEF);
                }
                if (objMessageEF.Satus == "1")//saved
                {
                    TempData["msg"]= "1";
                    return RedirectToAction("AddSectionOfficerTagging");
                }
                if (objMessageEF.Satus == "2")//allready exists
                {
                    TempData["msg"]= "2";
                    return RedirectToAction("AddSectionOfficerTagging");
                }
                if (objMessageEF.Satus == "3")//updated
                {
                    TempData["msg"] = "3";
                    return RedirectToAction("ViewSectionOfficerTagging");
                }
                else
                {
                    TempData["msg"] = "Something went please try after some time";
                    return RedirectToAction("AddSectionOfficerTagging");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IActionResult> ViewSectionOfficerTagging()
        {

            List<SectionOfficerTaggingQueryEF> listAuthoritySetting = new List<SectionOfficerTaggingQueryEF>();
            SectionOfficerTaggingQueryEF objSection = new SectionOfficerTaggingQueryEF();
            try
            {
                objSection.Check = 4;
                listAuthoritySetting = await objIofficeLevelModul.ViewSectionOfficerTagging(objSection);
                return View(listAuthoritySetting);

            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// add/update section officer tagging
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [IgnoreAntiforgeryToken]
        public IActionResult DeleteSectionOfficerTagging(string id = "0")
        {
            MessageEF objMessageEF = new MessageEF();
            SectionOfficerTaggingEF objmodel = new SectionOfficerTaggingEF();
            try
            {
                int iId = Convert.ToInt32(protector.Encode(id));
                objmodel.Check = 3;
                objmodel.IntId = iId;
                objmodel.intCreatedBy = 1;
                objMessageEF = objIofficeLevelModul.DeleteSectionOfficerTagging(objmodel);
                if (objMessageEF.Satus == "4")//---deleted
                {
                    TempData["msg"] = "4";
                }
                else
                {
                    TempData["msg"] = "Error ! while deleting section officer Details";
                }
                return RedirectToAction("ViewSectionOfficerTagging");
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
    }
}