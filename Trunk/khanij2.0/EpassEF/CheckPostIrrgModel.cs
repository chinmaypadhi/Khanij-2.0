using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace EpassEF
{
    public class CheckPostIrrgModel
    {
        public int CheckPostIrrgularity_Id { get; set; }

        [Required(ErrorMessage = "Enter TransitPass no")]
        [Display(Name = "TransitPass no")]
        [StringLength(49, ErrorMessage = "TransitPass must be less than 50 characters")]
        public string TransitPassNo { get; set; }
        public string TransitPassNo1 { get; set; }
        public string TransitPassNo2 { get; set; }
        public string TransitPassNo3 { get; set; }

        [Required(ErrorMessage = "Enter TransitPass no")]
        [Display(Name = "TransitPass no")]
        [StringLength(49, ErrorMessage = "TransitPass must be less than 50 characters")]
        public string TransitPassNo4 { get; set; }

        public int? CheckPostId { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public string Type3 { get; set; }

        [Required(ErrorMessage = "Enter CheckPost Name")]
        [Display(Name = "CheckPost Name")]
        [StringLength(49, ErrorMessage = "CheckPost Name must be less than 50 characters")]
        public string CheckPostName { get; set; }

        [Required(ErrorMessage = "Enter Submit Date")]
        [Display(Name = "SubmitDate Name")]

        public DateTime? submitDate { get; set; }
        public DateTime? submitDate1 { get; set; }
        public DateTime? submitDate2 { get; set; }
        public DateTime? submitDate3 { get; set; }
        public DateTime? submitDate4 { get; set; }

        [Required(ErrorMessage = "Enter Permit Holder Name")]
        [Display(Name = "PermitHolder Name")]
        [StringLength(49, ErrorMessage = "PermitHolder Name must be less than 50 characters")]
        public string PermitHolderName { get; set; }
        public string PermitHolderName1 { get; set; }
        public string PermitHolderName3 { get; set; }
        public string PermitHolderName4 { get; set; }


        [Required(ErrorMessage = "Enter Permit Details")]
        [Display(Name = "Permit Details")]
        [StringLength(49, ErrorMessage = "Permit Details must be less than 50 characters")]
        public string PermitDetails { get; set; }
        public string PermitDetails1 { get; set; }
        public string PermitDetails3 { get; set; }
        public string PermitDetails4 { get; set; }



        [Required(ErrorMessage = "Enter Name Of Mineral")]
        [Display(Name = "Name Of Mineral")]
        [StringLength(49, ErrorMessage = "Name Of Mineral must be less than 50 characters")]
        public string MineralName { get; set; }
        public string MineralName1 { get; set; }
        public string MineralName2 { get; set; }
        public string MineralName3 { get; set; }
        public string MineralName4 { get; set; }

        public string MineralUnit { get; set; }

        [Required(ErrorMessage = "Enter Previous Gross Weight")]
        [Display(Name = "Previous Gross Weight")]
        public Decimal? GrossWeight { get; set; }
        public Decimal? GrossWeight1 { get; set; }
        public Decimal? GrossWeight2 { get; set; }
        public Decimal? GrossWeight3 { get; set; }
        public Decimal? GrossWeight4 { get; set; }

        [Required(ErrorMessage = "Enter Current Gross Weight")]
        [Display(Name = "Current Gross Weight")]
        public Decimal? CurrentGrossWeight { get; set; }
        public Decimal? CurrentGrossWeight1 { get; set; }
        public Decimal? CurrentGrossWeight2 { get; set; }
        public Decimal? CurrentGrossWeight3 { get; set; }
        public Decimal? CurrentGrossWeight4 { get; set; }

        [Required(ErrorMessage = "Enter Difference Weight")]
        [Display(Name = "Difference Weight")]
        public Decimal? DifferenceWeight { get; set; }
        public Decimal? DifferenceWeight1 { get; set; }
        public Decimal? DifferenceWeight2 { get; set; }
        public Decimal? DifferenceWeight3 { get; set; }
        public Decimal? DifferenceWeight4 { get; set; }

        [Required(ErrorMessage = "Enter Sale Value of Mineral")]
        [Display(Name = "Sale Value of Mineral")]
        [StringLength(49, ErrorMessage = "Sale Value of Mineral must be less than 50 characters")]
        public string SaleValueofMineral { get; set; }
        public string SaleValueofMineral1 { get; set; }
        public string SaleValueofMineral3 { get; set; }
        public string SaleValueofMineral4 { get; set; }

        [Required(ErrorMessage = "Enter Dispatche Date")]
        [Display(Name = "Dispatche Date")]

        public string DateOfDispatche { get; set; }
        public string DateOfDispatche1 { get; set; }
        public string DateOfDispatche2 { get; set; }
        public DateTime? DateOfDispatche3 { get; set; }
        public DateTime? DateOfDispatche4 { get; set; }


        [Required(ErrorMessage = "Enter Vehicle No")]
        [Display(Name = "Vehicle No")]
        [StringLength(49, ErrorMessage = "Vehicle No must be less than 50 characters")]
        public string VehicleNumber { get; set; }
        public string VehicleNumber1 { get; set; }
        public string VehicleNumber2 { get; set; }
        public string VehicleNumber3 { get; set; }
        public string VehicleNumber4 { get; set; }

        [Required(ErrorMessage = "Enter Vehicle Type")]
        [Display(Name = "Vehicle Type")]
        [StringLength(49, ErrorMessage = "Vehicle Type must be less than 50 characters")]
        public string VehicleTypeName { get; set; }
        public string VehicleTypeName1 { get; set; }
        public string VehicleTypeName2 { get; set; }
        public string VehicleTypeName3 { get; set; }
        public string VehicleTypeName4 { get; set; }

        [Required(ErrorMessage = "Enter Vehicle Owner")]
        [Display(Name = "Vehicle Owner")]
        [StringLength(49, ErrorMessage = "Vehicle Owner must be less than 50 characters")]
        public string TransporterName { get; set; }
        public string TransporterName1 { get; set; }
        public string TransporterName2 { get; set; }
        public string TransporterName3 { get; set; }
        public string TransporterName4 { get; set; }

        [Required(ErrorMessage = "EnterDriver Name")]
        [Display(Name = "Driver Name")]
        [StringLength(49, ErrorMessage = "Driver Name must be less than 50 characters")]
        public string DriverName { get; set; }
        public string DriverName1 { get; set; }
        public string DriverName2 { get; set; }
        public string DriverName3 { get; set; }
        public string DriverName4 { get; set; }

        [Required(ErrorMessage = "Enter Purchaser Name")]
        [Display(Name = "Purchaser Name")]
        [StringLength(49, ErrorMessage = "Purchaser Name must be less than 50 characters")]
        public string PurchaserName { get; set; }
        public string PurchaserName1 { get; set; }
        public string PurchaserName2 { get; set; }
        public string PurchaserName3 { get; set; }
        public string PurchaserName4 { get; set; }

        [Required(ErrorMessage = "Enter DO Number")]
        [Display(Name = "DO Number")]
        [StringLength(49, ErrorMessage = "DO Number must be less than 50 characters")]
        public string DONumber { get; set; }
        public string DONumber1 { get; set; }
        public string DONumber2 { get; set; }
        public string DONumber3 { get; set; }
        public string DONumber4 { get; set; }


        [Required(ErrorMessage = "Enter DO Date")]
        [Display(Name = "DO Date")]
        public DateTime? DODate { get; set; }
        public DateTime? DODate1 { get; set; }
        public DateTime? DODate2 { get; set; }
        public DateTime? DODate3 { get; set; }
        public DateTime? DODate4 { get; set; }


        [Required(ErrorMessage = "Enter Destination")]
        [Display(Name = "Destination")]
        [StringLength(49, ErrorMessage = "Destination must be less than 50 characters")]
        public string Destination { get; set; }
        public string Destination1 { get; set; }
        public string Destination2 { get; set; }
        public string Destination3 { get; set; }
        public string Destination4 { get; set; }

        //[Required(ErrorMessage = "Enter Route")]
        //[Display(Name = "Route")]
        //[StringLength(49, ErrorMessage = "Route must be less than 50 characters")]
        //public string Route { get; set; }
        //public string Route1 { get; set; }
        //public string Route2 { get; set; }
        //public string Route3 { get; set; }
        //public string Route4 { get; set; }

        [Required(ErrorMessage = "Remark")]
        [Display(Name = "Remark")]
        [StringLength(49, ErrorMessage = "Remark must be less than 200 characters")]
        public string Remark { get; set; }
        public string Remark1 { get; set; }
        public string Remark2 { get; set; }
        public string Remark3 { get; set; }
        public string Remark4 { get; set; }


        public string Attachment_Bayan { get; set; }
        public string Attachment_Bayan1 { get; set; }
        public string Attachment_Bayan2 { get; set; }
        public string Attachment_Bayan3 { get; set; }
        public string Attachment_Bayan4 { get; set; }

        public bool? IsActive { get; set; }

        public int? CaseIrregularity_Id1 { get; set; }
        public int? CaseIrregularity_Id2 { get; set; }
        public int? CaseIrregularity_Id3 { get; set; }
        public int? CaseIrregularity_Id4 { get; set; }
        public int? CaseIrregularity_Id5 { get; set; }
        [Required(ErrorMessage = "Enter Case Of Irregularity")]
        [Display(Name = "Case Of Irregularity")]
        [StringLength(49, ErrorMessage = "Case Of Irregularity must be less than 50 characters")]
        public string CaseOfIrregularity { get; set; }

        public int? UserId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UserLoginId { get; set; }
        public int? ConfirmStatus { get; set; }
        public IFormFile file1 { get; set; }
        public IFormFile file2 { get; set; }
        public IFormFile file3 { get; set; }
        public IFormFile file4 { get; set; }
        public IFormFile file5 { get; set; }


        public string EndUserName { get; set; }
        public string EndUserName1 { get; set; }
        public string EndUserName3 { get; set; }
        public string EndUserName4 { get; set; }

        public string BulkPermitNo { get; set; }
        public string BulkPermitNo1 { get; set; }
        public string BulkPermitNo2 { get; set; }

        public string Transportermode { get; set; }
        public string Transportermode1 { get; set; }
        public string Transportermode2 { get; set; }

        public string TareWeight { get; set; }
        public string TareWeight1 { get; set; }
        public string TareWeight2 { get; set; }

        public string TareTime { get; set; }

        public decimal? NetWeight { get; set; }
        public decimal? NetWeight1 { get; set; }
        public decimal? NetWeight2 { get; set; }

        public string RouteName { get; set; }
        public string RouteName1 { get; set; }
        public string RouteName3 { get; set; }
        public string RouteName4 { get; set; }


        public string MineralGrade { get; set; }
        public string MineralGrade1 { get; set; }

        public string Address { get; set; }
        public string AverageSalePrice { get; set; }
        public int DistrictId { get; set; }

        public string DistrictName { get; set; }
        public string DistrictName1 { get; set; }
        public string DistrictName2 { get; set; }

        public string AreaDetails { get; set; }
        public string AreaDetails1 { get; set; }
        public string AreaDetails2 { get; set; }
        public string AreaDetails3 { get; set; }
        public string AreaDetails4 { get; set; }


        public decimal? AreaHect { get; set; }
        public decimal? AreaHect1 { get; set; }

        public string DriverAddress { get; set; }
        public string MobileNo { get; set; }
        public string RailWayReceipt { get; set; }
        public string RailwaysidingName { get; set; }
        public string TransporterMobileNo { get; set; }
        public string TrasporterAddress { get; set; }
        public string ApplicantName { get; set; }
        public string ApplicantAddress { get; set; }
        public string ApplicantMobileNo { get; set; }
        public string LoadingTime { get; set; }

        public string LeaseValidity { get; set; }
        public string LeaseValidity1 { get; set; }
    }
}