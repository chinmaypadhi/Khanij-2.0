using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;

namespace userregistrationApp.Areas.Contractor.Models.SandStone
{
    public interface ISandStoneModel 
    {
        MessageEF SubmitSandStoneRegd(SandStoneModels SandStoneModels);
        List<SandStoneModels> GetState(SandStoneModels SandStoneModels);
        List<SandStoneModels> GetDistrict(SandStoneModels SandStoneModels);
        List<SandStoneModels> GetBlock(SandStoneModels SandStoneModels);
        List<SandStoneModels> GetMineralName(SandStoneModels SandStoneModels);
        List<SandStoneModels> GetUserType(SandStoneModels SandStoneModels);
        List<SandStoneModels> GetKo_Id(SandStoneModels SandStoneModels);
        List<SandStoneModels> GetMineralForm(SandStoneModels SandStoneModels);
        SandStoneModels GetSandStoneNamePass(SandStoneModels SandStoneModels);
        MessageEF UpdateEncryptPassword(UpdateEncryptPasswordModel updateEncryptPasswordModel);
    }
}
