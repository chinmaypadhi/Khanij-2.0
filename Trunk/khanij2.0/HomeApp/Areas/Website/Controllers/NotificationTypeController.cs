// ***********************************************************************
//  Controller Name          : NotificationTypeController
//  Desciption               : Add,Select,Update,Delete Website Notification Type Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 12 Oct 2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HomeEF;
using HomeApp.Areas.Website.Models.NotificationType;
using HomeApp.Web;
using Microsoft.AspNetCore.Hosting;
using HomeApp.ActionFilter;

namespace HomeApp.Areas.Website.Controllers
{
    [Area("Website")]
    public class NotificationTypeController : Controller
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;
        INotificationTypeModel _objNotificationTypeModel;
        MessageEF objobjmodel = new MessageEF();
        AddNotificationTypeModel objAddmodel = new AddNotificationTypeModel();
        ViewNotificationTypeModel objViewmodel = new ViewNotificationTypeModel();
        List<ViewNotificationTypeModel> objlistviewmodel = new List<ViewNotificationTypeModel>();
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objNotificationModel"></param>
        public NotificationTypeController(INotificationTypeModel objNotificationTypeModel, IHostingEnvironment hostingEnvironment)
        {
            _objNotificationTypeModel = objNotificationTypeModel;
            this.hostingEnvironment = hostingEnvironment;
        }
        /// <summary>
        /// HTTP Get Method of Add Notification Type Details in view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public IActionResult Add(string id = "0")
        {
            try
            {
                if (Convert.ToInt32(id) != 0)
                {
                    objAddmodel.INT_NOTIFICATION_TYPE_ID = Convert.ToInt32(id);
                    objAddmodel = _objNotificationTypeModel.Edit(objAddmodel);
                    ViewBag.Button = "Update";
                    return View(objAddmodel);
                }
                else
                {
                    objAddmodel.BIT_STATUS = true;
                    ViewBag.Button = "Submit";
                    return View(objAddmodel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objAddmodel = null;
                objViewmodel = null;
            }
        }
        /// <summary>
        /// HTTP Post Method of Add Notification Type Details in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Add(AddNotificationTypeModel objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.INT_CREATED_BY = profile.UserId;
            try
            {
                #region Validation
                if (string.IsNullOrEmpty(objmodel.VCH_NOTIFICATION_NAME))
                {
                    ModelState.AddModelError("VCH_NOTIFICATION_NAME", "Notification Type Type Name is required");
                }
                if (string.IsNullOrEmpty(objmodel.VCH_NOTIFICATION_DESC))
                {
                    ModelState.AddModelError("VCH_NOTIFICATION_DESC", "Notification Type Desc is required");
                }              
                #endregion
                if (ModelState.IsValid)
                {                  
                    if (submit == "Submit")
                    {
                        objobjmodel = _objNotificationTypeModel.Add(objmodel);
                        objmodel.BIT_STATUS = true;
                        TempData["Message"] = objobjmodel.Satus;
                        return RedirectToAction("Add", "NotificationType", new { Area = "Website" });
                    }
                    else
                    {
                        objobjmodel = _objNotificationTypeModel.Update(objmodel);
                        TempData["Message"] = objobjmodel.Satus;
                        return RedirectToAction("ViewList", "NotificationType", new { Area = "Website" });
                    }

                }
                else
                {
                    int? id = objmodel.INT_NOTIFICATION_TYPE_ID;
                    if (id != null)
                    {
                        objAddmodel = _objNotificationTypeModel.Edit(objAddmodel);
                        ViewBag.Button = "Update";
                    }
                    else
                    {
                        objAddmodel.BIT_STATUS = true;
                        ViewBag.Button = "Submit";
                    }
                    return View(objAddmodel);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objobjmodel = null;
                objmodel = null;
            }
        }
        /// <summary>
        /// HTTP Get method to bind Notification Type details data in view
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ViewList()
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                objlistviewmodel = await _objNotificationTypeModel.View(objViewmodel);
                return View(objlistviewmodel);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objViewmodel = null;
                objlistviewmodel = null;
            }
        }
        /// <summary>
        /// Delete Notification Type details in view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public IActionResult Delete(string id = "0")
        {
            try
            { 
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objViewmodel.INT_CREATED_BY = profile.UserId;
            objViewmodel.INT_NOTIFICATION_TYPE_ID = Convert.ToInt32(id);
            objobjmodel = _objNotificationTypeModel.Delete(objViewmodel);
            TempData["Message"] = objobjmodel.Satus;
            return RedirectToAction("ViewList", "NotificationType", new { Area = "Website" });
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objViewmodel = null;
            }
        }
    }
}
