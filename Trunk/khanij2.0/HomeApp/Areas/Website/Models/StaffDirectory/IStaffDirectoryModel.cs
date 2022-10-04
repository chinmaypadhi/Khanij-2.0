// ***********************************************************************
//  Interface Name           : IStaffDirectoryModel
//  Desciption               : Add,Select,Update,Delete Website Staff Directory Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 20 Oct 2021
// ***********************************************************************
using HomeEF;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace HomeApp.Areas.Website.Models.StaffDirectory
{
    public interface IStaffDirectoryModel
    {
        /// <summary>
        /// Add Website Staff Directory Details 
        /// </summary>
        /// <param name="objAddStaffDirectoryModel"></param>
        /// <returns></returns>
        MessageEF Add(AddStaffDirectoryModel objAddStaffDirectoryModel);
        /// <summary>
        /// Update Website Staff Directory Details 
        /// </summary>
        /// <param name="objAddStaffDirectoryModel"></param>
        /// <returns></returns>
        MessageEF Update(AddStaffDirectoryModel objAddStaffDirectoryModel);
        /// <summary>
        /// Edit Website Staff Directory Details
        /// </summary>
        /// <param name="objViewStaffDirectoryModel"></param>
        /// <returns></returns>
        AddStaffDirectoryModel Edit(AddStaffDirectoryModel objAddStaffDirectoryModel);
        /// <summary>
        /// Select Website Staff Directory Details 
        /// </summary>
        /// <param name="objViewStaffDirectoryModel"></param>
        /// <returns></returns>
        List<ViewStaffDirectoryModel> View(ViewStaffDirectoryModel objViewStaffDirectoryModel);
        /// <summary>
        /// Delete Website Staff Directory Details 
        /// </summary>
        /// <param name="objAddStaffDirectoryModel"></param>
        /// <returns></returns>
        MessageEF Delete(ViewStaffDirectoryModel objViewStaffDirectoryModel);
        /// <summary>
        /// Bind Website Staff Directory Type List Details 
        /// </summary>
        /// <param name="objAddStaffDirectoryModel"></param>
        /// <returns></returns>
        List<AddStaffDirectoryModel> GetOfficeTypeList(AddStaffDirectoryModel objAddStaffDirectoryModel);
        /// <summary>
        /// Bind Publish Website Staff Directory Details 
        /// </summary>
        /// <param name="objViewStaffDirectoryModel"></param>
        /// <returns></returns>
        List<ViewStaffDirectoryModel> ViewPublishStaffDirectory(ViewStaffDirectoryModel objViewStaffDirectoryModel);
    }
}
