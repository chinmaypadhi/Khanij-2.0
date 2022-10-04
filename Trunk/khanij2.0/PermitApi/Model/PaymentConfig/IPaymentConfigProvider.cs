using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermitEF;
using PermitApi.Repository;

namespace PermitApi.Model.PaymentConfig
{
   public interface IPaymentConfigProvider:IDisposable,IRepository
    {
        Task<MessageEF> SaveFifthPaymentConfig(ePermitModel objUser);
        Task<ePermitResult> GetMineralGradeListOnNatureList(ePermitModel objUser);
        Task<List<ePermitModel>> GetFifthSchedule(ePermitModel objUser);
        Task<List<ePermitModel>> EditFifthSchedule(ePermitModel objUser);
        Task<MessageEF> UpdateFifthPaymentConfig(ePermitModel objUser);
        Task<MessageEF> DeleteFifthPaymentConfig(ePermitModel objUser);
        Task<MessageEF> SaveSixthPaymentConfig(ePermitModel objUser);
        Task<MessageEF> UpdateSixthPaymentConfig(ePermitModel objUser);
        Task<List<ePermitModel>> GetSixthSchedule(ePermitModel objUser);
        Task<ePermitResult> GetMineralNatureList(ePermitModel objUser);
        Task<ePermitResult> GetMineralList(ePermitModel objUser);

        Task<List<ePermitModel>> EditSixthSchedule(ePermitModel objUser);
        Task<MessageEF> DeleteSixthPaymentConfig(ePermitModel objUser);
        Task<ePermitResult> BindFifthSchedule(ePermitModel objUser);
        Task<ePermitResult> BindSixthSchedule(ePermitModel objUser);
        Task<List<ePermitModel>> GetRiderList(ePermitModel objUser);
        Task<MessageEF> SavePaymentConfig(ePermitModel objUser);
        Task<ePermitResult> FillUserName(ePermitModel objUser);
        Task<ePermitResult> FillLeaseType(ePermitModel objUser);
        Task<List<ePermitModel>> GetDynamicConfigWithourId(ePermitModel objUser);
        Task<ePermitResult> FillDistrict(ePermitModel objUser);
        Task<List<ePermitPaymentHead>> GetPaymentTypeHead(ePermitModel objUser);
        Task<MessageEF> SaveDynamicPaymentConfig(ePermitModel objUser);
        Task<ePermitResult> ViewDynamicPayment(ePermitModel objUser);
        Task<MessageEF> DeleteDynamicPaymentConfig(ePermitModel objUser);
        Task<ePermitResult> FillPaymentHeadType(ePermitModel objUser);
        Task<ePermitResult> FillPaymentDept(ePermitModel objUser);
        Task<ePermitResult> FillScheduleType(ePermitModel objUser);
        Task<MessageEF> SaveScheduleRateMaster(ePermitModel objUser);
        Task<MessageEF> UpdateScheduleRateMaster(ePermitModel objUser);
        Task<List<ePermitModel>> ViewScheduleRateMaster(ePermitModel objUser);
        Task<List<ePermitModel>> EditScheduleRateMaster(ePermitModel objUser);
        Task<MessageEF> DeleteScheduleRateMaster(ePermitModel objUser);
        Task<ePermitResult> DetailsDynamicPayment(ePermitModel objUser);
        Task<List<ePermitModel>> GetMineralCategory(ePermitModel objUser);
        ePermitModel GetPaymentDetails(ePermitModel objUser);
        Task<MessageEF> UpdateDynamicPaymentConfig(ePermitModel model);

    }
}
