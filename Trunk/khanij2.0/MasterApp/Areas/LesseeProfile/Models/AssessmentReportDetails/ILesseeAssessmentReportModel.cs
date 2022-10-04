// ***********************************************************************
//  Interface Name           : ILesseeAssessmentReportModel
//  Description              : Lessee Assessment Report View Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 29 July 2021
// ***********************************************************************
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.LesseeProfile.Models.AssessmentReportDetails
{
    public interface ILesseeAssessmentReportModel
    {
        /// <summary>
        /// To bind Assessment Report details in view
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        Task<LesseeAssessmentReportViewModel> GetAssessmentReportDetails(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel);
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Assessment Report details
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        MessageEF UpdateAssessmentReportDetails(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel);
        /// <summary>
        /// To bind Assessment Report Log details in view
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        Task<List<LesseeAssessmentReportViewModel>> GetAssessmentReportLogDetails(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel);
        /// <summary>
        /// To bind Assessment Report Compare details in view
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        Task<List<LesseeAssessmentReportViewModel>> GetAssessmentReportCompareDetails(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel);
        /// <summary>
        /// To Approve Lesse Assessment Report details by DD
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        MessageEF ApproveLesseeAssessmentReportDetails(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel);
        /// <summary>
        /// To Reject Lesse Assessment Report details by DD
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        MessageEF RejectLesseeAssessmentReportDetails(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel);
        /// <summary>
        /// To Delete Lesse Assessment Report details by DD
        /// </summary>
        /// <param name="objLesseeAssessmentReportModel"></param>
        /// <returns></returns>
        MessageEF DeleteLesseeAssessmentReportDetails(LesseeAssessmentReportViewModel objLesseeAssessmentReportModel);
    }
}
