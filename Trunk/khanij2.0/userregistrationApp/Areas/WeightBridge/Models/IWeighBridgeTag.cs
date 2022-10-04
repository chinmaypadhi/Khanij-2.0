using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;

namespace userregistrationApp.Areas.WeightBridge.Models
{
    public interface IWeighBridgeTag
    {
        List<ViewWeighBridgeTagModel> ViewUserType(ViewWeighBridgeTagModel obj);
        List<ViewWeighBridgeTagModel> ViewDistrict(ViewWeighBridgeTagModel obj);
        List<ViewWeighBridgeTagModel> ViewUserByDistrict(ViewWeighBridgeTagModel obj);
        List<ViewWeighBridgeTagModel> ViewWeighBridgeByUser(ViewWeighBridgeTagModel obj);
        List<ViewWeighBridgeTagModel> ViewWeighBridgeTag(ViewWeighBridgeTagModel obj);
        List<ViewWeighBridgeTagModel> ViewWeighBridgeTagHistory(ViewWeighBridgeTagModel obj);
        List<ViewWeighBridgeTagModel> ViewWeighBridgeTagApproval(ViewWeighBridgeTagModel obj);
        List<ViewWeighBridgeTagModel> ViewWeighBridgeTagRequest(ViewWeighBridgeTagModel obj);
        AddWeighBridgeTagModel WBTagByTagID(ViewWeighBridgeTagModel obj);
        MessageEF WBTagSave(AddWeighBridgeTagModel objmodel);
        MessageEF WBTagCheck(AddWeighBridgeTagModel objmodel);
        MessageEF WBTagEdit(AddWeighBridgeTagModel objmodel);
        MessageEF WBTagForward(ViewWeighBridgeTagModel obj);
        MessageEF WBTagApprove(ViewWeighBridgeTagModel obj);
        MessageEF WBTagReject(ViewWeighBridgeTagModel obj);
        MessageEF WBTagRequest(ViewWeighBridgeTagModel obj);
        List<ViewWeighBridgeTagModel> ViewWeighBridgeActionList(ViewWeighBridgeTagModel obj);
    }
}
