using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermitEF
{
   public class PartyMasterModel
    {
        public int? SRNumber { get; set; }
        public int DOPartyId { get; set; }
        public int? DOPartyType { get; set; }
        public string DOPartyCode { get; set; }
        public int? KOPartyId { get; set; }
        public string KOPartyName { get; set; }
        public int? KOPartyUserType { get; set; }
        public string KOPartyTypeName { get; set; }
        public string KOPartyAddress { get; set; }
        public string OtherPartyName { get; set; }
        public int? OtherPartyUserType { get; set; }
        public string OtherPartyAddress { get; set; }
        public int? IsActive { get; set; }
    }

    public class SampleGradeModel
    {
        public int? SRNumber { get; set; }
        public int SampleBulkPermitId { get; set; }
        public int LesseeId { get; set; }
        public int BulkPermitId { get; set; }
        public decimal? SampleQty { get; set; }
        public int SampleGradeId { get; set; }
        public decimal? SampleBasicRate { get; set; }
        public int? IsPaymentDone { get; set; }
        public int? ActiveStatus { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public int IsSampleUpdate { get; set; }

        public string UpdatedSamplePermitAndGrade { get; set; }
        public string DipatchQty { get; set; }
        public string PermitGrade { get; set; }
        public string BulkPermitNo { get; set; }
        public string LesseeName { get; set; }
        public string MineralName { get; set; }
        public string MineralNature { get; set; }
        public string Updatedgrade { get; set; }
        public string UpdateGradeQty { get; set; }
        public string UpdateGradeDate { get; set; }
        public string UpdateGradeStatus { get; set; }
        public string PendingforUpdateGrade { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentDetails { get; set; }



    }
    public class AdvanceRegisterReport
    {
        public string SRNO { get; set; }
        public string LesseeCode { get; set; }
        public string LesseeName { get; set; }
        public string TotalAmount { get; set; }
        public string UsedAmount { get; set; }
        public string BalanceAmount { get; set; }
        public string PaymentHead { get; set; }
        public string AmountSource { get; set; }
        public string AmountUsed { get; set; }
        public string AmountStatus { get; set; }
        //public string Royalty { get; set; }
        //public string DMF { get; set; }
        //public string NMET { get; set; }
        //public string MonthlyPeriodicAmount { get; set; }
        //public string EnvironmentalCess { get; set; }
        //public string TCS { get; set; }


    }
}
