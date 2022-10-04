// ***********************************************************************
//  Interface Name           : ITenderProvider
//  Desciption               : Add,Select,Update,Delete Website Tender Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 11 Oct 2021
// ***********************************************************************
using HomeApi.Repository;
using HomeEF;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeApi.Model.Tender
{
    public interface ITenderProvider
    {
        /// <summary>
        /// Add Website Tender Details 
        /// </summary>
        /// <param name="objAddTenderModel"></param>
        /// <returns></returns>
        MessageEF AddTender(AddTenderModel objAddTenderModel);
        /// <summary>
        /// Select Website Tender Details 
        /// </summary>
        /// <param name="objViewTenderModel"></param>
        /// <returns></returns>
        Task<List<ViewTenderModel>> ViewTender(ViewTenderModel objViewTenderModel);
        /// <summary>
        /// Edit Website Tender Details
        /// </summary>
        /// <param name="objAddTenderModel"></param>
        /// <returns></returns>
        AddTenderModel EditTender(AddTenderModel objAddTenderModel);
        /// <summary>
        /// Delete Website Tender Details 
        /// </summary>
        /// <param name="objAddTenderModel"></param>
        /// <returns></returns>
        MessageEF DeleteTender(ViewTenderModel objViewTenderModel);
        /// <summary>
        /// Update Website Tender Details 
        /// </summary>
        /// <param name="objAddTenderModel"></param>
        /// <returns></returns>
        MessageEF UpdateTender(AddTenderModel objAddTenderModel);
        /// <summary>
        /// Select Active Website Tender Details 
        /// </summary>
        /// <param name="objViewTenderModel"></param>
        /// <returns></returns>
        Task<List<ViewTenderModel>> ViewWebsiteTenderActive(ViewTenderModel objViewTenderModel);
        /// <summary>
        /// Select Archive Website Tender Details 
        /// </summary>
        /// <param name="objViewTenderModel"></param>
        /// <returns></returns>
        Task<List<ViewTenderModel>> ViewWebsiteTenderArchive(ViewTenderModel objViewTenderModel);
        /// <summary>
        /// Select Top 8 Active Website Tender Details 
        /// </summary>
        /// <param name="objViewTenderModel"></param>
        /// <returns></returns>
        Task<List<ViewTenderModel>> ViewTopWebsiteTender(ViewTenderModel objViewTenderModel);
    }
}
