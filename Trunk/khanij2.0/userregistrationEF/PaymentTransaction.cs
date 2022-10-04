using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userregistrationEF
{
    public class PaymentTransaction
    {
        public string strPGRESPONSE { get; set; }
        public string TXN_STATUS { get; set; }
        public string CLNT_TXT_Type { get; set; }
        public string CLNT_TXN_REF { get; set; }
        public string TPSL_BANK_CD { get; set; }
        public string TPSL_TXN_ID { get; set; }
        public string TXN_AMT { get; set; }
        public string TPSL_TXN_TIME { get; set; }
        public string PayableRoyalty { get; set; }
        public string TCS { get; set; }
        public string Cess { get; set; }
        public string eCess { get; set; }
        public string DMF { get; set; }
        public string NMET { get; set; }
        public string MonthlyPeriodicAmount { get; set; }
        //Mukesh RoyaltyWithAdditional150PerInclusion Modified 22-Oct-2021
        //Begin
        public string AdditionalAmount { get; set; }
        //End
        public string UserCode { get; set; }
        public string UserLogin { get; set; }
        public string PayMode { get; set; }
        public string GIBNo { get; set; }
        public string PaymentResponseID { get; set; }
        public int? UserId { get; set; }
    }
}
