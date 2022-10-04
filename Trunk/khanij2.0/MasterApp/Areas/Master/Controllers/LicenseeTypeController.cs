using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.LicenseeType;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;


namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class LicenseeTypeController : Controller
    {
        ILicenseeTypeModel _objLicenseeTypeModel;
        MessageEF objobjmodel = new MessageEF();
        public LicenseeTypeController(ILicenseeTypeModel objLicenseeType)
        {
            _objLicenseeTypeModel = objLicenseeType;
        }

        [Decryption]
        public IActionResult Add(string id ="0")
        {
            LicenseeTypeMaster objmodel = new LicenseeTypeMaster();
            if (!string.IsNullOrEmpty(id) &&  id != "0")
            {
               
                objmodel.LicenseeTypeId = Convert.ToInt32(id);
                objmodel = _objLicenseeTypeModel.Edit(objmodel);
                ViewBag.Button = "Update";
                return View(objmodel);
            }
            else
            {
                objmodel.IsActive = true;
                ViewBag.Button = "Submit";
                return View(objmodel);
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(LicenseeTypeMaster objmodel, string submit)
        {

            if (string.IsNullOrEmpty(objmodel.LicenseeTypeName))
            {
                ModelState.AddModelError("Licensee Type Name", "Licensee Type Name  is required");
            }

            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.CreatedBy =  (int)profile.UserId;
            objmodel.UserLoginId = (int)profile.UserLoginId;
            if (submit == "Submit")
            {
                objobjmodel = _objLicenseeTypeModel.Add(objmodel);
            }
            else
            {
                objobjmodel = _objLicenseeTypeModel.Update(objmodel);
            }
            if (objobjmodel.Satus == "1" && submit == "Submit")
            {
                TempData["msg"] = "Data Saved Sucessfully";
                return RedirectToAction("ViewList");
            }
            if (objobjmodel.Satus == "1")
            {
                TempData["msg"] = "Data Updated Sucessfully";
                return RedirectToAction("ViewList");
            }
            else if (objobjmodel.Satus == "2")
            {
                TempData["msg"] = "Licensee Type Name Already Exists !!";
                return View("Add");
            }
            else
            {
                TempData["msg"] = "Data not Saved Sucessfully";
                return View(objmodel);
            }

        }
        public IActionResult ViewList(LicenseeTypeMaster objmodel)
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                ViewBag.ViewList = _objLicenseeTypeModel.View(objmodel);
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [Decryption]
        public IActionResult Delete(string id = "0" )
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            LicenseeTypeMaster objmodel = new LicenseeTypeMaster();
            objmodel.CreatedBy = (int)profile.UserId;
            objmodel.UserLoginId =(int)profile.UserLoginId;
            objmodel.LicenseeTypeId = Convert.ToInt32(id);
            objobjmodel = _objLicenseeTypeModel.Delete(objmodel);

            if (objobjmodel.Satus == "1")
            {
                TempData["msg"] = "Data Deleted Sucessfully";
                return RedirectToAction("ViewList");
            }
            else
            {
                TempData["msg"] = "Data not Deleted Sucessfully";
                return RedirectToAction("ViewList");
            }


        }
    }
}