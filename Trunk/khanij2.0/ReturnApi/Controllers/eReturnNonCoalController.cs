// ***********************************************************************
//  Controller Name          : eReturnNonCoal
//  Desciption               : Add Monthly F1 ruturn API
//  Created By               : Debaraj Swain
//  Created On               : 12 July 2021
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReturnApi.Model.DailyProduction;
using ReturnEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReturnApi.Model.e_Return_NonCoal;
using Microsoft.AspNetCore.Authorization;

namespace ReturnApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class eReturnNonCoalController : ControllerBase
    {
        public IeReturnNonCoalProvider _objIeReturnNonCoalProvider;
        public eReturnNonCoalController(IeReturnNonCoalProvider objeReturnNonCoalProvider)
        {
            _objIeReturnNonCoalProvider = objeReturnNonCoalProvider;
        }
        /// <summary>
        /// Load Financial Year DrodownList
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>DDLResult class</returns>
        [HttpPost]
        public async Task<DDLResult> ViewFYDDL(MonthlyReturnModelNonCoal objDP)
        {
            return await _objIeReturnNonCoalProvider.ListOfFinancilaYear(objDP);
        }

        /// <summary>
        /// Get Details of F1 Monthly Return
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of MonthlyReturnModelNonCoal class</returns>
        [HttpPost]
        public async Task<List<MonthlyReturnModelNonCoal>> ViewData(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalProvider.GetViewDetails(objEU);
        }

        /// <summary>
        /// Get Lessee Mine Details
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>GetFormF1DetailsModel class</returns>
        [HttpPost]
        public async Task<GetFormF1DetailsModel> GetLesseMineDeatils(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalProvider.GetLesseMineDeatils(objEU);
        }

        /// <summary>
        /// Get details of submitted records 
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>GetFormF1DetailsModel class</returns>
        [HttpPost]
        public async Task<GetFormF1DetailsModel> GeteReturnSubmittedDetails(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalProvider.GeteReturnSubmittedDetails(objEU);
        }

        /// <summary>
        /// Get Royalty Details
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>GetRentRoyaltyDetailsModel class</returns>
        [HttpPost]
        public async Task<GetRentRoyaltyDetailsModel> GetRentRoyalty(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalProvider.GetRentRoyalty(objEU);
        }

        /// <summary>
        /// Add Royalty details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> AddRoyaltyDetails(GetFormF1DetailsModel objModel)
        {
            return await _objIeReturnNonCoalProvider.AddRoyaltyDetails(objModel);
        }

        /// <summary>
        /// Update Royalty details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> UpdateRoyaltyDetails(GetFormF1DetailsModel objModel)
        {
            return await _objIeReturnNonCoalProvider.UpdateRoyaltyDetails(objModel);
        }

        /// <summary>
        /// Get Mineral information
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>GetFormF1DetailsModel class</returns>
        [HttpPost]
        public async Task<GetFormF1DetailsModel> GetMineralInfo(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalProvider.GetMineralInfo(objEU);
        }

        /// <summary>
        /// Get production details
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>ProductionModel_Monthly class</returns>
        [HttpPost]
        public async Task<ProductionModel_Monthly> GetProduction(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalProvider.GetProduction(objEU);
        }

        /// <summary>
        /// Get details of deduction
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>Details_of_deductions_Monthly class</returns>
        [HttpPost]
        public async Task<Details_of_deductions_Monthly> GetDetails_of_deductions(GetFormF1DetailsModel objEU)
        {
            return await _objIeReturnNonCoalProvider.GetDetails_of_deductions(objEU);
        }

        /// <summary>
        /// Get Reason
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>Reason_Inc_Dec_Monthly class</returns>
        [HttpPost]
        public async Task<Reason_Inc_Dec_Monthly> GetReason_Inc_Dec(GetFormF1DetailsModel objEU)
        {
            return await _objIeReturnNonCoalProvider.GetReason_Inc_Dec(objEU);
        }

        /// <summary>
        /// Details of deductions monthly
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>Details_of_deductions_Monthly class</returns>
        [HttpPost]
        public async Task<Details_of_deductions_Monthly> Getpulverization(GetFormF1DetailsModel objEU)
        {
            return await _objIeReturnNonCoalProvider.Getpulverization(objEU);
        }

        /// <summary>
        /// Get Opening Stock
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>ProductionModel_Monthly class</returns>
        [HttpPost]
        public async Task<ProductionModel_Monthly> OpeningStock(GetFormF1DetailsModel objEU)
        {
            return await _objIeReturnNonCoalProvider.OpeningStock(objEU);
        }

        /// <summary>
        /// Get Mineral form
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>DDLResult class</returns>
        [HttpPost]
        public async Task<DDLResult> GetMineralForm(MonthlyReturnModelNonCoal objDP)
        {
            return await _objIeReturnNonCoalProvider.GetMineralForm(objDP);
        }

        /// <summary>
        /// Get Mineral Grade
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>DDLResult class</returns>
        [HttpPost]
        public async Task<DDLResult> GetMineralGrade(MonthlyReturnModelNonCoal objDP)
        {
            return await _objIeReturnNonCoalProvider.GetMineralGrade(objDP);
        }

        /// <summary>
        /// Add Grade wise ROM
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> ADDGradewise_ROM(Gradewise_ROMModel objDP)
        {
            return await _objIeReturnNonCoalProvider.ADDGradewise_ROM(objDP);
        }

        /// <summary>
        /// Get Grade wise ROM
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of Gradewise_ROMModel class</returns>
        [HttpPost]
        public async Task<List<Gradewise_ROMModel>> GetGradewise_ROM(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalProvider.GetGradewise_ROM(objEU);
        }

        /// <summary>
        /// Update Grade Wise ROM
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> UpdateGradewise_ROM(Gradewise_ROMModel objDP)
        {
            return await _objIeReturnNonCoalProvider.UpdateGradewise_ROM(objDP);
        }

        /// <summary>
        /// Delete Grade wise ROM
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> DeleteGradewise_ROM(Gradewise_ROMModel objDP)
        {
            return await _objIeReturnNonCoalProvider.DeleteGradewise_ROM(objDP);
        }

        /// <summary>
        /// Get Mineral form production
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>DDLResult class</returns>
        [HttpPost]
        public async Task<DDLResult> GetMineralFormProduction(MonthlyReturnModelNonCoal objDP)
        {
            return await _objIeReturnNonCoalProvider.GetMineralFormProduction(objDP);
        }

        /// <summary>
        /// Add Grade wise Production
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> ADDGradewise_Production(Grade_WiseProduction objDP)
        {
            return await _objIeReturnNonCoalProvider.ADDGradewise_Production(objDP);
        }

        /// <summary>
        /// Get Grade wise Production
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of Grade_WiseProduction</returns>
        [HttpPost]
        public async Task<List<Grade_WiseProduction>> GetGrade_WiseProduction(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalProvider.GetGrade_WiseProduction(objEU);
        }

        /// <summary>
        /// Update grade wise production
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> UpdateGradewise_Prod(Grade_WiseProduction objDP)
        {
            return await _objIeReturnNonCoalProvider.UpdateGradewise_Prod(objDP);
        }

        /// <summary>
        /// Delete Grade wise production
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> DeleteGradewise_Prod(Grade_WiseProduction objDP)
        {
            return await _objIeReturnNonCoalProvider.DeleteGradewise_Prod(objDP);
        }

        /// <summary>
        /// Get Nature of Dispatch
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of SalesDispatchModel</returns>
        [HttpPost]
        public async Task<List<SalesDispatchModel>> GetNatureOfDispatch(SalesDispatchModel objEU)
        {
            return await _objIeReturnNonCoalProvider.GetNatureOfDispatch(objEU);
        }

        /// <summary>
        /// Get purchaser Consignee
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of SalesDispatchModel</returns>
        [HttpPost]
        public async Task<List<SalesDispatchModel>> GetPurchaserConsignee(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalProvider.GetPurchaserConsignee(objEU);
        }

        /// <summary>
        /// Add Sale Dispatch
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> AddSaleDispatch(SalesDispatchModel objDP)
        {
            return await _objIeReturnNonCoalProvider.AddSaleDispatch(objDP);
        }

        /// <summary>
        /// Get Sale Dispatch
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of SalesDispatchModel class</returns>
        [HttpPost]
        public async Task<List<SalesDispatchModel>> GetSalesDespatch(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalProvider.GetSalesDespatch(objEU);
        }

        /// <summary>
        /// Update sale dispatch
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> UpdateSaleDispatch(SalesDispatchModel objDP)
        {
            return await _objIeReturnNonCoalProvider.UpdateSaleDispatch(objDP);
        }

        /// <summary>
        /// Delete Sale Dispatch
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF</returns>
        [HttpPost]
        public async Task<MessageEF> DeleteSaleDispatch(SalesDispatchModel objDP)
        {
            return await _objIeReturnNonCoalProvider.DeleteSaleDispatch(objDP);
        }

        /// <summary>
        /// Add Pulverization details
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> AddPulverization(Mineral_PulverizedModel objDP)
        {
            return await _objIeReturnNonCoalProvider.AddPulverization(objDP);
        }

        /// <summary>
        /// Get all mineral pulverization details
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of Mineral_PulverizedModel class</returns>
        [HttpPost]
        public async Task<List<Mineral_PulverizedModel>> GetMineral_Pulverized(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalProvider.GetMineral_Pulverized(objEU);
        }

        /// <summary>
        /// Update pulverization details
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> UpdateMineral_Pulverized(Mineral_PulverizedModel objDP)
        {
            return await _objIeReturnNonCoalProvider.UpdateMineral_Pulverized(objDP);
        }

        /// <summary>
        /// Delete Mineral Pulverization details
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> DeleteeMineral_Pulverized(Mineral_PulverizedModel objDP)
        {
            return await _objIeReturnNonCoalProvider.DeleteeMineral_Pulverized(objDP);
        }

        /// <summary>
        /// Add Reason
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> AddReasonForInDc(Reason_Inc_Dec_Monthly objDP)
        {
            return await _objIeReturnNonCoalProvider.AddReasonForInDc(objDP);
        }

        /// <summary>
        /// Add Deduction Made
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> AddDeductionMade(Details_of_deductions_Monthly objDP)
        {
            return await _objIeReturnNonCoalProvider.AddDeductionMade(objDP);
        }

        /// <summary>
        /// Update Reason
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> UpdateReasonForInDc(Reason_Inc_Dec_Monthly objDP)
        {
            return await _objIeReturnNonCoalProvider.UpdateReasonForInDc(objDP);
        }

        /// <summary>
        /// Update details of deduction
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> UpdateDetails_of_deductions(Details_of_deductions_Monthly objDP)
        {
            return await _objIeReturnNonCoalProvider.UpdateDetails_of_deductions(objDP);
        }

        /// <summary>
        /// Add Production Type Part2
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> AddTypeProductionPartTwo(ProductionModel_Monthly objDP)
        {
            return await _objIeReturnNonCoalProvider.AddTypeProductionPartTwo(objDP);
        }

        /// <summary>
        /// Update production Type Part2
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> UpdateTypeProductionPartTwo(ProductionModel_Monthly objDP)
        {
            return await _objIeReturnNonCoalProvider.UpdateTypeProductionPartTwo(objDP);
        }

        /// <summary>
        /// Update final SUbmit
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> Update_FinalSubmit(Reason_Inc_Dec_Monthly objDP)
        {
            return await _objIeReturnNonCoalProvider.Update_FinalSubmit(objDP);
        }

        /// <summary>
        /// Add Pulverization part2
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> Addpulverization1(Details_of_deductions_Monthly objDP)
        {
            return await _objIeReturnNonCoalProvider.Addpulverization1(objDP);
        }

        /// <summary>
        /// Update pulverization
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> Updatepulverization(Details_of_deductions_Monthly objDP)
        {
            return await _objIeReturnNonCoalProvider.Updatepulverization(objDP);
        }

        /// <summary>
        /// Get Form1 part1 for print details
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>GetFormF1DetailsModel class</returns>
        [HttpPost]
        public async Task<GetFormF1DetailsModel> GetFormF1Part1ForPrint(MonthlyReturnModelNonCoal objDP)
        {
            return await _objIeReturnNonCoalProvider.GetFormF1Part1ForPrint(objDP);
        }

        /// <summary>
        /// Get working mines details for print
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of Working_of_Mine</returns>
        [HttpPost]
        public async Task<List<Working_of_Mine>> GetMineWorkDetails(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalProvider.GetMineWorkDetails(objEU);
        }

        /// <summary>
        /// Update file path for print
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>Update_Filepath class</returns>
        [HttpPost]
        public async Task<MessageEF> Update_Filepath(MonthlyReturnModelNonCoal objDP)
        {
            return await _objIeReturnNonCoalProvider.Update_Filepath(objDP);
        }

    }
}
