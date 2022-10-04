using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.MineralGrade;
using MasterApp.Areas.Master.Models.MineralSchedule;
using MasterApp.Areas.Master.Models.MineralSchedulePart;
using MasterApp.Areas.Master.Models.Royalty;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class RoyaltyController : Controller
    {
        private readonly IRoyaltyMasterModel royaltyMasterModel;
        private readonly IMineralGradeMasterModel mineralGradeMasterModel;
        private readonly IMineralScheduleMasterModel mineralScheduleMasterModel;
        private readonly IMineralSchedulePartMasterModel mineralSchedulePartMasterModel;
        RoyaltyModel royaltyModel = new RoyaltyModel();
        List<RoyaltyModel> lstroyaltyModels = new List<RoyaltyModel>();
        MessageEF messageEF = new MessageEF();
        MineralScheduleModel mineralScheduleModel = new MineralScheduleModel();
        List<MineralScheduleModel> lstmineralScheduleModels = new List<MineralScheduleModel>();
        MineralSchedulePartModel mineralSchedulePartModel = new MineralSchedulePartModel();
        List<MineralSchedulePartModel> lstmineralSchedulePartModels = new List<MineralSchedulePartModel>();
        MineralGradeModel mineralGradeModel = new MineralGradeModel();
        List<MineralGradeModel> listMineralType = new List<MineralGradeModel>();
        public RoyaltyController(IRoyaltyMasterModel royaltyMasterModel, 
            IMineralGradeMasterModel mineralGradeMasterModel,
            IMineralScheduleMasterModel mineralScheduleMasterModel,
            IMineralSchedulePartMasterModel mineralSchedulePartMasterModel)
        {
            this.royaltyMasterModel = royaltyMasterModel;
            this.mineralGradeMasterModel = mineralGradeMasterModel;
            this.mineralScheduleMasterModel = mineralScheduleMasterModel;
            this.mineralSchedulePartMasterModel = mineralSchedulePartMasterModel;
        }

        #region Add/Update
        [Decryption]
        public IActionResult Add(string id= "0")
        {
            //---------------------------  
            ViewData["MineralCategory"] = GetMineralCategory(); 
            ViewData["CalculationType"] = GetCalculationType();
            //------------------------
            if ( !string.IsNullOrEmpty(id) && id != "0")
            {
                royaltyModel.RoyaltyID = Convert.ToInt32(id);
                royaltyModel = royaltyMasterModel.Edit(royaltyModel); 
                ViewData["MineralSchedule"] = GetMineralSchedule(royaltyModel.MineralTypeId);
                ViewData["MineralSchedulePart"] = GetMineralSchedulePart(royaltyModel.MineralScheduleId);
                ViewData["MineralName"] = GetMineralName(royaltyModel.MineralSchedulePartId);
                ViewData["MineralUnit"] = GetMineralUnit(royaltyModel.MineralId);
                ViewData["RoyaltyBasis"] = GetRoyaltyBasis(royaltyModel.MineralId);
                ViewData["MineralForm"] = GetMineralForm(royaltyModel.MineralTypeId, royaltyModel.MineralId);
                ViewData["MineralGrade"] = GetMineralGrade(royaltyModel.MineralNatureId);

                ViewBag.Button = "Update";
                return View(royaltyModel);
            }
            else
            {
                ViewBag.Button = "Submit";
                return View(royaltyModel);
            }
        }

        private List<MineralGradeModel> GetMineralCategory()
        {
            mineralGradeModel.CHK = 8;
            listMineralType = mineralGradeMasterModel.View(mineralGradeModel);
            return listMineralType;
        }

        private List<MineralGradeModel> GetCalculationType()
        {
            mineralGradeModel.CHK = 7;
            listMineralType = mineralGradeMasterModel.View(mineralGradeModel);
            return listMineralType;
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

        private List<MineralGradeModel> GetMineralForm(int? MineralTypeId,int? MineralId)
        {
            if ((MineralTypeId != 0 && MineralTypeId != null) && (MineralId != 0 && MineralId != null))
            {
                mineralGradeModel.CHK = 5;
                mineralGradeModel.MineralTypeId = MineralTypeId;
                mineralGradeModel.MineralId = MineralId;
                listMineralType = mineralGradeMasterModel.View(mineralGradeModel);
            }
            else
            {
                listMineralType = null;
            }
            return listMineralType;
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(RoyaltyModel royaltyModel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                if(string.IsNullOrEmpty(royaltyModel.MineralTypeId.ToString()))
                {
                    ModelState.AddModelError("MineralTypeId", "Please Select Mineral Category");
                }
                if (string.IsNullOrEmpty(royaltyModel.MineralScheduleId.ToString()))
                {
                    ModelState.AddModelError("MineralScheduleId", "Please Select Schedule");
                }
                if (string.IsNullOrEmpty(royaltyModel.MineralId.ToString()))
                {
                    ModelState.AddModelError("MineralId", "Please Select Mineral Name");
                }
                
                if (string.IsNullOrEmpty(royaltyModel.UnitId.ToString()))
                {
                    ModelState.AddModelError("UnitId", "Please Select Mineral Unit");
                }
                if (string.IsNullOrEmpty(royaltyModel.RoyaltyRateTypeId.ToString()))
                {
                    ModelState.AddModelError("RoyaltyRateTypeId", "Please Select Royalty Basis");
                }
                if (string.IsNullOrEmpty(royaltyModel.MineralNatureId.ToString()))
                {
                    ModelState.AddModelError("MineralNatureId", "Please Select Mineral Form");
                }
                if (string.IsNullOrEmpty(royaltyModel.MineralGradeId.ToString()))
                {
                    ModelState.AddModelError("MineralGradeId", "Please Select Mineral Grade");
                }
                if (string.IsNullOrEmpty(royaltyModel.CalculationTypeId))
                {
                    ModelState.AddModelError("CalculationTypeId", "Please Select Rate Of Royalty");
                }
                if (string.IsNullOrEmpty(royaltyModel.RoyaltyRate.ToString()))
                {
                    ModelState.AddModelError("RoyaltyRate", "Please Enter Royalty");
                }
                if (string.IsNullOrEmpty(royaltyModel.RateEffectiveFrom))
                {
                    ModelState.AddModelError("RateEffectiveFrom", "Please Enter Rate Effective From");
                }
                if (ModelState.IsValid)
                {
                    royaltyModel.CreatedBy =  profile.UserId;

                    if (submit == "Submit")
                    {
                        messageEF = royaltyMasterModel.Add(royaltyModel);
                    }
                    else
                    {
                        messageEF = royaltyMasterModel.Update(royaltyModel);
                    }
                    if (messageEF.Satus == "1")
                    {
                        TempData["msg"] = "Data Save Sucessfully";
                        return RedirectToAction("ViewList");
                    }
                    else
                    {
                        ViewBag.msg = "Data not Save Sucessfully";
                        ViewData["MineralCategory"] = GetMineralCategory();
                        ViewData["CalculationType"] = GetCalculationType();
                        ViewData["MineralSchedule"] = GetMineralSchedule(royaltyModel.MineralTypeId);
                        ViewData["MineralSchedulePart"] = GetMineralSchedulePart(royaltyModel.MineralScheduleId);
                        ViewData["MineralName"] = GetMineralName(royaltyModel.MineralSchedulePartId);
                        ViewData["MineralUnit"] = GetMineralUnit(royaltyModel.MineralId);
                        ViewData["RoyaltyBasis"] = GetRoyaltyBasis(royaltyModel.MineralId);
                        ViewData["MineralForm"] = GetMineralForm(royaltyModel.MineralTypeId, royaltyModel.MineralId);
                        ViewData["MineralGrade"] = GetMineralGrade(royaltyModel.MineralNatureId);
                        royaltyModel.CalculationTypeName = royaltyModel.CalculationTypeId;
                        return View(royaltyModel);
                    }
                }
                else
                {
                    ViewData["MineralCategory"] = GetMineralCategory();
                    ViewData["CalculationType"] = GetCalculationType();
                    ViewData["MineralSchedule"] = GetMineralSchedule(royaltyModel.MineralTypeId);
                    ViewData["MineralSchedulePart"] = GetMineralSchedulePart(royaltyModel.MineralScheduleId);
                    ViewData["MineralName"] = GetMineralName(royaltyModel.MineralSchedulePartId);
                    ViewData["MineralUnit"] = GetMineralUnit(royaltyModel.MineralId);
                    ViewData["RoyaltyBasis"] = GetRoyaltyBasis(royaltyModel.MineralId);
                    ViewData["MineralForm"] = GetMineralForm(royaltyModel.MineralTypeId, royaltyModel.MineralId);
                    ViewData["MineralGrade"] = GetMineralGrade(royaltyModel.MineralNatureId);
                    royaltyModel.CalculationTypeName = royaltyModel.CalculationTypeId;
                    return View(royaltyModel);
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
            royaltyModel.chk = 1;
            lstroyaltyModels = royaltyMasterModel.View(royaltyModel);
            return View(lstroyaltyModels);
        }

        public JsonResult GetSchedulePartNameByScheduleId(int ScheduleId)
        {
            lstmineralSchedulePartModels=GetMineralSchedulePart(ScheduleId);
            return Json(lstmineralSchedulePartModels);
        }

        private List<MineralSchedulePartModel> GetMineralSchedulePart(int? ScheduleId)
        {
            if (ScheduleId != 0 && ScheduleId != null)
            {
                mineralSchedulePartModel.MineralScheduleId = ScheduleId;
                lstmineralSchedulePartModels = mineralSchedulePartMasterModel.View(mineralSchedulePartModel);
            }
            else
            {
                lstmineralSchedulePartModels = null;
            }
            return lstmineralSchedulePartModels;
        }

        public JsonResult GetMineralNameBySchedulePartId(int? SchedulePartId)
        {
            lstroyaltyModels=GetMineralName(SchedulePartId);
            return Json(lstroyaltyModels);
        }

        private List<RoyaltyModel> GetMineralName(int? SchedulePartId)
        {
            if (SchedulePartId != 0 && SchedulePartId != null)
            {
                royaltyModel.chk = 5;
                royaltyModel.MineralSchedulePartId = SchedulePartId;
                lstroyaltyModels = royaltyMasterModel.View(royaltyModel);
            }
            else
            {
                lstroyaltyModels = null;
            }
            return lstroyaltyModels;
        }

        public JsonResult GetMineralUnitByMineralID(int? MineralID)
        {
            lstroyaltyModels= GetMineralUnit(MineralID);
            return Json(lstroyaltyModels);
        }

        private List<RoyaltyModel> GetMineralUnit(int? MineralID)
        {
            if (MineralID != 0 && MineralID != null)
            {
                royaltyModel.chk = 6;
                royaltyModel.MineralId = MineralID;
                lstroyaltyModels = royaltyMasterModel.View(royaltyModel);
            }
            else
            {
                lstroyaltyModels = null;
            }
            return lstroyaltyModels;
        }

        public JsonResult GetRoyaltyBasisByMineralID(int MineralID)
        {
            lstroyaltyModels=GetRoyaltyBasis(MineralID);
            return Json(lstroyaltyModels);
        }

        private List<RoyaltyModel> GetRoyaltyBasis(int? MineralID)
        {
            if (MineralID != 0 && MineralID != null)
            {
                royaltyModel.chk = 7;
                royaltyModel.MineralId = MineralID;
                lstroyaltyModels = royaltyMasterModel.View(royaltyModel);
            }
            else
            {
                lstroyaltyModels = null;
            }
            return lstroyaltyModels;
        }

        public JsonResult GetRoyaltyMineralGradeByNatureId(int NatureId)
        {
            listMineralType=GetMineralGrade(NatureId);
            return Json(listMineralType);
        }

        private List<MineralGradeModel> GetMineralGrade(int? NatureId)
        {
            if (NatureId != 0 && NatureId != null)
            {
                mineralGradeModel.CHK = 6;
                mineralGradeModel.MineralNatureId = NatureId;
                listMineralType = mineralGradeMasterModel.View(mineralGradeModel);
            }
            else
            {
                listMineralType = null;
            }
            return listMineralType;
        }

        #endregion

        #region Delete 
        [Decryption]
        public IActionResult Delete(string id = "0")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            royaltyModel.CreatedBy = profile.UserId;
            royaltyModel.RoyaltyID = Convert.ToInt32(id);
            messageEF = royaltyMasterModel.Delete(royaltyModel); 
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