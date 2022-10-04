using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermitEF;
using Newtonsoft.Json;
using PermitApp.Models.Utility;

namespace PermitApp.Areas.Permit.Models.MergePermit
{
    public class MergePermitModel:IMergePermitModel
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
        public MergePermitModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        public List<ePermitModel> GetMergePermitList(ePermitModel objPermit)
        {
            try
            {
                List<ePermitModel> objlistNotice = new List<ePermitModel>();
                objlistNotice = JsonConvert.DeserializeObject<List<ePermitModel>>(_objIHttpWebClients.PostRequest("MergePermit/GetMergePermitList", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult GetMergePermitMineralGrade(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("MergePermit/GetMergePermitMineralGrade", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF ClosePermit(ePermitModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MergePermit/ClosePermit", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF SaveAndGenerateEpermit(ePermitModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MergePermit/SaveAndGenerateEpermit", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult GetMineralName(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("MergePermit/GetMineralName", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// check for merge permit data
        /// </summary>
        /// <param name="objPermit"></param>
        /// <returns></returns>
        public ePermitResult CheckMergePermitDetails(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("MergePermit/CheckMergePermitDetails", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Get the details of Mergepermit
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public ePermitResult GetMergePermitTransDetails(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("MergePermit/GetMergePermitTransDetails", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
