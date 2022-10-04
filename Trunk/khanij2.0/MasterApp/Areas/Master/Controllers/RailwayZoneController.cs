using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.Division;
using MasterApp.Areas.Master.Models.RailwayZone;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class RailwayZoneController : Controller
    {
        private readonly IRailwayZoneMasterModel railwayZoneMasterModel;
        private readonly IDivisionMasterModel divisionMasterModel;
        RegionalModel regionalModel = new RegionalModel();
        RailwayZoneModel railwayZoneModel = new RailwayZoneModel();
        MessageEF messageEF = new MessageEF();
        public RailwayZoneController(IRailwayZoneMasterModel railwayZoneMasterModel,
            IDivisionMasterModel divisionMasterModel)
        {
            this.railwayZoneMasterModel = railwayZoneMasterModel;
            this.divisionMasterModel = divisionMasterModel;
        }

        #region Add
        [Decryption]
        public IActionResult Add(string id="0")
        { 
            ViewData["State"] = GetStateDetails(); 
            if (!string.IsNullOrEmpty(id) && id != "0")
            {
                railwayZoneModel.RailwayZoneID = Convert.ToInt32(id);
                railwayZoneModel = railwayZoneMasterModel.Edit(railwayZoneModel);
                railwayZoneModel.IsActive = railwayZoneModel.Status == "Active" ? true : false;
                ViewBag.Button = "Update";
                return View(railwayZoneModel);
            }
            else
            {
                railwayZoneModel.IsActive = true;
                ViewBag.Button = "Submit";
                return View(railwayZoneModel);
            }
        }

        private List<RegionalModel> GetStateDetails()
        {
            List<RegionalModel> lstregionalModels = new List<RegionalModel>();
            regionalModel.CHK = 5;
            lstregionalModels = divisionMasterModel.View(regionalModel);
            return lstregionalModels;
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(RailwayZoneModel objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                if(string.IsNullOrEmpty(objmodel.StateID.ToString()))
                {
                    ModelState.AddModelError("StateID", "Please Select State");
                }
                if (string.IsNullOrEmpty(objmodel.RailwayZoneName))
                {
                    ModelState.AddModelError("RailwayZoneName", "Please Enter Zone Name");
                }
                if (ModelState.IsValid)
                {
                    objmodel.CreatedBy = Convert.ToInt32(profile.UserId);

                    if (submit == "Submit")
                    {
                        messageEF = railwayZoneMasterModel.Add(objmodel);
                    }
                    else
                    {
                        messageEF = railwayZoneMasterModel.Update(objmodel);
                    }
                    if (messageEF.Satus == "1" && submit== "Submit")
                    {
                        TempData["msg"] = "Data Saved Sucessfully";
                        return RedirectToAction("ViewList");
                    }
                    if (messageEF.Satus == "1")
                    {
                        TempData["msg"] = "Data Updated Sucessfully"; 
                        return RedirectToAction("ViewList");
                    }
                    else
                    {
                        ViewBag.msg = "Data not Save Sucessfully";
                        ViewData["State"] = GetStateDetails();
                        return View(objmodel);
                    }
                }
                else
                {
                    ViewData["State"] = GetStateDetails();
                    return View(objmodel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region View
        public IActionResult ViewList()
        {
            if(TempData["msg"]!=null)
            {
                ViewBag.msg = TempData["msg"].ToString();
            }
            List<RailwayZoneModel> railwayZoneModels = new List<RailwayZoneModel>();
            railwayZoneModels = railwayZoneMasterModel.View(railwayZoneModel);
            return View(railwayZoneModels);
        }
        #endregion

        #region Delete
        [Decryption]
        public IActionResult Delete(string id = "0")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            railwayZoneModel.CreatedBy = Convert.ToInt32(profile.UserId);
            railwayZoneModel.RailwayZoneID = Convert.ToInt32(id);
            messageEF = railwayZoneMasterModel.Delete(railwayZoneModel);

            if (messageEF.Satus == "1")
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
        #endregion
    }
}