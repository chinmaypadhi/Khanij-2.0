using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.Royalty
{
    public interface IRoyaltyMasterModel
    {
        MessageEF Add(RoyaltyModel royaltyModel);
        MessageEF Update(RoyaltyModel royaltyModel);
        List<RoyaltyModel> View(RoyaltyModel royaltyModel);
        MessageEF Delete(RoyaltyModel royaltyModel);
        RoyaltyModel Edit(RoyaltyModel royaltyModel);
    }
}
