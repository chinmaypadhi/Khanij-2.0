
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.TransportationMode
{
    public interface ITransportationModeProvider : IDisposable, IRepository
    {
        MessageEF AddTransportationMode(TransportationModeMaster objTR);
        List<TransportationModeMaster> ViewTransportationMode(TransportationModeMaster objTR);
        TransportationModeMaster EditTransportationMode(TransportationModeMaster objTR);
        MessageEF DeleteTransportationMode(TransportationModeMaster objTR);
        MessageEF UpdateTransportationMode(TransportationModeMaster objTR);
    }
}
