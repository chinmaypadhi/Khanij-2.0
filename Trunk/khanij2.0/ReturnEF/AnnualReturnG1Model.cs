using System;
using System.Collections.Generic;
using System.Text;

namespace ReturnEF
{
    class AnnualReturnG1Model
    {
    }
    public class YearlyReturnModel
    {
        public string FinancialYear { get; set; }
        public string Status { get; set; }
        public string ModifiedOn { get; set; }
        public string FormType { get; set; }
        public string MineralName { get; set; }
        public int? MineralId { get; set; }
        public string Financial_Year { get; set; }
        public int? UserId { get; set; }
        public string MonthYear { get; set; }
        public string Year { get; set; }
        public int? MineralGradeId { get; set; }
        public int? Agency_Mine_Id { get; set; }
        public string Agency_Mine { get; set; }
        public string EncryptedId { get; set; }
        public decimal? TinContent { get; set; }
    }
    public class AnnualReturnH1ViewModel
    {
        public MineDetailsModel objMineDetails { get; set; }
        public MineOther_DetailsModel objOtherDetails { get; set; }
        public ParticularsofArea objParticular { get; set; }
        public LeaseArea objLeaseArea { get; set; }
        public int? UserId { get; set; }
        public AnnualReturnH1ViewModel()
        {
            objMineDetails = new MineDetailsModel();
            objOtherDetails = new MineOther_DetailsModel();
            objParticular = new ParticularsofArea();
            objLeaseArea = new LeaseArea();
        }

    }
    public class MineDetailsModel
    {
        //------------Mine Details ----------------------------------
        public string Registrationnumber { get; set; }
        public string MINE_CODE { get; set; }
        public int? MineralID { get; set; }
        public int? UID { get; set; }
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
        //------------Mine Details ----------------------------------      
    }
    public class MineOther_DetailsModel
    {
        public int OtherDetails_Id { get; set; }
        public string RegisteredOffice { get; set; }
        public string Director_in_charge { get; set; }
        public string Agent { get; set; }
        public string Manager { get; set; }
        public string MiningEngineer_in_charge { get; set; }
        public string Geologist_in_charge { get; set; }
        public string Transferor { get; set; }
        public string Dateof_Transfer { get; set; }
        public string Year { get; set; }
        public string MinePostOffice { get; set; }
        public string MineFaxNo { get; set; }
        public string LesseeFaxNo { get; set; }
        public int? Flag1 { get; set; }
        public string SubmitDate { get; set; }
        public string DSCFilePath { get; set; }
    }
    public class ParticularsofArea
    {

        //------------Particulars of area operated/Lease ----------------------------
        public List<int> Particular_Id { get; set; }
        public List<string> Lease_number { get; set; }
        public List<string> underlease_UnderForest { get; set; }
        public List<string> underlease_OutsideForest { get; set; }
        public List<string> underlease_Total { get; set; }
        public List<string> Date_of_execution { get; set; }
        public List<string> Date_of_execution_str { get; set; }
        public List<string> Periodoflease { get; set; }
        public List<string> Surfacerights_UnderForest { get; set; }
        public List<string> Surfacerights_OutsideForest { get; set; }
        public List<string> Surfacerights_Total { get; set; }
        public List<string> RenewalDate { get; set; }
        public List<string> RenewalDate_str { get; set; }
        public List<string> RenewalPeriod { get; set; }
        public string More_mine_details { get; set; }
        public string Mineral_produced { get; set; }
        public string Year { get; set; }
        public int? Flag2 { get; set; }
        public int? UID { get; set; }
        //------------Particulars of area operated/Lease ----------------------------
        public int? UserId { get; set; }
        public ParticularsofArea()
        {
            this.Particular_Id = new List<int>();
            this.Lease_number = new List<string>();
            this.underlease_UnderForest = new List<string>();
            this.underlease_OutsideForest = new List<string>();
            this.underlease_Total = new List<string>();
            this.Date_of_execution = new List<string>();
            this.Date_of_execution_str = new List<string>();
            this.Periodoflease = new List<string>();
            this.Surfacerights_UnderForest = new List<string>();
            this.Surfacerights_OutsideForest = new List<string>();
            this.Surfacerights_Total = new List<string>();
            this.RenewalDate = new List<string>();
            this.RenewalDate_str = new List<string>();
            this.RenewalPeriod = new List<string>();
        }

    }
    public class LeaseArea
    {
        //------------Lease area (surface area) utilisation----------------------------
        public int Lease_Area_Id { get; set; }
        public int? UID { get; set; }

