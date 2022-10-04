// ***********************************************************************
//  Interface Name           : ILesseeDetailsProvider
//  Desciption               : Lessee Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 01 July 2021
// ***********************************************************************
using MasterEF;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterApi.Model.LesseeDetails
{
    public interface ILesseeDetailsProvider
    {
        /// <summary>
        /// To bind Lessee Profile Details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        LesseeInfoModel GetLesseeProfileDetails(LesseeInfoModel objLesseeInfoModel);
        /// <summary>
        /// To Bind the Lessee Type Details Data in View
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        List<LesseeInfoModel> GetLesseeTypeList(LesseeInfoModel objLesseeInfoModel);
        /// <summary>
        /// To Bind the Auction Type Details Data in View
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        List<LesseeInfoModel> GetAuctionTypeList(LesseeInfoModel objLesseeInfoModel);
        /// <summary>
        /// To Update Lesse Profile details
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        MessageEF UpdateLesseeProfileDetails(LesseeInfoModel objLesseeInfoModel);
        /// <summary>
        /// To bind Lessee Profile Log Details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        List<LesseeInfoModel> GetLesseeProfileLogList(LesseeInfoModel objLesseeInfoModel);
        /// <summary>
        /// To bind Lessee Profile Request Data in view
        /// </summary>
        /// <param name="objLesseeProfileRequestModel"></param>
        /// <returns></returns>
        List<LesseeProfileRequestModel> GetLesseeProfileRequestData(LesseeProfileRequestModel objLesseeProfileRequestModel);
        /// <summary>
        /// To bind Last approved Lessee Profile Details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        List<LesseeInfoModel> GetLesseeProfileCompareDetails(LesseeInfoModel objLesseeInfoModel);
        /// <summary>
        /// To Approve Lesse Profile details by DD
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        MessageEF ApproveLesseeProfileDetails(LesseeInfoModel objLesseeInfoModel);
        /// <summary>
        /// To Reject Lesse Profile details by DD
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        MessageEF RejectLesseeProfileDetails(LesseeInfoModel objLesseeInfoModel);
        /// <summary>
        /// To Delete Lesse Profile details
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        MessageEF DeleteLesseeProfileDetails(LesseeInfoModel objLesseeInfoModel);
        /// <summary>
        /// To Bind the User Type Details Data in View
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        Task<List<LesseeInfoModel>> GetUserTypeList(LesseeInfoModel objLesseeInfoModel);
        /// <summary>
        /// To Bind the User Details Data in View
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        Task<List<LesseeInfoModel>> GetUserList(LesseeInfoModel objLesseeInfoModel);
        /// <summary>
        /// To Bind the Captive Details Data in View
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        Task<List<LesseeInfoModel>> GetCaptiveList(LesseeInfoModel objLesseeInfoModel);

        /// <summary>
        /// To bind Captive purpose details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        Task<List<CaptivePurposeModel>> GetPurposeDetails(CaptivePurposeModel objLesseeInfoModel);
        /// <summary>
        /// To bind Lessee Captive purpose log details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        Task<List<LesseeInfoModel>> GetCaptivePurposeLogDetails(LesseeInfoModel objLesseeInfoModel);
        /// <summary>
        /// To bind Captive purpose log history details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        Task<List<LesseeInfoModel>> GetCaptivePurposeLogDetailsView(LesseeInfoModel objLesseeInfoModel);
        /// <summary>
        /// To bind Captive purpose compare details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        Task<List<CaptivePurposeModel>> GetCaptivePurposeLogDetailsCompareDetails(CaptivePurposeModel objLesseeInfoModel);
    }
}
