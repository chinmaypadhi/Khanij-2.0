// ***********************************************************************
//  Controller Name          : MenuController
//  Desciption               : To Add,Edit,Update,Delete Menu master details
//  Created By               : Lingaraj Dalai
//  Created On               : 29 Jan 2021

//  Updated BY               : Kumar jeevan jyoti
//  Updated Date             : 28-Jun-2021
//  Description              : Add Domen in page add try catch 
// ***********************************************************************
using System;
using System.Collections.Generic;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.Menu;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class MenuController : Controller
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        IMenuModel _objMenumasterModel;
        MessageEF objobjmodel = new MessageEF();
        Menumaster objmodel = new Menumaster();
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objMenuProvider"></param>
        public MenuController(IMenuModel objMenumasterModel)
        {
            _objMenumasterModel = objMenumasterModel;
        }
        /// <summary>
        /// GET method of Add to bind data in view
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
                    objmodel.MenuId = Convert.ToInt32(id);
                    objmodel = _objMenumasterModel.Edit(objmodel);
                    ViewBag.Parentmenu = GetParentmenu(objmodel.ParentId);
                    ViewBag.Button = "Update";
                    return View(objmodel);
                }
                else
                {
                    objmodel.IsActive = true;
                    ViewBag.Parentmenu = GetParentmenu(null);
                    ViewBag.Button = "Submit";
                    return View(objmodel);
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                objmodel = null;
            }
        }
        /// <summary>
        /// POST method of Add to submit data
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(Menumaster objmodel, string submit)
        {
            
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.CreatedBy =profile.UserId;
                if (string.IsNullOrEmpty(objmodel.MenuName))
                {
                    ModelState.AddModelError("MenuName", "Menu Name is required");
                }
                if (!string.IsNullOrEmpty(objmodel.MenuName) && (objmodel.MenuName.Length > 50))
                {
                    ModelState.AddModelError("MenuName", "Menu Name must be less than 50 characters");
                }
                if (string.IsNullOrEmpty(objmodel.MmenuID.ToString()) || objmodel.MmenuID.ToString() == "0")
                {
                    ModelState.AddModelError("MmenuID", "Please Select Parent Menu");
                    ViewBag.Parentmenu = GetParentmenu(null);
                }
                if (string.IsNullOrEmpty(objmodel.Area))
                {
                    ModelState.AddModelError("Area", "Area Name is required");
                }
                if (!string.IsNullOrEmpty(objmodel.Area) && (objmodel.Area.Length > 50))
                {
                    ModelState.AddModelError("Area", "Area Name must be less than 50 characters");
                }
                if (string.IsNullOrEmpty(objmodel.Controller))
                {
                    ModelState.AddModelError("Controller", "Controller Name is required");
                }
                if (!string.IsNullOrEmpty(objmodel.Controller) && (objmodel.Controller.Length > 50))
                {
                    ModelState.AddModelError("Controller", "Controller Name must be less than 50 characters");
                }
                if (string.IsNullOrEmpty(objmodel.ActionName))
                {
                    ModelState.AddModelError("ActionName", "Action Name is required");
                }
                if (!string.IsNullOrEmpty(objmodel.ActionName) && (objmodel.ActionName.Length > 50))
                {
                    ModelState.AddModelError("ActionName", "Action Name must be less than 50 characters");
                }
                if (string.IsNullOrEmpty(objmodel.url))
                {
                    ModelState.AddModelError("ActionName", "URL is required");
                }
                objmodel.ParentId = objmodel.MmenuID;
                if (submit == "Submit")
                {
                    objobjmodel = _objMenumasterModel.Add(objmodel);
                }
                else
                {
                    objobjmodel = _objMenumasterModel.Update(objmodel);
                }
                if (ModelState.IsValid)
                {
                    if (objobjmodel.Satus == "1" && submit == "Submit")
                    {
                        objmodel.IsActive = true;
                        TempData["msg"] = "Menu Saved Sucessfully";
                        objmodel.MenuName = "";
                        ModelState.Clear();
                        return RedirectToAction("Add", "Menu", new { Area = "master" });
                    }
                    if (objobjmodel.Satus == "1")
                    {
                        TempData["msg"] = "Menu Updated Sucessfully";
                        return RedirectToAction("Viewlist", "Menu", new { Area = "master" });
                    }
                    if (objobjmodel.Satus == "3")
                    {
                        ViewBag.msg = "Menu Already Exist!";
                        ViewBag.Parentmenu = GetParentmenu(null);
                        ViewBag.Button = objmodel.MenuId > 0 ? "Update" : "Submit";
                        return View(objmodel);
                    }
                    else
                    {
                        ViewBag.msg = "Data not Saved Sucessfully";
                        ViewBag.Parentmenu = GetParentmenu(null);
                        ViewBag.Button = objmodel.MenuId > 0 ? "Update" : "Submit";
                        return View(objmodel);
                    }
                }
                else
                {
                    ViewBag.Parentmenu = GetParentmenu(null);
                    ViewBag.Button = objmodel.MenuId > 0 ? "Update" : "Submit";
                    return View();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objmodel = null;
                objobjmodel = null;
            }
        }

        /// <summary>
        /// To Bind the Menu Details Data in View
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        public IActionResult ViewList(Menumaster objmodel)
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                ViewBag.ViewList = _objMenumasterModel.View(objmodel);
                return View();
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
        /// To search the Menu Details Data in View
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="Show1"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult ViewList(Menumaster objmodel, string Show1)
        {
            try
            {
                ViewBag.ViewList = _objMenumasterModel.View(objmodel);
                return View();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objmodel = null;
            }
        }

        /// <summary>
        /// To Delete the Menu Details Data in View
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public IActionResult Delete(string id = "0")
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.CreatedBy = profile.UserId;
                objmodel.MenuId = Convert.ToInt32(id);
                objobjmodel = _objMenumasterModel.Delete(objmodel);
                if (objobjmodel.Satus == "1")
                {
                    TempData["msg"] = "Menu Deleted Sucessfully";
                    return RedirectToAction("ViewList");
                }
                else
                {
                    TempData["msg"] = "Data not Deleted Sucessfully";
                    return RedirectToAction("ViewList");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objmodel = null;
                objobjmodel = null;
            }
        }

        /// <summary>
        /// To Bind the Parent Menu Details Data in View
        /// </summary>
        /// <param name="ParentID"></param>
        /// <returns></returns>
        private SelectList GetParentmenu(int? ParentID)
        {
            MainMenuMaster mainMenuMaster = new MainMenuMaster();
            List<MainMenuMaster> listParentMenuResult = new List<MainMenuMaster>();
            try
            {               
                listParentMenuResult = _objMenumasterModel.GetMainMenuList(mainMenuMaster);
                return new SelectList(listParentMenuResult, "MmenuID", "MainMenuName", ParentID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                listParentMenuResult = null;
            }
        }
    }
}