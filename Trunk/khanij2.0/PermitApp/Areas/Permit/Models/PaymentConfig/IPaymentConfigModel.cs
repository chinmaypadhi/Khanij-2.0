using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermitEF;

namespace PermitApp.Areas.Permit.Models.PaymentConfig
{
    public interface IPaymentConfigModel
    {
        MessageEF SaveFifthPaymentConfig(ePermitModel objUser);
        List<ePermitModel> GetFifthSchedule(ePermitModel objUser);
        List<ePermitModel> EditFifthSchedule(ePermitModel objUser);
        MessageEF UpdateFifthPaymentConfig(ePermitModel objUser);
        MessageEF DeleteFifthPaymentConfig(ePermitModel objUser);
        MessageEF SaveSixthPaymentConfig(ePermitModel objUser);
        MessageEF UpdateSixthPaymentConfig(ePermitModel objUser);
        List<ePermitModel> EditSixthSchedule(ePermitModel objUser);
        List<ePermitModel> GetSixthSchedule(ePermitModel objUser);
        ePermitResult GetMineralNatureList(ePermitModel objUser);
        ePermitResult GetMineralList(ePermitModel objUser);
        MessageEF DeleteSixthPaymentConfig(ePermitModel objUser);
        ePermitResult BindFifthSchedule(ePermitModel objUser);
        ePermitResult BindSixthSchedule(ePermitModel objUser);
        List<ePermitModel> GetRiderList(ePermitModel objUser);
        MessageEF SavePaymentConfig(ePermitModel objUser);
        ePermitResult GetMineralGradeListOnNatureList(ePermitModel objUser);
        ePermitResult FillUserName(ePermitModel objUser);
        ePermitResult FillLeaseType(ePermitModel objUser);
        List<ePermitModel> GetDynamicConfigWithourId(ePermitModel objUser);
        ePermitResult FillDistrict(ePermitModel objUser);
        ePermitResult FillUserType(ePermitModel objUser);
        List<ePermitPaymentHead> GetPaymentTypeHead(ePermitModel objUser);
        MessageEF SaveDynamicPaymentConfig(ePermitModel objUser);
        ePermitResult ViewDynamicPayment(ePermitModel objUser);
        MessageEF DeleteDynamicPaymentConfig(ePermitModel objUser);
        ePermitResult FillPaymentHeadType(ePermitModel objUser);
        ePermitResult FillPaymentDept(ePermitModel objUser);
        ePermitResult FillScheduleType(ePermitModel objUser);
        MessageEF SaveScheduleRateMaster(ePermitModel objUser);
        MessageEF UpdateScheduleRateMaster(ePermitModel objUser);
        List<ePermitModel> ViewScheduleRateMaster(ePermitModel objUser);
        List<ePermitModel> EditScheduleRateMaster(ePermitModel objUser);
        MessageEF DeleteScheduleRateMaster(ePermitModel objUser);
        ePermitResult DetailsDynamicPayment(ePermitModel objUser);
        List<ePermitModel> GetMineralCategory(ePermitModel objUser);
        ePermitModel GetPaymentDetails(ePermitModel objUser);
        MessageEF UpdateDynamicPaymentConfig(ePermitModel objUser);

    }
}
