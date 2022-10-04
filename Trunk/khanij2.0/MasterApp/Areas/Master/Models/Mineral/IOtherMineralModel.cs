using System;
using MasterEF;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.Mineral
{
    public interface IOtherMineralModel
    {
        MessageEF AddOtherMineral(OtherMineralsmaster objOtherMineralmaster);
        MessageEF UpdateOtherMineral(OtherMineralsmaster objOtherMineralmaster);
        List<OtherMineralsmaster> ViewOtherMineral(OtherMineralsmaster objOtherMineralmaster);
        MessageEF DeleteOtherMineral(OtherMineralsmaster objOtherMineralmaster);
        OtherMineralsmaster EditOtherMineral(OtherMineralsmaster objOtherMineralmaster);
        List<OtherMineralsmaster> GetOtherMineralList(OtherMineralsmaster otherMineralResult);
        MessageEF UpdatePublishStatus(OtherMineralsmaster objOtherMineralmaster);
        OtherMineralsmaster Download_OtherMinerals(OtherMineralsmaster otherMineralResult);
    }
}
