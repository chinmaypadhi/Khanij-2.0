// ***********************************************************************
//  Controller Name          : AddFileController
//  Desciption               : Add other files to Assessment of Lessee 
//  Created By               : Lingaraj Dalai
//  Created On               : 30 April 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using StarratingApp.Areas.Starrating.Models.AddFile;
using StarratingEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace StarratingApp.Areas.Starrating.Controllers
{
    [Area("Starrating")]
    public class AddFileController : Controller
    {
        #region Gobal variable and object declaration
        /// <summary>
        /// Gobal variable and object declaration
        /// </summary>
        private readonly IAddFileModel _objAddFileModel;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        MessageEF objobjmodel;
        AddFilemaster objmodel;
        string uniqueFileName = null;
        string filePath = null;
        #endregion
        #region Constructor declaration
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objAddFileModel"></param>
        /// <param name="hostingEnvironment"></param>
        public AddFileController(IAddFileModel objAddFileModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _objAddFileModel = objAddFileModel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }
        #endregion
        #region Add files
        /// <summary>
        /// GET method of Add
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Add(UploadDocument objmodel, int id = 0)
        {
            objobjmodel = new MessageEF();
            try
            {
                if (id != 0)
                {
                    objmodel.AssesmentID = id;
                    ViewBag.AssesmentID = id;
                    return View(objmodel);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objmodel = null;
                objobjmodel = null;
            }
        }
        /// <summary>
        /// POST method of Add
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Add(UploadDocument objModel)
        {
            objmodel = new AddFilemaster();
            objobjmodel = new MessageEF();
            int id = objModel.AssesmentID;
            try
            {
                #region Validation
                if (string.IsNullOrEmpty(objModel.OtherName))
                {
                    ModelState.AddModelError("OtherName", "Title Name field is required");
                }
                if (objModel.file == null)
                {
                    ModelState.AddModelError("file", "Upload File");
                }
                #endregion
                if (ModelState.IsValid)
                {
                    #region File Upload
                    if (objModel.file != null)
                    {
                        foreach (IFormFile file in objModel.file)
                        {
                            uniqueFileName = Path.GetFileName(file.FileName);
                            filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadFilePath"), uniqueFileName);
                            var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadFilePath"));                          
                            if (!Directory.Exists(RootPath))
                                Directory.CreateDirectory(RootPath);
                            DirectoryInfo di = new DirectoryInfo(RootPath);
                            di.Attributes = FileAttributes.Normal;
                            objmodel.AssesmentID = objModel.AssesmentID;
                            objmodel.FileExtension = file.FileName;
                            objmodel.OtherName = objModel.OtherName;
                            objobjmodel = _objAddFileModel.Add(objmodel);
                            string uploadsFolder = Path.Combine(RootPath, objobjmodel.Msg);
                            using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                                file.CopyTo(fileStream);
                            uniqueFileName = null;
                            filePath = null;
                        }
                    }
                    #endregion
                    TempData["msg"] = objobjmodel.Satus;
                    return RedirectToAction("ViewList", "AddFile", new { id = objmodel.AssesmentID });
                }
                else
                {
                    objModel.AssesmentID = id;
                    ViewBag.AssesmentID = id;
                    return View(objModel);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objmodel = null;
                objModel = null;
                objobjmodel = null;
            }
        }
        #endregion
        #region View files
        /// <summary>
        /// GET method of Viewlist
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult ViewList(int id = 0)
        {
            objmodel = new AddFilemaster();
            List<AddFilemaster> lstAssessmentListmaster = new List<AddFilemaster>();
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                objmodel.AssesmentID = id;
                ViewBag.AssesmentID = id;
                lstAssessmentListmaster = _objAddFileModel.View(objmodel);
                ViewBag.ViewList = lstAssessmentListmaster;
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                lstAssessmentListmaster = null;
                objmodel = null;
            }
        }
        #endregion
    }
}
