// ***********************************************************************
//  Interface Name           : IPageModel
//  Desciption               : Add,Select,Update,Delete Website Page Details 
//  Created By               : Prakash Chandra Biswal
//  Created On               : 28 Oct 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeEF;

namespace HomeApp.Areas.Website.Models.Page
{
    public interface IPageModel
    {
        /// <summary>
        /// To Add Page Details
        /// </summary>
        /// <param name="addPageModel"></param>
        /// <returns></returns>
        MessageEF Add(AddPageModel addPageModel);
        /// <summary>
        /// To Update Page Details
        /// </summary>
        /// <param name="addPageModel"></param>
        /// <returns></returns>
        MessageEF Update(AddPageModel addPageModel);
        /// <summary>
        /// To Delete Page
        /// </summary>
        /// <param name="viewPageModel"></param>
        /// <returns></returns>
        MessageEF Delete(ViewPageModel viewPageModel);
        /// <summary>
        /// To Edit Page Details
        /// </summary>
        /// <param name="addPageModel"></param>
        /// <returns></returns>
        AddPageModel Edit(AddPageModel addPageModel);
        /// <summary>
        /// To View Page Details
        /// </summary>
        /// <param name="viewPageModel"></param>
        /// <returns></returns>
        Task<List<ViewPageModel>> View(ViewPageModel viewPageModel);
        /// <summary>
        /// To View Page in Archive
        /// </summary>
        /// <param name="viewPageModel"></param>
        /// <returns></returns>
        List<ViewPageModel> ViewArchive(ViewPageModel viewPageModel);
        /// <summary>
        /// To Archive Page
        /// </summary>
        /// <param name="viewPageModel"></param>
        /// <returns></returns>
        MessageEF Archive(ViewPageModel viewPageModel);
        /// <summary>
        /// To active page from Archive
        /// </summary>
        /// <param name="viewPageModel"></param>
        /// <returns></returns>
        MessageEF Active(ViewPageModel viewPageModel);
        /// <summary>
        /// To Get Plugin Type List
        /// </summary>
        /// <param name="addPageModel"></param>
        /// <returns></returns>
        Task<List<AddPageModel>> PlugnTypeList(AddPageModel addPageModel);
    }
}
