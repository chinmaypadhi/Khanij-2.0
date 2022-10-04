using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.Royalty
{
    public interface IRoyaltyProvider : IDisposable, IRepository
    {
        MessageEF AddRoyalty(RoyaltyModel royaltyModel);
        List<RoyaltyModel> ViewRoyalty(RoyaltyModel royaltyModel);
        RoyaltyModel EditRoyalty(RoyaltyModel royaltyModel);
        MessageEF DeleteRoyalty(RoyaltyModel royaltyModel);
        MessageEF UpdateRoyalty(RoyaltyModel royaltyModel);
    }
}
