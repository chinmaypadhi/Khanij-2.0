// ***********************************************************************
//  Interface Name           : ILeaseAreaModel
//  Description              : Lessee Lease Area Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 21 July 2021
// ***********************************************************************
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.LesseeProfile.Models.LeaseAreaDetails
{
    public interface ILesseeLeaseAreaModel
    {
        /// <summary>
        /// To Bind the State Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<LeaseAreaViewModel>> GetStateList(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// To Bind the District Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<LeaseAreaViewModel>> GetDistrictList(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// To Bind the Tehsil Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<LeaseAreaViewModel>> GetTehsilList(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// To Bind the Village Details Data in View
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
        /// To Bind the Lease Land District Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<LeaseAreaViewModel>> GetLeaseLandDistrictList(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// To Bind the Lease Land Village Details Data in View
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
        /// To bind Lease Area Log details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<LeaseAreaViewModel>> GetLeaseAreaLogDetails(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// To bind Lease Area Compare details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<LeaseAreaViewModel>> GetLeaseAreaCompareDetails(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// To Approve Lesse Lease Area details by DD
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        MessageEF ApproveLeaseAreaDetails(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// To Reject Lesse Lease Area details by DD
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        MessageEF RejectLeaseAreaDetails(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// To Delete Lesse Lease Area details by DD
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        MessageEF DeleteLesseeLeaseAreaDetails(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// To Bind the Land Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<LeaseAreaViewModel>> GetLandList(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// To Bind the Lease Land Block Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<LeaseAreaViewModel>> GetLeaseLandBlockList(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// To Bind the Vidhan Sabha Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        List<LeaseAreaViewModel> GetVidhanSabhaList(LeaseAreaViewModel objLeaseAreaModel);
        /// <summary>
        /// To Bind the Lok sabha Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        List<LeaseAreaViewModel> GetLokSabhaList(LeaseAreaViewModel objLeaseAreaModel);
    }
}
