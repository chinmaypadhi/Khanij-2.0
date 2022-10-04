// ***********************************************************************
//  Interface Name           : ILesseeForestClearanceProvider
//  Description              : Lessee Forest Clearance Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 27 July 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;

namespace MasterApi.Model.LesseeForestClearance
{
    public interface ILesseeForestClearanceProvider
    {
        /// <summary>
        /// To bind Forest Clearance details in view
        /// </summary>
        /// <param name="objLesseeForestClearanceViewModel"></param>
        /// <returns></returns>
        Task<LesseeForestClearanceViewModel> GetForestClearanceDetails(LesseeForestClearanceViewModel objLesseeForestClearanceViewModel);
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Forest Clearance details
        /// </summary>
        /// <param name="objLesseeForestClearanceViewModel"></param>
        /// <returns></returns>
        MessageEF UpdateForestClearanceDetails(LesseeForestClearanceViewModel objLesseeForestClearanceViewModel);
        /// <summary>
        /// To bind Forest Clearance Log History details in view
        /// </summary>
        /// <param name="objLesseeForestClearanceViewModel"></param>
        /// <returns></returns>
        Task<List<LesseeForestClearanceViewModel>> GetForestClearanceLogDetails(LesseeForestClearanceViewModel objLesseeForestClearanceViewModel);
        /// <summary>
        /// To bind Forest Clearance Compare details in view
        /// </summary>
        /// <param name="objLesseeForestClearanceViewModel"></param>
        /// <returns></returns>
        Task<List<LesseeForestClearanceViewModel>> GetForestClearanceCompareDetails(LesseeForestClearanceViewModel objLesseeForestClearanceViewModel);
        /// <summary>
        /// To Approve Lesse Forest Clearance details by DD
        /// </summary>
        /// <param name="objLesseeForestClearanceViewModel"></param>
        /// <returns></returns>
        MessageEF ApproveLesseeForestClearanceDetails(LesseeForestClearanceViewModel objLesseeForestClearanceViewModel);
        /// <summary>
        /// To Reject Lesse Forest Clearance details by DD
        /// </summary>
        /// <param name="objLesseeForestClearanceViewModel"></param>
        /// <returns></returns>
        MessageEF RejectLesseeForestClearanceDetails(LesseeForestClearanceViewModel objLesseeForestClearanceViewModel);
        /// <summary>
        /// To Delete Lesse Forest Clearance details by DD
        /// </summary>
        /// <param name="objLesseeForestClearanceViewModel"></param>
        /// <returns></returns>
        MessageEF DeleteLesseeForestClearanceDetails(LesseeForestClearanceViewModel objLesseeForestClearanceViewModel);
    }
}
