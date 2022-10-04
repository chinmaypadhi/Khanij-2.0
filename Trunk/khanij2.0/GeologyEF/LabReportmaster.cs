// ***********************************************************************
//  Class Name               : LabReportmaster
//  Desciption               : Lab Report Master Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 24 Feb 2021
// ***********************************************************************
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;

namespace GeologyEF
{
    public class LabReportmaster
    {
        public int SrNo { get; set; }
        public int? LabReport_Id { get; set; }
        public int? FPO_Id { get; set; }
        public string FPO_Code { get; set; }
        public string FPO_AffectiveDate { get; set; }
        public string Location { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
        public string Date_of_Submission { get; set; }
        public string ToposheetNo { get; set; }
        public int? RegionalID { get; set; }
        public string RegionalName { get; set; }
        public int? DistrictID { get; set; }
        public string DistrictName { get; set; }
        public int? TehsilID { get; set; }
        public string TehsilName { get; set; }
        public int? VillageID { get; set; }
        public string VillageName { get; set; }
        public string Type_Of_Sample { get; set; }
        public string No_Of_Sample { get; set; }
        public int? Type_Id { get; set; }
        public string Type_of_Study { get; set; }
        public string Elements_analysed { get; set; }
        public string Attechment { get; set; }
        public int? App_Id { get; set; }
        public string Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? UserLoginId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public IFormFile Attachment { get; set; }
        public string RegionalOfficeId { get; set; }
        public string RegionalOfficeName { get; set; }
        public string GeologistName { get; set; }
        public string Designation { get; set; }
        public string AttechmentName { get; set; }
        public string Report_MY { get; set; }
        public string ApproveStatus { get; set; }
        public string Block { get; set; }
        public int? MineralID { get; set; }
        public string MineralName { get; set; }
        public string FPO_Name { get; set; }
        public string ExplorationSeason { get; set; }
        public int? RegionalLabId { get; set; }
        public string RegionalLabName { get; set; }
        public string Type { get; set; }
        public int? StudyAnalysisID { get; set; }
        public string StudyAnalysisName { get; set; }
        public string ApplicantName { get; set; }
        public int? Approve_Status { get; set; }
        public string UserType { get; set; }
        public DataTable dtUpload { get; set; }
        public List<IFormFile> file { get; set; }
        public string ResultFileName { get; set; }
        public string Result_Attechment { get; set; }
    }
}
