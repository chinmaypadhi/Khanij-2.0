using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userregistrationEF
{
    public class CancelVehiclePayment
    {
        public string paymentReqId { get; set; }
        public string PaymentType { get; set; }
        public int? UserId { get; set; }
    }
}
