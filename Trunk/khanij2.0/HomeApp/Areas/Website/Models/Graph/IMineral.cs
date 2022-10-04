using HomeEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApp.Areas.Website.Models.Graph
{
    public interface IMineral
    {
        List<MineralGradeModel> ViewMineralCategory(MineralGradeModel mineralGradeModel);
        List<MineralGradeModel> ViewMineral(MineralGradeModel mineralGradeModel);
    }
}
