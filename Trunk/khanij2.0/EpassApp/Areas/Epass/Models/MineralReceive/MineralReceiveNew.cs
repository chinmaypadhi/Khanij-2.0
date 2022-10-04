using EpassApp.Models.Utility;
using EpassEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApp.Areas.Epass.Models.MineralReceive
{
    public class MineralReceiveNew : IMineralReceiveNew
    {
        IHttpWebClients _objIHttpWebClients;
        public MineralReceiveNew(IHttpWebClients objIHttpWebClients)
        {

            _objIHttpWebClients = objIHttpWebClients;
        }
        public List<EndUser_ETransitPassModel> MineralReceiveData(EndUser_ETransitPassModel objmodel)
        {
            List<EndUser_ETransitPassModel> ListofficeLevelEF = new List<EndUser_ETransitPassModel>();
            try
            {
                ListofficeLevelEF = JsonConvert.DeserializeObject<List<EndUser_ETransitPassModel>>(_objIHttpWebClients.PostRequest("MineralReceive/MineralReceiveData", JsonConvert.SerializeObject(objmodel)));
            }
            catch (Exception ex)
            {

                throw;
            }
            return ListofficeLevelEF;
        }
        public List<EndUser_ETransitPassModel> BindReceivePermit(EndUser_ETransitPassModel objOpenModel)
        {
            List<EndUser_ETransitPassModel> objvechicle = new List<EndUser_ETransitPassModel>();
            try
            {

                objvechicle = JsonConvert.DeserializeObject<List<EndUser_ETransitPassModel>>(_objIHttpWebClients.PostRequest("MineralReceive/BindReceivePermit", JsonConvert.SerializeObject(objOpenModel)));
                return objvechicle;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<EndUser_ETransitPassModel> GetGridData(EndUser_ETransitPassModel objmodel)
        {
            List<EndUser_ETransitPassModel> ListofficeLevelEF = new List<EndUser_ETransitPassModel>();
            try
            {
                ListofficeLevelEF = JsonConvert.DeserializeObject<List<EndUser_ETransitPassModel>>(_objIHttpWebClients.PostRequest("MineralReceive/GetGridData", JsonConvert.SerializeObject(objmodel)));
            }
            catch (Exception ex)
            {

                throw;
            }
            return ListofficeLevelEF;
        }
        public string UpdateMineralReceipt(EndUser_ETransitPassModel objmodel)
        {
            string _Result = string.Empty;
            try
            {
                _Result = JsonConvert.DeserializeObject<string>(_objIHttpWebClients.PostRequest("MineralReceive/UpdateMineralReceipt", JsonConvert.SerializeObject(objmodel)));
            }
            catch (Exception ex)
            {

                throw;
            }
            return _Result;
        }

        public List<EndUser_ETransitPassModel> GetClosedGridData(MineralReceiveModel objmodel)
        {
            List<EndUser_ETransitPassModel> ListofficeLevelEF = new List<EndUser_ETransitPassModel>();
            try
            {
                ListofficeLevelEF = JsonConvert.DeserializeObject<List<EndUser_ETransitPassModel>>(_objIHttpWebClients.PostRequest("MineralReceive/EndUserMineralReceiptReports", JsonConvert.SerializeObject(objmodel)));
            }
            catch (Exception ex)
            {

                throw;
            }
            return ListofficeLevelEF;
        }


    }

}
