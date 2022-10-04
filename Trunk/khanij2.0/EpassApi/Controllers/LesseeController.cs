using EpassApi.Model.Lessee;
using EpassEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class LesseeController : ControllerBase
    {
        public ITransitpassDetailsProvider _objTransitpassDetails;
        public LesseeController(ITransitpassDetailsProvider objTransitpassDetails)
        {
            _objTransitpassDetails = objTransitpassDetails;
        }
          [HttpPost]////Dinesh 25Apr2022
        public async Task<List<TransitpassCancelEF>> GeteTransitpassDetails(TransitpassCancelEF objLease)
        {
            return await _objTransitpassDetails.eTransitpassDetails(objLease);
        }

        [HttpPost]////Dinesh 25Apr2022
        public MessageEF TPcancel(TransitpassCancelEF model)
        {
            return _objTransitpassDetails.CancelTP(model);
        }
    }
}
