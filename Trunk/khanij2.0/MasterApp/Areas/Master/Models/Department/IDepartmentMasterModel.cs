using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.Department
{
    public interface IDepartmentMasterModel
    {
        MessageEF Add(RoleTypeModel roleTypeModel);
        MessageEF Update(RoleTypeModel roleTypeModel);
        List<RoleTypeModel> View(RoleTypeModel roleTypeModel);
        MessageEF Delete(RoleTypeModel roleTypeModel);
        RoleTypeModel Edit(RoleTypeModel roleTypeModel);
    }
}
