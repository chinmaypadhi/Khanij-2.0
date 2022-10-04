// ***********************************************************************
//  Controller Name          : AccessPermissionController
//  Description              : Access Permission details
//  Created By               : Kumar Jeevanjyoti
//  Created On               : 20 oct 2021
// ***********************************************************************
using MasterApi.Model.AccessPermission;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class AccessPermissionController : ControllerBase
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        public IAccessPermission _IAccessPermission;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objIAccessPermission"></param>
        public AccessPermissionController(IAccessPermission objIAccessPermission)
        {
             _IAccessPermission= objIAccessPermission;
        }
        /// <summary>
        /// Get view
        /// </summary>
        /// <param name="objUserRightsEF"></param>
        /// <returns></returns>
        [HttpPost]
        public List<UserRightsEF> getview(UserRightsEF objUserRightsEF)
        {
            return _IAccessPermission.getview(objUserRightsEF);
        }
        /// <summary>
        /// Get Tree view
        /// </summary>
        /// <param name="objTreeMenu"></param>
        /// <returns></returns>
        [HttpPost] 
        public List<TreeMenu> getTreeValue(TreeMenu objTreeMenu)
        {
            return _IAccessPermission.getTreeValue(objTreeMenu);
        }
        /// <summary>
        /// Fill dropdown
        /// </summary>
        /// <param name="objBindfild"></param>
        /// <returns></returns>
        [HttpPost]
        public List<Bindfild> FilldropDown(Bindfild objBindfild)
        {
            return _IAccessPermission.FilldropDown(objBindfild);
        }
        /// <summary>
        /// Bind User Type details in view
        /// </summary>
        /// <param name="objuserRights"></param>
        /// <returns></returns>
        [HttpPost]
        public List<userRights> BindUserTypeData(userRights objuserRights)
        {
            return _IAccessPermission.BindUserTypeData(objuserRights);
        }
        /// <summary>
        /// Add User Type details
        /// </summary>
        /// <param name="objAcessUserTypeEF"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF AddUserType(AcessUserTypeEF objAcessUserTypeEF)
        {
            return _IAccessPermission.AddUserType(objAcessUserTypeEF);
        }
        /// <summary>
        /// Bind User Data
        /// </summary>
        /// <param name="objuserRights"></param>
        /// <returns></returns>
        [HttpPost]
        public List<userRights> BindUseridData(userRights objuserRights)
        {
            return _IAccessPermission.BindUseridData(objuserRights);
        }
        /// <summary>
        /// Add User Id
        /// </summary>
        /// <param name="objAcessUserTypeEF"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF AddUserId(AcessUserIdEf objAcessUserTypeEF)
        {
            return _IAccessPermission.AddUserId(objAcessUserTypeEF);
        }
        /// <summary>
        /// Edit User Id
        /// </summary>
        /// <param name="objAcessUserIdEf"></param>
        /// <returns></returns>
        [HttpPost]
        public AcessUserIdEf EditUserId(AcessUserIdEf objAcessUserIdEf)
        {
            return _IAccessPermission.EditUserId(objAcessUserIdEf);
        }
    }
}
