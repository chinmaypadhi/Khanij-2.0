using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class WeighBridgeRegistrationController : ControllerBase
    {
        private readonly IAreaTypeProvider objIareatypeprovider;
        private readonly IWBRegisterProvider objIwbregisterprovider;
        public WeighBridgeRegistrationController(IWBRegisterProvider objIwbregisterprovider, IAreaTypeProvider objIareatypeprovider)
        {
            this.objIareatypeprovider = objIareatypeprovider;
            this.objIwbregisterprovider = objIwbregisterprovider;
        }
        [HttpPost]
        public async Task<MessageEF> WBRegister(AddWeighBridgeModel obj)
        {
            return await objIwbregisterprovider.WBRegister(obj);
        }
        [HttpPost]
        public async Task<MessageEF> WBIndependentRegister(AddIndependentWeighBridgeModel obj)
        {
            return await objIwbregisterprovider.WBIndependentRegister(obj);
        }
        [HttpPost]
        public async Task<MessageEF> WBRegisterEdit(AddWeighBridgeModel obj)
        {
            return await objIwbregisterprovider.WBRegisterEdit(obj);
        }
        [HttpPost]
        public async Task<MessageEF> WBForward(ViewWeighBridgeModel obj)
        {
            return await objIwbregisterprovider.WBForward(obj);
        }
        [HttpPost]
        public async Task<MessageEF> WBCheck(ViewWeighBridgeModel obj)
        {
            return await objIwbregisterprovider.WBCheck(obj);
        }
        [HttpPost]
        public async Task<MessageEF> WBApprove(ViewWeighBridgeModel obj)
        {
            return await objIwbregisterprovider.WBApprove(obj);
        }
        [HttpPost]
        public async Task<MessageEF> WBCheckContact(ViewWeighBridgeModel obj)
        {
            return await objIwbregisterprovider.WBCheckContact(obj);
        }
        [HttpPost]
        public async Task<MessageEF> WBRenewal(AddWeighBridgeRenewal obj)
        {
            return await objIwbregisterprovider.WBRenewal(obj);
        }
        [HttpPost]
        public async Task<ActionResult<List<AreaDetails>>> GetLandTypeList(AreaDetails viewAreaDetails)
        {
            return await objIareatypeprovider.GetLandTypeList(viewAreaDetails);
        }
        [HttpPost]
        public async Task<ActionResult<List<ViewWeighBridgeModel>>> ViewWBByUserID(ViewWeighBridgeModel obj)
        {
            return await objIwbregisterprovider.ViewWBByUserID(obj);
        }
        [HttpPost]
        public async Task<ActionResult<List<ViewWeighBridgeModel>>> RenewalWBByUserID(ViewWeighBridgeModel obj)
        {
            return await objIwbregisterprovider.RenewalWBByUserID(obj);
        }
        [HttpPost]
        public async Task<ActionResult<ViewWeighBridgeModel>> ViewWBByWeighBridgeID(ViewWeighBridgeModel obj)
        {
            return await objIwbregisterprovider.ViewWBByWeighBridgeID(obj);
        }
        [HttpPost]
        public async Task<AddWeighBridgeModel> WBByID(ViewWeighBridgeModel obj)
        {
            return await objIwbregisterprovider.WBByID(obj);
        }
        [HttpPost]
        public async Task<ViewIndependentUserDetailModel> ViewIndependentByUserID(ViewIndependentUserDetailModel obj)
        {
            return await objIwbregisterprovider.ViewIndependentByUserID(obj);
        }
        [HttpPost]
        public async Task<List<ViewWeighBridgeModel>> HistoryWBByID(ViewWeighBridgeModel obj)
        {
            return await objIwbregisterprovider.HistoryWBByID(obj);
        }
        [HttpPost]
        public async Task<ActionResult<List<ViewWeighBridgeModel>>> ViewWBByDistrict(ViewWeighBridgeModel obj)
        {
            return await objIwbregisterprovider.ViewWBByDistrict(obj);
        }
        [HttpPost]
        public async Task<List<ViewWeighBridgeModel>> ViewWeighBridgeTagActionList(ViewWeighBridgeModel obj)
        {
            return await objIwbregisterprovider.ViewWeighBridgeTagActionList(obj);
        }
    }
}
