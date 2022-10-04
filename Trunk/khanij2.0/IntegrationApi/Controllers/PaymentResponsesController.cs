﻿using IntegrationApi.Model.PaymentResponse;
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
    public class PaymentResponsesController : ControllerBase
    {
        private readonly IPaymentResponseProvider paymentResponseProvider;

        public PaymentResponsesController(IPaymentResponseProvider paymentResponseProvider)
        {
            this.paymentResponseProvider = paymentResponseProvider;
        }

        /// <summary>
        /// Get Payment Response ID
        /// </summary>
        /// <param name="paymentResponseDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> GetPaymentResponseID(PaymentResponseDetails paymentResponseDetails)
        {
            return await paymentResponseProvider.GetPaymentResponseID(paymentResponseDetails);
        }

        /// <summary>
        /// Add Payment Response
        /// </summary>
        /// <param name="paymentTransaction"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddPaymentResponse(PaymentTransaction paymentTransaction)
        {
            return await paymentResponseProvider.AddPaymentResponse(paymentTransaction);
        }

        /// <summary>
        /// Add Vehicle Payment Response
        /// </summary>
        /// <param name="paymentTransaction"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<TransporterModel> AddVehiclePaymentResponse(PaymentResponseDetails paymentResponseDetails)
        {
            return await paymentResponseProvider.AddVehiclePaymentResponse(paymentResponseDetails);
        }

        /// <summary>
        /// Add License First Payment
        /// </summary>
        /// <param name="paymentResponseDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<UserMasterModel> AddLicenseFirstPayment(PaymentResponseDetails paymentResponseDetails)
        {
            return await paymentResponseProvider.AddLicenseFirstPayment(paymentResponseDetails);
        }

        /// <summary>
        /// Add License Security Payment
        /// </summary>
        /// <param name="paymentResponseDetails"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<UserMasterModel> AddLicenseSecurityPayment(PaymentResponseDetails paymentResponseDetails)
        {
            return await paymentResponseProvider.AddLicenseSecurityPayment(paymentResponseDetails);
        }
        /// <summary>
        /// Add Lease Deed Payment
        /// </summary>
        /// <param name="paymentResponseDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<UserMasterModel> AddLicenseLeaseDeedPayment(PaymentResponseDetails paymentResponseDetails)
        {
            return await paymentResponseProvider.AddLicenseLeaseDeedPayment(paymentResponseDetails);
        }
        [HttpPost]
        public async Task<MessageEF> AddSBIDetails(PaymentEF paymentTransaction)
        {
            return await paymentResponseProvider.AddSBIDetails(paymentTransaction);
        }
        [HttpPost]
        public async Task<PaymentEF> SBIDetails(PaymentEF paymentTransaction)
        {
            return await paymentResponseProvider.SBIDetails(paymentTransaction);
        }
    }
}
