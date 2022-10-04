// ***********************************************************************
//  Interface Name           : ITenderModel
//  Desciption               : Add,Select,Update,Delete Website Tender Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 11 Oct 2021
// ***********************************************************************
using HomeEF;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace HomeApp.Areas.Website.Models.Tender
{
    public interface ITenderModel
    {
        /// <summary>
        /// Add Website Tender Details 
        /// </summary>
        /// <param name="objAddTenderModel"></param>
        /// <returns></returns>
        MessageEF Add(AddTenderModel objAddTenderModel);
        /// <summary>
        /// Update Website Tender Details 
        /// </summary>
        /// <param name="objAddTenderModel"></param>
        /// <returns></returns>
        MessageEF Update(AddTenderModel objAddTenderModel);
        /// <summary>
        /// Edit Website Tender Details
        /// </summary>
        /// <param name="objViewTenderModel"></param>
        /// <returns></returns>
        AddTenderModel Edit(AddTenderModel objAddTenderModel);
        /// <summary>
        /// Select Website Tender Details 
        /// </summary>
        /// <param name="objViewTenderModel"></param>
        /// <returns></returns>
        List<ViewTenderModel> View(ViewTenderModel objViewTenderModel);
        /// <summary>
        /// Delete Website Tender Details 
        /// </summary>
        /// <param name="objAddTenderModel"></param>
        /// <returns></returns>
        MessageEF Delete(ViewTenderModel objViewTenderModel);
        /// <summary>
        /// Select Active Website Tender Details 
        /// </summary>
        /// <param name="objViewTenderModel"></param>
        /// <returns></returns>
        List<ViewTenderModel> ViewWebsiteTenderActive(ViewTenderModel objViewTenderModel);
        /// <summary>
        /// Select Archive Website Tender Details 
        /// </summary>
        /// <param name="objViewTenderModel"></param>
        /// <returns></returns>
        List<ViewTenderModel> ViewWebsiteTenderArchive(ViewTenderModel objViewTenderModel);
        /// <summary>
        /// Select Top Active Website Tender Details 
        /// </summary>
        /// <param name="objViewTenderModel"></param>
        /// <returns></returns>
        List<ViewTenderModel> ViewTopWebsiteTender(ViewTenderModel objViewTenderModel);
    }
}
