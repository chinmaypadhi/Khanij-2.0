using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
using userregistrationEFApi.Model.WeighBridge;

namespace userregistrationEFApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class WeighBridgeTagController : ControllerBase
    {
        private readonly IWeighBridgeTagProvider objIWBTagProvider;
        public WeighBridgeTagController(IWeighBridgeTagProvider objIWBTagProvider)
        {
            this.objIWBTagProvider = objIWBTagProvider;
        }
        [HttpPost]
        public async Task<List<ViewWeighBridgeTagModel>> ViewDistrict(ViewWeighBridgeTagModel obj)
        {
            return await objIWBTagProvider.ViewDistrict(obj);
        }
        [HttpPost]
        public async Task<List<ViewWeighBridgeTagModel>> ViewUserByDistrict(ViewWeighBridgeTagModel obj)
        {
            return await objIWBTagProvider.ViewUserByDistrict(obj);
        }
        [HttpPost]
        public async Task<List<ViewWeighBridgeTagModel>> ViewWeighBridgeByUser(ViewWeighBridgeTagModel obj)
        {
            return await objIWBTagProvider.ViewWeighBridgeByUser(obj);
        }
        [HttpPost]
        public async Task<List<ViewWeighBridgeTagModel>> ViewWeighBridgeTag(ViewWeighBridgeTagModel obj)
        {
            return await objIWBTagProvider.ViewWeighBridgeTag(obj);
        }
        [HttpPost]
        public async Task<List<ViewWeighBridgeTagModel>> ViewWeighBridgeTagHistory(ViewWeighBridgeTagModel obj)
        {
            return await objIWBTagProvider.ViewWeighBridgeTagHistory(obj);
        }
        [HttpPost]
        public async Task<List<ViewWeighBridgeTagModel>> ViewWeighBridgeTagApproval(ViewWeighBridgeTagModel obj)
        {
            return await objIWBTagProvider.ViewWeighBridgeTagApproval(obj);
        }
        [HttpPost]
        public async Task<List<ViewWeighBridgeTagModel>> ViewWeighBridgeTagRequest(ViewWeighBridgeTagModel obj)
        {
            return await objIWBTagProvider.ViewWeighBridgeTagRequest(obj);
        }
        [HttpPost]
        public async Task<AddWeighBridgeTagModel> WBTagByTagID(ViewWeighBridgeTagModel obj)
        {
            return await objIWBTagProvider.WBTagByTagID(obj);
        }
        [HttpPost]
        public async Task<MessageEF> WBTagSave(AddWeighBridgeTagModel obj)
        {
            return await objIWBTagProvider.WBTagSave(obj);
        }
        [HttpPost]
        public async Task<MessageEF> WBTagCheck(AddWeighBridgeTagModel obj)
        {
            return await objIWBTagProvider.WBTagCheck(obj);
        }
        [HttpPost]
        public async Task<MessageEF> WBTagEdit(AddWeighBridgeTagModel obj)
        {
            return await objIWBTagProvider.WBTagEdit(obj);
        }
        [HttpPost]
        public async Task<MessageEF> WBTagForward(ViewWeighBridgeTagModel obj)
        {
            return await objIWBTagProvider.WBTagForward(obj);
        }
        [HttpPost]
        public async Task<MessageEF> WBTagReject(ViewWeighBridgeTagModel obj)
        {
            return await objIWBTagProvider.WBTagReject(obj);
        }
        [HttpPost]
        public async Task<MessageEF> WBTagApprove(ViewWeighBridgeTagModel obj)
        {
            return await objIWBTagProvider.WBTagApprove(obj);
        }
        [HttpPost]
        public async Task<MessageEF> WBTagRequest(ViewWeighBridgeTagModel obj)
        {
            return await objIWBTagProvider.WBTagRequest(obj);
        }
        [HttpPost]
        public async Task<List<ViewWeighBridgeTagModel>> ViewWeighBridgeActionList(ViewWeighBridgeTagModel obj)
        {
            return await objIWBTagProvider.ViewWeighBridgeActionList(obj);
        }
    }
}
