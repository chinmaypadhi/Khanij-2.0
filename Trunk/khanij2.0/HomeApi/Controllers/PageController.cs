// ***********************************************************************
//  Controller Name          : PageController
//  Desciption               : Add,Select,Update,Delete Website Page Details 
//  Created By               : Prakash Chandra Biswal
//  Created On               : 28 Oct 2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeApi.Model.Page;
using HomeEF;

namespace HomeApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = true)]
    public class PageController : Controller
    {
        /// <summary>
        /// Global Object & Variable declaration 
        /// </summary>
        public IPageProvider _objPageProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="pageProvider"></param>
        public PageController(IPageProvider pageProvider)
        {
            _objPageProvider = pageProvider;
        }
        /// <summary>
        /// To Add Page Details
        /// </summary>
        /// <param name="addPageModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(AddPageModel addPageModel)
        {
            return _objPageProvider.AddPage(addPageModel);
        }
        /// <summary>
        /// To Edit Page Details
        /// </summary>
        /// <param name="addPageModel"></param>
        /// <returns></returns>
        [HttpPost]
        public AddPageModel Edit(AddPageModel addPageModel)
        {
            return _objPageProvider.EditPage(addPageModel);
        }
        /// <summary>
        /// To View Page in Archive
        /// </summary>
        /// <param name="viewPageModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ViewPageModel>>> ViewArchive(ViewPageModel viewPageModel)
        {
            return await _objPageProvider.ViewPageOnArchive(viewPageModel);
        }
        /// <summary>
        /// To Archive Page 
        /// </summary>
        /// <param name="viewPageModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MessageEF>> Archive(ViewPageModel viewPageModel)
        {
            return await _objPageProvider.ArchivePage(viewPageModel);
        }
        /// <summary>
        /// To View Page Details
        /// </summary>
        /// <param name="viewPageModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ViewPageModel>>> View(ViewPageModel viewPageModel)
        {
            return await _objPageProvider.ViewPage(viewPageModel);
        }

        /// <summary>
        /// To Delete Page Details
        /// </summary>
        /// <param name="viewPageModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(ViewPageModel viewPageModel)
        {
            return _objPageProvider.DeletePage(viewPageModel);
        }
        /// <summary>
        /// To active page from Archive
        /// </summary>
        /// <param name="viewPageModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Active(ViewPageModel viewPageModel)
        {
            return await _objPageProvider.Active(viewPageModel);
        }
        /// <summary>
        /// To Update Page Details
        /// </summary>
        /// <param name="addPageModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(AddPageModel addPageModel)
        {
            return _objPageProvider.UpdatePage(addPageModel);
        }
        /// <summary>
        /// To Get Plugin Type List
        /// </summary>
        /// <param name="addPageModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<AddPageModel>>> GetPluginTypeList(AddPageModel addPageModel)
        {
            return await _objPageProvider.GetPluginTypeList(addPageModel);
        }
    }
}
