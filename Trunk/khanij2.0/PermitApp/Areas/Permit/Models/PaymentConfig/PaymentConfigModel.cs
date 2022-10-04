using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermitEF;
using Newtonsoft.Json;
using PermitApp.Models.Utility;

namespace PermitApp.Areas.Permit.Models.PaymentConfig
{
    public class PaymentConfigModel:IPaymentConfigModel
    {

        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// View Profile Requests of IBM Details to Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objKeyList"></param>
        /// <param name="objIHttpWebClients"></param>
        public PaymentConfigModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        public MessageEF SaveFifthPaymentConfig(ePermitModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("PaymentConfig/SaveFifthPaymentConfig", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ePermitModel> GetFifthSchedule(ePermitModel objPermit)
        {
            try
            {
                List<ePermitModel> objlistNotice = new List<ePermitModel>();
                objlistNotice = JsonConvert.DeserializeObject<List<ePermitModel>>(_objIHttpWebClients.PostRequest("PaymentConfig/GetFifthSchedule", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public MessageEF UpdateFifthPaymentConfig(ePermitModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("PaymentConfig/UpdateFifthPaymentConfig", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF DeleteFifthPaymentConfig(ePermitModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("PaymentConfig/DeleteFifthPaymentConfig", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ePermitModel> EditFifthSchedule(ePermitModel objPermit)
        {
            try
            {
                List<ePermitModel> objlistNotice = new List<ePermitModel>();
                objlistNotice = JsonConvert.DeserializeObject<List<ePermitModel>>(_objIHttpWebClients.PostRequest("PaymentConfig/EditFifthSchedule", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public MessageEF SaveSixthPaymentConfig(ePermitModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("PaymentConfig/SaveSixthPaymentConfig", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF UpdateSixthPaymentConfig(ePermitModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("PaymentConfig/UpdateSixthPaymentConfig", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ePermitModel> GetSixthSchedule(ePermitModel objPermit)
        {
            try
            {
                List<ePermitModel> objlistNotice = new List<ePermitModel>();
                objlistNotice = JsonConvert.DeserializeObject<List<ePermitModel>>(_objIHttpWebClients.PostRequest("PaymentConfig/GetSixthSchedule", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult GetMineralNatureList(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("PaymentConfig/GetMineralNatureList", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult GetMineralList(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("PaymentConfig/GetMineralList", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ePermitModel> EditSixthSchedule(ePermitModel objPermit)
        {
            try
            {
                List<ePermitModel> objlistNotice = new List<ePermitModel>();
                objlistNotice = JsonConvert.DeserializeObject<List<ePermitModel>>(_objIHttpWebClients.PostRequest("PaymentConfig/EditSixthSchedule", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF DeleteSixthPaymentConfig(ePermitModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("PaymentConfig/DeleteSixthPaymentConfig", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ePermitResult BindFifthSchedule(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("PaymentConfig/BindFifthSchedule", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult BindSixthSchedule(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("PaymentConfig/BindSixthSchedule", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ePermitModel> GetRiderList(ePermitModel objPermit)
        {
            try
            {
                List<ePermitModel> objlistNotice = new List<ePermitModel>();
                objlistNotice = JsonConvert.DeserializeObject<List<ePermitModel>>(_objIHttpWebClients.PostRequest("PaymentConfig/GetRiderList", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF SavePaymentConfig(ePermitModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("PaymentConfig/SavePaymentConfig", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ePermitResult GetMineralGradeListOnNatureList(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("PaymentConfig/GetMineralGradeListOnNatureList", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult FillUserName(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("PaymentConfig/FillUserName", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult FillLeaseType(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("PaymentConfig/FillLeaseType", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ePermitModel> GetDynamicConfigWithourId(ePermitModel objPermit)
        {
            try
            {
                List<ePermitModel> objlistNotice = new List<ePermitModel>();
                objlistNotice = JsonConvert.DeserializeObject<List<ePermitModel>>(_objIHttpWebClients.PostRequest("PaymentConfig/GetDynamicConfigWithourId", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult FillDistrict(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("PaymentConfig/FillDistrict", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult FillUserType(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("Permit/FillUserType", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ePermitPaymentHead> GetPaymentTypeHead(ePermitModel objPermit)
        {
            try
            {
                List<ePermitPaymentHead> objlistNotice = new List<ePermitPaymentHead>();
                objlistNotice = JsonConvert.DeserializeObject<List<ePermitPaymentHead>>(_objIHttpWebClients.PostRequest("PaymentConfig/GetPaymentTypeHead", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF SaveDynamicPaymentConfig(ePermitModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("PaymentConfig/SaveDynamicPaymentConfig", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ePermitResult ViewDynamicPayment(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("PaymentConfig/ViewDynamicPayment", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF DeleteDynamicPaymentConfig(ePermitModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("PaymentConfig/DeleteDynamicPaymentConfig", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ePermitResult FillPaymentHeadType(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("PaymentConfig/FillPaymentHeadType", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult FillPaymentDept(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("PaymentConfig/FillPaymentDept", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult FillScheduleType(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("PaymentConfig/FillScheduleType", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF SaveScheduleRateMaster(ePermitModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("PaymentConfig/SaveScheduleRateMaster", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF UpdateScheduleRateMaster(ePermitModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("PaymentConfig/UpdateScheduleRateMaster", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF DeleteScheduleRateMaster(ePermitModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("PaymentConfig/DeleteScheduleRateMaster", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ePermitModel> ViewScheduleRateMaster(ePermitModel objPermit)
        {
            try
            {
                List<ePermitModel> objlistNotice = new List<ePermitModel>();
                objlistNotice = JsonConvert.DeserializeObject<List<ePermitModel>>(_objIHttpWebClients.PostRequest("PaymentConfig/ViewScheduleRateMaster", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ePermitModel> EditScheduleRateMaster(ePermitModel objPermit)
        {
            try
            {
                List<ePermitModel> objlistNotice = new List<ePermitModel>();
                objlistNotice = JsonConvert.DeserializeObject<List<ePermitModel>>(_objIHttpWebClients.PostRequest("PaymentConfig/EditScheduleRateMaster", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult DetailsDynamicPayment(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("PaymentConfig/DetailsDynamicPayment", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<ePermitModel> GetMineralCategory(ePermitModel objUser)
        {
            try
            {
                List<ePermitModel> objlistNotice = new List<ePermitModel>();
                objlistNotice = JsonConvert.DeserializeObject<List<ePermitModel>>(_objIHttpWebClients.PostRequest("PaymentConfig/GetMineralCategory", JsonConvert.SerializeObject(objUser)));
                return objlistNotice;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ePermitModel GetPaymentDetails(ePermitModel objUser)
        {
            try
            {
                objUser = JsonConvert.DeserializeObject<ePermitModel>(_objIHttpWebClients.PostRequest("PaymentConfig/GetPaymentDetails", JsonConvert.SerializeObject(objUser)));
                return objUser;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MessageEF UpdateDynamicPaymentConfig(ePermitModel model)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("PaymentConfig/UpdateDynamicPaymentConfig", JsonConvert.SerializeObject(model)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
