using IntegrationApp.Models.Utility;
using IntegrationEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationApp.Areas.Payment.Models.LicensePaymentDetails
{
    public class LicensePaymentModel : ILicensePaymentModel
    {
        IHttpWebClients _objIHttpWebClients;
        public LicensePaymentModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }

        /// <summary>
        /// License Payment Details
        /// </summary>
        /// <param name="licensePaymentDetail"></param>
        /// <returns></returns>
        public MessageEF GetLicensePaymentDetails(LicensePaymentDetail licensePaymentDetail)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LicensePayment/GetLicensePaymentDetails", JsonConvert.SerializeObject(licensePaymentDetail)));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get License Payment Gateway
        /// </summary>
        /// <param name="licensePaymentDetail"></param>
        /// <returns></returns>
        public PaymentModel GetLicensePaymentGateway(LicensePaymentDetail licensePaymentDetail)
        {
            try
            {
                return JsonConvert.DeserializeObject<PaymentModel>(_objIHttpWebClients.PostRequest("LicensePayment/GetLicensePaymentGateway", JsonConvert.SerializeObject(licensePaymentDetail)));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Insert License Payment Request
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public MessageEF InsertLicensePaymentRequest(PaymentModel model)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LicensePayment/InsertLicensePaymentRequest", JsonConvert.SerializeObject(model)));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Add Security Deposit
        /// </summary>
        /// <param name="licenseApplication"></param>
        /// <returns></returns>
        public MessageEF AddSecurityDeposit(LicenseApplication licenseApplication)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LicensePayment/AddSecurityDeposit", JsonConvert.SerializeObject(licenseApplication)));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF AddLeaseDeedFine(LicenseApplication licenseApplication)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LicensePayment/AddLeaseDeedFine", JsonConvert.SerializeObject(licenseApplication)));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
