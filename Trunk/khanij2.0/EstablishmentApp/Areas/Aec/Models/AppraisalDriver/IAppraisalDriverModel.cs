using EstablishmentEf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApp.Areas.Aec.Models.AppraisalDriver
{
    public interface IAppraisalDriverModel
    {
        MessageEF AddAppraisal(AppraisalDriverEF objAppraisalDriverEF);
        List<AppraisalDriverEF> getList(AppraisalDriverEF objAppraisalDriverEF);
        AppraisalDriverEF getdataedit(AppraisalDriverEF objAppraisalDriverEF);
    }
}
