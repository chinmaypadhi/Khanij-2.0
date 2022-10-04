using PermitEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermitApi.Model.CoalGrade
{
    public interface ICoalGradeProvider
    {
        Task<List<SampleGradeModel>> CoalGradeDetailsByUserID(SampleGradeModel obj);
        Task<ePermitModel> CoalGradeDetailsByPermitID(ePermitModel obj);
        Task<List<ePermitModel>> GetMineralGradeCascadFromMineralNature(ePermitModel obj);
        Task<List<ePaymentData>> RevisedPayableRoyaltyRate(RevisedPayableRoyaltyRate obj);
    }
}
