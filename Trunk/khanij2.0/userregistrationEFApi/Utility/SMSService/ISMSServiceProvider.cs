using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;

namespace userregistrationEFApi.Utility.SMSService
{
    public interface ISMSServiceProvider
    {
        MessageEF Main(SMS sMS);
    }
}
