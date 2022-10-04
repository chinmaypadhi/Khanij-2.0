using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PermitApi.Model.Transit;
using PermitEF;

namespace PermitApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class TransitController : Controller
    {
        public ITransitProvider _objITransitProvider;
        public TransitController(ITransitProvider objTransitProvider)
        {
            _objITransitProvider = objTransitProvider;
        }
        [HttpPost]
        public async Task<eTransitResult> GetBulkPermitForwarding(ForwardingNoteModel objLease)
        {
            return await _objITransitProvider.GetBulkPermitForwarding(objLease);
        }
        [HttpPost]
        public async Task<eTransitResult> GetConsigerListForwardingNote(ForwardingNoteModel objLease)
        {
            return await _objITransitProvider.GetConsigerListForwardingNote(objLease);
        }
        [HttpPost]
        public async Task<eTransitResult> GetRailwaySiding(ForwardingNoteModel objLease)
        {
            return await _objITransitProvider.GetRailwaySiding(objLease);
        }
        [HttpPost]
        public async Task<eTransitResult> GetRailwaySidingDestination(ForwardingNoteModel objLease)
        {
            return await _objITransitProvider.GetRailwaySidingDestination(objLease);
        }
        [HttpPost]
        public async Task<List<ForwardingNoteModel>> GetForwardingNoteView(ForwardingNoteModel objLease)
        {
            return await _objITransitProvider.GetForwardingNoteView(objLease);
        }
        [HttpPost]
        public async Task<List<ForwardingNoteModel>> GetGrantOrderExpiry(ForwardingNoteModel objLease)
        {
            return await _objITransitProvider.GetGrantOrderExpiry(objLease);
        }
        [HttpPost]
        public async Task<eTransitResult> getFNPreviewData(ForwardingNoteModel objLease)
        {
            return await _objITransitProvider.getFNPreviewData(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> AddRTPApplication(ForwardingNoteModel objLease)
        {
            return await _objITransitProvider.AddRTPApplication(objLease);
        }
        [HttpPost]
        public async Task<List<ForwardingNoteModel>> GetForwadingTransactionNo(ForwardingNoteModel objLease)
        {
            return await _objITransitProvider.GetForwadingTransactionNo(objLease);
        }
        [HttpPost]
        public async Task<List<ForwardingNoteModel>> GetAvailableData(ForwardingNoteModel objLease)
        {
            return await _objITransitProvider.GetAvailableData(objLease);
        }
        [HttpPost]
        public async Task<List<ForwardingNoteModel>> GetDGDMOFN(ForwardingNoteModel objLease)
        {
            return await _objITransitProvider.GetDGDMOFN(objLease);
        }
        [HttpPost]
        public async Task<List<ForwardingNoteModel>> GenerateRTPPass(ForwardingNoteModel objLease)
        {
            return  await _objITransitProvider.GenerateRTPPass(objLease);
        }
        /// <summary>
        /// Get the details of permit that to be close
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<ForwardingNoteModel>> GetCloseRTPPassDetailsList(ForwardingNoteModel objLease)
        {
            return await _objITransitProvider.GetCloseRTPPassDetailsList(objLease);
        }
        /// <summary>
        /// Close RTP Trip
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> CloseRTPTripFor(ForwardingNoteModel objLease)
        {
            return await _objITransitProvider.CloseRTPTripFor(objLease);
        }
        /// <summary>
        /// Generate and close RTP
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateRTPPass(ForwardingNoteModel objLease)
        {
            return await _objITransitProvider.UpdateRTPPass(objLease);
        }
        /// <summary>
        /// Get details of  RTP to generate and close
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<ForwardingNoteModel>> PrintAndCloseTP(ForwardingNoteModel objLease)
        {
            return await _objITransitProvider.PrintAndCloseTP(objLease);
        }
        /// <summary>
        /// Update status to generate Permit 
        /// </summary>
        /// <param name="objLease"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> DSCPathUpdate(UpdateDSCPath objLease)
        {
            return await _objITransitProvider.DSCPathUpdate(objLease);
        }
        #region License Approval ACK Detail for MSG
        /// <summary>
        /// License Approval ACK Detail for MSG
        /// </summary>
        /// <param name="updateDSCPath"></param>
        /// <returns></returns>
        public async Task<LicenseFinalApproval> LICENSE_APP_ACK(UpdateDSCPath updateDSCPath)
        {
            return await _objITransitProvider.LICENSE_APP_ACK(updateDSCPath);
        }
        #endregion
        #region Lessee ACK Detail for MSG
        /// <summary>
        /// Lessee ACK Detail for MSG
        /// </summary>
        /// <param name="updateDSCPath"></param>
        /// <returns></returns>
        public async Task<LesseeFinalApproval> LESSEE_BP(UpdateDSCPath updateDSCPath)
        {
            return await _objITransitProvider.LESSEE_BP(updateDSCPath);
        }
        #endregion
        #region License App Grant Order Details for MSG
        /// <summary>
        /// License App Grant Order detail for MSG
        /// </summary>
        /// <param name="updateDSCPath"></param>
        /// <returns></returns>
        public async Task<LicenseFinalApproval> LICENSE_APP_GRANT_ORDER(UpdateDSCPath updateDSCPath)
        {
            return await _objITransitProvider.LICENSE_APP_GRANT_ORDER(updateDSCPath);
        }
        #endregion
    }
}