// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 22-Jan-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using MasterApp.Areas.Master.Models.UserFeedback;
using MasterApp.Web;
using MasterEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace MasterApp.Areas.Master.Controllers
{
    [Area("master")]
    public class UserFeedBackController : Controller
    {
        IUserFeedbackModel _objUserFeedbackmasterModel;
        MessageEF objobjmodel = new MessageEF();
        public UserFeedBackController(IUserFeedbackModel objUserFeedbackmasterModel)
        {
            _objUserFeedbackmasterModel = objUserFeedbackmasterModel;
        }
        public IActionResult ViewList(string FromDate,string ToDate)
        {
            try
            {
                UserFeedbackmaster objModel = new UserFeedbackmaster();
                objModel.FromDate = FromDate;
                objModel.ToDate = ToDate;
                List<UserFeedbackmaster> lstuserFeedbackmasters = new List<UserFeedbackmaster>();
                lstuserFeedbackmasters = _objUserFeedbackmasterModel.View(objModel);               
                return View(lstuserFeedbackmasters);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public IActionResult PublishUserFeedback(int id = 0, int IsApproved = 0)
        {
            UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
            UserFeedbackmaster objModel = new UserFeedbackmaster();
            objModel.FeedbackId = id;
            if (IsApproved == 1)
            {
                objobjmodel = _objUserFeedbackmasterModel.UndoPublish(objModel);
                TempData["msg"] = "User feedback undo-published successfully";
            }
            else
            {
                objobjmodel = _objUserFeedbackmasterModel.PublishUserFeedback(objModel);
                TempData["msg"] = "User feedback published successfully";
            }
            //ViewBag.msg =IsApproved==1?2:1;
            
            return RedirectToAction("ViewList");
        }
    }
}