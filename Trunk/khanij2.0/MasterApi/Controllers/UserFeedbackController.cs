// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 22-Jan-2021
// ***********************************************************************
using System.Collections.Generic;
using MasterApi.Model.UserFeedback;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class UserFeedbackController : ControllerBase
    {
        /// <summary>
        /// Global Declartion
        /// </summary>
        public IUserFeedbackProvider _objIUserFeedbackProvider;
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        /// <param name="objUserFeedbackProvider"></param>
        public UserFeedbackController(IUserFeedbackProvider objUserFeedbackProvider)
        {
            _objIUserFeedbackProvider = objUserFeedbackProvider;
        }
        [HttpPost]
        public MessageEF PublishUserFeedback(UserFeedbackmaster objUserFeedbackmaster)
        {
            return _objIUserFeedbackProvider.PublishUserFeedback(objUserFeedbackmaster);
        }
        [HttpPost]
        public MessageEF UndoPublishUserFeedback(UserFeedbackmaster objUserFeedbackmaster)
        {
            return _objIUserFeedbackProvider.UndoPublishUserFeedback(objUserFeedbackmaster);
        }
        [HttpPost]
        public List<UserFeedbackmaster> View(UserFeedbackmaster objUserFeedbackmaster)
        {
            return _objIUserFeedbackProvider.ViewUserFeedbackmaster(objUserFeedbackmaster);
        }
    }
}