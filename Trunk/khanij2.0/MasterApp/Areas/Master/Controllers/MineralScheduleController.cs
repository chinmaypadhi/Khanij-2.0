using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.MineralForm;
using MasterApp.Areas.Master.Models.MineralSchedule;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class MineralScheduleController : Controller
    {
        private readonly IMineralScheduleMasterModel mineralScheduleMasterModel;
        private readonly IMineralFormModel mineralFormModel;
        MineralGradeModel mineralGradeModel = new MineralGradeModel();
        MineralScheduleModel mineralScheduleModel = new MineralScheduleModel();
        MessageEF messageEF = new MessageEF();

        #region Constructor
        public MineralScheduleController(IMineralScheduleMasterModel mineralScheduleMasterModel,
            IMineralFormModel mineralFormModel)
        {
            this.mineralScheduleMasterModel = mineralScheduleMasterModel;
            this.mineralFormModel = mineralFormModel;
        }
        #endregion

        #region Add
        [Decryption]
        public IActionResult Add(string id= "0")
        {
           
            ViewData["MineralCategory"] = GetMineralCategory();
            if (!string.IsNullOrEmpty(id) &&  id != "0")
            {
                mineralScheduleModel.MineralScheduleID = Convert.ToInt32(id);
                mineralScheduleModel = mineralScheduleMasterModel.Edit(mineralScheduleModel);
                mineralScheduleModel.IsActive = mineralScheduleModel.Status == "Active" ? true : false;
                ViewBag.Button = "Update";
                return View(mineralScheduleModel);
            }
            else
            {
                mineralScheduleModel.IsActive = true;
                ViewBag.Button = "Submit";
                return View(mineralScheduleModel);
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
        public IActionResult Add(MineralScheduleModel mineralScheduleModel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                if(string.IsNullOrEmpty(mineralScheduleModel.MineralTypeId.ToString()))
                {
                    ModelState.AddModelError("MineralTypeId", "Please Select Mineral Category");
                }
                if (string.IsNullOrEmpty(mineralScheduleModel.MineralScheduleName))
                {
                    ModelState.AddModelError("MineralScheduleName", "Please Enter Mineral Schedule Name");
                }
                if (ModelState.IsValid)
                {
                    mineralScheduleModel.CreatedBy = profile.UserId;
                    if (submit == "Submit")
                    {
                        messageEF = mineralScheduleMasterModel.Add(mineralScheduleModel);
                    }
                    else
                    {
                        messageEF = mineralScheduleMasterModel.Update(mineralScheduleModel);
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
                        ViewData["MineralCategory"] = GetMineralCategory();
                        return View(mineralScheduleModel);
                    }
                }
                else
                {
                    ViewData["MineralCategory"] = GetMineralCategory();
                    return View(mineralScheduleModel);
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
            List<MineralScheduleModel> mineralScheduleModels = new List<MineralScheduleModel>();
            mineralScheduleModels = mineralScheduleMasterModel.View(mineralScheduleModel);
            return View(mineralScheduleModels);
        }
        #endregion

        #region Delete
        [Decryption]
        public IActionResult Delete(string id = "0")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            mineralScheduleModel.CreatedBy = profile.UserId;
            mineralScheduleModel.MineralScheduleID = Convert.ToInt32(id);
            messageEF = mineralScheduleMasterModel.Delete(mineralScheduleModel);

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