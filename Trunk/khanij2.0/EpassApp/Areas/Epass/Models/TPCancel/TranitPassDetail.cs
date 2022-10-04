using EpassApp.Models.Utility;
using EpassEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApp.Areas.Epass.Models.TPCancel
{
    public class TranitPassDetail: ITranitPassDetail
    {
        IHttpWebClients _objIHttpWebClients;
        public TranitPassDetail(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
      
        ////Dinesh 25Apr2022 
        public List<TransitpassCancelEF> GeteTransitpassDetails(TransitpassCancelEF objTPcancel)
        {
            try
            {
                List<TransitpassCancelEF> objlistNotice = new List<TransitpassCancelEF>();
                objlistNotice = JsonConvert.DeserializeObject<List<TransitpassCancelEF>>(_objIHttpWebClients.PostRequest("Lessee/GeteTransitpassDetails", JsonConvert.SerializeObject(objTPcancel)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
       
        ////Dinesh 25Apr2022 
        public MessageEF TPCancel(TransitpassCancelEF objcancel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Lessee/TPcancel", JsonConvert.SerializeObject(objcancel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
