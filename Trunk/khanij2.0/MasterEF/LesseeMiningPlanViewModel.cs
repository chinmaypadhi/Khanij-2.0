// ***********************************************************************
//  Model Name               : LesseeMiningPlanViewModel
//  Desciption               : Lessee Mining Plan Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 01 August 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Data;

namespace MasterEF
{
    public class LesseeMiningPlanViewModel
    {
        public int? MiningPlanId { get; set; }
        public string MP_APPROVE_DATE { get; set; }
        public string MP_EXPIRY_DATE { get; set; }
        public string MP_VALID_FORM { get; set; }
        public string MP_VALID_TO { get; set; }
        public string MP_VALID_TO_INTIMATION { get; set; }
        public int? STATUS { get; set; }
        public int? CREATED_BY { get; set; }
        public List<MiningProductionModel> Product { get; set; }
        public string MP_APPROVAL_NO { get; set; }
        public int? UnitId { get; set; }
        public string YEAR { get; set; }
        public string PRODUCTIONS { get; set; }
        public decimal EC_APPROVED_CAPACITY { get; set; }
        public IFormFile SOM_Upload_Letter { get; set; }
        public string MP_SOM_FilePath { get; set; }
        public string MP_SOM_FileName { get; set; }
        public string SubResion { get; set; }
        public string SubApprove { get; set; }
        public string SubReject { get; set; }
        public DataTable dtMines { get; set; }
        public int? MINING_PLAN_ID { get; set; }
        public int? UserLoginId { get; set; }
        public string ModifyDate { get; set; }
        public string ModifyYear { get; set; }
        public string Remarks { get; set; }
        public string MineralTypeName { get; set; }
        public string MODIFIED_ON { get; set; }
        public int UNIT_ID { get; set; }
        public string UNITNAME { get; set; }
    }
}
