// ***********************************************************************
//  Interface Name           : ILesseeForestClearanceModel
//  Description              : Lessee Forest Clearance View Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 27 July 2021
// ***********************************************************************
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.LesseeProfile.Models.ForestClearanceDetails
{
    public interface ILesseeForestClearanceModel
    {
        /// <summary>
        /// To bind Forest Clearance details in view
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        Task<LesseeForestClearanceViewModel> GetForestClearanceDetails(LesseeForestClearanceViewModel objLesseeForestClearanceModel);
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Forest Clearance details
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        MessageEF UpdateForestClearanceDetails(LesseeForestClearanceViewModel objLesseeForestClearanceModel);
        /// <summary>
        /// To bind Forest Clearance Log details in view
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        Task<List<LesseeForestClearanceViewModel>> GetForestClearanceLogDetails(LesseeForestClearanceViewModel objLesseeForestClearanceModel);
        /// <summary>
        /// To bind Forest Clearance Compare details in view
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        Task<List<LesseeForestClearanceViewModel>> GetForestClearanceCompareDetails(LesseeForestClearanceViewModel objLesseeForestClearanceModel);
        /// <summary>
        /// To Approve Lesse Forest Clearance details by DD
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        MessageEF ApproveLesseeForestClearanceDetails(LesseeForestClearanceViewModel objLesseeForestClearanceModel);
        /// <summary>
        /// To Reject Lesse Forest Clearance details by DD
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        MessageEF RejectLesseeForestClearanceDetails(LesseeForestClearanceViewModel objLesseeForestClearanceModel);
        /// <summary>
        /// To Delete Lesse Forest Clearance details by DD
        /// </summary>
        /// <param name="objLesseeForestClearanceModel"></param>
        /// <returns></returns>
        MessageEF DeleteLesseeForestClearanceDetails(LesseeForestClearanceViewModel objLesseeForestClearanceModel);
    }
}
