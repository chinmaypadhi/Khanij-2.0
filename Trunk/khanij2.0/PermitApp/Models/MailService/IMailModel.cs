using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermitEF;

namespace PermitApp.Models.MailService
{
    public interface IMailModel
    { 
        
        MessageEF SendLicenseApplicationAck(LicenseMail licenseMail);
       
    }
}
