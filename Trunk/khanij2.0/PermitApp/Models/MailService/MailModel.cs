using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermitApp.Models.Utility;
using PermitEF;

namespace PermitApp.Models.MailService
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


        #endregion
    }
}
