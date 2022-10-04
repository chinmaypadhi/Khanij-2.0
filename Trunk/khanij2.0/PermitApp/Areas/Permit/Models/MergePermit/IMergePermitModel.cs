using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermitEF;

namespace PermitApp.Areas.Permit.Models.MergePermit
{
   public interface IMergePermitModel
    {
        ePermitResult GetMergePermitMineralGrade(ePermitModel objUser);
        List<ePermitModel> GetMergePermitList(ePermitModel objUser);
        MessageEF ClosePermit(ePermitModel objUser);
        MessageEF SaveAndGenerateEpermit(ePermitModel objUser);
        ePermitResult GetMineralName(ePermitModel objUser);
        ePermitResult CheckMergePermitDetails(ePermitModel objUser);
        ePermitResult GetMergePermitTransDetails(ePermitModel objUser);
    }
}
