// ***********************************************************************
//  Class Name               : AssessmentListmaster
//  Desciption               : Assessment of Lessee 
//  Created By               : Lingaraj Dalai
//  Created On               : 30 April 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace StarratingEF
{
    public class AssessmentListmaster
    {
        public int? AssesmentID { get; set; }
        public int? RatingValue { get; set; }
        public int? PointObtained { get; set; }
        public decimal LesseePercent { get; set; }
        public int? MIPoint { get; set; }
        public decimal MIPercent { get; set; }
        public int? DDPoint { get; set; }
        public decimal DDPercent { get; set; }
        public int? DGMPoint { get; set; }
        public decimal DGMPercent { get; set; }
        public int? LStar { get; set; }
        public int? MIStar { get; set; }
        public int? DDStar { get; set; }
        public int? DGMStar { get; set; }
        public string Lessee_Code { get; set; }
        public string Khasra_No { get; set; }
        public string Lease_Period_From { get; set; }
        public string Lease_Period_To { get; set; }
        public string StateName { get; set; }
        public string DistrictName { get; set; }
        public string TehsilName { get; set; }
        public string VillageName { get; set; }
        public string MineralName { get; set; }
        public string ApplicantName { get; set; }
        public string Address { get; set; }
        public int? State_Id { get; set; }
        public int? District_Id { get; set; }
        public int? Tehsil_Id { get; set; }
        public int? Village_Id { get; set; }
        public int? Mineral_Id { get; set; }
        public string ReportingYear { get; set; }        
        public int? StateId { get; set; }
        public int? DistrictId { get; set; }
        public int? TehsilID { get; set; }
        public int? VillageID { get; set; }
        public int? UserId { get; set; }
        public int? Count { get; set; }
        public string Year { get; set; }
    }
}
