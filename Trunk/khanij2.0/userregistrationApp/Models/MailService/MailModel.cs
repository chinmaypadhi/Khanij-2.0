using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationApp.Models.Utility;
using userregistrationEF;

namespace userregistrationApp.Models.MailService
{
    public class MailModel : IMailModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public MailModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
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

        /// <summary>
        /// Send TailingDam Mail
        /// </summary>
        /// <param name="userMasterModel"></param>
        /// <returns></returns>
        public MessageEF SendTailingDamMail(UserMasterModel userMasterModel)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MailService/SendTailingDamMail", JsonConvert.SerializeObject(userMasterModel)));
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
