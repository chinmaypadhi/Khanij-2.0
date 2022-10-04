using System;
using System.Collections.Generic;
using System.Text;

namespace EpassEF
{
    public class EndUser_ETransitPassModel
    {
        public int? MineralNatureId { get; set; }
        public string OfflineTp { get; set; }
        public string OfflineFlag { get; set; }
        public int? userid { get; set; }
        public int? TransitPassID { get; set; }
        public string TransitPassNo { get; set; }
        public int? BulkPermitID { get; set; }
        public string BulkPermitNo { get; set; }
        public int? PurchaserConsigneeId { get; set; }
        public string PurchaserConsigneeName { get; set; }
        public DateTime? DateOfDispatche { get; set; }
        public int? TransporterId { get; set; }
        public int? TransportationModeId { get; set; }
        public string TransportationMode { get; set; }
        public int? VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; }
        public int? VehicleId { get; set; }
        public string VehicleNumber { get; set; }
        public string DriverName { get; set; }
        public string DriverContactNumber { get; set; }
        public string DONumber { get; set; }

        public string DODate { get; set; }
        public string TypeOfCoalDispatched { get; set; }

        public string Remarks { get; set; }
        public decimal? TareWeight { get; set; }
        public DateTime? TareTime { get; set; }
        public int? TareWBId { get; set; }
        public decimal? GrossWeight { get; set; }
        public DateTime? GrossTime { get; set; }
        public int? GrossWBId { get; set; }
        public decimal? NetWeight { get; set; }
       
        public decimal? ReceivedWeight { get; set; }
        public DateTime? ReceivedTime { get; set; }
        public int? ReceivedBy { get; set; }
        public int? TripStatus { get; set; }
        public int? ActiveStatus { get; set; }
        public int? AddedBy { get; set; }
        public DateTime? AddedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

        public int? MineralId { get; set; }
        public string MineralName { get; set; }
        public string UnitName { get; set; }
        public string MineralNature { get; set; }
        public int? MineralGradeId { get; set; }
        public string MineralGradeName { get; set; }
        public int? LesseeId { get; set; }
        public string LesseeName { get; set; }
        public string MiningArea { get; set; }
        public int srNo { get; set; }

        public string RouteName { get; set; }
        public string Destination { get; set; }
        public string TransporterName { get; set; }
        public string MineralSaleValue { get; set; }
        public string Address { get; set; }
        public string Date_OF_Dispatche { get; set; }
        public string TransitPass_Type { get; set; }
        public int UpcommingTrips { get; set; }

        public decimal? WashedCoal { get; set; }
        public decimal? RejectedCoal { get; set; }
        public string TripRemark { get; set; }

        public decimal? TotalReceivedQuantity { get; set; }
        public decimal? TotalECApprovedQuantity { get; set; }
        public string To_RailwaySliding { get; set; }
        public int? MineralNatrureId { get; set; }
        public decimal? EcQuantity { get; set; }

        public decimal? Remaining_Qty { get; set; }
        public decimal? OfflineQty { get; set; }
        public string TimeFormat { get; set; }
        public string Hours { get; set; }
        public string Minutes { get; set; }
        public string Seconds { get; set; }
        public string Format { get; set; }
        public string Minor_VehicleOwner { get; set; }
        public string Minor_VehicleNumber { get; set; }
        public string ReceivedDateTime { get; set; }

        public string UserType { get; set; }
        //public string Trips_Status { get; set; }
        //public string fdate { get; set; }
        //public string tdate { get; set; }
        //public string vehicleNumber { get; set; }
    }
    public class MineralReceiveModel
    {
        public int? userid { get; set; }
        public string UserType { get; set; }
        public string Trips_Status { get; set; }
        public string fdate { get; set; }
        public string tdate { get; set; }
        public string vehicleNumber { get; set; }


    }

}
