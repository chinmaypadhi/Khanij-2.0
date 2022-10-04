// ***********************************************************************
//  Controller Name          : MPRWorkController
//  Desciption               : To Add,View,Update,Delete Monthly Progress Report details 
//  Created By               : Lingaraj Dalai
//  Created On               : 02 March 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using GeologyApp.ActionFilter;
using GeologyApp.Models.MPR;
using GeologyApp.Web;
using GeologyEF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GeologyApp.Controllers
{
    [Area("Geology")]
    public class MPRWorkController : Controller
    {
        /// <summary>
        /// Global Object and variable declaration
        /// </summary>
        IMPRModel _objMPRMasterModel;
        MessageEF objobjmodel = new MessageEF();
        MPRWorkmaster objmodel;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        string ExtensionId = string.Empty;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objMPRMasterModel"></param>
        /// <param name="hostingEnvironment"></param>
        public MPRWorkController(IMPRModel objMPRMasterModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _objMPRMasterModel = objMPRMasterModel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }
        /// <summary>
        /// HTTP get method of Monthly Progress Report Add action details in view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public IActionResult Add(string id = "0")
        {
            objmodel = new MPRWorkmaster();
            try
            {
                if (id != "0")
                {
                    TempData["MPR_Id"] = id;
                    objmodel.MPR_Id = Convert.ToInt32(id);
                    objmodel = _objMPRMasterModel.EditMPRWorkMaster(objmodel);
                    if (objmodel.Work_Id > 0)
                    {
                        ViewBag.Button = "Update";
                    }
                    else
                    {
                        ViewBag.Button = "Submit";
                        ViewBag.Date = DateTime.Now.ToString("dd/MM/yyyy");
                    }
                }
                return View(objmodel);
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
        /// HTTP Post method to Add Monthly Progress Report details
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Add(MPRWorkmaster objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.UserId = profile.UserId;
            objmodel.UserLoginId = profile.UserLoginId;
            try
            {
                #region Validation
                if (objmodel.Up_To_The_Last_Month == null)
                {
                    ModelState.AddModelError("Up_To_The_Last_Month", "Up to the last month field is required");
                }
                if (string.IsNullOrEmpty(objmodel.During_The_Month))
                {
                    ModelState.AddModelError("During_The_Month", "During the month field is required");
                }
                if (objmodel.Labor == null)
                {
                    ModelState.AddModelError("Labor", "Labor field is required");
                }
                if (objmodel.POL == null)
                {
                    ModelState.AddModelError("POL", "POL field is required");
                }
                if (string.IsNullOrEmpty(objmodel.Repair_And_Maintenance))
                {
                    ModelState.AddModelError("Repair_And_Maintenance", "Repair and maintenance field is required");
                }
                if (objmodel.others == null)
                {
                    ModelState.AddModelError("others", "others field is required");
                }
                if (objmodel.Reconn_Area_Target == null)
                {
                    ModelState.AddModelError("Reconn_Area_Target", "Reconn target field is required");
                }
                if (objmodel.Reconn_Area_Last_Month == null)
                {
                    ModelState.AddModelError("Reconn_Area_Last_Month", "Work done up to the last month field is required");
                }
                if (objmodel.Reconn_Area_During_Month == null)
                {
                    ModelState.AddModelError("Reconn_Area_During_Month", "Work done during the month field is required");
                }
                if (string.IsNullOrEmpty(objmodel.Detailed_Area_Target))
                {
                    ModelState.AddModelError("Detailed_Area_Target", "Detailed target field is required");
                }
                if (string.IsNullOrEmpty(objmodel.Detailed_Area_Last_Month))
                {
                    ModelState.AddModelError("Detailed_Area_Last_Month", "Work done up to the last month field is required");
                }
                if (string.IsNullOrEmpty(objmodel.Detailed_Area_During_Month))
                {
                    ModelState.AddModelError("Detailed_Area_During_Month", "Work done during the month");
                }
                if (string.IsNullOrEmpty(objmodel.Pitting_Nos_Target))
                {
                    ModelState.AddModelError("Pitting_Nos_Target", "Pitting target field is required");
                }
                if (string.IsNullOrEmpty(objmodel.Pitting_Nos_Last_Month))
                {
                    ModelState.AddModelError("Pitting_Nos_Last_Month", "Work done up to the last month field is required");
                }
                if (string.IsNullOrEmpty(objmodel.Pitting_Nos_During_Month))
                {
                    ModelState.AddModelError("Pitting_Nos_During_Month", "Work done during the month");
                }
                #endregion
                if (ModelState.IsValid)
                {
                    #region File Upload                       
                    objmodel.MPR_Id = Convert.ToInt32(TempData["MPR_Id"]);
                    ExtensionId = Convert.ToString(objmodel.UserId);
                    string MapuniqueFileName = null; string MapfilePath = null;
                    string SynopsisuniqueFileName = null; string SynopsisfilePath = null;
                    string BoreholeuniqueFileName = null; string BoreholefilePath = null;
                    string OtherInfouniqueFileName = null; string OtherInfofilePath = null;
                    if (objmodel.MapAttachment != null)
                    {
                        MapuniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.MapAttachment.FileName);
                        MapfilePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadMPRWorkPath"), MapuniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadMPRWorkPath"));
                        string uploadsFolder = Path.Combine(RootPath, MapuniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.MapAttachment.CopyTo(fileStream);
                        objmodel.MapName = MapuniqueFileName;
                        objmodel.Map = MapfilePath;
                        objmodel.MapAttachment = null;
                    }
                    if (objmodel.BoreholeAttachment != null)
                    {
                        BoreholeuniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.BoreholeAttachment.FileName);
                        BoreholefilePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadMPRWorkPath"), BoreholeuniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadMPRWorkPath"));
                        string uploadsFolder = Path.Combine(RootPath, BoreholeuniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.BoreholeAttachment.CopyTo(fileStream);
                        objmodel.LogName = BoreholeuniqueFileName;
                        objmodel.BoreholeLogs = BoreholefilePath;
                        objmodel.BoreholeAttachment = null;
                    }
                    if (objmodel.SynopsisAttachment != null)
                    {
                        SynopsisuniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.SynopsisAttachment.FileName);
                        SynopsisfilePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadMPRWorkPath"), SynopsisuniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadMPRWorkPath"));
                        string uploadsFolder = Path.Combine(RootPath, SynopsisuniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.SynopsisAttachment.CopyTo(fileStream);
                        objmodel.SynopsisName = SynopsisuniqueFileName;
                        objmodel.Synopsis = SynopsisfilePath;
                        objmodel.SynopsisAttachment = null;
                    }
                    if (objmodel.Other_InfoAttachment != null)
                    {
                        OtherInfouniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.Other_InfoAttachment.FileName);
                        OtherInfofilePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("UploadMPRWorkPath"), OtherInfouniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("UploadMPRWorkPath"));
                        string uploadsFolder = Path.Combine(RootPath, OtherInfouniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.Other_InfoAttachment.CopyTo(fileStream);
                        objmodel.OtherName = OtherInfouniqueFileName;
                        objmodel.Other_Info = OtherInfofilePath;
                        objmodel.Other_InfoAttachment = null;
                    }
                    #endregion
                    if (submit == "Submit")
                    {
                        objobjmodel = _objMPRMasterModel.AddMPRWorkMaster(objmodel);
                    }
                    else
                    {
                        objobjmodel = _objMPRMasterModel.UpdateMPRWorkMaster(objmodel);
                    }
                    TempData["msg"] = objobjmodel.Satus;
                    return RedirectToAction("ViewList", new { MPRId = objmodel.MPR_Id });
                }
                else
                {
                    int? id = objmodel.MPR_Id;
                    if (id != null)
                    {
                        TempData["MPR_Id"] = id;
                        objmodel.MPR_Id = id;
                        objmodel = _objMPRMasterModel.EditMPRWorkMaster(objmodel);
                        if (objmodel.Work_Id > 0)
                        {
                            ViewBag.Button = "Update";
                        }
                        else
                        {
                            ViewBag.Button = "Submit";
                            ViewBag.Date = DateTime.Now.ToString("dd/MM/yyyy");
                        }
                    }
                    return View(objmodel);
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
        /// To bind MPR work details in view
        /// </summary>
        /// <param name="MPRId"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public IActionResult ViewList(string MPRId="0")
        {
            objmodel = new MPRWorkmaster();
            List<MPRWorkmaster> lstFPOmaster = new List<MPRWorkmaster>();
            try
            {
                if (TempData["msg"] != null)
                {
                    if (Convert.ToString(TempData["msg"]) == "1")
                        ViewBag.msg = "MPR Work created successfully !";
                    else if (Convert.ToString(TempData["msg"]) == "4")
                        ViewBag.msg = "MPR Work updated successfully !";
                    else
                        ViewBag.msg = "Data not saved !";
                }
                objmodel.MPR_Id = Convert.ToInt32(MPRId);
                lstFPOmaster = _objMPRMasterModel.ViewMPRWorkMaster(objmodel);
                ViewBag.ViewList = lstFPOmaster;
                return View();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                lstFPOmaster = null;
                objmodel = null;
            }
        }
        /// <summary>
        /// To Delete Monthly Progress Report work details in view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SkipImportantTask]
        public IActionResult Delete(string id = "0")
        {
            objmodel = new MPRWorkmaster();
            try
            {
                objmodel.Work_Id = Convert.ToInt32(id);
                objobjmodel = _objMPRMasterModel.DeleteMPRWorkMaster(objmodel);
                if (objobjmodel.Satus == "1")
                {
                    TempData["msg"] = "Data Deleted Sucessfully !";
                }
                else
                {
                    TempData["msg"] = "Data not Deleted Sucessfully !";                  
                }
                return RedirectToAction("ViewList", "MPRCreator",new { Area="Geology"});
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
        /// To bind MPR camp work details in view
        /// </summary>
        /// <param name="MPR_Id"></param>
        /// <param name="Work_Id"></param>
        /// <returns></returns>
        public JsonResult getMultipleMPRCampWorkData(int? MPR_Id, int? Work_Id)
        {
            objmodel = new MPRWorkmaster();
            try
            {
                objmodel.MPR_Id = MPR_Id;
                objmodel.Work_Id = Work_Id;
                objmodel = _objMPRMasterModel.EditMPRWorkMaster(objmodel);
                return Json(objmodel);
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
    }
}