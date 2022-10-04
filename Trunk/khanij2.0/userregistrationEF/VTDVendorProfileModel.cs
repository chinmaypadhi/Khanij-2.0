// ***********************************************************************
//  Class Name               : VTDVendorProfileModel
//  Desciption               : View,Update VTD Vendor Profile Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 31 July 2022
// ***********************************************************************
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userregistrationEF
{
    public class VTDVendorProfileModel
    {
        public VTDVendorProfileModel()
        {
            this.VTDvendorId = 0;
            this.UserId = 0;
            this.UserLoginId = 0;
            this.CompanyId = 0;
            this.CorpStateId = 0;
            this.CorpDistrictId = 0;
            this.LocalStateId = 0;
            this.LocalDistrictId = 0;
            this.LocalBlockId = 0;
            this.CompanyName = string.Empty;
            this.GSTNo = string.Empty;
            this.ModelName = string.Empty;
            this.PortNo = string.Empty;
            this.CorpAddress = string.Empty;
            this.CorpStateName = string.Empty;
            this.CorpDistrictName = string.Empty;
            this.CorpBlockName = string.Empty;
            this.CorpPincode = string.Empty;
            this.LocalAddress = string.Empty;
            this.LocalStateName = string.Empty;
            this.LocalDistrictName = string.Empty;
            this.LocalBlockName = string.Empty;
            this.LocalPincode = string.Empty;
            this.PrimaryContactName = string.Empty;
            this.PrimaryContactMobileNo = string.Empty;
            this.PrimaryContactDesignation = string.Empty;
            this.PrimaryContactEmailId = string.Empty;
            this.SecondaryContactName = string.Empty;
            this.SecondaryContactMobileNo = string.Empty;
            this.SecondaryContactDesignation = string.Empty;
            this.SecondaryContactEmailId = string.Empty;
            this.ApprovalLetterFileName = string.Empty;
            this.ApprovalLetterFilePath = string.Empty;
            this.UserName = string.Empty;
        }
        public int? VTDvendorId { get; set; }
        public int? UserId { get; set; }
        public int? UserLoginId { get; set; }
        public int? CompanyId { get; set; }
        public int? CorpStateId { get; set; }
        public int? CorpDistrictId { get; set; }
        public int? LocalStateId { get; set; }
        public int? LocalDistrictId { get; set; }
        public int? LocalBlockId { get; set; }
        public string CompanyName { get; set; }
        public string GSTNo { get; set; }
        public string ModelName { get; set; }
        public string PortNo { get; set; }
        public string CorpAddress { get; set; }
        public string CorpStateName { get; set; }
        public string CorpDistrictName { get; set; }
        public string CorpBlockName { get; set; }
        public string CorpPincode { get; set; }
        public string LocalAddress { get; set; }
        public string LocalStateName { get; set; }
        public string LocalDistrictName { get; set; }
        public string LocalBlockName { get; set; }
        public string LocalPincode { get; set; }
        public string PrimaryContactName { get; set; }
        public string PrimaryContactMobileNo { get; set; }
        public string PrimaryContactDesignation { get; set; }
        public string PrimaryContactEmailId { get; set; }
        public string SecondaryContactName { get; set; }
        public string SecondaryContactMobileNo { get; set; }
        public string SecondaryContactDesignation { get; set; }
        public string SecondaryContactEmailId { get; set; }
        public string ApprovalLetterFileName { get; set; }
        public string ApprovalLetterFilePath { get; set; }
        public string UserName { get; set; }
        public List<EditVTDUserModelPortDetails> VTDUserModelPortDetails { get; set; }
        public IFormFile ApprovalLetter { get; set; }
        public string Transport_Dept_ApprovalLetter { get; set; }
        public string Transport_Dept_ApprovalLetter_Path { get; set; }
    }
    public class EditVTDUserModelPortDetails
    {
        public string ModelName { get; set; }
        public string PortNo { get; set; }
    }
}
