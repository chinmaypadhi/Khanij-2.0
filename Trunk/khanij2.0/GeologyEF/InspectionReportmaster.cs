// ***********************************************************************
//  Class Name               : InspectionReportmaster
//  Desciption               : Inspection Report Master Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 01 March 2021
// ***********************************************************************
using Microsoft.AspNetCore.Http;

namespace GeologyEF
{
    public class InspectionReportmaster
    {
        public int? MPR_ID { get; set; }
        public int? FPO_Id { get; set; }      
        public string FPO_Code { get; set; }
        public string InspectionReportFileUploadValidation { get; set; }
        public string season { get; set; }
        public string FPO_Name { get; set; }
        public string FPO_AffectiveDate { get; set; }
        public string Report_MY { get; set; }
        public int? UserId { get; set; }
        public int? UserLoginId { get; set; }
        public string SubmissionDate { get; set; }
        public IFormFile Attachment { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string ApplicantName { get; set; }
        public string Designation { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string dateofissuance { get; set; }
        public string DateOfInspection { get; set; }
        public string OfficerDesignation { get; set; }
        public string OfficerMobileNo { get; set; }
    }
}
