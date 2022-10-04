using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermitEF;
using Newtonsoft.Json;
using PermitApp.Models.Utility;

namespace PermitApp.Areas.Permit.Models.LTP
{
    public class LTPModel:ILTPModel
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
        public LTPModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Get the RPTP pass details
        /// </summary>
        /// <param name="objPermit"></param>
        /// <returns></returns>
        public List<LTPInfo> GetRTPPassList(LTPInfo objPermit)
        {
            /// <summary>
            /// Get the details of RTP pass Number
            /// </summary>
            /// <param name="objUser"></param>
            /// <returns></returns>
            try
            {
                List<LTPInfo> objRTPList = new List<LTPInfo>();
                objRTPList = JsonConvert.DeserializeObject<List<LTPInfo>>(_objIHttpWebClients.PostRequest("LTP/GetRTPPassList", JsonConvert.SerializeObject(objPermit)));
                return objRTPList;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Get the mineral LIst
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<LTPInfo> GetCascadeMineral(LTPInfo objPermit)
        {
            try
            {
                List<LTPInfo> objRTPList = new List<LTPInfo>();
                objRTPList = JsonConvert.DeserializeObject<List<LTPInfo>>(_objIHttpWebClients.PostRequest("LTP/GetCascadeMineral", JsonConvert.SerializeObject(objPermit)));
                return objRTPList;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Get the mineral Nature List
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<LTPInfo> GetMineralNatureList(LTPInfo objPermit)
        {
            try
            {
                List<LTPInfo> objRTPList = new List<LTPInfo>();
                objRTPList = JsonConvert.DeserializeObject<List<LTPInfo>>(_objIHttpWebClients.PostRequest("LTP/GetMineralNatureList", JsonConvert.SerializeObject(objPermit)));
                return objRTPList;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Get the mineral Grade list
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<LTPInfo> GetMineralGradList(LTPInfo objPermit)
        {
            try
            {
                List<LTPInfo> objRTPList = new List<LTPInfo>();
                objRTPList = JsonConvert.DeserializeObject<List<LTPInfo>>(_objIHttpWebClients.PostRequest("LTP/GetMineralGradList", JsonConvert.SerializeObject(objPermit)));
                return objRTPList;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Bind the dropdown of Railway siding Sourse
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<LTPInfo> GetRailwaySiding(LTPInfo objPermit)
        {
            try
            {
                List<LTPInfo> objRTPList = new List<LTPInfo>();
                objRTPList = JsonConvert.DeserializeObject<List<LTPInfo>>(_objIHttpWebClients.PostRequest("LTP/GetRailwaySiding", JsonConvert.SerializeObject(objPermit)));
                return objRTPList;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Bind the dropdown of Railway siding Destination
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<LTPInfo> GetRailwaySidingDestination(LTPInfo objPermit)
        {
            try
            {
                List<LTPInfo> objRTPList = new List<LTPInfo>();
                objRTPList = JsonConvert.DeserializeObject<List<LTPInfo>>(_objIHttpWebClients.PostRequest("LTP/GetRailwaySidingDestination", JsonConvert.SerializeObject(objPermit)));
                return objRTPList;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Get all RTP data
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<LTPInfo> GetuserDetailsUsingRTP(LTPInfo objPermit)
        {
            try
            {
                List<LTPInfo> objRTPList = new List<LTPInfo>();
                objRTPList = JsonConvert.DeserializeObject<List<LTPInfo>>(_objIHttpWebClients.PostRequest("LTP/GetuserDetailsUsingRTP", JsonConvert.SerializeObject(objPermit)));
                return objRTPList;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        ///  Get all RTP data based on LTP permit number
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<LTPInfo> getAddLTPDetails(LTPInfo objPermit)
        {
            try
            {
                List<LTPInfo> objRTPList = new List<LTPInfo>();
                objRTPList = JsonConvert.DeserializeObject<List<LTPInfo>>(_objIHttpWebClients.PostRequest("LTP/getAddLTPDetails", JsonConvert.SerializeObject(objPermit)));
                return objRTPList;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        ///  Get all RTP data based on user id
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<LTPInfo> getLTPDetails(LTPInfo objPermit)
        {
            try
            {
                List<LTPInfo> objRTPList = new List<LTPInfo>();
                objRTPList = JsonConvert.DeserializeObject<List<LTPInfo>>(_objIHttpWebClients.PostRequest("LTP/getLTPDetails", JsonConvert.SerializeObject(objPermit)));
                return objRTPList;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Save LTP application
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public MessageEF AddLTPApplication(LTPInfo objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LTP/AddLTPApplication", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        ///  Download LTP application
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<ListofLTP> DownloadLTP(ListofLTP objPermit)
        {
            try
            {
                List<ListofLTP> objRTPList = new List<ListofLTP>();
                objRTPList = JsonConvert.DeserializeObject<List<ListofLTP>>(_objIHttpWebClients.PostRequest("LTP/DownloadLTP", JsonConvert.SerializeObject(objPermit)));
                return objRTPList;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        ///  Get Pendig LTP List 
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<ListofLTP> GetPendigLTPList(ListofLTP objPermit)
        {
            try
            {
                List<ListofLTP> objRTPList = new List<ListofLTP>();
                objRTPList = JsonConvert.DeserializeObject<List<ListofLTP>>(_objIHttpWebClients.PostRequest("LTP/GetPendigLTPList", JsonConvert.SerializeObject(objPermit)));
                return objRTPList;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
