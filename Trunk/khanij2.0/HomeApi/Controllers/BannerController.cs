// ***********************************************************************
//  Controller Name          : BannerController
//  Desciption               : Add,View,Edit,Update,Delete Website Banner Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 22 Oct 2021
// ***********************************************************************
using HomeApi.Model.Banner;
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
    public class BannerController : ControllerBase
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        public IBannerProvider _objIBannerProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public BannerController(IBannerProvider objIBannerProvider)
        {
            _objIBannerProvider = objIBannerProvider;
        }
        /// <summary>
        /// Add Website Banner Details in view
        /// </summary>
        /// <param name="objAddBannerModel"></param>
        /// <returns></returns>     
        [HttpPost]
        public MessageEF Add(AddBannerModel objAddBannerModel)
        {
            return _objIBannerProvider.AddBanner(objAddBannerModel);
        }
        /// <summary>
        /// Edit Website Banner Details in view
        /// </summary>
        /// <param name="objAddBannerModel"></param>
        /// <returns></returns>
        [HttpPost]
        public AddBannerModel Edit(AddBannerModel objAddBannerModel)
        {
            return _objIBannerProvider.EditBanner(objAddBannerModel);
        }
        /// <summary>
        /// Select Website Banner Details in view
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ViewBannerModel>>> View(ViewBannerModel objViewBannerModel)
        {
            return await _objIBannerProvider.ViewBanner(objViewBannerModel);
        }
        /// <summary>
        /// Select Website Banner Archive Details in view
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ViewBannerModel>>> ViewArchive(ViewBannerModel objViewBannerModel)
        {
            return await _objIBannerProvider.ViewBannerArchive(objViewBannerModel);
        }
        /// <summary>
        /// Delete Website Banner Details in view
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(ViewBannerModel objViewBannerModel)
        {
            return _objIBannerProvider.DeleteBanner(objViewBannerModel);
        }
        /// <summary>
        /// Archive Website Banner Details in view
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Archive(ViewBannerModel objViewBannerModel)
        {
            return await _objIBannerProvider.ArchiveBanner(objViewBannerModel);
        }
        /// <summary>
        /// Update Website Banner Details in view
        /// </summary>
        /// <param name="objAddBannerModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(AddBannerModel objAddBannerModel)
        {
            return _objIBannerProvider.UpdateBanner(objAddBannerModel);
        }
        /// <summary>
        /// Update Website Banner Status Details in view
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF UpdateStatus(AddBannerModel objAddBannerModel)
        {
            return _objIBannerProvider.UpdateStatus(objAddBannerModel);
        }
        /// <summary>
        /// Publish Website Banner Details in view
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Publish(ViewBannerModel objViewBannerModel)
        {
            return await _objIBannerProvider.PublishBanner(objViewBannerModel);
        }
        /// <summary>
        /// Unpublish Website Banner Details in view
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Unpublish(ViewBannerModel objViewBannerModel)
        {
            return await _objIBannerProvider.UnpublishBanner(objViewBannerModel);
        }
        /// <summary>
        /// Active Website Banner Details in view
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Active(ViewBannerModel objViewBannerModel)
        {
            return await _objIBannerProvider.Active(objViewBannerModel);
        }
        /// <summary>
        /// Bind Website Banner Sequence count Details in view
        /// </summary>
        /// <param name="objAddBannerModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<AddBannerModel>> GetSequence(AddBannerModel objAddBannerModel)
        {
            return await _objIBannerProvider.GetSequence(objAddBannerModel);
        }
        /// <summary>
        /// Select Website Banner Details in view
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ViewBannerModel>>> ViewWebsiteBanner(ViewBannerModel objViewBannerModel)
        {
            return await _objIBannerProvider.ViewWebsiteBanner(objViewBannerModel);
        }
    }
}
