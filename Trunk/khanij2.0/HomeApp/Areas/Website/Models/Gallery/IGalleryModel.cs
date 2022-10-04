// ***********************************************************************
//  Interface Name           : IGalleryModel
//  Desciption               : Add,Select,Update,Delete Website Gallery Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 28 Oct 2021
// ***********************************************************************
using HomeEF;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Models.Gallery
{
    public interface IGalleryModel
    {

        /// <summary>
        /// Add Website Gallery Details 
        /// </summary>
        /// <param name="obAddGalleryModel"></param>
        /// <returns></returns>
        MessageEF Add(AddGalleryModel obAddGalleryModel);
        /// <summary>
        /// Update Website Gallery Details 
        /// </summary>
        /// <param name="obAddGalleryModel"></param>
        /// <returns></returns>
        MessageEF Update(AddGalleryModel obAddGalleryModel);
        /// <summary>
        /// Edit Website Gallery Details
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        AddGalleryModel Edit(AddGalleryModel obAddGalleryModel);
        /// <summary>
        /// Select Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        List<ViewGalleryModel> View(ViewGalleryModel objViewGalleryModel);
        /// <summary>
        /// Select Website Gallery Archive Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        List<ViewGalleryModel> ViewArchive(ViewGalleryModel objViewGalleryModel);
        /// <summary>
        /// Delete Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        MessageEF Delete(ViewGalleryModel objViewGalleryModel);
        /// <summary>
        /// Archive Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        MessageEF Archive(ViewGalleryModel objViewGalleryModel);
        /// <summary>
        /// Publish Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        MessageEF Publish(ViewGalleryModel objViewGalleryModel);
        /// <summary>
        /// Unpublish Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        MessageEF Unpublish(ViewGalleryModel objViewGalleryModel);
        /// <summary>
        /// Active Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        MessageEF Active(ViewGalleryModel objViewGalleryModel);
        /// <summary>
        /// Bind Website Gallery Type List Details 
        /// </summary>
        /// <param name="obAddGalleryModel"></param>
        /// <returns></returns>
        AddGalleryModel GetSequence(AddGalleryModel obAddGalleryModel);
        /// <summary>
        /// Update Website Gallery Status Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        MessageEF UpdateStatus(AddGalleryModel obAddGalleryModel);
        /// <summary>
        /// Select Website Gallery Details 
        /// </summary>
        /// <param name="objViewGalleryModel"></param>
        /// <returns></returns>
        List<ViewGalleryModel> ViewWebsiteGallery(ViewGalleryModel objViewGalleryModel);
    }
}
