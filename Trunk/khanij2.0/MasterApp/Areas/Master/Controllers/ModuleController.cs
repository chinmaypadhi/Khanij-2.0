// ***********************************************************************
//  Controller Name          : ModuleController
//  Description              : Add,View,Edit,Update,Delete Module Master details
//  Created By               : Prakash Chandra Biswal
//  Created On               : 27 Dec 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MasterApp.Areas.Master.Models.Module;
using MasterEF;
using MasterApp.Web;
using MasterApp.ActionFilter;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class ModuleController : Controller
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        IModuleModel _objIModuleModel;
        MessageEF objobjmodel = new MessageEF();
        ModuleMasterModel objmodel = new ModuleMasterModel();
        List<ModuleMasterModel> objlistmodel = new List<ModuleMasterModel>();
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="moduleModel"></param>
        public ModuleController(IModuleModel moduleModel)
        {
            _objIModuleModel = moduleModel;
        }
        [Decryption]
        public IActionResult Add(string id = "0")
        {
            try
            {
                if (!string.IsNullOrEmpty(id) && id != "0")
                {
                    objmodel.ModuleId = Convert.ToInt32(id);
                    objmodel = _objIModuleModel.Edit(objmodel);
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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objmodel = null;
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(ModuleMasterModel objmodel, string submit)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserID = profile.UserId;
                objmodel.UserLoginID = profile.UserLoginId;
               
                if (ModelState.IsValid)
                {
                    if (submit == "Submit")
                    {
                        objobjmodel = _objIModuleModel.Add(objmodel);
                    }
                    else
                    {
                        objobjmodel = _objIModuleModel.Update(objmodel);
                    }
                    TempData["Message"] = objobjmodel.Satus;
                    if (submit == "Submit")
                    {
                        objmodel.IsActive = true;
                        return RedirectToAction("Add", "Module", new { Area = "master" });
                    }
                    else
                    {
                        return RedirectToAction("Viewlist", "Module", new { Area = "master" });
                    }
                }
                else
                {
                    if (objmodel.ModuleId != 0 || objmodel.ModuleId != null)
                    {
                        objmodel = _objIModuleModel.Edit(objmodel);
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objmodel = null;
            }
        }
        public IActionResult ViewList(ModuleMasterModel objmodel)
        {
            try
            {
                objlistmodel = _objIModuleModel.View(objmodel);
                return View(objlistmodel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objlistmodel = null;
                objmodel = null;
            }
        }

        [Decryption]
        public IActionResult Delete(string id = "0")
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserID = (int)profile.UserId;
                objmodel.UserLoginID = profile.UserLoginId;
                objmodel.ModuleId = Convert.ToInt32(id);
                objobjmodel = _objIModuleModel.Delete(objmodel);
                TempData["Message"] = objobjmodel.Satus;
                return RedirectToAction("ViewList");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objmodel = null;
            }
        }
    }
}