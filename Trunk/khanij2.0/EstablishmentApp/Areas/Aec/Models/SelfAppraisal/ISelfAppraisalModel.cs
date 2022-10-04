using EstablishmentEf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApp.Areas.Aec.Models.SelfAppraisal
{
    public interface ISelfAppraisalModel
    {
        List<SalfeAprasialEf> GetListData(SalfeAprasialEf objSalfeAprasialEf);
        SalfeAprasialEf GetAprasialDetails(SalfeAprasialEf objSalfeAprasialEf);
        MessageEF RevAuthoReviewUpdate(SalfeAprasialEf objSalfeAprasialEf);
        MessageEF AddSalfeAprasial(SalfeAprasialEf objSalfeAprasialEf);

    }
}
