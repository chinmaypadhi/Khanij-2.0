using HomeEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [Authorize]
        public MessageEF Get(MessageEF messageEF)
        {
            messageEF.Msg = "Hey i'm only for authorized users";
            return messageEF;
        }
    }
}
