using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PermitApi.Model.DemandNote;
using PermitEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermitApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class DemandNoteController : ControllerBase
    {
        private IDemandNoteProvider objIDemandNoteProvider;
        public DemandNoteController(IDemandNoteProvider objIDemandNoteProvider)
        {
            this.objIDemandNoteProvider = objIDemandNoteProvider;
        }
        //[HttpPost]
        //public async Task<List<DemandNoteCodePayment>> GetPaymentDemandNote(DemandNoteCodePayment obj)
        //{
        //    return await objIDemandNoteProvider.GetPaymentDemandNote(obj);
        //}
    }
}
