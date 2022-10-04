// ***********************************************************************
//  Interface Name           : ILesseeMiningPlanProvider
//  Description              : Lessee Mining Plan Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 01 August 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;

namespace MasterApi.Model.LesseeMiningPlan
{
    public interface ILesseeMiningPlanProvider
    {
        /// <summary>
        /// To bind Mining Plan Financial year details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        Task<List<LesseeMiningPlanViewModel>> GetFYDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel);
        /// <summary>
        /// To bind Mining Plan details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        Task<LesseeMiningPlanViewModel> GetMiningPlanDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel);
        /// <summary>
        /// To bind Mining Plan Production details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        Task<List<MiningProductionModel>> GetProductionDetails(MiningProductionModel objLesseeMiningPlanModel);
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Mining Plan details
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        MessageEF UpdateMiningPlanDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel);
        /// <summary>
        /// To bind Mining Plan Log History details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        Task<List<LesseeMiningPlanViewModel>> GetMiningPlanMPLogDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel);
        /// <summary>
        /// To bind Mining Scheme Log History details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        Task<List<LesseeMiningPlanViewModel>> GetMiningPlanMSLogDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel);
        /// <summary>
        /// To bind Mining Scheme Log History details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        Task<List<LesseeMiningPlanViewModel>> GetMiningPlanMSLogDetailsView(LesseeMiningPlanViewModel objLesseeMiningPlanModel);
        /// <summary>
        /// To bind Mining Plan Compare details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        Task<List<LesseeMiningPlanViewModel>> GetMiningPlanCompareDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel);
        /// <summary>
        /// To bind Mining Scheme Compare details in view
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        Task<List<MiningProductionModel>> GetMiningSchemeCompareDetails(MiningProductionModel objLesseeMiningPlanModel);
        /// <summary>
        /// To Approve Lesse Mining Plan details by DD
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        MessageEF ApproveLesseeMiningPlanDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel);
        /// <summary>
        /// To Reject Lesse Mining Plan details by DD
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        MessageEF RejectLesseeMiningPlanDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel);
        /// <summary>
        /// To Delete Lesse Mining Plan details by DD
        /// </summary>
        /// <param name="objLesseeMiningPlanModel"></param>
        /// <returns></returns>
        MessageEF DeleteLesseeMiningPlanDetails(LesseeMiningPlanViewModel objLesseeMiningPlanModel);
    }
}
