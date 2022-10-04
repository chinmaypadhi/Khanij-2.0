using IntegrationEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationApi.Model.Noticeltr
{
   public interface INoticeLtr
    {

        Task<List<Notice>> PaymentsView(Notice objmodel);
         Task<MessageEF> PaymentsStatus(Notice objmodel);
    }
}
