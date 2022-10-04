using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.MineralGrade;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MasterApp.Master.Controllers
{
    [Area("master")]
    public class MineralGradeController : Controller
    {
        private readonly IMineralGradeMasterModel mineralGradeMasterModel;
        List<MineralGradeModel> listMineralGrade = new List<MineralGradeModel>();
        MineralGradeModel mineralGradeModel = new MineralGradeModel();
        MessageEF objobjmodel = new MessageEF();

        #region Constructor
        public MineralGradeController(IMineralGradeMasterModel mineralGradeMasterModel)
        {
            this.mineralGradeMasterModel = mineralGradeMasterModel;
        }
        #endregion

        #region Add/Update
        [Decryption]
        public IActionResult Add(string id ="0")
        {
            //---------------- 

            ViewData["MineralCategory"] = GetMineralCategory();
            //----------------------
            if (TempData["msg"] != null)
            {
                ViewBag.msg = TempData["msg"].ToString();
            }
            if (!string.IsNullOrEmpty(id) && id !="0" )
            {
                mineralGradeModel.CHK = 0;
                mineralGradeModel.MineralGradeId =Convert.ToInt32(id);
                mineralGradeModel = mineralGradeMasterModel.Edit(mineralGradeModel);
                mineralGradeModel.IsActive = mineralGradeModel.Status == "Active" ? true : false;
                ViewData["MineralName"] = GetMineralNameByMineralCategory(mineralGradeModel.MineralTypeId ?? 0); 
                ViewData["MineralForm"] = GetMineralNatureByMineralTypeAndMineral(mineralGradeModel.MineralTypeId??0, mineralGradeModel.MineralId??0);

                ViewBag.Button = "Update";
                return View(mineralGradeModel);
            }
            else
            {
                mineralGradeModel.IsActive = true;
                ViewBag.Button = "Submit";
                return View(mineralGradeModel);
            }
        }
         
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(MineralGradeModel objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                if (string.IsNullOrEmpty(objmodel.MineralTypeId.ToString()))
                {
                    ModelState.AddModelError("MineralTypeId", "Please Select Mineral Category");
                }
                if (string.IsNullOrEmpty(objmodel.MineralId.ToString()))
                {
                    ModelState.AddModelError("MineralId", "Please Select Mineral Name");
                }
                if (string.IsNullOrEmpty(objmodel.MineralNatureId.ToString()))
                {
                    ModelState.AddModelError("MineralNatureId", "Please Select Mineral Form");
                }

                if (string.IsNullOrEmpty(objmodel.MineralGrade))
                {
                    ModelState.AddModelError("MineralGrade", "Please Enter Mineral Grade");
                }
                if (ModelState.IsValid)
                {
                    objmodel.CreatedBy = profile.UserId;
                    objmodel.UserLoginId = profile.UserLoginId;

                    if (submit == "Submit")
                    {
                        objobjmodel = mineralGradeMasterModel.Add(objmodel);
                    }
                    else
                    {
                        objobjmodel = mineralGradeMasterModel.Update(objmodel);
                    }
                    if (objobjmodel.Satus == "1" && submit== "Submit")
                    {
                        TempData["msg"] = "Data Saved Sucessfully";
                        return RedirectToAction("ViewList");
                    }
                    if (objobjmodel.Satus == "1")
                    {
                        TempData["msg"] = "Data Updated Sucessfully";
                        return RedirectToAction("ViewList");
                    }
                    if (objobjmodel.Satus == "2")
                    {
                        TempData["msg"] = "Mineral Grade Name Already Exists !! ";
                        return RedirectToAction("Add");
                    }
                    else
                    {
                        ViewBag.msg = "Data not Save Sucessfully";
                        ViewData["MineralCategory"] = GetMineralCategory();
                        ViewData["MineralName"] = GetMineralNameByMineralCategory(objmodel.MineralTypeId ?? 0);
                        ViewData["MineralForm"] = GetMineralNatureByMineralTypeAndMineral(mineralGradeModel.MineralTypeId ?? 0, mineralGradeModel.MineralId ?? 0);
                        return View(objmodel);
                    }
                }
                else
                {
                    ViewData["MineralCategory"] = GetMineralCategory();
                    ViewData["MineralName"] = GetMineralNameByMineralCategory(objmodel.MineralTypeId ?? 0);
                    ViewData["MineralForm"] = GetMineralNatureByMineralTypeAndMineral(objmodel.MineralTypeId ?? 0, objmodel.MineralId ?? 0);
                    return View(objmodel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public JsonResult GetMineralMasterDataByMineralTypeId(int? mineralType)
        {
            try
            {
                listMineralGrade = GetMineralNameByMineralCategory(mineralType);
                return Json(listMineralGrade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         
        public JsonResult GetMineralNatureDataByMineralTypeIdAndMineralId(int? mineralType, int? mineralId)
        {

            try
            {
                listMineralGrade= GetMineralNatureByMineralTypeAndMineral(mineralType, mineralId);
                return Json(listMineralGrade);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private List<MineralGradeModel> GetMineralNatureByMineralTypeAndMineral(int? mineralType, int? mineralId)
        {
            if (mineralType != 0 && mineralId != 0)
            {
                mineralGradeModel.CHK = 5;
                mineralGradeModel.MineralTypeId = mineralType;
                mineralGradeModel.MineralId = mineralId;
                listMineralGrade = mineralGradeMasterModel.View(mineralGradeModel);
            }
            else
            {
                listMineralGrade = null;
            }
            return listMineralGrade;
        }

        private List<MineralGradeModel> GetMineralCategory()
        {
            mineralGradeModel.CHK = 8;
            listMineralGrade = mineralGradeMasterModel.View(mineralGradeModel);
            return listMineralGrade;
        }

        private List<MineralGradeModel> GetMineralNameByMineralCategory(int? mineralType)
        {
            if (mineralType != 0)
            {
                mineralGradeModel.CHK = 9;
                mineralGradeModel.MineralTypeId = mineralType;
                listMineralGrade = mineralGradeMasterModel.View(mineralGradeModel);
            }
            else
            {
                listMineralGrade = null;
            }
            return listMineralGrade;
        }
        #endregion

        #region View
        public IActionResult ViewList()
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }

                mineralGradeModel.CHK = 4;
                listMineralGrade = mineralGradeMasterModel.View(mineralGradeModel);
                return View(listMineralGrade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Delete
        [Decryption]
        public IActionResult Delete(string id ="0")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            MineralGradeModel objmodel = new MineralGradeModel();
            mineralGradeModel.CreatedBy = profile.UserId;
            mineralGradeModel.UserLoginId = profile.UserLoginId;
            mineralGradeModel.MineralGradeId = Convert.ToInt32(id);
            objobjmodel = mineralGradeMasterModel.Delete(mineralGradeModel);

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
    }
}