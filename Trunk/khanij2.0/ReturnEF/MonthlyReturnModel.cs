using System;
using System.Collections.Generic;
using System.Text;

namespace ReturnEF
{
    public class MonthlyReturnModelNonCoal
    {
        public int? Months { get; set; }
        public int? Years { get; set; }

        public int? Uid { get; set; }
        public string MonthYear { get; set; }
        public string Year { get; set; }
        public string Status { get; set; }
        public string ModifiedOn { get; set; }
        public string FormType { get; set; }
        public int? MineralId { get; set; }
        public string MineralName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }

        public int? MineralNatureId { get; set; }
        public string MineralNature { get; set; }

        public int? MineralGradeID { get; set; }
        public string MineralGrade { get; set; }
        public string ServerPath { get; set; }
        public int? ID { get; set; }

        public string UpdateIn { get; set; }
        public string EncryptedId { get; set; }
    }
    public class DDLResult
    {
        public List<MonthlyReturnModelNonCoal> GetDDL { get; set; }
    }
    public class GetFormF1DetailsModel
    {
        public int? Details_Id { get; set; }
        public int? Work_Id { get; set; }
        public List<int> intwork { get; set; }

        public List<int> intNoOfDaysWorkStop { get; set; }

        public List<string> strReason { get; set; }

        public int? Wages_Id { get; set; }
        public int? UserID { get; set; }

        public string Registrationnumber { get; set; }
        public string FormType { get; set; }
        public string ReturnType { get; set; }
        //[Required(ErrorMessage = "Please select Month")]
        public string Month_Year { get; set; }
        public string MINE_CODE { get; set; }
        public int MineralID { get; set; }
        public string MineralName { get; set; }
        public string OtherMineral { get; set; }
        public string MineName { get; set; }

        public string MineAddress { get; set; }
        public string MineVillage { get; set; }
        public string MineDistrict { get; set; }
        public string MineState { get; set; }
        public string MineTehsil { get; set; }

        //[Required(ErrorMessage = "Pincode required")]
        public string MinePinCode { get; set; }
        public string MinePostOffice { get; set; }
        //[RegularExpression(@"^[0-9]*$", ErrorMessage = "Enter Digit only")]//Allowed only numbers
        //[Display(Name = "Fax No")]
        public string MineFaxNo { get; set; }
        public string MineEmailID { get; set; }
        public string MineMobileNo { get; set; }
        public string MinePhoneNo { get; set; }
        public string LesseeName { get; set; }
        public string LesseeAddress { get; set; }
        public string LesseeVillageName { get; set; }
        public string LesseeDistrictName { get; set; }
        public string LesseePostOffice { get; set; }
        public string LesseeStateName { get; set; }
        public string LesseeTehsilName { get; set; }
        //[Required(ErrorMessage = "Pincode required")]
        public string LesseePinCode { get; set; }
        //[RegularExpression(@"^[0-9]*$", ErrorMessage = "Enter Digit only")]//Allowed only numbers
        //[Display(Name = "Fax No")]
        public string LesseeFaxNo { get; set; }
        public string LesseeEmailID { get; set; }
        public string LesseeMobileNo { get; set; }
        public string LesseePhoneNo { get; set; }
        //[Required(ErrorMessage = "Please Enter Paid Rent")]
        public string Rentpaid { get; set; }
        public decimal? Royaltypaid { get; set; }
        //[Required(ErrorMessage = "Please Enter Dead Paid Rent")]
        public string DeadRentpaid { get; set; }
        public decimal? DMFPaid { get; set; }
        public decimal? NMETPaid { get; set; }


        public string DSCFilePath { get; set; }


        //[RegularExpression(@"^[0-9]*$", ErrorMessage = "Enter numbers only")]//Allowed only numbers
        //[Display(Name = "No Of Days")]
        // [Required(ErrorMessage = "No Of Days required")]
        public int? NoOfDaysMineWork { get; set; }

        public List<Working_of_Mine> MineWork { get; set; }


        //[RegularExpression(@"^[0-9]*$", ErrorMessage = "Enter numbers only")]//Allowed only numbers
        //[Display(Name = "No Of Days")]
        // [Required(ErrorMessage = "No Of Days Mine Stop required")]
        public int? NoOfDaysWorkStop { get; set; }

        // [Required(ErrorMessage = "Please Enter Reason for Mine Stop")]
        public string Reason { get; set; }

        public string WorkPlace1 { get; set; }
        // [Required(ErrorMessage = "Required")]
        //[RegularExpression(@"^[0-9]*$", ErrorMessage = "Enter Digit only")]
        public decimal? DirectMale1 { get; set; }
        // [Required(ErrorMessage = "Required")]
        public decimal? DirectFemale1 { get; set; }
        //  [Required(ErrorMessage = "Required")]
        public decimal? ContractMale1 { get; set; }
        //  [Required(ErrorMessage = "Required")]
        public decimal? ContractFemale1 { get; set; }


        public string WorkPlace2 { get; set; }
        //  [Required(ErrorMessage = "Required")]
        public decimal? DirectMale2 { get; set; }
        //  [Required(ErrorMessage = "Required")]
        public decimal? DirectFemale2 { get; set; }
        //  [Required(ErrorMessage = "Required")]
        public decimal? ContractMale2 { get; set; }
        //  [Required(ErrorMessage = "Required")]
        public decimal? ContractFemale2 { get; set; }



        public string WorkPlace3 { get; set; }
        // [Required(ErrorMessage = "Required")]
        public decimal? DirectMale3 { get; set; }
        //  [Required(ErrorMessage = "Required")]
        public decimal? DirectFemale3 { get; set; }
        // [Required(ErrorMessage = "Required")]
        public decimal? ContractMale3 { get; set; }
        // [Required(ErrorMessage = "Required")]
        public decimal? ContractFemale3 { get; set; }


        public decimal? BGTotalMale { get; set; }
        public decimal? BGTotalFemale { get; set; }
        public decimal? OCTotalMale { get; set; }
        public decimal? OCTptalFemale { get; set; }
        public decimal? AGTotalMale { get; set; }
        public decimal? AGTotalFemale { get; set; }

        //[Required(ErrorMessage = "Required")]
        public decimal? TotalWagesMale1 { get; set; }
        //[Required(ErrorMessage = "Required")]
        public decimal? TotalWagesMale2 { get; set; }
        // [Required(ErrorMessage = "Required")]
        public decimal? TotalWagesMale3 { get; set; }
        //  [Required(ErrorMessage = "Required")]
        public decimal? TotalWagesFeMale1 { get; set; }
        // [Required(ErrorMessage = "Required")]
        public decimal? TotalWagesFeMale2 { get; set; }
        //  [Required(ErrorMessage = "Required")]
        public decimal? TotalWagesFeMale3 { get; set; }

        public decimal? TotalDirectMale { get; set; }
        public decimal? TotalDirectFemale { get; set; }
        public decimal? TotalContractMale { get; set; }
        public decimal? TotalContractFemale { get; set; }
        public decimal? TotalMaleWages { get; set; }
        public decimal? TotalFeMaleWages { get; set; }
        public string DistrictName { get; set; }
        public int Flag { get; set; }
        //---------------------------------------

        public string TypeOfProduction { get; set; }
        public decimal? OpeningStockCw { get; set; }
        public decimal? OpeningStockUW { get; set; }
        public decimal? OpeningStockDW { get; set; }

        public decimal? ProductionCW { get; set; }
        public decimal? ProductionUW { get; set; }
        public decimal? ProductionDW { get; set; }

        public decimal? ClosingStockCW { get; set; }
        public decimal? ClosingStockUW { get; set; }
        public decimal? ClosingStockDW { get; set; }

        public string Amount1 { get; set; }
        public string Amount2 { get; set; }
        public string Amount3 { get; set; }
        public string Amount4 { get; set; }
        public string Amount5 { get; set; }
        public string Amount6 { get; set; }
        public string Amount7 { get; set; }

        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
        public string Remarks3 { get; set; }
        public string Remarks4 { get; set; }
        public string Remarks5 { get; set; }
        public string Remarks6 { get; set; }
        public string Remarks7 { get; set; }

        public string TotalAmount { get; set; }
        public string productionIncrDecResion { get; set; }
        public string ex_minepriceIncrDecResion { get; set; }

        public decimal? Averagecostofpulverization { get; set; }
        public bool certify { get; set; }

        public string SubmitDate { get; set; }
        //---------------------------------------
        public GetFormF1DetailsModel()
        {
            Flag = 0;
        }
    }
    public class Working_of_Mine
    {
        public Working_of_Mine()
        {
            Work_Id = 0;
            NoOfDaysWorkStop = 0;
            Reason = "";
            CREATED_BY = 0;

        }
        public int? Work_Id { get; set; }
        //[RegularExpression(@"^[0-9]*$", ErrorMessage = "Enter numbers only")]//Allowed only numbers
        //[Display(Name = "No Of Days")]
        //[Required(ErrorMessage = "No Of Days Mine Stop required")]
        public int? NoOfDaysWorkStop { get; set; }

        // [Required(ErrorMessage = "Please Enter Reason for Mine Stop")]
        public string Reason { get; set; }
        public int? CREATED_BY { get; set; }
    }
    public class GetRentRoyaltyDetailsModel
    {
        public decimal? Royaltypaid { get; set; }
        public decimal? DMFPaid { get; set; }
        public decimal? NMETPaid { get; set; }

    }

    public class MonthlyPartTwoViewModel
    {
        public ProductionModel_Monthly objProduction { get; set; }
        public Details_of_deductions_Monthly objDeduction { get; set; }
        public Reason_Inc_Dec_Monthly objReason_Inc_Dec { get; set; }

        public Gradewise_ROMModel objGradewise_ROMModel { get; set; }
        public Grade_WiseProduction objGrade_WiseProduction { get; set; }
        public SalesDispatchModel objSalesDispatchModel { get; set; }

        public Mineral_PulverizedModel ObjMineral_PulverizedModel { get; set; }
        public MonthlyPartTwoViewModel()
        {
            objProduction = new ProductionModel_Monthly();
            objDeduction = new Details_of_deductions_Monthly();
            objReason_Inc_Dec = new Reason_Inc_Dec_Monthly();
            objGradewise_ROMModel = new Gradewise_ROMModel();
            objGrade_WiseProduction = new Grade_WiseProduction();
            objSalesDispatchModel = new SalesDispatchModel();
            ObjMineral_PulverizedModel = new Mineral_PulverizedModel();
        }
    }
    public class Mineral_PulverizedModel
    {
        public int Pulverization_id { get; set; }
        public int UId { get; set; }

        public int? MineralNatureId7 { get; set; }
        public string MineralNature { get; set; }

        public int? MineralGradeId7 { get; set; }
        public string MineralGrade { get; set; }

        public decimal? Total_Qty_Mineral_Pulverization { get; set; }

        public string Pulverized_MeshSize { get; set; }

        public decimal? Pulverized_Qty { get; set; }

        public string Produced_MeshSize { get; set; }

        public decimal? Produced_Qty { get; set; }
        public decimal? Produced_Ex_factory_Sale_value { get; set; }
        public string Month_YearPulverization { get; set; }
        public int IsActive { get; set; }
    }
    public class SalesDispatchModel
    {
        public int Sale_Dispatch_Id { get; set; }
        public int UId { get; set; }
        public int? MineralNatureId6 { get; set; }
        public string MineralNature { get; set; }

        public int? MineralGradeId6 { get; set; }
        public string MineralGrade { get; set; }

        public string NatureofDispatch { get; set; }
        //[Required(ErrorMessage = "Enter Registration No")]
        public string RegistrationNo { get; set; }

        public int? PurchaserConsineeId { get; set; }
        //[Required(ErrorMessage = "Select Purchaser Consinee")]
        public string PurchaserConsinee { get; set; }
        //[Required(ErrorMessage = "Enter Quantity")]
        public decimal? DomesticPurposes_Quantity { get; set; }
        //[Required(ErrorMessage = "Enter Sales Value")]
        public decimal? SaleValue { get; set; }
        //[Required(ErrorMessage = "Enter Country")]
        public string Country { get; set; }
        // [Required(ErrorMessage = "Enter Quantity")]
        public decimal? Export_Quantity { get; set; }
        // [Required(ErrorMessage = "Enter FOB Value")]
        public string FOBValue { get; set; }
        public string Month_YearSalesDispatch { get; set; }
        public int IsActive { get; set; }

        public string MonthYear { get; set; }
        public int? MineralId { get; set; }
    }
    public class ProductionModel_Monthly
    {
        public int? MineralId1 { get; set; }
        public int? UID { get; set; }
        public int? TypeOfProduction_Id { get; set; }
        public string TypeofOreProduced { get; set; }

        public decimal? OpeningStockOCW { get; set; }
        public decimal? productionOCW { get; set; }
        public decimal? closingOCW { get; set; }

        public decimal? OpeningStockUW { get; set; }
        public decimal? productionUW { get; set; }
        public decimal? closingUW { get; set; }

        public decimal? OpeningStockDW { get; set; }
        public decimal? productionDW { get; set; }
        public decimal? closingDW { get; set; }
        public int? Flag1 { get; set; }
        public string Month_Year { get; set; }
        public bool Hematite { get; set; }
        public bool Magnetite { get; set; }



    }

    public class Details_of_deductions_Monthly
    {
        public int? DeductionMade_Id { get; set; }
        public int? MineralId { get; set; }

        public int? UID { get; set; }
        public int? Average_Id { get; set; }
        //public int? MineralNatureId { get; set; }
        public string Averagecostofpulverization { get; set; }
        public string Deduction_claimedType1 { get; set; }
        public string Deduction_claimedType2 { get; set; }
        public string Deduction_claimedType3 { get; set; }
        public string Deduction_claimedType4 { get; set; }
        public string Deduction_claimedType5 { get; set; }
        public string Deduction_claimedType6 { get; set; }
        public string Deduction_claimedType7 { get; set; }
        public string Amount1 { get; set; }
        public string Amount2 { get; set; }
        public string Amount3 { get; set; }
        public string Amount4 { get; set; }
        public string Amount5 { get; set; }
        public string Amount6 { get; set; }
        public string Amount7 { get; set; }
        public string Remarks1 { get; set; }
        public string Remarks2 { get; set; }
        public string Remarks3 { get; set; }
        public string Remarks4 { get; set; }
        public string Remarks5 { get; set; }
        public string Remarks6 { get; set; }
        public string Remarks7 { get; set; }
        public string TotalAmount { get; set; }
        public int? Flag2 { get; set; }
        public int? PFlag { get; set; }
        public string Month_Year { get; set; }

        public string CExMineSale { get; set; }
        public string ex_mineSale { get; set; }
    }
    public class Reason_Inc_Dec_Monthly
    {
        public int? Reason_Inc_Dec_Id { get; set; }
        public int? UID { get; set; }
        public int? MineralId { get; set; }
        public string productionIncrDecResion { get; set; }
        public string ex_minepriceIncrDecResion { get; set; }
        public bool certify { get; set; }
        public int? Flag3 { get; set; }
        public string Month_Year { get; set; }
        public int? FinalSubmitFlag { get; set; }
        #region DSC
        public string DSCResponse { get; set; }
        #endregion
    }
    public class Gradewise_ROMModel
    {
        public int GradeWiseRom_Id { get; set; }

        public int? MineralNatureId8 { get; set; }
        public string MineralNature { get; set; }

        public int? MineralGradeId8 { get; set; }
        public string MineralGrade { get; set; }

        public decimal? Despatches_minehead { get; set; }

        public decimal? Ex_mine_Price { get; set; }
        public string Month_YearGradewise_ROM { get; set; }
        public int IsActive { get; set; }
        public int UID { get; set; }
    }
    public class Grade_WiseProduction
    {
        public int GradeWiseProduction_Id { get; set; }
        public int UID { get; set; }

        public int? MineralNatureId5 { get; set; }
        public string MineralNature { get; set; }

        public int? MineralGradeId5 { get; set; }
        public string MineralGrade { get; set; }



        public decimal? OpeningStock_MineHead { get; set; }



        public decimal? Production { get; set; }


        public decimal? Dispatch_MineHead { get; set; }

        public decimal? ClosingStock_MineHead { get; set; }



        public decimal? Ex_MinePrice { get; set; }

        public string Month_YearGradeWise { get; set; }
        //public int IsActive { get; set; }
    }

    public class MonthlyReturnModel
    {
        public int? M_Id { get; set; }
        public int? Months { get; set; }
        public int? Years { get; set; }
        public string MonthYear { get; set; }
        public string Status { get; set; }
        public string ModifiedOn { get; set; }
        public string FormType { get; set; }
        public string MineralName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string FinancialYear { get; set; }
        public int? UserId { get; set; }
        public int? MineralGradeId { get; set; }
        public string MineralGrade { get; set; }
        public int? MineralNatureId { get; set; }
        public string MineralNature { get; set; }
        public string Size_Of_Coal { get; set; }
        public int? MineralId { get; set; }
        public string EncryptedId { get; set; }
    }
}
