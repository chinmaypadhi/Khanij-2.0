// ***********************************************************************
//  Interface Name           : IUserProfileModel
//  Desciption               : Add,View,Edit,Update,Delete Website User Profile Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 05 Nov 2021
// ***********************************************************************
using HomeEF;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Models.UserProfile
{
    public interface IUserProfileModel
    {
        /// <summary>
        /// Add Website User Profile Details 
        /// </summary>
        /// <param name="objAddUserProfileModel"></param>
        /// <returns></returns>
        MessageEF Add(AddUserProfileModel objAddUserProfileModel);
        /// <summary>
        /// Update Website User Profile Details 
        /// </summary>
        /// <param name="objAddUserProfileModel"></param>
        /// <returns></returns>
        MessageEF Update(AddUserProfileModel objAddUserProfileModel);
        /// <summary>
        /// Edit Website User Profile Details
        /// </summary>
        /// <param name="objViewUserProfileModel"></param>
        /// <returns></returns>
        AddUserProfileModel Edit(AddUserProfileModel objAddUserProfileModel);
        /// <summary>
        /// Select Website User Profile Details 
        /// </summary>
        /// <param name="objViewUserProfileModel"></param>
        /// <returns></returns>
        List<ViewUserProfileModel> View(ViewUserProfileModel objViewUserProfileModel);
        /// <summary>
        /// Delete Website User Profile Details 
        /// </summary>
        /// <param name="objViewUserProfileModel"></param>
        /// <returns></returns>
        MessageEF Delete(ViewUserProfileModel objViewUserProfileModel);
    }
}
