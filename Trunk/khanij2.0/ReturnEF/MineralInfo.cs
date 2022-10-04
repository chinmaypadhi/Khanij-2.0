using System;
using System.Collections.Generic;
using System.Text;

namespace ReturnEF
{
    public class MineralInfo
    {
        public int MineralID { get; set; }
        public string MineralName { get; set; }
        public int MineralNatureId { get; set; }
        public string MineralNature { get; set; }
        public string NatureOfDispatch { get; set; } 
        public int PurchaserConsigneeId { get; set; }
        public string Consignee { get; set; }
    }
}
