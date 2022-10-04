using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using userregistrationEF;
using userregistrationEFApi.Model.CommonRailwaySiding;
using Microsoft.AspNetCore.Authorization;

namespace userregistrationEFApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class CommonRailwaySidingController : ControllerBase
    {
        public ICommonRailwaySidingProvider _objICommon;
        public CommonRailwaySidingController(ICommonRailwaySidingProvider objCommon)
        {
            _objICommon = objCommon;
        }

        public MessageEF AddCommonRailwaySiding(CommonRailwaySidingModel objCommon)
        {
            return _objICommon.AddCommonRailwaySiding(objCommon);
        }

        public async Task<List<CRSDropDown>> BindCRSDDL(CRSDropDown objWorkFlow)
        {
            return await _objICommon.BindCRSDDL(objWorkFlow);
        }

        public async Task<List<CommonRailwaySidingModel_Query>> ViewCommonRailwaySiding(CommonRailwaySidingModel_Query objCommon)
        {
            return await _objICommon.ViewCommonRailwaySiding(objCommon);
        }

        public MessageEF DeleteCommonRailwaySiding(CommonRailwaySidingModel objCRS)
        {
            return _objICommon.DeleteCommonRailwaySiding(objCRS);
        }

        public async Task<CommonRailwaySidingModel> ViewCommonRailwaySidingDetails(CommonRailwaySidingModel objCommon)
        {
            return await _objICommon.ViewCommonRailwaySidingDetails(objCommon);
        }

        public async Task<List<CommonRailwaySidingInboxEF_Query>> CommonRailwaySidinginbox(CommonRailwaySidingInboxEF_Query objCommon)
        {

            return await _objICommon.CommonRailwaySidinginbox(objCommon);
        }
        public MessageEF TakeAction(CommonRailwaySidingTakeAction objCommon)
        {
            return _objICommon.TakeAction(objCommon);
        }

        public MessageEF CreatenewUser(CommonRailwaySidingTakeAction objCRS)
        {
            return _objICommon.CreatenewUser(objCRS);
        }


        public MessageEF Main(SMS sMS )
        {
            return _objICommon.Main(sMS);
        }

        public MessageEF ExcelFileUpload(ExcelDataValues objupload)
        {
            return _objICommon.ExcelfileUpload(objupload);
        }
    }
}
