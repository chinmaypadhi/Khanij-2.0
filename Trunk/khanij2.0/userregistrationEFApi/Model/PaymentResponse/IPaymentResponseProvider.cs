using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
using userregistrationEFApi.Repository;

namespace userregistrationEFApi.Model.PaymentResponse
{
    public interface IPaymentResponseProvider: IDisposable, IRepository
    {
        Task<MessageEF> GetPaymentResponseID(PaymentResponseDetails paymentResponseDetails);
        Task<MessageEF> AddPaymentResponse(PaymentTransaction paymentTransaction);
        Task<TransporterModel> AddVehiclePaymentResponse(PaymentResponseDetails paymentResponseDetails);
        Task<UserMasterModel> AddLicenseFirstPayment(PaymentResponseDetails paymentResponseDetails);
        Task<UserMasterModel> AddLicenseSecurityPayment(PaymentResponseDetails paymentResponseDetails);
    }
}
