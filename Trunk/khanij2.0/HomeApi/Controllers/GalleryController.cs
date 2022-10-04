// ***********************************************************************
//  Controller Name          : GalleryController
//  Desciption               : Add,Select,Update,Delete Website Gallery Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 28 Oct 2021
// ***********************************************************************
using HomeApi.Model.Gallery;
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
    public class GalleryController : ControllerBase
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        public IGalleryProvider _objIGalleryProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public GalleryController(IGalleryProvider objIGalleryProvider)
        {
            _objIGalleryProvider = objIGalleryProvider;
        }
        /// <summary>
        /// Add Website Gallery Details in view
        /// </summary>
        /// <param name="objAddGalleryModel"></param>
        /// <returns></returns>     
        [HttpPost]
        public async Task<MessageEF> Add(AddGalleryModel objAddGalleryModel)
        {
            return await _objIGalleryProvider.AddGallery(objAddGalleryModel);
        }
        /// <summary>
        /// Edit Website Gallery Details in view
        /// </summary>
        /// <param name="objAddGalleryModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<AddGalleryModel> Edit(AddGalleryModel objAddGalleryModel)
        {
            return await _objIGalleryProvider.EditGallery(objAddGalleryModel);
        }
        /// <summary>
        /// Select Website Gallery Details in view
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ViewGalleryModel>>> View(ViewGalleryModel objViewGalleryModel)
        {
            return await _objIGalleryProvider.ViewGallery(objViewGalleryModel);
        }
        /// <summary>
        /// Select Website Gallery Archive Details in view
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ViewGalleryModel>>> ViewArchive(ViewGalleryModel objViewGalleryModel)
        {
            return await _objIGalleryProvider.ViewGalleryArchive(objViewGalleryModel);
        }
        /// <summary>
        /// Delete Website Gallery Details in view
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Delete(ViewGalleryModel objViewGalleryModel)
        {
            return await _objIGalleryProvider.DeleteGallery(objViewGalleryModel);
        }
        /// <summary>
        /// Archive Website Gallery Details in view
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Archive(ViewGalleryModel objViewGalleryModel)
        {
            return await _objIGalleryProvider.ArchiveGallery(objViewGalleryModel);
        }
        /// <summary>
        /// Update Website Gallery Details in view
        /// </summary>
        /// <param name="objAddGalleryModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Update(AddGalleryModel objAddGalleryModel)
        {
            return await _objIGalleryProvider.UpdateGallery(objAddGalleryModel);
        }
        /// <summary>
        /// Publish Website Gallery Details in view
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Publish(ViewGalleryModel objViewGalleryModel)
        {
            return await _objIGalleryProvider.PublishGallery(objViewGalleryModel);
        }
        /// <summary>
        /// Unpublish Website Gallery Details in view
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Unpublish(ViewGalleryModel objViewGalleryModel)
        {
            return await _objIGalleryProvider.UnpublishGallery(objViewGalleryModel);
        }
        /// <summary>
        /// Active Website Gallery Details in view
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Active(ViewGalleryModel objViewGalleryModel)
        {
            return await _objIGalleryProvider.Active(objViewGalleryModel);
        }
        /// <summary>
        /// Bind Website Gallery Sequence count Details in view
        /// </summary>
        /// <param name="objAddGalleryModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<AddGalleryModel>> GetSequence(AddGalleryModel objAddGalleryModel)
        {
            return await _objIGalleryProvider.GetSequence(objAddGalleryModel);
        }
        /// <summary>
        /// Select Website Gallery Details in view
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ViewGalleryModel>>> ViewWebsiteGallery(ViewGalleryModel objViewGalleryModel)
        {
            return await _objIGalleryProvider.ViewWebsiteGallery(objViewGalleryModel);
        }
    }
}
