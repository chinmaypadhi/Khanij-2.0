// ***********************************************************************
//  Controller Name          : StaffDirectoryController
//  Desciption               : Add,Select,Update,Delete Website Staff Directory Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 20 Oct 2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeEF;
using HomeApp.Areas.Website.Models.StaffDirectory;
using HomeApp.Web;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using HomeApp.ActionFilter;

namespace HomeApp.Areas.Website.Controllers
{
    [Area("Website")]
    public class StaffDirectoryController : Controller
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        IStaffDirectoryModel _objIStaffDirectoryModel;
        MessageEF objobjmodel = new MessageEF();
        AddStaffDirectoryModel objAddmodel = new AddStaffDirectoryModel();
        ViewStaffDirectoryModel objViewmodel = new ViewStaffDirectoryModel();
        List<AddStaffDirectoryModel> objlistmodel = new List<AddStaffDirectoryModel>();
        List<ViewStaffDirectoryModel> objlistviewmodel = new List<ViewStaffDirectoryModel>();
        string uniqueFileName = string.Empty;
        string filePath = string.Empty;
        string ExtensionId = string.Empty;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objNotificationModel"></param>
        public StaffDirectoryController(IStaffDirectoryModel objIStaffDirectoryModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _objIStaffDirectoryModel = objIStaffDirectoryModel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }
        /// <summary>
        /// HTTP Get Method of Add Staff Directory Details in view
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
                    objAddmodel.INT_STAFFDIR_ID = Convert.ToInt32(id);
                    objAddmodel = _objIStaffDirectoryModel.Edit(objAddmodel);
                    ViewBag.Button = "Update";
                    return View(objAddmodel);
                }
                else
                {
                    ViewBag.Button = "Submit";
                    objAddmodel.BIT_STATUS = true;
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
        /// HTTP Post Method of Add Staff Directory Details in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Add(AddStaffDirectoryModel objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.INT_CREATED_BY = profile.UserId;
            ExtensionId = Convert.ToString(objmodel.INT_CREATED_BY);
            try
            {
                #region Validation
                if (objmodel.INT_OFFICE_TYPE_ID == null)
                {
                    ModelState.AddModelError("INT_OFFICE_TYPE_ID", "Department Type Field is required");
                }
                if (string.IsNullOrEmpty(objmodel.VCH_OFFICER_NAME))
                {
                    ModelState.AddModelError("VCH_OFFICER_NAME", "Officer Name Field is required");
                }
                //if (string.IsNullOrEmpty(objmodel.VCH_OFFICER_DESIG))
                //{
                //    ModelState.AddModelError("VCH_OFFICER_DESIG", "Officer Designation Field is required");
                //}
                if (string.IsNullOrEmpty(objmodel.VCH_PHONE_NO))
                {
                    ModelState.AddModelError("VCH_PHONE_NO", "Phone No Field is required");
                }
                //if (string.IsNullOrEmpty(objmodel.VCH_EMAIL))
                //{
                //    ModelState.AddModelError("VCH_EMAIL", "Email Field is required");
                //}
                if (objmodel.INT_OFFICE_TYPE_ID == 3 && string.IsNullOrEmpty(objmodel.VCH_LOCATION))
                {
                    ModelState.AddModelError("VCH_LOCATION", "Location Field is required");
                }
                #endregion
                if (ModelState.IsValid)
                {                   
                    if (submit == "Submit")
                    {
                        objobjmodel = _objIStaffDirectoryModel.Add(objmodel);
                        objmodel.BIT_STATUS = true;
                        TempData["Message"] = objobjmodel.Satus;
                        return RedirectToAction("Add", "StaffDirectory", new { Area = "Website" });
                    }
                    else
                    {
                        objobjmodel = _objIStaffDirectoryModel.Update(objmodel);
                        TempData["Message"] = objobjmodel.Satus;
                        return RedirectToAction("ViewList", "StaffDirectory", new { Area = "Website" });
                    }
                }
                else
                {
                    int? id = objmodel.INT_STAFFDIR_ID;
                    if (id != null)
                    {
                        objAddmodel = _objIStaffDirectoryModel.Edit(objAddmodel);
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
        /// HTTP Get method to bind Staff Directory details data in view
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewList()
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                objlistviewmodel = _objIStaffDirectoryModel.View(objViewmodel);
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
        /// Delete Staff Directory detials in view
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
            objViewmodel.INT_STAFFDIR_ID = Convert.ToInt32(id);
            objobjmodel = _objIStaffDirectoryModel.Delete(objViewmodel);
            TempData["Message"] = objobjmodel.Satus;
            return RedirectToAction("ViewList", "StaffDirectory", new { Area = "Website" });
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
        /// <summary>
        /// To bind Staff Directory Type Dropdown details in view
        /// </summary>
        /// <returns></returns>
        public JsonResult GetOfficeTypeDetails()
        {
            try
            {
                objlistmodel =  _objIStaffDirectoryModel.GetOfficeTypeList(objAddmodel);
                return Json(objlistmodel);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objAddmodel = null;
                objlistmodel = null;
            }
        }
    }
}
