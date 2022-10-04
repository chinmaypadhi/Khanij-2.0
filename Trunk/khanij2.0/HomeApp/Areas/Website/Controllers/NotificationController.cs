// ***********************************************************************
//  Controller Name          : NotificationController
//  Desciption               : Add,Select,Update,Delete Website Notification Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 07 Oct 2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeEF;
using HomeApp.Models.Notification;
using HomeApp.Web;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using HomeApp.ActionFilter;

namespace HomeApp.Areas.Website.Controllers
{
    [Area("Website")]
    public class NotificationController : Controller
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        INotificationModel _objNotificationModel;
        MessageEF objobjmodel = new MessageEF();
        AddNotificationModel objAddmodel = new AddNotificationModel();
        ViewNotificationModel objViewmodel = new ViewNotificationModel();
        List<AddNotificationModel> objlistmodel = new List<AddNotificationModel>();
        List<ViewNotificationModel> objlistviewmodel = new List<ViewNotificationModel>();
        string uniqueFileName = string.Empty;
        string filePath = string.Empty;
        string ExtensionId = string.Empty;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objNotificationModel"></param>
        public NotificationController(INotificationModel objNotificationModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _objNotificationModel = objNotificationModel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }
        /// <summary>
        /// HTTP Get Method of Add Notification Details in view
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
                    objAddmodel.INT_NOTIFICATION_ID = Convert.ToInt32(id);
                    objAddmodel = _objNotificationModel.Edit(objAddmodel);
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
                objViewmodel = null;
            }
        }
        /// <summary>
        /// HTTP Post Method of Add Notification Details in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Add(AddNotificationModel objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.INT_CREATED_BY = profile.UserId;
            ExtensionId = Convert.ToString(objmodel.INT_CREATED_BY);
            try
            {
                #region Validation
                if (objmodel.INT_NOTIFICATION_TYPE_ID == null)
                {
                    ModelState.AddModelError("INT_NOTIFICATION_TYPE_ID", "Notification type is required");
                }
                if (string.IsNullOrEmpty(objmodel.VCH_NOTIFICATION_SUB))
                {
                    ModelState.AddModelError("VCH_NOTIFICATION_SUB", "Notification Subject is required");
                }
                if (string.IsNullOrEmpty(objmodel.DTM_PUBLISHED_ON))
                {
                    ModelState.AddModelError("DTM_PUBLISHED_ON", "Publish Date is required");
                }
                if (objmodel.VCH_UPLOAD_FILE == null || objmodel.VCH_UPLOAD_FILE == "")
                {
                    if (objmodel.Notificationfile == null)
                    {
                        ModelState.AddModelError("Notificationfile", "Upload Document");
                    }
                }
                #endregion
                if (ModelState.IsValid)
                {
                    #region File Upload
                    if (objmodel.Notificationfile != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.Notificationfile.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("NotificationPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("NotificationPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.Notificationfile.CopyTo(fileStream);
                        //objmodel.RecoveryReportFileName = uniqueFileName;
                        objmodel.VCH_UPLOAD_FILE = filePath;
                        uniqueFileName = null;
                        filePath = null;
                        objmodel.Notificationfile = null;
                    }
                    #endregion
                    if (submit == "Submit")
                    {
                        objobjmodel = _objNotificationModel.Add(objmodel);
                        TempData["Message"] = objobjmodel.Satus;
                        return RedirectToAction("Add", "Notification", new { Area = "Website" });
                    }
                    else
                    {
                        objobjmodel = _objNotificationModel.Update(objmodel);
                        TempData["Message"] = objobjmodel.Satus;
                        return RedirectToAction("ViewList", "Notification", new { Area = "Website" });
                    }

                }
                else
                {
                    int? id = objmodel.INT_NOTIFICATION_ID;
                    if (id != null)
                    {
                        objAddmodel = _objNotificationModel.Edit(objAddmodel);
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
            }
        }
        /// <summary>
        /// HTTP Get method to bind Notification details data in view
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
                objlistviewmodel = _objNotificationModel.View(objViewmodel);
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
        /// HTTP Get method to bind Notification Archive details data in view
        /// </summary>
        /// <returns></returns>
        public IActionResult Archive()
        {
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                objlistviewmodel = _objNotificationModel.ViewArchive(objViewmodel);
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
        /// Move Notification details to archive in view
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public JsonResult ArchiveMove(string arr)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
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
                        objViewmodel.INT_NOTIFICATION_ID = Convert.ToInt32(id);
                        objobjmodel = _objNotificationModel.Archive(objViewmodel);
                    }
                    OutputResult = objobjmodel.Satus;
                }
            }
            return Json(OutputResult);
        }
        /// <summary>
        /// Delete Notification detials in view
        /// </summary>
        /// <param name="id"></param>
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
                        objViewmodel.INT_NOTIFICATION_ID = Convert.ToInt32(id);
                        objobjmodel = _objNotificationModel.Delete(objViewmodel);
                    }
                    OutputResult = objobjmodel.Satus;
                }
            }
            return Json(OutputResult);
        }
        /// <summary>
        /// Publish Notification details in view
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public JsonResult Publish(string arr)
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
                        objViewmodel.INT_NOTIFICATION_ID = Convert.ToInt32(id);
                        objobjmodel = _objNotificationModel.Publish(objViewmodel);
                    }
                    OutputResult = objobjmodel.Satus;
                }
            }
            return Json(OutputResult);
        }
        /// <summary>
        /// Unpublish Notification details in view
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public JsonResult UnPublish(string arr)
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
                        objViewmodel.INT_NOTIFICATION_ID = Convert.ToInt32(id);
                        objobjmodel = _objNotificationModel.Unpublish(objViewmodel);
                    }
                    OutputResult = objobjmodel.Satus;
                }
            }
            return Json(OutputResult);
        }
        /// <summary>
        /// Active Notification details in view
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public JsonResult Active(string arr)
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
                        objViewmodel.INT_NOTIFICATION_ID = Convert.ToInt32(id);
                        objobjmodel = _objNotificationModel.Active(objViewmodel);
                    }
                    OutputResult = objobjmodel.Satus;
                }
            }
            return Json(OutputResult);
        }
        /// <summary>
        /// To bind Notification Type Dropdown details in view
        /// </summary>
        /// <returns></returns>
        [SkipSessionTask]
        public JsonResult GetNotificationTypeDetails()
        {
            try
            {
                objlistmodel =_objNotificationModel.GetNotificationTypeList(objAddmodel);
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
