// ***********************************************************************
//  Model Name               : LesseeCTEViewModel
//  Desciption               : Lessee Consent To Establish Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 28 July 2021
// ***********************************************************************
using System;
using Microsoft.AspNetCore.Http;

namespace MasterEF
{
    public class LesseeCTEViewModel
    {
        #region CTE
        public int? CTE_ID { get; set; }
        public string CTE_ORDER_NO { get; set; }
        public string CTE_VALID_FROM { get; set; }
        public string CTE_VALID_TO { get; set; }
        public string CTE_Order_Date { get; set; }
        public string CTE_VALID_TO_INTIMATION { get; set; }
        public DateTime APPROVED_ON { get; set; }
        public string CTE_LETTER_PATH { get; set; }
        public int LICENSEE_ID { get; set; }
        public string FILE_CTE_LETTER { get; set; }
        public IFormFile CTE_FORM_UPLOAD { get; set; }
        public int? STATUS { get; set; }
        public int? CREATED_BY { get; set; }
        public string Remarks { get; set; }
        public LesseeCTEViewModel()
        {
            CTE_VALID_FROM = null;
            CTE_VALID_TO = null;
        }
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
