// ***********************************************************************
//  Interface Name           : IGlobalLinkProvider
//  Desciption               : Add Global link in Website Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 11 Nov 2021
// ***********************************************************************
using HomeApi.Repository;
using HomeEF;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeApi.Model.GlobalLink
{
    public interface IGlobalLinkProvider: IDisposable, IRepository
    {
        /// <summary>
        /// Add Website Global Link Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        MessageEF AddGlobalLink(AddGlobalLinkModel objAddGlobalLinkModel);
        /// <summary>
        /// Bind Website Top Menu Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        Task<AddGlobalLinkModel> TopMenu(AddGlobalLinkModel objAddGlobalLinkModel);
        /// <summary>
        /// Select Website Main Menu Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        Task<AddGlobalLinkModel> MainMenu(AddGlobalLinkModel objAddGlobalLinkModel);
        /// <summary>
        /// Select Website Footer Menu Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        Task<AddGlobalLinkModel> FooterMenu(AddGlobalLinkModel objAddGlobalLinkModel);
        /// <summary>
        /// Get Website Global Link Sequence count Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        Task<List<AddGlobalLinkModel>> GetPageList(AddGlobalLinkModel objAddGlobalLinkModel);
        /// <summary>
        /// Bind Website Menu Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        Task<AddGlobalLinkModel> WebsiteMenu(AddGlobalLinkModel objAddGlobalLinkModel);
        /// <summary>
        /// Bind Website Child Menu Details 
        /// </summary>
        /// <param name="objAddPageModel"></param>
        /// <returns></returns>
        Task<List<AddPageModel>> WebsiteChildMenu(AddPageModel objAddPageModel);
    }
}
