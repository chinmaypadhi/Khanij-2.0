using IntegrationApi.Model.MailService;
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
    public class MailServiceController : ControllerBase
    {
        private readonly IMailProvider mailProvider;

        public MailServiceController(IMailProvider mailProvider)
        {
            this.mailProvider = mailProvider;
        }

        /// <summary>
        /// Get Forgot Password
        /// </summary>
        /// <param name="forgotPassword"></param>
        /// <returns></returns>

        [HttpPost]
        public MessageEF ForgotPasswordMail(ForgotPassword forgotPassword)
        {
            return mailProvider.ForgotPasswordMail(forgotPassword);
        }

        /// <summary>
        /// Send Mail To Transporter
        /// </summary>
        /// <param name="transporterMail"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF SendMail(TransporterMail transporterMail)
        {
            return mailProvider.SendMail(transporterMail);
        }

        /// <summary>
        /// Send Mail EUP
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF SendMail_EUP(TransporterMail obj)
        {
            return mailProvider.SendMail_EUP(obj);
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
        /// Add Vehicle Acknowledgement
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF SendMail_AddVehiclesAck(TransporterMail obj)
        {
            return mailProvider.SendMail_AddVehiclesAck(obj);
        }

        /// <summary>
        /// Send Payment Awaited Mail
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF SendPaymentAwaitedMail(TransporterMail obj)
        {
            return mailProvider.SendPaymentAwaitedMail(obj);
        }

        /// <summary>
        /// Send Non Permit Payment Mail
        /// </summary>
        /// <param name="licensePaymentMail"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF SendNonPermitPaymentMail(LicensePaymentMail licensePaymentMail)
        {
            return mailProvider.SendNonPermitPaymentMail(licensePaymentMail);
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

        /// <summary>
        /// Send Tailing DamMail
        /// </summary>
        /// <param name="userMasterModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF SendTailingDamMail(UserMasterModel userMasterModel)
        {
            return mailProvider.SendTailingDamMail(userMasterModel);
        }
        [HttpPost]
        public MessageEF SendPermitPaymentAck(PaymentEF obj)
        {
            return mailProvider.SendPermitPaymentAck(obj);
        }
    }
}
