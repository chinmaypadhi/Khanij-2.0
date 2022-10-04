// ***********************************************************************
//  Class Name               : BlockMaster
//  Description              : Add,View,Edit,Update,Delete Block Master details
//  Created By               : Lingaraj Dalai
//  Created On               : 25 Dec 2021
// ***********************************************************************

namespace MasterEF
{
    public class BlockMaster
    {
        public int? BlockId { get; set; }
        public string BlockName { get; set; }
        public int? StateId { get; set; }
        public string StateName { get; set; }
        public int? RegionalID { get; set; }
        public string RegionalName { get; set; }
        public int? DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int? UserLoginID { get; set; }
        public int? UserID { get; set; }
        public bool? IsActive { get; set; }
        public string ActiveStatus { get; set; }
    }
}
