// ***********************************************************************
//  Interface Name           : IBannerModel
//  Desciption               : Add,View,Edit,Update,Delete Website Banner Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 22 Oct 2021
// ***********************************************************************
using HomeEF;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Models.Banner
{
    public interface IBannerModel
    {
        /// <summary>
        /// Add Website Banner Details 
        /// </summary>
        /// <param name="objAddBannerModel"></param>
        /// <returns></returns>
        MessageEF Add(AddBannerModel objAddBannerModel);
        /// <summary>
        /// Update Website Banner Details 
        /// </summary>
        /// <param name="objAddBannerModel"></param>
        /// <returns></returns>
        MessageEF Update(AddBannerModel objAddBannerModel);
        /// <summary>
        /// Edit Website Banner Details
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        AddBannerModel Edit(AddBannerModel objAddBannerModel);
        /// <summary>
        /// Select Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        List<ViewBannerModel> View(ViewBannerModel objViewBannerModel);
        /// <summary>
        /// Select Website Banner Archive Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        List<ViewBannerModel> ViewArchive(ViewBannerModel objViewBannerModel);
        /// <summary>
        /// Delete Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        MessageEF Delete(ViewBannerModel objViewBannerModel);
        /// <summary>
        /// Archive Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        MessageEF Archive(ViewBannerModel objViewBannerModel);
        /// <summary>
        /// Publish Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        MessageEF Publish(ViewBannerModel objViewGalleryModel);
        /// <summary>
        /// Unpublish Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        MessageEF Unpublish(ViewBannerModel objViewBannerModel);
        /// <summary>
        /// Active Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        MessageEF Active(ViewBannerModel objViewBannerModel);
        /// <summary>
        /// Bind Website Banner Type List Details 
        /// </summary>
        /// <param name="objAddBannerModel"></param>
        /// <returns></returns>
        AddBannerModel GetSequence(AddBannerModel objAddBannerModel);
        /// <summary>
        /// Update Website Banner Status Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        MessageEF UpdateStatus(AddBannerModel objAddBannerModel);
        /// <summary>
        /// Select Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        List<ViewBannerModel> ViewWebsiteBanner(ViewBannerModel objViewBannerModel);
        string Test(ViewBannerModel objViewBannerModel);
    }
}
