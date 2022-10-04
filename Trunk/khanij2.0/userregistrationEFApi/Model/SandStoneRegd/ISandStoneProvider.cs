using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
using userregistrationEFApi.Repository;

namespace userregistrationEFApi.Model.SandStoneRegd
{
    public interface ISandStoneProvider : IDisposable, IRepository
    {
        Task<MessageEF> SubmitSandStoneRegd(SandStoneModels SandStoneModel);
        Task<List<SandStoneModels>> GetState(SandStoneModels SandStoneModel);
        Task<List<SandStoneModels>> GetDistrict(SandStoneModels SandStoneModel);
        Task<List<SandStoneModels>> GetBlock(SandStoneModels SandStoneModel);
        Task<List<SandStoneModels>> GetMineralName(SandStoneModels SandStoneModel);
        Task<List<SandStoneModels>> GetUserType(SandStoneModels SandStoneModel);
        Task<List<SandStoneModels>> GetKo_Id(SandStoneModels SandStoneModel);
        Task<List<SandStoneModels>> GetMineralForm(SandStoneModels SandStoneModel);
        Task<SandStoneModels> GetSandStoneNamePass(SandStoneModels SandStoneModel);
    }
}