        public string UnderForest1 { get; set; }

        public string UnderForest2 { get; set; }
      
        public string UnderForest3 { get; set; }

        public string UnderForest4 { get; set; }
    
        public string UnderForest5 { get; set; }
  
        public string UnderForest6 { get; set; }
      
        public string UnderForest7 { get; set; }
    
        public string Outsideforest1 { get; set; }

        public string Outsideforest2 { get; set; }

        public string Outsideforest3 { get; set; }
    
        public string Outsideforest4 { get; set; }
   
        public string Outsideforest5 { get; set; }
     
        public string Outsideforest6 { get; set; }

        public string Outsideforest7 { get; set; }
      
        public string Total1 { get; set; }
      
        public string Total2 { get; set; }
 
        public string Total3 { get; set; }
       
        public string Total4 { get; set; }
       
        public string Total5 { get; set; }

        public string Total6 { get; set; }
       
        public string Total7 { get; set; }
  
        public string AgencyofMine { get; set; }
        public string Year { get; set; }
        public int? Flag3 { get; set; }
        //------------Lease area (surface area) utilisation----------------------------       
        public int? UserId { get; set; }
    }
    public class GetDDL
    {
        public int Agency_Mine_Id { get; set; }
        public string Agency_Mine { get; set; }
    }

    public class AnnualReturnH1PartTwoModel
    {
        public StaffandWorkModel objStaffWork { get; set; }
        public SalaryWagesPaidModel objSalaryWages { get; set; }
        public CapitalStructure objCapitalStructure { get; set; }
        public SourceOfFinance objSource { get; set; }
        public WorkModel objWork { get; set; }
        public int? UserId { get; set; }
        public AnnualReturnH1PartTwoModel()
        {
            objStaffWork = new StaffandWorkModel();
            objSalaryWages = new SalaryWagesPaidModel();
            objCapitalStructure = new CapitalStructure();
            objSource = new SourceOfFinance();
            objWork = new WorkModel();
        }
    }
    public class WorkModel
    {
        public List<int?> Work_Id { get; set; }
        public int? UID { get; set; }
        public int? NoOfDaysMineWorked { get; set; }
        public int? NoOfShiftPerDay { get; set; }
        public List<string> Reason { get; set; }
        public List<int?> NoOfDaysMineStop { get; set; }

        public string Year { get; set; }
        public int? Flag { get; set; }

        public int? UserId { get; set; }
        public WorkModel()
        {
            this.NoOfDaysMineWorked = 0;
            this.NoOfShiftPerDay = 0;
            this.Work_Id = new List<int?>();
            this.Reason = new List<string>();
            this.NoOfDaysMineStop = new List<int?>();
            this.Flag = 0;
        }
    }
    public class StaffandWorkModel
    {
        public int? WorkDetails_Id { get; set; }
        public int? UID { get; set; }
        public string Whollyemployed1 { get; set; }
        public string Whollyemployed2 { get; set; }
        public string Whollyemployed3 { get; set; }
        public string Whollyemployed4 { get; set; }
        public string Whollyemployed5 { get; set; }
        public string Whollyemployed_Total { get; set; }
        public string Partlyemployed1 { get; set; }
        public string Partlyemployed2 { get; set; }
        public string Partlyemployed3 { get; set; }
        public string Partlyemployed4 { get; set; }
        public string Partlyemployed5 { get; set; }
        public string Partlyemployed_Total { get; set; }

        public string Year { get; set; }
        public int? Flag1 { get; set; }
        public int? UserId { get; set; }
    }
    public class SalaryWagesPaidModel
    {
        public int? UID { get; set; }
        public int? SalaryWages_Id { get; set; }

        public string WorkingBelowGrounddate_str { get; set; }
        public string WorkingBelowNo { get; set; }

        public string WorkingOnMinedate_str { get; set; }
        public string WorkingOnMineNo { get; set; }
        public string BG_Direct { get; set; }
        public string BG_Contract { get; set; }
        public string BG_Total { get; set; }
        public string BG_NoOFDaysWork { get; set; }
        public string BG_Male { get; set; }
        public string BG_Female { get; set; }
        public string BG_Average_Total { get; set; }
        public string BG_TotalWages { get; set; }

