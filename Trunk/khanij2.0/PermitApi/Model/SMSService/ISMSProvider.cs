using PermitApi.Repository;
using PermitEF;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Threading.Tasks;

namespace PermitApi.Model.SMSService
{
    public interface ISMSProvider : IDisposable, IRepository
    {
        MessageEF Main(SMS sMS);
    }
}
