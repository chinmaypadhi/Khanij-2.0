
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.PaymentTypeMaster
{
   public interface IPaymentTypeMasterModel
    {
        MessageEF Add(PaymenttypeMaster objPaymentTypeMaster);
        MessageEF Update(PaymenttypeMaster objPaymentTypeMaster);
        List<PaymenttypeMaster> View(PaymenttypeMaster objPaymentTypeMaster);
        MessageEF Delete(PaymenttypeMaster objPaymentTypeMaster);
        PaymenttypeMaster Edit(PaymenttypeMaster objPaymentTypeMaster);
    }
}
