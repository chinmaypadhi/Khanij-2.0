using EpassApi.Model.GeneratedRTPAPP;
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
    public class GeneratedRTPAPPController : ControllerBase
    {
        private IGeneratedRTPAPPProvider _objIGeneratedRTPAPPPProvider;
        
        public GeneratedRTPAPPController(IGeneratedRTPAPPProvider objIGeneratedRTPAPPPProvider)
        {
            _objIGeneratedRTPAPPPProvider = objIGeneratedRTPAPPPProvider;
        }
        public async Task<List<FinalForwadingNoteEF>> GeneratedRTPAPPData(FinalForwadingNoteModelEF objtran)
        {
            return await _objIGeneratedRTPAPPPProvider.GetDGDMOFN(objtran);
        }
    }
}
