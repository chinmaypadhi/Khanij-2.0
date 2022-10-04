// ***********************************************************************
//  Class Name               : NotificationModel
//  Desciption               : Add,Select,Update,Delete Website Notification Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 07 Oct 2021
// ***********************************************************************
using HomeApp.Models.Utility;
using HomeEF;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Models.Notification
{
    public class NotificationModel:INotificationModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public NotificationModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add Website Notification Details
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>
        public MessageEF Add(AddNotificationModel objAddNotificationModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Notification/Add", JsonConvert.SerializeObject(objAddNotificationModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update Website Notification Details 
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>
        public MessageEF Update(AddNotificationModel objAddNotificationModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Notification/Update", JsonConvert.SerializeObject(objAddNotificationModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Edit Website Notification Details
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        public AddNotificationModel Edit(AddNotificationModel objAddNotificationModel)
        {
            try
            {
                objAddNotificationModel = JsonConvert.DeserializeObject<AddNotificationModel>(_objIHttpWebClients.PostRequest("Notification/Edit", JsonConvert.SerializeObject(objAddNotificationModel)));
                return objAddNotificationModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Website Notification Details 
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>
        public List<ViewNotificationModel> View(ViewNotificationModel objViewNotificationModel)
        {
            try
            {
                List<ViewNotificationModel> objlistNotification = new List<ViewNotificationModel>();
                objlistNotification = JsonConvert.DeserializeObject<List<ViewNotificationModel>>(_objIHttpWebClients.PostRequest("Notification/View", JsonConvert.SerializeObject(objViewNotificationModel)));
                return objlistNotification;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Website Notification Archive Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        public List<ViewNotificationModel> ViewArchive(ViewNotificationModel objViewNotificationModel)
        {
            try
            {
                List<ViewNotificationModel> objlistNotification = new List<ViewNotificationModel>();
                objlistNotification = JsonConvert.DeserializeObject<List<ViewNotificationModel>>(_objIHttpWebClients.PostRequest("Notification/ViewArchive", JsonConvert.SerializeObject(objViewNotificationModel)));
                return objlistNotification;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Delete Website Notification Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        public MessageEF Delete(ViewNotificationModel objViewNotificationModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Notification/Delete", JsonConvert.SerializeObject(objViewNotificationModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Archive Website Notification Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        public MessageEF Archive(ViewNotificationModel objViewNotificationModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Notification/Archive", JsonConvert.SerializeObject(objViewNotificationModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Publish Website Notification Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        public MessageEF Publish(ViewNotificationModel objViewNotificationModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Notification/Publish", JsonConvert.SerializeObject(objViewNotificationModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Unpublish Website Notification Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        public MessageEF Unpublish(ViewNotificationModel objViewNotificationModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Notification/Unpublish", JsonConvert.SerializeObject(objViewNotificationModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Active Website Notification Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        public MessageEF Active(ViewNotificationModel objViewNotificationModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Notification/Active", JsonConvert.SerializeObject(objViewNotificationModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Bind Website Notification Type List Details 
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>
        public List<AddNotificationModel> GetNotificationTypeList(AddNotificationModel objAddNotificationModel)
        {
            try
            {
                List<AddNotificationModel> objlistNotificationType = new List<AddNotificationModel>();
                objlistNotificationType = JsonConvert.DeserializeObject<List<AddNotificationModel>>(_objIHttpWebClients.PostRequest("Notification/GetNotificationTypeList", JsonConvert.SerializeObject(objAddNotificationModel)));
                return objlistNotificationType;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Publish Website Notification Active Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        public List<ViewNotificationModel> ViewWebsiteNotification(ViewNotificationModel objViewNotificationModel)
        {
            try
            {
                List<ViewNotificationModel> objlistNotification = new List<ViewNotificationModel>();
                objlistNotification = JsonConvert.DeserializeObject<List<ViewNotificationModel>>(_objIHttpWebClients.PostRequest("Notification/ViewWebsiteNotification", JsonConvert.SerializeObject(objViewNotificationModel)));
                return objlistNotification;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Publish Website Notification Archive Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        public List<ViewNotificationModel> ViewWebsiteNotificationArchive(ViewNotificationModel objViewNotificationModel)
        {
            try
            {
                List<ViewNotificationModel> objlistNotification = new List<ViewNotificationModel>();
                objlistNotification = JsonConvert.DeserializeObject<List<ViewNotificationModel>>(_objIHttpWebClients.PostRequest("Notification/ViewWebsiteNotificationArchive", JsonConvert.SerializeObject(objViewNotificationModel)));
                return objlistNotification;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Publish Website Notification Active Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        public List<ViewNotificationModel> ViewTopWebsiteNotification(ViewNotificationModel objViewNotificationModel)
        {
            try
            {
                List<ViewNotificationModel> objlistNotification = new List<ViewNotificationModel>();
                objlistNotification = JsonConvert.DeserializeObject<List<ViewNotificationModel>>(_objIHttpWebClients.PostRequest("Notification/ViewTopWebsiteNotification", JsonConvert.SerializeObject(objViewNotificationModel)));
                return objlistNotification;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
