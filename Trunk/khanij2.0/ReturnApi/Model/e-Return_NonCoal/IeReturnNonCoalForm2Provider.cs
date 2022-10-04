using Microsoft.AspNetCore.Mvc;
using ReturnApi.Repository;
using ReturnEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnApi.Model.e_Return_NonCoal
{
    public interface IeReturnNonCoalForm2Provider : IDisposable, IRepository
    {
        Task<GetFormF1DetailsModel> GetLesseMineDeatils(MonthlyReturnModelNonCoal model);
        Task<GetFormF1DetailsModel> GeteReturnSubmittedDetails(MonthlyReturnModelNonCoal model);
        Task<GetRentRoyaltyDetailsModel> GetRentRoyalty(MonthlyReturnModelNonCoal model);
        Task<MessageEF> AddRoyaltyDetails(GetFormF1DetailsModel objModel);
        Task<MessageEF> UpdateRoyaltyDetails(GetFormF1DetailsModel objModel);
        Task<GetFormF1DetailsModel> GetMineralInfo(MonthlyReturnModelNonCoal model);
        Task<MessageEF> AddRecoveries(RecoveriesModel objModel);
        Task<List<RecoveriesModel>> GetRecoveries(MonthlyReturnModelNonCoal model);
        Task<MessageEF> UpdateRecoveries(RecoveriesModel objModel);
        Task<MessageEF> DeleteRecoveries(RecoveriesModel objModel);
        Task<MessageEF> AddRecoveriesSmelter(Recovery_atSmelterModel objModel);
        Task<List<Recovery_atSmelterModel>> GetRecoveriesSmelter(MonthlyReturnModelNonCoal model);
        Task<MessageEF> UpdateRecoveriesSmelter(Recovery_atSmelterModel objModel);
        Task<MessageEF> DeleteRecoveriesSmelter(Recovery_atSmelterModel objModel);
        Task<List<Recovery_atSmelterModel>> GetMineralGradeForTinMineral(MonthlyReturnModelNonCoal model);
        Task<MessageEF> AddSaleProduct(SaleProductModel objModel);
        Task<List<SaleProductModel>> GetSaleProduct(MonthlyReturnModelNonCoal model);
        Task<MessageEF> UpdateSaleProduct(SaleProductModel objModel);
        Task<MessageEF> DeleteSaleProduct(SaleProductModel objModel);
        Task<List<SalesDispatchOf_OreModel>> GetMineralFormProduction(MonthlyReturnModelNonCoal ObjMR);
        Task<List<SalesDispatchModel>> GetNatureOfDispatch(SalesDispatchModel ObjMR);
        Task<List<SalesDispatchModel>> GetPurchaserConsignee(MonthlyReturnModelNonCoal ObjMR);
        Task<MessageEF> AddSaleDispatch(SalesDispatchOf_OreModel objModel);
        Task<List<SalesDispatchOf_OreModel>> GetSaleDispatch(MonthlyReturnModelNonCoal model);
        Task<MessageEF> UpdateSaleDispatch(SalesDispatchOf_OreModel objModel);
        Task<MessageEF> DeleteSaleDispatch(SalesDispatchOf_OreModel objModel);
        Task<MessageEF> AddReasonForInDc(Reason_Inc_Dec_Monthly_FormF2 objModel);
        Task<ProductionandStocksModel> GetProductionandStocks(MonthlyReturnModelNonCoal model);
        Task<MessageEF> AddProductionandStocks(ProductionandStocksModel objModel);
        Task<MessageEF> AddDetails_of_deductions(Details_of_deductions_sale_computation objModel);
        Task<Details_of_deductions_sale_computation> GetDetails_of_deductions(MonthlyReturnModelNonCoal model);
        Task<Reason_Inc_Dec_Monthly_FormF2> GetReason_Inc_Dec(MonthlyReturnModelNonCoal model);
        Task<MessageEF> UpdateProductionandStocks(ProductionandStocksModel objModel);
        Task<MessageEF> UpdateDetails_of_deductions(Details_of_deductions_sale_computation objModel);
        Task<MessageEF> UpdateReasonForInDc(Reason_Inc_Dec_Monthly_FormF2 objModel);
        Task<MessageEF> Update_FinalSubmit(Reason_Inc_Dec_Monthly_FormF2 objModel);

        Task<LesseeFormF2Part1Model> GetFormF2ForPrint(MonthlyReturnModelNonCoal model);
        Task<List<Working_of_Mine>> GetMineWorkDetails(MonthlyReturnModelNonCoal model);
        Task<List<RecoveriesModel>> GetRecoveries_ConcentratorForPrint(MonthlyReturnModelNonCoal model);
        Task<MessageEF> Update_Filepath(MonthlyReturnModelNonCoal objModel);
    }
}
