// ***********************************************************************
//  Interface Name           : IProfileProvider
//  Description              : View Lessee Profile details
//  Created By               : Lingaraj Dalai
//  Created On               : 10 Feb 2022
// ***********************************************************************
using MasterEF;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterApi.Model.Profile
{
    public interface IProfileProvider
    {
        /// <summary>
        /// Bind Profile Completion Count Details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        Task<LesseeInfoModel> GetProfileCompletionCount(LesseeInfoModel objLesseeInfoModel);
        /// <summary>
        /// Bind Profile Completion Request Count Details in view
        /// </summary>
        /// <param name="objLesseeProfileIndividualCountModel"></param>
        /// <returns></returns>
        Task<LesseeProfileIndividualCountModel> GetLesseeProfileIndividualCountModel(LesseeProfileIndividualCountModel objLesseeProfileIndividualCountModel);
        /// <summary>
        /// Bind Lessee Licensee Users by District in view
        /// </summary>
        /// <param name="objLesseeProfileIndividualCountModel"></param>
        /// <returns></returns>
        Task<List<LesseeProfileIndividualCountModel>> GetLesseeLicneseeUserByDistrict(LesseeProfileIndividualCountModel objLesseeProfileIndividualCountModel);
        /// <summary>
        /// Bind Lessee Users by User,Role type in view
        /// </summary>
        /// <param name="objLesseeListForDGMModel"></param>
        /// <returns></returns>
        Task<List<LesseeListForDGMModel>> GetLesseeListDGM(LesseeListForDGMModel objLesseeListForDGMModel);
    }
}
