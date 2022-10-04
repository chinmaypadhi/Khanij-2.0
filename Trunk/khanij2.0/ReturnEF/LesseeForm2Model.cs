using System;
using System.Collections.Generic;
using System.Text;

namespace ReturnEF
{
    public class FormF2PartTwoViewModel
    {
        public ProductionandStocksModel objProduction { get; set; }
        public Details_of_deductions_sale_computation objDeduction_made { get; set; }
        public Reason_Inc_Dec_Monthly_FormF2 objReason_Inc_Dec { get; set; }
        public RecoveriesModel Obj_RecoveriesModel { get; set; }
        
        public SaleProductModel Obj_SaleProductModel { get; set; }
        public SalesDispatchOf_OreModel Obj_SalesDispatchOf_OreModel { get; set; }
 
        public Reason_Inc_Dec objReason_Reason_Inc_Dec { get; set; }
        public Details_of_deductions objDeduction { get; set; }
        public FormF2PartTwoViewModel()
        {
            objProduction = new ProductionandStocksModel();
            objDeduction_made = new Details_of_deductions_sale_computation();
            objReason_Inc_Dec = new Reason_Inc_Dec_Monthly_FormF2();
            Obj_RecoveriesModel = new RecoveriesModel();
            Obj_SaleProductModel = new SaleProductModel();
            Obj_SalesDispatchOf_OreModel= new SalesDispatchOf_OreModel();
            objReason_Reason_Inc_Dec = new Reason_Inc_Dec();
            objDeduction = new Details_of_deductions();
        }
    }

    public class ProductionandStocksModel
    {
        public int? ProductionandStocks_Id { get; set; }

        public int? MineralId1 { get; set; }
        public int? UID { get; set; }

        public decimal? Development_OS_Qty { get; set; }
        public string Development_OS_grade { get; set; }

        public decimal? Development_Production_Qty { get; set; }
        public string Development_Production_grade { get; set; }

        public decimal? Development_CS_Qty { get; set; }
        public string Development_CS_grade { get; set; }

        public decimal? Stoping_OS_Qty { get; set; }
        public string Stoping_OS_grade { get; set; }

        public decimal? Stoping_Production_Qty { get; set; }
        public string Stoping_Production_grade { get; set; }

        public decimal? Stoping_CS_Qty { get; set; }
        public string Stoping_CS_grade { get; set; }

        public decimal? OpenCastWork_OS_Qty { get; set; }
        public string OpenCastWork_OS_grade { get; set; }

        public decimal? OpenCastWork_Production_Qty { get; set; }
        public string OpenCastWork_Production_grade { get; set; }

        public decimal? OpenCastWork_CS_Qty { get; set; }
        public string OpenCastWork_CS_grade { get; set; }
        public decimal? Total_OS_Qty { get; set; }
        public decimal? Total_OS_grade { get; set; }
        public decimal? Total_Production_Qty { get; set; }
        public decimal? Total_Production_grade { get; set; }
        public decimal? Total_CS_Qty { get; set; }
        public decimal? Total_CS_grade { get; set; }


        public decimal? ExMinePrice { get; set; }
        public int? Flag { get; set; }

        public string Month_Year { get; set; }
        public string Year { get; set; }
        public string MineralGrade { get; set; }
     
        public int? UserId { get; set; }

    }
    public class Details_of_deductions_sale_computation
    {
        public int? DeductionMade_Id { get; set; }
        public int? MineralId8 { get; set; }
        public int? UID { get; set; }
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
        public int? Flag { get; set; }

        public string Month_Year { get; set; }

        public string CExMineSale { get; set; }
        public string ex_mineSale { get; set; }
    }
    public class Reason_Inc_Dec_Monthly_FormF2
    {
        public int? Reason_Inc_Dec_Id { get; set; }
        public int MineralId { get; set; }
        public int? UID { get; set; }
        public string productionIncrDecResion { get; set; }
        public string ex_minepriceIncrDecResion { get; set; }
        public bool certify { get; set; }
        public int? Flag { get; set; }
        public string Month_Year { get; set; }
        public int? FinalSubmitFlag { get; set; }
    }
    public class RecoveriesModel
    {
        public int UID { get; set; }
        public int Recoverie_Id { get; set; }
        public int? MineralId2 { get; set; }
        public string MineralName { get; set; }

        public decimal? OS_qty { get; set; }

        public string OS_grade { get; set; }

        public decimal? OreReceived_qty { get; set; }

        public string OreReceived_grade { get; set; }

        public decimal? OreTreated_qty { get; set; }

        public string OreTreated_grade { get; set; }

        public decimal? Concentrates_qty { get; set; }

        public decimal? Concentrates_Value { get; set; }

        public string Concentrates_grade { get; set; }

        public decimal? Tailings_Qty { get; set; }

