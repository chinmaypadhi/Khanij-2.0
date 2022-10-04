// ***********************************************************************
//  Class Name               : IPrimaryLinkModel
//  Desciption               : Add,Publish Website Primary Link Details 
//  Created By               : Prakash Chandra Biswal
//  Created On               : 02 Nov 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeEF;


namespace HomeApp.Areas.Website.Models.PrimaryLink
{
    public interface IPrimaryLinkModel
    {
        /// <summary>
        /// To Add Primary Link Details
        /// </summary>
        /// <param name="addPrimaryLinkModel"></param>
        /// <returns></returns>
        MessageEF Add(AddPrimaryLinkModel addPrimaryLinkModel);
        /// <summary>
        /// To Bind About Us Submenus
        /// </summary>
        /// <param name="addPrimaryLinkModel"></param>
        /// <returns></returns>
        AddPrimaryLinkModel AboutUs(AddPrimaryLinkModel addPrimaryLinkModel);
        /// <summary>
        /// To Bind Registration Submenus
        /// </summary>
        /// <param name="addPrimaryLinkModel"></param>
        /// <returns></returns>
        AddPrimaryLinkModel Registrations(AddPrimaryLinkModel addPrimaryLinkModel);
        /// <summary>
        /// To Bind Statistical Reports
        /// </summary>
        /// <param name="addPrimaryLinkModel"></param>
        /// <returns></returns>
        AddPrimaryLinkModel StatisticalReports(AddPrimaryLinkModel addPrimaryLinkModel);
        /// <summary>
        /// To Bind page List
        /// </summary>
        /// <param name="AddPrimaryLinkModel"></param>
        /// <returns></returns>
        List<AddPrimaryLinkModel> GetPageList(AddPrimaryLinkModel AddPrimaryLinkModel);
        /// <summary>
        /// To Get Global Link List of Main Menu
        /// </summary>
        /// <param name="addPrimaryLinkModel"></param>
        /// <returns></returns>
        Task<List<AddPrimaryLinkModel>> GetGlobalLinkList(AddPrimaryLinkModel addPrimaryLinkModel);
    }
    
}
