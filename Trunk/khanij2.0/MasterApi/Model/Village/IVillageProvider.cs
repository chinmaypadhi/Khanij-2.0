using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.Village
{
    public interface IVillageProvider : IDisposable, IRepository
    {
        MessageEF AddVillage(VillageModel villageModel);
        List<VillageModel> ViewVillage(VillageModel villageModel);
        VillageModel EditVillage(VillageModel villageModel);
        MessageEF DeleteVillage(VillageModel villageModel);
        MessageEF UpdateVillage(VillageModel villageModel);
    }
}
