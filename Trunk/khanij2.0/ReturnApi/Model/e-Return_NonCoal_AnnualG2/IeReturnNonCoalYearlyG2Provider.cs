using ReturnApi.Repository;
using ReturnEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnApi.Model.e_Return_NonCoal_AnnualG2
{
    public interface IeReturnNonCoalYearlyG2Provider : IDisposable, IRepository
    {
        Task<List<YearlyReturnModel>> GetYearlyReturnDetails(YearlyReturnModel yearlyReturnModel);

        #region Part One H2
        Task<MineDetailsModel> GetLesseMineDeatils(YearlyReturnModel yearlyReturnModel);
        Task<List<YearlyReturnModel>> GetAgencyOfMine(int? UserId);
        Task<MessageEF> UpdateMineOtherDetails(AnnualReturnH1ViewModel annualReturnH1ViewModel);
        Task<MessageEF> AddMineOtherDetails(AnnualReturnH1ViewModel annualReturnH1ViewModel);
        Task<MessageEF> UpdateParticularsofArea(ParticularsofArea particularsofArea);
        Task<MessageEF> AddParticularsofArea(ParticularsofArea objModel);
        Task<MessageEF> UpdateLeasearea(LeaseArea objModel);
        Task<MessageEF> AddLeasearea(LeaseArea objModel);
        Task<AnnualReturnH1ViewModel> GetMineOtherDetails(YearlyReturnModel yearlyReturnModel);
        Task<ParticularsofArea> GetParticularsofArea(YearlyReturnModel yearlyReturnModel);
        Task<LeaseArea> GetLeasearea(YearlyReturnModel yearlyReturnModel);
        #endregion

        #region Part Two H2 
        Task<StaffandWorkModel> GetStaffandWork(YearlyReturnModel yearlyReturnModel);
        Task<MessageEF> UpdateStaffandWork(StaffandWorkModel objModel);
        Task<MessageEF> AddStaffandWork(StaffandWorkModel objModel);

        Task<WorkModel> GetWorkDetails(YearlyReturnModel yearlyReturnModel);
        Task<MessageEF> UpdateWorkDetails(WorkModel objModel);
        Task<MessageEF> AddWorkDetails(WorkModel objModel);

        Task<SalaryWagesPaidModel> GetSalaryWagesPaid(YearlyReturnModel yearlyReturnModel);
        Task<MessageEF> UpdateSalaryWagesPaid(SalaryWagesPaidModel objModel);
        Task<MessageEF> AddSalaryWagesPaid(SalaryWagesPaidModel objModel);

        Task<CapitalStructure> GetCapitalStructure(YearlyReturnModel yearlyReturnModel);
        Task<MessageEF> UpdateCapitalStructure(CapitalStructure objModel);
        Task<MessageEF> AddCapitalStructure(CapitalStructure objModel);

        Task<SourceOfFinance> GetSourceOfFinance(YearlyReturnModel yearlyReturnModel);
        Task<MessageEF> UpdateSourceOfFinance(SourceOfFinance objModel);
        Task<MessageEF> AddSourceOfFinance(SourceOfFinance objModel);
        #endregion

        #region Part Three H2
        Task<MaterialConsumed> GetMaterialConsumed(YearlyReturnModel yearlyReturnModel);
        Task<MessageEF> UpdateMaterialConsumed(MaterialConsumed objModel);
        Task<MessageEF> AddMaterialConsumed(MaterialConsumed objModel);

        Task<RoyaltyandRents> GetRoyaltyandRent(YearlyReturnModel yearlyReturnModel);
        Task<MessageEF> UpdateRoyaltyandRent(RoyaltyandRents objModel);
        Task<MessageEF> AddRoyaltyandRent(RoyaltyandRents objModel);
        #endregion

        #region Part Four H2
        Task<AnnualReturnH1PartFourModel> GetExplosives(YearlyReturnModel yearlyReturnModel);
        Task<MessageEF> UpdateExplosives(AnnualReturnH1PartFourModel objModel);
        Task<MessageEF> AddExplosives(AnnualReturnH1PartFourModel objModel);
        Task<List<UnitType>> GetUnitTypeList(YearlyReturnModel yearlyReturnModel);
        #endregion

        #region Part Five H2
        Task<Exploration> GetExploration(YearlyReturnModel yearlyReturnModel);
        Task<MessageEF> UpdateExploration(Exploration objModel);
        Task<MessageEF> AddExploration(Exploration objModel);

        Task<MessageEF> UpdateResources(ReservesAndResources objModel);
        Task<MessageEF> AddResources(ReservesAndResources objModel);
        Task<ReservesAndResources> GetResources(YearlyReturnModel yearlyReturnModel);

        Task<MessageEF> UpdateRejectWaste(RejectWasteTreesPlanted objModel);
        Task<MessageEF> AddRejectWaste(RejectWasteTreesPlanted objModel);
        Task<RejectWasteTreesPlanted> GetRejectWasteTreesPlanted(YearlyReturnModel yearlyReturnModel);

        Task<MessageEF> UpdateFurnishDetails(FurnishDetails objModel);
        Task<MessageEF> AddFurnishDetails(FurnishDetails objModel);
        Task<FurnishDetails> GetFurnishDetails(YearlyReturnModel yearlyReturnModel);

        Task<MessageEF> AddMachineryDetails(MachineryDetails objModel);
        Task<MessageEF> UpdateMachineryDetails(MachineryDetails objModel);
        Task<MessageEF> DeleteMachineryDetails(MachineryDetails objModel);
        Task<List<MachineryDetails>> GetMachineryDetails(YearlyReturnModel yearlyReturnModel);
        Task<List<TypeOfMachinery>> GetTypeOfMachineryDetails(YearlyReturnModel yearlyReturnModel);
        #endregion

        #region Part Six H2
        Task<MineralInfo> GetMineralInfo(YearlyReturnModel yearlyReturnModel);

        Task<MessageEF> UpdateProductionandStocks(ProductionandStocksModel objModel);
        Task<MessageEF> AddProductionandStocks(ProductionandStocksModel objModel);
        Task<ProductionandStocksModel> GetProductionandStocks(YearlyReturnModel yearlyReturnModel);

        Task<MessageEF> UpdateDetails_of_deductions(Details_of_deductions objModel);
        Task<MessageEF> AddDetails_of_deductions(Details_of_deductions objModel);
        Task<Details_of_deductions> GetDetails_of_deductions(YearlyReturnModel yearlyReturnModel);

        Task<MessageEF> UpdateReasonForInDc(Reason_Inc_Dec objModel);
        Task<MessageEF> AddReasonForInDc(Reason_Inc_Dec objModel);
        Task<Reason_Inc_Dec> GetReason_Inc_Dec(YearlyReturnModel yearlyReturnModel);

        Task<MessageEF> AddRecoveries(RecoveriesModel objModel);
        Task<MessageEF> UpdateRecoveries(RecoveriesModel objModel);
        Task<MessageEF> DeleteRecoveries(RecoveriesModel objModel);
        Task<List<RecoveriesModel>> GetRecoveries(YearlyReturnModel yearlyReturnModel);

        Task<MessageEF> AddRecoveriesSmelter(Recovery_atSmelterModel objModel);
        Task<MessageEF> UpdateRecoveriesSmelter(Recovery_atSmelterModel objModel);
        Task<MessageEF> DeleteRecoveriesSmelter(Recovery_atSmelterModel objModel);
        Task<List<Recovery_atSmelterModel>> GetRecoveriesSmelter(YearlyReturnModel yearlyReturnModel);


        Task<MessageEF> AddSaleProduct(SaleProductModel objModel);
        Task<MessageEF> UpdateSaleProduct(SaleProductModel objModel);
        Task<MessageEF> DeleteSaleProduct(SaleProductModel objModel);
        Task<List<SaleProductModel>> GetSaleProduct(YearlyReturnModel yearlyReturnModel);
        Task<List<MineralGrade>> GetMineralGradeForTinMineral(YearlyReturnModel yearlyReturnModel);
        Task<OpeningStockandDispatch> Get_G2_ClosingStock(YearlyReturnModel yearlyReturnModel);
        Task<OpeningStockandDispatch> GetDispatch_Form2_Annual(YearlyReturnModel yearlyReturnModel);

        Task<MessageEF> AddSaleDispatch(SalesDispatchOf_OreModel objModel);
        Task<MessageEF> UpdateSaleDispatch(SalesDispatchOf_OreModel objModel);
        Task<MessageEF> DeleteSaleDispatch(SalesDispatchOf_OreModel objModel);
        Task<List<SalesDispatchOf_OreModel>> GetSaleDispatch(YearlyReturnModel yearlyReturnModel);
        Task<List<MineralInfo>> GetMineralForm(YearlyReturnModel yearlyReturnModel);
        Task<List<MineralGrade>> GetMineralGrade(YearlyReturnModel yearlyReturnModel);
        Task<List<MineralInfo>> GetNatureOfDispatch(YearlyReturnModel yearlyReturnModel);
        Task<List<MineralInfo>> GetPurchaserConsignee(YearlyReturnModel yearlyReturnModel);
        #endregion

        #region Part Seven H2
        Task<MessageEF> UpdateCostOfProduction(CostOfProduction_Annual objModel);
        Task<MessageEF> AddCostOfProduction(CostOfProduction_Annual objModel);
        Task<MessageEF> Update_FinalSubmit(CostOfProduction_Annual objModel);
        Task<CostOfProduction_Annual> GetCostOfProduction(YearlyReturnModel yearlyReturnModel);
        #endregion
    }
}
