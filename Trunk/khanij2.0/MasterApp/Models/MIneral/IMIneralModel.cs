
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Models.MIneral
{
    public interface IMIneralModel
    {
         MessageEF Add(MineralCategory objMineralCategory);
         MessageEF Update(MineralCategory objMineralCategory);
         List<MineralCategory> View(MineralCategory objMineralCategory);
         MessageEF Delete(MineralCategory objMineralCategory);
         MineralCategory Edit(MineralCategory objMineralCategory);
    }
}
