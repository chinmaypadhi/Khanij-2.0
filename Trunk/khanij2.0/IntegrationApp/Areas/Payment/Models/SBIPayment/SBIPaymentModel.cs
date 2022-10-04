using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationApp.Models.Utility;
using IntegrationEF;
using Newtonsoft.Json;

namespace IntegrationApp.Areas.Payment.Models.SBIPayment
{
    public class SBIPaymentModel : ISBIPaymentModel
    {
        IHttpWebClients _objIHttpWebClients;
        public SBIPaymentModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }

        public PaymentResult GetPaymentGateway(PaymentEF objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<PaymentResult>(_objIHttpWebClients.PostRequest("SBIPayment/GetPaymentGateway", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MessageEF InsertPaymentRequest(PaymentEF objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("SBIPayment/InsertPaymentRequest", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PaymentResult PaymentStatusReport(PaymentEF objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<PaymentResult>(_objIHttpWebClients.PostRequest("SBIPayment/PaymentStatusReport", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MessageEF PaymentStatusReportInsert(PaymentEF objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("SBIPayment/PaymentStatusReportInsert", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MessageEF InsertPaymentRequestOnFailed(PaymentEF objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("SBIPayment/InsertPaymentRequestOnFailed", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PaymentResult LesseeWisePaymentDetails(PaymentEF objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<PaymentResult>(_objIHttpWebClients.PostRequest("SBIPayment/LesseeWisePaymentDetails", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MessageEF MakeFinalCoalPayment(PaymentEF objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("SBIPayment/MakeFinalCoalPayment", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PaymentResult GetCoalEPermit(PaymentEF objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<PaymentResult>(_objIHttpWebClients.PostRequest("SBIPayment/GetCoalEPermit", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MessageEF SaveSuperLesseeDashboardData(PaymentEF objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("SBIPayment/SaveSuperLesseeDashboardData", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PaymentResult InsertVehicleMasterPaymentDetails(PaymentEF objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<PaymentResult>(_objIHttpWebClients.PostRequest("SBIPayment/InsertVehicleMasterPaymentDetails", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<BankRemittanceModel> GetSBIPaymentStatus(PaymentEF objPermit)
        {
            try
            {
                List<BankRemittanceModel> objlistNotice = new List<BankRemittanceModel>();
                objlistNotice = JsonConvert.DeserializeObject<List<BankRemittanceModel>>(_objIHttpWebClients.PostRequest("SBIPayment/GetSBIPaymentStatus", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public List<MCPaymentUserDetails> GetReLoginUser(MCPaymentUserDetails ObjloginEF)
        {
            List<MCPaymentUserDetails> objUserLoginSession = new List<MCPaymentUserDetails>();
            try
            {

                objUserLoginSession = JsonConvert.DeserializeObject<List<MCPaymentUserDetails>>(_objIHttpWebClients.PostRequest("SBIPayment/GetReLoginUser", JsonConvert.SerializeObject(ObjloginEF)));
                return objUserLoginSession;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            //finally
            //{
            //    objUserLoginSession = null;
            //}

        }
        public List<MCPaymentUserDetails> GetReLoginUserDetailsInfo(MCPaymentUserDetails ObjloginEF)
        {
            List<MCPaymentUserDetails> objUserLoginSession = new List<MCPaymentUserDetails>();
            try
            {

                objUserLoginSession = JsonConvert.DeserializeObject<List<MCPaymentUserDetails>>(_objIHttpWebClients.PostRequest("SBIPayment/GetReLoginUserDetails", JsonConvert.SerializeObject(ObjloginEF)));
                return objUserLoginSession;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                objUserLoginSession = null;
            }

        }

        public PaymentResult GetDetailsOfConfig(PaymentEF objUser)
        {
            try
            {
                return JsonConvert.DeserializeObject<PaymentResult>(_objIHttpWebClients.PostRequest("SBIPayment/GetDetailsOfConfig", JsonConvert.SerializeObject(objUser)));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
