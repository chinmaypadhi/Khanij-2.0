// ***********************************************************************
//  Model Name               : LesseeCTOViewModel
//  Desciption               : Lessee Consent To Operate Details class
//  Created By               : Lingaraj Dalai
//  Created On               : 29 July 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Http;

namespace MasterEF
{
    public class LesseeCTOViewModel
    {
        #region CTO
        public int? CTO_ID { get; set; }
        public string CTO_ORDER_NO { get; set; }
        public string CTO_VALID_FROM { get; set; }
        public string CTO_VALID_TO { get; set; }
        public string CTO_Order_Date { get; set; }
        public string CTO_VALID_TO_INTIMATION { get; set; }
        public DateTime APPROVED_ON { get; set; }
        public string CTO_LETTER_PATH { get; set; }
        public int LICENSEE_ID { get; set; }
        public string Remarks { get; set; }
        public string FILE_CTO_LETTER { get; set; }
        public int? CREATED_BY { get; set; }
        public IFormFile CTO_FORM_UPLOAD { get; set; }
        public int? STATUS { get; set; }
        public LesseeCTOViewModel()
        {
            CTO_VALID_FROM = null;
            CTO_VALID_TO = null;
        }
        public List<MiningProductionModel> Product { get; set; }
        public DataTable dtFYApprovedQuantity { get; set; }
        #endregion
        public string SubResion { get; set; }
        public string SubApprove { get; set; }
        public string SubReject { get; set; }
        public string DSCResponse { get; set; }
        public string Action_Transfer { get; set; }
        public string Action_Approve { get; set; }
        public string Action_Reject { get; set; }
        public decimal? CTO_QUANTITY { get; set; }
        public int? UserLoginId { get; set; }
        public string ModifyDate { get; set; }
        public string ModifyYear { get; set; }
        public string MODIFIED_ON { get; set; }
        public string YEAR { get; set; }
        public string PRODUCTIONS { get; set; }
        public int UNIT_ID { get; set; }
        public string UNITNAME { get; set; }
    }
}
