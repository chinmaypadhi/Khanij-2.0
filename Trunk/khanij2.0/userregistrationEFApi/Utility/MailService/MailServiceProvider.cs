using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;

namespace userregistrationEFApi.Utility.MailService
{
    public class MailServiceProvider: IMailServiceProvider
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public MailServiceProvider(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }

        /// <summary>
        /// Add Vehicle Acknowledgement
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
        /// Send Mail to Vehicle Owner for Vehicle Breakdown
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public MessageEF SendMail_VehicleBreakdownTransporter(BreakdownRequestDetailsByMobileApp obj)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MailService/SendMail_VehicleBreakdownTransporter", JsonConvert.SerializeObject(obj)));
                return messageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
    }
}
