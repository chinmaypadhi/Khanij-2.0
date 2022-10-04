// ***********************************************************************
//  Interface Name           : INotificationProvider
//  Desciption               : Add,Select,Update,Delete Website Notification Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 07 Oct 2021
// ***********************************************************************
using HomeApi.Repository;
using HomeEF;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeApi.Model.Notification
{
    public interface INotificationProvider: IDisposable, IRepository
    {
        /// <summary>
        /// Add Website Notification Details 
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>
        MessageEF AddNotification(AddNotificationModel objAddNotificationModel);
        /// <summary>
        /// Select Website Notification Details 
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>
        Task<List<ViewNotificationModel>> ViewNotification(ViewNotificationModel objViewNotificationModel);
        /// <summary>
        /// Select Website Notification Archive Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        Task<List<ViewNotificationModel>> ViewNotificationArchive(ViewNotificationModel objViewNotificationModel);
        /// <summary>
        /// Edit Website Notification Details
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>
        AddNotificationModel EditNotification(AddNotificationModel objAddNotificationModel);
        /// <summary>
        /// Archive Website Notification Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        Task<MessageEF> ArchiveNotification(ViewNotificationModel objViewNotificationModel);
        /// <summary>
        /// Delete Website Notification Details 
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>
        MessageEF DeleteNotification(ViewNotificationModel objViewNotificationModel);
        /// <summary>
        /// Update Website Notification Details 
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>
        MessageEF UpdateNotification(AddNotificationModel objAddNotificationModel);
        /// <summary>
        /// Publish Website Notification Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        Task<MessageEF> PublishNotification(ViewNotificationModel objViewNotificationModel);
        /// <summary>
        /// Unpublish Website Notification Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        Task<MessageEF> UnpublishNotification(ViewNotificationModel objViewNotificationModel);
        /// <summary>
        /// Active Website Notification Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        Task<MessageEF> Active(ViewNotificationModel objViewNotificationModel);
        /// <summary>
        /// Bind Website Notification Type List Details 
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>
        Task<List<AddNotificationModel>> GetNotificationTypeList(AddNotificationModel objAddNotificationModel);
        /// <summary>
        /// Select Website Publish Notification Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        Task<List<ViewNotificationModel>> ViewWebsiteNotification(ViewNotificationModel objViewNotificationModel);
        /// <summary>
        /// Select Website Publish Notification Archive Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        Task<List<ViewNotificationModel>> ViewWebsiteNotificationArchive(ViewNotificationModel objViewNotificationModel);
        /// <summary>
        /// Select Top Website Publish Notification Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        Task<List<ViewNotificationModel>> ViewTopWebsiteNotification(ViewNotificationModel objViewNotificationModel);
    }
}
