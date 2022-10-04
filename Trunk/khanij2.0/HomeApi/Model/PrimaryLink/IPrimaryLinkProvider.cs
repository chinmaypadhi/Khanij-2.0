
// ***********************************************************************
//  Interface Name           : IPrimaryLinkProvider
//  Desciption               : Add Primary link in Website Details 
//  Created By               : Prakash Chandra Biswal
//  Created On               : 2 Nov 2021
// ***********************************************************************using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeEF;

namespace HomeApi.Model.PrimaryLink
{
    public interface IPrimaryLinkProvider:IDisposable
    {
        /// <summary>
        /// To add Primary Links
        /// </summary>
        /// <param name="addPrimaryLinkModel"></param>
        /// <returns></returns>
        MessageEF AddPrimarylLink(AddPrimaryLinkModel  addPrimaryLinkModel);
        /// <summary>
        /// To Bind About Us Details
        /// </summary>
        /// <param name="addPrimaryLinkModel"></param>
        /// <returns></returns>
        Task<AddPrimaryLinkModel> AboutUs(AddPrimaryLinkModel addPrimaryLinkModel);
       /// <summary>
       /// For Registration Link
       /// </summary>
       /// <param name="addPrimaryLinkModel"></param>
       /// <returns></returns>
        Task<AddPrimaryLinkModel> Registrations(AddPrimaryLinkModel addPrimaryLinkModel);
        /// <summary>
        /// To Bind Statistical Reports 
        /// </summary>
        /// <param name="addPrimaryLinkModel"></param>
        /// <returns></returns>
        Task<AddPrimaryLinkModel> StatisticalReports(AddPrimaryLinkModel addPrimaryLinkModel);
        /// <summary>
        /// To Get Page Lists 
        /// </summary>
        /// <param name="addPrimaryLinkModel"></param>
        /// <returns></returns>
        Task<List<AddPrimaryLinkModel>> GetPageList(AddPrimaryLinkModel addPrimaryLinkModel);
        /// <summary>
        /// To Bind global links in dropdown
        /// </summary>
        /// <param name="addPrimaryLinkModel"></param>
        /// <returns></returns>
        Task<List<AddPrimaryLinkModel>> GetGlobalLinkList(AddPrimaryLinkModel addPrimaryLinkModel);
    }
}
