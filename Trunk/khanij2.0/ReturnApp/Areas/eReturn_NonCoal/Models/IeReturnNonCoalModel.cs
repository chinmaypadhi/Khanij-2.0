using ReturnEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnApp.Areas.eReturn_NonCoal.Models
{
    public interface IeReturnNonCoalModel
    {
        DDLResult GetFyDDL(MonthlyReturnModelNonCoal objDD);
        List<MonthlyReturnModelNonCoal> ViewLst(MonthlyReturnModelNonCoal model);

        GetFormF1DetailsModel GetLesseMineDeatils(MonthlyReturnModelNonCoal model);
        GetFormF1DetailsModel GeteReturnSubmittedDetails(MonthlyReturnModelNonCoal model);
        GetRentRoyaltyDetailsModel GetRentRoyalty(MonthlyReturnModelNonCoal model);
        MessageEF AddRoyaltyDetails(GetFormF1DetailsModel objModel);
        MessageEF UpdateRoyaltyDetails(GetFormF1DetailsModel objModel);
        GetFormF1DetailsModel GetMineralInfo(MonthlyReturnModelNonCoal model);
        ProductionModel_Monthly GetProduction(MonthlyReturnModelNonCoal model);
        Details_of_deductions_Monthly GetDetails_of_deductions(GetFormF1DetailsModel model);
        Reason_Inc_Dec_Monthly GetReason_Inc_Dec(GetFormF1DetailsModel model);
        Details_of_deductions_Monthly Getpulverization(GetFormF1DetailsModel model);
        ProductionModel_Monthly OpeningStock(GetFormF1DetailsModel model);
        DDLResult GetMineralForm(MonthlyReturnModelNonCoal objDD);
        DDLResult GetMineralGrade(MonthlyReturnModelNonCoal objDD);
        MessageEF ADDGradewise_ROM(Gradewise_ROMModel objModel);
        List<Gradewise_ROMModel> GetGradewise_ROM(MonthlyReturnModelNonCoal model);
        MessageEF UpdateGradewise_ROM(Gradewise_ROMModel objModel);
        MessageEF DeleteGradewise_ROM(Gradewise_ROMModel objModel);
        DDLResult GetMineralFormProduction(MonthlyReturnModelNonCoal objDD);
        MessageEF ADDGradewise_Production(Grade_WiseProduction objModel);
        List<Grade_WiseProduction> GetGrade_WiseProduction(MonthlyReturnModelNonCoal model);
        MessageEF UpdateGradewise_Prod(Grade_WiseProduction objModel);
        MessageEF DeleteGradewise_Prod(Grade_WiseProduction objModel);
        List<SalesDispatchModel> GetNatureOfDispatch(SalesDispatchModel model);
        List<SalesDispatchModel> GetPurchaserConsignee(MonthlyReturnModelNonCoal model);
        MessageEF AddSaleDispatch(SalesDispatchModel objModel);
        List<SalesDispatchModel> GetSalesDespatch(MonthlyReturnModelNonCoal model);
        MessageEF UpdateSaleDispatch(SalesDispatchModel objModel);
        MessageEF DeleteSaleDispatch(SalesDispatchModel objModel);
        MessageEF AddPulverization(Mineral_PulverizedModel objModel);
        List<Mineral_PulverizedModel> GetMineral_Pulverized(MonthlyReturnModelNonCoal model);
        MessageEF UpdateMineral_Pulverized(Mineral_PulverizedModel objModel);
        MessageEF DeleteeMineral_Pulverized(Mineral_PulverizedModel objModel);
        MessageEF AddReasonForInDc(Reason_Inc_Dec_Monthly objModel);

        MessageEF AddDeductionMade(Details_of_deductions_Monthly objModel);
        MessageEF UpdateReasonForInDc(Reason_Inc_Dec_Monthly objModel);
        MessageEF UpdateDetails_of_deductions(Details_of_deductions_Monthly objModel);

        MessageEF AddTypeProductionPartTwo(ProductionModel_Monthly objModel);
        MessageEF UpdateTypeProductionPartTwo(ProductionModel_Monthly objModel);
        MessageEF Update_FinalSubmit(Reason_Inc_Dec_Monthly objModel);
        MessageEF Addpulverization1(Details_of_deductions_Monthly objModel);
        MessageEF Updatepulverization(Details_of_deductions_Monthly objModel);
        GetFormF1DetailsModel GetFormF1Part1ForPrint(MonthlyReturnModelNonCoal objModel);
        List<Working_of_Mine> GetMineWorkDetails(MonthlyReturnModelNonCoal model);
        MessageEF Update_Filepath(MonthlyReturnModelNonCoal objModel);
    }
}
