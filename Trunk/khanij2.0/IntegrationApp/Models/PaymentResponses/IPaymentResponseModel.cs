using IntegrationEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace IntegrationApp.Models.PaymentResponses
{
    public interface IPaymentResponseModel
    {
        MessageEF GetPaymentResponseID(PaymentResponseDetails paymentResponseDetails);
        MessageEF AddPaymentResponse(PaymentTransaction paymentTransaction);
        TransporterModel AddVehiclePaymentResponse(PaymentResponseDetails paymentResponseDetails);
        UserMasterModel AddLicenseFirstPayment(PaymentResponseDetails paymentResponseDetails);
        UserMasterModel AddLicenseSecurityPayment(PaymentResponseDetails paymentResponseDetails);
        UserMasterModel AddLicenseLeaseDeedPayment(PaymentResponseDetails paymentResponseDetails);
        MessageEF AddSBIDetails(PaymentEF paymentTransaction);
        PaymentEF SBIDetails(PaymentEF paymentTransaction);
    }
}
