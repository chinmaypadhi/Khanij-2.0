// ***********************************************************************
//  Interface Name           : ILesseeCTOModel
//  Description              : Lessee Consent To Operate View Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 29 July 2021
// ***********************************************************************
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MasterApp.Areas.LesseeProfile.Models.CTODetails
{
    public interface ILesseeCTOModel
    {
        /// <summary>
        /// To bind Consent To Operate Financial year details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        Task<List<LesseeCTOViewModel>> GetFYDetails(LesseeCTOViewModel objLesseeCTOModel);
        /// <summary>
        /// To bind Consent To Operate details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        Task<LesseeCTOViewModel> GetCTODetails(LesseeCTOViewModel objLesseeCTOModel);
        /// <summary>
        /// To bind Consent To Operate Approved Quantity Details details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        Task<List<MiningProductionModel>> GetApprovedQuantityDetails(MiningProductionModel objLesseeCTOModel);
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Consent To Operate details
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        MessageEF UpdateCTODetails(LesseeCTOViewModel objLesseeCTOModel);
        /// <summary>
        /// To bind Consent To Operate Log details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        Task<List<LesseeCTOViewModel>> GetCTOLogDetails(LesseeCTOViewModel objLesseeCTOModel);
        /// <summary>
        /// To get Consent To Operate Log History details
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        Task<List<LesseeCTOViewModel>> GetCTOApprovedQuantityLogDetails(LesseeCTOViewModel objLesseeCTOModel);
        /// <summary>
        /// To bind Consent To Operate Log History details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        Task<List<LesseeCTOViewModel>> GetCTOApprovedQuantityLogDetailsView(LesseeCTOViewModel objLesseeCTOModel);
        /// <summary>
        /// To bind Consent To Operate Compare details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        Task<List<LesseeCTOViewModel>> GetCTOCompareDetails(LesseeCTOViewModel objLesseeCTOModel);
        /// <summary>
        /// To bind Consent To Operate Approved Quantity Compare details in view
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        Task<List<MiningProductionModel>> GetCTOApprovedQuantityCompareDetails(MiningProductionModel objLesseeCTOModel);
        /// <summary>
        /// To Approve Lesse Consent To Operate details by DD
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        MessageEF ApproveLesseeCTODetails(LesseeCTOViewModel objLesseeCTOModel);
        /// <summary>
        /// To Reject Lesse Consent To Operate details by DD
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        MessageEF RejectLesseeCTODetails(LesseeCTOViewModel objLesseeCTOModel);
        /// <summary>
        /// To Delete Lesse Consent To Operate details by DD
        /// </summary>
        /// <param name="objLesseeCTOModel"></param>
        /// <returns></returns>
        MessageEF DeleteLesseeCTODetails(LesseeCTOViewModel objLesseeCTOModel);
    }
}
