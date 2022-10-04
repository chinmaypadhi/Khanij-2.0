using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpassEF.ViewModel
{
    public class PurchaserConsigneeByPermitIdViewModel
    {
        public PurchaserConsigneeByPermitIdViewModel()
        {
            this.Destination = string.Empty;
            this.BulkPermitNo = string.Empty;
            this.PurchaserConsigneeName = string.Empty;
            this.TransportationMode = string.Empty;
            this.RouteName = string.Empty;
            this.CheckPostName = string.Empty;
            this.RCR_RTP_BY = string.Empty;
            
        }
        public int PCId { get; set; }
        public string PurchaserConsigneeName { get; set; }
        public int? BulkPermitId { get; set; }
        public string BulkPermitNo { get; set; }
        public string Destination { get; set; }
        public string TransportationMode { get; set; }
        public string RouteName { get; set; }
        public string CheckPostName { get; set; }
        public string RCR_RTP_BY { get; set; }

    }
}
