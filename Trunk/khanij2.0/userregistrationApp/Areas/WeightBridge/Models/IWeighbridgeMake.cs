using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;

namespace userregistrationApp.Areas.WeightBridge.Models
{
    public interface IWeighbridgeMake
    {
        List<ViewWeighBridgeMakeModel> View(ViewWeighBridgeMakeModel obj);
    }
}
