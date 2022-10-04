using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;

namespace userregistrationApp.Models.MailService
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
        MessageEF SendTailingDamMail(UserMasterModel userMasterModel);
    }
}
