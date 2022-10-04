using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.MineralSchedule
{
    public interface IMineralScheduleMasterModel
    {
        MessageEF Add(MineralScheduleModel mineralScheduleModel);
        MessageEF Update(MineralScheduleModel mineralScheduleModel);
        List<MineralScheduleModel> View(MineralScheduleModel mineralScheduleModel);
        MessageEF Delete(MineralScheduleModel mineralScheduleModel);
        MineralScheduleModel Edit(MineralScheduleModel mineralScheduleModel);
    }
}
