using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;

namespace userregistrationApp.Models.PaymentResponses
{
    public interface IPaymentResponseModel
    {
        MessageEF GetPaymentResponseID(PaymentResponseDetails paymentResponseDetails);
        MessageEF AddPaymentResponse(PaymentTransaction paymentTransaction);
        TransporterModel AddVehiclePaymentResponse(PaymentResponseDetails paymentResponseDetails);
        UserMasterModel AddLicenseFirstPayment(PaymentResponseDetails paymentResponseDetails);
        UserMasterModel AddLicenseSecurityPayment(PaymentResponseDetails paymentResponseDetails);
    }
}
