
// ***********************************************************************
// Interface Name   : UserModel
// Author           : Prakash Chandra Biswal
// Created          : 24-Mar-2022
//
// ***********************************************************************

using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.User
{
    public interface IUserModel
    {
        List<UserCreationModel> GetUserTypeList();
        /// <summary>
        /// Bind State details in view
        /// </summary>
        List<UserCreationModel> StateList();
        /// <summary>
        /// Bind District List details in view
        /// </summary>
        /// <param name="userCreationModel"></param>
        /// <returns></returns>
        List<UserCreationModel> GetDistrictList(UserCreationModel userCreationModel);

        /// <summary>
        /// To Bind Department Dropdownlist by selecting usertype
        /// </summary>
        /// <param name="userCreationModel"></param>
        /// <returns></returns>
        List<UserCreationModel> GetRoleTypeListByUserType(UserCreationModel userCreationModel);
        /// <summary>
        /// To Bind Designation Dropdwon by selecting Department
        /// </summary>
        /// <param name="userCreationModel"></param>
        /// <returns></returns>
        List<UserCreationModel> GetRoleListByRoleType(UserCreationModel userCreationModel);
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
        List<ViewUserCreationModel> View(ViewUserCreationModel userCreationModel);
        /// <summary>
        /// To Edit a User
        /// </summary>
        /// <param name="userCreationModel"></param>
        /// <returns></returns>
        UserCreationModel Edit(UserCreationModel userCreationModel);
        /// <summary>
        /// To Update User
        /// </summary>
        /// <param name="userCreationModel"></param>
        /// <returns></returns>
        MessageEF Update(UserCreationModel userCreationModel);
        /// <summary>
        /// To Delete a User
        /// </summary>
        /// <param name="userCreationModel"></param>
        /// <returns></returns>
        MessageEF Delete(UserCreationModel userCreationModel);
        /// <summary>
        /// To Send SMS
        /// </summary>
        /// <param name="sMS"></param>
        /// <returns></returns>
        MessageEF Main(SMS sMS);
    }
}
