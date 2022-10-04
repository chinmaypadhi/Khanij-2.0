// ***********************************************************************
//  Interface Name           : IStaffDirectoryProvider
//  Desciption               : Add,Select,Update,Delete Website Staff Directory Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 20 Oct 2021
// ***********************************************************************
using HomeApi.Repository;
using HomeEF;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeApi.Model.StaffDirectory
{
    public interface IStaffDirectoryProvider
    {
        /// <summary>
        /// Add Website Staff Directory Details 
        /// </summary>
        /// <param name="objAddStaffDirectoryModel"></param>
        /// <returns></returns>
        MessageEF AddStaffDirectory(AddStaffDirectoryModel objAddStaffDirectoryModel);
        /// <summary>
        /// Select Website Staff Directory Details 
        /// </summary>
        /// <param name="objViewStaffDirectoryModel"></param>
        /// <returns></returns>
        Task<List<ViewStaffDirectoryModel>> ViewStaffDirectory(ViewStaffDirectoryModel objViewStaffDirectoryModel);
        /// <summary>
        /// Edit Website Staff Directory Details
        /// </summary>
        /// <param name="objAddStaffDirectoryModel"></param>
        /// <returns></returns>
        AddStaffDirectoryModel EditStaffDirectory(AddStaffDirectoryModel objAddStaffDirectoryModel);
        /// <summary>
        /// Delete Website Staff Directory Details 
        /// </summary>
        /// <param name="objAddStaffDirectoryModel"></param>
        /// <returns></returns>
        MessageEF DeleteStaffDirectory(ViewStaffDirectoryModel objViewStaffDirectoryModel);
        /// <summary>
        /// Update Website Staff Directory Details 
        /// </summary>
        /// <param name="objAddStaffDirectoryModel"></param>
        /// <returns></returns>
        MessageEF UpdateStaffDirectory(AddStaffDirectoryModel objAddStaffDirectoryModel);
        /// <summary>
        /// Bind Website Office Type List Details 
        /// </summary>
        /// <param name="objAddStaffDirectoryModel"></param>
        /// <returns></returns>
        Task<List<AddStaffDirectoryModel>> GetOfficeTypeList(AddStaffDirectoryModel objAddStaffDirectoryModel);
        /// <summary>
        /// Bind Publish Website Staff Directory Details 
        /// </summary>
        /// <param name="objViewStaffDirectoryModel"></param>
        /// <returns></returns>
        Task<List<ViewStaffDirectoryModel>> ViewPublishStaffDirectory(ViewStaffDirectoryModel objViewStaffDirectoryModel);
    }
}
