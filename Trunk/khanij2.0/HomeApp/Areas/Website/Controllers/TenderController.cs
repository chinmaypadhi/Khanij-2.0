// ***********************************************************************
//  Controller Name          : TenderController
//  Desciption               : Add,Select,Update,Delete Website Tender Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 11 Oct 2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeEF;
using HomeApp.Areas.Website.Models.Tender;
using HomeApp.Web;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using HomeApp.ActionFilter;

namespace HomeApp.Areas.Website.Controllers
{
    [Area("Website")]
    public class TenderController : Controller
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        ITenderModel _objTenderModel;
        MessageEF objobjmodel = new MessageEF();
        AddTenderModel objAddmodel = new AddTenderModel();
        ViewTenderModel objViewmodel = new ViewTenderModel();
        List<AddTenderModel> objlistmodel = new List<AddTenderModel>();
        List<ViewTenderModel> objlistviewmodel = new List<ViewTenderModel>();
        string uniqueFileName = string.Empty;
        string filePath = string.Empty;
        string ExtensionId = string.Empty;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objNotificationModel"></param>
        public TenderController(ITenderModel objTenderModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _objTenderModel = objTenderModel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }
        /// <summary>
        /// HTTP Get Method of Add Tender Details in view
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
                    objAddmodel.INT_TENDER_ID = Convert.ToInt32(id);
                    objAddmodel = _objTenderModel.Edit(objAddmodel);
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
        /// HTTP Post Method of Add Tender Details in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Add(AddTenderModel objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.INT_CREATED_BY = profile.UserId;
            ExtensionId = Convert.ToString(objmodel.INT_CREATED_BY);
            try
            {
                #region Validation
                if (objmodel.VCH_TENDER_NO == null)
                {
                    ModelState.AddModelError("VCH_TENDER_NO", "Tender No field is required");
                }
                if (string.IsNullOrEmpty(objmodel.VCH_SUBJECT))
                {
                    ModelState.AddModelError("VCH_SUBJECT", "Tender Subject is required");
                }
                if (objmodel.VCH_DOCUMENT == null || objmodel.VCH_DOCUMENT == "")
                {
                    if (objmodel.Tenderfile == null)
                    {
                        ModelState.AddModelError("Tenderfile", "Upload Tender File");
                    }
                }
                #endregion
                if (ModelState.IsValid)
                {
                    #region File Upload
                    if (objmodel.Tenderfile != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.Tenderfile.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("TenderPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("TenderPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.Tenderfile.CopyTo(fileStream);
                        objmodel.VCH_DOCUMENT = filePath;
                        uniqueFileName = null;
                        filePath = null;
                        objmodel.Tenderfile = null;
                    }
                    #endregion
                    if (submit == "Submit")
                    {
                        objobjmodel = _objTenderModel.Add(objmodel);
                        TempData["Message"] = "Tender Saved Sucessfully.";
                        return RedirectToAction("Add", "Tender", new { Area = "Website" });
                    }
                    else
                    {
                        objobjmodel = _objTenderModel.Update(objmodel);
                        TempData["Message"] = "Tender Updated Sucessfully.";
                        return RedirectToAction("ViewList", "Tender", new { Area = "Website" });
                    }

                }
                else
                {
                    int? id = objmodel.INT_TENDER_ID;
                    if (id != null)
                    {
                        objAddmodel = _objTenderModel.Edit(objAddmodel);
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
        /// HTTP Get method to bind Tender details data in view
        /// </summary>
        /// <returns></returns>
        public IActionResult ViewList()
        {
            List<ViewTenderModel> notificationModels = new List<ViewTenderModel>();
            try
            {
                if (TempData["Message"] != null)
                {
                    ViewBag.msg = TempData["Message"].ToString();
                }
                notificationModels = _objTenderModel.View(objViewmodel);
                return View(notificationModels);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objViewmodel = null;
                notificationModels = null;
            }
        }
        /// <summary>
        /// Delete Tender detials in view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public IActionResult Delete(string id = "0")
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objViewmodel.INT_CREATED_BY = profile.UserId;
            objViewmodel.INT_TENDER_ID = Convert.ToInt32(id);
            objobjmodel = _objTenderModel.Delete(objViewmodel);
            if (objobjmodel.Satus == "1")
            {
                TempData["Message"] = "Tender Deleted Sucessfully.";
            }
            else
            {
                TempData["Message"] = "Tender not Deleted Sucessfully.";
            }
            return RedirectToAction("ViewList", "Tender", new { Area = "Website" });
        }
    }
}
