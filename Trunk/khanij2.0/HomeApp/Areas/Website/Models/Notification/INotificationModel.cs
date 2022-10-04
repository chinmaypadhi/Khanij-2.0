// ***********************************************************************
//  Interface Name           : INotificationModel
//  Desciption               : Add,Select,Update,Delete Website Notification Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 07 Oct 2021
// ***********************************************************************
using HomeEF;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeApp.Models.Notification
{
    public interface INotificationModel
    {
        /// <summary>
        /// Add Website Notification Details 
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>
        MessageEF Add(AddNotificationModel objAddNotificationModel);
        /// <summary>
        /// Update Website Notification Details 
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>
        MessageEF Update(AddNotificationModel objAddNotificationModel);
        /// <summary>
        /// Edit Website Notification Details
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        AddNotificationModel Edit(AddNotificationModel objAddNotificationModel);
        /// <summary>
        /// Select Website Notification Details 
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>
        List<ViewNotificationModel> View(ViewNotificationModel objViewNotificationModel);
        /// <summary>
        /// Select Website Notification Archive Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        List<ViewNotificationModel> ViewArchive(ViewNotificationModel objViewNotificationModel);
        /// <summary>
        /// Delete Website Notification Details 
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>
        MessageEF Delete(ViewNotificationModel objViewNotificationModel);
        /// <summary>
        /// Archive Website Notification Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        MessageEF Archive(ViewNotificationModel objViewNotificationModel);
        /// <summary>
        /// Publish Website Notification Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        MessageEF Publish(ViewNotificationModel objViewNotificationModel);
        /// <summary>
        /// Unpublish Website Notification Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        MessageEF Unpublish(ViewNotificationModel objViewNotificationModel);
        /// <summary>
        /// Active Website Notification Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        MessageEF Active(ViewNotificationModel objViewNotificationModel);
        /// <summary>
        /// Bind Website Notification Type List Details 
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>
        List<AddNotificationModel> GetNotificationTypeList(AddNotificationModel objAddNotificationModel);
        /// <summary>
        /// Select Publish Website Notification Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        List<ViewNotificationModel> ViewWebsiteNotification(ViewNotificationModel objViewNotificationModel);
        /// <summary>
        /// Select Publish Website Notification Archive Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        List<ViewNotificationModel> ViewWebsiteNotificationArchive(ViewNotificationModel objViewNotificationModel);
        /// <summary>
        /// Select Top Publish Website Notification Active Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        List<ViewNotificationModel> ViewTopWebsiteNotification(ViewNotificationModel objViewNotificationModel);
    }
}
