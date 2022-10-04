using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.AspNetCore.Http;

namespace QuarryPlanApprovalEF
{
    public class QuarryPlanModel
    {
        public int QID { get; set; }
        public int Step { get; set; }
        public int? LesseeID { get; set; }
        public string ApplicantName { get; set; }
        public string ApplicationNo { get; set; }
        public string MobileNo { get; set; }
        public string EMailId { get; set; }
        public DataTable DtKhasra { get; set; }
        public DataTable DtLeaseBoundary { get; set; }
        public DataTable DtMineralPlan { get; set; }
        public string RepresentativeName { get; set; }
        public string RepresentativeDesignation { get; set; }
        public string RepresentativeContact { get; set; }
        public bool StatusFlag { get; set; }
        public string Status { get; set; }
        public string StatusDescription { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime TDate { get; set; }
        //Docs
        public IFormFile QuarryPlanCopy { get; set; }
        public string QuarryPlanFile { get; set; }
        public IFormFile SupportingDocCopy { get; set; }
        public string SupportingDocFile { get; set; }
        //RQP
        public string RQPName { get; set; }
        public string RQPRegistrationNo { get; set; }
        public string RQPEmail { get; set; }
        public string RQPMobile { get; set; }
        public int RQPDistrictID { get; set; }
        public string RQPDistrictName { get; set; }
        public string RQPAddress { get; set; }
        public IFormFile RQPCertificateCopy { get; set; }
        public string RQPCertificateFile { get; set; }
        public DateTime RQPValidityDate { get; set; }
        //Approval section
        public int? ApprovedBy { get; set; }
        public IFormFile ApprovedDocCopy { get; set; }
        public string ApprovedDocFile { get; set; }
        public IFormFile FieldVerificationCopy { get; set; }
        public string FieldVerificationFile { get; set; }
        public string ApproveType { get; set; }
        public string ApproveRemarks { get; set; }
        //lesee profile section
        public string MinesAddress { get; set; }
        public string District { get; set; }
        public string Village { get; set; }
        public string Panchayat { get; set; }
        public string Tehsil { get; set; }
        public string PoliceStation { get; set; }
        public string TotalLeaseHectares { get; set; }
    }
    public class QuarryMineralModel
    {
        public string FinancialYear { get; set; }
        public string MineralQty { get; set; }
        public string Remarks { get; set; }
    }
    public class QuarryLeaseBoundaryModel
    {
        public string BoundaryType { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
    public class QuarryKhasraModel
    {
        public int KhasraNo { get; set; }
    }
}
