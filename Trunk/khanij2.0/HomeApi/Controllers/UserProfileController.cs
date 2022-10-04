// ***********************************************************************
//  Controller Name          : UserProfileController
//  Desciption               : Add,View,Edit,Update,Delete Website User Profile Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 05 Nov 2021
// ***********************************************************************
using HomeApi.Model.UserProfile;
using HomeEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class UserProfileController : ControllerBase
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        public IUserProfileProvider _objIUserProfileProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public UserProfileController(IUserProfileProvider objIUserProfileProvider)
        {
            _objIUserProfileProvider = objIUserProfileProvider;
        }
        /// <summary>
        /// Add Website User Profile Details in view
        /// </summary>
        /// <param name="objAddUserProfileModel"></param>
        /// <returns></returns>     
        [HttpPost]
        public MessageEF Add(AddUserProfileModel objAddUserProfileModel)
        {
            return _objIUserProfileProvider.AddUserProfile(objAddUserProfileModel);
        }
        /// <summary>
        /// Edit Website User Profile Details in view
        /// </summary>
        /// <param name="objAddUserProfileModel"></param>
        /// <returns></returns>
        [HttpPost]
        public AddUserProfileModel Edit(AddUserProfileModel objAddUserProfileModel)
        {
            return _objIUserProfileProvider.EditUserProfile(objAddUserProfileModel);
        }
        /// <summary>
        /// Select Website User Profile Details in view
        /// </summary>
        /// <param name="objViewUserProfileModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ViewUserProfileModel>>> View(ViewUserProfileModel objViewUserProfileModel)
        {
            return await _objIUserProfileProvider.ViewUserProfile(objViewUserProfileModel);
        }
        /// <summary>
        /// Delete Website User Profile Details in view
        /// </summary>
        /// <param name="objViewUserProfileModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(ViewUserProfileModel objViewUserProfileModel)
        {
            return _objIUserProfileProvider.DeleteUserProfile(objViewUserProfileModel);
        }
        /// <summary>
        /// Update Website User Profile Details in view
        /// </summary>
        /// <param name="objAddUserProfileModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(AddUserProfileModel objAddUserProfileModel)
        {
            return _objIUserProfileProvider.UpdateUserProfile(objAddUserProfileModel);
        }
    }
}
