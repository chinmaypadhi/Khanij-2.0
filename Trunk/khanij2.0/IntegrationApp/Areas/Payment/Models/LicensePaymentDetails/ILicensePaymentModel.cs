using IntegrationEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationApp.Areas.Payment.Models.LicensePaymentDetails
{
    public interface ILicensePaymentModel
    {
        MessageEF GetLicensePaymentDetails(LicensePaymentDetail licensePaymentDetail);
        PaymentModel GetLicensePaymentGateway(LicensePaymentDetail licensePaymentDetail);
        MessageEF InsertLicensePaymentRequest(PaymentModel model);
        MessageEF AddSecurityDeposit(LicenseApplication licenseApplication);
        MessageEF AddLeaseDeedFine(LicenseApplication licenseApplication);
    }
}
