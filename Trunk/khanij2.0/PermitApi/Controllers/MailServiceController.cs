using PermitApi.Model.MailService;
using PermitEF;
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
    public class MailServiceController : ControllerBase
    {
        private readonly IMailProvider mailProvider;

        public MailServiceController(IMailProvider mailProvider)
        {
            this.mailProvider = mailProvider;
        }

        

        /// <summary>
        /// SendnLicense Application Ack
        /// </summary>
        /// <param name="licenseMail"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF SendLicenseApplicationAck(LicenseMail licenseMail)
        {
            return mailProvider.SendLicenseApplicationAck(licenseMail);
        }

       
      

        /// <summary>
        /// Send License Approved Acknowledgement
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF SendLicenseApprovedAck(LicenseMail obj)
        {
            return mailProvider.SendLicenseApprovedAck(obj);
        }
       
    }
}
