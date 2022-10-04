using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.Mineral
{
    public interface IMineralMasterModel
    {
        MessageEF Add(MineralModel mineralModel);
        MessageEF Update(MineralModel mineralModel);
        List<MineralModel> View(MineralModel mineralModel);
        MessageEF Delete(MineralModel mineralModel);
        MineralModel Edit(MineralModel mineralModel); 
    }
}
