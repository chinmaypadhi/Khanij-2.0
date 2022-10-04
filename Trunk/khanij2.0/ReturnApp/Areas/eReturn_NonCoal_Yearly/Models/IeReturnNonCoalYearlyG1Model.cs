using ReturnEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ReturnApp.Areas.eReturn_NonCoal_Yearly.Models
{
    public interface IeReturnNonCoalYearlyG1Model
    {
        List<YearlyReturnModel> GetYearlyReturnDetails(MonthlyReturnModelNonCoal model);
        AnnualReturnH1ViewModel GetMineOtherDetails(MonthlyReturnModelNonCoal model);
        ParticularsofArea GetParticularsofArea(MonthlyReturnModelNonCoal model);
        LeaseArea GetLeasearea(MonthlyReturnModelNonCoal model);
        MineDetailsModel GetLesseMineDeatils(MonthlyReturnModelNonCoal model);
        List<GetDDL> GetAgencyOfMine(MonthlyReturnModelNonCoal model);
        MessageEF AddMineOtherDetails(AnnualReturnH1ViewModel model);
        MessageEF AddParticularsofArea(AnnualReturnH1ViewModel model);
        MessageEF AddLeasearea(AnnualReturnH1ViewModel model);
        MessageEF UpdateMineOtherDetails(AnnualReturnH1ViewModel model);
        MessageEF UpdateParticularsofArea(AnnualReturnH1ViewModel model);
        MessageEF UpdateLeasearea(AnnualReturnH1ViewModel model);
        StaffandWorkModel GetStaffandWork(MonthlyReturnModelNonCoal model);
        SalaryWagesPaidModel GetSalaryWagesPaid(MonthlyReturnModelNonCoal model);
        CapitalStructure GetCapitalStructure(MonthlyReturnModelNonCoal model);
        SourceOfFinance GetSourceOfFinance(MonthlyReturnModelNonCoal model);
        WorkModel GetWorkDetails(MonthlyReturnModelNonCoal model);
        MessageEF AddStaffandWork(AnnualReturnH1PartTwoModel model);
        MessageEF AddWorkDetails(AnnualReturnH1PartTwoModel model);
        MessageEF AddSalaryWagesPaid(AnnualReturnH1PartTwoModel model);
        MessageEF AddCapitalStructure(AnnualReturnH1PartTwoModel model);
        MessageEF AddSourceOfFinance(AnnualReturnH1PartTwoModel model);
        MessageEF UpdateStaffandWork(AnnualReturnH1PartTwoModel model);
        MessageEF UpdateWorkDetails(AnnualReturnH1PartTwoModel model);
        MessageEF UpdateSalaryWagesPaid(AnnualReturnH1PartTwoModel model);
        MessageEF UpdateCapitalStructure(AnnualReturnH1PartTwoModel model);
        MessageEF UpdateSourceOfFinance(AnnualReturnH1PartTwoModel model);
    }
}
