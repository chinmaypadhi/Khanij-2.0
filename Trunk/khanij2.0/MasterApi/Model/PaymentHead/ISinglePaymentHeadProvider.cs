using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.PaymentHead
{
    public interface ISinglePaymentHeadProvider : IDisposable, IRepository
    {
        MessageEF AddSinglePaymentHead(SinglePaymentHeadModel singlePaymentHeadModel);
        List<SinglePaymentHeadModel> ViewSinglePaymentHead(SinglePaymentHeadModel singlePaymentHeadModel);
        SinglePaymentHeadModel EditSinglePaymentHead(SinglePaymentHeadModel singlePaymentHeadModel);
        MessageEF DeleteSinglePaymentHead(SinglePaymentHeadModel singlePaymentHeadModel);
        MessageEF UpdateSinglePaymentHead(SinglePaymentHeadModel singlePaymentHeadModel);
        List<SinglePaymentHeadModel> GetDistrict(SinglePaymentHeadModel singlePaymentHeadModel);
        List<SinglePaymentHeadModel> GetHeadData(SinglePaymentHeadModel singlePaymentHeadModel);
    }
}
