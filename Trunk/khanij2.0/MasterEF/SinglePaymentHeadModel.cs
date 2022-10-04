using System;
using System.Collections.Generic;
using System.Text;

namespace MasterEF
{
    public class SinglePaymentHeadModel
    {

        public int? PaymentHeadId { get; set; }
        public int? PaymentTypeId { get; set; }
        public string PaymentType { get; set; }
        public string AccountType { get; set; }
        public int? DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string HeadOFAccount { get; set; }
        public string SBISchemeCode { get; set; }
        public string HDFCSchemeCode { get; set; }
        public string ICICISchemeCode { get; set; }
        public int? CreatedBy { get; set; }
        public int? IsDelete { get; set; }
        public string Status { get; set; } 
        public int? Check { get; set; }
    }

    public class PaymentHeadViewModel
    {
        public List<SinglePaymentHeadModel> objPaymentHead { get; set; } 
        public PaymentHeadViewModel()
        { 
            objPaymentHead = new List<SinglePaymentHeadModel>();
        }
    }
}
