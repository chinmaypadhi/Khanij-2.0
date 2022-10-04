using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationApp.Models.Utility;
using userregistrationEF;

namespace userregistrationApp.Areas.WeightBridge.Models
{
    public class AreaType : IAreaType
    {
        IHttpWebClients _objIHttpWebClients;
        public AreaType(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        public List<AreaDetails> GetLandTypeList(AreaDetails viewAreaDetails)
        {
            try
            {
                List<AreaDetails> objarealist = new List<AreaDetails>();
                objarealist = JsonConvert.DeserializeObject<List<AreaDetails>>(_objIHttpWebClients.PostRequest("WeighBridgeRegistration/GetLandTypeList", JsonConvert.SerializeObject(viewAreaDetails)));
                return objarealist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
