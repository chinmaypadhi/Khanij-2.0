using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userregistrationEF
{
    public class cls_TailingDam
    {
        public int? TailingDumpID { get; set; } 
        public string OwnerName { get; set; } 
        public string Address { get; set; } 
        public string MobileNo { get; set; } 
        public string EmailID { get; set; } 
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; } 
        public int? DistrictId { get; set; }
        public string DistrictName { get; set; } 
        public int? TehsilId { get; set; }
        public string TehsilName { get; set; } 
        public int? VillageId { get; set; }
        public string VillageName { get; set; } 
        public string Location { get; set; } 
        public string Designation { get; set; }     
        public decimal? Area { get; set; } 
        public int? Division { get; set; } 
        public int? MineralTypeId { get; set; }
        public string MineralTypeName { get; set; } 
        public int? MineralId { get; set; }
        public string MineralName { get; set; } 
        public int? MineralFormId { get; set; }
        public string MineralForm { get; set; } 
        public int? MineralGradeId { get; set; }
        public string MineralGrade { get; set; } 
        public decimal? CurrentStock { get; set; } 
        public string StateName { get; set; } 
        public string TypeOfSite { get; set; }
        public string UnitName { get; set; } 
        public IFormFile Tailing_SCAN_COPY { get; set; }
        public string TailingCopyPath { get; set; } 
        public string TailingDamUserCode { get; set; }
        public string TailingDamUserCurrentStatus { get; set; } 
        public int? SRNo { get; set; }
        public string OrderNo { get; set; }
        public string OrderDate { get; set; }
        public string PeriodValidityFrom { get; set; }
        public string PeriodValidityTo { get; set; }
        public string RoyaltyAndOtherPayable { get; set; }
        public string Status { get; set; } 
        public string CheckType { get; set; }
        public string s1 { get; set; }
        public int? UserId { get; set; }
        public int? UserTypeId { get; set; }
        public int IsRoyaltyPaid { get; set; }
        public string RoyaltyPaid { get; set; }
        public IFormFile SUPPORTING_DOCUMENT { get; set; }
        public string SUPPORTING_DOCUMENTPath { get; set; }
        public string SUPPORTING_DOCUMENTFILENAME { get; set; }
        public string Remarks { get; set; }
        public string ApplicantName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }


        public string MineralGradeName { get; set; }
        public string MineralType { get; set; }
        public int ForwardDDId { get; set; }


    }
}
