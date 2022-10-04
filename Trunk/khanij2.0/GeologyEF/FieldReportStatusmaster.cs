// ***********************************************************************
//  Class Name               : FieldReportStatusmaster
//  Desciption               : Field Report Status Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 12 Feb 2021
// ***********************************************************************
using Microsoft.AspNetCore.Http;
using System;


namespace GeologyEF
{
    public class FieldReportStatusmaster
    {
        public string ReportStatus_1 { get; set; }
        public string SrNo { get; set; }
        public int MPR_ID { get; set; }
        public int? FPO_Id { get; set; }
        public string FPO_Code { get; set; }
        public string ExplorationSeason { get; set; }
        public string FPO_Name { get; set; }
        public string FPO_AffectiveDate { get; set; }
        public string Report_MY { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public string ApplicantName { get; set; }
        public int? Officer_Id { get; set; }
        public string OfficerName { get; set; }
        public string OfficerDesignation { get; set; }
        public string OfficerMobileNo { get; set; }
        public string MobileNo { get; set; }
        public string FilePath { get; set; }
        public int? RegionalID { get; set; }
        public string RegionalName { get; set; }
        public int? DistrictID { get; set; }
        public string DistrictName { get; set; }
        public int? TehsilID { get; set; }
        public string TehsilName { get; set; }
        public int? VillageID { get; set; }
        public string VillageName { get; set; }
        public string BlockID { get; set; }
        public string BlockName { get; set; }
        public int? RegionalOfficeId { get; set; }
        public string RegionalOfficeName { get; set; }
        public int? Approve_Status { get; set; }
        public string Status { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? UserLoginId { get; set; }
        public string EmailId { get; set; }
        public int? ReportType { get; set; }
        public int? ReportStatus { get; set; }
        public string ReportTypeName { get; set; }
        public string ReportStatusName { get; set; }
        public string FIELD_REPORT_FILE_PATH { get; set; }
        public string FIELD_REPORT_FILE_NAME { get; set; }
        public string MAPS_PLATES_FILE_PATH { get; set; }
        public string MAPS_PLATES_FILE_NAME { get; set; }
        public string ANNEXURE_FILE_PATH { get; set; }
        public string ANNEXURE_FILE_NAME { get; set; }
        public IFormFile FIELD_REPORTAttachment { get; set; }
        public IFormFile MAPS_PLATESAttachment { get; set; }
        public IFormFile ANNEXUREAttachment { get; set; }
        public string season { get; set; }
        public string Report_Type { get; set; }
        public string Report_Status { get; set; }
        public string EmailId_List { get; set; }
        public string EmailId_CC_List { get; set; }
    }
}
