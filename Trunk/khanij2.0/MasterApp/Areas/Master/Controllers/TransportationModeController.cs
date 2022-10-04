using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.TransportationMode;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;


namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class TransportationModeController : Controller
    {
        ITransportationModeModel _objTRModel;
        MessageEF objobjmodel = new MessageEF();
        public TransportationModeController(ITransportationModeModel objTRModel)
        {
            _objTRModel = objTRModel;
        }
        [Decryption]
        public IActionResult Add(string id = "0")
        {
            TransportationModeMaster objmodel = new TransportationModeMaster();
            if (!string.IsNullOrEmpty(id) && id != "0")
            {
            
                objmodel.TransportationModeId =Convert.ToInt32(id);
                objmodel = _objTRModel.Edit(objmodel);
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
        public IActionResult Add(TransportationModeMaster objmodel, string submit)
        {
            if (string.IsNullOrEmpty(objmodel.TransportationModeName))
            {
                ModelState.AddModelError("Transportation Mode", "Transportation Mode is required");
            }

            if (ModelState.IsValid)
            {

                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.CreatedBy = (int)profile.UserId;
                objmodel.UserLoginId = profile.UserLoginId;
                if (submit == "Submit")
                {
                    objobjmodel = _objTRModel.Add(objmodel);
                }
                else
                {
                    objobjmodel = _objTRModel.Update(objmodel);
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
                    TempData["msg"] = "Duplicate Data found.";
                    return View(objmodel);
                }
                else
                {
                    TempData["msg"] = "Data not Save Sucessfully";
                    return View(objmodel);
                }
            }
            return View();

        }
        public IActionResult ViewList(TransportationModeMaster objmodel)
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                ViewBag.ViewList = _objTRModel.View(objmodel);
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [Decryption]
        public IActionResult Delete(string id = "0")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            TransportationModeMaster objmodel = new TransportationModeMaster();
            objmodel.CreatedBy = (int) profile.UserId;
            objmodel.UserLoginId =  profile.UserLoginId;
            objmodel.TransportationModeId =Convert.ToInt32(id);
            objobjmodel = _objTRModel.Delete(objmodel);

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