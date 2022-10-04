// ***********************************************************************
//  Interface Name           : IBannerProvider
//  Desciption               : Add,View,Edit,Update,Delete Website Banner Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 22 Oct 2021
// ***********************************************************************
using HomeApi.Repository;
using HomeEF;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeApi.Model.Banner
{
    public interface IBannerProvider: IDisposable, IRepository
    {
        /// <summary>
        /// Add Website Banner Details 
        /// </summary>
        /// <param name="objAddBannerModel"></param>
        /// <returns></returns>
        MessageEF AddBanner(AddBannerModel objAddBannerModel);
        /// <summary>
        /// Select Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        Task<List<ViewBannerModel>> ViewBanner(ViewBannerModel objViewBannerModel);
        /// <summary>
        /// Select Website Banner Archive Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        Task<List<ViewBannerModel>> ViewBannerArchive(ViewBannerModel objViewBannerModel);
        /// <summary>
        /// Edit Website Banner Details
        /// </summary>
        /// <param name="objAddBannerModel"></param>
        /// <returns></returns>
        AddBannerModel EditBanner(AddBannerModel objAddBannerModel);
        /// <summary>
        /// Archive Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        Task<MessageEF> ArchiveBanner(ViewBannerModel objViewBannerModel);
        /// <summary>
        /// Delete Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        MessageEF DeleteBanner(ViewBannerModel objViewBannerModel);
        /// <summary>
        /// Update Website Banner Details 
        /// </summary>
        /// <param name="objAddBannerModel"></param>
        /// <returns></returns>
        MessageEF UpdateBanner(AddBannerModel objAddBannerModel);
        /// <summary>
        /// Update Website Banner Status Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        MessageEF UpdateStatus(AddBannerModel objAddBannerModel);
        /// <summary>
        /// Publish Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        Task<MessageEF> PublishBanner(ViewBannerModel objViewBannerModel);
        /// <summary>
        /// Unpublish Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        Task<MessageEF> UnpublishBanner(ViewBannerModel objViewBannerModel);
        /// <summary>
        /// Active Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        Task<MessageEF> Active(ViewBannerModel objViewBannerModel);
        /// <summary>
        /// Get Website Banner Sequence count Details 
        /// </summary>
        /// <param name="objAddBannerModel"></param>
        /// <returns></returns>
        Task<AddBannerModel> GetSequence(AddBannerModel objAddBannerModel);
        /// <summary>
        /// Select Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        Task<List<ViewBannerModel>> ViewWebsiteBanner(ViewBannerModel objViewBannerModel);
    }
}
