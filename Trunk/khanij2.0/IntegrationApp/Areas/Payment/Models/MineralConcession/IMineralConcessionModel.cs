using IntegrationEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationApp.Areas.Payment.Models.MineralConcession
{
   public interface IMineralConcessionModel
    {
        LeaseApplicationModel GetFirstinstallment(LeaseApplicationModel objRaiseTicket);
        MessageEF AddPayment(LeaseApplicationModel model);
    }
}
