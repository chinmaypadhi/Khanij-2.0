// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 14-Apr-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using StarratingEF;
using System.Collections.Generic;

namespace StarratingApp.Areas.Starrating.Models.Assessment
{
    public interface IAssessmentModel
    {
        #region View Assessment List
        /// <summary>
        /// Bind Assessment List details
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        List<AssessmentListmaster> View(AssessmentListmaster objAssessmentListmaster);
        #region Bind dropdowns
        /// <summary>
        /// To Bind the State Details Data in View
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        List<AssessmentListmaster> GetStateList(AssessmentListmaster stateResult);
        /// <summary>
        /// To Bind the District Details Data in View
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        List<AssessmentListmaster> GetDistrictList(AssessmentListmaster districtResult);
        /// <summary>
        /// To Bind the Tehsil Details Data in View
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        List<AssessmentListmaster> GetTehsilList(AssessmentListmaster tehsilResult);
        /// <summary>
        /// To Bind the Village Details Data in View
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        List<AssessmentListmaster> GetVillageList(AssessmentListmaster villageResult);
        #endregion
        #endregion
        /// <summary>
        /// Bind Financial Year List details in view
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        List<AssessmentListmaster> GetFYList(AssessmentListmaster villageResult);
        #region View Assessment Template List
        /// <summary>
        /// To Bind the Assessment Template List Details Data in View
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        AssessmentListmaster ViewAssessmentTemplate(AssessmentListmaster objAssessmentListmaster);
        #endregion
       
    }
}
