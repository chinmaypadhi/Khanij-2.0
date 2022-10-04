using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;

namespace userregistrationEFApi.Model.WeighBridge
{
    public interface IAreaTypeProvider
    {
        Task<List<AreaDetails>> GetLandTypeList(AreaDetails obj);
    }
}
