using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.Village
{
    public interface IVillageMaster
    {
        MessageEF Add(VillageModel villageModel);
        MessageEF Update(VillageModel villageModel);
        List<VillageModel> View(VillageModel villageModel);
        MessageEF Delete(VillageModel villageModel);
        VillageModel Edit(VillageModel villageModel);
    }
}
