using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.Designation
{
    public interface IDesignationModel
    {
        MessageEF Add(RoleListModel roleListModel);
        MessageEF Update(RoleListModel roleListModel);
        List<RoleListModel> View(RoleListModel roleListModel);
        MessageEF Delete(RoleListModel roleListModel);
        RoleListModel Edit(RoleListModel roleListModel);
    }
}
