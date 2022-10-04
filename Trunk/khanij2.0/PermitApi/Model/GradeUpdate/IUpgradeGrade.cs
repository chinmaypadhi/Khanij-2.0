using PermitEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermitApi.Model.GradeUpdate
{
   public interface IUpgradeGrade
    {
        Task<List<SampleGradeModel>> GetGradeDetails(SampleGradeModel objUser);
    }
}
