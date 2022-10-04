using EstablishmentApi.Repository;
using EstablishmentEf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApi.Model.PAStatffAppraisal
{
    public interface IPAStatffAppraisalProvider:IDisposable, IRepository
    {
        MessageEF ReportingAuthority(PastaffEF objPastaffEF);
        List<PastaffEF> getList(PastaffEF objPastaffEF);
        PastaffEF ReportingAuthorityEdit(PastaffEF objPastaffEF);
    }
}
