using IntegrationApi.Repository;
using IntegrationEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace IntegrationApi.Model.PaymentResponse
{
    public interface IPaymentResponseProvider: IDisposable, IRepository
    {
        Task<MessageEF> GetPaymentResponseID(PaymentResponseDetails paymentResponseDetails);
        Task<MessageEF> AddPaymentResponse(PaymentTransaction paymentTransaction);
        Task<TransporterModel> AddVehiclePaymentResponse(PaymentResponseDetails paymentResponseDetails);
        Task<UserMasterModel> AddLicenseFirstPayment(PaymentResponseDetails paymentResponseDetails);
        Task<UserMasterModel> AddLicenseSecurityPayment(PaymentResponseDetails paymentResponseDetails);
        Task<UserMasterModel> AddLicenseLeaseDeedPayment(PaymentResponseDetails paymentResponseDetails);
        Task<MessageEF> AddSBIDetails(PaymentEF paymentTransaction);
        Task<PaymentEF> SBIDetails(PaymentEF paymentTransaction);
    }
}