        public string Tailing_grade { get; set; }

        public decimal? CS_qty { get; set; }

        public string CS_grade { get; set; }

        public string Month_Year { get; set; }
        public string Year { get; set; }
        public int IsActive { get; set; }      
        public int? UserId { get; set; }
        public int? MineralId { get; set; }
    }
    public class Recovery_atSmelterModel
    {
        public int? Recovery_atSmelter_Id { get; set; }
        public int UID { get; set; }
        public int? MineralId3 { get; set; }
        public string MineralName { get; set; }
     
        public decimal? OS_qty { get; set; }
   
        public string OS_grade { get; set; }
     
        public decimal? Concentratesreceived_qty { get; set; }
 
        public string Concentratesreceived_grade { get; set; }
 
        public decimal? Concentrates_othersources_qty { get; set; }

        public string Concentrates_othersources_grade { get; set; }

        public decimal? Concentrates_sold_qty { get; set; }

        public string Concentrates_sold_grade { get; set; }
     
        public decimal? Concentrates_treated_qty { get; set; }

        public string Concentrates_treated_grade { get; set; }
   
        public decimal? CS_qty { get; set; }

        public string CS_grade { get; set; }

        public decimal? Metalsrecovered_qty { get; set; }

        public string Metalsrecovered_grade { get; set; }
      
        public decimal? Metalsrecovered_Value { get; set; }
     
        public decimal? Other_byproducts_qty { get; set; }

        public string Other_byproducts_grade { get; set; }

        public decimal? Other_byproducts_Value { get; set; }
        public string Month_Year { get; set; }
        public int IsActive { get; set; }      
        public int? MineralId { get; set; }
        public int? UserId { get; set; }
        public string Year { get; set; }
    }
    public class SaleProductModel
    {
        public int SaleProductId { get; set; }
        public int? MineralId { get; set; }
         public int? UID { get; set; }
        public int? MineralId6 { get; set; }
   
        public int? MineralGradeId6 { get; set; }
        public string MineralName { get; set; }
    
        public string Product { get; set; }
     
        public string OS_Qty { get; set; }
        public string OS_Grade { get; set; }

        public string PlaceOfSale { get; set; }
      
        public string Sold_Qty { get; set; }
        public string Sold_Grade { get; set; }
    
        public string Sold_Value { get; set; }
     
        public string CS_Qty { get; set; }
        public string CS_Grade { get; set; }
  
        public string Month_Year { get; set; }
        public int IsActive { get; set; }

        public decimal? TinContent { get; set; }
        public decimal? AluminaContent { get; set; }     
        public int? UserId { get; set; }
        public string Year { get; set; }
    }
    public class SalesDispatchOf_OreModel
    {
        public int Sale_Dispatch_Id { get; set; }
        public int? MineralId9 { get; set; }
        public int? UID { get; set; }
        public string MineralName { get; set; }
  
        public int? MineralNatureId { get; set; }
        public string MineralNature { get; set; }
      
        public int? MineralGradeId { get; set; }
        public string MineralGrade { get; set; }
      
        public string NatureofDispatch { get; set; }
    
        public string RegistrationNo { get; set; }
        public int? PurchaserConsineeId { get; set; }
        public string PurchaserConsinee { get; set; }
        public decimal? DomesticPurposes_Quantity { get; set; }
        public decimal? SaleValue { get; set; }
        public string Country { get; set; }
        public decimal? Export_Quantity { get; set; }
        public string FOBValue { get; set; }
        public string Month_Year { get; set; }
        public int IsActive { get; set; }
        public int? UserId { get; set; }
        public string Year { get; set; }
        public int? MineralId { get; set; }
    }

    public class LesseeFormF2Part1Model
    {
        public int? Details_Id { get; set; }
        public int? Work_Id { get; set; }
        public int? Wages_Id { get; set; }

        public string Registrationnumber { get; set; }
       
        public string Month_Year { get; set; }
        public string MINE_CODE { get; set; }
        public int? MineralID { get; set; }
        public string MineralName { get; set; }
        public string OtherMineral { get; set; }
        public string MineName { get; set; }

        public string MineAddress { get; set; }
        public string MineVillage { get; set; }
        public string MineDistrict { get; set; }
        public string MineState { get; set; }
        public string MineTehsil { get; set; }
        public string MinePinCode { get; set; }
        public string MinePostOffice { get; set; }

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
        public string LesseePinCode { get; set; }
        public string LesseeFaxNo { get; set; }
        public string LesseeEmailID { get; set; }
        public string LesseeMobileNo { get; set; }
        public string LesseePhoneNo { get; set; }
 
        public decimal? Rentpaid { get; set; }
        public decimal? Royaltypaid { get; set; }
   
        public decimal? DeadRentpaid { get; set; }
        public decimal? DMFPaid { get; set; }
        public decimal? NMETPaid { get; set; }

