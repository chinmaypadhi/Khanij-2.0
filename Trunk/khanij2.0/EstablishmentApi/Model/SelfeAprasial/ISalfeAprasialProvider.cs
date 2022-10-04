using EstablishmentEf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApi.Model.SelfeAprasial
{
    public interface ISalfeAprasialProvider
    {
         List<SalfeAprasialEf> GetListData(SalfeAprasialEf objSalfeAprasialEf);
        SalfeAprasialEf Edit(SalfeAprasialEf objSalfeAprasialEf);
   
        MessageEF Update(SalfeAprasialEf objSalfeAprasialEf);
        MessageEF AddSalfeAprasial(SalfeAprasialEf objSalfeAprasialEf);


    }
}
