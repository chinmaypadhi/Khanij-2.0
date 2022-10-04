// ***********************************************************************
//  Controller Name          : GlobalLinkController
//  Desciption               : Add,Publish Website Global Link Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 11 Nov 2021
// ***********************************************************************
using HomeApi.Model.GlobalLink;
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
    //[Authorize]
    public class GlobalLinkController : ControllerBase
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        public IGlobalLinkProvider _objIGlobalLinkProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public GlobalLinkController(IGlobalLinkProvider objIGlobalLinkProvider)
        {
            _objIGlobalLinkProvider = objIGlobalLinkProvider;
        }
        /// <summary>
        /// Add Website Global Link Details in view
        /// </summary>
        /// <param name="objAddNotificationModel"></param>
        /// <returns></returns>     
        [HttpPost]
        public MessageEF Add(AddGlobalLinkModel objAddGlobalLinkModel)
        {
            return _objIGlobalLinkProvider.AddGlobalLink(objAddGlobalLinkModel);
        }
        /// <summary>
        /// Bind Website Top Menu Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<AddGlobalLinkModel>> TopMenu(AddGlobalLinkModel objAddGlobalLinkModel)
        {
            return await _objIGlobalLinkProvider.TopMenu(objAddGlobalLinkModel);
        }
        /// <summary>
        /// Bind Website Main Menu Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<AddGlobalLinkModel>> MainMenu(AddGlobalLinkModel objAddGlobalLinkModel)
        {
            return await _objIGlobalLinkProvider.MainMenu(objAddGlobalLinkModel);
        }
        /// <summary>
        /// Bind Website Footer Menu Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<AddGlobalLinkModel>> FooterMenu(AddGlobalLinkModel objAddGlobalLinkModel)
        {
            return await _objIGlobalLinkProvider.FooterMenu(objAddGlobalLinkModel);
        }
        /// <summary>
        /// Bind Website Page Details in view
        /// </summary>
        /// <param name="AddGlobalLinkModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<AddGlobalLinkModel>>> GetPageList(AddGlobalLinkModel objAddGlobalLinkModel)
        {
            return await _objIGlobalLinkProvider.GetPageList(objAddGlobalLinkModel);
        }
        /// <summary>
        /// Bind Website Menu Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<AddGlobalLinkModel>> WebsiteMenu(AddGlobalLinkModel objAddGlobalLinkModel)
        {
            return await _objIGlobalLinkProvider.WebsiteMenu(objAddGlobalLinkModel);
        }
        /// <summary>
        /// Bind Website Child Menu Details 
        /// </summary>
        /// <param name="objAddPageModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<AddPageModel>>> WebsiteChildMenu(AddPageModel objAddPageModel)
        {
            return await _objIGlobalLinkProvider.WebsiteChildMenu(objAddPageModel);
        }
    }
}
