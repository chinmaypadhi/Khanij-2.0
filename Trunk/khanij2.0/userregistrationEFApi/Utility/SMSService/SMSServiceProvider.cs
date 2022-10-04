using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;

namespace userregistrationEFApi.Utility.SMSService
{
    public class SMSServiceProvider: ISMSServiceProvider
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public SMSServiceProvider(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }

        public MessageEF Main(SMS sMS)
        {

            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("SMSService/Main", JsonConvert.SerializeObject(sMS)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
