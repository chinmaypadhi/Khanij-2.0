// ***********************************************************************
//  Class Name               : FPOOrdermaster
//  Desciption               : Field Program Order Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 12 Feb 2021
// ***********************************************************************
using Microsoft.AspNetCore.Http;

namespace GeologyEF
{
    public class FPOOrdermaster
    {
        public int? FPO_Id { get; set; }
        public string FPO_Code { get; set; }
        public string FPO_Name { get; set; }
        public bool? IsDelete { get; set; }
        public int? CreatedBy { get; set; }
        public int? UserLoginId { get; set; }
        public string DateOfIssuance { get; set; }
        public string ExplorationSeason { get; set; }
        public string FPO_File { get; set; }
        public string FPO_Path { get; set; }
        public int? Approve_Status { get; set; }
        public string Remarks { get; set; }
        public string ApprovalStatus { get; set; }
        public string Creater_Remarks { get; set; }
        public string FPO_Creater_File { get; set; }
        public string FPO_Creater_Path { get; set; }
        public int? Srno { get; set; }
        public string Year { get; set; }    
        public string STATUS { get; set; }
        public bool? IsActive { get; set; }
        public int? IsApproved { get; set; }
        public IFormFile FPO_copy { get; set; }
    }
}
