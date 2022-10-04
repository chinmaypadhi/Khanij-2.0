// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.Models.MIneral;
using MasterApp.Areas.Master.Models.Priority;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using MasterApp.ActionFilter;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class PriorityController : Controller
    {
        IPriorityModel _objPrioritymasterModel;
        MessageEF objobjmodel = new MessageEF();
        public PriorityController(IPriorityModel objPrioritymasterModel)
        {
            _objPrioritymasterModel = objPrioritymasterModel;
        }
        [Decryption]
        public IActionResult Add(string id = "0" )
        {
            Prioritymaster objmodel = new Prioritymaster();
            if (!string.IsNullOrEmpty(id) &&  id != "0")
            {
                objmodel.PriorityID = Convert.ToInt32(id);
                objmodel = _objPrioritymasterModel.Edit(objmodel);
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
        public IActionResult Add(Prioritymaster objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.CreatedBy =  (int)profile.UserId;
            objmodel.UserLoginID = (int)profile.UserLoginId;
            if (string.IsNullOrEmpty(objmodel.PriorityName))
            {
                ModelState.AddModelError("PriorityName", "Priority Name is required");
            }
            else if (!string.IsNullOrEmpty(objmodel.PriorityName) && (objmodel.PriorityName.Length > 50))
            {
                ModelState.AddModelError("PriorityName", "Priority Name Name must be less than 50 characters");
            }
            if (ModelState.IsValid)
            {
                if (submit == "Submit")
                {
                    objobjmodel = _objPrioritymasterModel.Add(objmodel);
                }
                else
                {
                    objobjmodel = _objPrioritymasterModel.Update(objmodel);
                }
                if (objobjmodel.Satus == "1" && submit == "Submit")
                {
                    //ViewBag.msg = "Data Saved Sucessfully";
                    // return View();
                    //return RedirectToAction("ViewList");
                    objmodel.IsActive = true;
                    TempData["msg"] = "Data Saved Sucessfully";
                    ModelState.Clear();
                    return RedirectToAction("Viewlist", "Priority", new { Area = "master" });
                }
                if (objobjmodel.Satus == "1")
                {
                    TempData["msg"] = "Data Updated Sucessfully";
                    return RedirectToAction("Viewlist", "Priority", new { Area = "master" });

                }
                if (objobjmodel.Satus == "3")
                {
                    ViewBag.msg = "Priority Name Already Exist!";
                    ViewBag.Button = objmodel.PriorityID > 0 ? "Update" : "Submit";
                    return View(objmodel);
                }
                else
                {
                    ViewBag.msg = "Data not Saved Sucessfully";
                    ViewBag.Button = objmodel.PriorityID > 0 ? "Update" : "Submit";
                    return View(objmodel);
                }
            }
            else
            {
                ViewBag.Button = objmodel.PriorityID > 0 ? "Update" : "Submit";
                return View();
            }
        }
        public IActionResult ViewList(Prioritymaster objmodel)
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                ViewBag.ViewList = _objPrioritymasterModel.View(objmodel);
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        public IActionResult ViewList(Prioritymaster objmodel, string Show1)
        {
            try
            {
                ViewBag.ViewList = _objPrioritymasterModel.View(objmodel);
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
            Prioritymaster objmodel = new Prioritymaster();
            objmodel.CreatedBy = (int)profile.UserId;
            objmodel.UserLoginID = (int)profile.UserLoginId;
            objmodel.PriorityID = Convert.ToInt32(id);
            objobjmodel = _objPrioritymasterModel.Delete(objmodel);
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