using ReturnEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnApp.Areas.eReturn_NonCoal_Yearly.Models
{
    public interface IeReturnNonCoalYearlyG2Model
    {
        List<YearlyReturnModel> GetYearlyReturnDetails(YearlyReturnModel yearlyReturnModel);

        #region Part One H2
        MineDetailsModel GetLesseMineDeatils(YearlyReturnModel yearlyReturnModel);
        List<YearlyReturnModel> GetAgencyOfMine(int? UserId);
        MessageEF UpdateMineOtherDetails(AnnualReturnH1ViewModel annualReturnH1ViewModel);
        MessageEF AddMineOtherDetails(AnnualReturnH1ViewModel annualReturnH1ViewModel);
        MessageEF UpdateParticularsofArea(ParticularsofArea particularsofArea);
        MessageEF AddParticularsofArea(ParticularsofArea objModel);
        MessageEF UpdateLeasearea(LeaseArea objModel);
        MessageEF AddLeasearea(LeaseArea objModel);
        AnnualReturnH1ViewModel GetMineOtherDetails(YearlyReturnModel yearlyReturnModel);
        ParticularsofArea GetParticularsofArea(YearlyReturnModel yearlyReturnModel);
        LeaseArea GetLeasearea(YearlyReturnModel yearlyReturnModel);
        #endregion

        #region Part Two H2
        StaffandWorkModel GetStaffandWork(YearlyReturnModel yearlyReturnModel);
        MessageEF UpdateStaffandWork(StaffandWorkModel objModel);
        MessageEF AddStaffandWork(StaffandWorkModel objModel);

        WorkModel GetWorkDetails(YearlyReturnModel yearlyReturnModel);
        MessageEF UpdateWorkDetails(WorkModel objModel);
        MessageEF AddWorkDetails(WorkModel objModel);

        SalaryWagesPaidModel GetSalaryWagesPaid(YearlyReturnModel yearlyReturnModel);
        MessageEF UpdateSalaryWagesPaid(SalaryWagesPaidModel objModel);
        MessageEF AddSalaryWagesPaid(SalaryWagesPaidModel objModel);

        CapitalStructure GetCapitalStructure(YearlyReturnModel yearlyReturnModel);
        MessageEF UpdateCapitalStructure(CapitalStructure objModel);
        MessageEF AddCapitalStructure(CapitalStructure objModel);

        SourceOfFinance GetSourceOfFinance(YearlyReturnModel yearlyReturnModel);
        MessageEF UpdateSourceOfFinance(SourceOfFinance objModel);
        MessageEF AddSourceOfFinance(SourceOfFinance objModel);
        #endregion

        #region Part Three H2
        MaterialConsumed GetMaterialConsumed(YearlyReturnModel yearlyReturnModel);
        MessageEF UpdateMaterialConsumed(MaterialConsumed objModel);
        MessageEF AddMaterialConsumed(MaterialConsumed objModel);

        RoyaltyandRents GetRoyaltyandRent(YearlyReturnModel yearlyReturnModel);
        MessageEF UpdateRoyaltyandRent(RoyaltyandRents objModel);
        MessageEF AddRoyaltyandRent(RoyaltyandRents objModel);
        #endregion

        #region Part Four H2
        AnnualReturnH1PartFourModel GetExplosives(YearlyReturnModel yearlyReturnModel);
        MessageEF UpdateExplosives(AnnualReturnH1PartFourModel objModel);
        MessageEF AddExplosives(AnnualReturnH1PartFourModel objModel);
        List<UnitType> GetUnitTypeList(YearlyReturnModel yearlyReturnModel);
        #endregion

        #region Part Five H2
        Exploration GetExploration(YearlyReturnModel yearlyReturnModel);
        MessageEF UpdateExploration(Exploration objModel);
        MessageEF AddExploration(Exploration objModel);

        MessageEF UpdateResources(ReservesAndResources objModel);
        MessageEF AddResources(ReservesAndResources objModel);
        ReservesAndResources GetResources(YearlyReturnModel yearlyReturnModel);

        MessageEF UpdateRejectWaste(RejectWasteTreesPlanted objModel);
        MessageEF AddRejectWaste(RejectWasteTreesPlanted objModel);
        RejectWasteTreesPlanted GetRejectWasteTreesPlanted(YearlyReturnModel yearlyReturnModel);

        MessageEF UpdateFurnishDetails(FurnishDetails objModel);
        MessageEF AddFurnishDetails(FurnishDetails objModel);
        FurnishDetails GetFurnishDetails(YearlyReturnModel yearlyReturnModel);

        MessageEF AddMachineryDetails(MachineryDetails objModel);
        MessageEF UpdateMachineryDetails(MachineryDetails objModel);
        MessageEF DeleteMachineryDetails(MachineryDetails objModel);
        List<MachineryDetails> GetMachineryDetails(YearlyReturnModel yearlyReturnModel);
        List<TypeOfMachinery> GetTypeOfMachineryDetails(YearlyReturnModel yearlyReturnModel);
        #endregion

        #region Part Six H2
        MineralInfo GetMineralInfo(YearlyReturnModel yearlyReturnModel);

        MessageEF UpdateProductionandStocks(ProductionandStocksModel objModel);
        MessageEF AddProductionandStocks(ProductionandStocksModel objModel);
        ProductionandStocksModel GetProductionandStocks(YearlyReturnModel yearlyReturnModel);

        MessageEF UpdateDetails_of_deductions(Details_of_deductions objModel);
        MessageEF AddDetails_of_deductions(Details_of_deductions objModel);
        Details_of_deductions GetDetails_of_deductions(YearlyReturnModel yearlyReturnModel);

        MessageEF UpdateReasonForInDc(Reason_Inc_Dec objModel);
        MessageEF AddReasonForInDc(Reason_Inc_Dec objModel);
        Reason_Inc_Dec GetReason_Inc_Dec(YearlyReturnModel yearlyReturnModel);

        MessageEF AddRecoveries(RecoveriesModel objModel);
        MessageEF UpdateRecoveries(RecoveriesModel objModel);
        MessageEF DeleteRecoveries(RecoveriesModel objModel);
        List<RecoveriesModel> GetRecoveries(YearlyReturnModel yearlyReturnModel);

        MessageEF AddRecoveriesSmelter(Recovery_atSmelterModel objModel);
        MessageEF UpdateRecoveriesSmelter(Recovery_atSmelterModel objModel);
        MessageEF DeleteRecoveriesSmelter(Recovery_atSmelterModel objModel);
        List<Recovery_atSmelterModel> GetRecoveriesSmelter(YearlyReturnModel yearlyReturnModel);

        MessageEF AddSaleProduct(SaleProductModel objModel);
        MessageEF UpdateSaleProduct(SaleProductModel objModel);
        MessageEF DeleteSaleProduct(SaleProductModel objModel);
        List<SaleProductModel> GetSaleProduct(YearlyReturnModel yearlyReturnModel);
        List<MineralGrade> GetMineralGradeForTinMineral(YearlyReturnModel yearlyReturnModel);
        OpeningStockandDispatch Get_G2_ClosingStock(YearlyReturnModel yearlyReturnModel);
        OpeningStockandDispatch GetDispatch_Form2_Annual(YearlyReturnModel yearlyReturnModel);

        MessageEF AddSaleDispatch(SalesDispatchOf_OreModel objModel);
        MessageEF UpdateSaleDispatch(SalesDispatchOf_OreModel objModel);
        MessageEF DeleteSaleDispatch(SalesDispatchOf_OreModel objModel);
        List<SalesDispatchOf_OreModel> GetSaleDispatch(YearlyReturnModel yearlyReturnModel);
        List<MineralInfo> GetMineralForm(YearlyReturnModel yearlyReturnModel);
        List<MineralGrade> GetMineralGrade(YearlyReturnModel yearlyReturnModel);
        List<MineralInfo> GetNatureOfDispatch(YearlyReturnModel yearlyReturnModel);
        List<MineralInfo> GetPurchaserConsignee(YearlyReturnModel yearlyReturnModel);
        #endregion

        #region Part Seven H2
        MessageEF UpdateCostOfProduction(CostOfProduction_Annual objModel);
        MessageEF AddCostOfProduction(CostOfProduction_Annual objModel);
        MessageEF Update_FinalSubmit(CostOfProduction_Annual objModel);
        CostOfProduction_Annual GetCostOfProduction(YearlyReturnModel yearlyReturnModel);
        #endregion
    }
}
