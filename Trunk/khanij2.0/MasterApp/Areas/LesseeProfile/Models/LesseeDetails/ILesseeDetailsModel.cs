// ***********************************************************************
//  Interface Name           : ILesseeDetailsModel
//  Desciption               : Lessee Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 01 July 2021
// ***********************************************************************
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.LesseeProfile.Models.LesseeDetails
{
    public interface ILesseeDetailsModel
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
        /// <param name="lesseetypeResult"></param>
        /// <returns></returns>
        List<LesseeInfoModel> GetLesseeTypeList(LesseeInfoModel lesseetypeResult);
        /// <summary>
        /// To Bind the Auction Type Details Data in View
        /// </summary>
        /// <param name="auctiontypeResult"></param>
        /// <returns></returns>
        List<LesseeInfoModel> GetAuctionTypeList(LesseeInfoModel auctiontypeResult);
        /// <summary>
        /// To Update Lesse Profile details
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        MessageEF UpdateLesseeProfileDetails(LesseeInfoModel objLesseeInfoModel);
        /// <summary>
        /// To Bind the Lessee Profile Log Details Data in View
        /// </summary>
        /// <param name="lesseetypeResult"></param>
        /// <returns></returns>
        List<LesseeInfoModel> GetLesseeProfileLogList(LesseeInfoModel lesseetypeResult);
        /// <summary>
        /// To bind Lessee Profile Request Data in view
        /// </summary>
        /// <param name="lesseeProfileRequestResult"></param>
        /// <returns></returns>
        List<LesseeProfileRequestModel> GetLesseeProfileRequestData(LesseeProfileRequestModel lesseeProfileRequestResult);
        /// <summary>
        /// To bind Last approved Lessee Profile Details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        List<LesseeInfoModel>GetLesseeProfileCompareDetails(LesseeInfoModel objLesseeInfoModel);
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
        /// To Bind the State Details Data in View
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        List<LesseeInfoModel> GetStateList(LesseeInfoModel objLesseeInfoModel);
        /// <summary>
        /// To Bind the User Type Details Data in View
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        List<LesseeInfoModel> GetUserTypeList(LesseeInfoModel objLesseeInfoModel);
        /// <summary>
        /// To Bind the User Details Data in View
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        List<LesseeInfoModel> GetUserList(LesseeInfoModel objLesseeInfoModel);
        /// <summary>
        /// To Bind the Captive Details Data in View
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        List<LesseeInfoModel> GetCaptiveList(LesseeInfoModel objLesseeInfoModel);

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
