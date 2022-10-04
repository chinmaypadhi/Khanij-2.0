using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationEF;

namespace IntegrationApp.Areas.Payment.Models.SBIPayment
{
    public interface ISBIPaymentModel
    {
        PaymentResult GetPaymentGateway(PaymentEF objUser);
        MessageEF InsertPaymentRequest(PaymentEF objUser);
        PaymentResult PaymentStatusReport(PaymentEF objUser);
        MessageEF PaymentStatusReportInsert(PaymentEF objUser);
        MessageEF InsertPaymentRequestOnFailed(PaymentEF objUser);
        PaymentResult LesseeWisePaymentDetails(PaymentEF objUser);
        MessageEF MakeFinalCoalPayment(PaymentEF objUser);
        PaymentResult GetCoalEPermit(PaymentEF objUser);
        MessageEF SaveSuperLesseeDashboardData(PaymentEF objUser);
        PaymentResult InsertVehicleMasterPaymentDetails(PaymentEF objUser);
        List<BankRemittanceModel> GetSBIPaymentStatus(PaymentEF objUser);
        //Get user details added on 06092022 By saroj
        List<MCPaymentUserDetails> GetReLoginUser(MCPaymentUserDetails ObjloginEF);
        List<MCPaymentUserDetails> GetReLoginUserDetailsInfo(MCPaymentUserDetails ObjloginEF);
        PaymentResult GetDetailsOfConfig(PaymentEF objUser);
    }
}
