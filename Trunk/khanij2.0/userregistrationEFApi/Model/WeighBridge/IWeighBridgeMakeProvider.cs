using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;

namespace userregistrationEFApi.Model.WeighBridge
{
    public interface IWeighBridgeMakeProvider
    {
        Task<List<ViewWeighBridgeMakeModel>> View();
    }
}
