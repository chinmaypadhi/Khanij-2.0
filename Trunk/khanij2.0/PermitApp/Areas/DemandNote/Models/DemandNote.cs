// ***********************************************************************
//  Class Name               : DemandNote
//  Desciption               : Demand & Credit Note summary data Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 12 July 2021
// ***********************************************************************
using Newtonsoft.Json;
using PermitApp.Models.Utility;
using PermitEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermitApp.Areas.DemandNote.Models
{
    public class DemandNote : IDemandNote
    {
        /// <summary>
        /// Global Object & variable declaration
        /// </summary>
        IHttpWebClients objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objIDemandNoteProvider"></param>
        public DemandNote(IHttpWebClients objIHttpWebClients)
        {
            this.objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Bind Credit note summary data details in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        public List<DemandNoteCodePayment> getDemandNoteSummaryData(DemandNoteCodePayment objmodel)
        {
            try
            {
                List<DemandNoteCodePayment> list = new List<DemandNoteCodePayment>();
                list = JsonConvert.DeserializeObject<List<DemandNoteCodePayment>>(objIHttpWebClients.PostRequest("DemandNotePayment/getDemandNoteSummaryData", JsonConvert.SerializeObject(objmodel)));
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Bind Credit note summary data details in view
        /// </summary>
        /// <param name="objmodel"></param>
        /// <returns></returns>
        public List<DemandNoteCodePayment> getCreditNoteSummaryData(DemandNoteCodePayment objmodel)
        {
            try
            {
                List<DemandNoteCodePayment> list = new List<DemandNoteCodePayment>();
                list = JsonConvert.DeserializeObject<List<DemandNoteCodePayment>>(objIHttpWebClients.PostRequest("DemandNote/getCreditNoteSummaryData", JsonConvert.SerializeObject(objmodel)));
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Payment Demand note summary data details in view
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public List<DemandNoteCodePayment> GetPaymentDemandNote(DemandNoteCodePayment obj)
        {
            try
            {
                List<DemandNoteCodePayment> list = new List<DemandNoteCodePayment>();
                list = JsonConvert.DeserializeObject<List<DemandNoteCodePayment>>(objIHttpWebClients.PostRequest("DemandNote/GetPaymentDemandNote", JsonConvert.SerializeObject(obj)));
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DemandNoteCodePayment> ViewPaymentDetails(DemandNoteCodePayment obj)
        {
            try
            {
                List<DemandNoteCodePayment> list = new List<DemandNoteCodePayment>();
                list = JsonConvert.DeserializeObject<List<DemandNoteCodePayment>>(objIHttpWebClients.PostRequest("DemandNotePayment/ViewPaymentDetails", JsonConvert.SerializeObject(obj)));
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<DemandNotePaymentModel> ViewPaymentDetailsData(DemandNoteCodePayment obj)
        {
            try
            {
                List<DemandNotePaymentModel> list = new List<DemandNotePaymentModel>();
                list = JsonConvert.DeserializeObject<List<DemandNotePaymentModel>>(objIHttpWebClients.PostRequest("DemandNotePayment/getPaymentDemandNoteData", JsonConvert.SerializeObject(obj)));
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DemandNoteCodePayment> ViewCreditDetails(DemandNoteCodePayment obj)
        {
            try
            {
                List<DemandNoteCodePayment> list = new List<DemandNoteCodePayment>();
                list = JsonConvert.DeserializeObject<List<DemandNoteCodePayment>>(objIHttpWebClients.PostRequest("DemandNotePayment/getCreditNoteSummaryData", JsonConvert.SerializeObject(obj)));
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CreditAmountModel> ViewCreditAmountDetails(DemandNoteCodePayment obj)
        {
            try
            {
                List<CreditAmountModel> list = new List<CreditAmountModel>();
                list = JsonConvert.DeserializeObject<List<CreditAmountModel>>(objIHttpWebClients.PostRequest("DemandNotePayment/GetCreditAmountDetails", JsonConvert.SerializeObject(obj)));
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MessageEF AddManualCreditAmount(CreditAmountModel objadd)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(objIHttpWebClients.PostRequest("DemandNotePayment/AddPassoutsideState", JsonConvert.SerializeObject(objadd)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public List<CreditAmountModel> ViewPaymentType(DemandNoteCodePayment obj)
        {
            try
            {
                List<CreditAmountModel> list = new List<CreditAmountModel>();
                list = JsonConvert.DeserializeObject<List<CreditAmountModel>>(objIHttpWebClients.PostRequest("DemandNotePayment/GetPaymentType", JsonConvert.SerializeObject(obj)));
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CreditAmountModel> ViewLessee(DemandNoteCodePayment obj)
        {
            try
            {
                List<CreditAmountModel> list = new List<CreditAmountModel>();
                list = JsonConvert.DeserializeObject<List<CreditAmountModel>>(objIHttpWebClients.PostRequest("DemandNotePayment/GetLesseeDetails", JsonConvert.SerializeObject(obj)));
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF VerifyDemandNoteS(objDemandListData  objadd)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(objIHttpWebClients.PostRequest("DemandNotePayment/VerifyDemandNoteS", JsonConvert.SerializeObject(objadd)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
