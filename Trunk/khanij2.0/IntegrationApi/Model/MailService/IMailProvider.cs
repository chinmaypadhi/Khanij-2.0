using IntegrationApi.Repository;
using IntegrationEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationApi.Model.MailService
{
    public interface IMailProvider : IDisposable, IRepository
    {
        MessageEF ForgotPasswordMail(ForgotPassword forgotPassword);
        MessageEF SendMail(TransporterMail obj);
        MessageEF SendMail_EUP(TransporterMail obj);
        MessageEF SendLicenseApplicationAck(LicenseMail licenseMail);
        MessageEF SendMail_AddVehiclesAck(TransporterMail obj);
        MessageEF SendPaymentAwaitedMail(TransporterMail obj);
        MessageEF SendNonPermitPaymentMail(LicensePaymentMail licensePaymentMail);
        MessageEF SendLicenseApprovedAck(LicenseMail obj);
        MessageEF SendTailingDamMail(UserMasterModel userMasterModel);
        MessageEF SendPermitPaymentAck(PaymentEF obj);
    }
}
