using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationApp.Models.Utility;
using userregistrationEF;

namespace userregistrationApp.Areas.VehicleOwner.Models.Vehicles
{
    public class VehicleModel : IVehicleModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public VehicleModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region Add Vehicle
        /// <summary>
        /// To Add Vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public MessageEF Add(Vehicle vehicle)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Vehicle/Add", JsonConvert.SerializeObject(vehicle)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Delete Vehicle
        /// <summary>
        /// To Delete Vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public MessageEF Delete(Vehicle vehicle)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Vehicle/Delete", JsonConvert.SerializeObject(vehicle)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Edit Vehicle
        /// <summary>
        /// To Edit Vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public Vehicle Edit(Vehicle vehicle)
        {
            try
            {
                vehicle = JsonConvert.DeserializeObject<Vehicle>(_objIHttpWebClients.PostRequest("Vehicle/Edit", JsonConvert.SerializeObject(vehicle)));
                return vehicle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get Vehicle BreakDown Approval Letter
        /// <summary>
        /// To Get Vehicle BreakDown Approval Letter
        /// </summary>
        /// <param name="vehicleBreakdown"></param>
        /// <returns></returns>
        public List<VehicleBreakdown> GetApprovalLetter(VehicleBreakdown vehicleBreakdown)
        {
            try
            {
                List<VehicleBreakdown> lstVehicleBreakdown = new List<VehicleBreakdown>();
                lstVehicleBreakdown = JsonConvert.DeserializeObject<List<VehicleBreakdown>>(_objIHttpWebClients.PostRequest("Vehicle/ApprovalLetter", JsonConvert.SerializeObject(vehicleBreakdown)));
                return lstVehicleBreakdown;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Vehicle Trips
        /// <summary>
        /// To Get Vehicle Trips
        /// </summary>
        /// <param name="eTransitPassModel"></param>
        /// <returns></returns>
        public List<ETransitPassModel> GetRunningClosedTripGridData(ETransitPassModel eTransitPassModel)
        {
            try
            {
                List<ETransitPassModel> lstETransitPassModel = new List<ETransitPassModel>();
                lstETransitPassModel = JsonConvert.DeserializeObject<List<ETransitPassModel>>(_objIHttpWebClients.PostRequest("Vehicle/RunningClosedTripData", JsonConvert.SerializeObject(eTransitPassModel)));
                return lstETransitPassModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get BreakDown Details By TP No
        /// <summary>
        /// To Get BreakDown Details By TP No
        /// </summary>
        /// <param name="vehicleBreakdownTpDetails"></param>
        /// <returns></returns>
        public VehicleBreakdownTpDetails GetTransitPassNoWiseData(VehicleBreakdownTpDetails vehicleBreakdownTpDetails)
        {
            try
            {
                vehicleBreakdownTpDetails = JsonConvert.DeserializeObject<VehicleBreakdownTpDetails>(_objIHttpWebClients.PostRequest("Vehicle/GetTPDetailsByTransitPassNo", JsonConvert.SerializeObject(vehicleBreakdownTpDetails)));
                return vehicleBreakdownTpDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Indivisual Vehicle Fees
        /// <summary>
        /// Indivisual Vehicle Fees
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public List<Vehicle> IndivisualVehicleFees(Vehicle vehicle)
        {
            try
            {
                List<Vehicle> lstVehicle = new List<Vehicle>();
                lstVehicle = JsonConvert.DeserializeObject<List<Vehicle>>(_objIHttpWebClients.PostRequest("Vehicle/VehicleFees", JsonConvert.SerializeObject(vehicle)));
                return lstVehicle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Check Vehicle No
        /// <summary>
        /// To Check Vehicle No
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public MessageEF IsVehicleExist(Vehicle vehicle)
        {
            try
            {
                MessageEF messageEF = new MessageEF();
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Vehicle/CheckVehicleNo", JsonConvert.SerializeObject(vehicle)));
                return messageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Payment Remaining Vehicle
        /// <summary>
        /// To Payment Remaining Vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public List<Vehicle> PaymentRemainingVehicle(Vehicle vehicle)
        {
            try
            {
                List<Vehicle> listVehicle = new List<Vehicle>();
                listVehicle = JsonConvert.DeserializeObject<List<Vehicle>>(_objIHttpWebClients.PostRequest("Vehicle/PaymentRemainingVehicle", JsonConvert.SerializeObject(vehicle)));
                return listVehicle;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// To Update Vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public MessageEF Update(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region View Vehicle Details
        /// <summary>
        /// To View Vehicle Details
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public List<Vehicle> View(Vehicle vehicle)
        {
            try
            {
                List<Vehicle> listVehicle = new List<Vehicle>();
                listVehicle = JsonConvert.DeserializeObject<List<Vehicle>>(_objIHttpWebClients.PostRequest("Vehicle/ViewDetails", JsonConvert.SerializeObject(vehicle)));
                return listVehicle;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region View Vehicle Renewal Details
        /// <summary>
        /// To View Vehicle Renewal Details
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public List<Vehicle> ViewVehicleRenewal(Vehicle vehicle)
        {
            try
            {
                List<Vehicle> listVehicle = new List<Vehicle>();
                listVehicle = JsonConvert.DeserializeObject<List<Vehicle>>(_objIHttpWebClients.PostRequest("Vehicle/VehicleRenewalDetails", JsonConvert.SerializeObject(vehicle)));
                return listVehicle;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region View Vehicle Type
        /// <summary>
        /// To View Vehicle Type
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public List<Vehicle> ViewVehicleType(Vehicle vehicle)
        {
            try
            {
                List<Vehicle> listVehicle = new List<Vehicle>();
                listVehicle = JsonConvert.DeserializeObject<List<Vehicle>>(_objIHttpWebClients.PostRequest("Vehicle/VehicleTypeDetails", JsonConvert.SerializeObject(vehicle)));
                return listVehicle;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region View Vehicle Unit
        /// <summary>
        /// To View Vehicle Unit
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public List<Vehicle> ViewVehicleUnit(Vehicle vehicle)
        {
            try
            {
                List<Vehicle> listVehicle = new List<Vehicle>();
                listVehicle = JsonConvert.DeserializeObject<List<Vehicle>>(_objIHttpWebClients.PostRequest("Vehicle/VehicleUnitDetails", JsonConvert.SerializeObject(vehicle)));
                return listVehicle;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Get Record For Report
        /// <summary>
        /// Get Record For Report
        /// </summary>
        /// <returns></returns>
        public MessageEF getRecordForReport(MessageEF messageEF)
        {
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Vehicle/getRecordForReport", JsonConvert.SerializeObject(messageEF)));
                return messageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Cancel Vehicle Payment Transaction
        /// <summary>
        /// Cancel Vehicle Payment Transaction
        /// </summary>
        /// <param name="cancelVehiclePayment"></param>
        /// <returns></returns>
        public MessageEF CancelVehiclePaymentTransaction(CancelVehiclePayment cancelVehiclePayment)
        {
            MessageEF messageEF = new MessageEF();
            try
            {
                messageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Vehicle/CancelVehiclePaymentTransaction", JsonConvert.SerializeObject(cancelVehiclePayment)));
                return messageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
