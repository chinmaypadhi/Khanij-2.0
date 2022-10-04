using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupportEF;

namespace SupportApp.Models.MailService
{
    public interface IMailModel
    { 
        MessageEF SendMail(GrievanceMail obj);
        MessageEF SendMail_EUP(GrievanceMail obj);
    }
}
