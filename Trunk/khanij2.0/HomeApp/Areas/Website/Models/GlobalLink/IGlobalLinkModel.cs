// ***********************************************************************
//  Interface Name           : IGlobalLinkModel
//  Desciption               : Add,Publish Website Global Link Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 01 Nov 2021
// ***********************************************************************
using HomeEF;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Models.GlobalLink
{
    public interface IGlobalLinkModel
    {
        /// <summary>
        /// Add Website Global Link Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        MessageEF Add(AddGlobalLinkModel objAddGlobalLinkModel);
        /// <summary>
        /// Bind Website Top Menu Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        AddGlobalLinkModel TopMenu(AddGlobalLinkModel objAddGlobalLinkModel);
        /// <summary>
        /// Bind Website Main Menu Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        AddGlobalLinkModel MainMenu(AddGlobalLinkModel objAddGlobalLinkModel);
        /// <summary>
        /// Bind Website Footer Menu Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        AddGlobalLinkModel FooterMenu(AddGlobalLinkModel objAddGlobalLinkModel);
        /// <summary>
        /// Select Website Global Link Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        List<AddGlobalLinkModel> GetPageList(AddGlobalLinkModel objAddGlobalLinkModel);
        /// <summary>
        /// Bind Website Menu Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        AddGlobalLinkModel WebsiteMenu(AddGlobalLinkModel objAddGlobalLinkModel);
        /// <summary>
        /// Bind Website Child Menu Details 
        /// </summary>
        /// <param name="objAddPageModel"></param>
        /// <returns></returns>
        List<AddPageModel> WebsiteChildMenu(AddPageModel objAddPageModel);
    }
}
