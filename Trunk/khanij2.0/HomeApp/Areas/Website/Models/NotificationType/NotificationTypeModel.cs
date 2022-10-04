// ***********************************************************************
//  Class Name               : NotificationTypeModel
//  Desciption               : Add,Select,Update,Delete Website Notification Type Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 12 Oct 2021
// ***********************************************************************
using HomeApp.Models.Utility;
using HomeEF;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Models.NotificationType
{
    public class NotificationTypeModel:INotificationTypeModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public NotificationTypeModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add Website Notification Type Details
        /// </summary>
        /// <param name="objAddNotificationTypeModel"></param>
        /// <returns></returns>
        public MessageEF Add(AddNotificationTypeModel objAddNotificationTypeModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("NotificationType/Add", JsonConvert.SerializeObject(objAddNotificationTypeModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update Website Notification Type Details 
        /// </summary>
        /// <param name="objAddNotificationTypeModel"></param>
        /// <returns></returns>
        public MessageEF Update(AddNotificationTypeModel objAddNotificationTypeModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("NotificationType/Update", JsonConvert.SerializeObject(objAddNotificationTypeModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Edit Website Notification Type Details
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        public AddNotificationTypeModel Edit(AddNotificationTypeModel objAddNotificationTypeModel)
        {
            try
            {
                objAddNotificationTypeModel = JsonConvert.DeserializeObject<AddNotificationTypeModel>(_objIHttpWebClients.PostRequest("NotificationType/Edit", JsonConvert.SerializeObject(objAddNotificationTypeModel)));
                return objAddNotificationTypeModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Website Notification Type Details 
        /// </summary>
        /// <param name="objAddNotificationTypeModel"></param>
        /// <returns></returns>
        public async Task<List<ViewNotificationTypeModel>> View(ViewNotificationTypeModel objViewNotificationModel)
        {
            try
            {
                List<ViewNotificationTypeModel> objlistNotificationType = new List<ViewNotificationTypeModel>();
                objlistNotificationType = JsonConvert.DeserializeObject<List<ViewNotificationTypeModel>>(await _objIHttpWebClients.AwaitPostRequest("NotificationType/View", JsonConvert.SerializeObject(objViewNotificationModel)));
                return objlistNotificationType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Delete Website Notification Type Details 
        /// </summary>
        /// <param name="objAddNotificationTypeModel"></param>
        /// <returns></returns>
        public MessageEF Delete(ViewNotificationTypeModel objViewNotificationModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("NotificationType/Delete", JsonConvert.SerializeObject(objViewNotificationModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
