using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationEF;

namespace IntegrationApi.Model.SBIPayment
{
   public interface ISBIPaymentProvider
    {
        Task<PaymentResult> GetPaymentGateway(PaymentEF objUser);

        Task<MessageEF> InsertPaymentRequest(PaymentEF objUser);
        Task<PaymentResult> PaymentStatusReport(PaymentEF objUser);
        Task<MessageEF> PaymentStatusReportInsert(PaymentEF objUser);
        Task<MessageEF> InsertPaymentRequestOnFailed(PaymentEF objUser);
        Task<PaymentResult> LesseeWisePaymentDetails(PaymentEF objUser);
        Task<MessageEF> MakeFinalCoalPayment(PaymentEF objUser);
        Task<PaymentResult> GetCoalEPermit(PaymentEF objUser);
        Task<MessageEF> SaveSuperLesseeDashboardData(PaymentEF objUser);
        Task<PaymentResult> InsertVehicleMasterPaymentDetails(PaymentEF objUser);
        Task<List<BankRemittanceModel>> GetSBIPaymentStatus(PaymentEF objUser);
        Task<List<MCPaymentUserDetails>> GetReLoginUser(MCPaymentUserDetails objUser);
        Task<List<MCPaymentUserDetails>> GetReLoginUserDetails(MCPaymentUserDetails objUser);
        Task<PaymentResult> GetDetailsOfConfig(PaymentEF objUser);
    }
}
