using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;

namespace userregistrationEFApi.Utility.MailService
{
    public interface IMailServiceProvider
    {
        MessageEF SendMail_AddVehiclesAck(TransporterMail obj);
        MessageEF SendMail_VehicleBreakdownTransporter(BreakdownRequestDetailsByMobileApp obj); 
    }
}
