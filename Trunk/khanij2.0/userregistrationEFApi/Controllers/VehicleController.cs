// ***********************************************************************
//  Controller Name          : Vehicle
//  Desciption               : Vehicle  Add,Update,Delete,View,Trips,Renewal
//  Created By               : Akshaya Dalei
//  Created On               : 25 July 2021
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
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleProvider vehicleProvider;
        public VehicleController(IVehicleProvider vehicleProvider)
        {
            this.vehicleProvider = vehicleProvider;
        }

        #region Add Vehicle
        /// <summary>
        /// To Add Vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Add(Vehicle vehicle)
        {
            return await vehicleProvider.AddVehicle(vehicle);
        }
        #endregion

        #region View Vehicle Details
        /// <summary>
        /// To View Vehicle Details
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<Vehicle>> ViewDetails(Vehicle vehicle)
        {
            return await vehicleProvider.ViewVehicle(vehicle);
        }
        #endregion

        #region Edit Vehicle
        /// <summary>
        /// To Edit Vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Vehicle> Edit(Vehicle vehicle)
        {
            return await vehicleProvider.EditVehicle(vehicle);
        }
        #endregion

        #region Delete Vehicle
        /// <summary>
        /// To Delete Vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Delete(Vehicle vehicle)
        {
            return await vehicleProvider.DeleteVehicle(vehicle);
        }
        #endregion

        #region Check Vehicle No
        /// <summary>
        /// To Check Vehicle No
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> CheckVehicleNo(Vehicle vehicle)
        {
            return await vehicleProvider.IsVehicleExist(vehicle);
        }
        #endregion

        #region View Vehicle Type
        /// <summary>
        /// To View Vehicle Type
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<Vehicle>> VehicleTypeDetails(Vehicle vehicle)
        {
            return await vehicleProvider.ViewVehicleType(vehicle);
        }
        #endregion

        #region View Vehicle Unit
        /// <summary>
        /// To View Vehicle Unit
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<Vehicle>> VehicleUnitDetails(Vehicle vehicle)
        {
            return await vehicleProvider.ViewUnit(vehicle);
        }
        #endregion

        #region View Vehicle Renewal Details
        /// <summary>
        /// To View Vehicle Renewal Details
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<Vehicle>> VehicleRenewalDetails(Vehicle vehicle)
        {
            return await vehicleProvider.ViewVehicleRenewal(vehicle);
        }
        #endregion

        #region Indivisual Vehicle Fees
        /// <summary>
        /// Indivisual Vehicle Fees
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<Vehicle>> VehicleFees(Vehicle vehicle)
        {
            return await vehicleProvider.GetIndividualVehicleFees(vehicle);
        }
        #endregion

        #region Payment Remaining Vehicle
        /// <summary>
        /// To Payment Remaining Vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<Vehicle>> PaymentRemainingVehicle(Vehicle vehicle)
        {
            return await vehicleProvider.GetPaymentRemainingVehicle(vehicle);
        }
        #endregion

        #region Vehicle Trips
        /// <summary>
        /// To Get Vehicle Trips
        /// </summary>
        /// <param name="eTransitPassModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<ETransitPassModel>> RunningClosedTripData(ETransitPassModel eTransitPassModel)
        {
            return await vehicleProvider.GetRunningClosedTripGridData(eTransitPassModel);
        }
        #endregion

        #region Get BreakDown Details By TP No
        /// <summary>
        /// To Get BreakDown Details By TP No
        /// </summary>
        /// <param name="vehicleBreakdownTpDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<VehicleBreakdownTpDetails> GetTPDetailsByTransitPassNo(VehicleBreakdownTpDetails vehicleBreakdownTpDetails)
        {
            return await vehicleProvider.GetTransitPassNoWiseData(vehicleBreakdownTpDetails);
        }
        #endregion

        #region Get Vehicle BreakDown Approval Letter
        /// <summary>
        /// To Get Vehicle BreakDown Approval Letter
        /// </summary>
        /// <param name="vehicleBreakdown"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<VehicleBreakdown>> ApprovalLetter(VehicleBreakdown vehicleBreakdown)
        {
            return await vehicleProvider.GetApprovalLetter(vehicleBreakdown);
        }
        #endregion

        #region Get Record For 
        /// <summary>
        /// Get Record For Report
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> getRecordForReport(MessageEF messageEF)
        {
            return await vehicleProvider.getRecordForReport(messageEF);
        }
        #endregion

        #region Cancel Vehicle Payment Transaction
        /// <summary>
        /// Cancel Vehicle Payment Transaction
        /// </summary>
        /// <param name="cancelVehiclePayment"></param>
        /// <returns></returns>
        public async Task<MessageEF> CancelVehiclePaymentTransaction(CancelVehiclePayment cancelVehiclePayment)
        {
            return await CancelVehiclePaymentTransaction(cancelVehiclePayment);
        }
        #endregion

        /// <summary>
        /// Get Vehicles By Transit Pass No
        /// </summary>
        /// <param name="vehicleBreakdownTpDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<TextValue>> GetVehiclesByTransitPassNo(VehicleBreakdownTpDetails vehicleBreakdownTpDetails)
        {
            return await vehicleProvider.GetVehiclesByTransitPassNo(vehicleBreakdownTpDetails);
        }

        /// <summary>
        /// Save Vehicle Breakdown
        /// </summary>
        /// <param name="vehicleBreakdown"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> SaveVehicleBreakdownDetails(VehicleBreakdown vehicleBreakdown)
        {
            return await vehicleProvider.SaveVehicleBreakdownDetails(vehicleBreakdown);
        }

        /// <summary>
        /// Get VehicleBreak downData
        /// </summary>
        /// <param name="vehicleBreakdown"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<VehicleBreakdown>> GetVehicleBreakdownData(VehicleBreakdown vehicleBreakdown)
        {
            return await vehicleProvider.GetVehicleBreakdownData(vehicleBreakdown);
        }

        /// <summary>
        /// Get Vehicle BreakdownData By BreakDownId
        /// </summary>
        /// <param name="vehicleBreakdown"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<VehicleBreakdown> GetVehicleBreakdownDataByBreakDownId(VehicleBreakdown vehicleBreakdown)
        {
            return await vehicleProvider.GetVehicleBreakdownDataByBreakDownId(vehicleBreakdown);
        }

        /// <summary>
        /// Approve/Reject Vehicle Breakdown Request
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> ApproveRejectRequest(VehicleBreakdown vehicleBreakdown)
        {
            return await vehicleProvider.ApproveRejectRequest(vehicleBreakdown);
        }

        /// <summary>
        /// Start Vehicle Breakdown Trip
        /// </summary>
        /// <param name="vehicleBreakdown"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> StartVehicleBreakdownTrip(VehicleBreakdown vehicleBreakdown)
        {
            return await vehicleProvider.StartVehicleBreakdownTrip(vehicleBreakdown);
        }

        /// <summary>
        /// GET USER DETAILS BY MOBILENO
        /// </summary>
        /// <param name="MobileNo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result<List<VehicleBreakdownDetailsByMobileNo>>> GETUSERDETAILSBYMOBILENO(string MobileNo)
        {
            return await vehicleProvider.GETUSERDETAILSBYMOBILENO(MobileNo);
        }

        /// <summary>
        /// Breakdown Request From MobileApp
        /// </summary>
        /// <param name="breakdownRequestFromMobileApp"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result<MessageEF>> BreakdownRequestFromMobileApp(BreakdownRequestFromMobileApp breakdownRequestFromMobileApp)
        {
            return await vehicleProvider.BreakdownRequestFromMobileApp(breakdownRequestFromMobileApp);
        }

        /// <summary>
        /// Get OTP
        /// </summary>
        /// <param name="MobileNo"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Result<MessageEF>> GetOTPByMobileNo(string MobileNo)
        {
            return await vehicleProvider.GetOTPByMobileNo(MobileNo);
        }

        /// <summary>
        /// Add VTS Log
        /// </summary>
        /// <param name="vTSLog"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddVTSLog(VTSLog vTSLog)
        {
            return await vehicleProvider.AddVTSLog(vTSLog);
        }
    }
}