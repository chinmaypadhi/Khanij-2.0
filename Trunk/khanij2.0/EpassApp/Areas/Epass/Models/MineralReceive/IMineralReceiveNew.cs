using EpassEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApp.Areas.Epass.Models.MineralReceive
{
    public interface IMineralReceiveNew
    { 
        List<EndUser_ETransitPassModel> MineralReceiveData(EndUser_ETransitPassModel objtran);
        List<EndUser_ETransitPassModel> BindReceivePermit(EndUser_ETransitPassModel objtran);
        List<EndUser_ETransitPassModel> GetGridData(EndUser_ETransitPassModel objtran);
        string UpdateMineralReceipt(EndUser_ETransitPassModel model);

        List<EndUser_ETransitPassModel> GetClosedGridData(MineralReceiveModel objtran);

    }
}
