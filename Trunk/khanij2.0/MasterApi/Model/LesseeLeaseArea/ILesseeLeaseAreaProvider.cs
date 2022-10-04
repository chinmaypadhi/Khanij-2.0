// ***********************************************************************
//  Interface Name           : ILesseeLeaseAreaProvider
//  Description              : Lessee Lease Area Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 21 July 2021
// ***********************************************************************
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.LesseeLeaseArea
{
    public interface ILesseeLeaseAreaProvider
    {
        /// <summary>
        /// Bind State List details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<LeaseAreaViewModel>> GetStateList(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// Bind District List details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<LeaseAreaViewModel>> GetDistrictList(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// Bind Tehsil List details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<LeaseAreaViewModel>> GetTehsilList(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// Bind Village List details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<LeaseAreaViewModel>> GetVillageList(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// To bind Lessee Lease Area details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<LeaseAreaViewModel> GetLeaseAreaDetails(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// Bind Lease Land District List details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<LeaseAreaViewModel>> GetLeaseLandDistrictList(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// Bind Lease Land Village List details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<LeaseAreaViewModel>> GetLeaseLandVillageList(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Lease Area details
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        MessageEF UpdateLeaseAreaDetails(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// To bind Lessee Lease Area Log History details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<LeaseAreaViewModel>> GetLeaseAreaLogDetails(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// To bind Lessee Lease Area Compare details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<LeaseAreaViewModel>> GetLeaseAreaCompareDetails(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// To Approve Lessee Lease Area details by DD
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        MessageEF ApproveLeaseAreaDetails(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// To Reject Lessee Lease Area details by DD
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        MessageEF RejectLeaseAreaDetails(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// To Delete Lessee Lease Area details
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        MessageEF DeleteLeaseAreaDetails(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// Bind Land List details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<LeaseAreaViewModel>> GetLandList(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// Bind Lease Land Block List details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<LeaseAreaViewModel>> GetLeaseLandBlockList(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// Bind Vidhan Sabha List details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<LeaseAreaViewModel>> GetVidhanSabhaList(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// Bind Lok Sabha List details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<LeaseAreaViewModel>> GetLokSabhaList(LeaseAreaViewModel objLeaseAreaModel);
    }
}
