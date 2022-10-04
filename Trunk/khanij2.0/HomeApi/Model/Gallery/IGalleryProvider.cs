// ***********************************************************************
//  Interface Name           : IGalleryProvider
//  Desciption               : Add,Select,Update,Delete Website Gallery Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 28 Oct 2021
// ***********************************************************************
using HomeApi.Repository;
using HomeEF;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeApi.Model.Gallery
{
    public interface IGalleryProvider: IDisposable, IRepository
    {
        /// <summary>
        /// Add Website Gallery Details 
        /// </summary>
        /// <param name="objAddGalleryModel"></param>
        /// <returns></returns>
        Task<MessageEF> AddGallery(AddGalleryModel objAddGalleryModel);
        /// <summary>
        /// Select Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        Task<List<ViewGalleryModel>> ViewGallery(ViewGalleryModel objViewGalleryModel);
        /// <summary>
        /// Select Website Gallery Archive Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        Task<List<ViewGalleryModel>> ViewGalleryArchive(ViewGalleryModel objViewGalleryModel);
        /// <summary>
        /// Edit Website Gallery Details
        /// </summary>
        /// <param name="objAddGalleryModel"></param>
        /// <returns></returns>
        Task<AddGalleryModel> EditGallery(AddGalleryModel objAddGalleryModel);
        /// <summary>
        /// Archive Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        Task<MessageEF> ArchiveGallery(ViewGalleryModel objViewGalleryModel);
        /// <summary>
        /// Delete Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        Task<MessageEF> DeleteGallery(ViewGalleryModel objViewGalleryModel);
        /// <summary>
        /// Update Website Gallery Details 
        /// </summary>
        /// <param name="objAddGalleryModel"></param>
        /// <returns></returns>
        Task<MessageEF> UpdateGallery(AddGalleryModel objAddGalleryModel);
        /// <summary>
        /// Publish Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        Task<MessageEF> PublishGallery(ViewGalleryModel objViewGalleryModel);
        /// <summary>
        /// Unpublish Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        Task<MessageEF> UnpublishGallery(ViewGalleryModel objViewGalleryModel);
        /// <summary>
        /// Active Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        Task<MessageEF> Active(ViewGalleryModel objViewGalleryModel);
        /// <summary>
        /// Bind Website Gallery Details 
        /// </summary>
        /// <param name="objAddGalleryModel"></param>
        /// <returns></returns>
        Task<AddGalleryModel> GetSequence(AddGalleryModel objAddGalleryModel);
        /// <summary>
        /// Select Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        Task<List<ViewGalleryModel>> ViewWebsiteGallery(ViewGalleryModel objViewGalleryModel);
    }
}
