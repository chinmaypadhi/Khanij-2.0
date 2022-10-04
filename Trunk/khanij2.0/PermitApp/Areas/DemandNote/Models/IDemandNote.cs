// ***********************************************************************
//  Interface Name           : IDemandNote
//  Desciption               : Demand & Credit Note summary data Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 12 July 2021
// ***********************************************************************
using PermitEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermitApp.Areas.DemandNote.Models
{
    public interface IDemandNote
    {
        /// <summary>
        /// Bind Demand note summary data details in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        List<DemandNoteCodePayment> getDemandNoteSummaryData(DemandNoteCodePayment objmodel);
        /// <summary>
        /// Bind Credit note summary data details in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        List<DemandNoteCodePayment> getCreditNoteSummaryData(DemandNoteCodePayment objmodel);
        /// <summary>
        /// Payment Demand note summary data details in view
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        List<DemandNoteCodePayment> GetPaymentDemandNote(DemandNoteCodePayment obj);
        List<DemandNoteCodePayment> ViewPaymentDetails(DemandNoteCodePayment obj);
        List<DemandNotePaymentModel> ViewPaymentDetailsData(DemandNoteCodePayment obj);
        List<DemandNoteCodePayment> ViewCreditDetails(DemandNoteCodePayment obj);
        List<CreditAmountModel> ViewCreditAmountDetails(DemandNoteCodePayment obj);
        MessageEF AddManualCreditAmount(CreditAmountModel objadd);
        List<CreditAmountModel> ViewPaymentType(DemandNoteCodePayment obj);
        List<CreditAmountModel> ViewLessee(DemandNoteCodePayment obj);
        MessageEF VerifyDemandNoteS(objDemandListData objadd);

    }
}
