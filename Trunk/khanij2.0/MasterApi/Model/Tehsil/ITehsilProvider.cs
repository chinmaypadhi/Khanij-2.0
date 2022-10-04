using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.Tehsil
{
    public interface ITehsilProvider : IDisposable, IRepository
    {
        MessageEF AddTehsil(TehsilModel tehsilModel);
        List<TehsilModel> ViewTehsil(TehsilModel tehsilModel);
        TehsilModel EditTehsil(TehsilModel tehsilModel);
        MessageEF DeleteTehsil(TehsilModel tehsilModel);
        MessageEF UpdateTehsil(TehsilModel tehsilModel);
    }
}
