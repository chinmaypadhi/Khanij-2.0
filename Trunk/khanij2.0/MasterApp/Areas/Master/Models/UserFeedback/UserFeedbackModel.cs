// ***********************************************************************
//  Class Name               : UserFeedbackModel
//  Description              : Add,View,Edit,Update,Delete User Feedback Details
//  Created By               : Lingaraj Dalai
//  Created On               : 22 Jan 2021
// ***********************************************************************
using MasterEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.UserFeedback
{
    public class UserFeedbackModel:IUserFeedbackModel
    {
        /// <summary>
        /// Global Object & variable declaration
        /// </summary>
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objKeyList"></param>
        /// <param name="objIHttpWebClients"></param>
        public UserFeedbackModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Publish User Feedback
        /// </summary>
        /// <param name="objUserFeedbackmaster"></param>
        /// <returns></returns>
        public MessageEF PublishUserFeedback(UserFeedbackmaster objUserFeedbackmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserFeedback/PublishUserFeedback", JsonConvert.SerializeObject(objUserFeedbackmaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// UnPublish User Feedback
        /// </summary>
        /// <param name="objUserFeedbackmaster"></param>
        /// <returns></returns>
        public MessageEF UndoPublish(UserFeedbackmaster objUserFeedbackmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserFeedBack/UndoPublishUserFeedback", JsonConvert.SerializeObject(objUserFeedbackmaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Bind User Feedback
        /// </summary>
        /// <param name="objUserFeedbackmaster"></param>
        /// <returns></returns>
        public List<UserFeedbackmaster> View(UserFeedbackmaster objUserFeedbackmaster)
        {
            try
            {
                List<UserFeedbackmaster> objlistUserFeedbackmaster = new List<UserFeedbackmaster>();
                objlistUserFeedbackmaster = JsonConvert.DeserializeObject<List<UserFeedbackmaster>>(_objIHttpWebClients.PostRequest("UserFeedBack/View", JsonConvert.SerializeObject(objUserFeedbackmaster)));
                return objlistUserFeedbackmaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
