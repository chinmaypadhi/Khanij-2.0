// ***********************************************************************
//  Model Name               : MiningProductionModel
//  Desciption               : FY Approved Quantity Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 01 August 2021
// ***********************************************************************

namespace MasterEF
{
    public class MiningProductionModel
    {
        public MiningProductionModel()
        {
            PRODUCTION = 0;
            YEAR = "";
            CREATED_BY = 0;
            UNIT_ID = 0;
            ModifyDate = "";
            ModifyYear = "";
            UNITNAME = "";
        }
        public int? PRODUCTION { get; set; }
        public string YEAR { get; set; }
        public int? CREATED_BY { get; set; }
        public int UNIT_ID { get; set; }
        public string STATUS { get; set; }
        public string ModifyDate { get; set; }
        public string ModifyYear { get; set; }
        public string UNITNAME { get; set; }
    }
}
