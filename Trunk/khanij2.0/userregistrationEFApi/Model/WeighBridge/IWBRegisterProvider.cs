using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;

namespace userregistrationEFApi.Model.WeighBridge
{
    public interface IWBRegisterProvider
    {
        Task<MessageEF> WBRegister(AddWeighBridgeModel objmodel);
        Task<MessageEF> WBIndependentRegister(AddIndependentWeighBridgeModel objmodel);
        Task<MessageEF> WBRenewal(AddWeighBridgeRenewal objmodel);
        Task<MessageEF> WBRegisterEdit(AddWeighBridgeModel objmodel);
        Task<MessageEF> WBForward(ViewWeighBridgeModel objmodel);
        Task<MessageEF> WBCheck(ViewWeighBridgeModel objmodel);
        Task<MessageEF> WBApprove(ViewWeighBridgeModel objmodel);
        Task<MessageEF> WBCheckContact(ViewWeighBridgeModel objmodel);
        Task<List<ViewWeighBridgeModel>> ViewWBByUserID(ViewWeighBridgeModel objmodel);
        Task<List<ViewWeighBridgeModel>> RenewalWBByUserID(ViewWeighBridgeModel objmodel);
        Task<List<ViewWeighBridgeModel>> HistoryWBByID(ViewWeighBridgeModel objmodel);
        Task<AddWeighBridgeModel> WBByID(ViewWeighBridgeModel objmodel);
        Task<List<ViewWeighBridgeModel>> ViewWBByDistrict(ViewWeighBridgeModel objmodel);
        Task<ViewWeighBridgeModel> ViewWBByWeighBridgeID(ViewWeighBridgeModel objmodel);
        Task<ViewIndependentUserDetailModel> ViewIndependentByUserID(ViewIndependentUserDetailModel objmodel);
        Task<List<ViewWeighBridgeModel>> ViewWeighBridgeTagActionList(ViewWeighBridgeModel obj);

    }
}
