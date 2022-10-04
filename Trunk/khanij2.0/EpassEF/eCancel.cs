using System;
using System.Collections.Generic;
using System.Text;


namespace EpassEF
{
    public class eCancelModel
    {


        public int? UserId { get; set; }

        public int? SubuserId { get; set; }

        public int? UserLoginId { get; set; }

        public string TPid { get; set; }

        public string UpdateIn { get; set; }

        public string Remarks { get; set; }
        public string ePassType { get; set; }

        public int? Check { get; set; }

        public string Id { get; set; }

        public string BulkPermitNO { get; set; }

        public int SRNumber { get; set; }
        public int BulkPermitId { get; set; }
        public string TransactionalID { get; set; }
        public string PaymentReceiptID { get; set; }
        public string BulkPermitNo { get; set; }
        public string ApprovedDateText { get; set; }

        public string MineralName { get; set; }
        public string MineralNature { get; set; }
        public string MineralGradeName { get; set; }
        public string UnitName { get; set; }

        public decimal? ApprovedQty { get; set; }
        public string TillDateDispatched { get; set; }
        public decimal? PendingQty { get; set; }
        public decimal? AdjustedQty { get; set; }
        public decimal? TotalPayableAmount { get; set; }

        public int? ActiveStatus { get; set; }
        public int? RunningTrip { get; set; }
        public int? CloseTrip { get; set; }
        public int? TotalTrip { get; set; }

    }

    public class LesseeTransitPassModel
    {
        public int SrNo { get; set; }
        public int? TransitPassId { get; set; }
        public DateTime? Mineral_DateOfDispatch { get; set; }
        public string str_DateOfDispatch { get; set; }
        public string TransitPassNumber { get; set; }
        public int? PurchaserConsigneeId { get; set; }
        public int? BulkPermitId { get; set; }
        public string BulkPermitNo { get; set; }
        public string PurchaserConsigneeName { get; set; }

        public string DriverName { get; set; }
        public string DONumber { get; set; }
        public string DODate { get; set; }
        public string Remarks { get; set; }

        public decimal? TareWeight_Qty { get; set; }
        public decimal? GrossWeight_Qty { get; set; }
        public decimal? NetWeight_Qty { get; set; }
        public int? TransporterId { get; set; }
        public string TransporterName { get; set; }
        public int? TransportationModeId { get; set; }
        public string TransportationMode { get; set; }

        public string MineralName { get; set; }
        public string MineralGradeName { get; set; }
        public string UnitName { get; set; }
        public string MineralNature { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleTypeName { get; set; }
        public string TPMode { get; set; }
        public string IntTripStatus { get; set; }
        public string TripStatus { get; set; }

        public string RePrintStatus { get; set; }
        public int? CancelStatus { get; set; }

        public string CancellationDateTime { get; set; }
        public string ApproveRejectDateTime { get; set; }


    }



    public class DD
        {
       

        public int SrNo { get; set; }
        public int? TransitPassno { get; set; }
        public string VehicleNumber { get; set; }
        public string BulkPermitNo { get; set; }
        public string PurchaserConsigneeName { get; set; }
        public string str_DateOfDispatch { get; set; }
        public string MineralName { get; set; }
        public string MineralNature { get; set; }
        public string MineralGradeName { get; set; }
        public decimal? NetWeight_Qty { get; set; }
        public string UnitName { get; set; }
        public string TransportationMode { get; set; }
        public string TripStatus { get; set; }
        public string RePrintStatus { get; set; }
        public string ApproveRejectDateTime { get; set; }

        
    }


}
