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
    public class WeighBridgeMakeController : ControllerBase
    {
        private readonly IWeighBridgeMakeProvider objImakeprovider;
        public WeighBridgeMakeController(IWeighBridgeMakeProvider objImakeprovider)
        {
            this.objImakeprovider = objImakeprovider;
        }
        [HttpPost]
        public async Task<ActionResult<List<ViewWeighBridgeMakeModel>>> View()
        {
            return await objImakeprovider.View();
        }
    }
}
