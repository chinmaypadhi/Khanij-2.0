using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userregistrationEF
{
    public class VehicleBreakdownDetailsByMobileNo
    {
        public int TransitPassID { get; set; }
        public string TransitPassNo { get; set; }
        public int BulkPermitID { get; set; }
        public int ForwardingNoteId { get; set; }
        public int PurchaserConsigneeId { get; set; }
        public DateTime DateOfDispatche { get; set; }
        public int TransporterId { get; set; }
        public int TransportationModeId { get; set; }
        public string TransportationMode { get; set; }
        public int VehicleTypeId { get; set; }
        public int VehicleId { get; set; }
        public string DriverName { get; set; }
        public string DriverContactNumber { get; set; }
        public string DONumber { get; set; }
        public string Remarks { get; set; }
        public decimal TareWeight { get; set; }
        public DateTime TareTime { get; set; }
        public decimal GrossWeight { get; set; }
        public DateTime GrosdTime { get; set; }
        public decimal NetWeight { get; set; }
        public decimal ReceivedWeight { get; set; }
        public DateTime ReceivedTime { get; set; }
        public int ReceivedBy { get; set; }
        public int TripStatus { get; set; }
        public int ActiveStatus { get; set; }
        public int AddedBy { get; set; }
        public decimal MineralSaleValue { get; set; }
        public bool IsTPOffline { get; set; }
        public string PurchaserConsignee { get; set; }
        public string Destination { get; set; }
        public decimal SaleValue { get; set; }
        public string RouteName { get; set; }
        public bool IsOpened { get; set; }
        public int IsOtherTP { get; set; }
        public int RePrintCount { get; set; }
        public int DistrictId { get; set; }
        public int ProjectId { get; set; }
    }
}
