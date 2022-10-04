using IntegrationEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace IntegrationApp.Models.MailService
{
    public interface IMailModel
    { 
        MessageEF SendMail(TransporterMail obj);
        MessageEF SendMail_EUP(TransporterMail obj);
        MessageEF SendLicenseApplicationAck(LicenseMail licenseMail);
        MessageEF SendMail_AddVehiclesAck(TransporterMail obj);
        MessageEF SendPaymentAwaitedMail(TransporterMail obj);
        MessageEF SendNonPermitPaymentMail(LicensePaymentMail licensePaymentMail);
        MessageEF SendLicenseApprovedAck(LicenseMail obj);
        MessageEF SendPermitPaymentAck(PaymentEF obj);
    }
}
