using EstablishmentApi.Repository;
using EstablishmentEf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApi.Model.AppraisalDriver
{
    public interface IAppraisalDriverProvider: IDisposable, IRepository
    {
        MessageEF AddAppraisal(AppraisalDriverEF objAppraisalDriverEF);
        List<AppraisalDriverEF> getList(AppraisalDriverEF objAppraisalDriverEF);
        AppraisalDriverEF getdataedit(AppraisalDriverEF objAppraisalDriverEF);
    }
}
