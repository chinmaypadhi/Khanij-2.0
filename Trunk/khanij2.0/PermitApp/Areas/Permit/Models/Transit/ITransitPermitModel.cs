using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermitEF;

namespace PermitApp.Areas.Permit.Models.Transit
{
   public interface ITransitPermitModel
    {
        eTransitResult GetBulkPermitForwarding(ForwardingNoteModel objUser);
        eTransitResult GetConsigerListForwardingNote(ForwardingNoteModel objUser);
        eTransitResult GetRailwaySiding(ForwardingNoteModel objUser);
        eTransitResult GetRailwaySidingDestination(ForwardingNoteModel objUser);
        List<ForwardingNoteModel> GetForwardingNoteView(ForwardingNoteModel objUser);
        List<ForwardingNoteModel> GetGrantOrderExpiry(ForwardingNoteModel objUser);
        eTransitResult getFNPreviewData(ForwardingNoteModel objUser);
        MessageEF AddRTPApplication(ForwardingNoteModel objUser);
        List<ForwardingNoteModel> GetForwadingTransactionNo(ForwardingNoteModel objUser);
        List<ForwardingNoteModel> GetAvailableData(ForwardingNoteModel objUser);
        List<ForwardingNoteModel> GetDGDMOFN(ForwardingNoteModel objUser);
        /// <summary>
        /// Get the data and bind for generate RTP pass
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        List<ForwardingNoteModel> GenerateRTPPass(ForwardingNoteModel objUser);
        /// <summary>
        /// Get the details of permit that to be close
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        List<ForwardingNoteModel> GetCloseRTPPassDetailsList(ForwardingNoteModel objUser);
        /// <summary>
        /// Closing Permit
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        MessageEF CloseRTPTripFor(ForwardingNoteModel objUser);
        /// <summary>
        /// Generate RTP pass
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        MessageEF UpdateRTPPass(ForwardingNoteModel objUser);
        /// <summary>
        /// Get RTP data to generate and close
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        List<ForwardingNoteModel> PrintAndCloseTP(ForwardingNoteModel objUser);
        MessageEF DSCPathUpdate(UpdateDSCPath objUser);
        LicenseFinalApproval LICENSE_APP_ACK(UpdateDSCPath updateDSCPath);
        LicenseFinalApproval LICENSE_APP_GRANT_ORDER(UpdateDSCPath updateDSCPath);
        LesseeFinalApproval LESSEE_BP(UpdateDSCPath updateDSCPath);
    }
}
