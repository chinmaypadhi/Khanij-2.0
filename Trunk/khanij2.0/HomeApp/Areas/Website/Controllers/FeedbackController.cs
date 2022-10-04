using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeApp.Areas.Website.Models.Feedback;
using HomeApp.Models;
using HomeEF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace HomeApp.Areas.Website.Controllers
{
    [Area("Website")]
    public class FeedbackController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        IFeedbackModel _objFeedbackModel;
        MessageEF objobjmodel = new MessageEF();
        AddFeedbackModel objAddmodel = new AddFeedbackModel();
        ViewFeedbackModel objViewmodel = new ViewFeedbackModel();
        List<AddFeedbackModel> objlistmodel = new List<AddFeedbackModel>();
        List<ViewFeedbackModel> objlistviewmodel = new List<ViewFeedbackModel>();
        string uniqueFileName = string.Empty;
        string filePath = string.Empty;
        string ExtensionId = string.Empty;
        /// <summary>
        /// Constructor dependency injection
        /// </summary>
        /// <param name="feedbackModel"></param>
        /// <param name="hostingEnvironment"></param>
        /// <param name="configuration"></param>
        public FeedbackController(IFeedbackModel feedbackModel, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _objFeedbackModel = feedbackModel;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
        }
        /// <summary>
        /// Http Get Method of Feedback Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Add(int id = 0)
        {
            try
            {
                if (id != 0)
                {
                    objAddmodel.FEEDBACK_ID = id;
                    objAddmodel = _objFeedbackModel.Edit(objAddmodel);
                    ViewBag.Button = "Update";
                    return View(objAddmodel);
                }
                else
                {
                    objAddmodel.BIT_STATUS = true;
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
        /// Http Post Method of Feedback Details To Add New Feedback
        /// </summary>
        /// <param name="objmodel"></param>
        /// <param name="submit"></param>
        /// <returns></returns>
        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult Add(AddFeedbackModel objmodel, string submit)
        {
            //UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            //objmodel.INT_CREATED_BY = profile.UserId;
            //ExtensionId = Convert.ToString(objmodel.int);
            try
            {
                #region Validation
               
                if (string.IsNullOrEmpty(objmodel.FULL_NAME))
                {
                    ModelState.AddModelError("FULL_NAME", "Full Name is Required");
                }
                if(string.IsNullOrEmpty(objmodel.MAIL_ID))
                {
                    ModelState.AddModelError("MAIL_ID", "Mail Id is Required");
                }
                if(string.IsNullOrEmpty(objmodel.FEEDBACK))
                {
                    ModelState.AddModelError("FEEDBACK", "Feedback is Required");
                }
               
                #endregion
                if (ModelState.IsValid)
                {
                   
                    if (submit == "Submit")
                    {
                        objobjmodel = _objFeedbackModel.Add(objmodel);
                        objmodel.BIT_STATUS = true;
                        TempData["Message"] = "Feedback Saved Sucessfully.";
                        return RedirectToAction("Add", "Feedback", new { Area = "Website" });
                    }
                    else
                    {
                        objobjmodel = _objFeedbackModel.Update(objmodel);
                        TempData["Message"] = "Feedback Updated Sucessfully.";
                        return RedirectToAction("ViewList", "Feedback", new { Area = "Website" });
                    }

                }
                else
                {
                    int? id = objmodel.FEEDBACK_ID;
                    if (id != null)
                    {
                        objAddmodel = _objFeedbackModel.Edit(objAddmodel);
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
                throw;
            }
            finally
            {
                //objobjmodel = null;
                objmodel = null;
            }
        }
        /// <summary>
        /// To Bind Feedback details data in view
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
                objlistviewmodel = await _objFeedbackModel.View(objViewmodel);
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
        /// For Deletion of Feedback
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int id = 0)
        {
            //UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            //objViewmodel.INT_CREATED_BY = profile.UserId;
            objViewmodel.FEEDBACK_ID = id;
            objobjmodel = _objFeedbackModel.Delete(objViewmodel);
            if (objobjmodel.Satus == "1")
            {
                TempData["Message"] = "Feedback Deleted Sucessfully.";
            }
            else
            {
                TempData["Message"] = "Feedback not Deleted Sucessfully.";
            }
            return RedirectToAction("ViewList", "Feedback", new { Area = "Website" });
        }
    }
}
