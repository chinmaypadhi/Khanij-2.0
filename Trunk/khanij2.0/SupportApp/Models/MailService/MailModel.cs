using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupportApp.Models.Utility;
using SupportEF;

namespace SupportApp.Models.MailService
{
    public class MailModel: IMailModel
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
        public MessageEF SendMail(GrievanceMail obj)
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
        public MessageEF SendMail_EUP(GrievanceMail obj)
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
        #endregion
    }
}
