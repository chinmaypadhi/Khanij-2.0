using EpassApp.Models.Utility;
using EpassEF;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EpassApp.Areas.Epass.Models.eTransitpass
{
    public class Transitpass:IeTransitpass
    {
        IHttpWebClients _objIHttpWebClients;
        public Transitpass( IHttpWebClients objIHttpWebClients)
        {
           
            _objIHttpWebClients = objIHttpWebClients;
        }

        public List<TransitPassModel> GetApprovedBulkPermitList(TransitPassModel objOpenModel)
        {
            try
            {
                List<TransitPassModel> objListOpenPermit = new List<TransitPassModel>();
                objListOpenPermit = JsonConvert.DeserializeObject<List<TransitPassModel>>(_objIHttpWebClients.PostRequest("eTransitpass/GetApprovedBulkPermitList", JsonConvert.SerializeObject(objOpenModel)));
                return objListOpenPermit;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public TransitPassModel getTransitpassdtls(TransitPassModel objOpenModel)
        {
            try
            {
               
                objOpenModel = JsonConvert.DeserializeObject<TransitPassModel>(_objIHttpWebClients.PostRequest("eTransitpass/getTransitpassdtls", JsonConvert.SerializeObject(objOpenModel)));
                return objOpenModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public TransitPassModel getBulkPermitDataByBulkPermitId(TransitPassModel objOpenModel)
        {
            try
            {

                objOpenModel = JsonConvert.DeserializeObject<TransitPassModel>(_objIHttpWebClients.PostRequest("eTransitpass/getBulkPermitDataByBulkPermitId", JsonConvert.SerializeObject(objOpenModel)));
                return objOpenModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<TransitPassModel> GetCascadePurchaserConsignee(TransitPassModel objOpenModel)
        {
            try
            {
                List<TransitPassModel> objListOpenPermit = new List<TransitPassModel>();
                objListOpenPermit = JsonConvert.DeserializeObject<List<TransitPassModel>>(_objIHttpWebClients.PostRequest("eTransitpass/GetCascadePurchaserConsignee", JsonConvert.SerializeObject(objOpenModel)));
                return objListOpenPermit;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public TransitPassModel GetDataByPurchaserConsigneeId(TransitPassModel objOpenModel)
        {
            try
            {

                objOpenModel = JsonConvert.DeserializeObject<TransitPassModel>(_objIHttpWebClients.PostRequest("eTransitpass/GetDataByPurchaserConsigneeId", JsonConvert.SerializeObject(objOpenModel)));
                return objOpenModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<TPVehicleModel> GetAllVehicleInformation(TransitPassModel objOpenModel)
        {
            List<TPVehicleModel> objvechicle = new List<TPVehicleModel>();
            try
            {
               
                objvechicle = JsonConvert.DeserializeObject<List<TPVehicleModel>>(_objIHttpWebClients.PostRequest("eTransitpass/GetAllVehicleInformation", JsonConvert.SerializeObject(objOpenModel)));
                return objvechicle;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public ReturnOuputResult AddTransitPassDetails(TransitPassModel objOpenModel)
        {
            ReturnOuputResult objout = new ReturnOuputResult();
            try
            {

                objout = JsonConvert.DeserializeObject<ReturnOuputResult>(_objIHttpWebClients.PostRequest("eTransitpass/AddTransitPassDetails", JsonConvert.SerializeObject(objOpenModel)));
                return objout;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Added by Suroj on 15-jul-2021 to generate print eTransit Pass
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>
        public TransitPassModel PassReportDesignView(TransitPassModel objOpenModel)
        {
           
            try
            {

                objOpenModel = JsonConvert.DeserializeObject<TransitPassModel>(_objIHttpWebClients.PostRequest("eTransitpass/PassReportDesignView", JsonConvert.SerializeObject(objOpenModel)));
                return objOpenModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public List<TransitPassModel> GetForwardingNote(TransitPassModel objOpenModel)
        {
            List<TransitPassModel> objvechicle = new List<TransitPassModel>();
            try
            {

                objvechicle = JsonConvert.DeserializeObject<List<TransitPassModel>>(_objIHttpWebClients.PostRequest("eTransitpass/GetForwardingNote", JsonConvert.SerializeObject(objOpenModel)));
                return objvechicle;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Added by Suroj on 15-jul-2021 to generate print Railway eTransit Pass
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>
        public TransitPassModel RailTPDataFetch(TransitPassModel objOpenModel)
        {

            try
            {

                objOpenModel = JsonConvert.DeserializeObject<TransitPassModel>(_objIHttpWebClients.PostRequest("eTransitpass/RailTPDataFetch", JsonConvert.SerializeObject(objOpenModel)));
                return objOpenModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<EndUser_ETransitPassModel> BindReceivePermit(EndUser_ETransitPassModel objOpenModel)
        {
            List<EndUser_ETransitPassModel> objvechicle = new List<EndUser_ETransitPassModel>();
            try
            {

                objvechicle = JsonConvert.DeserializeObject<List<EndUser_ETransitPassModel>>(_objIHttpWebClients.PostRequest("eTransitpass/BindReceivePermit", JsonConvert.SerializeObject(objOpenModel)));
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
                ListofficeLevelEF = JsonConvert.DeserializeObject<List<EndUser_ETransitPassModel>>(_objIHttpWebClients.PostRequest("eTransitpass/GetGridData", JsonConvert.SerializeObject(objmodel)));
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
                _Result = JsonConvert.DeserializeObject<string>(_objIHttpWebClients.PostRequest("eTransitpass/UpdateMineralReceipt", JsonConvert.SerializeObject(objmodel)));
            }
            catch (Exception ex)
            {

                throw;
            }
            return _Result;
        }
        public List<EndUser_ETransitPassModel> MineralReceiveData(EndUser_ETransitPassModel objmodel)
        {
            List<EndUser_ETransitPassModel> ListofficeLevelEF = new List<EndUser_ETransitPassModel>();
            try
            {
                ListofficeLevelEF = JsonConvert.DeserializeObject<List<EndUser_ETransitPassModel>>(_objIHttpWebClients.PostRequest("eTransitpass/MineralReceiveData", JsonConvert.SerializeObject(objmodel)));
            }
            catch (Exception ex)
            {

                throw;
            }
            return ListofficeLevelEF;
        }
        /// <summary>
        /// Added by suroj kumar pradhan on 23-aug-2021 to bind Permit No in RPTP
        /// </summary>
        /// <returns></returns>
        public List<RPTPModel> GetApprovedBulkPermitListRPTP(RPTPModel objmodel)
        {
            List<RPTPModel> ListofficeLevelEF = new List<RPTPModel>();
            try
            {
                ListofficeLevelEF = JsonConvert.DeserializeObject<List<RPTPModel>>(_objIHttpWebClients.PostRequest("eTransitpass/GetApprovedBulkPermitListRPTP", JsonConvert.SerializeObject(objmodel)));
            }
            catch (Exception ex)
            {

                throw;
            }
            return ListofficeLevelEF;
        }

        /// <summary>
        /// Added by suroj on 24-Aug-2021 to fetch details against permitNO RPTP
        /// </summary>
        /// <param name="objRPTP"></param>
        /// <returns></returns>
        
        public RPTPModel GetDataByBulkPermitId(RPTPModel objmodel)
        {
            
            try
            {
                objmodel = JsonConvert.DeserializeObject<RPTPModel>(_objIHttpWebClients.PostRequest("eTransitpass/GetDataByBulkPermitId", JsonConvert.SerializeObject(objmodel)));
            }
            catch (Exception ex)
            {

                throw;
            }
            return objmodel;
        }


        /// <summary>
        /// Added by suroj on 08-jul-2021 to bind Purchase/Consignee in eTransit Pass RPTP
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>
       

        public List<RPTPModel> GetCascadePurchaserConsigneeRPTP(RPTPModel objmodel)
        {
            List<RPTPModel> ListofficeLevelEF = new List<RPTPModel>();
            try
            {
                ListofficeLevelEF = JsonConvert.DeserializeObject<List<RPTPModel>>(_objIHttpWebClients.PostRequest("eTransitpass/GetCascadePurchaserConsigneeRPTP", JsonConvert.SerializeObject(objmodel)));
            }
            catch (Exception ex)
            {

                throw;
            }
            return ListofficeLevelEF;
        }
        /// <summary>
        /// Added by suroj on 08-jul-2021 to Get destination Against Purchase consignee ID RPTP
        /// </summary>
        /// <param name="objTP"></param>
        /// <returns></returns>
        public RPTPModel GetDataByPurchaserConsigneeIdRPTP(RPTPModel objmodel)
        {

            try
            {
                objmodel = JsonConvert.DeserializeObject<RPTPModel>(_objIHttpWebClients.PostRequest("eTransitpass/GetDataByPurchaserConsigneeIdRPTP", JsonConvert.SerializeObject(objmodel)));
            }
            catch (Exception ex)
            {

                throw;
            }
            return objmodel;
        }
        /// <summary>
        /// Added by suroj on 25-aug-2021 to add RPTP details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnOuputResultRPTP AddData(RPTPModel objmodel)
        {
            ReturnOuputResultRPTP _Result = new ReturnOuputResultRPTP();
            try
            {
                _Result = JsonConvert.DeserializeObject<ReturnOuputResultRPTP>(_objIHttpWebClients.PostRequest("eTransitpass/AddData", JsonConvert.SerializeObject(objmodel)));
            }
            catch (Exception ex)
            {

                throw;
            }
            return _Result;
        }

        /// <summary>
        /// Added by suroj on 26-08-21 to print RPTP
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public RPTPModel getRecordForReport(RPTPModel objmodel)
        {

            try
            {
                objmodel = JsonConvert.DeserializeObject<RPTPModel>(_objIHttpWebClients.PostRequest("eTransitpass/getRecordForReport", JsonConvert.SerializeObject(objmodel)));
            }
            catch (Exception ex)
            {

                throw;
            }
            return objmodel;
        }
        /// <summary>
        ///  Added by Shyam Sir on 5-1-21 to print  AddUserWiseTPConfiguration
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //public ReturnOuputResult AddUserWiseTPConfiguration(UserWiseTPConfigurationViewModel model)
        //{
        //    ReturnOuputResult objout = new ReturnOuputResult();
        //    try
        //    {
        //        objout = JsonConvert.DeserializeObject<ReturnOuputResult>(_objIHttpWebClients.PostRequest("eTransitpass/AddUserWiseTPConfiguration", JsonConvert.SerializeObject(model)));
               
        //    }
        //    catch (Exception)
        //    {

        //        throw ;
        //    }
        //    return objout;
        //}
        ///// <summary>
        ///// view leave rule master
        ///// </summary>
        ///// <param name="objLeaveRuleMaster"></param>
        ///// <returns></returns>
        //public  List<UserWiseTPConfigurationModel> ListUserWiseTPConfiguration(UserWiseTPConfigurationModel objUserWiseTPConfiguration)
        //{
        //    try
        //    {
        //        List<UserWiseTPConfigurationModel> objlistUserWiseTPConfiguration = new List<UserWiseTPConfigurationModel>();

        //       objlistUserWiseTPConfiguration = JsonConvert.DeserializeObject<List<UserWiseTPConfigurationModel>>(_objIHttpWebClients.PostRequest("eTransitpass/ListUserWiseTPConfiguration", JsonConvert.SerializeObject(objUserWiseTPConfiguration)));

        //        return objlistUserWiseTPConfiguration;

        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}
    }
}
