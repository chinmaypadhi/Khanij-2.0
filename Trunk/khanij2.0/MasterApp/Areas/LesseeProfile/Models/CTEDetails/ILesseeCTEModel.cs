// ***********************************************************************
//  Interface Name           : ILesseeCTEModel
//  Description              : Lessee Consent To Establish View Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 28 July 2021
// ***********************************************************************
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.LesseeProfile.Models.CTEDetails
{
    public interface ILesseeCTEModel
    {
        /// <summary>
        /// To bind Consent To Establish details in view
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        Task<LesseeCTEViewModel> GetCTEDetails(LesseeCTEViewModel objLesseeCTEModel);
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Consent To Establish details
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        MessageEF UpdateCTEDetails(LesseeCTEViewModel objLesseeCTEModel);
        /// <summary>
        /// To bind Consent To Establish Log details in view
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        Task<List<LesseeCTEViewModel>> GetCTELogDetails(LesseeCTEViewModel objLesseeCTEModel);
        /// <summary>
        /// To bind Consent To Establish Compare details in view
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        Task<List<LesseeCTEViewModel>> GetCTECompareDetails(LesseeCTEViewModel objLesseeCTEModel);
        /// <summary>
        /// To Approve Lesse Consent To Establish details by DD
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        MessageEF ApproveLesseeCTEDetails(LesseeCTEViewModel objLesseeCTEModel);
        /// <summary>
        /// To Reject Lesse Consent To Establish details by DD
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        MessageEF RejectLesseeCTEDetails(LesseeCTEViewModel objLesseeCTEModel);
        /// <summary>
        /// To Delete Lesse Consent To Establish details by DD
        /// </summary>
        /// <param name="objLesseeCTEModel"></param>
        /// <returns></returns>
        MessageEF DeleteLesseeCTEDetails(LesseeCTEViewModel objLesseeCTEModel);
    }
}
