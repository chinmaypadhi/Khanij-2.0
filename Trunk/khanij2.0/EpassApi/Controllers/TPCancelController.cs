using EpassApi.Model.eCancel;
using EpassEF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class TPCancelController : Controller
    {
        private IeCancelProvider _objIeCancelProvider;
        public TPCancelController(IeCancelProvider eCancelProvider)
        {
            _objIeCancelProvider = eCancelProvider;
        }
        [HttpPost]//Dinesh 19apr22
        public async Task<List<TPCancelModelEF>> GetTP_Cancel(TPCancelModelEF obj)
        {
            return await _objIeCancelProvider.GetTP_Cancel(obj);
        }
    }
}
