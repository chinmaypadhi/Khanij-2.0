// ***********************************************************************
//  Interface Name           : IProfileModel
//  Description              : Lessee Profile Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 10 Feb 2022
// ***********************************************************************
using MasterEF;
using System.Collections.Generic;

namespace MasterApp.Areas.LesseeProfile.Models.Profile
{
    public interface IProfileModel
    {
        /// <summary>
        /// Bind Profile Completion Count Details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        LesseeInfoModel GetProfileCompletionCount(LesseeInfoModel objLesseeInfoModel);
        /// <summary>
        /// Bind Profile Completion Request Count Details in view
        /// </summary>
        /// <param name="objLesseeProfileIndividualCountModel"></param>
        /// <returns></returns>
        LesseeProfileIndividualCountModel GetLesseeProfileIndividualCountModel(LesseeProfileIndividualCountModel objLesseeProfileIndividualCountModel);
        /// <summary>
        /// Bind Lessee Licensee Users by District in view
        /// </summary>
        /// <param name="objLesseeProfileIndividualCountModel"></param>
        /// <returns></returns>
        List<LesseeProfileIndividualCountModel> GetLesseeLicneseeUserByDistrict(LesseeProfileIndividualCountModel objLesseeProfileIndividualCountModel);
        /// <summary>
        /// Bind Lessee Users by User,Role type in view
        /// </summary>
        /// <param name="objLesseeListForDGMModel"></param>
        /// <returns></returns>
        List<LesseeListForDGMModel> GetLesseeListDGM(LesseeListForDGMModel objLesseeListForDGMModel);
    }
}
