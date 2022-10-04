using IntegrationApp.Models.Utility;
using IntegrationEF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;  

namespace IntegrationApp.Models.MailService
{
    public class MailModel : IMailModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        private readonly IHostingEnvironment _hostingEnvironment;
        static string LogoPath = "~/Content/images/colors/magenta/header.jpg";
        static string infiLogoPath = "~/images/infi.png";
        private IConfiguration configuration;
        public MailModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients, IHostingEnvironment hostingEnvironment, IConfiguration _configuration)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
            this._hostingEnvironment = hostingEnvironment;
            this.configuration = _configuration;
        }

        #region Send Mail
        /// <summary>
        /// Send Mail
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public MessageEF SendMail(TransporterMail obj)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MailService/SendMail", JsonConvert.SerializeObject(obj)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Send Mail EUP
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public MessageEF SendMail_EUP(TransporterMail obj)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MailService/SendMail_EUP", JsonConvert.SerializeObject(obj)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Send License Application Ack
        /// </summary>
        /// <param name="licenseMail"></param>
        /// <returns></returns>
        public MessageEF SendLicenseApplicationAck(LicenseMail licenseMail)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MailService/SendLicenseApplicationAck", JsonConvert.SerializeObject(licenseMail)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Vehicle Acknowledgement
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public MessageEF SendMail_AddVehiclesAck(TransporterMail obj)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MailService/SendMail_AddVehiclesAck", JsonConvert.SerializeObject(obj)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Send Payment Awaited Mail
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public MessageEF SendPaymentAwaitedMail(TransporterMail obj)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MailService/SendPaymentAwaitedMail", JsonConvert.SerializeObject(obj)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Send Non Permit Payment Mail
        /// </summary>
        /// <param name="licensePaymentMail"></param>
        /// <returns></returns>
        public MessageEF SendNonPermitPaymentMail(LicensePaymentMail licensePaymentMail)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MailService/SendPaymentAwaitedMail", JsonConvert.SerializeObject(licensePaymentMail)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Send License Approved Ack
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public MessageEF SendLicenseApprovedAck(LicenseMail obj)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MailService/SendLicenseApprovedAck", JsonConvert.SerializeObject(obj)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MessageEF SendPermitPaymentAck(PaymentEF obj)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MailService/SendPermitPaymentAck", JsonConvert.SerializeObject(obj)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}
