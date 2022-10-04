using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;

namespace userregistrationApp.Areas.WeightBridge.Models
{
    public interface IWeighBridge
    {
        MessageEF WBRegister(AddWeighBridgeModel obj);
        MessageEF WBRegisterEdit(AddWeighBridgeModel obj);
        MessageEF WBForward(ViewWeighBridgeModel obj);
        MessageEF WBRenewal(AddWeighBridgeRenewal obj);
        MessageEF WBCheck(ViewWeighBridgeModel obj);
        MessageEF WBCheckContact(ViewWeighBridgeModel obj);
        List<ViewWeighBridgeModel> ViewWBByUserID(ViewWeighBridgeModel obj);
        List<ViewWeighBridgeModel> HistoryWBByID(ViewWeighBridgeModel obj);
        List<ViewWeighBridgeModel> RenewalWBByUserID(ViewWeighBridgeModel obj);
        ViewWeighBridgeModel ViewWBByWeighBridgeID(ViewWeighBridgeModel obj);
        AddWeighBridgeModel WBByID(ViewWeighBridgeModel obj);
        List<ViewWeighBridgeModel> ViewWBByDistrict(ViewWeighBridgeModel obj);
        MessageEF WBApprove(ViewWeighBridgeModel obj);
        MessageEF WBIndependentRegister(AddIndependentWeighBridgeModel obj);
        ViewIndependentUserDetailModel ViewIndependentByUserID(ViewIndependentUserDetailModel obj);
        List<ViewWeighBridgeModel> ViewWeighBridgeTagActionList(ViewWeighBridgeModel obj);
    }
}
