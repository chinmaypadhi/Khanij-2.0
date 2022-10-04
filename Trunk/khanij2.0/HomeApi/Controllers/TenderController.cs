// ***********************************************************************
//  Controller Name          : TenderController
//  Desciption               : Add,Select,Update,Delete Website Tender Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 11 Oct 2021
// ***********************************************************************
using HomeApi.Model.Tender;
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
    public class TenderController : ControllerBase
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        public ITenderProvider _objITenderProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public TenderController(ITenderProvider objITenderProvider)
        {
            _objITenderProvider = objITenderProvider;
        }
        /// <summary>
        /// Add Website Tender Details in view
        /// </summary>
        /// <param name="objAddTenderModel"></param>
        /// <returns></returns>     
        [HttpPost]
        public MessageEF Add(AddTenderModel objAddTenderModel)
        {
            return _objITenderProvider.AddTender(objAddTenderModel);
        }
        /// <summary>
        /// Edit Website Tender Details in view
        /// </summary>
        /// <param name="objAddTenderModel"></param>
        /// <returns></returns>
        [HttpPost]
        public AddTenderModel Edit(AddTenderModel objAddTenderModel)
        {
            return _objITenderProvider.EditTender(objAddTenderModel);
        }
        /// <summary>
        /// Select Website Tender Details in view
        /// </summary>
        /// <param name="objAddTenderModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ViewTenderModel>>> View(ViewTenderModel objViewTenderModel)
        {
            return await _objITenderProvider.ViewTender(objViewTenderModel);
        }
        /// <summary>
        /// Delete Website Tender Details in view
        /// </summary>
        /// <param name="objAddTenderModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(ViewTenderModel objViewNotificationModel)
        {
            return _objITenderProvider.DeleteTender(objViewNotificationModel);
        }
        /// <summary>
        /// Update Website Tender Details in view
        /// </summary>
        /// <param name="objAddTenderModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(AddTenderModel objAddTenderModel)
        {
            return _objITenderProvider.UpdateTender(objAddTenderModel);
        }
        /// <summary>
        /// Select Active Website Tender Details in view
        /// </summary>
        /// <param name="objViewTenderModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ViewTenderModel>>> ViewWebsiteTenderActive(ViewTenderModel objViewTenderModel)
        {
            return await _objITenderProvider.ViewWebsiteTenderActive(objViewTenderModel);
        }
        /// <summary>
        /// Select Archive Website Tender Details in view
        /// </summary>
        /// <param name="objViewTenderModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ViewTenderModel>>> ViewWebsiteTenderArchive(ViewTenderModel objViewTenderModel)
        {
            return await _objITenderProvider.ViewWebsiteTenderArchive(objViewTenderModel);
        }
        /// <summary>
        /// Select Top Active Website Tender Details in view
        /// </summary>
        /// <param name="objViewTenderModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ViewTenderModel>>> ViewTopWebsiteTender(ViewTenderModel objViewTenderModel)
        {
            return await _objITenderProvider.ViewTopWebsiteTender(objViewTenderModel);
        }
    }
}
