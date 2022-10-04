using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.MineralForm;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class MineralFormController : Controller
    {
        private readonly IMineralFormModel mineralFormModel;
        List<MineralNatureModel> listMineralNatureModel = new List<MineralNatureModel>();
        List<MineralGradeModel> listMineralType = new List<MineralGradeModel>();
        MineralNatureModel mineralNatureModel = new MineralNatureModel();
        MineralGradeModel mineralGradeModel = new MineralGradeModel();
        MessageEF messageEF = new MessageEF();

        #region Constructor 
        public MineralFormController(IMineralFormModel mineralFormModel)
        {
            this.mineralFormModel = mineralFormModel;
        }
        #endregion

        #region Add/Update
        [Decryption]
        public IActionResult Add(string id ="0")
        {
            ViewData["MineralCategory"] = GetMineralCategory(mineralGradeModel); 
            if (!string.IsNullOrEmpty(id) && id !="0" )
            {
                mineralNatureModel.MineralNatureId = Convert.ToInt32(id);
                mineralNatureModel = mineralFormModel.Edit(mineralNatureModel);
                mineralNatureModel.IsActive = mineralNatureModel.Status == "Active" ? true : false; 
                ViewData["MineralName"] = GetMineralName(mineralNatureModel);
                ViewBag.Button = "Update";
                return View(mineralNatureModel);
            }
            else
            {
                mineralNatureModel.IsActive = true;
                ViewBag.Button = "Submit";
                return View(mineralNatureModel);
            } 
        }

        private List<MineralGradeModel> GetMineralName(MineralNatureModel mineralNatureModel)
        {
            if (mineralNatureModel.MineralTypeId != 0 && mineralNatureModel.MineralTypeId != null)
            {
                mineralGradeModel.CHK = 9;
                mineralGradeModel.MineralTypeId = mineralNatureModel.MineralTypeId;
                listMineralType = mineralFormModel.ViewMineralCategory(mineralGradeModel);
            }
            else
            {
                listMineralType = null;
            }
            return listMineralType;
        }

        private List<MineralGradeModel> GetMineralCategory(MineralGradeModel mineralGradeModel)
        {
            mineralGradeModel.CHK = 8;
            listMineralType = mineralFormModel.ViewMineralCategory(mineralGradeModel);
            return listMineralType;
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(MineralNatureModel mineralNatureModel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                if (string.IsNullOrEmpty(mineralNatureModel.MineralTypeId.ToString()))
                {
                    ModelState.AddModelError("MineralTypeId", "Please Select Mineral Category");
                }
                if (string.IsNullOrEmpty(mineralNatureModel.MineralId.ToString()))
                {
                    ModelState.AddModelError("MineralId", "Please Select Mineral Name");
                } 

                if (string.IsNullOrEmpty(mineralNatureModel.MineralNature))
                {
                    ModelState.AddModelError("MineralNature", "Please Enter Mineral Form");
                }
                if (ModelState.IsValid)
                {
                    mineralNatureModel.CreatedBy = profile.UserId;
                    if (submit == "Submit")
                    {
                        messageEF = mineralFormModel.Add(mineralNatureModel);
                    }
                    else
                    {
                        messageEF = mineralFormModel.Update(mineralNatureModel);
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
                    else if(messageEF.Satus == "2")
                    {
                        TempData["msg"] = "Mineral Form Name Already Exists !!";
                        return RedirectToAction("Add");
                    }
                    else
                    {
                        ViewData["MineralCategory"] = GetMineralCategory(mineralGradeModel);
                        ViewBag.msg = "Data not Save Sucessfully";
                        return View(mineralNatureModel);
                    }
                }
                else
                {
                    ViewData["MineralCategory"] = GetMineralCategory(mineralGradeModel);
                    ViewData["MineralName"] = GetMineralName(mineralNatureModel);
                    return View(mineralNatureModel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region View
        [HttpGet]
        public IActionResult ViewList()
        {
            try
            { 
                if (TempData["msg"]!=null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }

                listMineralNatureModel = mineralFormModel.View(mineralNatureModel);
                return View(listMineralNatureModel);
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
        #endregion

        #region Delete
        [Decryption]
        public IActionResult Delete(string id ="0" )
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey); 
            mineralNatureModel.CreatedBy = profile.UserId;
            mineralNatureModel.MineralNatureId = Convert.ToInt32(id);
            messageEF = mineralFormModel.Delete(mineralNatureModel);

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