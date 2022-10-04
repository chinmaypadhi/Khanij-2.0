// ***********************************************************************
//  Controller Name          : NotificationController
//  Desciption               : Add,Select,Update,Delete Website Notification Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 07 Oct 2021
// ***********************************************************************
using HomeApi.Model.Notification;
using HomeEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class NotificationController : ControllerBase
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        public INotificationProvider _objINotificationProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public NotificationController(INotificationProvider objINotificationProvider)
        {
            _objINotificationProvider = objINotificationProvider;
        }
        /// <summary>
        /// Add Website Notification Details in view
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>     
        [HttpPost]
        public MessageEF Add(AddNotificationModel objAddNotificationModel)
        {
            return _objINotificationProvider.AddNotification(objAddNotificationModel);
        }
        /// <summary>
        /// Edit Website Notification Details in view
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public AddNotificationModel Edit(AddNotificationModel objAddNotificationModel)
        {
            return _objINotificationProvider.EditNotification(objAddNotificationModel);
        }
        /// <summary>
        /// Select Website Notification Details in view
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ViewNotificationModel>>> View(ViewNotificationModel objViewNotificationModel)
        {
            return await _objINotificationProvider.ViewNotification(objViewNotificationModel);
        }
        /// <summary>
        /// Select Website Notification Archive Details in view
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ViewNotificationModel>>> ViewArchive(ViewNotificationModel objViewNotificationModel)
        {
            return await _objINotificationProvider.ViewNotificationArchive(objViewNotificationModel);
        }
        /// <summary>
        /// Delete Website Notification Details in view
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(ViewNotificationModel objViewNotificationModel)
        {
            return _objINotificationProvider.DeleteNotification(objViewNotificationModel);
        }
        /// <summary>
        /// Archive Website Notification Details in view
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Archive(ViewNotificationModel objViewNotificationModel)
        {
            return await _objINotificationProvider.ArchiveNotification(objViewNotificationModel);
        }
        /// <summary>
        /// Update Website Notification Details in view
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(AddNotificationModel objAddNotificationModel)
        {
            return _objINotificationProvider.UpdateNotification(objAddNotificationModel);
        }
        /// <summary>
        /// Publish Website Notification Details in view
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Publish(ViewNotificationModel objViewNotificationModel)
        {
            return await _objINotificationProvider.PublishNotification(objViewNotificationModel);
        }
        /// <summary>
        /// Unpublish Website Notification Details in view
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Unpublish(ViewNotificationModel objViewNotificationModel)
        {
            return await _objINotificationProvider.UnpublishNotification(objViewNotificationModel);
        }
        /// <summary>
        /// Active Website Notification Details in view
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Active(ViewNotificationModel objViewNotificationModel)
        {
            return await _objINotificationProvider.Active(objViewNotificationModel);
        }
        /// <summary>
        /// Bind Website Notification Type List Details in view
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<AddNotificationModel>>> GetNotificationTypeList(AddNotificationModel objAddNotificationModel)
        {
            return await _objINotificationProvider.GetNotificationTypeList(objAddNotificationModel);
        }
        /// <summary>
        /// Select Publish Website Notification Details in view
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ViewNotificationModel>>> ViewWebsiteNotification(ViewNotificationModel objViewNotificationModel)
        {
            return await _objINotificationProvider.ViewWebsiteNotification(objViewNotificationModel);
        }
        /// <summary>
        /// Select Website Publish Notification Archive Details 
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ViewNotificationModel>>> ViewWebsiteNotificationArchive(ViewNotificationModel objViewNotificationModel)
        {
            return await _objINotificationProvider.ViewWebsiteNotificationArchive(objViewNotificationModel);
        }
        /// <summary>
        /// Select Top Publish Website Notification Archive Details in view
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ViewNotificationModel>>> ViewTopWebsiteNotification(ViewNotificationModel objViewNotificationModel)
        {
            return await _objINotificationProvider.ViewTopWebsiteNotification(objViewNotificationModel);
        }
    }
}
