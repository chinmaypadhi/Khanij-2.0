// ***********************************************************************
//  Controller Name          : ReturnYearlyNonCoal G2
//  Desciption               : To be used for minerals Copper, Gold, Lead, Pyrites, Tin, Tungsten and Zinc
//  Created By               : Akshaya Dalei
//  Created On               : 28 July 2021
// ***********************************************************************

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReturnApi.Model.e_Return_NonCoal_AnnualG2;
using ReturnEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class eReturnYearlyNonCoalG2Controller : ControllerBase
    {
        private readonly IeReturnNonCoalYearlyG2Provider yearlyNonCoalReturnProvider;

        public eReturnYearlyNonCoalG2Controller(IeReturnNonCoalYearlyG2Provider yearlyNonCoalReturnProvider)
        {
            this.yearlyNonCoalReturnProvider = yearlyNonCoalReturnProvider;
        }

        #region Yearly Return Non Coal Details
        /// <summary>
        /// To Bind Yearly Return Non Coal Details
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<YearlyReturnModel>> GetYearlyReturnDetails(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetYearlyReturnDetails(yearlyReturnModel);
        }
        #endregion

        #region Part One H2

        #region Lessee Mine Details
        /// <summary>
        /// Lessee Mine Details
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MineDetailsModel> GetLesseMineDeatils(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetLesseMineDeatils(yearlyReturnModel);
        }
        #endregion

        #region Agency Of Mine
        /// <summary>
        /// To Bind Agency Of Mine Details
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<YearlyReturnModel>> GetAgencyOfMine(int? UserId)
        {
            return await yearlyNonCoalReturnProvider.GetAgencyOfMine(UserId);
        }
        #endregion

        #region Mine Other Details
        #region Get Mine Other Details
        /// <summary>
        /// To Get Mine Other Details
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<AnnualReturnH1ViewModel> GetMineOtherDetails(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetMineOtherDetails(yearlyReturnModel);
        }
        #endregion

        #region Update Mine Other Details
        /// <summary>
        /// To Update Mine Other Details
        /// </summary>
        /// <param name="annualReturnH1ViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateMineOtherDetails(AnnualReturnH1ViewModel annualReturnH1ViewModel)
        {
            return await yearlyNonCoalReturnProvider.UpdateMineOtherDetails(annualReturnH1ViewModel);
        }
        #endregion

        #region Add Mine Other Details
        /// <summary>
        /// To Add Mine Other Details
        /// </summary>
        /// <param name="annualReturnH1ViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddMineOtherDetails(AnnualReturnH1ViewModel annualReturnH1ViewModel)
        {
            return await yearlyNonCoalReturnProvider.AddMineOtherDetails(annualReturnH1ViewModel);
        }
        #endregion
        #endregion

        #region Particulars Of Area
        #region Get Particulars Of Area
        /// <summary>
        /// To Get Particulars Of Area
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ParticularsofArea> GetParticularsofArea(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetParticularsofArea(yearlyReturnModel);
        }
        #endregion

        #region Update Particulars Of Area
        /// <summary>
        /// To Update Particulars Of Area
        /// </summary>
        /// <param name="particularsofArea"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateParticularsofArea(ParticularsofArea particularsofArea)
        {
            return await yearlyNonCoalReturnProvider.UpdateParticularsofArea(particularsofArea);
        }
        #endregion

        #region Add Particulars Of Area
        /// <summary>
        /// To Add Particulars Of Area
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddParticularsofArea(ParticularsofArea objModel)
        {
            return await yearlyNonCoalReturnProvider.AddParticularsofArea(objModel);
        }
        #endregion
        #endregion

        #region Lease Area
        #region Get Lease Area
        /// <summary>
        /// To Get Lease Area
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<LeaseArea> GetLeasearea(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetLeasearea(yearlyReturnModel);
        }
        #endregion

        #region Update Lease Area
        /// <summary>
        /// To Update Lease Area
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateLeasearea(LeaseArea objModel)
        {
            return await yearlyNonCoalReturnProvider.UpdateLeasearea(objModel);
        }
        #endregion

        #region Add Lease Area
        /// <summary>
        /// To Add Lease Area
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddLeasearea(LeaseArea objModel)
        {
            return await yearlyNonCoalReturnProvider.AddLeasearea(objModel);
        }
        #endregion
        #endregion

        #endregion

        #region Part Two H2
        #region Staff Details
        #region Get Staff Details
        /// <summary>
        /// To Get Staff and Work Details
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<StaffandWorkModel> GetStaffandWork(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetStaffandWork(yearlyReturnModel);
        }
        #endregion

        #region Update Staff Details
        /// <summary>
        /// To Update Staff Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateStaffandWork(StaffandWorkModel objModel)
        {
            return await yearlyNonCoalReturnProvider.UpdateStaffandWork(objModel);
        }
        #endregion

        #region Add Staff Details
        /// <summary>
        /// To Add Staff Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddStaffandWork(StaffandWorkModel objModel)
        {
            return await yearlyNonCoalReturnProvider.AddStaffandWork(objModel);
        }
        #endregion
        #endregion

        #region Work Details
        #region Get Work Details
        /// <summary>
        /// To Get Work Details
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<WorkModel> GetWorkDetails(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetWorkDetails(yearlyReturnModel);
        }
        #endregion

        #region Update Work Details
        /// <summary>
        /// To Update Work Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateWorkDetails(WorkModel objModel)
        {
            return await yearlyNonCoalReturnProvider.UpdateWorkDetails(objModel);
        }
        #endregion

        #region Add Work Details
        /// <summary>
        /// To Add Work Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddWorkDetails(WorkModel objModel)
        {
            return await yearlyNonCoalReturnProvider.AddWorkDetails(objModel);
        }
        #endregion
        #endregion

        #region Salary/Wages Paid
        #region Get Salary/Wages
        /// <summary>
        /// To Get Salary/Wages
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<SalaryWagesPaidModel> GetSalaryWagesPaid(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetSalaryWagesPaid(yearlyReturnModel);
        }
        #endregion

        #region Update SalaryWages
        /// <summary>
        /// To Update SalaryWages
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateSalaryWagesPaid(SalaryWagesPaidModel objModel)
        {
            return await yearlyNonCoalReturnProvider.UpdateSalaryWagesPaid(objModel);
        }
        #endregion

        #region Add SalaryWages
        /// <summary>
        /// To Add SalaryWages
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddSalaryWagesPaid(SalaryWagesPaidModel objModel)
        {
            return await yearlyNonCoalReturnProvider.AddSalaryWagesPaid(objModel);
        }
        #endregion

        #endregion

        #region Part II-A(Capital Structure)
        #region Get Capital Structure
        /// <summary>
        /// To Get Capital Structure
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<CapitalStructure> GetCapitalStructure(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetCapitalStructure(yearlyReturnModel);
        }
        #endregion

        #region Update Capital Structure
        /// <summary>
        /// To Update Capital Structure
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateCapitalStructure(CapitalStructure objModel)
        {
            return await yearlyNonCoalReturnProvider.UpdateCapitalStructure(objModel);
        }
        #endregion

        #region Add Capital Structure
        /// <summary>
        /// To Add Capital Structure
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddCapitalStructure(CapitalStructure objModel)
        {
            return await yearlyNonCoalReturnProvider.AddCapitalStructure(objModel);
        }
        #endregion
        #endregion

        #region Part-II A(Source Of Finance/Interest and Rent)
        #region Get Source Of Finance/Interest and Rent
        /// <summary>
        /// To Get Source Of Finance/Interest and Rent
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<SourceOfFinance> GetSourceOfFinance(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetSourceOfFinance(yearlyReturnModel);
        }
        #endregion

        #region Update Source Of Finance/Interest and Rent
        /// <summary>
        /// To Update Source Of Finance/Interest and Rent
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateSourceOfFinance(SourceOfFinance objModel)
        {
            return await yearlyNonCoalReturnProvider.UpdateSourceOfFinance(objModel);
        }
        #endregion

        #region Add Source Of Finance/Interest and Rent
        /// <summary>
        /// To Add Source Of Finance/Interest and Rent
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddSourceOfFinance(SourceOfFinance objModel)
        {
            return await yearlyNonCoalReturnProvider.AddSourceOfFinance(objModel);
        }
        #endregion
        #endregion
        #endregion

        #region Part Three H2
        #region Quantity and Cost of Material Consumed
        #region Get Material Consumed
        /// <summary>
        /// To Get Material Consumed
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MaterialConsumed> GetMaterialConsumed(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetMaterialConsumed(yearlyReturnModel);
        }
        #endregion

        #region Update Material Consumed
        /// <summary>
        /// To Update Material Consumed
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateMaterialConsumed(MaterialConsumed objModel)
        {
            return await yearlyNonCoalReturnProvider.UpdateMaterialConsumed(objModel);
        }
        #endregion

        #region Add Material Consumed
        /// <summary>
        /// To Add Material Consumed
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddMaterialConsumed(MaterialConsumed objModel)
        {
            return await yearlyNonCoalReturnProvider.AddMaterialConsumed(objModel);
        }
        #endregion
        #endregion

        #region Royalty,Rents and Payments
        #region Get Royalty and Rents
        /// <summary>
        /// To Get Royalty and Rent
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<RoyaltyandRents> GetRoyaltyandRent(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetRoyaltyandRent(yearlyReturnModel);
        }
        #endregion

        #region Update Royalty and Rent
        /// <summary>
        /// To Update Royalty and Rent
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateRoyaltyandRent(RoyaltyandRents objModel)
        {
            return await yearlyNonCoalReturnProvider.UpdateRoyaltyandRent(objModel);
        }
        #endregion

        #region Add Royalty and Rent
        /// <summary>
        /// To Add Royalty and Rent
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddRoyaltyandRent(RoyaltyandRents objModel)
        {
            return await yearlyNonCoalReturnProvider.AddRoyaltyandRent(objModel);
        }
        #endregion

        #endregion

        #endregion

        #region Part Four H2
        #region Update Consumption Of Explosives
        /// <summary>
        /// To Update Consumption Of Explosives
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateExplosives(AnnualReturnH1PartFourModel objModel)
        {
            return await yearlyNonCoalReturnProvider.UpdateExplosives(objModel);
        }
        #endregion

        #region Add Consumption Of Explosives
        /// <summary>
        /// To Add Consumption Of Explosives
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddExplosives(AnnualReturnH1PartFourModel objModel)
        {
            return await yearlyNonCoalReturnProvider.AddExplosives(objModel);
        }
        #endregion

        #region Get Consumption Of Explosives
        /// <summary>
        /// To Get Consumption Of Explosives
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<AnnualReturnH1PartFourModel> GetExplosives(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetExplosives(yearlyReturnModel);
        }
        #endregion

        #region Unit
        /// <summary>
        /// To Bind Unit
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<UnitType>> GetUnitTypeList(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetUnitTypeList(yearlyReturnModel);
        }
        #endregion
        #endregion

        #region Part Five H2
        #region Exploration
        #region Update Exploration
        /// <summary>
        /// To Update Exploration
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateExploration(Exploration objModel)
        {
            return await yearlyNonCoalReturnProvider.UpdateExploration(objModel);
        }
        #endregion

        #region Add Exploration
        /// <summary>
        /// To Add Exploration
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddExploration(Exploration objModel)
        {
            return await yearlyNonCoalReturnProvider.AddExploration(objModel);
        }
        #endregion

        #region Get Exploration
        /// <summary>
        /// To Get Exploration
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Exploration> GetExploration(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetExploration(yearlyReturnModel);
        }
        #endregion
        #endregion

        #region Reserves and Resources estimated
        #region Update Reserves and Resources
        /// <summary>
        /// To Update Reserves and Resources
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateResources(ReservesAndResources objModel)
        {
            return await yearlyNonCoalReturnProvider.UpdateResources(objModel);
        }
        #endregion

        #region Add Reserves and Resources
        /// <summary>
        /// To Add Reserves and Resources
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddResources(ReservesAndResources objModel)
        {
            return await yearlyNonCoalReturnProvider.AddResources(objModel);
        }
        #endregion

        #region Get Reserves and Resources
        /// <summary>
        /// To Get Reserves and Resources
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ReservesAndResources> GetResources(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetResources(yearlyReturnModel);
        }
        #endregion
        #endregion

        #region Reject,Waste,Trees Planted/survival
        #region Update Reject Waste
        /// <summary>
        /// To Update Reject Waste
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateRejectWaste(RejectWasteTreesPlanted objModel)
        {
            return await yearlyNonCoalReturnProvider.UpdateRejectWaste(objModel);
        }
        #endregion

        #region Add Reject Waste
        /// <summary>
        /// To Add Reject Waste
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddRejectWaste(RejectWasteTreesPlanted objModel)
        {
            return await yearlyNonCoalReturnProvider.AddRejectWaste(objModel);
        }
        #endregion

        #region Get Reject Waste
        /// <summary>
        /// To Get Reject Waste
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<RejectWasteTreesPlanted> GetRejectWasteTreesPlanted(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetRejectWasteTreesPlanted(yearlyReturnModel);
        }
        #endregion
        #endregion

        #region Details Of Mineral Treatment Plant
        #region Update Details Of Mineral
        /// <summary>
        /// To Update Details Of Mineral
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateFurnishDetails(FurnishDetails objModel)
        {
            return await yearlyNonCoalReturnProvider.UpdateFurnishDetails(objModel);
        }
        #endregion

        #region Add Details Of Mineral
        /// <summary>
        /// To Add Details Of Mineral
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddFurnishDetails(FurnishDetails objModel)
        {
            return await yearlyNonCoalReturnProvider.AddFurnishDetails(objModel);
        }
        #endregion

        #region Get Details Of Mineral
        /// <summary>
        /// To Get Details Of Mineral
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<FurnishDetails> GetFurnishDetails(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetFurnishDetails(yearlyReturnModel);
        }
        #endregion
        #endregion

        #region Type Of Machinery
        #region Add Machinery
        /// <summary>
        /// To Add Machinery
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddMachineryDetails(MachineryDetails objModel)
        {
            return await yearlyNonCoalReturnProvider.AddMachineryDetails(objModel);
        }
        #endregion

        #region Update Machinery
        /// <summary>
        /// To Update Machinery
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateMachineryDetails(MachineryDetails objModel)
        {
            return await yearlyNonCoalReturnProvider.UpdateMachineryDetails(objModel);
        }
        #endregion

        #region Delete Machinery
        /// <summary>
        /// To Delete Machinery
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> DeleteMachineryDetails(MachineryDetails objModel)
        {
            return await yearlyNonCoalReturnProvider.DeleteMachineryDetails(objModel);
        }
        #endregion

        #region Machinery Details
        /// <summary>
        /// To Get Machinery Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<MachineryDetails>> GetMachineryDetails(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetMachineryDetails(yearlyReturnModel);
        }
        #endregion

        #region Type Of Machinery
        /// <summary>
        /// To Get Type Of Machinery Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<TypeOfMachinery>> GetTypeOfMachineryDetails(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetTypeOfMachineryDetails(yearlyReturnModel);
        }
        #endregion
        #endregion
        #endregion

        #region Part Six H2
        #region Mineral Info
        /// <summary>
        /// To Get Mineral Info
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MineralInfo> GetMineralInfo(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetMineralInfo(yearlyReturnModel);
        }
        #endregion

        #region Production and Stocks
        #region Update Production and Stocks
        /// <summary>
        /// To Update Production and Stocks
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateProductionandStocks(ProductionandStocksModel objModel)
        {
            return await yearlyNonCoalReturnProvider.UpdateProductionandStocks(objModel);
        }
        #endregion

        #region Add Production and Stocks
        /// <summary>
        /// To Add Production and Stocks
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddProductionandStocks(ProductionandStocksModel objModel)
        {
            return await yearlyNonCoalReturnProvider.AddProductionandStocks(objModel);
        }
        #endregion

        #region Get Production and Stocks
        /// <summary>
        /// To Get Production and Stocks
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ProductionandStocksModel> GetProductionandStocks(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetProductionandStocks(yearlyReturnModel);
        }
        #endregion
        #endregion

        #region Details of Deduction
        #region Update Details of Deduction
        /// <summary>
        /// To Update Details of Deduction
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateDetails_of_deductions(Details_of_deductions objModel)
        {
            return await yearlyNonCoalReturnProvider.UpdateDetails_of_deductions(objModel);
        }
        #endregion

        #region Add Details of Deduction
        /// <summary>
        /// To Add Details of Deduction
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddDetails_of_deductions(Details_of_deductions objModel)
        {
            return await yearlyNonCoalReturnProvider.AddDetails_of_deductions(objModel);
        }
        #endregion

        #region Get Details of Deduction
        /// <summary>
        /// To Get Details of Deduction
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Details_of_deductions> GetDetails_of_deductions(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetDetails_of_deductions(yearlyReturnModel);
        }
        #endregion
        #endregion

        #region Reason for Increase/Decrease
        #region Update Reason for Increase/Decrease
        /// <summary>
        /// To Update Reason for Increase/Decrease
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateReasonForInDc(Reason_Inc_Dec objModel)
        {
            return await yearlyNonCoalReturnProvider.UpdateReasonForInDc(objModel);
        }
        #endregion

        #region Add Reason for Increase/Decrease
        /// <summary>
        /// To Add Reason for Increase/Decrease
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddReasonForInDc(Reason_Inc_Dec objModel)
        {
            return await yearlyNonCoalReturnProvider.AddReasonForInDc(objModel);
        }
        #endregion

        #region Get Reason for Increase/Decrease
        /// <summary>
        /// To Get Reason for Increase/Decrease
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Reason_Inc_Dec> GetReason_Inc_Dec(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetReason_Inc_Dec(yearlyReturnModel);
        }
        #endregion

        #endregion

        #region Recoveries at Concentrator Mill/Plant
        #region Add Recoveries
        /// <summary>
        /// To Add Recoveries
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddRecoveries(RecoveriesModel objModel)
        {
            return await yearlyNonCoalReturnProvider.AddRecoveries(objModel);
        }
        #endregion

        #region Update Recoveries
        /// <summary>
        /// To Update Recoveries
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateRecoveries(RecoveriesModel objModel)
        {
            return await yearlyNonCoalReturnProvider.UpdateRecoveries(objModel);
        }
        #endregion

        #region Delete Recoveries
        /// <summary>
        /// To Delete Recoveries
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> DeleteRecoveries(RecoveriesModel objModel)
        {
            return await yearlyNonCoalReturnProvider.DeleteRecoveries(objModel);
        }
        #endregion

        #region Get Recoveries
        /// <summary>
        /// To Get Recoveries
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<RecoveriesModel>> GetRecoveries(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetRecoveries(yearlyReturnModel);
        }
        #endregion
        #endregion

        #region Recovery at the Smelter/Mill/Plant
        #region Add Recovery at the Smelter
        /// <summary>
        /// To Add Recovery at the Smelter
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddRecoveriesSmelter(Recovery_atSmelterModel objModel)
        {
            return await yearlyNonCoalReturnProvider.AddRecoveriesSmelter(objModel);
        }
        #endregion

        #region Update Recovery at the Smelter
        /// <summary>
        /// To Update Recovery at the Smelter
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateRecoveriesSmelter(Recovery_atSmelterModel objModel)
        {
            return await yearlyNonCoalReturnProvider.UpdateRecoveriesSmelter(objModel);
        }
        #endregion

        #region Delete Recovery at the Smelter
        /// <summary>
        /// To Delete Recovery at the Smelter
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> DeleteRecoveriesSmelter(Recovery_atSmelterModel objModel)
        {
            return await yearlyNonCoalReturnProvider.DeleteRecoveriesSmelter(objModel);
        }
        #endregion

        #region Get Recovery at the Smelter
        /// <summary>
        /// To Delete Recovery at the Smelter
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<Recovery_atSmelterModel>> GetRecoveriesSmelter(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetRecoveriesSmelter(yearlyReturnModel);
        }
        #endregion
        #endregion

        #region Sales During the month
        #region Add Sales During the month
        /// <summary>
        /// To Add Sales During the month
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddSaleProduct(SaleProductModel objModel)
        {
            return await yearlyNonCoalReturnProvider.AddSaleProduct(objModel);
        }
        #endregion

        #region Update Sales During the month
        /// <summary>
        /// To Update Sales During the month
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateSaleProduct(SaleProductModel objModel)
        {
            return await yearlyNonCoalReturnProvider.UpdateSaleProduct(objModel);
        }
        #endregion

        #region Delete Sales During the month
        /// <summary>
        /// To Delete Sales During the month
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> DeleteSaleProduct(SaleProductModel objModel)
        {
            return await yearlyNonCoalReturnProvider.DeleteSaleProduct(objModel);
        }
        #endregion

        #region Get Sales During the month
        /// <summary>
        /// To Get Sales During the month
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<SaleProductModel>> GetSaleProduct(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetSaleProduct(yearlyReturnModel);
        }
        #endregion

        #region Get Mineral Grade
        /// <summary>
        /// To Get Mineral Grade
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<MineralGrade>> GetMineralGradeForTinMineral(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetMineralGradeForTinMineral(yearlyReturnModel);
        }
        #endregion

        #region Get Closing Stock
        /// <summary>
        /// To Get Closing Stock
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns> 
        [HttpPost]
        public async Task<OpeningStockandDispatch> Get_G2_ClosingStock(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.Get_G2_ClosingStock(yearlyReturnModel);
        }
        #endregion

        #region Get Dispatch
        /// <summary>
        /// To Get Dispatch
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<OpeningStockandDispatch> GetDispatch_Form2_Annual(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetDispatch_Form2_Annual(yearlyReturnModel);
        }
        #endregion
        #endregion

        #region Sales/Dispatches
        #region Add Sales/Dispatches
        /// <summary>
        /// To Add Sales/Dispatches
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddSaleDispatch(SalesDispatchOf_OreModel objModel)
        {
            return await yearlyNonCoalReturnProvider.AddSaleDispatch(objModel);
        }
        #endregion

        #region Update Sales/Dispatches
        /// <summary>
        /// To Update Sales/Dispatches
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateSaleDispatch(SalesDispatchOf_OreModel objModel)
        {
            return await yearlyNonCoalReturnProvider.UpdateSaleDispatch(objModel);
        }
        #endregion

        #region Delete Sales/Dispatches
        /// <summary>
        /// To Delete Sales/Dispatches
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> DeleteSaleDispatch(SalesDispatchOf_OreModel objModel)
        {
            return await yearlyNonCoalReturnProvider.DeleteSaleDispatch(objModel);
        }
        #endregion

        #region Get Sales/Dispatches
        /// <summary>
        /// To Get Sales/Dispatches
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<SalesDispatchOf_OreModel>> GetSaleDispatch(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetSaleDispatch(yearlyReturnModel);
        }
        #endregion

        #region Get Mineral Form
        /// <summary>
        /// To Get Mineral Form
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<MineralInfo>> GetMineralForm(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetMineralForm(yearlyReturnModel);
        }
        #endregion

        #region Get Mineral Grade
        /// <summary>
        /// To Get Mineral Grade
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<MineralGrade>> GetMineralGrade(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetMineralGrade(yearlyReturnModel);
        }
        #endregion

        #region Nature Of Dispatch
        /// <summary>
        /// To GetNature Of Dispatch
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<MineralInfo>> GetNatureOfDispatch(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetNatureOfDispatch(yearlyReturnModel);
        }
        #endregion

        #region Purchaser Consignee
        /// <summary>
        /// To Get Purchaser Consignee
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<MineralInfo>> GetPurchaserConsignee(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetPurchaserConsignee(yearlyReturnModel);
        }
        #endregion
        #endregion
        #endregion

        #region Part Seven H2
        #region Update CostOfProduction
        /// <summary>
        /// To Update Cost Of Production
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateCostOfProduction(CostOfProduction_Annual objModel)
        {
            return await yearlyNonCoalReturnProvider.UpdateCostOfProduction(objModel);
        }
        #endregion

        #region Add Cost Of Production
        /// <summary>
        /// To Add Cost Of Production
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddCostOfProduction(CostOfProduction_Annual objModel)
        {
            return await yearlyNonCoalReturnProvider.AddCostOfProduction(objModel);
        }
        #endregion

        #region Final Submit Cost Of Production
        /// <summary>
        /// To Final Submit Cost Of Production
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Update_FinalSubmit(CostOfProduction_Annual objModel)
        {
            return await yearlyNonCoalReturnProvider.Update_FinalSubmit(objModel);
        }
        #endregion

        #region Get Cost Of Production
        /// <summary>
        /// To Get Cost Of Production
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<CostOfProduction_Annual> GetCostOfProduction(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyNonCoalReturnProvider.GetCostOfProduction(yearlyReturnModel);
        }
        #endregion
        #endregion
    }
}
