// ***********************************************************************
//  Interface Name           : INotificationTypeProvider
//  Desciption               : Add,Select,Update,Delete Website Notification Type Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 12 Oct 2021
// ***********************************************************************
using HomeApi.Repository;
using HomeEF;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeApi.Model.NotificationType
{
    public interface INotificationTypeProvider
    {
        /// <summary>
        /// Add Website Notification Type Details 
        /// </summary>
        /// <param name="objAddNotificationTypeModel"></param>
        /// <returns></returns>
        MessageEF AddNotificationType(AddNotificationTypeModel objAddNotificationTypeModel);
        /// <summary>
        /// Select Website Notification Type Details 
        /// </summary>
        /// <param name="objAddNotificationTypeModel"></param>
        /// <returns></returns>
        Task<List<ViewNotificationTypeModel>> ViewNotificationType(ViewNotificationTypeModel objViewNotificationTypeModel);
        /// <summary>
        /// Edit Website Notification Type Details
        /// </summary>
        /// <param name="objAddNotificationTypeModel"></param>
        /// <returns></returns>
        AddNotificationTypeModel EditNotificationType(AddNotificationTypeModel objAddNotificationTypeModel);
        /// <summary>
        /// Delete Website Notification Type Details 
        /// </summary>
        /// <param name="objAddNotificationTypeModel"></param>
        /// <returns></returns>
        MessageEF DeleteNotificationType(ViewNotificationTypeModel objViewNotificationTypeModel);
        /// <summary>
        /// Update Website Notification Type Details 
        /// </summary>
        /// <param name="objAddNotificationTypeModel"></param>
        /// <returns></returns>
        MessageEF UpdateNotificationType(AddNotificationTypeModel objAddNotificationTypeModel);
    }
}
