// ***********************************************************************
//  Interface Name           : IAssessmentProvider
//  Desciption               : Starrating Assessment of Lessee 
//  Created By               : Lingaraj Dalai
//  Created On               : 14 April 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using StarRatingApi.Repository;
using StarratingEF;

namespace StarRatingApi.Model.Assessment
{
    public interface IAssessmentProvider: IDisposable, IRepository
    {
        #region View Assessment List
        /// <summary>
        ///  View Assessment List details in view
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        List<AssessmentListmaster> ViewAssessmentListmaster(AssessmentListmaster objAssessmentListmaster);
        #region Dropdowns
        /// <summary>
        /// Bind State List details in view
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        List<AssessmentListmaster> GetStateList(AssessmentListmaster objAssessmentListmaster);
        /// <summary>
        /// Bind District List details in view
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        List<AssessmentListmaster> GetDistrictList(AssessmentListmaster objAssessmentListmaster);
        /// <summary>
        /// Bind Tehsil List details in view
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        List<AssessmentListmaster> GetTehsilList(AssessmentListmaster objAssessmentListmaster);
        /// <summary>
        /// Bind Village List details in view
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        List<AssessmentListmaster> GetVillageList(AssessmentListmaster objAssessmentListmaster);
        #endregion
        #endregion
        /// <summary>
        /// Bind Financial Year List details in view
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        List<AssessmentListmaster> GetFYList(AssessmentListmaster objAssessmentListmaster);
        #region View Assessment Template List
        /// <summary>
        /// View Assessment Template List details in view
        /// </summary>
        /// <param name="objAssessmentListmaster"></param>
        /// <returns></returns>
        AssessmentListmaster ViewAssessmentTemplateListmaster(AssessmentListmaster objAssessmentListmaster);
        #endregion
       
    }
}
