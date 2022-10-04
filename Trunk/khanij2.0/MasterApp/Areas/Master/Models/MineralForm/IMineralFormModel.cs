using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.MineralForm
{
    public interface IMineralFormModel
    {
        MessageEF Add(MineralNatureModel mineralNatureModel);
        MessageEF Update(MineralNatureModel mineralNatureModel);
        List<MineralNatureModel> View(MineralNatureModel mineralNatureModel);
        MessageEF Delete(MineralNatureModel mineralNatureModel);
        MineralNatureModel Edit(MineralNatureModel mineralNatureModel);
        List<MineralGradeModel> ViewMineralCategory(MineralGradeModel mineralGradeModel);
    }
}
