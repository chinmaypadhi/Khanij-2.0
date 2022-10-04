using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.MineralSize
{
    public interface IMineralSizeMasterModel
    {
        MessageEF AddMineralSize(MineralSizeMaster mineralSizeMaster);
        List<MineralSizeMaster> ViewMineralSize(MineralSizeMaster mineralSizeMaster);
        MineralSizeMaster EditMineralSize(MineralSizeMaster mineralSizeMaster);
        MessageEF DeleteMineralSize(MineralSizeMaster mineralSizeMaster);
        MessageEF UpdateMineralSize(MineralSizeMaster mineralSizeMaster);
    }
}
