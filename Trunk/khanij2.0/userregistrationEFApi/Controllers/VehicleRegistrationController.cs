// ***********************************************************************
//  Controller Name          : VehicleOwner
//  Desciption               : Vehicle Owner Details 
//  Created By               : Akshaya Dalei
//  Created On               : 24 July 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using userregistrationEF;
using userregistrationEFApi.Model.Vhicle;

namespace userregistrationEFApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class VehicleRegistrationController : ControllerBase
    {
        private readonly IVehicleRegistrationProvider vehicleProvider;

        public VehicleRegistrationController(IVehicleRegistrationProvider vehicleProvider)
        {
            this.vehicleProvider = vehicleProvider;
        }

        #region Add Vehicle Owner
        /// <summary>
        /// To Add Vehicle Owner
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        [HttpPost]
        public async Task<MessageEF> Add(TransporterModel transporterModel)
        {
            return await vehicleProvider.AddVehicleRegistration(transporterModel);
        }
        #endregion

        #region Edit Vehicle Owner
        /// <summary>
        /// To Edit Vehicle Owner
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="TransporterModel"></returns>
        [HttpPost]
        public async Task<TransporterModel> Edit(TransporterModel transporterModel)
        {
            return await vehicleProvider.EditVehicleRegistration(transporterModel);
        }
        #endregion

        #region Update Vehicle Owner
        /// <summary>
        /// To Update Vehicle Owner
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        [HttpPost]
        public async Task<MessageEF> Update(TransporterModel transporterModel)
        {
            return await vehicleProvider.UpdateVehicleRegistration(transporterModel);
        }
        #endregion

        #region View State
        /// <summary>
        /// To View State
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="List<TransporterModel>"></returns>
        [HttpPost]
        public async Task<List<TransporterModel>> ViewState(TransporterModel transporterModel)
        {
            return await vehicleProvider.ViewVehicleState(transporterModel);
        }
        #endregion

        #region View District
        /// <summary>
        /// To Get District
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="List<TransporterModel>"></returns>
        [HttpPost]
        public async Task<List<TransporterModel>> ViewDistrict(TransporterModel transporterModel)
        {
            return await vehicleProvider.ViewVehicleDistrict(transporterModel);
        }
        #endregion

        #region Get Security Question
        /// <summary>
        /// To Get Security Question
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="List<TransporterModel>"></returns>
        [HttpPost]
        public async Task<List<TransporterModel>> ViewSQuestion(TransporterModel transporterModel)
        {
            return await vehicleProvider.GetSQuestion(transporterModel);
        }
        #endregion

        #region Get OTP
        /// <summary>
        /// Get OTP to Validate Mobile No
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        [HttpPost]
        public async Task<MessageEF> OTPDetails(TransporterModel transporterModel)
        {
            return await vehicleProvider.GetOTP(transporterModel);
        }
        #endregion

        #region Verify OTP
        /// <summary>
        /// To Verify OTP
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        [HttpPost]
        public async Task<MessageEF> OTPVerification(TransporterModel transporterModel)
        {
            return await vehicleProvider.VerifyOTP(transporterModel);
        }
        #endregion

        #region Get Record For Report
        /// <summary>
        /// To Get Record For Report
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="TransporterModel"></returns>
        [HttpPost]
        public async Task<TransporterModel> RecordForReport(TransporterModel transporterModel)
        {
            return await vehicleProvider.GetRecordForReport(transporterModel);
        }
        #endregion

        #region Verify Mobile No
        /// <summary>
        /// To Verify Mobile No
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="MessageEF"></returns>
        [HttpPost]
        public async Task<MessageEF> VerifyMobile(TransporterModel transporterModel)
        {
            return await vehicleProvider.CheckMobileNo(transporterModel);
        }
        #endregion

        #region Get UserName and Password
        /// <summary>
        /// To Get UserName and Password
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="TransporterModel"></returns>
        [HttpPost]
        public async Task<TransporterModel> UserNamePasswordDetails(TransporterModel transporterModel)
        {
            return await vehicleProvider.GetUserNamePassword(transporterModel);
        }
        #endregion

        #region Vehicle Owner Registration Profile
        /// <summary>
        /// To Get Vehicle Registration Profile
        /// </summary>
        /// <param name="transporterModel"></param>
        /// <returns name="TransporterModel"></returns>
        [HttpPost]
        public async Task<Result<TransporterModel>> ProfileDetails(TransporterModel transporterModel)
        {
            return await vehicleProvider.VehicleRegistrationProfile(transporterModel);
        }
        #endregion

        #region Vehicle Payment Configuration Per Vehicle
        /// <summary>
        /// Add Vehicle Amount Configuration
        /// </summary>
        /// <param name="vehicleAmountConfiguration"></param>
        /// <returns></returns>
       [HttpPost]
        public async Task<MessageEF> AddVehicleAmountConfiguration(VehicleAmountConfiguration vehicleAmountConfiguration)
        {
            return await vehicleProvider.AddVehicleAmountConfiguration(vehicleAmountConfiguration);
        }

        /// <summary>
        /// Update Vehicle Amount Configuration
        /// </summary>
        /// <param name="vehicleAmountConfiguration"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateVehicleAmountConfiguration(VehicleAmountConfiguration vehicleAmountConfiguration)
        {
            return await vehicleProvider.UpdateVehicleAmountConfiguration(vehicleAmountConfiguration);
        }

        /// <summary>
        /// Get Vehicle Amount Configuration
        /// </summary>
        /// <param name="vehicleAmountConfiguration"></param>
        /// <returns></returns>
        public async Task<VehicleAmountConfiguration> GetVehicleAmountConfiguration(VehicleAmountConfiguration vehicleAmountConfiguration)
        {
            return await vehicleProvider.GetVehicleAmountConfiguration(vehicleAmountConfiguration);
        }
        #endregion

        
    }
}