        public string NoOfDaysMineWork { get; set; }
        
        public string NoOfDaysWorkStop { get; set; }
     
        public string Reason { get; set; }

        public List<Working_of_Mine> MineWork { get; set; }

        public string WorkPlace1 { get; set; }
     
        public decimal? DirectMale1 { get; set; }
      
        public decimal? DirectFemale1 { get; set; }
    
        public decimal? ContractMale1 { get; set; }
    
        public decimal? ContractFemale1 { get; set; }


        public string WorkPlace2 { get; set; }
     
        public decimal? DirectMale2 { get; set; }
     
        public decimal? DirectFemale2 { get; set; }
       
        public decimal? ContractMale2 { get; set; }
      
        public decimal? ContractFemale2 { get; set; }



        public string WorkPlace3 { get; set; }
     
        public decimal? DirectMale3 { get; set; }
       
        public decimal? DirectFemale3 { get; set; }
     
        public decimal? ContractMale3 { get; set; }
        
        public decimal? ContractFemale3 { get; set; }


        public decimal? BGTotalMale { get; set; }
        public decimal? BGTotalFemale { get; set; }
        public decimal? OCTotalMale { get; set; }
        public decimal? OCTptalFemale { get; set; }
        public decimal? AGTotalMale { get; set; }
        public decimal? AGTotalFemale { get; set; }

     
        public decimal? TotalWagesMale1 { get; set; }
       
        public decimal? TotalWagesMale2 { get; set; }
    
        public decimal? TotalWagesMale3 { get; set; }
      
        public decimal? TotalWagesFeMale1 { get; set; }
        //  [Required(ErrorMessage = "Required")]
     
        public decimal? TotalWagesFeMale2 { get; set; }
        //  [Required(ErrorMessage = "Required")]
  
        public decimal? TotalWagesFeMale3 { get; set; }

        public decimal? TotalDirectMale { get; set; }
        public decimal? TotalDirectFemale { get; set; }
        public decimal? TotalContractMale { get; set; }
        public decimal? TotalContractFemale { get; set; }
        public decimal? TotalMaleWages { get; set; }
        public decimal? TotalFeMaleWages { get; set; }

        //----------------------------------------
        public decimal? Development_OS_Qty { get; set; }
        public string Development_OS_grade { get; set; }
        public decimal? Development_Production_Qty { get; set; }
        public string Development_Production_grade { get; set; }

        public decimal? Development_CS_Qty { get; set; }
        public string Development_CS_grade { get; set; }

        public decimal? Stoping_OS_Qty { get; set; }
        public string Stoping_OS_grade { get; set; }

        public decimal? Stoping_Production_Qty { get; set; }
        public string Stoping_Production_grade { get; set; }

        public decimal? Stoping_CS_Qty { get; set; }
        public string Stoping_CS_grade { get; set; }

        public decimal? OpenCastWork_OS_Qty { get; set; }
        public string OpenCastWork_OS_grade { get; set; }

        public decimal? OpenCastWork_Production_Qty { get; set; }
        public string OpenCastWork_Production_grade { get; set; }

        public decimal? OpenCastWork_CS_Qty { get; set; }
        public string OpenCastWork_CS_grade { get; set; }
        public decimal? Total_OS_Qty { get; set; }
        public decimal? Total_OS_grade { get; set; }
        public decimal? Total_Production_Qty { get; set; }
        public decimal? Total_Production_grade { get; set; }
        public decimal? Total_CS_Qty { get; set; }
        public decimal? Total_CS_grade { get; set; }

        public decimal? ExMinePrice { get; set; }


        //---------------------------------------

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
        public string SubmitDate { get; set; }
        //---------------------------------------
        public string productionIncrDecResion { get; set; }
        public string ex_minepriceIncrDecResion { get; set; }
        public bool certify { get; set; }
        //-------------------
        public string DistrictName { get; set; }
        //---------------------------------------
        public int Flag { get; set; }
        public string DSCFilePath { get; set; }
        public LesseeFormF2Part1Model()
        {
            Flag = 0;
        }
    }

    public class Details_of_deductions
    {
        public int? DeductionMade_Id { get; set; }
        public int? MineralNatureId { get; set; }
        public int? Average_Id { get; set; }
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
        public string Year { get; set; }

        public string CExMineSale { get; set; }
        public string ex_mineSale { get; set; }
        public int? UserId { get; set; }
    }

    public class Reason_Inc_Dec
    {
        public int? Reason_Inc_Dec_Id { get; set; }
        public int MineralId { get; set; }
        public string productionIncrDecResion { get; set; }
        public string ex_minepriceIncrDecResion { get; set; }
        public bool certify { get; set; }
        public int? Flag3 { get; set; }
        public string Year { get; set; }
        public int? UserId { get; set; }
    }
}
