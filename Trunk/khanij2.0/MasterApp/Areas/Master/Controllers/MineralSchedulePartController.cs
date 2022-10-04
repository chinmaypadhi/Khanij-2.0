using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.MineralForm;
using MasterApp.Areas.Master.Models.MineralSchedule;
using MasterApp.Areas.Master.Models.MineralSchedulePart;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class MineralSchedulePartController : Controller
    {
        private readonly IMineralSchedulePartMasterModel mineralSchedulePartMasterModel;
        private readonly IMineralScheduleMasterModel mineralScheduleMasterModel;
        private readonly IMineralFormModel mineralFormModel;
        MessageEF messageEF = new MessageEF();
        MineralScheduleModel mineralScheduleModel = new MineralScheduleModel();
        MineralSchedulePartModel mineralSchedulePartModel = new MineralSchedulePartModel();
        MineralGradeModel mineralGradeModel = new MineralGradeModel();
        List<MineralScheduleModel> lstmineralScheduleModels = new List<MineralScheduleModel>();
        public MineralSchedulePartController(IMineralSchedulePartMasterModel mineralSchedulePartMasterModel,
            IMineralScheduleMasterModel mineralScheduleMasterModel, IMineralFormModel mineralFormModel)
        {
            this.mineralSchedulePartMasterModel = mineralSchedulePartMasterModel;
            this.mineralScheduleMasterModel = mineralScheduleMasterModel;
            this.mineralFormModel = mineralFormModel;
        }
        #region Add
        [Decryption]
        public IActionResult Add(string id = "0")
        {
            ViewData["MineralCategory"] = GetMineralCategory();
            if ( !string.IsNullOrEmpty(id) && id != "0")
            {
                mineralSchedulePartModel.MineralSchedulePartID = Convert.ToInt32(id);
                mineralSchedulePartModel = mineralSchedulePartMasterModel.Edit(mineralSchedulePartModel);
                mineralSchedulePartModel.IsActive = mineralSchedulePartModel.Status == "Active" ? true : false;
                ViewData["MineralSchedule"] = MineralScheduleByCategory(mineralSchedulePartModel.MineralTypeId);
                ViewBag.Button = "Update";
                return View(mineralSchedulePartModel);
            }
            else
            {
                mineralSchedulePartModel.IsActive = true;
                ViewBag.Button = "Submit";
                return View(mineralSchedulePartModel);
            }
        }

        private List<MineralGradeModel> GetMineralCategory()
        {
            List<MineralGradeModel> listMineralType = new List<MineralGradeModel>();
            mineralGradeModel.CHK = 8;
            listMineralType = mineralFormModel.ViewMineralCategory(mineralGradeModel);
            return listMineralType;
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(MineralSchedulePartModel mineralSchedulePartModel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                if (string.IsNullOrEmpty(mineralSchedulePartModel.MineralTypeId.ToString()))
                {
                    ModelState.AddModelError("MineralTypeId", "Please Select Mineral Category");
                }
                if (string.IsNullOrEmpty(mineralSchedulePartModel.MineralScheduleId.ToString()))
                {
                    ModelState.AddModelError("MineralScheduleId", "Please Select Schedule");
                }
                if (string.IsNullOrEmpty(mineralSchedulePartModel.MineralSchedulePartName))
                {
                    ModelState.AddModelError("MineralSchedulePartName", "Please Enter Schedule Part Name");
                }
                if (ModelState.IsValid)
                {
                    mineralSchedulePartModel.CreatedBy = profile.UserId;
                    if (submit == "Submit")
                    {
                        messageEF = mineralSchedulePartMasterModel.Add(mineralSchedulePartModel);
                    }
                    else
                    {
                        messageEF = mineralSchedulePartMasterModel.Update(mineralSchedulePartModel);
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
                    if (messageEF.Satus == "2")
                    {
                        TempData["msg"] = "Schedule Part Name Already Exists !";
                        return RedirectToAction("Add");
                    }
                    else
                    {
                        ViewBag.msg = "Data not Save Sucessfully";
                        ViewData["MineralCategory"] = GetMineralCategory();
                        ViewData["MineralSchedule"] = MineralScheduleByCategory(mineralSchedulePartModel.MineralTypeId);
                        return View(mineralSchedulePartModel);
                    }
                }
                else
                {
                    ViewData["MineralCategory"] = GetMineralCategory();
                    ViewData["MineralSchedule"] = MineralScheduleByCategory(mineralSchedulePartModel.MineralTypeId);
                    return View(mineralSchedulePartModel);
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
            if (TempData["msg"] != null)
            {
                ViewBag.msg = TempData["msg"].ToString();
            }
            List<MineralSchedulePartModel> lstmineralSchedulePartModels = new List<MineralSchedulePartModel>();
            lstmineralSchedulePartModels = mineralSchedulePartMasterModel.View(mineralSchedulePartModel);
            return View(lstmineralSchedulePartModels);
        }

        public JsonResult GetMineralScheduleByCategoryId(int? MineralTypeId)
        {
            MineralScheduleByCategory(MineralTypeId);
            return Json(lstmineralScheduleModels);
        }

        private List<MineralScheduleModel> MineralScheduleByCategory(int? MineralTypeId)
        {
            if (MineralTypeId != null && MineralTypeId != 0)
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
        #endregion

        #region Delete
        [Decryption]
        public IActionResult Delete(string id = "0")
        {

            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            mineralSchedulePartModel.CreatedBy = profile.UserId;
            mineralSchedulePartModel.MineralSchedulePartID = Convert.ToInt32(id);
            messageEF = mineralSchedulePartMasterModel.Delete(mineralSchedulePartModel);

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