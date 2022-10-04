// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 25-Jan-2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using MasterApp.ActionFilter;
using MasterApp.Areas.Master.Models.Transparncy;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class TransparncyController : Controller
    {
        #region Global Declartion
        ITransparncyModel _objTransparncymasterModel;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        string uniqueFileName = string.Empty;
        string filePath = string.Empty;
        string ExtensionId = string.Empty;
        MessageEF objobjmodel = new MessageEF();
        #endregion
        #region Constructor Dependency Injection
        public TransparncyController(ITransparncyModel objTransparncymasterModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
            _objTransparncymasterModel = objTransparncymasterModel;
        }
        #endregion

        [Decryption]
        public IActionResult Add(string id = "0")
        {
            Transparncymaster objmodel = new Transparncymaster();
            if (!string.IsNullOrEmpty(id) && id != "0")
            {
                objmodel.DNId = Convert.ToInt32(id);
                objmodel = _objTransparncymasterModel.Edit(objmodel);
                ViewBag.Button = "Update";
                return View(objmodel);
            }
            else
            {
                objmodel.IsActive = true;
                objmodel.IsPublished= true;
                ViewBag.Button = "Submit";
                return View(objmodel);
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(Transparncymaster objmodel, string submit, IFormFile selectedFile)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.CREATED_BY = profile.UserId;

            //if (string.IsNullOrEmpty(objmodel.NoticeText))
            //{
            //    ModelState.AddModelError("NoticeText", "Notice Text is required");
            //}
            if (ModelState.IsValid)
            {
                #region Upload File 

                if (selectedFile != null && selectedFile.Length > 0)
                {
                    if (!string.IsNullOrEmpty(selectedFile.FileName))
                    {
                        string hosting = _hostingEnvironment.ContentRootPath;
                        string wwwPath = this._hostingEnvironment.WebRootPath;
                        string strName = DateTime.Now.Date.Day.ToString() + DateTime.Now.Date.Month.ToString() + DateTime.Now.Date.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                        var fileName = strName + "_" + selectedFile.FileName;
                        filePath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("TransparancyNoticePath"), fileName);
                        var RootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration.GetSection("Path").GetValue<string>("TransparancyNoticePath"));
                        string UploadFolderPath = Path.Combine(RootPath, fileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var stream = new FileStream(UploadFolderPath, FileMode.Create))
                        {
                            selectedFile.CopyTo(stream);
                        }
                        objmodel.NoticeFilePath = filePath;
                        objmodel.NoticeFileName = fileName;
                        //string imageurlpath = "http://khanijmasterapp.khanij.com" + filePath;
                        string NoticeImgPath = Path.Combine(_configuration.GetSection("Path").GetValue<string>("NoticeImagePath") + filePath);
                        objmodel.ImageUrlPath = NoticeImgPath;
                    }

                }
                #endregion
                if (submit == "Submit")
                {
                    objobjmodel = _objTransparncymasterModel.Add(objmodel);
                }
                else
                {
                    objobjmodel = _objTransparncymasterModel.Update(objmodel);
                }
                if (objobjmodel.Satus == "1" && submit == "Submit")
                {
                    objmodel.IsActive = true;
                    TempData["msg"] = "Transparncy Portal Notice Saved Sucessfully";
                    objmodel.NoticeText = "";
                    ModelState.Clear();
                    return RedirectToAction("Viewlist", "Transparncy", new { Area = "master" });
                }
                if (objobjmodel.Satus == "1")
                {
                    TempData["msg"] = "Transparncy Portal Notice Updated Sucessfully";
                    return RedirectToAction("Viewlist", "Transparncy", new { Area = "master" });
                }
                if (objobjmodel.Satus == "3")
                {
                    ViewBag.msg = "Transparncy Portal Notice Already Exist!";
                    ViewBag.Button = objmodel.DNId > 0 ? "Update" : "Submit";
                    return View(objmodel);
                }
                else
                {
                    ViewBag.msg = "Data not Saved Sucessfully";
                    ViewBag.Button = objmodel.DNId > 0 ? "Update" : "Submit";
                    return View(objmodel);
                }
            }
            else
            {
                ViewBag.Button = objmodel.DNId > 0 ? "Update" : "Submit";
                return View(objmodel);
            }
        }
        public IActionResult ViewList(Transparncymaster objmodel)
        {
            try
            {
                if(TempData["msg"]!=null)
                {
                    ViewBag.msg = TempData["msg"];
                }
                ViewBag.ViewList = _objTransparncymasterModel.View(objmodel);
                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost]
        
        public IActionResult ViewList(Transparncymaster objmodel, string Show1)
        {
            try
            {
                ViewBag.ViewList = _objTransparncymasterModel.View(objmodel);
                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [Decryption]
        public IActionResult Delete(string id = "0")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            Transparncymaster objmodel = new Transparncymaster();
            objmodel.CREATED_BY = profile.UserId;
            objmodel.DNId = Convert.ToInt32(id);
            objmodel.isDelete = true;
            objobjmodel = _objTransparncymasterModel.Delete(objmodel);
            if (objobjmodel.Satus == "1")
            {
                TempData["msg"] = "Transparncy Portal Notice Deleted Sucessfully";
                return RedirectToAction("ViewList");
            }
            else
            {
                TempData["msg"] = "Data not Deleted Sucessfully";
                return RedirectToAction("ViewList");
            }
        }
    }
}