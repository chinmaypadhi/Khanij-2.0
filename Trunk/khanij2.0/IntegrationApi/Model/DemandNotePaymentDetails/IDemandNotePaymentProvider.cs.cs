using IntegrationEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationApi.Model.DemandNotePaymentDetails
{
    public interface IDemandNotePaymentProvider
    {
        Task<List<DemandNotePaymentEF>> getDemandNoteSummaryData(DemandNotePaymentEF objmodel);
        Task<List<DemandNotePaymentEF>> getDemandNoteSummaryDataAll(DemandNotePaymentEF objmodel);
        Task<MessageEF> GetpayStatus(DemandNotePaymentEF objmodel);
        Task<PaymentDetailsQmultiple> getPaymentGetwayDetails(DemandNotePaymentEF objmodel);
        Task<MessageEF> AddpayStatus(DemandNotePaymentEF objmodel);

    }
}
