using ReturnEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnApp.Areas.Dailyproduction.Models
{
    public interface IDailyProductionModel
    {
        MessageEF Add(DailyProductionModel objDailyProductionModel);
        GetMineralResult GetMineralDDL(DailyProductionModel objDP);
        GetMineralResult GetGradeDDL(DailyProductionModel objDP);
        DailyProductionModel GetMineralName(DailyProductionModel ObjDP);
        MessageEF InsertDailyProd(DailyProductionModel ObjDP);
        DailyProductionModel GetTotalCap(DailyProductionModel ObjDP);
        List<DailyProductionModel> ViewSReport(DailyProductionModel objDP);
        DailyProductionModel GetYear(DailyProductionModel ObjDP);
        DailyProductionModel GetMonth(DailyProductionModel ObjDP);

        List<DailyProductionModel> ViewDetailsReport(DailyProductionModel objDP);
        MessageEF Delete(DailyProductionModel objDailyProductionModel);
        MessageEF SubmitDp(DailyProductionModel objDailyProductionModel);
        GetMonthResult GetMonthDDL(DailyProductionModel objDD);
        GetYearResult GetYearDDL(DailyProductionModel objDD);
        DailyProductionModel GetPaymentDetails(DailyProductionModel ObjDP);
        DailyProductionModel GetPaymentDetailsMonthYear(DailyProductionModel ObjDP);
        DailyProductionModel GetUniqueID(DailyProductionModel ObjDP);
        PaymentModel GetPaymentGateWay(DailyProductionModel ObjDP);
        MessageEF InsertPaymentStatus(PaymentModel objPaymentProductionmodel);
        List<DailyProductionModel> SummeryDetails(DailyProductionModel objDP);
    }
}
