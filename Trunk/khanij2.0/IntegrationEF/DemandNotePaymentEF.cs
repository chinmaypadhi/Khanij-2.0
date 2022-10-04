using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationEF
{
    public class DemandNotePaymentEF
    {
        public int UserLoginId { get; set; }
        public decimal TotalPaidAmount { get; set; }
        public decimal TotalIntersetCalc { get; set; }
        public decimal PayableRoyalty { get; set; }
        public decimal iCess { get; set; }
        public decimal eCess { get; set; }
        public decimal INT_PayableRoyalty { get; set; }
        public decimal INT_DMF { get; set; }
        public decimal INT_NMET { get; set; }
        public decimal INT_TCS { get; set; }
        public decimal INT_iCess { get; set; }
        public decimal INT_eCess { get; set; }
        public decimal INT_monthlyPeriodicAmount { get; set; }
        public decimal TotalAmount { get; set; }

        public int? UserId { get; set; }
        public string DemandNoteCode { get; set; }
        public string TransactionalID { get; set; }
        public decimal DMF { get; set; }
        public decimal NMET { get; set; }
        public decimal TCS  { get; set; }
        public decimal Infrastructure_Development_Cess { get; set; }
        public decimal Environmental_Cess { get; set; }
        public decimal TotalPayableAmount { get; set; }
        public decimal Monthly_Periodic_Amount { get; set; }
        public decimal DemandNoteIntersetRate { get; set; }
        public int? differnceDays { get; set; }
        public int? TotalDaysPassed { get; set; }
        public string DemandYear { get; set; }
        public string arr { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentBank { get; set; }
        public string PMode { get; set; }
        public string NetBanking_mode { get; set; }





        public string RequestType { get; set; }
        public string MERCHANTCODE { get; set; }
        public string ErrorFile { get; set; }
        public string PropertyPath { get; set; }
        public string LogFilePath { get; set; }
        public string BankCode { get; set; }
        public string CustomerName { get; set; }
        public string UserMobileNumber { get; set; }
        public string UserEmail { get; set; }
        public string TXNDATE { get; set; }
        public string TPSLTXNID { get; set; }
        public string Amount { get; set; }
        public string Shoppingcartdetails { get; set; }
        public string ICICI { get; set; }
        public string MappingValue { get; set; }
        public string ITC { get; set; }
        public string MerchantTxnRefNumber { get; set; }
        public string UNIQUECUSTOMERID { get; set; }
        public string USEREMAIL { get; set; }
        public string USERMOBILENUMBER { get; set; }
        public string BANKCODE { get; set; }


     

    }

    public class PaymentDetailsQmultiple
    {
        public List<DemandNotePaymentEF> PaymentHeadList { get; set; }
        public List<DemandNotePaymentEF> PaymentDetailsList { get; set; }

    }
}
