// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.Models.MIneral;
using MasterApp.Areas.Master.Models.StateMaster;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Mvc;
using MasterApp.ActionFilter;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class StateController : Controller
    {
        #region Global Declaration
        IStateMasterModel _objStatemasterModel;
        MessageEF objobjmodel = new MessageEF();
        #endregion
        #region Constructor Dependency Injection
        public StateController(IStateMasterModel objStatemasterModel)
        {
            _objStatemasterModel = objStatemasterModel;
        }
        #endregion
        [Decryption]
        public IActionResult Add(string id ="0" )
        {
            Statemaster objmodel = new Statemaster();
            if (!string.IsNullOrEmpty(id) &&  id !="0" )
            {
                objmodel.StateID =Convert.ToInt32(id);
                objmodel = _objStatemasterModel.Edit(objmodel);
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
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(Statemaster objmodel, string submit)
        {
            if (string.IsNullOrEmpty(objmodel.StateName))
            {
                ModelState.AddModelError("StateName", "State Name is required");
            }
            if (ModelState.IsValid)
            {

                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objmodel.CreatedBy = (int)profile.UserId;
                objmodel.UserLoginID = (int)profile.UserLoginId;

                if (submit == "Submit")
                {
                    objobjmodel = _objStatemasterModel.Add(objmodel);
                }
                else
                {
                    objobjmodel = _objStatemasterModel.Update(objmodel);
                }
                if (objobjmodel.Satus == "1")
                {
                    if (submit == "Submit")
                    {
                        TempData["msg"] = "Data Saved Sucessfully";
                    }
                    else
                    {
                        TempData["msg"] = "Data Updated Sucessfully";
                    }

                    return RedirectToAction("ViewList");
                }
                else if(objobjmodel.Satus=="2")
                {
                    TempData["msg"] = "State Name Already Exists !";
                    return RedirectToAction("Add");
                }
                else
                {
                    TempData["msg"] = "Data Not Saved Sucessfully";
                    return View(objmodel);
                }
            }
            return View();

        }
        
        public IActionResult ViewList(Statemaster objmodel)
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"];
                }
                if (TempData["msgDel"] != null)
                {
                    ViewBag.msgDel = TempData["msgDel"];
                }
                ViewBag.ViewList = _objStatemasterModel.View(objmodel);
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        public IActionResult ViewList(Statemaster objmodel,string Show1)
        {
            try
            {
                ViewBag.ViewList = _objStatemasterModel.View(objmodel);
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #region For State Deletion
        [Decryption]
        public IActionResult Delete(string id ="0")
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                Statemaster objmodel = new Statemaster();
                objmodel.CreatedBy = Convert.ToInt32(profile.UserId);
                objmodel.UserLoginID = Convert.ToInt32(profile.UserLoginId);
                objmodel.StateID =Convert.ToInt32(id);

                objobjmodel = _objStatemasterModel.Delete(objmodel);

                if (objobjmodel.Satus == "1")
                {
                    TempData["msgDel"] = "Data Deleted Sucessfully";
                    return RedirectToAction("ViewList");
                }
                else
                {
                    TempData["msgDel"] = "Data not Deleted Sucessfully";
                    return RedirectToAction("ViewList");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion  
    }
}