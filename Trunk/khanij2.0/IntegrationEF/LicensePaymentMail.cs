using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationEF
{
    public class LicensePaymentMail
    {
        public string PaymentReceiptID { get; set; }
        public string EmailID { get; set; }
        public string ForwardDate { get; set; }
        public string TransactionId { get; set; }
        public string ApplicantName { get; set; }
        public string PaymentType { get; set; }
        public string PayableAmount { get; set; }
        public string EMAIL_SENT { get; set; }
        public int? UserId { get; set; }
    }
}
