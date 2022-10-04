using IntegrationApi.Model.Noticeltr;
using IntegrationEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class NoticeLtrController : ControllerBase
    {
        private readonly INoticeLtr INoticeLtr;

        public NoticeLtrController(INoticeLtr _INoticeLtr)
        {
            this.INoticeLtr = _INoticeLtr;
        }
        [HttpPost]
        public async Task<List<Notice>> Payments(Notice objmodel)
        {
            return await INoticeLtr.PaymentsView(objmodel);
        }
        [HttpPost]
        public async Task<MessageEF> PaymentsStatus(Notice objmodel)
        {
            return await INoticeLtr.PaymentsStatus(objmodel);
        }

    }
}
