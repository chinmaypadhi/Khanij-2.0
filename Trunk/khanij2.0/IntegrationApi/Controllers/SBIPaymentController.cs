using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using IntegrationEF;
using IntegrationApi.Model.SBIPayment;
using Microsoft.AspNetCore.Authorization;

namespace IntegrationApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class SBIPaymentController : ControllerBase
    {
        public ISBIPaymentProvider _objISBIPaymentProvider;
        [HttpGet]
        public ActionResult<IEnumerable<string>> Test()
        {
            return new string[] { "value1", "value2" };
        }
        public SBIPaymentController(ISBIPaymentProvider objISBIPaymentProvider)
        {
            _objISBIPaymentProvider = objISBIPaymentProvider;
        }
        [HttpPost]
        public async Task<PaymentResult> GetPaymentGateway(PaymentEF objLease)
        {
            return await _objISBIPaymentProvider.GetPaymentGateway(objLease);
        }
        [HttpPost]
        public async Task<PaymentResult> PaymentStatusReport(PaymentEF objLease)
        {
            return await _objISBIPaymentProvider.PaymentStatusReport(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> InsertPaymentRequest(PaymentEF objLease)
        {
            return await _objISBIPaymentProvider.InsertPaymentRequest(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> PaymentStatusReportInsert(PaymentEF objLease)
        {
            return await _objISBIPaymentProvider.PaymentStatusReportInsert(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> InsertPaymentRequestOnFailed(PaymentEF objLease)
        {
            return await _objISBIPaymentProvider.InsertPaymentRequestOnFailed(objLease);
        }
        [HttpPost]
        public async Task<PaymentResult> LesseeWisePaymentDetails(PaymentEF objLease)
        {
            return await  _objISBIPaymentProvider.PaymentStatusReport(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> MakeFinalCoalPayment(PaymentEF objLease)
        {
            return await _objISBIPaymentProvider.MakeFinalCoalPayment(objLease);
        }
        [HttpPost]
        public async Task<PaymentResult> GetCoalEPermit(PaymentEF objLease)
        {
            return await _objISBIPaymentProvider.GetCoalEPermit(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> SaveSuperLesseeDashboardData(PaymentEF objLease)
        {
            return await _objISBIPaymentProvider.SaveSuperLesseeDashboardData(objLease);
        }
        [HttpPost]
        public async Task<PaymentResult> InsertVehicleMasterPaymentDetails(PaymentEF objLease)
        {
            return await _objISBIPaymentProvider.InsertVehicleMasterPaymentDetails(objLease);
        }
        [HttpPost]
        public async Task<List<BankRemittanceModel>> GetSBIPaymentStatus(PaymentEF objLease)
        {
            return await _objISBIPaymentProvider.GetSBIPaymentStatus(objLease);
        }
        //[HttpPost]
        //public UserLoginSession GetReLoginUser(LoginEF objLoginEF)
        //{

        //    return _objISBIPaymentProvider.UserLogin(objLoginEF);
        //}
        [HttpPost]
        public async Task<List<MCPaymentUserDetails>> GetReLoginUser(MCPaymentUserDetails objLoginEF)
        {

            return await _objISBIPaymentProvider.GetReLoginUser(objLoginEF);
        }
        [HttpPost]
        public async Task<List<MCPaymentUserDetails>> GetReLoginUserDetails(MCPaymentUserDetails objLoginEF)
        {

            return await _objISBIPaymentProvider.GetReLoginUserDetails(objLoginEF);
        }
        [HttpPost]
        public async Task<PaymentResult> GetDetailsOfConfig(PaymentEF objLease)
        {
            return await _objISBIPaymentProvider.GetDetailsOfConfig(objLease);
        }

    }
}
