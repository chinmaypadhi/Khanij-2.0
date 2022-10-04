// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 18-Jan-2021
// ***********************************************************************
using System;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.MineralUnit;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class MineralUnitController : Controller
    {
        IMineralUnitModel _objMineralUnitmasterModel;
        MessageEF objobjmodel = new MessageEF();
        public MineralUnitController(IMineralUnitModel objMineralUnitmasterModel)
        {
            _objMineralUnitmasterModel = objMineralUnitmasterModel;
        }
        [Decryption]
        public IActionResult Add(string id = "0")
        {
            MineralUnitmaster objmodel = new MineralUnitmaster();
            if (!string.IsNullOrEmpty(id) && id != "0")
            {

                objmodel.MineralUnitID = Convert.ToInt32(id);
                objmodel = _objMineralUnitmasterModel.Edit(objmodel);
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
        public IActionResult Add(MineralUnitmaster objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.CreatedBy = (int)profile.UserId;
                                   
            if (string.IsNullOrEmpty(objmodel.MineralUnitName))
            {
                ModelState.AddModelError("Name", "Mineral Unit Name is required");
            }
            else if (!string.IsNullOrEmpty(objmodel.MineralUnitName) && (objmodel.MineralUnitName.Length > 50))
            {
                ModelState.AddModelError("Name", "Mineral Unit Name must be less than 50 characters");
            }
            if (ModelState.IsValid)
            {
                if (submit == "Submit")
                {
                    objobjmodel = _objMineralUnitmasterModel.Add(objmodel);
                }
                else
                {
                    objobjmodel = _objMineralUnitmasterModel.Update(objmodel);
                }

                if (objobjmodel.Satus == "1" && submit == "Submit")
                {
                    objmodel.IsActive = true;
                    TempData["msg"] = "Mineral Unit Saved Sucessfully.";
                    objmodel.MineralUnitName = "";
                    ModelState.Clear();
                    return RedirectToAction("Viewlist", "MineralUnit", new { Area = "master" });
                }
                if (objobjmodel.Satus == "1")
                {
                    TempData["msg"] = "Mineral Unit Updated Sucessfully.";
                    return RedirectToAction("Viewlist", "MineralUnit", new { Area = "master" });
                }
                if (objobjmodel.Satus == "3")
                {
                    ViewBag.msg = "Mineral Unit Name Already Exist!";
                    ViewBag.Button = objmodel.MineralUnitID > 0 ? "Update" : "Submit";
                    return View(objmodel);
                }
                else
                {
                    ViewBag.msg = "Data not Saved Sucessfully";
                    ViewBag.Button = objmodel.MineralUnitID > 0 ? "Update" : "Submit";
                    return View(objmodel);
                }
            }
            else
            {
                ViewBag.Button = objmodel.MineralUnitID > 0 ? "Update" : "Submit";
                return View();
            }
        }
        public IActionResult ViewList(MineralUnitmaster objmodel)
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                ViewBag.ViewList = _objMineralUnitmasterModel.View(objmodel);
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult ViewList(MineralUnitmaster objmodel, string Show1)
        {
            try
            {
                ViewBag.ViewList = _objMineralUnitmasterModel.View(objmodel);
                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Decryption]
        public IActionResult Delete(string id = "0")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            MineralUnitmaster objmodel = new MineralUnitmaster();
            objmodel.CreatedBy = (int)profile.UserId;            
            objmodel.MineralUnitID = Convert.ToInt32(id);

            objobjmodel = _objMineralUnitmasterModel.Delete(objmodel);

            if (objobjmodel.Satus == "1")
            {
                TempData["msg"] = "Mineral Unit Deleted Sucessfully.";
                return RedirectToAction("ViewList");
            }
            else
            {
                TempData["msg"] = "Data not Deleted Sucessfully.";
                return RedirectToAction("ViewList");
            }
        }

    }
}