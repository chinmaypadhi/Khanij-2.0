using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.TransportationMode
{
    public interface ITransportationModeModel
    {
        MessageEF Add(TransportationModeMaster objTR);
        MessageEF Update(TransportationModeMaster objTR);
        List<TransportationModeMaster> View(TransportationModeMaster objTR);
        MessageEF Delete(TransportationModeMaster objTR);
        TransportationModeMaster Edit(TransportationModeMaster objTR);
    }
}
