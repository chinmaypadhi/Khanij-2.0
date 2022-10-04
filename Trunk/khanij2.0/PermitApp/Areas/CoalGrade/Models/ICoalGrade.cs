using PermitEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermitApp.Areas.CoalGrade.Models
{
    public interface ICoalGrade
    {
        List<SampleGradeModel> CoalGradeDetailsByUserID(SampleGradeModel obj);
        ePermitModel CoalGradeDetailsByPermitID(ePermitModel obj);
        List<ePermitModel> GetMineralGradeCascadFromMineralNature(ePermitModel obj);
        List<ePaymentData> RevisedPayableRoyaltyRate(RevisedPayableRoyaltyRate obj);
    }
}
