using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.MineralSize;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class MineralSizeController : Controller
    {
        private readonly IMineralSizeMasterModel mineralSizeMasterModel;
        MineralSizeMaster mineralSizeMaster = new MineralSizeMaster();
        List<MineralSizeMaster> listMineralSizeMaster = new List<MineralSizeMaster>();
        MessageEF messageEF = new MessageEF();

        public MineralSizeController(IMineralSizeMasterModel mineralSizeMasterModel)
        {
            this.mineralSizeMasterModel = mineralSizeMasterModel;
        }

        /// <summary>
        /// Get Mineral Size By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public IActionResult Add(string id = "0")
        {
            if (!string.IsNullOrEmpty(id) && id != "0")
            {
                mineralSizeMaster.MineralSizeId = Convert.ToInt32(id);
                mineralSizeMaster = mineralSizeMasterModel.EditMineralSize(mineralSizeMaster);
                mineralSizeMaster.IsActive = mineralSizeMaster.Status == "Active" ? true : false;
                ViewBag.Button = "Update";
                return View(mineralSizeMaster);
            }
            else
            {


                mineralSizeMaster.IsActive = true;
                ViewBag.Button = "Submit";
                return View(mineralSizeMaster);
            }
        }

        /// <summary>
        /// Save Mineral Size Details
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(MineralSizeMaster objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {

                if (string.IsNullOrEmpty(objmodel.MineralSize))
                {
                    ModelState.AddModelError("MineralSize", "Please Enter Mineral Size");
                }
                if (ModelState.IsValid)
                {
                    objmodel.CreatedBy = profile.UserId;

                    if (submit == "Submit")
                    {
                        messageEF = mineralSizeMasterModel.AddMineralSize(objmodel);
                    }
                    else
                    {
                        messageEF = mineralSizeMasterModel.UpdateMineralSize(objmodel);
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
                        return View(objmodel);
                    }
                }
                else
                {
                    return View(objmodel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// View Mineral Size Details
        /// </summary>
        /// <param name="mineralSizeMaster"></param>
        /// <returns></returns>

        public IActionResult ViewList(MineralSizeMaster mineralSizeMaster)
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }

                listMineralSizeMaster = mineralSizeMasterModel.ViewMineralSize(mineralSizeMaster);
                return View(listMineralSizeMaster);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete Mineral Size
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public IActionResult Delete(string id = "0")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            mineralSizeMaster.CreatedBy = profile.UserId;
            mineralSizeMaster.MineralSizeId = Convert.ToInt32(id);
            messageEF = mineralSizeMasterModel.DeleteMineralSize(mineralSizeMaster);

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
    }
}
