using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpassEF
{

    public class TPCancelModelEF
    {
        public int? UserID { get; set; }
        public string Check { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int? CancellationId { get; set; }
        public int? TransitPassId { get; set; }
        public int? SrNo { get; set; }
        public int? Status { get; set; }
        public string ApplicantName { get; set; }
        public string DDRemarks { get; set; }
        public string UserRemarks { get; set; }
        public string TransitPassNo { get; set; }
        public string SourceUserCode { get; set; }
        public string SourceAddress { get; set; }
        public string SourceUserName { get; set; }
        public string DesinationUserCode { get; set; }
        public string DesinationAddress { get; set; }
        public string DestUserName { get; set; }
        public string NetWeight { get; set; }
        public string TransportaionMode { get; set; }
        public string TpType { get; set; }
        public string CancellationDateTime { get; set; }
        public string ApproveRejectDateTime { get; set; }
        public string TPDispatchTime { get; set; }
        public int? RePrintCount { get; set; }
        public string BulkPermitNo { get; set; }
        public string VehicleNo { get; set; }
        public string TripStatus { get; set; }
        public string Remarks { get; set; }
        public string UpdateIn { get; set; }
      //  public int? UserId { get; set; }
        public int? UserLoginId { get; set; }
        public int? TPid { get; set; }
        public string Action { get; set; }

    }
}
