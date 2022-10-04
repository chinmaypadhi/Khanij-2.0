// ***********************************************************************
//  Controller Name          : NotificationTypeController
//  Desciption               : Add,Select,Update,Delete Website Notification Type Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 12 Oct 2021
// ***********************************************************************
using HomeApi.Model.NotificationType;
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
    public class NotificationTypeController : ControllerBase
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        public INotificationTypeProvider _objINotificationTypeProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public NotificationTypeController(INotificationTypeProvider objINotificationTypeProvider)
        {
            _objINotificationTypeProvider = objINotificationTypeProvider;
        }
        /// <summary>
        /// Add Website Notification Type Details in view
        /// </summary>
        /// <param name="objAddNotificationTypeModel"></param>
        /// <returns></returns>     
        [HttpPost]
        public MessageEF Add(AddNotificationTypeModel objAddNotificationTypeModel)
        {
            return _objINotificationTypeProvider.AddNotificationType(objAddNotificationTypeModel);
        }
        /// <summary>
        /// Edit Website Notification Type Details in view
        /// </summary>
        /// <param name="objAddNotificationTypeModel"></param>
        /// <returns></returns>
        [HttpPost]
        public AddNotificationTypeModel Edit(AddNotificationTypeModel objAddNotificationTypeModel)
        {
            return _objINotificationTypeProvider.EditNotificationType(objAddNotificationTypeModel);
        }
        /// <summary>
        /// Select Website Notification Type Details in view
        /// </summary>
        /// <param name="objAddNotificationTypeModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ViewNotificationTypeModel>>> View(ViewNotificationTypeModel objViewNotificationTypeModel)
        {
            return await _objINotificationTypeProvider.ViewNotificationType(objViewNotificationTypeModel);
        }
        /// <summary>
        /// Delete Website Notification Type Details in view
        /// </summary>
        /// <param name="objAddNotificationTypeModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(ViewNotificationTypeModel objViewNotificationTypeModel)
        {
            return _objINotificationTypeProvider.DeleteNotificationType(objViewNotificationTypeModel);
        }
        /// <summary>
        /// Update Website Notification Type Details in view
        /// </summary>
        /// <param name="objAddNotificationTypeModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(AddNotificationTypeModel objAddNotificationTypeModel)
        {
            return _objINotificationTypeProvider.UpdateNotificationType(objAddNotificationTypeModel);
        }
    }
}
