using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userregistrationEF
{
    public class AddWeighBridgeTagModel
    {
        public int WeighBridgeTagID { get; set; }
        public int? UserID { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please Select WeighBridge")]
        public int? WeighBridgeID { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please Select User Type")]
        public int? UserTypeID { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please Select District")]
        public int? DistrictID { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please Select User")]
        public int? TagUserID{ get; set; }
    }
    public class ViewWeighBridgeTagModel
    {
        public int? WeighBridgeTagID { get; set; }
        
        public int? UserID { get; set; }
        public int? WeighBridgeID { get; set; }
        public string WeighBridgeName { get; set; }
        public int UserTypeID { get; set; }
        public string UserType { get; set; }
        public int? DistrictID { get; set; }
        public string DistrictName { get; set; }
        public int? TagUserID { get; set; }
        public string TagUserName { get; set; }
        //for list
        public string ApplicantName { get; set; }
        public string OwnerName { get; set; }
        public string ApplicationNo { get; set; }
        public string UserCode { get; set; }
        public string WeighBridgeType { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public DateTime StampValidFrom { get; set; }
        public DateTime StampValidTo { get; set; }
        public string ApproveType { get; set; }
        public DateTime AppliedDate { get; set; }
        public DateTime ApprovedOn { get; set; }
        public int? ApprovedBy { get; set; }
        public string ApproveRemarks { get; set; }
        //ADDED BY CHINMAY
        public int? ActivityId { get; set; }
        public int? ActionType { get; set; }
        public int? Value  { get; set; }
        public string Text { get; set; }


    }
}
