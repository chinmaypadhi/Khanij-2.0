using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermitEF;
using PermitApi.Repository;

namespace PermitApi.Model.Transit
{
   public interface ITransitProvider : IDisposable, IRepository
    {
        Task<eTransitResult> GetBulkPermitForwarding(ForwardingNoteModel objUser);
        Task<eTransitResult> GetConsigerListForwardingNote(ForwardingNoteModel objUser);
        Task<eTransitResult> GetRailwaySiding(ForwardingNoteModel objUser);
        Task<eTransitResult> GetRailwaySidingDestination(ForwardingNoteModel objUser);
        Task<List<ForwardingNoteModel>> GetForwardingNoteView(ForwardingNoteModel objUser);
        Task<List<ForwardingNoteModel>> GetGrantOrderExpiry(ForwardingNoteModel objUser);
        Task<eTransitResult> getFNPreviewData(ForwardingNoteModel objUser);
        Task<MessageEF> AddRTPApplication(ForwardingNoteModel objUser);
        Task<List<ForwardingNoteModel>> GetForwadingTransactionNo(ForwardingNoteModel objUser);
        Task<List<ForwardingNoteModel>> GetAvailableData(ForwardingNoteModel objUser);
        Task<List<ForwardingNoteModel>> GetDGDMOFN(ForwardingNoteModel objUser);
        /// <summary>
        /// Get the data and bind for generate RTP pass
        /// </summary>
        /// <param name="ForwardingNoteId"></param>
        /// <returns></returns>
        Task<List<ForwardingNoteModel>> GenerateRTPPass(ForwardingNoteModel objUser);
        /// <summary>
        /// Get the details of permit that to be close
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        Task<List<ForwardingNoteModel>> GetCloseRTPPassDetailsList(ForwardingNoteModel objUser);
        /// <summary>
        /// Closing Permit
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        Task<MessageEF> CloseRTPTripFor(ForwardingNoteModel objUser);
        /// <summary>
        /// Generate RTP pass
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        Task<MessageEF> UpdateRTPPass(ForwardingNoteModel objUser);
        /// <summary>
        /// Get RTP data to generate and close
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        Task<List<ForwardingNoteModel>> PrintAndCloseTP(ForwardingNoteModel objUser);
        /// <summary>
        /// Update status to generate Permit 
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        Task<MessageEF> DSCPathUpdate(UpdateDSCPath objUser);
        Task<LicenseFinalApproval> LICENSE_APP_ACK(UpdateDSCPath updateDSCPath);
        Task<LesseeFinalApproval> LESSEE_BP(UpdateDSCPath updateDSCPath);
        Task<LicenseFinalApproval> LICENSE_APP_GRANT_ORDER(UpdateDSCPath updateDSCPath);


    }
}
