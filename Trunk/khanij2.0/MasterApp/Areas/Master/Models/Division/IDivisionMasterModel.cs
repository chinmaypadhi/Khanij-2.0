using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.Division
{
    public interface IDivisionMasterModel
    {
        MessageEF Add(RegionalModel regionalModel);
        MessageEF Update(RegionalModel regionalModel);
        List<RegionalModel> View(RegionalModel regionalModel);
        MessageEF Delete(RegionalModel regionalModel);
        RegionalModel Edit(RegionalModel regionalModel);
    }
}