        public string OC_Direct { get; set; }
        public string OC_Contract { get; set; }
        public string OC_Total { get; set; }
        public string OC_NoOFDaysWork { get; set; }
        public string OC_Male { get; set; }
        public string OC_Female { get; set; }
        public string OC_Average_Total { get; set; }
        public string OC_TotalWages { get; set; }

        public string AG_Direct { get; set; }
        public string AG_Contract { get; set; }
        public string AG_Total { get; set; }
        public string AG_NoOFDaysWork { get; set; }
        public string AG_Male { get; set; }
        public string AG_Female { get; set; }
        public string AG_Average_Total { get; set; }
        public string AG_TotalWages { get; set; }

        public string Total_Direct { get; set; }
        public string Total_Contract { get; set; }
        public string Total_Total { get; set; }
        public string Total_NoOFDaysWork { get; set; }
        public string Total_Male { get; set; }
        public string Total_Female { get; set; }
        public string Total_Average_Total { get; set; }
        public string Total_TotalWages { get; set; }

        public string Year { get; set; }
        public int? Flag2 { get; set; }
        public int? UserId { get; set; }
        public DateTime? WorkingBelowGrounddate { get; set; }
        public DateTime? WorkingOnMinedate { get; set; }
    }
    public class CapitalStructure
    {
        public int? UID { get; set; }
        public int? CapitalStructure_Id { get; set; }
        public string ValueofFixedAssets { get; set; }
        public string OtherMineCode { get; set; }
        // -----------------------------------        
        public string Land_AtBeginning { get; set; }
        public string Land_Additions { get; set; }
        public string Land_Sold_Discarded { get; set; }
        public string Land_Depreciation { get; set; }
        public string Land_Net_closing_Balance { get; set; }
        public string Land_Estimated_Market { get; set; }
        // -----------------------------------
        //  Building:
        public string Industrial_AtBeginning { get; set; }
        public string Industrial_Additions { get; set; }
        public string Industrial_Sold_Discarded { get; set; }
        public string Industrial_Depreciation { get; set; }
        public string Industrial_Net_closing_Balance { get; set; }
        public string Industrial_Estimated_Market { get; set; }


        public string Residential_AtBeginning { get; set; }
        public string Residential_Additions { get; set; }
        public string Residential_Sold_Discarded { get; set; }
        public string Residential_Depreciation { get; set; }
        public string Residential_Net_closing_Balance { get; set; }
        public string Residential_Estimated_Market { get; set; }
        // -----------------------------------
        // Plant and Machinery including transport equipment
        public string P_M_T_AtBeginning { get; set; }
        public string P_M_T_Additions { get; set; }
        public string P_M_T_Sold_Discarded { get; set; }
        public string P_M_T_Depreciation { get; set; }
        public string P_M_T_Net_closing_Balance { get; set; }
        public string P_M_T_Estimated_Market { get; set; }
        // -----------------------------------
        //Capitalised Expenditure such as pre-production exploration, development,major overhaul and repair to machinery etc
        public string Exp_AtBeginning { get; set; }
        public string Exp_Additions { get; set; }
        public string Exp_Sold_Discarded { get; set; }
        public string Exp_Depreciation { get; set; }
        public string Exp_Net_closing_Balance { get; set; }
        public string Exp_Estimated_Market { get; set; }
        //-----------------------------------
        public string Total_AtBeginning { get; set; }
        public string Total_Additions { get; set; }
        public string Total_Sold_Discarded { get; set; }
        public string Total_Depreciation { get; set; }
        public string Total_Net_closing_Balance { get; set; }
        public string Total_Estimated_Market { get; set; }
        public string Year { get; set; }
        public int? Flag3 { get; set; }
        // -----------------------------------        
        // -----------------------------------
        //  Building:
        // -----------------------------------
        // Plant and Machinery including transport equipment
        // -----------------------------------
        //Capitalised Expenditure such as pre-production exploration, development,major overhaul and repair to machinery etc
        public int? UserId { get; set; }
    }
    public class SourceOfFinance
    {
        public int? UID { get; set; }
        public int? SourceOfFinance_Id { get; set; }
        public string ShareCapital { get; set; }
        public string OwnCapital { get; set; }
        public string Reserve { get; set; }
        public string Institution { get; set; }
        public string AmountofLoan { get; set; }
        public string RateofInterest { get; set; }
        public string Interestpaid { get; set; }
        public string Rentspaid { get; set; }
        public string Year { get; set; }
        public int? Flag4 { get; set; }
        public int? UserId { get; set; }
    }

}
