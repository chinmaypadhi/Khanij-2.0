// ***********************************************************************
//  Controller Name          : ChecklistController
//  Description              : Add,View,Edit,Update,Delete Checklist Master details
//  Created By               : Lingaraj Dalai
//  Created On               : 25 Dec 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.Checklist;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class ChecklistController : Controller
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        IChecklistModel _objIChecklistModel;
        MessageEF objobjmodel = new MessageEF();
        ChecklistMaster objmodel = new ChecklistMaster();
        List<ChecklistMaster> objlistmodel = new List<ChecklistMaster>();
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objCheckPostmasterModel"></param>
        public ChecklistController(IChecklistModel objIChecklistModel)
        {
            _objIChecklistModel = objIChecklistModel;
        }
        /// <summary>
        /// Get method of Add
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public IActionResult Add(string id = "0")
        {
            try
            {
                if (!string.IsNullOrEmpty(id) && id != "0")
                {
                    objmodel.ChecklistId =Convert.ToInt32(id);
                    objmodel = _objIChecklistModel.Edit(objmodel);
                    ViewBag.Modules = GetModule(objmodel.ModuleID);
                    ViewBag.Button = "Update";
                    return View(objmodel);
                }
                else
                {
                    objmodel.IsActive = true;
                    ViewBag.Modules = GetModule(null);
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
        /// <summary>
        /// Post method of Add
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(ChecklistMaster objmodel, string submit)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserID = profile.UserId;
                if (string.IsNullOrEmpty(objmodel.ModuleID.ToString()))
                {
                    ModelState.AddModelError("ModuleID", "Please Select Module");
                }
                if (string.IsNullOrEmpty(objmodel.CheckListDescription))
                {
                    ModelState.AddModelError("CheckListDescription", "CheckList Description is required");
                }
                if (ModelState.IsValid)
                {
                    if (submit == "Submit")
                    {
                        objobjmodel = _objIChecklistModel.Add(objmodel);
                    }
                    else
                    {
                        objobjmodel = _objIChecklistModel.Update(objmodel);
                    }
                    TempData["Message"] = objobjmodel.Satus;
                    if (submit == "Submit")
                    {
                        objmodel.IsActive = true;
                        return RedirectToAction("Add", "Checklist", new { Area = "master" });
                    }
                    else
                    {
                        return RedirectToAction("Viewlist", "Checklist", new { Area = "master" });
                    }
                }
                else
                {
                    if (objmodel.ChecklistId != 0 || objmodel.ChecklistId != null)
                    {
                        objmodel = _objIChecklistModel.Edit(objmodel);
                        ViewBag.Modules = GetModule(objmodel.ModuleID);
                        ViewBag.Button = "Update";
                        return View(objmodel);
                    }
                    else
                    {
                        objmodel.IsActive = true;
                        ViewBag.Modules = GetModule(null);
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
        /// <summary>
        /// Bind Checklist details in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        public IActionResult ViewList(ChecklistMaster objmodel)
        {
            try
            {
                objlistmodel = _objIChecklistModel.View(objmodel);
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
        /// <summary>
        /// To delete Checklist details in view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public IActionResult Delete(string id = "0")
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserID = (int)profile.UserId;
                objmodel.ChecklistId =Convert.ToInt32(id);
                objobjmodel = _objIChecklistModel.Delete(objmodel);
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
        /// <summary>
        /// Bind Module List details in view
        /// </summary>
        /// <param name="ModuleID"></param>
        /// <returns></returns>
        private SelectList GetModule(int? ModuleID)
        {          
            try
            {
                objlistmodel = _objIChecklistModel.GetModuleList(objmodel);
                return new SelectList(objlistmodel, "ModuleID", "ModuleName", ModuleID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objlistmodel = null;
            }
        }
    }
}
