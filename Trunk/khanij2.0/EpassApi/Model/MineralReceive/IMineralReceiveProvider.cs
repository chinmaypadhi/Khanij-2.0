using EpassEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApi.Model.MineralReceive
{
     public interface IMineralReceiveProvider
    {
        Task<List<EndUser_ETransitPassModel>> MineralReceiveData(EndUser_ETransitPassModel objtran);
        Task<List<EndUser_ETransitPassModel>> BindReceivePermit(EndUser_ETransitPassModel objtran);
        Task<List<EndUser_ETransitPassModel>> GetGridData(EndUser_ETransitPassModel objtran);
        Task<string> UpdateMineralReceipt(EndUser_ETransitPassModel model);

        Task<List<EndUser_ETransitPassModel>> GetClosedGridData(MineralReceiveModel objtran);
    }
}
