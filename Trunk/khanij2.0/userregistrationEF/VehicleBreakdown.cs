using System;
using System.Collections.Generic;
using System.Text;

namespace userregistrationEF
{
    public class VehicleBreakdown
    {
        public int? SrNo { get; set; }
        public int? BreakDownId { get; set; }
        public string TransitPassNo { get; set; }
        public string ReasonOfBreakDown { get; set; }
        public string LocationOfBreakDown { get; set; }
        public int? AssignedVehicleNo { get; set; }

        public string VehicleNumber { get; set; }
        public string TransporterName { get; set; }
        public string Remarks { get; set; }
        public string CommandType { get; set; }
        public string DSCResponse { get; set; }
        public int? OldVehicleId { get; set; }
        public string TransitPassType { get; set; }
        public string BreakDownDate { get; set; }

        public string SourceAddress { get; set; }
        public string DestinationAddress { get; set; }
        public string GrossWeight { get; set; }
        public int? UserId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Trip_Start_Status { get; set; }
        public int? TransitPassID { get; set; }
        public DateTime CREATED_ON { get; set; }
    }

    public class VehicleBreakdownTpDetails
    {
        public string TransitPassNo { get; set; }
        public string SourceAddress { get; set; }
        public string DestinationAddress { get; set; }
        public string GrossWeight { get; set; }
        public string Message { get; set; }
        public string RequestedUserName { get; set; }
        public string PurchaserConsigneeName { get; set; }
        public string VehicleNumber { get; set; }
        public string TransitPassType { get; set; }
        public int? OldVehicleId { get; set; }
        public string UserMaster { get; set; }
        public string EndUserName { get; set; }
        public string PassType { get; set; }
        public int? VehicleId { get; set; }
        public int? UserId { get; set; }
    }
}
