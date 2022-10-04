using PermitEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermitApp.Areas.Permit.Models.GradeUpdate
{
   public interface IUpgradeGrade
    {
        List<SampleGradeModel> GetGradeDetails(SampleGradeModel objUser);
    }
}
