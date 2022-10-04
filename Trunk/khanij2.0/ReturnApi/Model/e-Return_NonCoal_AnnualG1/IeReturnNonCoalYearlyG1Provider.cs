using Microsoft.AspNetCore.Mvc;
using ReturnApi.Repository;
using ReturnEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnApi.Model.e_Return_NonCoal_AnnualG1
{
    public interface IeReturnNonCoalYearlyG1Provider : IDisposable, IRepository
    {
        Task<List<YearlyReturnModel>> GetYearlyReturnDetails(MonthlyReturnModelNonCoal model);
        Task<AnnualReturnH1ViewModel> GetMineOtherDetails(MonthlyReturnModelNonCoal model);
        Task<ParticularsofArea> GetParticularsofArea(MonthlyReturnModelNonCoal model);
        Task<LeaseArea> GetLeasearea(MonthlyReturnModelNonCoal model);
        Task<MineDetailsModel> GetLesseMineDeatils(MonthlyReturnModelNonCoal model);
        Task<List<GetDDL>> GetAgencyOfMine(MonthlyReturnModelNonCoal model);
        Task<MessageEF> AddMineOtherDetails(AnnualReturnH1ViewModel objModel);
        Task<MessageEF> AddParticularsofArea(AnnualReturnH1ViewModel objModel);
        Task<MessageEF> AddLeasearea(AnnualReturnH1ViewModel objModel);
        Task<MessageEF> UpdateMineOtherDetails(AnnualReturnH1ViewModel objModel);
        Task<MessageEF> UpdateParticularsofArea(AnnualReturnH1ViewModel objModel);
        Task<MessageEF> UpdateLeasearea(AnnualReturnH1ViewModel objModel);
        Task<StaffandWorkModel> GetStaffandWork(MonthlyReturnModelNonCoal model);
        Task<SalaryWagesPaidModel> GetSalaryWagesPaid(MonthlyReturnModelNonCoal model);
        Task<CapitalStructure> GetCapitalStructure(MonthlyReturnModelNonCoal model);
        Task<SourceOfFinance> GetSourceOfFinance(MonthlyReturnModelNonCoal model);
        Task<WorkModel> GetWorkDetails(MonthlyReturnModelNonCoal model);
        Task<MessageEF> AddStaffandWork(AnnualReturnH1PartTwoModel objModel);
        Task<MessageEF> AddWorkDetails(AnnualReturnH1PartTwoModel objModel);
        Task<MessageEF> AddSalaryWagesPaid(AnnualReturnH1PartTwoModel objModel);
        Task<MessageEF> AddCapitalStructure(AnnualReturnH1PartTwoModel objModel);
        Task<MessageEF> AddSourceOfFinance(AnnualReturnH1PartTwoModel objModel);
        Task<MessageEF> UpdateStaffandWork(AnnualReturnH1PartTwoModel objModel);
        Task<MessageEF> UpdateWorkDetails(AnnualReturnH1PartTwoModel objModel);
        Task<MessageEF> UpdateSalaryWagesPaid(AnnualReturnH1PartTwoModel objModel);
        Task<MessageEF> UpdateCapitalStructure(AnnualReturnH1PartTwoModel objModel);
        Task<MessageEF> UpdateSourceOfFinance(AnnualReturnH1PartTwoModel objModel);


    }
}
