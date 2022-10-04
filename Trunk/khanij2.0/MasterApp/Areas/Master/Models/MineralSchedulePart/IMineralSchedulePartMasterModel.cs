using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.MineralSchedulePart
{
    public interface IMineralSchedulePartMasterModel
    {
        MessageEF Add(MineralSchedulePartModel mineralSchedulePartModel);
        MessageEF Update(MineralSchedulePartModel mineralSchedulePartModel);
        List<MineralSchedulePartModel> View(MineralSchedulePartModel mineralSchedulePartModel);
        MessageEF Delete(MineralSchedulePartModel mineralSchedulePartModel);
        MineralSchedulePartModel Edit(MineralSchedulePartModel mineralSchedulePartModel);
    }
}
