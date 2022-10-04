using System;
using System.Collections.Generic;
using System.Text;

namespace ReturnEF
{
    public class CostOfProduction_Annual
    {
        public int? CostOfProduction_Id { get; set; }
        public string Exploration { get; set; }
        public string Mining { get; set; }
        public string Beneficiation { get; set; }
        public string Over_headcost { get; set; }
        public string Depreciation { get; set; }
        public string Interest { get; set; }
        public string Royalty { get; set; }
        public string DMF { get; set; }
        public string NMET { get; set; }
        public string Taxes { get; set; }
        public string Dead_Rent { get; set; }
        public string Others { get; set; }
        public string Total { get; set; }
        public string Year { get; set; }
        public int? Flag1 { get; set; }
        public int? FinalSubmitFlag { get; set; }
        public bool certify { get; set; }
        public int? UserId { get; set; }
    }
}
