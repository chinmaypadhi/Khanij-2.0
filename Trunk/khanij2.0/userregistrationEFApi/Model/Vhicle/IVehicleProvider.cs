using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
using userregistrationEFApi.Repository;

namespace userregistrationEFApi.Model.Vhicle
{
    public interface IVehicleProvider : IDisposable, IRepository
    {
        Task<MessageEF> AddVehicle(Vehicle vehicle);
        Task<List<Vehicle>> ViewVehicle(Vehicle vehicle);
        Task<Vehicle> EditVehicle(Vehicle vehicle);
        Task<MessageEF> DeleteVehicle(Vehicle vehicle);
        Task<MessageEF> UpdateVehicle(Vehicle vehicle);
        Task<List<Vehicle>> ViewVehicleType(Vehicle vehicle);
        Task<List<Vehicle>> ViewUnit(Vehicle vehicle);
        Task<MessageEF> IsVehicleExist(Vehicle vehicle);
        Task<List<Vehicle>> ViewVehicleRenewal(Vehicle vehicle);
        Task<List<Vehicle>> GetIndividualVehicleFees(Vehicle vehicle);
        Task<List<Vehicle>> GetPaymentRemainingVehicle(Vehicle vehicle);
        Task<List<ETransitPassModel>> GetRunningClosedTripGridData(ETransitPassModel eTransitPassModel);
        Task<VehicleBreakdownTpDetails> GetTransitPassNoWiseData(VehicleBreakdownTpDetails vehicleBreakdownTpDetails);
        Task<List<VehicleBreakdown>> GetApprovalLetter(VehicleBreakdown vehicleBreakdown);
        Task<MessageEF> getRecordForReport(MessageEF messageEF);
        Task<MessageEF> CancelVehiclePaymentTransaction(CancelVehiclePayment cancelVehiclePayment);
        Task<MessageEF> PaymentStatusFromGateway(CancelVehiclePayment cancelVehiclePayment);
        Task<List<TextValue>> GetVehiclesByTransitPassNo(VehicleBreakdownTpDetails vehicleBreakdownTpDetails);
        Task<MessageEF> SaveVehicleBreakdownDetails(VehicleBreakdown vehicleBreakdown);
        Task<List<VehicleBreakdown>> GetVehicleBreakdownData(VehicleBreakdown vehicleBreakdown);
        Task<VehicleBreakdown> GetVehicleBreakdownDataByBreakDownId(VehicleBreakdown vehicleBreakdown);
        Task<MessageEF> ApproveRejectRequest(VehicleBreakdown vehicleBreakdown);
        Task<MessageEF> StartVehicleBreakdownTrip(VehicleBreakdown vehicleBreakdown);
        Task<Result<List<VehicleBreakdownDetailsByMobileNo>>> GETUSERDETAILSBYMOBILENO(string MobileNo);
        Task<Result<MessageEF>> BreakdownRequestFromMobileApp(BreakdownRequestFromMobileApp breakdownRequestFromMobileApp);
        Task<Result<MessageEF>> GetOTPByMobileNo(string MobileNo);
        Task<MessageEF> AddVTSLog(VTSLog vTSLog);
    }
}
