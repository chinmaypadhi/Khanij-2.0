// ***********************************************************************
//  Interface Name           : ILesseeEnvironmentClearanceProvider
//  Description              : Lessee Environment Clearance Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 30 July 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;

namespace MasterApi.Model.LesseeEnvironmentClearance
{
    public interface ILesseeEnvironmentClearanceProvider
    {
        /// <summary>
        /// To bind FY details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        Task<List<LesseeEnvironmentClearanceViewModel>> GetFYDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel);
        /// <summary>
        /// To bind Environment Clearance details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        Task<LesseeEnvironmentClearanceViewModel> GetEnvironmentClearanceDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel);
        /// <summary>
        /// To bind Environment Clearance Approved Quantity details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        Task<List<MiningProductionModel>> GetApprovedQuantityDetails(MiningProductionModel objLesseeEnvironmentClearanceModel);
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Environment Clearance details
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        MessageEF UpdateEnvironmentClearanceDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel);
        /// <summary>
        /// To bind Environment Clearance Log History details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        Task<List<LesseeEnvironmentClearanceViewModel>> GetEnvironmentClearanceLogDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel);
        /// <summary>
        /// To get Environment Clearance Approved Quantity details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        Task<List<LesseeEnvironmentClearanceViewModel>> GetEnvironmentClearanceApprovedQuantityLogDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel);
        /// <summary>
        /// To bind Environment Clearance Approved Quantity Log History details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        Task<List<LesseeEnvironmentClearanceViewModel>> GetEnvironmentClearanceApprovedQuantityLogDetailsView(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel);
        /// <summary>
        /// To bind Environment Clearance Compare details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        Task<List<LesseeEnvironmentClearanceViewModel>> GetEnvironmentClearanceCompareDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel);
        /// <summary>
        /// To bind Environment Clearance Approved Quantity Compare details in view
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        Task<List<MiningProductionModel>> GetEnvironmentClearanceApprovedQuantityCompareDetails(MiningProductionModel objLesseeEnvironmentClearanceModel);
        /// <summary>
        /// To Approve Lesse Environment Clearance details by DD
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        MessageEF ApproveLesseeEnvironmentClearanceDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel);
        /// <summary>
        /// To Reject Lesse Environment Clearance details by DD
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        MessageEF RejectLesseeEnvironmentClearanceDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel);
        /// <summary>
        /// To Delete Lesse Environment Clearance details by DD
        /// </summary>
        /// <param name="objLesseeEnvironmentClearanceModel"></param>
        /// <returns></returns>
        MessageEF DeleteLesseeEnvironmentClearanceDetails(LesseeEnvironmentClearanceViewModel objLesseeEnvironmentClearanceModel);
    }
}
