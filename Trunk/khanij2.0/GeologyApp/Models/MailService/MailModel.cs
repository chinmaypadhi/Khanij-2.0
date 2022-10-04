using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeologyApp.Models.Utility;
using GeologyEF;

namespace GeologyApp.Models.MailService
{
    public class MailModel: IMailModel
    {
        /// <summary>
        /// Global object and variable declaration
        /// </summary>
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public MailModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region Send Mail
        /// <summary>
        /// Send Mail of Monthly Progress Report
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public MessageEF SendMail_MPR(GeologyMail obj)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MailService/SendMail_MPR", JsonConvert.SerializeObject(obj)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Send Mail of Field Status Report
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public MessageEF SendMail_FSR(GeologyMail obj)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MailService/SendMail_FSR", JsonConvert.SerializeObject(obj)));
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
