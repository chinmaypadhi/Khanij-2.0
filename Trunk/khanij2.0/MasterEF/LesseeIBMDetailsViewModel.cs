// ***********************************************************************
//  Model Name               : LesseeIBMDetailsViewModel
//  Desciption               : Lessee IBM Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 26 July 2021
// ***********************************************************************
using System;
using Microsoft.AspNetCore.Http;

namespace MasterEF
{
    public class LesseeIBMDetailsViewModel
    {
        public int? CREATED_BY { get; set; }
        public string Remarks { get; set; }
        public int? LICENSEE_IBM_ID { get; set; }
        #region IBM
        public string IBM_APPLICATION_NUMBER { get; set; }
        public string IBM_APPLICATON_DATE { get; set; }
        public DateTime? APPROVED_ON { get; set; }
        public string IBM_REGISTRATION_FORM_PATH { get; set; }
        public string FILE_IBM_REGISTRATION_FORM { get; set; }
        public IFormFile IBM_REGISTRATION_FORM { get; set; }
        public string IBM_NUMBER { get; set; }
        public int? STATUS { get; set; }
        public string IBM_REGISTRATION_NUMBER { get; set; }
        #endregion
        public string SubResion { get; set; }
        public string SubApprove { get; set; }
        public string SubReject { get; set; }
        public string DSCResponse { get; set; }
        public string Action_Transfer { get; set; }
        public string Action_Approve { get; set; }
        public string Action_Reject { get; set; }
        public int? UserLoginId { get; set; }
        public string ModifyDate { get; set; }
        public string ModifyYear { get; set; }
    }
}
