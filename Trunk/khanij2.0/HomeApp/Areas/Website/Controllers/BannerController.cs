// ***********************************************************************
//  Controller Name          : BannerController
//  Desciption               : Add,View,Edit,Update,Delete Website Banner Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 22 Oct 2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeEF;
using HomeApp.Areas.Website.Models.Banner;
using HomeApp.Web;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using HomeApp.ActionFilter;

namespace HomeApp.Areas.Website.Controllers
{
    [Area("Website")]
    public class BannerController : Controller
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        IBannerModel _objIBannerModel;
        MessageEF objobjmodel = new MessageEF();
        AddBannerModel objAddmodel = new AddBannerModel();
        ViewBannerModel objViewmodel = new ViewBannerModel();
        List<AddBannerModel> objlistmodel = new List<AddBannerModel>();
        List<ViewBannerModel> objlistviewmodel = new List<ViewBannerModel>();
        string uniqueFileName = string.Empty;
        string filePath = string.Empty;
        string ExtensionId = string.Empty;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objNotificationModel"></param>
        public BannerController(IBannerModel objIBannerModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _objIBannerModel = objIBannerModel;
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
            AddBannerModel objaddbannermodel = new AddBannerModel();
            try
            {
                if (Convert.ToInt32(id) != 0)
                {
                    objAddmodel.INT_BANNER_ID = Convert.ToInt32(id);
                    objAddmodel = _objIBannerModel.Edit(objAddmodel);
                    ViewBag.Button = "Update";
                    return View(objAddmodel);
                }
                else
                {                    
                    objaddbannermodel= _objIBannerModel.GetSequence(objAddmodel);
                    objAddmodel.INT_SEQUENCE = objaddbannermodel.INT_SEQUENCE;
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
                objaddbannermodel = null;
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
        public IActionResult Add(AddBannerModel objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.INT_CREATED_BY = profile.UserId;
            ExtensionId = Convert.ToString(objmodel.INT_CREATED_BY);
            AddBannerModel objaddbannermodel = new AddBannerModel();
            try
            {
                #region Validation
                if (string.IsNullOrEmpty(objmodel.VCH_DESCRIPTION))
                {
                    ModelState.AddModelError("VCH_DESCRIPTION", "Banner Description Field is required");
                }
                if (objmodel.VCH_DESKTOP_DOCUMENT == null || objmodel.VCH_DESKTOP_DOCUMENT == "")
                {
                    if (objmodel.DesktopDocument == null)
                    {
                        ModelState.AddModelError("DesktopDocument", "Upload Desktop Document");
                    }
                }
                if (objmodel.VCH_MOBILE_DOCUMENT == null || objmodel.VCH_MOBILE_DOCUMENT == "")
                {
                    if (objmodel.MobileDocument == null)
                    {
                        ModelState.AddModelError("Document", "Upload Mobile Document");
                    }
                }
                #endregion
                if (ModelState.IsValid)
                {
                    #region File Upload
                    if (objmodel.DesktopDocument != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.DesktopDocument.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("BannerPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("BannerPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.DesktopDocument.CopyTo(fileStream);
                        objmodel.VCH_DESKTOP_DOCUMENT = filePath;
                        uniqueFileName = null;
                        filePath = null;
                        objmodel.DesktopDocument = null;
                    }
                    if (objmodel.MobileDocument != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.MobileDocument.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("BannerPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("BannerPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.MobileDocument.CopyTo(fileStream);
                        objmodel.VCH_MOBILE_DOCUMENT = filePath;
                        uniqueFileName = null;
                        filePath = null;
                        objmodel.MobileDocument = null;
                    }
                    #endregion
                    if (submit == "Submit")
                    {
                        objobjmodel = _objIBannerModel.Add(objmodel);
                        TempData["Message"] = objobjmodel.Satus;
                        return RedirectToAction("Add", "Banner", new { Area = "Website" });
                    }
                    else
                    {
                        objobjmodel = _objIBannerModel.Update(objmodel);
                        TempData["Message"] = objobjmodel.Satus;
                        return RedirectToAction("ViewList", "Banner", new { Area = "Website" });
                    }

                }
                else
                {
                    
                    int? id = objmodel.INT_BANNER_ID;
                    if (id != null)
                    {
                        objAddmodel = _objIBannerModel.Edit(objAddmodel);
                        ViewBag.Button = "Update";
                    }
                    else
                    {
                        objaddbannermodel = _objIBannerModel.GetSequence(objAddmodel);
                        objAddmodel.INT_SEQUENCE = objaddbannermodel.INT_SEQUENCE;
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
                objaddbannermodel = null;
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
                objlistviewmodel =  _objIBannerModel.View(objViewmodel);
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
        /// HTTP Get method to bind Banner Archive details data in view
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
                objlistviewmodel = _objIBannerModel.ViewArchive(objViewmodel);
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
        /// Move Banner details to archive in view
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
                        objViewmodel.INT_BANNER_ID = Convert.ToInt32(id);
                        objobjmodel = _objIBannerModel.Archive(objViewmodel);
                    }
                    OutputResult = objobjmodel.Satus;
                }
            }
            return Json(OutputResult);
        }
        /// <summary>
        /// Delete Banner detials in view
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
                        objViewmodel.INT_BANNER_ID = Convert.ToInt32(id);
                        objobjmodel = _objIBannerModel.Delete(objViewmodel);
                    }
                    OutputResult = objobjmodel.Satus;
                }
            }
            return Json(OutputResult);
        }
        /// <summary>
        /// Publish Banner details in view
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
                        objViewmodel.INT_BANNER_ID = Convert.ToInt32(id);
                        objobjmodel = _objIBannerModel.Publish(objViewmodel);
                    }
                    OutputResult = objobjmodel.Satus;
                }
            }
            return Json(OutputResult);
        }
        /// <summary>
        /// Unpublish Banner details in view
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
                        objViewmodel.INT_BANNER_ID = Convert.ToInt32(id);
                        objobjmodel = _objIBannerModel.Unpublish(objViewmodel);
                    }
                    OutputResult = objobjmodel.Satus;
                }
            }
            return Json(OutputResult);
        }
        /// <summary>
        /// Active Banner details in view
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
                        objViewmodel.INT_BANNER_ID = Convert.ToInt32(id);
                        objobjmodel = _objIBannerModel.Active(objViewmodel);
                    }
                    OutputResult = objobjmodel.Satus;
                }
            }
            return Json(OutputResult);
        }
        /// <summary>
        /// To Update Status as Active/InActive in view
        /// </summary>
        /// <param name="BannerId"></param>
        /// <param name="BitStatus"></param>
        /// <returns></returns>
        public JsonResult StatusUpdate(int BannerId,bool BitStatus)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objAddmodel.INT_CREATED_BY = profile.UserId;
                objAddmodel.INT_BANNER_ID = BannerId;
                objAddmodel.BIT_STATUS = BitStatus;
                objAddmodel.VCH_DESKTOP_DOCUMENT = null;
                objAddmodel.VCH_MOBILE_DOCUMENT = null;
                objobjmodel = _objIBannerModel.UpdateStatus(objAddmodel);
                return Json(objobjmodel.Satus);
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
        /// Added by Lingaraj on 06-May-2022 to download files
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="foldername"></param>
        /// <returns></returns>
        public IActionResult DownloadFiles(string filename, string filepath)
        {
            var absolutePath = filename;
            if (filename != null)
            {
                var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("BannerPath"));
                if (filepath == null)
                    filepath = Path.Combine(RootPath, filename);
                if (System.IO.File.Exists(filepath))
                {
                    return File(new FileStream(filepath, FileMode.Open), "application/octetstream", filename);
                }
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}
