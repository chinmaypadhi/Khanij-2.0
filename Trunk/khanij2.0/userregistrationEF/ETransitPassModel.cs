using System;
using System.Collections.Generic;
using System.Text;

namespace userregistrationEF
{
    public class ETransitPassModel
    {
        public int? TransitPassID { get; set; }
        public string TransitPassNo { get; set; }
        public int? BulkPermitID { get; set; }
        public int? PurchaserConsigneeId { get; set; }
        public DateTime? DateOfDispatche { get; set; }
        public int? TransporterId { get; set; }
        public int? TransportationModeId { get; set; }
        public int? VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; }
        public int? VehicleId { get; set; }
        public string VehicleNumber { get; set; }
        public string DriverName { get; set; }
        public string DONumber { get; set; }
        public string Remarks { get; set; }
        public decimal? TareWeight { get; set; }
        public DateTime? TareTime { get; set; }
        public int? TareWBId { get; set; }
        public decimal? GrossWeight { get; set; }
        public DateTime? GrosdTime { get; set; }
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
        public DateTime? UpdatedOn { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Address { get; set; }

        public int? srNo { get; set; }
        public string MineralName { get; set; }
        public decimal? ApprovedQty { get; set; }

        public string FromDate { get; set; }
        public string ToDate { get; set; }


        public string D_O_Dispatche { get; set; }
        public string Display_TripStatus { get; set; }
        public int? rdoTripStatus { get; set; }
        public string PassNo { get; set; }

        public string SourceUserName { get; set; }
        public string DestUserName { get; set; }
        public string DriverContactNumber { get; set; }
        public string MineralNature { get; set; }
        public string MineralGrade { get; set; }

        public int? UserId { get; set; } 

    }
}
