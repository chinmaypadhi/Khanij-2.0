// ***********************************************************************
// Assembly         : Khanij
// Author           : Debaraj Swain
// Created          : 1-Feb-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using userregistrationEFApi.Repository;
using userregistrationEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace userregistrationEFApi.Model.EndUser
{
   public interface IEndUserRegProvider : IDisposable, IRepository
    {
        Task<EndUserModel> GetOTPProvider(EndUserModel objER);
        Task<GetIndustryType> ListOfIType(EndUserModel objER);
        Task<GetListState> LstState(EndUserModel objER);
        Task<GetListState> ListOfDistrictByStateID(EndUserModel objER);
        Task<GetListState> LstState_O(EndUserModel objER);
        Task<GetListState> ListOfDistrictByStateID_O(EndUserModel objER);
        Task<GetListState> LstSQ(EndUserModel objER);
        Task<GetListState> ListOfMineral(EndUserModel objER);
        Task<GetListState> ListOfMineralForm(EndUserModel objER);
        Task<GetListState> ListOfMineralGrade(EndUserModel objER);
        Task<MessageEF> VerifyOTP(EndUserModel objER);
        Task<MessageEF> AddEndUserData(EndUserModel objER);
        Task<EndUserModel> GetUserDetailsProvider(EndUserModel objER);
        Task<List<EndUserModel>> ViewAllRequest(EndUserModel OBJEU);
        Task<EndUserBasicInfoModel> GetNewRequestDetailsProvider(EndUserModel objER);
        Task<MessageEF> ApproveEndUser(EndUserBasicInfoModel objER);
        Task<EndUserBasicInfoModel> GetUserDetails(EndUserBasicInfoModel objER);
        Task<MessageEF> RejectEndUser(EndUserBasicInfoModel objER); 
        Task<List<EndUserModel>> ViewUpdationRequest(EndUserModel OBJEU); 
        Task<List<ForceFullDataEndUser>> ActionTakenRequest(EndUserModel OBJEU); 
        Task<EndUserBasicInfoModel> GetActionTakenDetailsProvider(EndUserModel objER);
        Task<MessageEF> ViewEuserStatus(EndUserBasicInfoModel objER);
        Task<EndUserModel> GetEndUserDetails(EndUserModel objER);
        Task<MessageEF> ViewEuserProfStatus(EndUserModel1 objER); 
    }
}
