// ***********************************************************************
//  Controller Name          : PageController
//  Desciption               : Add,Select,Update,Delete Website Page Details 
//  Created By               : Prakash Chandra Biswal
//  Created On               : 28 Oct 2021
// ***********************************************************************
using HomeEF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeApp.Areas.Website.Models.Page;
using System.IO;
using HomeApp.Web;
using HomeApp.ActionFilter;

namespace HomeApp.Areas.Website.Controllers
{
    [Area("Website")]
    public class PageController : Controller
    {
        /// <summary>
        /// Global Declaration
        /// </summary>
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        IPageModel _ObjPageModel;
        MessageEF messageEF = new MessageEF();
        AddPageModel objAddmodel = new AddPageModel();
        ViewPageModel objViewmodel = new ViewPageModel();
        List<AddPageModel> objlistaddmodel = new List<AddPageModel>();
        List<ViewPageModel> objlistviewmodel = new List<ViewPageModel>();
        string uniqueFileName = string.Empty;
        string filePath = string.Empty;
        string ExtensionId = string.Empty;
        /// <summary>
        /// Constructor Dependency Injection
        /// </summary>
        /// <param name="pageModel"></param>
        /// <param name="hostingEnvironment"></param>
        /// <param name="configuration"></param>
        public PageController(IPageModel pageModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _hostingEnvironment = hostingEnvironment;
            _ObjPageModel = pageModel;
            _configuration = configuration;
        }
        /// <summary>
        /// To Add Page Details
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
                    objAddmodel.INT_PAGE_ID = Convert.ToInt32(id);
                    objAddmodel = _ObjPageModel.Edit(objAddmodel);
                    ViewBag.Button = "Update";
                    return View(objAddmodel);
                }
                else
                {
                    objAddmodel.BIT_STATUS = true;
                    objAddmodel.BIT_LINK_TYPE = true;
                    objAddmodel.BIT_WINDOW_STATUS = true;
                    ViewBag.Button = "Submit";
                    return View(objAddmodel);
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objAddmodel = null;
            }
        }
        [HttpPost]
        public IActionResult Add(AddPageModel objmodel, string submit)
        {
            //objmodel.INT_CREATED_BY = 1;
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objAddmodel.INT_CREATED_BY = profile.UserId;
            if(objAddmodel.INT_PLUGIN_TYPE==0)
            {
                objAddmodel.INT_PLUGIN_TYPE = 9;
            }
              
            ExtensionId = Convert.ToString(objmodel.INT_CREATED_BY);
            try
            {
                #region Validation
                if (string.IsNullOrEmpty(objmodel.VCH_PAGE_NAME))
                {
                    ModelState.AddModelError("VCH_PAGE_NAME", "Page Name");
                }
                if (string.IsNullOrEmpty(objmodel.VCH_PAGE_NAME_ALIAS))
                {
                    ModelState.AddModelError("VCH_PAGE_NAME_ALIAS", "Page Alias");
                }
                if (string.IsNullOrEmpty(objmodel.VCH_PAGE_TITLE))
                {
                    ModelState.AddModelError("VCH_PAGE_TITLE", "Page Title");
                }
                if (string.IsNullOrEmpty(objmodel.VCH_URL))
                {
                    ModelState.AddModelError("VCH_URL", "URL");
                }
                #endregion
                if (ModelState.IsValid)
                {
                    #region File Upload
                    if (objmodel.META_IMG_FILE != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.META_IMG_FILE.FileName);
                        filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("PagePath"), uniqueFileName);
                        var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("PagePath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.META_IMG_FILE.CopyTo(fileStream);
                        //objmodel.RecoveryReportFileName = uniqueFileName;
                        objmodel.VCH_META_IMAGE_NAME = filePath;
                        uniqueFileName = null;
                        filePath = null;
                        objmodel.META_IMG_FILE = null;
                    }

                    if (objmodel.FEATURE_IMAGE_FILE != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.FEATURE_IMAGE_FILE.FileName);
                        filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("PagePath"), uniqueFileName);
                        var RootPath1 = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("PagePath"));
                        string uploadsFolder1 = Path.Combine(RootPath1, uniqueFileName);
                        if (!Directory.Exists(RootPath1))
                            Directory.CreateDirectory(RootPath1);
                        DirectoryInfo di1 = new DirectoryInfo(RootPath1);
                        di1.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder1, FileMode.Create))
                            objmodel.FEATURE_IMAGE_FILE.CopyTo(fileStream);
                        //objmodel.RecoveryReportFileName = uniqueFileName;
                        objmodel.VCH_FEATURE_IMAGE_NAME = filePath;
                        uniqueFileName = null;
                        filePath = null;
                        objmodel.FEATURE_IMAGE_FILE = null;
                    }

                    #endregion
                    if (submit == "Submit")
                    {
                        messageEF = _ObjPageModel.Add(objmodel);
                        objmodel.BIT_STATUS = true;
                        if (messageEF.Satus == "1")
                            TempData["Message"] = messageEF.Satus;
                        else if (messageEF.Satus == "2")
                            TempData["Message"] = messageEF.Satus;
                        return RedirectToAction("Add", "Page", new { Area = "Website" });
                    }
                    else
                    {
                        messageEF = _ObjPageModel.Update(objmodel);
                        if (messageEF.Satus == "1")
                            TempData["Message"] = messageEF.Satus;
                        return RedirectToAction("ViewList", "Page", new { Area = "Website" });
                    }

                }
                else
                {
                    int? id = objmodel.INT_PAGE_ID;
                    if (id != null)
                    {
                        objAddmodel = _ObjPageModel.Edit(objAddmodel);
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
                throw ex;
            }
            finally
            {
                //messageEF = null;
                objmodel = null;
            }
        }
        /// <summary>
        /// To Archive Page
        /// </summary>
        /// <returns></returns>
        public IActionResult Archive()
        {
            try
            {
                if (TempData["Message"] != null)
                {
                    ViewBag.Message = TempData["Message"].ToString();
                }
                objlistviewmodel = _ObjPageModel.ViewArchive(objViewmodel);
                return View(objlistviewmodel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 
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
                objlistviewmodel = await _ObjPageModel.View(objViewmodel);
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
        /// Move Notification details to archive view
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public JsonResult ArchiveMove(string arr)
        {
            // UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
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
                        objViewmodel.INT_CREATED_BY = 1;
                        objViewmodel.INT_PAGE_ID = Convert.ToInt32(id);
                        messageEF = _ObjPageModel.Archive(objViewmodel);
                    }
                    OutputResult = messageEF.Satus;
                }
            }
            return Json(OutputResult);
        }
        /// <summary>
        /// To Bind Plugin Type in dropdown
        /// </summary>
        /// <returns></returns>
        public async Task<JsonResult> GetPluginTypeDetails()
        {
            try
            {
                objlistaddmodel = await _ObjPageModel.PlugnTypeList(objAddmodel);
                return Json(objlistaddmodel);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objAddmodel = null;
                objlistaddmodel = null;
            }
        }
        /// <summary>
        /// To Delete Page
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public JsonResult Delete(string arr)
        {
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
                        objViewmodel.INT_CREATED_BY = 1;
                        objViewmodel.INT_PAGE_ID = Convert.ToInt32(id);
                        messageEF = _ObjPageModel.Delete(objViewmodel);
                    }
                    OutputResult = messageEF.Satus;
                }
            }
            return Json(OutputResult);
        }
        /// <summary>
        /// To active page from Archive
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public JsonResult Active(string arr)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objAddmodel.INT_CREATED_BY = profile.UserId;
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
                        objViewmodel.INT_CREATED_BY = 1;
                        objViewmodel.INT_PAGE_ID = Convert.ToInt32(id);
                        messageEF = _ObjPageModel.Active(objViewmodel);
                    }
                    OutputResult = messageEF.Satus;
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
        public IActionResult DownloadFiles(string filename, string filepath)
        {
            var absolutePath = filename;
            if (filename != null)
            {
                var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("PagePath"));
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
