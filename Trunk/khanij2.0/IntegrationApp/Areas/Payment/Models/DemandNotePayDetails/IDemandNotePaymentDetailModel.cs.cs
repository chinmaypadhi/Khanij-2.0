using IntegrationEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationApp.Areas.Payment.Models.DemandNotePayDetails
{
   public  interface IDemandNotePaymentDetailModel
    {
        List<DemandNotePaymentEF> getDemandNoteSummaryData(DemandNotePaymentEF objmodel);
        List<DemandNotePaymentEF> getDemandNoteSummaryDataAll(DemandNotePaymentEF objmodel);
        PaymentDetailsQmultiple GetpayStatus(DemandNotePaymentEF objmodel);
      //  List<DemandNotePaymentEF> getPaymentGetwayDetails(DemandNotePaymentEF objmodel);
        MessageEF AddpayStatus(DemandNotePaymentEF objmodel);
    }
}
