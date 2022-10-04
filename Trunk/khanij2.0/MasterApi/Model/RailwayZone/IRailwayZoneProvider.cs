using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.RailwayZone
{
    public interface IRailwayZoneProvider : IDisposable, IRepository
    {
        MessageEF AddRailwayZone(RailwayZoneModel railwayZoneModel);
        List<RailwayZoneModel> ViewRailwayZone(RailwayZoneModel railwayZoneModel);
        RailwayZoneModel EditRailwayZone(RailwayZoneModel railwayZoneModel);
        MessageEF DeleteRailwayZone(RailwayZoneModel railwayZoneModel);
        MessageEF UpdateRailwayZoneModel(RailwayZoneModel railwayZoneModel);
    }
}
