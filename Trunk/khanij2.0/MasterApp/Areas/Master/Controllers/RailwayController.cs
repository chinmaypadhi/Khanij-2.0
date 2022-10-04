using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.Railway;
using MasterApp.Areas.Master.Models.RailwayZone;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class RailwayController : Controller
    {
        private readonly IRailwayMasterModel railwayMasterModel;
        private readonly IRailwayZoneMasterModel railwayZoneMasterModel;
        RailwayModel railwayModel = new RailwayModel();
        RailwayZoneModel railwayZoneModel = new RailwayZoneModel();
        MessageEF messageEF = new MessageEF();
        public RailwayController(IRailwayMasterModel railwayMasterModel,
            IRailwayZoneMasterModel railwayZoneMasterModel)
        {
            this.railwayMasterModel = railwayMasterModel;
            this.railwayZoneMasterModel = railwayZoneMasterModel;
        }

        #region Add
        [Decryption]
        public IActionResult Add(string id = "0")
        { 
            ViewData["RailwayZone"] = GetRailwayZone();
            if (!string.IsNullOrEmpty(id) && id != "0")
            {
                railwayModel.RailwayID = Convert.ToInt32(id);
                railwayModel = railwayMasterModel.Edit(railwayModel);
                railwayModel.IsActive = railwayModel.Status == "Active" ? true : false;
                ViewBag.Button = "Update";
                return View(railwayModel);
            }
            else
            {
                railwayModel.IsActive = true;
                ViewBag.Button = "Submit";
                return View(railwayModel);
            }
        }

        private List<RailwayZoneModel> GetRailwayZone()
        {
            List<RailwayZoneModel> lstrailwayZoneModels = new List<RailwayZoneModel>();
            lstrailwayZoneModels = railwayZoneMasterModel.View(railwayZoneModel);
            return lstrailwayZoneModels;
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(RailwayModel objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                if(string.IsNullOrEmpty(objmodel.RailwaySlidingName))
                {
                    ModelState.AddModelError("RailwaySlidingName", "Please Enter Siding Name");
                }
                if (string.IsNullOrEmpty(objmodel.RailwayZoneID.ToString()))
                {
                    ModelState.AddModelError("RailwayZoneID", "Please Select Railway Zone");
                }
                if (ModelState.IsValid)
                {
                    objmodel.CreatedBy =  profile.UserId;

                    if (submit == "Submit")
                    {
                        messageEF = railwayMasterModel.Add(objmodel);
                    }
                    else
                    {
                        messageEF = railwayMasterModel.Update(objmodel);
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
                        ViewData["RailwayZone"] = GetRailwayZone();
                        return View(objmodel);
                        }
                }
                else
                {
                    ViewData["RailwayZone"] = GetRailwayZone();
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
            List<RailwayModel> railwayModels = new List<RailwayModel>();
            railwayModels = railwayMasterModel.View(railwayModel);
            return View(railwayModels);
        }
        #endregion

        #region Delete 
        [Decryption]
        public IActionResult Delete(string id = "0")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            railwayModel.CreatedBy = profile.UserId;
            railwayModel.RailwayID = Convert.ToInt32(id);
            messageEF = railwayMasterModel.Delete(railwayModel);

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