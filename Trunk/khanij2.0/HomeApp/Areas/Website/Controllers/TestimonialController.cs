// ***********************************************************************
//  Controller Name          : TestimonialController
//  Desciption               : Add,Select,Update,Delete Website Testimonial Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 27 Oct 2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeEF;
using HomeApp.Areas.Website.Models.Testimonial;
using HomeApp.Web;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using HomeApp.ActionFilter;

namespace HomeApp.Areas.Website.Controllers
{
    [Area("Website")]
    public class TestimonialController : Controller
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IConfiguration configuration;
        ITestimonialModel _objITestimonialModel;
        MessageEF objobjmodel = new MessageEF();
        AddTestimonialModel objAddmodel = new AddTestimonialModel();
        ViewTestimonialModel objViewmodel = new ViewTestimonialModel();
        List<AddTestimonialModel> objlistmodel = new List<AddTestimonialModel>();
        List<ViewTestimonialModel> objlistviewmodel = new List<ViewTestimonialModel>();
        string uniqueFileName = string.Empty;
        string filePath = string.Empty;
        string ExtensionId = string.Empty;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objNotificationModel"></param>
        public TestimonialController(ITestimonialModel objITestimonialModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _objITestimonialModel = objITestimonialModel;
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;
        }
        /// <summary>
        /// HTTP Get Method of Add Testimonial Details in view
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
                    objAddmodel.INT_TESTIMONIAL_ID = Convert.ToInt32(id);
                    objAddmodel = _objITestimonialModel.Edit(objAddmodel);
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
        /// HTTP Post Method of Add Testimonial Details in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Add(AddTestimonialModel objmodel, string submit)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            objmodel.INT_CREATED_BY = profile.UserId;
            ExtensionId = Convert.ToString(objmodel.INT_CREATED_BY);
            try
            {
                #region Validation
                if (string.IsNullOrEmpty(objmodel.VCH_TESTIMONIAL_MSG))
                {
                    ModelState.AddModelError("VCH_TESTIMONIAL_MSG", "Message is required");
                }
                if (string.IsNullOrEmpty(objmodel.VCH_TESTIMONIAL_NAME))
                {
                    ModelState.AddModelError("VCH_TESTIMONIAL_NAME", "Name is required");
                }
                if (string.IsNullOrEmpty(objmodel.VCH_TESTIMONIAL_DESG))
                {
                    ModelState.AddModelError("VCH_TESTIMONIAL_DESG", "Designation is required");
                }
                if (string.IsNullOrEmpty(objmodel.VCH_TESTIMONIAL_LOCATION))
                {
                    ModelState.AddModelError("VCH_TESTIMONIAL_LOCATION", "Location is required");
                }
                //if (objmodel.VCH_IMG_PATH == null || objmodel.VCH_IMG_PATH == "")
                //{
                //    if (objmodel.Photo == null)
                //    {
                //        ModelState.AddModelError("Photo", "Upload Photo");
                //    }
                //}
                #endregion
                if (ModelState.IsValid)
                {
                    #region File Upload
                    if (objmodel.Photo != null)
                    {
                        uniqueFileName = ExtensionId + "_" + Path.GetFileName(objmodel.Photo.FileName);
                        filePath = Path.Combine(configuration.GetSection("Path").GetValue<string>("TestimonialPath"), uniqueFileName);
                        var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("TestimonialPath"));
                        string uploadsFolder = Path.Combine(RootPath, uniqueFileName);
                        if (!Directory.Exists(RootPath))
                            Directory.CreateDirectory(RootPath);
                        DirectoryInfo di = new DirectoryInfo(RootPath);
                        di.Attributes = FileAttributes.Normal;
                        using (var fileStream = new FileStream(uploadsFolder, FileMode.Create))
                            objmodel.Photo.CopyTo(fileStream);
                        objmodel.VCH_IMG_PATH = filePath;
                        uniqueFileName = null;
                        filePath = null;
                        objmodel.Photo = null;
                    }
                    #endregion
                    if (submit == "Submit")
                    {
                        objobjmodel = _objITestimonialModel.Add(objmodel);
                        TempData["Message"] = objobjmodel.Satus;
                        return RedirectToAction("Add", "Testimonial", new { Area = "Website" });
                    }
                    else
                    {
                        objobjmodel = _objITestimonialModel.Update(objmodel);
                        TempData["Message"] = objobjmodel.Satus;
                        return RedirectToAction("ViewList", "Testimonial", new { Area = "Website" });
                    }

                }
                else
                {
                    int? id = objmodel.INT_TESTIMONIAL_ID;
                    if (id != null)
                    {
                        objAddmodel = _objITestimonialModel.Edit(objAddmodel);
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
        /// HTTP Get method to bind Testimonial details data in view
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
                objlistviewmodel = _objITestimonialModel.View(objViewmodel);
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
        /// Delete Testimonial detials in view
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Decryption]
        public IActionResult Delete(string id = "0")
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                objViewmodel.INT_CREATED_BY = profile.UserId;
                objViewmodel.INT_TESTIMONIAL_ID = Convert.ToInt32(id);
                objobjmodel = _objITestimonialModel.Delete(objViewmodel);
                TempData["Message"] = objobjmodel.Satus;
                return RedirectToAction("ViewList", "Testimonial", new { Area = "Website" });
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objViewmodel = null;
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
                var RootPath = Path.Combine(hostingEnvironment.WebRootPath, configuration.GetSection("Path").GetValue<string>("TestimonialPath"));
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
