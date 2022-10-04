// ***********************************************************************
//  Interface Name           : IUserProvider
//  Description              : Add,View,Edit,Update,Delete User Master details
//  Created By               : Prakash Chandra Biswal
//  Created On               : 27 Dec 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;

namespace MasterApi.Model.UserCreation
{
    public interface IUserProvider
    {
        //Task<List<UserCreationModel>> GetDistricts(UserCreationModel userCreationModel);

        /// <summary>
        /// To Bind Department Dropdownlist by selecting usertype
        /// </summary>
        /// <param name="userCreationModel"></param>
        /// <returns></returns>
        Task<List<UserCreationModel>> GetRoleTypeListByUserType(UserCreationModel userCreationModel);
        /// <summary>
        /// To Bind Designation Dropdwon by selecting Department
        /// </summary>
        /// <param name="userCreationModel"></param>
        /// <returns></returns>
        Task<List<UserCreationModel>> GetRoleListByRoleType(UserCreationModel userCreationModel);
        /// <summary>
        /// To Create a New User
        /// </summary>
        /// <param name="userCreationModel"></param>
        /// <returns></returns>
        MessageEF AddNewUser(UserCreationModel userCreationModel);
        /// <summary>
        /// To View Users
        /// </summary>
        /// <param name="userCreationModel"></param>
        /// <returns></returns>
        Task<List<ViewUserCreationModel>> ViewUser(ViewUserCreationModel userCreationModel);
        UserCreationModel EditUser(UserCreationModel userCreationModel);
        MessageEF UpdateUser(UserCreationModel userCreationModel);
        MessageEF DeleteUser(UserCreationModel userCreationModel);

    }
}
