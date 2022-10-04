using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpassEF.ViewModel
{
    public class PurchaserConsigneeViewModel
    {
        public PurchaserConsigneeViewModel()
        {
            this.BULKPERMITID = string.Empty;
            this.BULKPERMITNO = string.Empty;
            this.PAYABLEROYALTY = string.Empty;
            this.PAYMENTMODE = string.Empty;
            this.MINERALGRADE = string.Empty;
            this.MINERALNAME = string.Empty;
            this.MINERALNATURE = string.Empty;
            this.TOTALQTY = string.Empty;
            this.UNIT = string.Empty;
            this.RPTPBulkPermitId = string.Empty;
            this.MineralType = string.Empty;
            this.PENDINGQTY = string.Empty;
            this.DISPATCHEDQTY = string.Empty;
            this.BlockedQty = string.Empty;
            this.PermitAdjustedQty = string.Empty;            
            this.UserWiseId = 0;
        }
        public string RPTPBulkPermitId { get; set; }
        public string BULKPERMITID { get; set; }
        public string BULKPERMITNO { get; set; }
        public string PAYABLEROYALTY { get; set; }
        public string PAYMENTMODE { get; set; }
        public string MINERALGRADE { get; set; }
        public string MINERALNAME { get; set; }
        public string MINERALNATURE { get; set; }
        public string TOTALQTY { get; set; }
        public string UNIT { get; set; }
        public string MineralType { get; set; }
        public string PENDINGQTY { get; set; }
        public string DISPATCHEDQTY { get; set; }
        public string BlockedQty { get; set; }
        public string PermitAdjustedQty { get; set; }
        public int UserWiseId { get; set; }        

    }
}
