using IntegrationApi.Model.VehiclePaymentDetails;
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
    public class VehiclePaymentController : ControllerBase
    {
        private readonly IVehiclePaymentProvider vehiclePaymentProvider;

        public VehiclePaymentController(IVehiclePaymentProvider vehiclePaymentProvider)
        {
            this.vehiclePaymentProvider = vehiclePaymentProvider;
        }

        /// <summary>
        /// Get Vehicle Payment Details
        /// </summary>
        /// <param name="vehiclePayment"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> GetVehiclePaymentDetails(VehiclePayment vehiclePayment)
        {
            return await vehiclePaymentProvider.GetVehiclePaymentDetails(vehiclePayment);
        }

        /// <summary>
        /// Get Vehicle Payment Gateway
        /// </summary>
        /// <param name="vehiclePayment"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<PaymentModel> GetVehiclePaymentGateway(VehiclePayment vehiclePayment)
        {
            return await vehiclePaymentProvider.GetVehiclePaymentGateway(vehiclePayment);
        }

        /// <summary>
        /// Insert Vehicle Payment Request
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> InsertVehiclePaymentRequest(PaymentEF model)
        {
            return await vehiclePaymentProvider.InsertVehiclePaymentRequest(model);
        }
    }
}
