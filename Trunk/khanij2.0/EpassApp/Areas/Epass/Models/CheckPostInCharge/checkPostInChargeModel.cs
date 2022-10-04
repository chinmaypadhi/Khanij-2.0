using EpassApp.Models.Utility;
using EpassEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApp.Areas.Epass.Models.CheckPostInCharge
{
    public class checkPostInChargeModel: IcheckPostInChargeModel
    {
        IHttpWebClients _objIHttpWebClients;
        public checkPostInChargeModel(IHttpWebClients httpWebClients)
        {
            _objIHttpWebClients = httpWebClients;
        }

        public List<CheckPostIrrgModel> ExcessMineralForCheckPost(CheckPostIrrgModel checkPostIrrgModel)
        {
            try
            {
                List<CheckPostIrrgModel> objlistModule = new List<CheckPostIrrgModel>();
                objlistModule = JsonConvert.DeserializeObject<List<CheckPostIrrgModel>>(_objIHttpWebClients.PostRequest("CheckPostInCherge/ExcessMineralForCheckPost", JsonConvert.SerializeObject(checkPostIrrgModel)));
                return objlistModule;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<CheckPostIrrgModel> GetTPInfromation(CheckPostIrrgModel checkPostIrrgModel)
        {
            try
            {
                List<CheckPostIrrgModel> objlistModule = new List<CheckPostIrrgModel>();
                objlistModule = JsonConvert.DeserializeObject<List<CheckPostIrrgModel>>(_objIHttpWebClients.PostRequest("CheckPostInCherge/TransitPassDetails", JsonConvert.SerializeObject(checkPostIrrgModel)));
                return objlistModule;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
