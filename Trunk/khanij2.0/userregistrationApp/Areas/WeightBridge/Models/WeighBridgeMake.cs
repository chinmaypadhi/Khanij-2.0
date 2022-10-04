using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationApp.Models.Utility;
using userregistrationEF;

namespace userregistrationApp.Areas.WeightBridge.Models
{
    public class WeighBridgeMake : IWeighbridgeMake
    {
        IHttpWebClients _objIHttpWebClients;
        public WeighBridgeMake(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        public List<ViewWeighBridgeMakeModel> View(ViewWeighBridgeMakeModel obj)
        {
            try
            {
                List<ViewWeighBridgeMakeModel> objlist = new List<ViewWeighBridgeMakeModel>();

                objlist = JsonConvert.DeserializeObject<List<ViewWeighBridgeMakeModel>>(_objIHttpWebClients.PostRequest("WeighBridgeMake/View", JsonConvert.SerializeObject(obj)));
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
