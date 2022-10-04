using PermitApi.Repository;
using PermitEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermitApi.Model.MailService
{
    public interface IMailProvider : IDisposable, IRepository
    {
        MessageEF SendLicenseApplicationAck(LicenseMail licenseMail);
        MessageEF SendLicenseApprovedAck(LicenseMail obj);
    }
}
