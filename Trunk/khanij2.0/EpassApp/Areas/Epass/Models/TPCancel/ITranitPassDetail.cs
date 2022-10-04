using EpassEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApp.Areas.Epass.Models.TPCancel
{
    public interface ITranitPassDetail
    {
        List<TransitpassCancelEF> GeteTransitpassDetails(TransitpassCancelEF objTPcancel);
        MessageEF TPCancel(TransitpassCancelEF objcancel);
    }
}
