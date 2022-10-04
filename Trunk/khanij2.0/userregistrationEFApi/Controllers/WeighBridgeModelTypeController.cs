using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEFApi.Model.WeighBridge;
using userregistrationEF;

namespace userregistrationEFApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class WeighBridgeModelTypeController : ControllerBase
    {
        IWeighBrideModelTypeProvider objIwbmodeltypeprovider;
        public WeighBridgeModelTypeController(IWeighBrideModelTypeProvider objIwbmodeltypeprovider)
        {
            this.objIwbmodeltypeprovider = objIwbmodeltypeprovider;

        }
        [HttpPost]
        public async Task<ActionResult<List<ViewWeighBridgeModelTypeModel>>> ViewByMake(ViewWeighBridgeModelTypeModel obj)
        {
            return await objIwbmodeltypeprovider.ViewByMake(obj);
        }
    }
}
