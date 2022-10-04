using IntegrationApp.Models.Utility;
using IntegrationEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationApp.Areas.Payment.Models.DemandNotePayDetails
{
    public class DemandNotePaymentDetailModel : IDemandNotePaymentDetailModel
    {
        IHttpWebClients _objIHttpWebClients;
        public DemandNotePaymentDetailModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }

        public MessageEF AddpayStatus(DemandNotePaymentEF objmodel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("DemandNotePayment/AddpayStatus", JsonConvert.SerializeObject(objmodel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<DemandNotePaymentEF> getDemandNoteSummaryData(DemandNotePaymentEF objmodel)
        {
            try
            {
                List<DemandNotePaymentEF> objlistNotice = new List<DemandNotePaymentEF>();
                objlistNotice = JsonConvert.DeserializeObject<List<DemandNotePaymentEF>>(_objIHttpWebClients.PostRequest("DemandNotePayment/getDemandNoteSummaryData", JsonConvert.SerializeObject(objmodel)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<DemandNotePaymentEF> getDemandNoteSummaryDataAll(DemandNotePaymentEF objmodel)
        {
            try
            {
                List<DemandNotePaymentEF> objlistNotice = new List<DemandNotePaymentEF>();
                objlistNotice = JsonConvert.DeserializeObject<List<DemandNotePaymentEF>>(_objIHttpWebClients.PostRequest("DemandNotePayment/getDemandNoteSummaryDataAll", JsonConvert.SerializeObject(objmodel)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //public List<DemandNotePaymentEF> getPaymentGetwayDetails(DemandNotePaymentEF objmodel)
        //{
        //    throw new NotImplementedException();
        //}

        public PaymentDetailsQmultiple GetpayStatus(DemandNotePaymentEF objmodel)
        {
            try
            {
                PaymentDetailsQmultiple objList = new PaymentDetailsQmultiple();
                objList = JsonConvert.DeserializeObject<PaymentDetailsQmultiple>(_objIHttpWebClients.PostRequest("DemandNotePayment/getPaymentGetwayDetails", JsonConvert.SerializeObject(objmodel)));
                return objList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       
    }
}
