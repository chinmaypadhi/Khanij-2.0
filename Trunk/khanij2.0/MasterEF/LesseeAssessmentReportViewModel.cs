// ***********************************************************************
//  Model Name               : LesseeAssessmentReportViewModel
//  Desciption               : Lessee Assessment Report Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 29 July 2021
// ***********************************************************************
using System;
using Microsoft.AspNetCore.Http;


namespace MasterEF
{
    public class LesseeAssessmentReportViewModel
    {
        public int AssessmentID { get; set; }
        public string Assessmentdate { get; set; }
        public string StrAssessmentdate { get; set; }
        public string RecoveryReportFilePath { get; set; }
        public string RecoveryReportFileName { get; set; }
        public string HalfyearassesmentFilePath { get; set; }
        public string HalfyearassesmentFileName { get; set; }
        public string HalfYearAssesmentDate { get; set; }
        public IFormFile RecoveryHttpBase { get; set; }
        public IFormFile HalfYearHttpBase { get; set; }
        public string Remarks { get; set; }
        public int Status { get; set; }
        public string SubResion { get; set; }
        public string SubApprove { get; set; }
        public string SubReject { get; set; }
        public int? UserId { get; set; }
        public int? UserLoginId { get; set; }
        public string ModifyDate { get; set; }
        public string ModifyYear { get; set; }
        public int? CREATED_BY { get; set; }
        public string MineralTypeName { get; set; }
    }
}
