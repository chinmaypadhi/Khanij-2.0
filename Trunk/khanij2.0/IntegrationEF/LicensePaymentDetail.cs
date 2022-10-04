using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationEF
{
    public class LicensePaymentDetail
    {
        public int? LicenseAppId { get; set; }
        public int? UserId { get; set; }
        public int? UserLoginId { get; set; }
        public decimal? TotalPayment { get; set; }
        public string PaymentBank { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentRefId { get; set; }
    }
}
