// ***********************************************************************
//  Controller Name          : GalleryController
//  Desciption               : Add,View,Edit,Update,Delete Website Gallery Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 28 Oct 2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeEF;
using HomeApp.Areas.Website.Models.Gallery;
using HomeApp.Web;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using HomeApp.ActionFilter;

namespace HomeApp.Areas.Website.Controllers
{
    [Area("Website")]
    public class GalleryController : Controller
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        IGalleryModel _objIGalleryModel;
        MessageEF objobjmodel = new MessageEF();
        AddGalleryModel objAddmodel = new AddGalleryModel();
        ViewGalleryModel objViewmodel = new ViewGalleryModel();
        List<AddGalleryModel> objlistmodel = new List<AddGalleryModel>();
        List<ViewGalleryModel> objlistviewmodel = new List<ViewGalleryModel>();
        string uniqueFileName = string.Empty;
        string filePath = string.Empty;
        string ExtensionId = string.Empty;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objIGalleryModel"></param>
        /// <param name="hostingEnvironment"></param>
        /// <param name="configuration"></param>
        public GalleryController(IGalleryModel objIGalleryModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _objIGalleryModel = objIGalleryModel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }
        /// <summary>
        /// HTTP Get Method of Add Gallery Details in view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public IActionResult Add(string id = "0")
        {
            AddGalleryModel objaddbannermodel = new AddGalleryModel();
            try
            {
                if (Convert.ToInt32(id) != 0)
                {
                    objAddmodel.INT_GALLERY_ID = Convert.ToInt32(id);
                    objAddmodel = _objIGalleryModel.Edit(objAddmodel);
                    ViewBag.Button = "Update";
                    return View(objAddmodel);
                }
                else
                {
                    objaddbannermodel = _objIGalleryModel.GetSequence(objAddmodel);
                    objAddmodel.INT_SEQUENCE = objaddbannermodel.INT_SEQUENCE;
                    objAddmodel.BIT_STATUS = false;
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
        /// HTTP Post Method of Add Gallery Details in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Add(AddGalleryModel objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.INT_CREATED_BY = profile.UserId;
            ExtensionId = Convert.ToString(objmodel.INT_CREATED_BY);
            AddGalleryModel objaddbannermodel = new AddGalleryModel();
            try
            {
                #region Validation
                if (objmodel.INT_CONTENT_TYPE == null)
                {
                    ModelState.AddModelError("INT_CONTENT_TYPE", "Content Type Field is required");
                }
                if (objmodel.INT_CONTENT_TYPE == 1 && objmodel.VCH_THUMBNAIL_IMG_PATH == null || objmodel.VCH_THUMBNAIL_IMG_PATH == "")
                {
                    if (objmodel.ThumbnailImgFile == null)
                    {
                        ModelState.AddModelError("ThumbnailImgFile", "Upload Thumbnail Image");
                    }
                }
                if (objmodel.INT_CONTENT_TYPE == 1 && objmodel.VCH_IMG_PATH == null || objmodel.VCH_IMG_PATH == "")
                {
                    if (objmodel.ImgFile == null)
                    {
                        ModelState.AddModelError("ImgFile", "Upload Image");
                    }
                }
                if (objmodel.INT_CONTENT_TYPE == 1 && string.IsNullOrEmpty(objmodel.VCH_GALLERY_DESC))
                {
                    ModelState.AddModelError("VCH_GALLERY_DESC", "Gallery Description Field is required");
                }
                if (objmodel.INT_CONTENT_TYPE == 2 && objmodel.VCH_VIDEO_PATH == null || objmodel.VCH_VIDEO_PATH == "")
                {
                    if (objmodel.VideoFile == null)
                    {
                        ModelState.AddModelError("VideoFile", "Upload Video");
                    }
                }
                if (objmodel.INT_CONTENT_TYPE == 2 && objmodel.VCH_THUMBNAIL_VIDEOIMG_PATH == null || objmodel.VCH_THUMBNAIL_VIDEOIMG_PATH == "")
                {
                    if (objmodel.ThumbnailVideoImgFile == null)
                    {
                        ModelState.AddModelError("ThumbnailVideoImgFile", "Upload Thumbnail Video");
                    }
                }                
                #endregion
                if (ModelState.IsValid)
                {
                    #region File Upload
                    if (objmodel.ThumbnailImgFile != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.ThumbnailImgFile.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("PhotoGalleryPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("PhotoGalleryPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.ThumbnailImgFile.CopyTo(fileStream);
                        objmodel.VCH_THUMBNAIL_IMG_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.ImgFile != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.ImgFile.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("PhotoGalleryPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("PhotoGalleryPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.ImgFile.CopyTo(fileStream);
                        objmodel.VCH_IMG_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.VideoFile != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.VideoFile.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("VideoGalleryPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("VideoGalleryPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.VideoFile.CopyTo(fileStream);
                        objmodel.VCH_VIDEO_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    if (objmodel.ThumbnailVideoImgFile != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.ThumbnailVideoImgFile.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("VideoGalleryPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("VideoGalleryPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.ThumbnailVideoImgFile.CopyTo(fileStream);
                        objmodel.VCH_THUMBNAIL_VIDEOIMG_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                    }
                    objmodel.ThumbnailImgFile = null;
                    objmodel.ImgFile = null;
                    objmodel.VideoFile = null;
                    objmodel.ThumbnailVideoImgFile = null;
                    #endregion
                    if (submit == "Submit")
                    {
                        objobjmodel = _objIGalleryModel.Add(objmodel);
                        objmodel.BIT_STATUS = false;
                        TempData["Message"] = objobjmodel.Satus;
                        return RedirectToAction("Add", "Gallery", new { Area = "Website" });
                    }
                    else
                    {
                        objobjmodel = _objIGalleryModel.Update(objmodel);
                        TempData["Message"] = objobjmodel.Satus;
                        return RedirectToAction("ViewList", "Gallery", new { Area = "Website" });
                    }

                }
                else
                {

                    int? id = objmodel.INT_GALLERY_ID;
                    if (id != null)
                    {
                        objAddmodel = _objIGalleryModel.Edit(objAddmodel);
                        ViewBag.Button = "Update";
                    }
                    else
                    {
                        objaddbannermodel = _objIGalleryModel.GetSequence(objAddmodel);
                        objAddmodel.INT_SEQUENCE = objaddbannermodel.INT_SEQUENCE;
                        objAddmodel.BIT_STATUS = false;
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
        /// HTTP Get method to bind Gallery details data in view
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
                objlistviewmodel = _objIGalleryModel.View(objViewmodel);
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
        /// HTTP Get method to bind Gallery Archive details data in view
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
                objlistviewmodel = _objIGalleryModel.ViewArchive(objViewmodel);
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
        /// Move Gallery details to archive in view
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
                        objViewmodel.INT_GALLERY_ID = Convert.ToInt32(id);
                        objobjmodel = _objIGalleryModel.Archive(objViewmodel);
                    }
                    OutputResult = objobjmodel.Satus;
                }
            }
            return Json(OutputResult);
        }
        /// <summary>
        /// Delete Gallery details in view
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
                        objViewmodel.INT_GALLERY_ID = Convert.ToInt32(id);
                        objobjmodel = _objIGalleryModel.Delete(objViewmodel);
                    }
                    OutputResult = objobjmodel.Satus;
                }
            }
            return Json(OutputResult);
        }
        /// <summary>
        /// Publish Gallery details in view
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
                        objViewmodel.INT_GALLERY_ID = Convert.ToInt32(id);
                        objobjmodel = _objIGalleryModel.Publish(objViewmodel);
                    }
                    OutputResult = objobjmodel.Satus;
                }
            }
            return Json(OutputResult);
        }
        /// <summary>
        /// Unpublish Gallery details in view
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
                        objViewmodel.INT_GALLERY_ID = Convert.ToInt32(id);
                        objobjmodel = _objIGalleryModel.Unpublish(objViewmodel);
                    }
                    OutputResult = objobjmodel.Satus;
                }
            }
            return Json(OutputResult);
        }
        /// <summary>
        /// Active Gallery details in view
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
                        objViewmodel.INT_GALLERY_ID = Convert.ToInt32(id);
                        objobjmodel = _objIGalleryModel.Active(objViewmodel);
                    }
                    OutputResult = objobjmodel.Satus;
                }
            }
            return Json(OutputResult);
        }
        /// <summary>
        /// Added by Lingaraj on 06-May-2022 to download files
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="foldername"></param>
        /// <returns></returns>
        public IActionResult DownloadImgFiles(string filename, string filepath)
        {
            var absolutePath = filename;
            if (filename != null)
            {
                var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("PhotoGalleryPath"));
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
        /// <summary>
        /// Added by Lingaraj on 06-May-2022 to download files
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="foldername"></param>
        /// <returns></returns>
        public IActionResult DownloadVideoFiles(string filename, string filepath)
        {
            var absolutePath = filename;
            if (filename != null)
            {
                var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("VideoGalleryPath"));
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
