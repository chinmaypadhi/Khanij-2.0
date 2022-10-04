// ***********************************************************************
//  Interface Name           : ILesseeIBMDetails
//  Description              : Lessee IBM View Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 26 July 2021
// ***********************************************************************
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.LesseeProfile.Models.IBMDetails
{
    public interface ILesseeIBMModelDetails
    {
        /// <summary>
        /// To bind IBM details in view
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        Task<LesseeIBMDetailsViewModel> GetIBMDetails(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel);
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse IBM details
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        MessageEF UpdateIBMDetails(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel);
        /// <summary>
        /// To bind IBM Log details in view
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        Task<List<LesseeIBMDetailsViewModel>> GetIBMLogDetails(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel);
        /// <summary>
        /// To bind IBM Compare details in view
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        Task<List<LesseeIBMDetailsViewModel>> GetIBMCompareDetails(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel);
        /// <summary>
        /// To Approve Lesse IBM details by DD
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        MessageEF ApproveLesseeIBMDetails(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel);
        /// <summary>
        /// To Reject Lesse IBM details by DD
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        MessageEF RejectLesseeIBMDetails(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel);
        /// <summary>
        /// To Delete Lesse IBM details by DD
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        MessageEF DeleteLesseeIBMDetails(LesseeIBMDetailsViewModel objLesseeIBMDetailsModel);
    }
}
