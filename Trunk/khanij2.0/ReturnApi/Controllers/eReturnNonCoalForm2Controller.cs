// ***********************************************************************
//  Controller Name          : eReturnNonCoalForm2
//  Desciption               : Add Monthly Form Two F2 ruturn API
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
    public class eReturnNonCoalForm2Controller : ControllerBase
    {
        public IeReturnNonCoalForm2Provider _objIeReturnNonCoalForm2Provider;
        public eReturnNonCoalForm2Controller(IeReturnNonCoalForm2Provider objeReturnNonCoalForm2Provider)
        {
            _objIeReturnNonCoalForm2Provider = objeReturnNonCoalForm2Provider;
        }
        /// <summary>
        /// Get Lessee Mine Details
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>GetFormF1DetailsModel class</returns>
        [HttpPost]
        public async Task<GetFormF1DetailsModel> GetLesseMineDeatils(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalForm2Provider.GetLesseMineDeatils(objEU);
        }

        /// <summary>
        /// Get Return Submitted Details
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>GetFormF1DetailsModel class</returns>
        [HttpPost]
        public async Task<GetFormF1DetailsModel> GeteReturnSubmittedDetails(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalForm2Provider.GeteReturnSubmittedDetails(objEU);
        }

        /// <summary>
        /// Get Rent Royalty Details
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>GetRentRoyaltyDetailsModel class</returns>
        [HttpPost]
        public async Task<GetRentRoyaltyDetailsModel> GetRentRoyalty(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalForm2Provider.GetRentRoyalty(objEU);
        }

        /// <summary>
        /// Add Royalty Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> AddRoyaltyDetails(GetFormF1DetailsModel objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.AddRoyaltyDetails(objModel);
        }

        /// <summary>
        /// Update Royalty Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> UpdateRoyaltyDetails(GetFormF1DetailsModel objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.UpdateRoyaltyDetails(objModel);
        }

        /// <summary>
        /// Get Mineral Information
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>GetFormF1DetailsModel class</returns>
        [HttpPost]
        public async Task<GetFormF1DetailsModel> GetMineralInfo(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalForm2Provider.GetMineralInfo(objEU);
        }

        /// <summary>
        /// Add Recoveries Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> AddRecoveries(RecoveriesModel objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.AddRecoveries(objModel);
        }

        /// <summary>
        /// Get Recoveries details
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of RecoveriesModel class</returns>
        public async Task<List<RecoveriesModel>> GetRecoveries(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalForm2Provider.GetRecoveries(objEU);
        }

        /// <summary>
        /// Update Recoveries details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> UpdateRecoveries(RecoveriesModel objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.UpdateRecoveries(objModel);
        }

        /// <summary>
        /// Delete Recoveries
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> DeleteRecoveries(RecoveriesModel objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.DeleteRecoveries(objModel);
        }

        /// <summary>
        /// Add Recoveries Smellter
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> AddRecoveriesSmelter(Recovery_atSmelterModel objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.AddRecoveriesSmelter(objModel);
        }

        /// <summary>
        /// Get all Recoveries at smelter 
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of Recovery_atSmelterModel class</returns>
        [HttpPost]
        public async Task<List<Recovery_atSmelterModel>> GetRecoveriesSmelter(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalForm2Provider.GetRecoveriesSmelter(objEU);
        }

        /// <summary>
        /// Update Recoveries at smelter
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> UpdateRecoveriesSmelter(Recovery_atSmelterModel objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.UpdateRecoveriesSmelter(objModel);
        }

        /// <summary>
        /// Delete Recoveries at smelter
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> DeleteRecoveriesSmelter(Recovery_atSmelterModel objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.DeleteRecoveriesSmelter(objModel);
        }

        /// <summary>
        /// Get Mineral For Tin Mineral
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of Recovery_atSmelterModel class</returns>
        [HttpPost]
        public async Task<List<Recovery_atSmelterModel>> GetMineralGradeForTinMineral(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalForm2Provider.GetMineralGradeForTinMineral(objEU);
        }

        /// <summary>
        /// Add Sale product
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> AddSaleProduct(SaleProductModel objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.AddSaleProduct(objModel);
        }

        /// <summary>
        /// Get Sale Product
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of SaleProductModel details</returns>
        [HttpPost]
        public async Task<List<SaleProductModel>> GetSaleProduct(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalForm2Provider.GetSaleProduct(objEU);
        }

        /// <summary>
        /// Update Sale Product
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> UpdateSaleProduct(SaleProductModel objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.UpdateSaleProduct(objModel);
        }

        /// <summary>
        /// Delete sale Product
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> DeleteSaleProduct(SaleProductModel objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.DeleteSaleProduct(objModel);
        }

        /// <summary>
        /// Get Mineral Form Production
        /// </summary>
        /// <param name="ObjMR"></param>
        /// <returns>List of SalesDispatchOf_OreModel</returns>
        [HttpPost]
        public async Task<List<SalesDispatchOf_OreModel>> GetMineralFormProduction(MonthlyReturnModelNonCoal ObjMR)
        {
            return await _objIeReturnNonCoalForm2Provider.GetMineralFormProduction(ObjMR);
        }

        /// <summary>
        /// Get Nature of dispatch
        /// </summary>
        /// <param name="ObjMR"></param>
        /// <returns>List of SalesDispatchModel class</returns>
        [HttpPost]
        public async Task<List<SalesDispatchModel>> GetNatureOfDispatch(SalesDispatchModel ObjMR)
        {
            return await _objIeReturnNonCoalForm2Provider.GetNatureOfDispatch(ObjMR);
        }

        /// <summary>
        /// Get Purchaser consignee
        /// </summary>
        /// <param name="ObjMR"></param>
        /// <returns>List of SalesDispatchModel class</returns>
        [HttpPost]
        public async Task<List<SalesDispatchModel>> GetPurchaserConsignee(MonthlyReturnModelNonCoal ObjMR)
        {
            return await _objIeReturnNonCoalForm2Provider.GetPurchaserConsignee(ObjMR);
        }

        /// <summary>
        /// Add Sale Dispatch
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> AddSaleDispatch(SalesDispatchOf_OreModel objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.AddSaleDispatch(objModel);
        }

        /// <summary>
        /// Get all sale dispatch Details
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of SalesDispatchOf_OreModel</returns>
        [HttpPost]
        public async Task<List<SalesDispatchOf_OreModel>> GetSaleDispatch(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalForm2Provider.GetSaleDispatch(objEU);
        }

        /// <summary>
        /// Update sale dispatch
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> UpdateSaleDispatch(SalesDispatchOf_OreModel objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.UpdateSaleDispatch(objModel);
        }

        /// <summary>
        /// Delete Sale Dispatch
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> DeleteSaleDispatch(SalesDispatchOf_OreModel objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.DeleteSaleDispatch(objModel);
        }

        /// <summary>
        /// Add Reason
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> AddReasonForInDc(Reason_Inc_Dec_Monthly_FormF2 objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.AddReasonForInDc(objModel);
        }

        /// <summary>
        /// Get Production and stock details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>ProductionandStocksModel class</returns>
        [HttpPost]
        public async Task<ProductionandStocksModel> GetProductionandStocks(MonthlyReturnModelNonCoal objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.GetProductionandStocks(objModel);
        }

        /// <summary>
        /// Add production and stock details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> AddProductionandStocks(ProductionandStocksModel objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.AddProductionandStocks(objModel);
        }

        /// <summary>
        /// Add Details of deduction
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> AddDetails_of_deductions(Details_of_deductions_sale_computation objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.AddDetails_of_deductions(objModel);
        }

        /// <summary>
        /// Get Details of Deduction
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>Details_of_deductions_sale_computation class</returns>
        [HttpPost]
        public async Task<Details_of_deductions_sale_computation> GetDetails_of_deductions(MonthlyReturnModelNonCoal objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.GetDetails_of_deductions(objModel);
        }

        /// <summary>
        /// Get Reason
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>Reason_Inc_Dec_Monthly_FormF2 class</returns>
        [HttpPost]
        public async Task<Reason_Inc_Dec_Monthly_FormF2> GetReason_Inc_Dec(MonthlyReturnModelNonCoal objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.GetReason_Inc_Dec(objModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> UpdateProductionandStocks(ProductionandStocksModel objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.UpdateProductionandStocks(objModel);
        }

        /// <summary>
        /// Update Details of Deduction
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> UpdateDetails_of_deductions(Details_of_deductions_sale_computation objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.UpdateDetails_of_deductions(objModel);
        }

        /// <summary>
        /// Update reason
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> UpdateReasonForInDc(Reason_Inc_Dec_Monthly_FormF2 objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.UpdateReasonForInDc(objModel);
        }

        /// <summary>
        /// Update Final Submit
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> Update_FinalSubmit(Reason_Inc_Dec_Monthly_FormF2 objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.Update_FinalSubmit(objModel);
        }

        /// <summary>
        /// Get Form2 for print
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>LesseeFormF2Part1Model class</returns>
        [HttpPost]
        public async Task<LesseeFormF2Part1Model> GetFormF2ForPrint(MonthlyReturnModelNonCoal objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.GetFormF2ForPrint(objModel);
        }

        /// <summary>
        /// Get Mine Work Details for print
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>List of Working_of_Mine class</returns>
        [HttpPost]
        public async Task<List<Working_of_Mine>> GetMineWorkDetails(MonthlyReturnModelNonCoal objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.GetMineWorkDetails(objModel);
        }

        /// <summary>
        /// Get Recoveries Concentrator For Print
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns>List RecoveriesModel class</returns>
        [HttpPost]
        public async Task<List<RecoveriesModel>> GetRecoveries_ConcentratorForPrint(MonthlyReturnModelNonCoal objModel)
        {
            return await _objIeReturnNonCoalForm2Provider.GetRecoveries_ConcentratorForPrint(objModel);
        }

        /// <summary>
        /// Update File Path For Print
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> Update_Filepath(MonthlyReturnModelNonCoal objDP)
        {
            return await _objIeReturnNonCoalForm2Provider.Update_Filepath(objDP);
        }


    }
}
