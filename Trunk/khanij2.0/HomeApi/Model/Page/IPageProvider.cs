// ***********************************************************************
//  Interface Name           : IPageProvider
//  Desciption               : Add,Select,Update,Delete Website Page Details 
//  Created By               : Prakash Chandra Biswal
//  Created On               : 28 Oct 2021
// ***********************************************************************
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using HomeEF;

namespace HomeApi.Model.Page
{
    public interface IPageProvider : IDisposable
    {
        /// <summary>
        /// To Add AddPage Details
        /// </summary>
        /// <param name="addPageModel"></param>
        /// <returns></returns>
        MessageEF AddPage(AddPageModel addPageModel);
        /// <summary>
        /// To View Page Details
        /// </summary>
        /// <param name="viewPageModel"></param>
        /// <returns></returns>
        Task<List<ViewPageModel>> ViewPage(ViewPageModel viewPageModel);
        /// <summary>
        /// To View Page in Archive
        /// </summary>
        /// <param name="viewPageModel"></param>
        /// <returns></returns>
        Task<List<ViewPageModel>> ViewPageOnArchive(ViewPageModel viewPageModel);
        /// <summary>
        /// To Archive Page 
        /// </summary>
        /// <param name="viewPageModel"></param>
        /// <returns></returns>
        Task<MessageEF> ArchivePage(ViewPageModel viewPageModel);
        /// <summary>
        /// To Edit Page Details
        /// </summary>
        /// <param name="addPageModel"></param>
        /// <returns></returns>
        AddPageModel EditPage(AddPageModel addPageModel);
        /// <summary>
        /// To Delete Page Details
        /// </summary>
        /// <param name="viewPageModel"></param>
        /// <returns></returns>
        MessageEF DeletePage(ViewPageModel viewPageModel);
        /// <summary>
        /// To active page from Archive
        /// </summary>
        /// <param name="viewPageModel"></param>
        /// <returns></returns>
        Task<MessageEF> Active(ViewPageModel viewPageModel);
        /// <summary>
        /// To Update Page Details
        /// </summary>
        /// <param name="addPageModel"></param>
        /// <returns></returns>
        MessageEF UpdatePage(AddPageModel addPageModel);
        /// <summary>
        /// To get Plugintypes
        /// </summary>
        Task<List<AddPageModel>> GetPluginTypeList(AddPageModel addPageModel);
    }
}
