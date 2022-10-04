using EstablishmentEf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApp.Areas.Aec.Models.AppraisalClassIV
{
    public interface IAppraisalClassIVModel
    {
        MessageEF AddAppraisal(AppraisalClassIVEF objAppraisalClassIVEF);
        List<AppraisalClassIVEF> getList(AppraisalClassIVEF objAppraisalClassIVEF);
        AppraisalClassIVEF getdataedit(AppraisalClassIVEF objAppraisalClassIVEF);
    }
}
