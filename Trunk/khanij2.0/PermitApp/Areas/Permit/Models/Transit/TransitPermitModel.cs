using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermitEF;
using Newtonsoft.Json;
using PermitApp.Models.Utility;

namespace PermitApp.Areas.Permit.Models.Transit
{
    public class TransitPermitModel:ITransitPermitModel
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
        public TransitPermitModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        public eTransitResult GetBulkPermitForwarding(ForwardingNoteModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<eTransitResult>(_objIHttpWebClients.PostRequest("Transit/GetBulkPermitForwarding", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public eTransitResult GetConsigerListForwardingNote(ForwardingNoteModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<eTransitResult>(_objIHttpWebClients.PostRequest("Transit/GetConsigerListForwardingNote", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public eTransitResult GetRailwaySiding(ForwardingNoteModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<eTransitResult>(_objIHttpWebClients.PostRequest("Transit/GetRailwaySiding", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public eTransitResult GetRailwaySidingDestination(ForwardingNoteModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<eTransitResult>(_objIHttpWebClients.PostRequest("Transit/GetRailwaySidingDestination", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ForwardingNoteModel> GetForwardingNoteView(ForwardingNoteModel objPermit)
        {
            try
            {
                List<ForwardingNoteModel> objlistNotice = new List<ForwardingNoteModel>();
                objlistNotice = JsonConvert.DeserializeObject<List<ForwardingNoteModel>>(_objIHttpWebClients.PostRequest("Transit/GetForwardingNoteView", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ForwardingNoteModel> GetGrantOrderExpiry(ForwardingNoteModel objPermit)
        {
            try
            {
                List<ForwardingNoteModel> objlistNotice = new List<ForwardingNoteModel>();
                objlistNotice = JsonConvert.DeserializeObject<List<ForwardingNoteModel>>(_objIHttpWebClients.PostRequest("Transit/GetGrantOrderExpiry", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public eTransitResult getFNPreviewData(ForwardingNoteModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<eTransitResult>(_objIHttpWebClients.PostRequest("Transit/getFNPreviewData", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF AddRTPApplication(ForwardingNoteModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Transit/AddRTPApplication", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ForwardingNoteModel> GetForwadingTransactionNo(ForwardingNoteModel objPermit)
        {
            try
            {
                List<ForwardingNoteModel> objlistNotice = new List<ForwardingNoteModel>();
                objlistNotice = JsonConvert.DeserializeObject<List<ForwardingNoteModel>>(_objIHttpWebClients.PostRequest("Transit/GetForwadingTransactionNo", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ForwardingNoteModel> GetAvailableData(ForwardingNoteModel objPermit)
        {
            try
            {
                List<ForwardingNoteModel> objlistNotice = new List<ForwardingNoteModel>();
                objlistNotice = JsonConvert.DeserializeObject<List<ForwardingNoteModel>>(_objIHttpWebClients.PostRequest("Transit/GetAvailableData", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ForwardingNoteModel> GetDGDMOFN(ForwardingNoteModel objPermit)
        {
            try
            {
                List<ForwardingNoteModel> objlistNotice = new List<ForwardingNoteModel>();
                objlistNotice = JsonConvert.DeserializeObject<List<ForwardingNoteModel>>(_objIHttpWebClients.PostRequest("Transit/GetDGDMOFN", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Get the data and bind for generate RTP pass
        /// </summary>
        /// <param name="ForwardingNoteId"></param>
        /// <returns></returns>
        public List<ForwardingNoteModel> GenerateRTPPass(ForwardingNoteModel objPermit)
        {
            try
            {
                List<ForwardingNoteModel> objlistNotice = new List<ForwardingNoteModel>();
                objlistNotice = JsonConvert.DeserializeObject<List<ForwardingNoteModel>>(_objIHttpWebClients.PostRequest("Transit/GenerateRTPPass", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Get the details of permit that to be close
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<ForwardingNoteModel> GetCloseRTPPassDetailsList(ForwardingNoteModel objPermit)
        {
            try
            {
                List<ForwardingNoteModel> objlistNotice = new List<ForwardingNoteModel>();
                objlistNotice = JsonConvert.DeserializeObject<List<ForwardingNoteModel>>(_objIHttpWebClients.PostRequest("Transit/GetCloseRTPPassDetailsList", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To close RTP pass
        /// </summary>
        /// <param name="objPermit"></param>
        /// <returns></returns>
        public MessageEF CloseRTPTripFor(ForwardingNoteModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Transit/CloseRTPTripFor", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To generate RTP pass
        /// </summary>
        /// <param name="objPermit"></param>
        /// <returns></returns>
        public MessageEF UpdateRTPPass(ForwardingNoteModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Transit/UpdateRTPPass", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Generate RTP pass and continue
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public List<ForwardingNoteModel> PrintAndCloseTP(ForwardingNoteModel objPermit)
        {
            try
            {
                List<ForwardingNoteModel> objlistNotice = new List<ForwardingNoteModel>();
                objlistNotice = JsonConvert.DeserializeObject<List<ForwardingNoteModel>>(_objIHttpWebClients.PostRequest("Transit/PrintAndCloseTP", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF DSCPathUpdate(UpdateDSCPath objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Transit/DSCPathUpdate", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #region LICENSE_APP_ACK Detail for MSG
        /// <summary>
        /// LICENSE APP ACK Detail for MSG
        /// </summary>
        /// <param name="updateDSCPath"></param>
        /// <returns></returns>
        public LicenseFinalApproval LICENSE_APP_ACK(UpdateDSCPath updateDSCPath)
        {
            try
            {
                LicenseFinalApproval licenseFinalApproval = new LicenseFinalApproval();
                licenseFinalApproval = JsonConvert.DeserializeObject<LicenseFinalApproval>(_objIHttpWebClients.PostRequest("Transit/LICENSE_APP_ACK", JsonConvert.SerializeObject(updateDSCPath)));
                return licenseFinalApproval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region License App Granr Order Details for MSG
        /// <summary>
        /// License App Granr Order Details for MSG
        /// </summary>
        /// <param name="updateDSCPath"></param>
        /// <returns></returns>
        public LicenseFinalApproval LICENSE_APP_GRANT_ORDER(UpdateDSCPath updateDSCPath)
        {
            try
            {
                LicenseFinalApproval licenseFinalApproval = new LicenseFinalApproval();
                licenseFinalApproval = JsonConvert.DeserializeObject<LicenseFinalApproval>(_objIHttpWebClients.PostRequest("Transit/LICENSE_APP_GRANT_ORDER", JsonConvert.SerializeObject(updateDSCPath)));
                return licenseFinalApproval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Lessee  Details for MSG
        /// <summary>
        /// Lessee App Granr Order Details for MSG
        /// </summary>
        /// <param name="updateDSCPath"></param>
        /// <returns></returns>
        public LesseeFinalApproval LESSEE_BP(UpdateDSCPath updateDSCPath)
        {
            try
            {
                LesseeFinalApproval lesseeFinalApproval = new LesseeFinalApproval();
                lesseeFinalApproval = JsonConvert.DeserializeObject<LesseeFinalApproval>(_objIHttpWebClients.PostRequest("Transit/LESSEE_BP", JsonConvert.SerializeObject(updateDSCPath)));
                return lesseeFinalApproval;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
