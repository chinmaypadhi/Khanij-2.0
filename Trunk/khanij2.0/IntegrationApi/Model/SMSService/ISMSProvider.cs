using IntegrationApi.Repository;
using IntegrationEF;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Threading.Tasks;

namespace IntegrationApi.Model.SMSService
{
    public interface ISMSProvider : IDisposable, IRepository
    {
        MessageEF Main(SMS sMS);
    }
}
