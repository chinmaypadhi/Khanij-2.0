using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpassEF
{
    public class ValidityExpiredEF
    {
        public int BulkPermitId { get; set; }
        public int UserID { get; set; }
        public string TotalECApprovedQty { get; set; }
        public string ECApprovedQuantity { get; set; }
        public string TotalMiningProductionQty { get; set; }
        public string Production { get; set; }
        public string ECValidity { get; set; }
        public string MPValidity { get; set; }
        public string MiningValidity { get; set; }
        public string LeaseValidity { get; set; }
        public string TotalDispatched { get; set; }
        public string TPStoppedReason { get; set; }
    }
}
