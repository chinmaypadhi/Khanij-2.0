using IntegrationEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace IntegrationApp.Models.SMSService
{
    public interface ISMSModel
    { 
        MessageEF Main(SMS sMS); 
    }
}
