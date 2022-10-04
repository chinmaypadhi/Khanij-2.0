// ***********************************************************************
//  Interface Name           : IDemandNoteProvider
//  Desciption               : Demand & Credit Note summary data Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 12 July 2021
// ***********************************************************************
using PermitEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermitApi.Model.DemandNote
{
    public interface IDemandNoteProvider
    {
        /// <summary>
        /// Bind Demand note summary data details in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        Task<List<DemandNoteCodePayment>> getDemandNoteSummaryData(DemandNoteCodePayment objmodel);
        /// <summary>
        /// Bind Credit note summary data details in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        Task<List<DemandNoteCodePayment>> getCreditNoteSummaryData(DemandNoteCodePayment objmodel);
        Task<List<DemandNoteCodePayment>> viewPaymentDetails(DemandNoteCodePayment objmodel);
        Task<List<DemandNotePaymentModel>> viewPaymentDetailsData(DemandNoteCodePayment objmodel);
        Task<List<DemandNoteCodePayment>> viewCreditNoteSummaryData(DemandNoteCodePayment objmodel);
        Task<List<CreditAmountModel>> viewCreditAmountData(DemandNoteCodePayment objmodel);
        MessageEF AddCreditAmount(CreditAmountModel objins);
        Task<List<CreditAmountModel>> viewPaymentType(DemandNoteCodePayment objmodel);
        Task<List<CreditAmountModel>> viewLesseeName(DemandNoteCodePayment objmodel);
        MessageEF VerifyDemandNoteS(objDemandListData objins);
    }
}
