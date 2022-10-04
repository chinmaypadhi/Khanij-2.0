using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace userregistrationEF
{
    public class LicenseeDocUploadModel
    { 
        public int? LicenseAppId { get; set; }
        public string KhasraPanchsala { get; set; }
        public string MapPlanofAppliedArea { get; set; }
        public string ForestReport { get; set; }
        public string RevenueOfficerReport { get; set; }
        public string SpotInspectionAnalysisReport { get; set; }
        public string MiningInspectorReport { get; set; }
        public string GramPanchayatProposal { get; set; }
        public string DemarcationReport { get; set; }
        public string EnvironmentalClearanceLetter { get; set; }
        public string ConsentToOperateLetter { get; set; }

        public string MAP_LAND_CERTIFICATE_FILE_PATH { get; set; }
        public string MAP_LAND_CERTIFICATE_FILE_NAME { get; set; }
        public string LATEST_REVENEW_CERTIFICATE_FILE_PATH { get; set; }
        public string LATEST_REVENEW_CERTIFICATE_FILE_NAME { get; set; }
        public string OWNER_LAND_CERTIFICATE_FILE_PATH { get; set; }
        public string OWNER_LAND_CERTIFICATE_FILE_NAME { get; set; }


        public string East { get; set; }
        public string West { get; set; }
        public string North { get; set; }
        public string South { get; set; }

        public string TotalAreaInHect { get; set; }
        public string ECNumber { get; set; }
        public string ECFromDate { get; set; }
        public string ECToDate { get; set; }

        public string CTONumber { get; set; }
        public string CTOOrderDate { get; set; }
        public int? AppliedBy { get; set; }
        public string AppliedName { get; set; }
        public IFormFile DemarcationPhoto { get; set; }
        public IFormFile EnvironmentalClearancePhoto { get; set; }
        public IFormFile ConsentToOperatePhoto { get; set; }
        public IFormFile KhasraPanchsalaPhoto { get; set; }
        public IFormFile MapPlanofAppliedAreaPhoto { get; set; }
        public IFormFile ForestReportPhoto { get; set; }
        public IFormFile RevenueOfficerReportPhoto { get; set; }
        public IFormFile SpotInspectionAnalysisReportPhoto { get; set; }
        public IFormFile MiningInspectorReportPhoto { get; set; }
        public IFormFile GramPanchayatProposalPhoto { get; set; }
    }
}
