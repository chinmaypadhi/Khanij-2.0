using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.CriticalityMasters
{
    public interface ICriticalityMasterModel
    {
        MessageEF Add(CriticalityMaster objCriticalityMaster);
        MessageEF Update(CriticalityMaster objCriticalityMaster);
        List<CriticalityMaster> View(CriticalityMaster criticalityMaster);
        MessageEF Delete(CriticalityMaster objCriticalityMaster);
        CriticalityMaster Edit(CriticalityMaster objCriticalityMaster);

    }
}
