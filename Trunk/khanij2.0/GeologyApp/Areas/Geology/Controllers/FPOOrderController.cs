// ***********************************************************************
//  Controller Name          : FPOOrderController
//  Desciption               : Add,View,Edit,Update Field Program Order
//  Created By               : Lingaraj Dalai
//  Created On               : 12 Feb 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using GeologyApp.Models.FPO;
using GeologyEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using GeologyApp.Web;
using GeologyApp.ActionFilter;

namespace GeologyApp.Controllers
{
    [Area("Geology")]
    public class FPOOrderController : Controller
    {
        /// <summary>
        /// Global object and variable declaration
        /// </summary>
        IFPOModel _objFPOMasterModel;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        MessageEF objobjmodel = new MessageEF();
        FPOOrdermaster fpomaster = new FPOOrdermaster();
        string uniqueFileName = null;
        string filePath = null;
        string ExtensionId = string.Empty;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objFieldReportStatusMasterModel"></param>
        /// <param name="objInspectionReportMasterModel"></param>
        /// <param name="hostingEnvironment"></param>
        public FPOOrderController(IFPOModel objFPOMasterModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _objFPOMasterModel = objFPOMasterModel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }
        /// <summary>
        /// GET method of Field Program Order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public IActionResult Add(string id = "0")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                if (id != "0")
                {
                    fpomaster.FPO_Id = Convert.ToInt32(id);
                    fpomaster = _objFPOMasterModel.Edit(fpomaster);
                    ViewBag.Button = "Update";
                    return View(fpomaster);
                }
                else
                {
                    fpomaster.IsActive = true;
                    ViewBag.Button = "Submit";
                    return View(fpomaster);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                fpomaster = null;
            }
        }
        /// <summary>
        /// POST methd of Field Program Order
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Add(FPOOrdermaster objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            try
            {
                objmodel.CreatedBy = profile.UserId;
                objmodel.UserLoginId = profile.UserLoginId;
                ExtensionId = Convert.ToString(objmodel.CreatedBy);
                #region Validation
                if (string.IsNullOrEmpty(objmodel.FPO_Code))
                {
                    ModelState.AddModelError("FPO_Code", "Field Program Order field is required");
                }
                if (string.IsNullOrEmpty(objmodel.FPO_Name))
                {
                    ModelState.AddModelError("FPO_Name", "Field Program Order Name field is required");
                }
                if (string.IsNullOrEmpty(objmodel.DateOfIssuance))
                {
                    ModelState.AddModelError("DateOfIssuance", "Date Of Issuance field is required");
                }
                if (objmodel.Year == null)
                {
                    ModelState.AddModelError("Year", "Field Season is required");
                }
                if (objmodel.FPO_File == null || objmodel.FPO_File == "")
                {
                    if (objmodel.FPO_copy == null)
                    {
                        ModelState.AddModelError("FPO_copy", "Upload Field Program Order");
                    }
                }
                #endregion
                if (ModelState.IsValid)
                {
                    #region File Upload
                    if (objmodel.FPO_copy != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.FPO_copy.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadFPOPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadFPOPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.FPO_copy.CopyTo(fileStream);
                        objmodel.FPO_Creater_File = uniqueFileName;
                        objmodel.FPO_Creater_Path = filePath;
                        objmodel.FPO_copy = null;
                    }
                    #endregion
                    if (submit == "Submit")
                    {
                        objobjmodel = _objFPOMasterModel.Add(objmodel);
                    }
                    else
                    {
                        objobjmodel = _objFPOMasterModel.Update(objmodel);
                    }
                    TempData["msg"] = objobjmodel.Satus;
                    return RedirectToAction("Add", "FPOOrder", new { Area = "Geology" });
                }
                else
                {
                    int? id = objmodel.FPO_Id;
                    if (id != null)
                    {
                        objmodel.FPO_Id = id;
                        objmodel = _objFPOMasterModel.Edit(objmodel);
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
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                objmodel = null;
            }
        }
        /// <summary>
        /// To bind Field Program Order list details data in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        public IActionResult ViewList(FPOOrdermaster objmodel)
        {
            List<FPOOrdermaster> lstFPOmaster = new List<FPOOrdermaster>();
            try
            {
                if (TempData["msg"] != null)
                {
                    ViewBag.msg = TempData["msg"].ToString();
                }
                lstFPOmaster = _objFPOMasterModel.View(objmodel);
                ViewBag.ViewList = lstFPOmaster;
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objmodel = null;
                lstFPOmaster = null;
            }
        }
        /// <summary>
        ///  To POST Field Program Order list details data in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="Show1"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult ViewList(FPOOrdermaster objmodel, string Show1)
        {
            try
            {
                ViewBag.ViewList = _objFPOMasterModel.View(objmodel);
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objmodel = null;
            }
        }
        /// <summary>
        /// To delete Field Program Order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public IActionResult Delete(string id = "0")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            FPOOrdermaster objmodel = new FPOOrdermaster();
            try
            {
                objmodel.CreatedBy = profile.UserId;
                objmodel.UserLoginId = profile.UserLoginId;
                objmodel.FPO_Id = Convert.ToInt32(id);
                objobjmodel = _objFPOMasterModel.Delete(objmodel);
                if (objobjmodel.Satus == "1")
                {
                    TempData["msg"] = "Data Deleted Sucessfully !";
                    return RedirectToAction("ViewList");
                }
                else
                {
                    TempData["msg"] = "Data not Deleted Sucessfully !";
                    return RedirectToAction("ViewList");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objmodel = null;
            }
        }
        /// <summary>
        /// To bind Financial Year list in view
        /// </summary>
        /// <returns></returns>
        public JsonResult GetFinancialYearlist()
        {
            List<FPOOrdermaster> listFieldSeasonResult = new List<FPOOrdermaster>();
            FPOOrdermaster fpomaster = new FPOOrdermaster();
            try
            {
                listFieldSeasonResult = _objFPOMasterModel.GetFieldSeasonList(fpomaster);
                return Json(listFieldSeasonResult);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                fpomaster = null;
                listFieldSeasonResult = null;
            }
        }
    }
}