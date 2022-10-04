// ***********************************************************************
//  Controller Name          : DemandNotePaymentController
//  Desciption               : Demand & Credit Note summary data Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 12 July 2021
// ***********************************************************************
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PermitApi.Model.DemandNote;
using PermitEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermitApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class DemandNotePaymentController : ControllerBase
    {
        /// <summary>
        /// Global Object & variable declaration
        /// </summary>
        public IDemandNoteProvider _objIDemandNoteProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objIDemandNoteProvider"></param>
        public DemandNotePaymentController(IDemandNoteProvider objIDemandNoteProvider)
        {
            _objIDemandNoteProvider = objIDemandNoteProvider;
        }
        /// <summary>
        /// Bind Demand note summary data details in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<DemandNoteCodePayment>> getDemandNoteSummaryData(DemandNoteCodePayment objmodel)
        {
            return await _objIDemandNoteProvider.getDemandNoteSummaryData(objmodel);
        }
        /// <summary>
        /// Bind Credit note summary data details in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<DemandNoteCodePayment>> ViewPaymentDetails(DemandNoteCodePayment objmodel)
        {
            return await _objIDemandNoteProvider.viewPaymentDetails(objmodel);
        }

        [HttpPost]
        public async Task<List<DemandNotePaymentModel>> getPaymentDemandNoteData(DemandNoteCodePayment objmodel)
        {
            return await _objIDemandNoteProvider.viewPaymentDetailsData(objmodel);
        }
        [HttpPost]
        public async Task<List<DemandNoteCodePayment>> getCreditNoteSummaryData(DemandNoteCodePayment objmodel)
        {
            return await _objIDemandNoteProvider.viewCreditNoteSummaryData(objmodel);
        }

        [HttpPost]
        public async Task<List<CreditAmountModel>> GetCreditAmountDetails(DemandNoteCodePayment objmodel)
        {
            return await _objIDemandNoteProvider.viewCreditAmountData(objmodel);
        }

        [HttpPost]
        public MessageEF AddPassoutsideState(CreditAmountModel model)
        {
            return _objIDemandNoteProvider.AddCreditAmount(model);
        }

        [HttpPost]
        public async Task<List<CreditAmountModel>> GetPaymentType(DemandNoteCodePayment objmodel)
        {
            return await _objIDemandNoteProvider.viewPaymentType(objmodel);
        }

        [HttpPost]
        public async Task<List<CreditAmountModel>> GetLesseeDetails(DemandNoteCodePayment objmodel)
        {
            return await _objIDemandNoteProvider.viewLesseeName(objmodel);
        }

        [HttpPost]
        public MessageEF VerifyDemandNoteS(objDemandListData model)
        {
            return _objIDemandNoteProvider.VerifyDemandNoteS(model);
        }

    }
}
