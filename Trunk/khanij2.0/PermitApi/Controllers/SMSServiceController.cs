using PermitApi.Model.SMSService;
using PermitEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermitApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class SMSServiceController : ControllerBase
    {
        private readonly ISMSProvider sMSProvider;

        public SMSServiceController(ISMSProvider sMSProvider)
        {
            this.sMSProvider = sMSProvider;
        }

        /// <summary>
        /// Send OTP to Mobile
        /// </summary>
        /// <param name="sMS"></param>
        /// <returns></returns>
        public MessageEF Main(SMS sMS)
        {
            return sMSProvider.Main(sMS);
        }
    }
}
