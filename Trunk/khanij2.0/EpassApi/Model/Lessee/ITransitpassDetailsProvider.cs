using EpassApi.Repository;
using EpassEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApi.Model.Lessee
{
     public interface ITransitpassDetailsProvider: IDisposable, IRepository
    {
        Task<List<TransitpassCancelEF>> eTransitpassDetails(TransitpassCancelEF objTPDetails);
        MessageEF CancelTP(TransitpassCancelEF obj);
     }
}
