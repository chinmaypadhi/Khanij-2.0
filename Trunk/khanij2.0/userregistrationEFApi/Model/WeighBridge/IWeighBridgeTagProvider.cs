using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;

namespace userregistrationEFApi.Model.WeighBridge
{
    public interface IWeighBridgeTagProvider
    {
        Task<List<ViewWeighBridgeTagModel>> ViewUserType();
        Task<List<ViewWeighBridgeTagModel>> ViewDistrict(ViewWeighBridgeTagModel obj);
        Task<List<ViewWeighBridgeTagModel>> ViewUserByDistrict(ViewWeighBridgeTagModel obj);
        Task<List<ViewWeighBridgeTagModel>> ViewWeighBridgeByUser(ViewWeighBridgeTagModel obj);
        Task<List<ViewWeighBridgeTagModel>> ViewWeighBridgeTag(ViewWeighBridgeTagModel obj);
        Task<List<ViewWeighBridgeTagModel>> ViewWeighBridgeTagHistory(ViewWeighBridgeTagModel obj);
        Task<List<ViewWeighBridgeTagModel>> ViewWeighBridgeTagApproval(ViewWeighBridgeTagModel obj);
        Task<List<ViewWeighBridgeTagModel>> ViewWeighBridgeTagRequest(ViewWeighBridgeTagModel obj);
        Task<AddWeighBridgeTagModel> WBTagByTagID(ViewWeighBridgeTagModel obj);
        Task<MessageEF> WBTagSave(AddWeighBridgeTagModel obj);
        Task<MessageEF> WBTagCheck(AddWeighBridgeTagModel obj);
        Task<MessageEF> WBTagForward(ViewWeighBridgeTagModel obj);
        Task<MessageEF> WBTagReject(ViewWeighBridgeTagModel obj);
        Task<MessageEF> WBTagApprove(ViewWeighBridgeTagModel obj);
        Task<MessageEF> WBTagEdit(AddWeighBridgeTagModel obj);
        Task<MessageEF> WBTagRequest(ViewWeighBridgeTagModel obj);
        Task<List<ViewWeighBridgeTagModel>> ViewWeighBridgeActionList(ViewWeighBridgeTagModel obj);
    }
}
