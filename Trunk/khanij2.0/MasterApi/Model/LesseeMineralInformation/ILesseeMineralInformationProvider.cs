// ***********************************************************************
//  Interface Name           : ILesseeMineralInformationProvider
//  Description              : Lessee Mineral Information Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 04 August 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;

namespace MasterApi.Model.LesseeMineralInformation
{
    public interface ILesseeMineralInformationProvider
    {
        #region Binddropdowns
        /// <summary>
        /// To bind Mineral Category details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        Task<List<LesseeMineralInformationModel>> GetMineralCategoryDetails(LesseeMineralInformationModel objLesseeMineralInformationModel);
        /// <summary>
        /// To bind Mineral Name details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        Task<List<LesseeMineralInformationModel>> GetMineralNameDetails(LesseeMineralInformationModel objLesseeMineralInformationModel);
        /// <summary>
        /// To bind Mineral Form details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        Task<List<LesseeMineralInformationModel>> GetMineralFormDetails(LesseeMineralInformationModel objLesseeMineralInformationModel);
        /// <summary>
        /// To bind Mineral Grade details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        Task<List<LesseeMineralInformationModel>> GetMineralGradeDetails(LesseeMineralInformationModel objLesseeMineralInformationModel);
        #endregion
        /// <summary>
        /// To bind Lessee Mineral Information details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        Task<LesseeMineralInformationModel> GetMineralInformationDetails(LesseeMineralInformationModel objLesseeMineralInformationModel);
        /// <summary>
        /// To bind Mineral Information Log History details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        Task<List<LesseeMineralInformationModel>> GetMineralInformationLogDetails(LesseeMineralInformationModel objLesseeMineralInformationModel);
        /// <summary>
        /// To bind Mineral Information Compare details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        Task<List<LesseeMineralInformationModel>> GetMineralInformationCompareDetails(LesseeMineralInformationModel objLesseeMineralInformationModel);
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Mineral Information details
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        MessageEF UpdateMineralInformationDetails(LesseeMineralInformationModel objLesseeMineralInformationModel);
        /// <summary>
        /// To Approve Lesse Mineral Information details by DD
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        MessageEF ApproveLesseeMineralInformationDetails(LesseeMineralInformationModel objLesseeMineralInformationModel);
        /// <summary>
        /// To Reject Lesse Mineral Information details by DD
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        MessageEF RejectLesseeMineralInformationDetails(LesseeMineralInformationModel objLesseeMineralInformationModel);
        /// <summary>
        /// To Delete Lesse Mineral Information details by DD
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        MessageEF DeleteLesseeMineralInformationDetails(LesseeMineralInformationModel objLesseeMineralInformationModel);
    }
}
