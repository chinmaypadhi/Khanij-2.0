using IntegrationApi.Model.DemandNotePaymentDetails;
using IntegrationEF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class DemandNotePaymentController : Controller
    {
        private readonly IDemandNotePaymentProvider demandNote;
        public DemandNotePaymentController(IDemandNotePaymentProvider _demandNotes)
        {
            this.demandNote = _demandNotes;
        }

        [HttpPost]
        public async Task<List<DemandNotePaymentEF>> getDemandNoteSummaryData(DemandNotePaymentEF objmodel)
        {
            return await demandNote.getDemandNoteSummaryData(objmodel);
        }
        [HttpPost]
        public async Task<List<DemandNotePaymentEF>> getDemandNoteSummaryDataAll(DemandNotePaymentEF objmodel)
        {
            return await demandNote.getDemandNoteSummaryDataAll(objmodel);
        }
        [HttpPost]
        public async Task<MessageEF> GetpayStatus(DemandNotePaymentEF objmodel)
        {
            return await demandNote.GetpayStatus(objmodel);
        }
        [HttpPost]
        public async Task<PaymentDetailsQmultiple> getPaymentGetwayDetails(DemandNotePaymentEF objmodel)
        {
            return await demandNote.getPaymentGetwayDetails(objmodel);
        }


        public async Task<MessageEF> AddpayStatus(DemandNotePaymentEF objmodel)
        {
            return await demandNote.AddpayStatus(objmodel);
        }

        
    }
}
