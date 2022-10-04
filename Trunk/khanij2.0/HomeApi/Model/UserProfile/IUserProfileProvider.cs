// ***********************************************************************
//  Interface Name           : IUserProfileProvider
//  Desciption               : Add,View,Edit,Update,Delete Website User Profile Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 05 Nov 2021
// ***********************************************************************
using HomeApi.Repository;
using HomeEF;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeApi.Model.UserProfile
{
    public interface IUserProfileProvider: IDisposable, IRepository
    {
        /// <summary>
        /// Add Website User Profile Details 
        /// </summary>
        /// <param name="objAddUserProfileModel"></param>
        /// <returns></returns>
        MessageEF AddUserProfile(AddUserProfileModel objAddUserProfileModel);
        /// <summary>
        /// Select Website User Profile Details 
        /// </summary>
        /// <param name="objViewUserProfileModel"></param>
        /// <returns></returns>
        Task<List<ViewUserProfileModel>> ViewUserProfile(ViewUserProfileModel objViewUserProfileModel);
        /// <summary>
        /// Edit Website User Profile Details
        /// </summary>
        /// <param name="objAddUserProfileModel"></param>
        /// <returns></returns>
        AddUserProfileModel EditUserProfile(AddUserProfileModel objAddUserProfileModel);
        /// <summary>
        /// Delete Website User Profile Details 
        /// </summary>
        /// <param name="objViewUserProfileModel"></param>
        /// <returns></returns>
        MessageEF DeleteUserProfile(ViewUserProfileModel objViewUserProfileModel);
        /// <summary>
        /// Update Website User Profile Details 
        /// </summary>
        /// <param name="objAddUserProfileModel"></param>
        /// <returns></returns>
        MessageEF UpdateUserProfile(AddUserProfileModel objAddUserProfileModel);
    }
}
