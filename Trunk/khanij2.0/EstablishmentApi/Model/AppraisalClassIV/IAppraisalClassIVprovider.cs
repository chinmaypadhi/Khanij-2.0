using EstablishmentApi.Repository;
using EstablishmentEf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApi.Model.AppraisalClassIV
{
    public interface IAppraisalClassIVprovider : IDisposable, IRepository
    {
        MessageEF AddAppraisal(AppraisalClassIVEF objAppraisalClassIVEF);
        List<AppraisalClassIVEF> getList(AppraisalClassIVEF objAppraisalClassIVEF);
        AppraisalClassIVEF getdataedit(AppraisalClassIVEF objAppraisalClassIVEF);

    }
}
