using System;
using System.Collections.Generic;
using System.Text;

namespace ReturnEF
{
    public class AnnualReturnH1PartTwoModel
    {
        public StaffandWorkModel objStaffWork { get; set; }
        public SalaryWagesPaidModel objSalaryWages { get; set; }
        public CapitalStructure objCapitalStructure { get; set; }
        public SourceOfFinance objSource { get; set; }
        public WorkModel objWork { get; set; }
        public AnnualReturnH1PartTwoModel()
        {
            objStaffWork = new StaffandWorkModel();
            objSalaryWages = new SalaryWagesPaidModel();
            objCapitalStructure = new CapitalStructure();
            objSource = new SourceOfFinance();
            objWork = new WorkModel();
        }
        public int? UserId { get; set; }
    }

    public class WorkModel
    {
        public List<int?> Work_Id { get; set; }
        public int? NoOfDaysMineWorked { get; set; }
        public int? NoOfShiftPerDay { get; set; }
        public List<string> Reason { get; set; }
        public List<int?> NoOfDaysMineStop { get; set; }

        public string Year { get; set; }
        public int? Flag { get; set; }
        public WorkModel()
        {
            this.NoOfDaysMineWorked = 0;
            this.NoOfShiftPerDay = 0;
            this.Work_Id = new List<int?>();
            this.Reason = new List<string>();
            this.NoOfDaysMineStop = new List<int?>();
            this.Flag = 0;
        }
        public int? UserId { get; set; }
    }

    public class StaffandWorkModel
    {
        public int? WorkDetails_Id { get; set; }
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
        public int? UserId { get; set; }
    }

    public class SourceOfFinance
    {
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
