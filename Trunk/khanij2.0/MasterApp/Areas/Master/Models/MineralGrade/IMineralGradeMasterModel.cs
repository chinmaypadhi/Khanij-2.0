using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.MineralGrade
{
   public interface IMineralGradeMasterModel
    {
        MessageEF Add(MineralGradeModel mineralGradeModel);
        MessageEF Update(MineralGradeModel mineralGradeModel);
        List<MineralGradeModel> View(MineralGradeModel mineralGradeModel);
        MessageEF Delete(MineralGradeModel mineralGradeModel);
        MineralGradeModel Edit(MineralGradeModel mineralGradeModel);
        
    }
}
