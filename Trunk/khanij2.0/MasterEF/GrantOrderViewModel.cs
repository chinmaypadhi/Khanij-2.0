// ***********************************************************************
//  Class Name               : GrantOrderViewModel
//  Description              : Lessee Grant Order Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 16 July 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Http;

namespace MasterEF
{
    public class GrantOrderViewModel
    {
        public int? GRANT_ORDER_ID { get; set; }
        public string GRANT_ORDER_NUMBER { get; set; }
        public string GRANT_ORDER_DATE { get; set; }
        public string FROM_VALIDITY { get; set; }
        public string TO_VALIDITY { get; set; }
        public string EXECUTION_OF_DEED_NUMBER { get; set; }
        public string EXECUTION_OF_DEED_DATE { get; set; }
        public string PATH_GRANT_ORDER_COPY { get; set; }
        public string FILE_GRANT_ORDER_COPY { get; set; }
        public IFormFile GRANT_ORDER_COPY { get; set; }
        public string PATH_EXECUTION_OF_DEED_COPY { get; set; }
        public string FILE_EXECUTION_OF_DEED_COPY { get; set; }
        public IFormFile EXECUTION_OF_DEED_COPY { get; set; }
        public int? STATUS { get; set; }
        public int? CREATED_BY { get; set; }
        public int? REJECTED_BY { get; set; }
        public int? APPROVED_BY { get; set; }
        public string LEASE_PERIOD { get; set; }
        public string Remarks { get; set; }
        public string VALIDITY_TO_INTIMATION { get; set; }
        public string SubResion { get; set; }
        public string SubApprove { get; set; }
        public string SubReject { get; set; }
        public int? UserId { get; set; }
        public int? UserLoginId { get; set; }
        public string ModifyDate { get; set; }
        public string ModifyYear { get; set; }
        public string MinesSection { get; set; }
        public string MinesAlloted { get; set; }
        public string MinesType { get; set; }
        public string MDPA_GRANT_ORDER_NUMBER { get; set; }
        public string MDPA_GRANT_ORDER_DATE { get; set; }
        public string MDPA_GRANT_AGREEMENT_DATE { get; set; }
        public string MDPA_PRODUCTION_QUANTITY { get; set; }
        public IFormFile GRANT_MDPA_COPY { get; set; }
        public string PATH_MDPA_COPY { get; set; }
        public string FILE_MDPA_COPY { get; set; }
        public int? AuctionTypeId { get; set; }
        public string LeaseExtender { get; set; }
        public string LEASEEXTENSION_FROM_VALIDITY { get; set; }
        public string LEASEEXTENSION_TO_VALIDITY { get; set; }
        public IFormFile LEASEEXTENSION_ORDER_COPY { get; set; }
        public string PATH_LEASEEXTENSION { get; set; }
        public string FILE_LEASEEXTENSION { get; set; }
        public string MineralSalePercentage { get; set; }
        public IFormFile ALLOTTMENT_ORDER_COPY { get; set; }
        public string PATH_ALLOTTMENT { get; set; }
        public string FILE_ALLOTTMENT { get; set; }
        public decimal? AllotmentAmount { get; set; }
        public string AuctionName {get;set;}
        public string PATH_DEMARCATION_COPY { get; set; }
        public string FILE_DEMARCATION_COPY { get; set; }
        public IFormFile DEMARCATION_COPY { get; set; }
        public string FINAL_OFFER { get; set; }
        public string MineralTypeName { get; set; }
        public string MineralName { get; set; }
        public List<MiningProductionModel> Product { get; set; }
        public string MODIFIED_ON { get; set; }
        public string YEAR { get; set; }
        public string PRODUCTIONS { get; set; }
        public int UNIT_ID { get; set; }
        public string UNITNAME { get; set; }
        public int IsMinesSection { get; set; }
        public string Mines_Section { get; set; }
        public DataTable dtFYApprovedQuantity { get; set; }
    }
}
