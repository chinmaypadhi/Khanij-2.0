using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.Railway
{
    public interface IRailwayProvider : IDisposable, IRepository
    {
        MessageEF AddRailway(RailwayModel railwayModel);
        List<RailwayModel> ViewRailway(RailwayModel railwayModel);
        RailwayModel EditRailway(RailwayModel railwayModel);
        MessageEF DeleteRailway(RailwayModel railwayModel);
        MessageEF UpdateRailway(RailwayModel railwayModel);
    }
}
