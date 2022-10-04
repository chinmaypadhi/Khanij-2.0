// ***********************************************************************
// Assembly         : Khanij
// Author           : Kumar jeevan jyoti
// Created          : 28-dec-2020
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.Areas.Master.Models.Mineral;
using MasterApp.Areas.Master.Models.MineralGrade;
using MasterApp.Areas.Master.Models.MineralSchedule;
using MasterApp.Areas.Master.Models.MineralSchedulePart;
using MasterApp.Areas.Master.Models.Royalty;
using MasterApp.Models.MIneral;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MasterApp.ActionFilter;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class MineralController : Controller
    {
        #region global Declaration
        IMIneralModel _objMIneralModel;
        private readonly IMineralMasterModel mineralMasterModel;
        private readonly IMineralGradeMasterModel mineralGradeMasterModel;
        private readonly IMineralScheduleMasterModel mineralScheduleMasterModel;
        private readonly IMineralSchedulePartMasterModel mineralSchedulePartMasterModel;
        private readonly IRoyaltyMasterModel royaltyMasterModel;
        IOtherMineralModel _objOtherMineralModel;
        MineralModel mineralModel = new MineralModel();
        MineralScheduleModel mineralScheduleModel = new MineralScheduleModel();
        List<MineralScheduleModel> lstmineralScheduleModels = new List<MineralScheduleModel>();
        MineralSchedulePartModel mineralSchedulePartModel = new MineralSchedulePartModel();
        List<MineralSchedulePartModel> lstmineralSchedulePartModels = new List<MineralSchedulePartModel>();
        MineralGradeModel mineralGradeModel = new MineralGradeModel();
        List<MineralGradeModel> listMineralType = new List<MineralGradeModel>();
        RoyaltyModel royaltyModel = new RoyaltyModel();
        List<RoyaltyModel> lstroyaltyModels = new List<RoyaltyModel>();
        MessageEF objobjmodel = new MessageEF();
        OtherMineralsmaster objOtherMineralmodel = new OtherMineralsmaster();
        #endregion

        #region Constructor Dependency Injection
        public MineralController(IMIneralModel objMIneralModel, IMineralMasterModel mineralMasterModel,
           IMineralGradeMasterModel mineralGradeMasterModel,
           IMineralScheduleMasterModel mineralScheduleMasterModel,
           IMineralSchedulePartMasterModel mineralSchedulePartMasterModel,
           IRoyaltyMasterModel royaltyMasterModel,
           IOtherMineralModel objOtherMineralModel)
        {
            _objMIneralModel = objMIneralModel;
            this.mineralMasterModel = mineralMasterModel;
            this.mineralGradeMasterModel = mineralGradeMasterModel;
            this.mineralScheduleMasterModel = mineralScheduleMasterModel;
            this.mineralSchedulePartMasterModel = mineralSchedulePartMasterModel;
            this.royaltyMasterModel = royaltyMasterModel;
            _objOtherMineralModel = objOtherMineralModel;
        }
        #endregion

        #region Category
        [Decryption]
        public IActionResult Add(string id="0")
        {
            MineralCategory objmodel = new MineralCategory();
            if (! string.IsNullOrEmpty(id) && id != "0")
            {
                
                objmodel.MineralTypeID =Convert.ToInt32(id);
                objmodel = _objMIneralModel.Edit(objmodel);
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
        public IActionResult Add(MineralCategory objmodel,string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.CreatedBy =  profile.UserId;
            objmodel.UserLoginId = profile.UserLoginId;
            if (submit == "Submit")
            {
                objobjmodel = _objMIneralModel.Add(objmodel);
            }
            else
            {
                objobjmodel = _objMIneralModel.Update(objmodel);
                
            }
            if(objobjmodel.Satus=="1" && submit == "Submit")
            {
                objmodel = new MineralCategory();
                objmodel.IsActive = true;
                objmodel.MineralType = "";
                ViewBag.msg = "Data Saved Sucessfully";
                return View(objmodel);
            }
            else if(objobjmodel.Satus == "1")
            {
                TempData["msg"] = "Data Updated Sucessfully";
                return RedirectToAction("Viewlist", "Mineral", new { Area = "master" });
            }
            else if (objobjmodel.Satus == "2")
            {
                TempData["msg"] = "Mineral Name Already Exists !! ";
                return RedirectToAction("Add", "Mineral", new { Area = "master" });
            }
            else
            {
                ViewBag.msg = "Data not Saved Sucessfully";
                return View();
            }
        }
       
        public IActionResult ViewList(MineralCategory objmodel)
        {
            try
            {
                List<MineralCategory> mineralCategoriesList = new List<MineralCategory>();
                mineralCategoriesList = _objMIneralModel.View(objmodel);
                return View(mineralCategoriesList);
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
            MineralCategory objmodel = new MineralCategory();
            objmodel.CreatedBy = profile.UserId;
            objmodel.UserLoginId = profile.UserLoginId;
            objmodel.MineralTypeID =Convert.ToInt32(id);
                objobjmodel = _objMIneralModel.Delete(objmodel);
            
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
        #endregion

        #region Mineral
        #region Add/Update
        public IActionResult Mineral(int id = 0)
        {

            ViewData["MineralCategory"] = GetMineralCategory();
            ViewData["MineralUnit"] = GetMineralUnit();
            ViewData["RoyaltyBasis"] = GetRoyaltyBasis();
            if (id != 0)
            {
                mineralModel.MineralID = id;
                mineralModel = mineralMasterModel.Edit(mineralModel);
                mineralModel.IsActive = mineralModel.Status == "Active" ? true : false;
                ViewData["MineralSchedule"] = GetMineralSchedule(mineralModel.MineralTypeId);
                ViewData["MineralSchedulePart"] = GetMineralSchedulePart(mineralModel.MineralScheduleId);
                ViewBag.Button = "Update";
                return View(mineralModel);
            }
            else
            {
                mineralModel.IsActive = true;
                ViewBag.Button = "Submit";
                return View(mineralModel);
            }
        }

        private List<MineralSchedulePartModel> GetMineralSchedulePart(int? MineralScheduleId)
        {
            if (MineralScheduleId != 0 && MineralScheduleId != null)
            {
                mineralSchedulePartModel.MineralScheduleId = MineralScheduleId;
                lstmineralSchedulePartModels = mineralSchedulePartMasterModel.View(mineralSchedulePartModel);
            }
            else
            {
                lstmineralSchedulePartModels = null;
            }
            return lstmineralSchedulePartModels;
        }

        private List<MineralScheduleModel> GetMineralSchedule(int? MineralTypeId)
        {
            if (MineralTypeId != 0 && MineralTypeId != null)
            {
                mineralScheduleModel.MineralTypeId = MineralTypeId;
                lstmineralScheduleModels = mineralScheduleMasterModel.View(mineralScheduleModel);
            }
            else
            {
                lstmineralScheduleModels = null;
            }
            return lstmineralScheduleModels;
        }

        private List<RoyaltyModel> GetRoyaltyBasis()
        {
            royaltyModel.chk = 7;
            lstroyaltyModels = royaltyMasterModel.View(royaltyModel);
            return lstroyaltyModels;
        }

        private List<RoyaltyModel> GetMineralUnit()
        {
            royaltyModel.chk = 6;
            lstroyaltyModels = royaltyMasterModel.View(royaltyModel);
            return lstroyaltyModels;
        }

        private List<MineralGradeModel> GetMineralCategory()
        {
            mineralGradeModel.CHK = 8;
            listMineralType = mineralGradeMasterModel.View(mineralGradeModel);
            return listMineralType;
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Mineral(MineralModel objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                if (string.IsNullOrEmpty(objmodel.MineralTypeId.ToString()))
                {
                    ModelState.AddModelError("MineralTypeId", "Please Select Mineral Category");
                }
                if (string.IsNullOrEmpty(objmodel.MineralScheduleId.ToString()))
                {
                    ModelState.AddModelError("MineralScheduleId", "Please Select Mineral Schedule");
                }
                if (string.IsNullOrEmpty(objmodel.MineralSchedulePartId.ToString()))
                {
                    ModelState.AddModelError("MineralSchedulePartId", "Please Select Mineral Schedule Part");
                }
                if (string.IsNullOrEmpty(objmodel.MineralName))
                {
                    ModelState.AddModelError("MineralName", "Please Enter Mineral Name");
                }
                if (string.IsNullOrEmpty(objmodel.UnitId.ToString()))
                {
                    ModelState.AddModelError("UnitId", "Please Select Mineral Unit");
                }
                if (string.IsNullOrEmpty(objmodel.RoyaltyRateTypeId.ToString()))
                {
                    ModelState.AddModelError("RoyaltyRateTypeId", "Please Select Royalty Basis");
                }
                if (ModelState.IsValid)
                {
                    objmodel.CreatedBy =  profile.UserId;

                    if (submit == "Submit")
                    {
                        objobjmodel = mineralMasterModel.Add(objmodel);
                    }
                    else
                    {
                        objobjmodel = mineralMasterModel.Update(objmodel);
                    }
                    if (objobjmodel.Satus == "1")
                    {
                        TempData["msg"] = "Data Save Sucessfully";
                        return RedirectToAction("ViewMineral");
                    }
                    else
                    {
                        ViewBag.msg = "Data not Save Sucessfully";
                        ViewData["MineralCategory"] = GetMineralCategory();
                        ViewData["MineralUnit"] = GetMineralUnit();
                        ViewData["RoyaltyBasis"] = GetRoyaltyBasis();
                        return View(objmodel);
                    }
                }
                else
                {
                    ViewData["MineralCategory"] = GetMineralCategory();
                    ViewData["MineralUnit"] = GetMineralUnit();
                    ViewData["RoyaltyBasis"] = GetRoyaltyBasis();
                    ViewData["MineralSchedule"] = GetMineralSchedule(objmodel.MineralTypeId);
                    ViewData["MineralSchedulePart"] = GetMineralSchedulePart(objmodel.MineralScheduleId);
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
        public IActionResult ViewMineral()
        {
            if (TempData["msg"] != null)
            {
                ViewBag.msg = TempData["msg"].ToString();
            }
            List<MineralModel> mineralModels = mineralMasterModel.View(mineralModel);
            return View(mineralModels);
        }
        #endregion

        #region Delete 
        public IActionResult DeleteMineral(int id = 0)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            mineralModel.CreatedBy = profile.UserId;
            mineralModel.MineralID = id;
            objobjmodel = mineralMasterModel.Delete(mineralModel);

            if (objobjmodel.Satus == "1")
            {
                TempData["msg"] = "Data Deleted Sucessfully";
                return RedirectToAction("ViewMineral");
            }
            else
            {
                TempData["msg"] = "Data not Deleted Sucessfully";
                return RedirectToAction("ViewMineral");
            }


        }
        #endregion

        #endregion

        #region Other Mineral
        public IActionResult AddOtherMineral(int id = 0)
        {                      
            if (id != 0)
            {
                objOtherMineralmodel.OtherMineralId = id;
                ViewBag.Otherminerals = GetMineral(objOtherMineralmodel.MineralId);
                objOtherMineralmodel = _objOtherMineralModel.EditOtherMineral(objOtherMineralmodel);
                ViewBag.Button = "Update";
                return View(objOtherMineralmodel);
            }
            else
            {
                ViewBag.Otherminerals = GetMineral(null);
                ViewBag.Button = "Submit";
                return View(objOtherMineralmodel);
            }
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult AddOtherMineral(OtherMineralsmaster objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserId = profile.UserId;
            objmodel.UserLoginId = profile.UserLoginId;
            if (string.IsNullOrEmpty(objmodel.MineralId.ToString()) || objmodel.MineralId.ToString() == "0")
            {
                ModelState.AddModelError("MineralId", "Please Select Mineral");
                ViewBag.Districts = GetMineral(null);
            }
            if (string.IsNullOrEmpty(objmodel.Fector1))
            {
                ModelState.AddModelError("Fector1", "Factor field is required");
            }
            if (!string.IsNullOrEmpty(objmodel.Fector1) && (objmodel.Fector1.Length > 50))
            {
                ModelState.AddModelError("Fector1", "Factor field must be less than 50 characters");
            }
            if (string.IsNullOrEmpty(objmodel.EffectiveFromDate))
            {
                ModelState.AddModelError("EffectiveFromDate", "Effective From Date field is required");
            }
            if (ModelState.IsValid)
            {
                if (submit == "Submit")
                {
                    objobjmodel = _objOtherMineralModel.AddOtherMineral(objmodel);
                }
                else
                {
                    objobjmodel = _objOtherMineralModel.UpdateOtherMineral(objmodel);

                }
                if (objobjmodel.Satus == "1")
                {
                    objmodel.MineralName = "";
                    TempData["msg"] = "Data Saved Sucessfully";
                    return RedirectToAction("ViewOtherMineralList", "Mineral", new { Area = "master" });
                }
                if (objobjmodel.Satus == "2")
                {
                    TempData["msg"] = "Data updated Sucessfully";
                    return RedirectToAction("ViewOtherMineralList", "Mineral", new { Area = "master" });
                }
                if (objobjmodel.Satus == "3")
                {
                    ViewBag.msg = "Effective date greater than previous effective date!";
                    ViewBag.Button = objmodel.OtherMineralId > 0 ? "Update" : "Submit";
                    ViewBag.Otherminerals = GetMineral(null);
                    return View();
                }
                else
                {
                    ViewBag.msg = "Data not Saved Sucessfully";
                    ViewBag.Button = objmodel.OtherMineralId > 0 ? "Update" : "Submit";
                    ViewBag.Otherminerals = GetMineral(null);
                    return View();
                }
            }
            else
            {
                ViewBag.Button = objmodel.OtherMineralId > 0 ? "Update" : "Submit";
                ViewBag.Otherminerals = GetMineral(null);
                return View();
            }
        }
        public IActionResult ViewOtherMineralList(OtherMineralsmaster objmodel)
        {
            try
            {
                ViewBag.ViewList = _objOtherMineralModel.ViewOtherMineral(objmodel);
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult ViewOtherMineralList(OtherMineralsmaster objmodel, string Show1)
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                ViewBag.ViewList = _objOtherMineralModel.ViewOtherMineral(objmodel);
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public IActionResult DeleteOtherMineral(int id = 0)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            OtherMineralsmaster objmodel = new OtherMineralsmaster();
            objmodel.UserLoginId = (int)profile.UserId;
            objmodel.OtherMineralId = id;

            objobjmodel = _objOtherMineralModel.DeleteOtherMineral(objmodel);
            ViewBag.msg = objobjmodel.Satus;
            if (objobjmodel.Satus == "1")
            {
                TempData["msg"] = "Data Deleted Sucessfully";
                return RedirectToAction("ViewOtherMineralList");
            }
            else
            {
                TempData["msg"] = "Data not Deleted Sucessfully";
                return RedirectToAction("ViewOtherMineralList");
            }
        }
        private SelectList GetMineral(int? MineralId)
        {
            List<OtherMineralsmaster> listOtherMineralResult = new List<OtherMineralsmaster>();
            listOtherMineralResult = _objOtherMineralModel.GetOtherMineralList(objOtherMineralmodel);
            return new SelectList(listOtherMineralResult, "MineralId", "MineralName", MineralId);
        }
        public JsonResult UpdatePublishStatus(int? OtherMineralId)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objOtherMineralmodel.OtherMineralId = OtherMineralId;
            objOtherMineralmodel.UserId = profile.UserId;
            objOtherMineralmodel.UserLoginId = profile.UserLoginId;
            objobjmodel = _objOtherMineralModel.UpdatePublishStatus(objOtherMineralmodel);
            return Json(objobjmodel.Satus);
        }
        public ActionResult Download_OtherMinerals(int id=0)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objOtherMineralmodel.OtherMineralId = id;
            objOtherMineralmodel.UserId = profile.UserId;
            objOtherMineralmodel = _objOtherMineralModel.Download_OtherMinerals(objOtherMineralmodel);
            return View(objOtherMineralmodel);
        }
        #endregion
    }
}