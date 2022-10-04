using IntegrationApp.Models.Utility;
using IntegrationEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationApp.Areas.Payment.Models.VehiclePaymentDetails
{
    public class VehiclePaymentModel : IVehiclePaymentModel
    {
        IHttpWebClients _objIHttpWebClients;
        public VehiclePaymentModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }

        /// <summary>
        /// Get Vehicle Payment Details
        /// </summary>
        /// <param name="vehiclePayment"></param>
        /// <returns></returns>
        public MessageEF GetVehiclePaymentDetails(VehiclePayment vehiclePayment)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("VehiclePayment/GetVehiclePaymentDetails", JsonConvert.SerializeObject(vehiclePayment)));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get Vehicle Payment Gateway
        /// </summary>
        /// <param name="vehiclePayment"></param>
        /// <returns></returns>
        public PaymentModel GetVehiclePaymentGateway(VehiclePayment vehiclePayment)
        {
            PaymentModel paymentModel = new PaymentModel();
            try
            {
                return JsonConvert.DeserializeObject<PaymentModel>(_objIHttpWebClients.PostRequest("VehiclePayment/GetVehiclePaymentGateway", JsonConvert.SerializeObject(vehiclePayment)));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Insert Vehicle Payment Mode
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageEF InsertVehiclePaymentRequest(PaymentEF model)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("VehiclePayment/InsertVehiclePaymentRequest", JsonConvert.SerializeObject(model)));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
