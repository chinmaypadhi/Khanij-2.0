// ***********************************************************************
//  Controller Name          : UsertypeController
//  Description              : Add,View,Edit,Update,Delete Usertype Master details
//  Created By               : Lingaraj Dalai
//  Created On               : 25 Dec 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.Usertype;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class UsertypeController : Controller
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        IUsertypeModel _objIUsertypeModel;
        MessageEF objobjmodel = new MessageEF();
        UsertypeMaster objmodel = new UsertypeMaster();
        List<UsertypeMaster> objlistmodel = new List<UsertypeMaster>();
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objCheckPostmasterModel"></param>
        public UsertypeController(IUsertypeModel objIUsertypeModel)
        {
            _objIUsertypeModel = objIUsertypeModel;
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
                    objmodel.UsertypeId = Convert.ToInt32(id);
                    objmodel = _objIUsertypeModel.Edit(objmodel);
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
        /// <summary>
        /// Post method of Add
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(UsertypeMaster objmodel, string submit)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.UserID = profile.UserId;
                if (string.IsNullOrEmpty(objmodel.Usertype))
                {
                    ModelState.AddModelError("Usertype", "Usertype is required");
                }
                if (ModelState.IsValid)
                {
                    if (submit == "Submit")
                    {
                        objobjmodel = _objIUsertypeModel.Add(objmodel);
                    }
                    else
                    {
                        objobjmodel = _objIUsertypeModel.Update(objmodel);
                    }
                    TempData["Message"] = objobjmodel.Satus;
                    if (submit == "Submit")
                    {
                        objmodel.IsActive = true;
                        return RedirectToAction("Add", "Usertype", new { Area = "master" });
                    }
                    else
                    {
                        return RedirectToAction("Viewlist", "Usertype", new { Area = "master" });
                    }
                }
                else
                {
                    if (objmodel.UsertypeId != 0 || objmodel.UsertypeId != null)
                    {
                        objmodel = _objIUsertypeModel.Edit(objmodel);
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
        /// <summary>
        /// Bind Usertype details in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        public IActionResult ViewList(UsertypeMaster objmodel)
        {
            try
            {
                objlistmodel = _objIUsertypeModel.View(objmodel);
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
        /// To delete Usertype details in view
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
                objmodel.UsertypeId =Convert.ToInt32(id);
                objobjmodel = _objIUsertypeModel.Delete(objmodel);
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
