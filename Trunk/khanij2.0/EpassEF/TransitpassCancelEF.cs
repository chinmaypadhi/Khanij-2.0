using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpassEF
{
   public class TransitpassCancelEF
    {
        public int? SrNo { get; set; }
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

        public int? UserID { get; set; }
        public int? SubUserID { get; set; }
        public string ePassType { get; set; }

        public string ePermit { get; set; }
        //---------------------Added by Akash kumar on 15/4/2022-------------------------------
        public string TPID { get; set; }
        public string DateOfDispatche { get; set; }

        public int? BulkPermitID { get; set; }
        public int? UserLoginId { get; set; }
        public string TransitPassNo { get; set; }
        public decimal? TareWeight { get; set; }
        public decimal? GrossWeight { get; set; }
        public decimal? NetWeight { get; set; }
        public string TRANSPORTATIONMODE { get; set; }
        public string INTTRIPSTATUS { get; set; }
        public string TRIPSTATUS { get; set; }
        public int? ID { get; set; }       
        
    }

    

}
