using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.AccessPermission
{
    public interface IAccessPermission
    {
        List<UserRightsEF> getview(UserRightsEF objUserRightsEF);
        List<TreeMenu> getTreeValue(TreeMenu objTreeMenu);
        List<Bindfild> FilldropDown(Bindfild objBindfild);
        List<userRights> BindUserTypeData(userRights objuserRights);
        MessageEF AddUserType(AcessUserTypeEF objAcessUserTypeEF);
        List<userRights> BindUseridData(userRights objuserRights);
        MessageEF AddUserId(AcessUserIdEf objAcessUserTypeEF);
        AcessUserIdEf EditUserId(AcessUserIdEf objAcessUserIdEf);
    }
}
