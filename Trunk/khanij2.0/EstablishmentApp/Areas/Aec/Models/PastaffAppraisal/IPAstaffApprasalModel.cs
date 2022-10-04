using EstablishmentEf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApp.Areas.Aec.Models.PastaffAppraisal
{
    public interface IPAstaffApprasalModel 
    {
        MessageEF ReportingAuthority(PastaffEF objPastaffEF);
        List<PastaffEF> getList(PastaffEF objPastaffEF);
        PastaffEF ReportingAuthorityEdit(PastaffEF objPastaffEF);
    }
}
