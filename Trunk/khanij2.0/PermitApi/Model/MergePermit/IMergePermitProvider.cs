using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermitEF;
using PermitApi.Repository;

namespace PermitApi.Model.MergePermit
{
   public interface IMergePermitProvider : IDisposable, IRepository
    {
        Task<List<ePermitModel>> GetMergePermitList(ePermitModel objUser);
        Task<ePermitResult> GetMergePermitMineralGrade(ePermitModel objUser);
        Task<MessageEF> ClosePermit(ePermitModel objUser);
        Task<MessageEF> SaveAndGenerateEpermit(ePermitModel objUser);
        Task<ePermitResult> GetMineralName(ePermitModel objUser);
        Task<ePermitResult> CheckMergePermitDetails(ePermitModel objUser);
        Task<ePermitResult> GetMergePermitTransDetails(ePermitModel objUser);
    }
}
