// ***********************************************************************
//  Controller Name          : UserProfileController
//  Desciption               : Add,View,Edit,Update,Delete Website Banner Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 05 Nov 2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeEF;
using HomeApp.Areas.Website.Models.UserProfile;
using HomeApp.Web;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using HomeApp.ActionFilter;

namespace HomeApp.Areas.Website.Controllers
{
    [Area("Website")]
    public class UserProfileController : Controller
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        IUserProfileModel _objIUserProfileModel;
        MessageEF objobjmodel = new MessageEF();
        AddUserProfileModel objAddmodel = new AddUserProfileModel();
        ViewUserProfileModel objViewmodel = new ViewUserProfileModel();
        List<AddUserProfileModel> objlistmodel = new List<AddUserProfileModel>();
        List<ViewUserProfileModel> objlistviewmodel = new List<ViewUserProfileModel>();
        string uniqueFileName = string.Empty;
        string filePath = string.Empty;
        string ExtensionId = string.Empty;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objNotificationModel"></param>
        public UserProfileController(IUserProfileModel objIUserProfileModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _objIUserProfileModel = objIUserProfileModel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }
        /// <summary>
        /// HTTP Get Method of Add Banner Details in view
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
                    objAddmodel.INT_UPROFILE_ID = Convert.ToInt32(id);
                    objAddmodel = _objIUserProfileModel.Edit(objAddmodel);
                    ViewBag.Button = "Update";
                    return View(objAddmodel);
                }
                else
                {
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
            }
        }
        /// <summary>
        /// HTTP Post Method of Add Banner Details in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Add(AddUserProfileModel objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.INT_CREATED_BY = profile.UserId;
            ExtensionId = Convert.ToString(objmodel.INT_CREATED_BY);
            AddUserProfileModel objAddUserProfileModel = new AddUserProfileModel();
            try
            {
                #region Validation
                if (string.IsNullOrEmpty(objmodel.VCH_NAME))
                {
                    ModelState.AddModelError("VCH_NAME", "Name Field is required");
                }
                if (string.IsNullOrEmpty(objmodel.VCH_DESIGNATION))
                {
                    ModelState.AddModelError("VCH_DESIGNATION", "Designation Field is required");
                }
                if (string.IsNullOrEmpty(objmodel.VCH_DEPARTMENT))
                {
                    ModelState.AddModelError("VCH_DEPARTMENT", "Department Field is required");
                }
                //if (objmodel.VCH_PHOTO_PATH == null || objmodel.VCH_PHOTO_PATH == "")
                //{
                //    if (objmodel.Photo == null)
                //    {
                //        ModelState.AddModelError("Photo", "Upload Photo");
                //    }
                //}
                if (string.IsNullOrEmpty(objmodel.VCH_EMAIL_ID))
                {
                    ModelState.AddModelError("VCH_EMAIL_ID", "Email Id Field is required");
                }
                if (string.IsNullOrEmpty(objmodel.VCH_USER_ID))
                {
                    ModelState.AddModelError("VCH_USER_ID", "User Id Field is required");
                }
                if (string.IsNullOrEmpty(objmodel.VCH_PASSWORD))
                {
                    ModelState.AddModelError("VCH_PASSWORD", "Password Field is required");
                }
                if (string.IsNullOrEmpty(objmodel.VCH_CONF_PASSWORD))
                {
                    ModelState.AddModelError("VCH_CONF_PASSWORD", "Confirm Password Field is required");
                }
                if (objmodel.VCH_PASSWORD != objmodel.VCH_CONF_PASSWORD)
                {
                    ModelState.AddModelError("VCH_CONF_PASSWORD", "Password & Confirm Password does not match");
                }
                #endregion
                if (ModelState.IsValid)
                {
                    #region File Upload
                    if (objmodel.Photo != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.Photo.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UserProfilePath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UserProfilePath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.Photo.CopyTo(fileStream);
                        objmodel.VCH_PHOTO_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                        objmodel.Photo = null;
                    }
                    #endregion
                    if (submit == "Submit")
                    {
                        objobjmodel = _objIUserProfileModel.Add(objmodel);
                        TempData["Message"] = objobjmodel.Satus;
                        return RedirectToAction("Add", "UserProfile", new { Area = "Website" });
                    }
                    else
                    {
                        objobjmodel = _objIUserProfileModel.Update(objmodel);
                        TempData["Message"] = objobjmodel.Satus;
                        return RedirectToAction("ViewList", "UserProfile", new { Area = "Website" });
                    }

                }
                else
                {
                    int? id = objmodel.INT_UPROFILE_ID;
                    if (id != null)
                    {
                        objAddmodel = _objIUserProfileModel.Edit(objAddmodel);
                        ViewBag.Button = "Update";
                    }
                    else
                    {
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
                objAddUserProfileModel = null;
            }
        }
        /// <summary>
        /// HTTP Get method to bind Banner details data in view
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
                objlistviewmodel = _objIUserProfileModel.View(objViewmodel);
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
        /// Delete User Profile details in view
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public JsonResult Delete(string arr)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            List<int> list = new List<int>();
            string OutputResult = "";
            if (!string.IsNullOrEmpty(arr.ToString()))
            {
                string[] multiArray = arr.Split(new Char[] { ' ', ',', '.', '-', '\n', '\t', '[', ']', '"' });
                string abc = arr.Remove(0, 1);
                string xyz = abc.Remove(abc.Length - 1, 1);
                foreach (string id in multiArray)
                {
                    if (id.Trim() != "" && id.Trim() != "on")
                    {
                        objViewmodel.INT_CREATED_BY = profile.UserId;
                        objViewmodel.INT_UPROFILE_ID = Convert.ToInt32(id);
                        objobjmodel = _objIUserProfileModel.Delete(objViewmodel);
                    }
                    OutputResult = objobjmodel.Satus;
                }
            }
            return Json(OutputResult);
        }
    }
}
