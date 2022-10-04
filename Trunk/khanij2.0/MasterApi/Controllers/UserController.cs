// ***********************************************************************
//  Controller Name          : UserController
//  Description              : Add,View,Edit,Update,Delete User details
//  Created By               : Prakash Chandra Biswal
//  Created On               : 24 Mar 2022
// ***********************************************************************

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.UserCreation;
using MasterEF;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        #region Global Declaration
        public IUserProvider _objIUserProvider;
        #endregion
        #region Constructor Dependency Injection
        public UserController(IUserProvider userProvider)
        {
            _objIUserProvider = userProvider;
        }
        #endregion

        //[HttpPost]
        //public async Task<List<UserCreationModel>> GetDistrictsList(UserCreationModel userCreationModel)
        //{
        //    return await _objIUserProvider.GetDistricts(userCreationModel);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userCreationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<UserCreationModel>> GetRoleTypeListByUserType(UserCreationModel userCreationModel)
        {
            return await _objIUserProvider.GetRoleTypeListByUserType(userCreationModel);
        }

        /// <summary>
        /// To Bind Designation Dropdwon by selecting Department
        /// </summary>
        /// <param name="userCreationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<UserCreationModel>> GetRoleListByRoleType(UserCreationModel userCreationModel)
        {
            return await _objIUserProvider.GetRoleListByRoleType(userCreationModel);
        }
        /// <summary>
        /// To Create a New User 
        /// </summary>
        /// <param name="userCreationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public  MessageEF AddNewUser(UserCreationModel userCreationModel)
        {
            return  _objIUserProvider.AddNewUser(userCreationModel);
        }
        /// <summary>
        /// To View all Users
        /// </summary>
        /// <param name="userCreationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<ViewUserCreationModel>> ViewUser(ViewUserCreationModel userCreationModel)
        {
            return await _objIUserProvider.ViewUser(userCreationModel);
        }
        [HttpPost]
        public UserCreationModel EditUser(UserCreationModel userCreationModel)
        {
            return _objIUserProvider.EditUser(userCreationModel);
        }
        [HttpPost]
        public MessageEF UpdateUser(UserCreationModel userCreationModel)
        {
            return _objIUserProvider.UpdateUser(userCreationModel);
        }
        [HttpPost]
        public MessageEF DeleteUser(UserCreationModel userCreationModel)
        {
            return _objIUserProvider.DeleteUser(userCreationModel);
        }
    }
}
