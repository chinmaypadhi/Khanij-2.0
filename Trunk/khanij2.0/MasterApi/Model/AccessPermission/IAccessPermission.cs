// ***********************************************************************
//  Interface Name           : IAccessPermission
//  Description              : Access Permission details
//  Created By               : Kumar Jeevanjyoti
//  Created On               : 20 oct 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
namespace MasterApi.Model.AccessPermission
{
    public interface IAccessPermission
    {
        /// <summary>
        /// Get view
        /// </summary>
        /// <param name="objUserRightsEF"></param>
        /// <returns></returns>
        List<UserRightsEF> getview(UserRightsEF objUserRightsEF);
        /// <summary>
        /// Get Tree view
        /// </summary>
        /// <param name="objTreeMenu"></param>
        /// <returns></returns>
        List<TreeMenu> getTreeValue(TreeMenu objTreeMenu);
        /// <summary>
        /// Fill dropdown
        /// </summary>
        /// <param name="objBindfild"></param>
        /// <returns></returns>
        List<Bindfild> FilldropDown(Bindfild objBindfild);
        /// <summary>
        /// Bind User Type details in view
        /// </summary>
        /// <param name="objuserRights"></param>
        /// <returns></returns>
        List<userRights> BindUserTypeData(userRights objuserRights);
        /// <summary>
        /// Add User Type details
        /// </summary>
        /// <param name="objAcessUserTypeEF"></param>
        /// <returns></returns>
        MessageEF AddUserType(AcessUserTypeEF objAcessUserTypeEF);
        /// <summary>
        /// Bind User Data
        /// </summary>
        /// <param name="objuserRights"></param>
        /// <returns></returns>
        List<userRights> BindUseridData(userRights objuserRights);
        /// <summary>
        /// Add User Id
        /// </summary>
        /// <param name="objAcessUserTypeEF"></param>
        /// <returns></returns>
        MessageEF AddUserId(AcessUserIdEf objAcessUserTypeEF);
        /// <summary>
        /// Edit User Id
        /// </summary>
        /// <param name="objAcessUserIdEf"></param>
        /// <returns></returns>
        AcessUserIdEf EditUserId(AcessUserIdEf objAcessUserIdEf);
    }
}
