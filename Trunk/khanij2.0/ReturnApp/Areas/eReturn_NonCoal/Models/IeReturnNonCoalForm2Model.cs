using ReturnEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnApp.Areas.eReturn_NonCoal.Models
{
   public interface IeReturnNonCoalForm2Model
    {
        GetFormF1DetailsModel GetLesseMineDeatils(MonthlyReturnModelNonCoal model);
        GetFormF1DetailsModel GeteReturnSubmittedDetails(MonthlyReturnModelNonCoal model);
        GetRentRoyaltyDetailsModel GetRentRoyalty(MonthlyReturnModelNonCoal model);
        MessageEF AddRoyaltyDetails(GetFormF1DetailsModel objModel);
        MessageEF UpdateRoyaltyDetails(GetFormF1DetailsModel objModel);
        GetFormF1DetailsModel GetMineralInfo(MonthlyReturnModelNonCoal model);
        MessageEF AddRecoveries(RecoveriesModel objModel);
        List<RecoveriesModel> GetRecoveries(MonthlyReturnModelNonCoal model);
        MessageEF UpdateRecoveries(RecoveriesModel objModel);
        MessageEF DeleteRecoveries(RecoveriesModel objModel);
        MessageEF AddRecoveriesSmelter(Recovery_atSmelterModel objModel);
        List<Recovery_atSmelterModel> GetRecoveriesSmelter(MonthlyReturnModelNonCoal model);
        MessageEF UpdateRecoveriesSmelter(Recovery_atSmelterModel objModel);
        MessageEF DeleteRecoveriesSmelter(Recovery_atSmelterModel objModel);
        List<Recovery_atSmelterModel> GetMineralGradeForTinMineral(MonthlyReturnModelNonCoal model);
        MessageEF AddSaleProduct(SaleProductModel objModel);
        List<SaleProductModel> GetSaleProduct(MonthlyReturnModelNonCoal model);
        MessageEF UpdateSaleProduct(SaleProductModel objModel);
        MessageEF DeleteSaleProduct(SaleProductModel objModel);
        List<SalesDispatchOf_OreModel> GetMineralFormProduction(MonthlyReturnModelNonCoal ObjMR);
        List<SalesDispatchModel> GetNatureOfDispatch(SalesDispatchModel ObjMR);
        List<SalesDispatchModel> GetPurchaserConsignee(MonthlyReturnModelNonCoal ObjMR);
        MessageEF AddSaleDispatch(SalesDispatchOf_OreModel objModel);
        List<SalesDispatchOf_OreModel> GetSaleDispatch(MonthlyReturnModelNonCoal model);
        MessageEF UpdateSaleDispatch(SalesDispatchOf_OreModel objModel);
        MessageEF DeleteSaleDispatch(SalesDispatchOf_OreModel objModel);
        MessageEF AddReasonForInDc(Reason_Inc_Dec_Monthly_FormF2 objModel);
        ProductionandStocksModel GetProductionandStocks(MonthlyReturnModelNonCoal objModel);
        MessageEF AddProductionandStocks(ProductionandStocksModel objModel);
        MessageEF AddDetails_of_deductions(Details_of_deductions_sale_computation objModel);
        Details_of_deductions_sale_computation GetDetails_of_deductions(MonthlyReturnModelNonCoal objModel);
        Reason_Inc_Dec_Monthly_FormF2 GetReason_Inc_Dec(MonthlyReturnModelNonCoal objModel);
        MessageEF UpdateProductionandStocks(ProductionandStocksModel objModel);
        MessageEF UpdateDetails_of_deductions(Details_of_deductions_sale_computation objModel);
        MessageEF UpdateReasonForInDc(Reason_Inc_Dec_Monthly_FormF2 objModel);
        MessageEF Update_FinalSubmit(Reason_Inc_Dec_Monthly_FormF2 objModel);
        LesseeFormF2Part1Model GetFormF2ForPrint(MonthlyReturnModelNonCoal objModel);
        List<Working_of_Mine> GetMineWorkDetails(MonthlyReturnModelNonCoal objModel);
        List<RecoveriesModel> GetRecoveries_ConcentratorForPrint(MonthlyReturnModelNonCoal objModel);
        MessageEF Update_Filepath(MonthlyReturnModelNonCoal objModel);
    }
}
