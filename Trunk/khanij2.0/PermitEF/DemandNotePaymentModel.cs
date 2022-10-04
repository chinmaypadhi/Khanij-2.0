using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermitEF
{
    public class DemandNotePaymentModel
    {
        public int? DemandNoteId { get; set; }
        public string Status { get; set; }
        public string BulkPermitNo { get; set; }
        public string TransitPassNo { get; set; }
        public string MappingValue { get; set; }
        public decimal DemandNoteQty { get; set; }
        public string LesseeName { get; set; }
        public int? PassId { get; set; }
        public string PassNumber { get; set; }
        public int? PermitId { get; set; }
        public string PermitNumber { get; set; }
        public int? RoylatyId { get; set; }
        public decimal RoylatyRate { get; set; }

        public string IsPaymentDone { get; set; }
        #region FINAL PART
        public decimal PayableRoyalty { get; set; }
        public decimal DMF { get; set; }
        public decimal NMET { get; set; }
        public decimal MonthlyPeriodicAmount { get; set; }
        public decimal TotalPayableAmount { get; set; }
        public decimal TCS { get; set; }
        public decimal iCess { get; set; }
        public decimal eCess { get; set; }
        public decimal ShallBePaidLater { get; set; }
        #endregion

        #region OLD PART
        public decimal OldRoyaltyRate { get; set; }
        public decimal OLDPayableRoyalty { get; set; }
        public decimal OLDDMF { get; set; }
        public decimal OLDNMET { get; set; }
        public decimal OLDMonthlyPeriodicAmount { get; set; }
        public decimal OLDTotalPayableAmount { get; set; }
        public decimal OLDTCS { get; set; }
        public decimal OLDiCess { get; set; }
        public decimal OLDeCess { get; set; }
        public decimal OLDShallBePaidLater { get; set; }
        #endregion

        #region NEW PART
        public decimal NEWPayableRoyalty { get; set; }
        public decimal NEWDMF { get; set; }
        public decimal NEWNMET { get; set; }
        public decimal NEWMonthlyPeriodicAmount { get; set; }
        public decimal NEWTotalPayableAmount { get; set; }
        public decimal NEWTCS { get; set; }
        public decimal NEWiCess { get; set; }
        public decimal NEWeCess { get; set; }
        public decimal NEWShallBePaidLater { get; set; }
        #endregion
        public string PaymentStatus { get; set; }
        public string MineralName { get; set; }
        public string UnitName { get; set; }
        public string MineralForm { get; set; }
        public string MineralGrade { get; set; }

        public int? DistrictId { get; set; }
        public string DistrictName { get; set; }
    }
    public class objDemandListData
    {
        public List<DemandNoteCodePayment> objDemandListDataVal { get; set; }
        public int? UserID { get; set; }
    }
    public class DemandNoteCodePayment
    {
        public string Payment_Transaction_Details { get; set; }
        public string DistrictName { get; set; }

        public int? UserID { get; set; }
        public string UserName { get; set; }
        public string ApplicantName { get; set; }

        public string DemandNoteCode { get; set; }
        public string DemandDate { get; set; }
        public string FromDate { get; set; }
        public DateTime FromDatee { get; set; }
        public string ToDate { get; set; }
        public DateTime ToDatee { get; set; }

        public string PaymentStatus { get; set; }

        public int PaymentOption { get; set; }

        public string PayableRoyalty { get; set; }
        public string DMF { get; set; }
        public string NMET { get; set; }
        public string Monthly_Periodic_Amount { get; set; }
        public string TotalPayableAmount { get; set; }

        public string TCS { get; set; }
        public string Infrastructure_Development_Cess { get; set; }
        public string Environmental_Cess { get; set; }
        public string ShallBePaidLater { get; set; }

        public string FilePath { get; set; }
        public string IsVerify { get; set; }
        public string IsPaymentDone { get; set; }
    }
    public class CreditAmountModel
    {
        public int? CreditAmountId { get; set; }
        public int? SrNo { get; set; }
        //[Required(ErrorMessage = "Select Payment Type")]
        public int? PaymentTypeHeadId { get; set; }
        public string PaymentTypeHeadName { get; set; }
        public string UserName { get; set; }
        public string MannualCreditID { get; set; }
        public string PaymentHeadTypeID { get; set; }
        public string AssesmentHead { get; set; }
        //[Required(ErrorMessage = "Select Lessee")]
        public int? LesseeId { get; set; }
        public string LesseeName { get; set; }
        //[Required(ErrorMessage = "Credit Amount Required")]
        public decimal? CreditAmount { get; set; }
        public string AssessmentCopyName { get; set; }
        public string AssessmentCopyPath { get; set; }
        public string CreditedAmmount { get; set; }
        public string Status { get; set; }
        public string FileName { get; set; }
        public int? UserId { get; set; }
        public int? UserLoginId { get; set; }
        public int? PaymentTypeId { get; set; }
        public string PaymentType { get; set; }
        public string ApplicantName { get; set; }

    }
    public class CreditAmountData
    {
        public int PaymentType { get; set; }
        public int LesseeName { get; set; }
        public string txtCreditAmount { get; set; }
        public string UploadCopy { get; set; }
        public string UploadPath { get; set; }

    }


}
