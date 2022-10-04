using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;

namespace userregistrationApp.Areas.VehicleOwner.Models.VehicleRegistration
{
    public interface IVehicleRegistrationModel
    {
        #region Add Vehicle Owner
        /// <summary>
        /// To Add Vehicle Owner
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        MessageEF Add(TransporterModel transporterModel);
        #endregion

        #region Update Vehicle Owner
        /// <summary>
        /// To Update Vehicle Owner
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        MessageEF Update(TransporterModel transporterModel);
        #endregion

        #region View Vehicle Owner Details
        /// <summary>
        /// To View Vehicle Owner Details
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        List<TransporterModel> View(TransporterModel transporterModel);
        #endregion

        #region Delete
        MessageEF Delete(TransporterModel transporterModel);
        #endregion

        #region Edit Vehicle Owner
        /// <summary>
        /// To Edit Vehicle Owner
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="TransporterModel"></returns>
        TransporterModel Edit(TransporterModel transporterModel);
        #endregion

        #region View State
        /// <summary>
        /// To View State
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="List<TransporterModel>"></returns>
        List<TransporterModel> ViewState(TransporterModel transporterModel);
        #endregion

        #region View District
        /// <summary>
        /// To Get District
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="List<TransporterModel>"></returns>
        List<TransporterModel> ViewDistrict(TransporterModel transporterModel);
        #endregion

        #region Get Security Question
        /// <summary>
        /// To Get Security Question
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="List<TransporterModel>"></returns>
        List<TransporterModel> GetSQuestion(TransporterModel transporterModel);
        #endregion

        #region Get OTP
        /// <summary>
        /// Get OTP to Validate Mobile No
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        MessageEF GetOTP(TransporterModel transporterModel);
        #endregion

        #region Verify OTP
        /// <summary>
        /// To Verify OTP
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        MessageEF VerifyOTP(TransporterModel transporterModel);
        #endregion

        #region Get Record For Report
        /// <summary>
        /// To Get Record For Report
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="TransporterModel"></returns>
        TransporterModel GetRecordForReport(TransporterModel transporterModel);
        #endregion

        #region Verify Mobile No
        /// <summary>
        /// To Verify Mobile No
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        MessageEF VerifyMobile(TransporterModel transporterModel);
        #endregion

        #region Get UserName and Password
        /// <summary>
        /// To Get UserName and Password
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="TransporterModel"></returns>
        TransporterModel GetUserNamePassword(TransporterModel transporterModel);
        #endregion

        #region Vehicle Owner Registration Profile
        /// <summary>
        /// To Get Vehicle Registration Profile
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="TransporterModel"></returns>
        TransporterModel VehicleRegistrationProfile(TransporterModel transporterModel);
        #endregion

        MessageEF UpdateEncryptPassword(UpdateEncryptPasswordModel updateEncryptPasswordModel);
    }
}
