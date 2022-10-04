// ***********************************************************************
// Assembly         : Khanij
// Author           : Debaraj Swain
// Created          : 27-May-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using ReturnApi.Repository;
using ReturnEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnApi.Model.e_Return_NonCoal
{
   public interface IeReturnNonCoalProvider : IDisposable, IRepository
    {
        Task<DDLResult> ListOfFinancilaYear(MonthlyReturnModelNonCoal ObjMR);
        Task<List<MonthlyReturnModelNonCoal>> GetViewDetails(MonthlyReturnModelNonCoal model);
        Task<GetFormF1DetailsModel> GetLesseMineDeatils(MonthlyReturnModelNonCoal model);
        Task<GetFormF1DetailsModel> GeteReturnSubmittedDetails(MonthlyReturnModelNonCoal model);
        Task<GetRentRoyaltyDetailsModel> GetRentRoyalty(MonthlyReturnModelNonCoal model);
        Task<MessageEF> AddRoyaltyDetails(GetFormF1DetailsModel objModel);
        Task<MessageEF> UpdateRoyaltyDetails(GetFormF1DetailsModel objModel);
        Task<GetFormF1DetailsModel> GetMineralInfo(MonthlyReturnModelNonCoal model);
        Task<ProductionModel_Monthly> GetProduction(MonthlyReturnModelNonCoal model);
        Task<Details_of_deductions_Monthly> GetDetails_of_deductions(GetFormF1DetailsModel model);
        Task<Reason_Inc_Dec_Monthly> GetReason_Inc_Dec(GetFormF1DetailsModel model);
        Task<Details_of_deductions_Monthly> Getpulverization(GetFormF1DetailsModel model);
        Task<ProductionModel_Monthly> OpeningStock(GetFormF1DetailsModel model);
        Task<DDLResult> GetMineralForm(MonthlyReturnModelNonCoal ObjMR);
        Task<DDLResult> GetMineralGrade(MonthlyReturnModelNonCoal ObjMR);
        Task<MessageEF> ADDGradewise_ROM(Gradewise_ROMModel objModel);
        Task<List<Gradewise_ROMModel>> GetGradewise_ROM(MonthlyReturnModelNonCoal model);
        Task<MessageEF> UpdateGradewise_ROM(Gradewise_ROMModel objModel);
        Task<MessageEF> DeleteGradewise_ROM(Gradewise_ROMModel objModel);
        Task<DDLResult> GetMineralFormProduction(MonthlyReturnModelNonCoal ObjMR);
        Task<MessageEF> ADDGradewise_Production(Grade_WiseProduction objModel);
        Task<List<Grade_WiseProduction>> GetGrade_WiseProduction(MonthlyReturnModelNonCoal model);
        Task<MessageEF> UpdateGradewise_Prod(Grade_WiseProduction objModel);
        Task<MessageEF> DeleteGradewise_Prod(Grade_WiseProduction objModel);
        Task<List<SalesDispatchModel>> GetNatureOfDispatch(SalesDispatchModel ObjMR);
        Task<List<SalesDispatchModel>> GetPurchaserConsignee(MonthlyReturnModelNonCoal ObjMR);
        Task<MessageEF> AddSaleDispatch(SalesDispatchModel objModel);
        Task<List<SalesDispatchModel>> GetSalesDespatch(MonthlyReturnModelNonCoal model);
        Task<MessageEF> UpdateSaleDispatch(SalesDispatchModel objModel);
        Task<MessageEF> DeleteSaleDispatch(SalesDispatchModel objModel);
        Task<MessageEF> AddPulverization(Mineral_PulverizedModel objModel);
        Task<List<Mineral_PulverizedModel>> GetMineral_Pulverized(MonthlyReturnModelNonCoal model);
        Task<MessageEF> UpdateMineral_Pulverized(Mineral_PulverizedModel objModel);
        Task<MessageEF> DeleteeMineral_Pulverized(Mineral_PulverizedModel objModel);
        Task<MessageEF> AddReasonForInDc(Reason_Inc_Dec_Monthly objModel);
        Task<MessageEF> AddDeductionMade(Details_of_deductions_Monthly objModel);
        Task<MessageEF> UpdateReasonForInDc(Reason_Inc_Dec_Monthly objModel);
        Task<MessageEF> UpdateDetails_of_deductions(Details_of_deductions_Monthly objModel);

        Task<MessageEF> AddTypeProductionPartTwo(ProductionModel_Monthly objModel);
        Task<MessageEF> UpdateTypeProductionPartTwo(ProductionModel_Monthly objModel);
        Task<MessageEF> Update_FinalSubmit(Reason_Inc_Dec_Monthly objModel);
        Task<MessageEF> Addpulverization1(Details_of_deductions_Monthly objModel);
        Task<MessageEF> Updatepulverization(Details_of_deductions_Monthly objModel);
        Task<GetFormF1DetailsModel> GetFormF1Part1ForPrint(MonthlyReturnModelNonCoal model);
        Task<List<Working_of_Mine>> GetMineWorkDetails(MonthlyReturnModelNonCoal model);
        Task<MessageEF> Update_Filepath(MonthlyReturnModelNonCoal objModel);
    }
}
