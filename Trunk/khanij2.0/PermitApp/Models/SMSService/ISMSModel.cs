using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermitEF;

namespace PermitApp.Models.SMSService
{
    public interface ISMSModel
    { 
        MessageEF Main(SMS sMS); 
    }
}
