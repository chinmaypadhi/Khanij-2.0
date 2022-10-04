// ***********************************************************************
//  Model Name               : LesseeEnvironmentClearanceViewModel
//  Desciption               : Lessee Environment Clearance Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 30 July 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Http;

namespace MasterEF
{
    public class LesseeEnvironmentClearanceViewModel
    {
        public int LICENSEE_EC_ID { get; set; }
        public string Remarks { get; set; }
        public int? CREATED_BY { get; set; }
        public string EC_APPLICATION_NUMBER { get; set; }
        public string EC_APPLICATON_DATE { get; set; }
        public string EC_NUMBER { get; set; }
        public int APPROVED_BY { get; set; }
        public DateTime? APPROVED_ON { get; set; }
        public string EC_CLEARANCE_PATH { get; set; }
        public int? STATUS { get; set; }
        public string FILE_EC_CLEARANCE { get; set; }
        public IFormFile Env_Clearance_Letter { get; set; }
        #region lessee
        public string EC_ORDRER_NUMBER { get; set; }
        public string EC_VALID_FROM { get; set; }
        public string EC_VALID_TO { get; set; }
        public string VALID_TO_INTIMATION { get; set; }
        public decimal EC_APPROVED_CAPACITY { get; set; }
        public int? MineralId { get; set; }
        public string MineralName { get; set; }
        public decimal EC_MINERAL_QUANTITY { get; set; }
        #endregion
        public List<MiningProductionModel> Product { get; set; }
        public DataTable dtFYApprovedQuantity { get; set; }
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
        public string MODIFIED_ON { get; set; }
        public string YEAR { get; set; }
        public string PRODUCTIONS { get; set; }
        public int UNIT_ID { get; set; }
        public string UNITNAME { get; set; }
    }
}
