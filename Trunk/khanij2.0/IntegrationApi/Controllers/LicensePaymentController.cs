using IntegrationApi.Model.LicensePaymentDetails;
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
    public class LicensePaymentController : ControllerBase
    {
        private readonly ILicensePaymentProvider licensePaymentProvider;

        public LicensePaymentController(ILicensePaymentProvider licensePaymentProvider)
        {
            this.licensePaymentProvider = licensePaymentProvider;
        }

        /// <summary>
        /// Get License Payment Details
        /// </summary>
        /// <param name="licensePaymentDetail"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> GetLicensePaymentDetails(LicensePaymentDetail licensePaymentDetail)
        {
            return await licensePaymentProvider.GetLicensePaymentDetails(licensePaymentDetail);
        }

        /// <summary>
        /// Get Payment Gateway
        /// </summary>
        /// <param name="licensePaymentDetail"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<PaymentModel> GetLicensePaymentGateway(LicensePaymentDetail licensePaymentDetail)
        {
            return await licensePaymentProvider.GetLicensePaymentGateway(licensePaymentDetail);
        }

        /// <summary>
        /// Insert License Payment Request
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> InsertLicensePaymentRequest(PaymentModel model)
        {
            return await licensePaymentProvider.InsertLicensePaymentRequest(model);
        }

        /// <summary>
        /// Add Security Deposit
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddSecurityDeposit(LicenseApplication licenseApplication)
        {
            return await licensePaymentProvider.AddSecurityDeposit(licenseApplication);
        }
        public async Task<MessageEF> AddLeaseDeedFine(LicenseApplication licenseApplication)
        {
            return await licensePaymentProvider.AddLeaseDeedFine(licenseApplication);
        }
    }
}
