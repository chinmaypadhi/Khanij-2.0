using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.District
{
    public interface IDistrictMasterModel
    {
        MessageEF Add(DistrictModel districtModel);
        MessageEF Update(DistrictModel districtModel);
        List<DistrictModel> View(DistrictModel districtModel);
        MessageEF Delete(DistrictModel districtModel);
        DistrictModel Edit(DistrictModel districtModel);
    }
}
