// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 2-Feb-2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using MasterApp.Areas.Master.Models.RoyaltyMapping;
using MasterApp.Areas.Master.Models.MineralGrade;
using MasterApp.Areas.Master.Models.MineralSchedule;
using MasterApp.Areas.Master.Models.MineralSchedulePart;
using MasterApp.Areas.Master.Models.Royalty;
using MasterApp.Areas.Master.Models.OSU;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MasterApp.ActionFilter;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class RoyaltyMappingController : Controller
    {
        #region Global Object and Variable declaration
        private readonly IRoyaltyMappingModel _objRoyaltyMappingmasterModel;
        private readonly IMineralGradeMasterModel mineralGradeMasterModel;
        private readonly IMineralScheduleMasterModel mineralScheduleMasterModel;
        private readonly IMineralSchedulePartMasterModel mineralSchedulePartMasterModel;
        private readonly IRoyaltyMasterModel _royaltyMasterModel;
        private readonly IOSUModel _OSUModel;
        MessageEF objobjmodel = new MessageEF();

        RoyaltyMappingmaster objRoyaltyMappingmaster = new RoyaltyMappingmaster();
        List<RoyaltyMappingmaster> lstobjRoyaltyMappingmasters = new List<RoyaltyMappingmaster>();

        MineralScheduleModel mineralScheduleModel = new MineralScheduleModel();
        List<MineralScheduleModel> lstmineralScheduleModels = new List<MineralScheduleModel>();

        MineralSchedulePartModel mineralSchedulePartModel = new MineralSchedulePartModel();
        List<MineralSchedulePartModel> lstmineralSchedulePartModels = new List<MineralSchedulePartModel>();

        MineralGradeModel mineralGradeModel = new MineralGradeModel();
        List<MineralGradeModel> listMineralType = new List<MineralGradeModel>();

        RoyaltyModel royaltyModel = new RoyaltyModel();
        List<RoyaltyModel> listRoyalty = new List<RoyaltyModel>();

        OSUmaster osuMaster = new OSUmaster();
        List<OSUmaster> listOSU = new List<OSUmaster>();
        #endregion
        public RoyaltyMappingController(IRoyaltyMappingModel objRoyaltyMappingmasterModel,
             IMineralGradeMasterModel mineralGradeMasterModel,
            IMineralScheduleMasterModel mineralScheduleMasterModel,
            IMineralSchedulePartMasterModel mineralSchedulePartMasterModel,
            IRoyaltyMasterModel royaltyMasterModel,
            IOSUModel OSUModel)
        {
            _objRoyaltyMappingmasterModel = objRoyaltyMappingmasterModel;
            this.mineralGradeMasterModel = mineralGradeMasterModel;
            this.mineralScheduleMasterModel = mineralScheduleMasterModel;
            this.mineralSchedulePartMasterModel = mineralSchedulePartMasterModel;
            _royaltyMasterModel = royaltyMasterModel;
            _OSUModel = OSUModel;
        }
        [Decryption]
        public IActionResult Add(string id = "0")
        {
            //RoyaltyMappingmaster objmodel = new RoyaltyMappingmaster();
            mineralGradeModel.CHK = 8;
            listMineralType = mineralGradeMasterModel.View(mineralGradeModel);
            ViewData["MineralCategory"] = listMineralType;

            mineralGradeModel.CHK = 7;
            listMineralType = mineralGradeMasterModel.View(mineralGradeModel);
            ViewData["CalculationType"] = listMineralType;

            objRoyaltyMappingmaster.MappingID = Convert.ToInt32(id);
            ViewBag.PaymentType = _objRoyaltyMappingmasterModel.ViewPaymentType(objRoyaltyMappingmaster);
            if (!string.IsNullOrEmpty(id) && id != "0")
            {

                objRoyaltyMappingmaster = _objRoyaltyMappingmasterModel.Edit(objRoyaltyMappingmaster);
                mineralScheduleModel.MineralTypeId = objRoyaltyMappingmaster.MineralTypeId;
                lstmineralScheduleModels = mineralScheduleMasterModel.View(mineralScheduleModel);
                ViewData["MineralSchedule"] = lstmineralScheduleModels;
                mineralSchedulePartModel.MineralScheduleId = objRoyaltyMappingmaster.MineralScheduleId;
                lstmineralSchedulePartModels = mineralSchedulePartMasterModel.View(mineralSchedulePartModel);
                ViewData["MineralSchedulePart"] = lstmineralSchedulePartModels;

                royaltyModel.chk = 5;
                royaltyModel.MineralSchedulePartId = objRoyaltyMappingmaster.MineralSchedulePartId;
                listRoyalty = _royaltyMasterModel.View(royaltyModel);
                ViewData["MineralName"] = listRoyalty;

                royaltyModel.chk = 6;
                royaltyModel.MineralId = objRoyaltyMappingmaster.MineralId;
                listRoyalty = _royaltyMasterModel.View(royaltyModel);
                ViewData["MineralUnit"] = listRoyalty;

                royaltyModel.chk = 7;
                royaltyModel.MineralId = objRoyaltyMappingmaster.MineralId;
                listRoyalty = _royaltyMasterModel.View(royaltyModel);
                ViewData["RoyaltyBasis"] = listRoyalty;

                mineralGradeModel.CHK = 5;
                mineralGradeModel.MineralTypeId = objRoyaltyMappingmaster.MineralTypeId;
                mineralGradeModel.MineralId = objRoyaltyMappingmaster.MineralId;
                listMineralType = mineralGradeMasterModel.View(mineralGradeModel);
                ViewData["MineralForm"] = listMineralType;

                mineralGradeModel.CHK = 6;
                mineralGradeModel.MineralNatureId = objRoyaltyMappingmaster.MineralNatureId;
                listMineralType = mineralGradeMasterModel.View(mineralGradeModel);
                ViewData["MineralGrade"] = listMineralType;

                listOSU = _OSUModel.GetLesseeTypeList(osuMaster);
                ViewData["OSU"] = listOSU;

                lstobjRoyaltyMappingmasters = _objRoyaltyMappingmasterModel.ViewRoyaltyType(objRoyaltyMappingmaster);
                ViewData["RoyaltyRate"] = lstobjRoyaltyMappingmasters;

                objRoyaltyMappingmaster.IsGrantType = objRoyaltyMappingmaster.GrantType == "1" ? true : false;

                ViewBag.Button = "Update";
                return View(objRoyaltyMappingmaster);
            }
            else
            {
                ViewBag.PaymentType = _objRoyaltyMappingmasterModel.ViewPaymentType(objRoyaltyMappingmaster);
                lstmineralScheduleModels = null;
                lstobjRoyaltyMappingmasters = null;
                ViewData["MineralSchedule"] = lstmineralScheduleModels;
                ViewData["MineralName"] = lstobjRoyaltyMappingmasters;
                objRoyaltyMappingmaster.IsGrantType = true;
                ViewBag.Button = "Submit";
                return View(objRoyaltyMappingmaster);
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(RoyaltyMappingmaster objModel, string submit)
        {
            if (string.IsNullOrEmpty(objModel.MineralTypeId.ToString()) || objModel.MineralTypeId.ToString() == "0")
            {
                ModelState.AddModelError("MineralTypeId", "Please Select Mineral Category");
                mineralGradeModel.CHK = 8;
                listMineralType = mineralGradeMasterModel.View(mineralGradeModel);
                ViewData["MineralCategory"] = listMineralType;
            }
            if (string.IsNullOrEmpty(objModel.MineralScheduleId.ToString()) || objModel.MineralScheduleId.ToString() == "0")
            {
                ModelState.AddModelError("MineralScheduleId", "Please Select Mineral Schedule");
            }
            if (string.IsNullOrEmpty(objModel.MineralSchedulePartId.ToString()) || objModel.MineralSchedulePartId.ToString() == "0")
            {
                ModelState.AddModelError("MineralSchedulePartId", "Please Select Mineral Schedule Part");
            }
            if (string.IsNullOrEmpty(objModel.MineralId.ToString()) || objModel.MineralId.ToString() == "0")
            {
                ModelState.AddModelError("MineralId", "Please Select Mineral Name");
            }
            if (string.IsNullOrEmpty(objModel.UnitId.ToString()) || objModel.UnitId.ToString() == "0")
            {
                ModelState.AddModelError("UnitId", "Please Select Mineral Unit");
            }
            if (string.IsNullOrEmpty(objModel.RoyaltyRateTypeId.ToString()) || objModel.RoyaltyRateTypeId.ToString() == "0")
            {
                ModelState.AddModelError("RoyaltyRateTypeId", "Please Select Royalty Basis");
            }
            if (string.IsNullOrEmpty(objModel.MineralNatureId.ToString()) || objModel.MineralNatureId.ToString() == "0")
            {
                ModelState.AddModelError("MineralNatureId", "Please Select Mineral Form");
            }
            if (string.IsNullOrEmpty(objModel.MineralGradeId.ToString()) || objModel.MineralGradeId.ToString() == "0")
            {
                ModelState.AddModelError("MineralGradeId", "Please Select Mineral Grade");
            }
            if (string.IsNullOrEmpty(objModel.RoyaltyId.ToString()) || objModel.RoyaltyId.ToString() == "0")
            {
                ModelState.AddModelError("RoyaltyId", "Please Select Royalty");
            }
            if (string.IsNullOrEmpty(objModel.GrantOrderDate))
            {
                ModelState.AddModelError("GrantOrderDate", "Please Select Grant Order Date");
            }
            if (string.IsNullOrEmpty(objModel.AuctionName))
            {
                ModelState.AddModelError("AuctionName", "Please Select Auction Name");
            }
            if (string.IsNullOrEmpty(objModel.ID.ToString()) || objModel.ID.ToString() == "0")
            {
                ModelState.AddModelError("ID", "Please Select Lease Type");
            }
            if (ModelState.IsValid)
            {
                objobjmodel = _objRoyaltyMappingmasterModel.Add(objModel);
                ViewBag.PaymentType = _objRoyaltyMappingmasterModel.ViewPaymentType(objModel);
                ViewBag.msg = objobjmodel.Satus;
                if (objobjmodel.Satus == "1")
                {
                    if (objModel.MappingID > 0)
                    {
                        TempData["msg"] = "Royalty mapping updated successfully.";
                    }
                    else
                    {
                        TempData["msg"] = "Royalty mapping inserted successfully.";
                    }
                }
                else if (objobjmodel.Satus == "2")
                {
                    TempData["msg"] = "Same record already exists !";
                }
                else
                {
                    TempData["msg"] = "Something went wrong !";
                }

                return RedirectToAction("ViewList");
            }
            return View();
            }
            
        public JsonResult GetRoyaltyRateByMineralGrade(int MineralGradeId)
        {
            RoyaltyMappingmaster objmodel = new RoyaltyMappingmaster();
            objmodel.MineralGradeId = MineralGradeId;
            List<RoyaltyMappingmaster> listRoyaltyrateResult = new List<RoyaltyMappingmaster>();
            listRoyaltyrateResult = _objRoyaltyMappingmasterModel.ViewRoyaltyType(objmodel);
            return Json(listRoyaltyrateResult);
        }
        #region View
        public IActionResult ViewList(RoyaltyMappingmaster objmodel)
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"];
                }
                ViewBag.ViewList = _objRoyaltyMappingmasterModel.View(objmodel);
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult ViewList(RoyaltyMappingmaster objmodel, string Show1)
        {
            try
            {
                ViewBag.ViewList = _objRoyaltyMappingmasterModel.View(objmodel);
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        #endregion
        [Decryption]
        public IActionResult Delete(string id = "0")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            RoyaltyMappingmaster objmodel = new RoyaltyMappingmaster();
            //objmodel.CreatedBy = (int)profile.UserId;
            //objmodel.UserLoginID = (int)profile.UserLoginId;
            //objmodel.CreatedBy = 1;
            //objmodel.UserLoginID = 1;
            objmodel.MappingID = Convert.ToInt32(id);

            objobjmodel = _objRoyaltyMappingmasterModel.Delete(objmodel);

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
        public ActionResult DownloadRoyaltyMapping(int id=0)
        {
            objRoyaltyMappingmaster.MappingID = id;
            ViewBag.PaymentType = _objRoyaltyMappingmasterModel.ViewPaymentType(objRoyaltyMappingmaster);
            objRoyaltyMappingmaster = _objRoyaltyMappingmasterModel.Edit(objRoyaltyMappingmaster);
            return View(objRoyaltyMappingmaster);
        }
        #region Bind Dropdowns
        public JsonResult GetSchedulePartNameByScheduleId(int ScheduleId)
        {
            mineralSchedulePartModel.MineralScheduleId = ScheduleId;
            lstmineralSchedulePartModels = mineralSchedulePartMasterModel.View(mineralSchedulePartModel);
            return Json(lstmineralSchedulePartModels);
        }

        public JsonResult GetMineralNameBySchedulePartId(int SchedulePartId)
        {
            objRoyaltyMappingmaster.chk = 5;
            objRoyaltyMappingmaster.MineralSchedulePartId = SchedulePartId;
            lstobjRoyaltyMappingmasters = _objRoyaltyMappingmasterModel.View(objRoyaltyMappingmaster);
            return Json(lstobjRoyaltyMappingmasters);
        }

        public JsonResult GetMineralUnitByMineralID(int MineralID)
        {
            objRoyaltyMappingmaster.chk = 6;
            objRoyaltyMappingmaster.MineralId = MineralID;
            lstobjRoyaltyMappingmasters = _objRoyaltyMappingmasterModel.View(objRoyaltyMappingmaster);
            return Json(lstobjRoyaltyMappingmasters);
        }

        public JsonResult GetRoyaltyBasisByMineralID(int MineralID)
        {
            objRoyaltyMappingmaster.chk = 7;
            objRoyaltyMappingmaster.MineralId = MineralID;
            lstobjRoyaltyMappingmasters = _objRoyaltyMappingmasterModel.View(objRoyaltyMappingmaster);
            return Json(lstobjRoyaltyMappingmasters);
        }

        public JsonResult GetRoyaltyMineralGradeByNatureId(int NatureId)
        {
            mineralGradeModel.CHK = 6;
            mineralGradeModel.MineralNatureId = NatureId;
            listMineralType = mineralGradeMasterModel.View(mineralGradeModel);
            return Json(listMineralType);
        }
        #endregion
    }
}