using EpassApi.Model.CaseOfIrregularity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpassEF;

namespace EpassApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class CheckPostInChergeController : ControllerBase
    {
        private ICaseOfIrregularityProvider _objcaseOfIrregularityProvider;
        public CheckPostInChergeController(ICaseOfIrregularityProvider objcaseOfIrregularityProvider)
        {
            _objcaseOfIrregularityProvider = objcaseOfIrregularityProvider;
        }
        [HttpPost]
        public async Task< List<CheckPostIrrgModel>> TransitPassDetails(CheckPostIrrgModel checkPostIrrgModel)
        {
            return await _objcaseOfIrregularityProvider.GetDetailsFromTP(checkPostIrrgModel);
        }
        [HttpPost]
        public async Task<List<CheckPostIrrgModel>> ExcessMineralForCheckPost(CheckPostIrrgModel checkPostIrrgModel)
        {
            return await _objcaseOfIrregularityProvider.ExcessMineralForCheckPost(checkPostIrrgModel);
        }
    }
}
