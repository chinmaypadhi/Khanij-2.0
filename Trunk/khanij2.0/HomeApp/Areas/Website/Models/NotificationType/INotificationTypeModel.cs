// ***********************************************************************
//  Interface Name           : INotificationTypeModel
//  Desciption               : Add,Select,Update,Delete Website Notification Type Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 12 Oct 2021
// ***********************************************************************
using HomeEF;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Models.NotificationType
{
    public interface INotificationTypeModel
    {
        /// <summary>
        /// Add Website Notification Type Details 
        /// </summary>
        /// <param name="objAddNotificationTypeModel"></param>
        /// <returns></returns>
        MessageEF Add(AddNotificationTypeModel objAddNotificationTypeModel);
        /// <summary>
        /// Update Website Notification Type Details 
        /// </summary>
        /// <param name="objAddNotificationTypeModel"></param>
        /// <returns></returns>
        MessageEF Update(AddNotificationTypeModel objAddNotificationTypeModel);
        /// <summary>
        /// Edit Website Notification Type Details
        /// </summary>
        /// <param name="objViewNotificationTypeModel"></param>
        /// <returns></returns>
        AddNotificationTypeModel Edit(AddNotificationTypeModel objAddNotificationTypeModel);
        /// <summary>
        /// Select Website Notification Type Details 
        /// </summary>
        /// <param name="objAddNotificationTypeModel"></param>
        /// <returns></returns>
        Task<List<ViewNotificationTypeModel>> View(ViewNotificationTypeModel objViewNotificationTypeModel);
        /// <summary>
        /// Delete Website Notification Type Details 
        /// </summary>
        /// <param name="objAddNotificationTypeModel"></param>
        /// <returns></returns>
        MessageEF Delete(ViewNotificationTypeModel objViewNotificationTypeModel);
    }
}
