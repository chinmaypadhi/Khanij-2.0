// ***********************************************************************
//  Model Name               : LesseeForestClearanceViewModel
//  Desciption               : Lessee Forest Clearance Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 27 July 2021
// ***********************************************************************
using System;
using Microsoft.AspNetCore.Http;

namespace MasterEF
{
    public  class LesseeForestClearanceViewModel
    {
        public int? FC_APPROVAL_ID { get; set; }
        public string FC_APPROVAL_NUMBER { get; set; }
        public string FC_APPROVAL_DATE { get; set; }
        public string VALID_FROM { get; set; }
        public string VALID_TO { get; set; }
        public string VALID_TO_INTIMATION { get; set; }
        public IFormFile FC_LETTER { get; set; }
        public string FC_LETTER_FILE_NAME { get; set; }
        public string FC_LETTER_FILE_PATH { get; set; }
        public int? STATUS { get; set; }
        public string Remarks { get; set; }
        public int? CREATED_BY { get; set; }
        public ProfileStatusModel objProfileStatus { get; set; }
        public string SubResion { get; set; }
        public string SubApprove { get; set; }
        public string SubReject { get; set; }
        public int? UserLoginId { get; set; }
        public string ModifyDate { get; set; }
        public string ModifyYear { get; set; }
    }
}
