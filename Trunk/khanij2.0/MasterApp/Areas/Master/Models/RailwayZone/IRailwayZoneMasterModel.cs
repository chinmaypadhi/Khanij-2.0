using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.RailwayZone
{
    public interface IRailwayZoneMasterModel
    {
        MessageEF Add(RailwayZoneModel railwayZoneModel);
        MessageEF Update(RailwayZoneModel railwayZoneModel);
        List<RailwayZoneModel> View(RailwayZoneModel railwayZoneModel);
        MessageEF Delete(RailwayZoneModel railwayZoneModel);
        RailwayZoneModel Edit(RailwayZoneModel railwayZoneModel);
    }
}
