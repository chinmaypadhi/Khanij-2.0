using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.PaymentHead
{
    public interface ISinglePaymentHeadMasterModel
    {
        MessageEF Add(SinglePaymentHeadModel singlePaymentHeadModel);
        MessageEF Update(SinglePaymentHeadModel singlePaymentHeadModel);
        List<SinglePaymentHeadModel> View(SinglePaymentHeadModel singlePaymentHeadModel);
        MessageEF Delete(SinglePaymentHeadModel singlePaymentHeadModel);
        SinglePaymentHeadModel Edit(SinglePaymentHeadModel singlePaymentHeadModel);
        List<SinglePaymentHeadModel> District(SinglePaymentHeadModel singlePaymentHeadModel);
        List<SinglePaymentHeadModel> PaymentHead(SinglePaymentHeadModel singlePaymentHeadModel);
    }
}
