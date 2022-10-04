using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationEF
{
   public class Notice
    {
        public string OtherPaymentTypeName { get; set; }
        public string LesseeName { get; set; }
        public string GenerationDate { get; set; }
        public string OtherPaymentType { get; set; }
        public string arr { get; set; }
        public string totalPayableAmt { get; set; }
        public int ? UserId { get; set; }
        public string MineralTypeName { get; set; }
        public string Check { get; set; }
        public string PaymentType { get; set; }
        public string ArrtotalPayableAmt { get; set; }
        public int ? OtherPaymentAmount { get; set; }
        public int ? paymentIDs { get; set; }
        public string PaymentMode { get; set; }
        public string PMode { get; set; }
        public string NetBanking_mode { get; set; }
        public string PaymentBank { get; set; }
        public Boolean TotalPayableAmount { get; set; }

    }
    public class OtherPaymentModel
    {
        public int? OtherPaymentTypeID { get; set; }
        public string OtherPaymentTypeName { get; set; }
        public string OtherPaymentStatus { get; set; }
        public decimal? OtherPaymentAmount { get; set; }
        public string OtherPaymentBank { get; set; }
        public string OtherPaymentMode { get; set; }
        public string OtherPaymentDate { get; set; }
        public string OtherPaymentPoolAccountDate { get; set; }
        public string OtherPaymentTreasuryDate { get; set; }


        public string PaymentMode { get; set; }
        public string PaymentBank { get; set; }
        public string P_Mode { get; set; }
        public string NetBanking_mode { get; set; }


        public string LesseeName { get; set; }
        public string GenerationDate { get; set; }
        public string DeadRentFromTo { get; set; }
        public string AreaInHect { get; set; }
        public string NoOfYears { get; set; }
        public string perHectRate { get; set; }
        public string ToDateofDeadRentDate { get; set; }
        public string RoyaltyPaidDuringYear { get; set; }
        public string IntrestRateLable { get; set; }
        public string IntrestRate { get; set; }
        public decimal? OtherPaymentFinalAmount { get; set; }
        public string Flag { get; set; }






    }
}
