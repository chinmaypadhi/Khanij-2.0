using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationApp.Models.Utility;
using userregistrationEF;

namespace userregistrationApp.Areas.WeightBridge.Models
{
    public class WeighBridgeModelType : IWeighBridgeModelType
    {
        IHttpWebClients _objIHttpWebClients;
        public WeighBridgeModelType(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        public List<ViewWeighBridgeModelTypeModel> ViewByMake(ViewWeighBridgeModelTypeModel obj)
        {
            try
            {
                List<ViewWeighBridgeModelTypeModel> objlist = new List<ViewWeighBridgeModelTypeModel>();
                objlist = JsonConvert.DeserializeObject<List<ViewWeighBridgeModelTypeModel>>(_objIHttpWebClients.PostRequest("WeighBridgeModelType/ViewByMake", JsonConvert.SerializeObject(obj)));
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
