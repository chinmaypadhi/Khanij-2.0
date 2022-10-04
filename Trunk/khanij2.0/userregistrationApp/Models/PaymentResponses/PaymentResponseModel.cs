using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationApp.Models.Utility;
using userregistrationEF;

namespace userregistrationApp.Models.PaymentResponses
{
    public class PaymentResponseModel : IPaymentResponseModel
    {
        IHttpWebClients _objIHttpWebClients;
        public PaymentResponseModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }

        /// <summary>
        /// Add Payment Response
        /// </summary>
        /// <param name="paymentTransaction"></param>
        /// <returns></returns>
        public MessageEF AddPaymentResponse(PaymentTransaction paymentTransaction)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("PaymentResponses/AddPaymentResponse", JsonConvert.SerializeObject(paymentTransaction)));
                return messageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get Payment Response ID
        /// </summary>
        /// <param name="paymentResponseDetails"></param>
        /// <returns></returns>
        public MessageEF GetPaymentResponseID(PaymentResponseDetails paymentResponseDetails)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("PaymentResponses/GetPaymentResponseID", JsonConvert.SerializeObject(paymentResponseDetails)));
                return messageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Add Vehicle Payment Response
        /// </summary>
        /// <param name="paymentResponseDetails"></param>
        /// <returns></returns>
        public TransporterModel AddVehiclePaymentResponse(PaymentResponseDetails paymentResponseDetails)
        {
            TransporterModel transporterModel = new TransporterModel();
            try
            {
                transporterModel = JsonConvert.DeserializeObject<TransporterModel>(_objIHttpWebClients.PostRequest("PaymentResponses/AddVehiclePaymentResponse", JsonConvert.SerializeObject(paymentResponseDetails)));
                return transporterModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Add License First Payment
        /// </summary>
        /// <param name="paymentResponseDetails"></param>
        /// <returns></returns>
        public UserMasterModel AddLicenseFirstPayment(PaymentResponseDetails paymentResponseDetails)
        {
            UserMasterModel userMasterModel = new UserMasterModel();
            try
            {
                userMasterModel = JsonConvert.DeserializeObject<UserMasterModel>(_objIHttpWebClients.PostRequest("PaymentResponses/AddLicenseFirstPayment", JsonConvert.SerializeObject(paymentResponseDetails)));
                return userMasterModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Add License Security Payment
        /// </summary>
        /// <param name="paymentResponseDetails"></param>
        /// <returns></returns>
        public UserMasterModel AddLicenseSecurityPayment(PaymentResponseDetails paymentResponseDetails)
        {
            UserMasterModel userMasterModel = new UserMasterModel();
            try
            {
                userMasterModel = JsonConvert.DeserializeObject<UserMasterModel>(_objIHttpWebClients.PostRequest("PaymentResponses/AddLicenseSecurityPayment", JsonConvert.SerializeObject(paymentResponseDetails)));
                return userMasterModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
