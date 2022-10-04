using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReturnEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnApi.Controllers
{
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
