using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpassEF
{
   public class FinalForwadingNoteEF
    {
        public int? SRNO { get; set; }
        public int? ForwardingNoteId { get; set; }
        public int? RTP_Id { get; set; }
        public string ForwardingNoteNumber { get; set; }
        public string ForwardingTransacationId { get; set; }
        [Required(ErrorMessage = "Select e-Permit No.")]
        public int? BulkPermitId { get; set; }
        public string BulkPermitNumber { get; set; }
        [Required(ErrorMessage = "Select Railway Sliding")]
        public int? RailwayId { get; set; }
        public string RailwaySliding { get; set; }
        public string RailwayAddress { get; set; }


        public int? DestinationRailwayId { get; set; }

        public string DestinationRailwaySiding { get; set; }

        public string EndUserRailwayAddress { get; set; }



        public string AddressofRailwaySliding { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateofSubmitedRTPRequest { get; set; }
        [Required(ErrorMessage = "Select Mineral")]
        public int? MineralId { get; set; }
        public string MineralName { get; set; }
        [Required(ErrorMessage = "Select  Mineral Grade")]
        public int? MineralGradeId { get; set; }
        public string MineralGrade { get; set; }
        [Required(ErrorMessage = "Qty field required")]
        public decimal? ReqQty { get; set; }
        public int? MineralNatureId { get; set; }
        public string MineralNature { get; set; }
        public decimal? ApprovedQty { get; set; }


        public decimal? PrintAndCloseFNQty { get; set; }

        public int? Status { get; set; }
        public string Request_Status { get; set; }
        public string ViewUserType { get; set; }
        public int? TotalPass { get; set; }
        public int? LicenseeId { get; set; }
        public string Consigner { get; set; }
        public string Consignee { get; set; }
        public string Address { get; set; }
        public string TripStatusText { get; set; }

        public string TelephoneNo { get; set; }
        public string GrantOrderNo { get; set; }

        public string GrantOrderDate { get; set; }
        public string LeaseFrom { get; set; }
        public string LeaseTo { get; set; }
        public int? UnitId { get; set; }
        public string UnitName { get; set; }
        [Required(ErrorMessage = "Select Consignee")]
        public int? EndUserId { get; set; }
        public string EndUser { get; set; }
        public string AddressofConsignee { get; set; }
        public int? NoofRTP { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public string RTP_RequestedOn { get; set; }
        public string Remarks { get; set; }
        // public decimal? AreaInHect { get; set; }
        public int? isForwarded { get; set; }
        public string UserType { get; set; }
        public string emailid { get; set; }
        public int? RTPQty { get; set; }
        public decimal StockQty { get; set; }
        public decimal PendingQty { get; set; }
        public decimal DispatchedQty { get; set; }
        public decimal TotalDispatchedQty { get; set; }
        public string RTPPassNo { get; set; }
        public int? RoyaltyPaidTransitPassId { get; set; }
        public string PassNo { get; set; }
        public string DateOfDispatch { get; set; }
        public string RPTPIds { get; set; }
        public string ReceivedWeights { get; set; }
        public string LeaseValidity { get; set; }

        public string GeneratedDSC { get; set; }
        public string GeneratedBy { get; set; }
        public string GeneratedDesignation { get; set; }
        public string District { get; set; }
        public string DSCResponse { get; set; }

        public string TransportationMode { get; set; }
        public decimal BalanceQty { get; set; }

        public string TrainNo { get; set; }
        public string RackNo { get; set; }

        public string DSCLesseeFilePath { get; set; }
        public string DSCDDFilePath { get; set; }

        [Required(ErrorMessage = "Please Enter EDRM Number")]
        public string EDRMNumber { get; set; }
        public string EDRMDate { get; set; }

        //Shyam Sir Update for file
        //public HttpPostedFileBase EDRM_SCAN_COPY { get; set; }
        public IFormFile EDRM_SCAN_COPY { get; set; }
        public string EDRMCopyPath { get; set; }
        [Required(ErrorMessage = "Please Enter EDRM Qty")]
        public decimal EDRMQty { get; set; }

        public decimal? RTP_ApprovedQty { get; set; }

        public decimal? OpenRoadTPQty { get; set; }

        public int? CloseTripStatus { get; set; }
        public int? GenerateRTPStatus { get; set; }
        public int? CloseRTPStatus { get; set; }
        public int? TripStatus { get; set; }
        public int? isLable { get; set; }
        public decimal? DiffDisplay { get; set; }
    }
    public class FinalForwadingNoteModelEF
    {
        public int? userid { get; set; }
        public string UserType { get; set; }
        public int? final { get; set; }
        public string From { get; set; }
        public string To { get; set; }
       


    }
}
