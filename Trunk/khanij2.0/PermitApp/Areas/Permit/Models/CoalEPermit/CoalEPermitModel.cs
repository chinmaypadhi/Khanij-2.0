using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermitEF;
using Newtonsoft.Json;
using PermitApp.Models.Utility;
namespace PermitApp.Areas.Permit.Models.CoalEPermit
{
    public class CoalEPermitModel : ICoalEPermitModel
    {
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// View Profile Requests of IBM Details to Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objKeyList"></param>
        /// <param name="objIHttpWebClients"></param>
        public CoalEPermitModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        public ePermitResult GetTypeOfCoal(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("CoalEPermit/GetTypeOfCoal", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult GetCoalMineralNatureList(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("Permit/GetCoalMineralNatureList", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult CheckTotalPermitByUser(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("CoalEPermit/CheckTotalPermitByUser", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult GetPermitDetailsByUserID(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("CoalEPermit/GetPermitDetailsByUserID", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult GetPermitOperation(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("CoalEPermit/GetPermitOperation", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult GetPermitOperationByBulkId(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("CoalEPermit/GetPermitOperationByBulkId", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult GetMineralGradeListOnNatureList(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("Permit/GetMineralGradeListOnNatureList", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF AddBulkPermit(ePermitModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Permit/AddBulkPermit", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ePermitResult GetePermitPayment(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("CoalEPermit/GetePermitPayment", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ListCoalPermit> GetSavedCoalPermit(ePermitModel objPermit)
        {
            try
            {
                List<ListCoalPermit> objlistNotice = new List<ListCoalPermit>();
                objlistNotice = JsonConvert.DeserializeObject<List<ListCoalPermit>>(_objIHttpWebClients.PostRequest("CoalEPermit/GetSavedCoalPermit", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF DeleteCoalData(ePermitModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("CoalEPermit/DeleteCoalData", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ePermitResult GetPermitViewWithoutDSC(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("CoalEPermit/GetPermitViewWithoutDSC", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF CheckOutPayment(ePermitModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("CoalEPermit/CheckOutPayment", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ePermitResult GetCheckOutPermitPayment(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("CoalEPermit/GetCheckOutPermitPayment", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<ePaymentData> GetDetailsOfConfig(ePermitModel objUser)
        {
            try
            {
                List<ePaymentData> objlistNotice = new List<ePaymentData>();
                objlistNotice = JsonConvert.DeserializeObject<List<ePaymentData>>(_objIHttpWebClients.PostRequest("CoalEPermit/GetDetailsOfConfig", JsonConvert.SerializeObject(objUser)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MessageEF UpgradeMineral(ePermitModel objUser)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("CoalEPermit/UpgradeMineral", JsonConvert.SerializeObject(objUser)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ePermitModel GetDetailsOfUpgrade(ePermitModel objUser)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitModel>(_objIHttpWebClients.PostRequest("CoalEPermit/GetDetailsOfUpgrade", JsonConvert.SerializeObject(objUser)));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ePermitResult GetMinesDetails(ePermitModel objUser)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("CoalEPermit/GetMinesDetails", JsonConvert.SerializeObject(objUser)));

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public ePermitModel GetComapny(ePermitModel objUser)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitModel>(_objIHttpWebClients.PostRequest("CoalEPermit/GetComapny", JsonConvert.SerializeObject(objUser)));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ePermitModel GetCoalRoyalty(ePermitModel objUser)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitModel>(_objIHttpWebClients.PostRequest("CoalEPermit/GetCoalRoyalty", JsonConvert.SerializeObject(objUser)));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<ePaymentData> GetPaymentStatus(ePermitModel objUser)
        {
            try
            {
                List<ePaymentData> objlistNotice = new List<ePaymentData>();
                objlistNotice = JsonConvert.DeserializeObject<List<ePaymentData>>(_objIHttpWebClients.PostRequest("CoalEPermit/GetPaymentStatus", JsonConvert.SerializeObject(objUser)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}
