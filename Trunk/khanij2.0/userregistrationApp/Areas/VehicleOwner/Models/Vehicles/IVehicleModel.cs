using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;

namespace userregistrationApp.Areas.VehicleOwner.Models.Vehicles
{
    public interface IVehicleModel
    {
        MessageEF Add(Vehicle vehicle);
        MessageEF Update(Vehicle vehicle);
        List<Vehicle> View(Vehicle vehicle);
        MessageEF Delete(Vehicle vehicle);
        Vehicle Edit(Vehicle vehicle);
        List<Vehicle> ViewVehicleType(Vehicle vehicle);
        List<Vehicle> ViewVehicleUnit(Vehicle vehicle);
        MessageEF IsVehicleExist(Vehicle vehicle);
        List<Vehicle> ViewVehicleRenewal(Vehicle vehicle);
        List<Vehicle> IndivisualVehicleFees(Vehicle vehicle);
        List<Vehicle> PaymentRemainingVehicle(Vehicle vehicle);
        List<ETransitPassModel> GetRunningClosedTripGridData(ETransitPassModel eTransitPassModel);
        VehicleBreakdownTpDetails GetTransitPassNoWiseData(VehicleBreakdownTpDetails vehicleBreakdownTpDetails);
        List<VehicleBreakdown> GetApprovalLetter(VehicleBreakdown vehicleBreakdown);
        MessageEF getRecordForReport(MessageEF messageEF);
        MessageEF CancelVehiclePaymentTransaction(CancelVehiclePayment cancelVehiclePayment);
    }
}
