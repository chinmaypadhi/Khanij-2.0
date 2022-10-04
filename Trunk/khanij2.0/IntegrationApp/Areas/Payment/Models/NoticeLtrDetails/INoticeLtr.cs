using IntegrationEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationApp.Areas.Payment.Models.NoticeLtrDetails
{
   public interface INoticeLtr
    {
        List<Notice> NoticeLtrPaynalty(Notice objmodel);
    }
}
