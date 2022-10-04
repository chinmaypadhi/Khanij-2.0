using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.Railway
{
    public interface IRailwayMasterModel
    {
        MessageEF Add(RailwayModel railwayModel);
        MessageEF Update(RailwayModel railwayModel);
        List<RailwayModel> View(RailwayModel railwayModel);
        MessageEF Delete(RailwayModel railwayModel);
        RailwayModel Edit(RailwayModel railwayModel);
    }
}
