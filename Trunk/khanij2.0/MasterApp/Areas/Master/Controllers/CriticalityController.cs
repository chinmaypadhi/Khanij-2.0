using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.CriticalityMasters;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class CriticalityController : Controller
    {
        private readonly ICriticalityMasterModel criticalityMasterModel;
        MessageEF objobjmodel = new MessageEF();

        #region Constructor
        public CriticalityController(ICriticalityMasterModel criticalityMasterModel)
        {
            this.criticalityMasterModel = criticalityMasterModel;
        }
        #endregion

        #region Add/Update
        [Decryption]
        public IActionResult Add(string id = "0" )
        {
           
            CriticalityMaster objmodel = new CriticalityMaster();
            if (!string.IsNullOrEmpty(id) && id != "0")
            { 
                objmodel.CriticalityMasterId =  Convert.ToInt32(id);
                objmodel = criticalityMasterModel.Edit(objmodel);
                objmodel.IsActive =(objmodel.Status=="True"?true:false);
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
        public IActionResult Add(CriticalityMaster objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                if (string.IsNullOrEmpty(objmodel.CriticalityName))
                {
                    ModelState.AddModelError("CriticalityName", "Please Enter Criticality Name");
                }
                if (!string.IsNullOrEmpty(objmodel.CriticalityName))
                {
                    if (objmodel.CriticalityName.Length > 50)
                    {
                        ModelState.AddModelError("CriticalityName", "Maximum 50 Characters Allowed");
                    }
                }
                if (ModelState.IsValid)
                {
                    objmodel.CreatedBy =  profile.UserId;
                    objmodel.UserLoginID = profile.UserLoginId;

                    if (submit == "Submit")
                    {
                        objobjmodel = criticalityMasterModel.Add(objmodel);
                    }
                    else
                    {
                        objobjmodel = criticalityMasterModel.Update(objmodel);
                    }
                    if(objobjmodel.Satus=="1" && submit=="Submit")
                    {
                        TempData["Message"] = "Data Saved Sucessfully";
                        return RedirectToAction("ViewList");
                    }
                    if (objobjmodel.Satus == "1")
                    {
                       TempData["Message"] = "Data Updated Sucessfully";
                        return RedirectToAction("ViewList");
                    }
                    if (objobjmodel.Satus == "2")
                    {
                        TempData["Message"] = "Name Already Exists !! ";
                        return RedirectToAction("Add");
                    }
                    else
                    {
                        ViewBag.msg = "Data not Saved Sucessfully";
                        return View();
                    }
                }
                return View(objmodel);
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region View Detail
        [HttpGet] 
        public IActionResult ViewList(CriticalityMaster criticalityMaster)
        {
            try
            {
                if (TempData["Message"] != null)
                {
                    ViewBag.msg = TempData["Message"].ToString();
                    TempData["Message"] = null;
                }
                List<CriticalityMaster> lstcriticalityMasters= criticalityMasterModel.View(criticalityMaster);
                return View(lstcriticalityMasters);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
        #endregion

        #region Delete
        [Decryption]
        public IActionResult Delete(string id = "0")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            CriticalityMaster objmodel = new CriticalityMaster();
            objmodel.CreatedBy = (int)profile.UserId;
            objmodel.UserLoginID = (int)profile.UserLoginId;
            objmodel.CriticalityMasterId = Convert.ToInt32(id);
            objobjmodel = criticalityMasterModel.Delete(objmodel);
            if (objobjmodel.Satus == "1")
            {
                TempData["Message"] = "Data Deleted Sucessfully";
                return RedirectToAction("ViewList");
            }
            else
            {
                TempData["Message"] = "Data not Deleted Sucessfully";
                return RedirectToAction("ViewList");
            }
        }
        #endregion
    }
}