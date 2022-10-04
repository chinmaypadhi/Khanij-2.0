using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationApp.Models.Utility;
using userregistrationEF;

namespace userregistrationApp.Areas.VehicleOwner.Models.VehicleRegistration
{
    public class VehicleRegistrationModel : IVehicleRegistrationModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public VehicleRegistrationModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }

        #region Add Vehicle Owner
        /// <summary>
        /// To Add Vehicle Owner
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        public MessageEF Add(TransporterModel transporterModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("VehicleRegistration/Add",JsonConvert.SerializeObject(transporterModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Delete Vehicle Owner
        public MessageEF Delete(TransporterModel transporterModel)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Edit Vehicle Owner
        /// <summary>
        /// To Edit Vehicle Owner
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="TransporterModel"></returns>
        public TransporterModel Edit(TransporterModel transporterModel)
        {
            try
            {
                transporterModel = JsonConvert.DeserializeObject<TransporterModel>(_objIHttpWebClients.PostRequest("VehicleRegistration/Edit",JsonConvert.SerializeObject(transporterModel)));
                return transporterModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Get OTP
        /// <summary>
        /// Get OTP to Validate Mobile No
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        public MessageEF GetOTP(TransporterModel transporterModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("VehicleRegistration/OTPDetails",JsonConvert.SerializeObject(transporterModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Get Record For Report
        /// <summary>
        /// To Get Record For Report
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="TransporterModel"></returns>
        public TransporterModel GetRecordForReport(TransporterModel transporterModel)
        {
            try
            {
                
                transporterModel = JsonConvert.DeserializeObject<TransporterModel>(_objIHttpWebClients.PostRequest("VehicleRegistration/RecordForReport",JsonConvert.SerializeObject(transporterModel)));
                return transporterModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Get Security Question
        /// <summary>
        /// To Get Security Question
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="List<TransporterModel>"></returns>
        public List<TransporterModel> GetSQuestion(TransporterModel transporterModel)
        {
            try
            {
                List<TransporterModel> listTransporterModel = new List<TransporterModel>();
                listTransporterModel = JsonConvert.DeserializeObject<List<TransporterModel>>(_objIHttpWebClients.PostRequest("VehicleRegistration/ViewSQuestion",JsonConvert.SerializeObject(transporterModel)));
                return listTransporterModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Get UserName and Password
        /// <summary>
        /// To Get UserName and Password
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="TransporterModel"></returns>
        public TransporterModel GetUserNamePassword(TransporterModel transporterModel)
        {
            try
            {
               
                transporterModel = JsonConvert.DeserializeObject<TransporterModel>(_objIHttpWebClients.PostRequest("VehicleRegistration/UserNamePasswordDetails",JsonConvert.SerializeObject(transporterModel)));
                return transporterModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Update Vehicle Owner
        /// <summary>
        /// To Update Vehicle Owner
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        public MessageEF Update(TransporterModel transporterModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("VehicleRegistration/Update",JsonConvert.SerializeObject(transporterModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Vehicle Owner Registration Profile
        /// <summary>
        /// To Get Vehicle Registration Profile
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="TransporterModel"></returns>
        public TransporterModel VehicleRegistrationProfile(TransporterModel transporterModel)
        {
            try
            {
                transporterModel = JsonConvert.DeserializeObject<TransporterModel>(_objIHttpWebClients.PostRequest("VehicleRegistration/ProfileDetails",JsonConvert.SerializeObject(transporterModel)));
                return transporterModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Verify Mobile No
        /// <summary>
        /// To Verify Mobile No
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        public MessageEF VerifyMobile(TransporterModel transporterModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("VehicleRegistration/VerifyMobile",JsonConvert.SerializeObject(transporterModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Verify OTP
        /// <summary>
        /// To Verify OTP
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        public MessageEF VerifyOTP(TransporterModel transporterModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("VehicleRegistration/OTPVerification",JsonConvert.SerializeObject(transporterModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region View Vehicle Owner Details
        /// <summary>
        /// To View Vehicle Owner Details
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        public List<TransporterModel> View(TransporterModel transporterModel)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region View District
        /// <summary>
        /// To Get District
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="List<TransporterModel>"></returns>
        public List<TransporterModel> ViewDistrict(TransporterModel transporterModel)
        {
            try
            {
                List<TransporterModel> listTransporterModel = new List<TransporterModel>();
                listTransporterModel = JsonConvert.DeserializeObject<List<TransporterModel>>(_objIHttpWebClients.PostRequest("VehicleRegistration/ViewDistrict",JsonConvert.SerializeObject(transporterModel)));
                return listTransporterModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region View State
        /// <summary>
        /// To View State
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="List<TransporterModel>"></returns>
        public List<TransporterModel> ViewState(TransporterModel transporterModel)
        {
            try
            {
                List<TransporterModel> listTransporterModel = new List<TransporterModel>();
                listTransporterModel = JsonConvert.DeserializeObject<List<TransporterModel>>(_objIHttpWebClients.PostRequest("VehicleRegistration/ViewState",JsonConvert.SerializeObject(transporterModel)));
                return listTransporterModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Update Encrypted Password
        /// <summary>
        /// Update Encrypted Password
        /// </summary>
        /// <param name="updateEncryptPasswordModel"></param>
        /// <returns></returns>
        public MessageEF UpdateEncryptPassword(UpdateEncryptPasswordModel updateEncryptPasswordModel)
        {
            try
            {

                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LicenseApplication/UpdateEncryptPassword", JsonConvert.SerializeObject(updateEncryptPasswordModel)));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
