using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermitEF
{
    //public class SampleGradeModel
    //{
    //    public int? SRNumber { get; set; }
    //    public int SampleBulkPermitId { get; set; }
    //    public int? LesseeId { get; set; }
    //    public int BulkPermitId { get; set; }
    //    public decimal? SampleQty { get; set; }
    //    public int SampleGradeId { get; set; }
    //    public decimal? SampleBasicRate { get; set; }
    //    public int? IsPaymentDone { get; set; }
    //    public int? ActiveStatus { get; set; }
    //    public int? CreatedBy { get; set; }
    //    public DateTime CreatedOn { get; set; }

    //    public int IsSampleUpdate { get; set; }

    //    public string UpdatedSamplePermitAndGrade { get; set; }
    //    public string DipatchQty { get; set; }
    //    public string PermitGrade { get; set; }
    //    public string BulkPermitNo { get; set; }
    //    public string LesseeName { get; set; }
    //    public string MineralName { get; set; }
    //    public string MineralNature { get; set; }
    //    public string Updatedgrade { get; set; }
    //    public string UpdateGradeQty { get; set; }
    //    public string UpdateGradeDate { get; set; }
    //    public string UpdateGradeStatus { get; set; }
    //    public string PendingforUpdateGrade { get; set; }
    //    public string PaymentStatus { get; set; }
    //    public string PaymentDetails { get; set; }
    //}
    public class RevisedPayableRoyaltyRate
    {
        public int? UserID { get; set; }
        public string UserType { get; set; }
        public int? MineralNatureId { get; set; }
        public int? MineralGradeId { get; set; }
        public int? MineralId { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? RoyaltyRate { get; set; }
        public int? BulkPermitId { get; set; }
        public decimal? AluminaContent { get; set; }
        public decimal? TinContent { get; set; }

    }
}
