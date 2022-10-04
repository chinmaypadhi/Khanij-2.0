using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermitApi.Model.PaymentConfig;
using PermitEF;
using Microsoft.AspNetCore.Authorization;

namespace PermitApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class PaymentConfigController : Controller
    {
        public IPaymentConfigProvider _objIPaymentProvider;
        public PaymentConfigController(IPaymentConfigProvider objIPaymentProvider)
        {
            _objIPaymentProvider = objIPaymentProvider;
        }
        [HttpPost]
        public async Task<ePermitResult> GetMineralGradeListOnNatureList(ePermitModel objLease)
        {
            return await _objIPaymentProvider.GetMineralGradeListOnNatureList(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> SaveFifthPaymentConfig(ePermitModel objLease)
        {
            return await _objIPaymentProvider.SaveFifthPaymentConfig(objLease);
        }
        [HttpPost]
        public async Task<List<ePermitModel>> GetFifthSchedule(ePermitModel objLease)
        {
            return await _objIPaymentProvider.GetFifthSchedule(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> UpdateFifthPaymentConfig(ePermitModel objLease)
        {
            return await _objIPaymentProvider.UpdateFifthPaymentConfig(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> DeleteFifthPaymentConfig(ePermitModel objLease)
        {
            return await _objIPaymentProvider.DeleteFifthPaymentConfig(objLease);
        }
        [HttpPost]
        public async Task<List<ePermitModel>> EditFifthSchedule(ePermitModel objLease)
        {
            return await _objIPaymentProvider.EditFifthSchedule(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> SaveSixthPaymentConfig(ePermitModel objLease)
        {
            return await _objIPaymentProvider.SaveSixthPaymentConfig(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> UpdateSixthPaymentConfig(ePermitModel objLease)
        {
            return await _objIPaymentProvider.UpdateSixthPaymentConfig(objLease);
        }
        [HttpPost]
        public async Task<List<ePermitModel>> GetSixthSchedule(ePermitModel objLease)
        {
            return await _objIPaymentProvider.GetSixthSchedule(objLease);
        }
        [HttpPost]
        public async Task<List<ePermitModel>> EditSixthSchedule(ePermitModel objLease)
        {
            return await _objIPaymentProvider.EditSixthSchedule(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> GetMineralNatureList(ePermitModel objLease)
        {
            return await _objIPaymentProvider.GetMineralNatureList(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> GetMineralList(ePermitModel objLease)
        {
            return await _objIPaymentProvider.GetMineralList(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> DeleteSixthPaymentConfig(ePermitModel objLease)
        {
            return await _objIPaymentProvider.DeleteSixthPaymentConfig(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> BindFifthSchedule(ePermitModel objLease)
        {
            return await _objIPaymentProvider.BindFifthSchedule(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> BindSixthSchedule(ePermitModel objLease)
        {
            return await _objIPaymentProvider.BindSixthSchedule(objLease);
        }
        [HttpPost]
        public async Task<List<ePermitModel>> GetRiderList(ePermitModel objLease)
        {
            return await _objIPaymentProvider.GetRiderList(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> SavePaymentConfig(ePermitModel objLease)
        {
            return await _objIPaymentProvider.SavePaymentConfig(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> FillUserName(ePermitModel objLease)
        {
            return await _objIPaymentProvider.FillUserName(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> FillLeaseType(ePermitModel objLease)
        {
            return await _objIPaymentProvider.FillLeaseType(objLease);
        }
        [HttpPost]
        public async Task<List<ePermitModel>> GetDynamicConfigWithourId(ePermitModel objLease)
        {
            return await _objIPaymentProvider.GetDynamicConfigWithourId(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> FillDistrict(ePermitModel objLease)
        {
            return await _objIPaymentProvider.FillDistrict(objLease);
        }
        [HttpPost]
        public async Task<List<ePermitPaymentHead>> GetPaymentTypeHead(ePermitModel objLease)
        {
            return await _objIPaymentProvider.GetPaymentTypeHead(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> SaveDynamicPaymentConfig(ePermitModel objLease)
        {
            return await _objIPaymentProvider.SaveDynamicPaymentConfig(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> ViewDynamicPayment(ePermitModel objLease)
        {
            return await _objIPaymentProvider.ViewDynamicPayment(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> DeleteDynamicPaymentConfig(ePermitModel objLease)
        {
            return await _objIPaymentProvider.DeleteDynamicPaymentConfig(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> FillPaymentHeadType(ePermitModel objLease)
        {
            return await _objIPaymentProvider.FillPaymentHeadType(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> FillPaymentDept(ePermitModel objLease)
        {
            return await _objIPaymentProvider.FillPaymentDept(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> FillScheduleType(ePermitModel objLease)
        {
            return await _objIPaymentProvider.FillScheduleType(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> SaveScheduleRateMaster(ePermitModel objLease)
        {
            return await _objIPaymentProvider.SaveScheduleRateMaster(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> UpdateScheduleRateMaster(ePermitModel objLease)
        {
            return await _objIPaymentProvider.UpdateScheduleRateMaster(objLease);
        }
        [HttpPost]
        public async Task<List<ePermitModel>> ViewScheduleRateMaster(ePermitModel objLease)
        {
            return await _objIPaymentProvider.ViewScheduleRateMaster(objLease);
        }
        [HttpPost]
        public async Task<List<ePermitModel>> EditScheduleRateMaster(ePermitModel objLease)
        {
            return await _objIPaymentProvider.EditScheduleRateMaster(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> DeleteScheduleRateMaster(ePermitModel objLease)
        {
            return await _objIPaymentProvider.DeleteScheduleRateMaster(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> DetailsDynamicPayment(ePermitModel objLease)
        {
            return await _objIPaymentProvider.DetailsDynamicPayment(objLease);
        }

        //Created by priyabrat das for selecting mineral category

        [HttpPost]
        public async Task<List<ePermitModel>> GetMineralCategory(ePermitModel objLease)
        {
            return await _objIPaymentProvider.GetMineralCategory(objLease);
        }
        [HttpPost]
        public  ePermitModel GetPaymentDetails(ePermitModel objLease)
        {
            return  _objIPaymentProvider.GetPaymentDetails(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> UpdateDynamicPaymentConfig(ePermitModel objLease)
        {
            return await _objIPaymentProvider.UpdateDynamicPaymentConfig(objLease);
        }
    }
}
