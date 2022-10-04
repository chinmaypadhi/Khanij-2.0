using IntegrationApi.Repository;
using IntegrationEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationApi.Model.LicensePaymentDetails
{
    public interface ILicensePaymentProvider : IDisposable, IRepository
    {
        Task<MessageEF> GetLicensePaymentDetails(LicensePaymentDetail licensePaymentDetail);
        Task<PaymentModel> GetLicensePaymentGateway(LicensePaymentDetail licensePaymentDetail);
        Task<MessageEF> InsertLicensePaymentRequest(PaymentModel model);
        Task<MessageEF> AddSecurityDeposit(LicenseApplication licenseApplication);
        
        Task<MessageEF> AddLeaseDeedFine(LicenseApplication licenseApplication);
    }
}
