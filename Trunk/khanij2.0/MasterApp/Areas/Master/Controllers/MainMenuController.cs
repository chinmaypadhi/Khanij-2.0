using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.MainMenu;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class MainMenuController : Controller
    {
        private readonly IMainMenuMasterModel mainMenuMasterModel;
        MainMenuMaster mainMenuMaster = new MainMenuMaster();
        List<MainMenuMaster> listMainMenuMaster = new List<MainMenuMaster>();
        MessageEF messageEF = new MessageEF();

        public MainMenuController(IMainMenuMasterModel mainMenuMasterModel)
        {
            this.mainMenuMasterModel = mainMenuMasterModel;
        }


        /// <summary>
        /// Get Main Menu By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public IActionResult Add(string id = "0")
        {
            ModuleMasterModel moduleMasterModel = new ModuleMasterModel();
            ViewData["ModuleDetails"] = mainMenuMasterModel.ViewModuleDetails(moduleMasterModel);
            if (!string.IsNullOrEmpty(id) && id != "0")
            {
                mainMenuMaster.MmenuID = Convert.ToInt32(id);
                mainMenuMaster = mainMenuMasterModel.EditMainMenu(mainMenuMaster);
                mainMenuMaster.IsActive = mainMenuMaster.Status == "Active" ? true : false;
                ViewBag.Button = "Update";
                return View(mainMenuMaster);
            }
            else
            {
                mainMenuMaster.IsActive = true;
                ViewBag.Button = "Submit";
                return View(mainMenuMaster);
            }
        }

        /// <summary>
        /// Save Main Menu Details
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(MainMenuMaster objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {

                if (string.IsNullOrEmpty(objmodel.MainMenuName))
                {
                    ModelState.AddModelError("MainMenuName", "Please Enter MainMenu Name");
                }
                if (string.IsNullOrEmpty(objmodel.ModuleId.ToString()))
                {
                    ModelState.AddModelError("ModuleId", "Please Select Module");
                }
                if (string.IsNullOrEmpty(objmodel.icon))
                {
                    ModelState.AddModelError("icon", "Please Enter icon");
                }
                if (string.IsNullOrEmpty(objmodel.LinkPath))
                {
                    ModelState.AddModelError("LinkPath", "Please Enter Link Path");
                }
                if (string.IsNullOrEmpty(objmodel.Slno.ToString()))
                {
                    ModelState.AddModelError("Slno", "Please Enter Slno");
                }
                if (ModelState.IsValid)
                {
                    objmodel.CreatedBy = profile.UserId;

                    if (submit == "Submit")
                    {
                        messageEF = mainMenuMasterModel.AddMainMenu(objmodel);
                    }
                    else
                    {
                        messageEF = mainMenuMasterModel.UpdateMainMenu(objmodel);
                    }
                    if (messageEF.Satus == "1")
                    {
                        TempData["msg"] = "Data Save Sucessfully";
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
        /// View Main Menu Details
        /// </summary>
        /// <param name="mainMenuMaster"></param>
        /// <returns></returns>

        public IActionResult ViewList(MainMenuMaster mainMenuMaster)
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }

                listMainMenuMaster = mainMenuMasterModel.ViewMainMenu(mainMenuMaster);
                return View(listMainMenuMaster);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Delete Main Menu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public IActionResult Delete(string id = "0")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            mainMenuMaster.CreatedBy = profile.UserId;
            mainMenuMaster.MmenuID = Convert.ToInt32(id);
            messageEF = mainMenuMasterModel.DeleteMainMenu(mainMenuMaster);

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
