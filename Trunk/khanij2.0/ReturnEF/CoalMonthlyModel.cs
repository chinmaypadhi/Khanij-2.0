// ***********************************************************************
// Assembly         : Khanij
// Author           : Akshaya Dalei
// Created          : 22-June-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace ReturnEF
{
    public class CoalMonthlyModel
    {
        public int? Working_BackgroundOn_Id { get; set; }
        public string Belowground_on { get; set; }
        public string Belowground_on_str { get; set; }
        public int? Belowground_No_Employee { get; set; }
        public string Mine_on { get; set; }
        public int? Mine_No_Employee { get; set; }
        public string Mine_on_str { get; set; }
        public decimal? BG_Mine_Loader_Men { get; set; }
        public decimal? BG_Mine_Loader_Women { get; set; }
        public decimal? BG_Sickness { get; set; }
        public decimal? BG_Accident { get; set; }
        public decimal? BG_Leave { get; set; }
        public decimal? BG_OtherCause { get; set; }
        public decimal? BG_Total { get; set; }

        public decimal? BG_Other_Men { get; set; }
        public decimal? BG_Other_Women { get; set; }
        public decimal? BG_Other_Sickness { get; set; }
        public decimal? BG_Other_Accident { get; set; }
        public decimal? BG_Other_Leave { get; set; }
        public decimal? BG_Other_OtherCause { get; set; }
        public decimal? BG_Other_Total { get; set; }

        public decimal? OC_Mine_Loader_Men { get; set; }
        public decimal? OC_Mine_Loader_Women { get; set; }
        public decimal? OC_Sickness { get; set; }
        public decimal? OC_Accident { get; set; }
        public decimal? OC_Leave { get; set; }
        public decimal? OC_OtherCause { get; set; }
        public decimal? OC_Total { get; set; }

        public decimal? OC_Other_Men { get; set; }
        public decimal? OC_Other_Women { get; set; }
        public decimal? OC_Other_Sickness { get; set; }
        public decimal? OC_Other_Accident { get; set; }
        public decimal? OC_Other_Leave { get; set; }
        public decimal? OC_Other_OtherCause { get; set; }
        public decimal? OC_Other_Total { get; set; }


        public decimal? AG_Men { get; set; }
        public decimal? AG_Women { get; set; }
        public decimal? AG_Sickness { get; set; }
        public decimal? AG_Accident { get; set; }
        public decimal? AG_Leave { get; set; }
        public decimal? AG_OtherCause { get; set; }
        public decimal? AG_Total { get; set; }
        public decimal? Total_Men { get; set; }
        public decimal? Total_Women { get; set; }
        public decimal? Total_Sickness { get; set; }
        public decimal? Total_Accident { get; set; }
        public decimal? Total_Leave { get; set; }
        public decimal? Total_OtherCause { get; set; }
        public decimal? Total_All { get; set; }
        public string Month_Year3 { get; set; }
        public DateTime? Return_For_Month { get; set; }
        public int Flag { get; set; }
        public string Month_Year { get; set; }
    }

    public class CoalMonthlyMineDetailsModel
    {
        public int? Coal_Monthly_Id { get; set; }
        public string Month_Year4 { get; set; }
        public string Name_of_mine { get; set; }
        public string postal_address_of_mine { get; set; }
        public string Situation_of_Mine { get; set; }
        public string Tahsil { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Name_of_Owner { get; set; }
        public string Postal_address_of_owner { get; set; }

        public string Name_of_agents { get; set; }
        public string Address_of_agents { get; set; }


        public string Name_of_manager { get; set; }

        public string Address_of_manager { get; set; }


        public string agent_name { get; set; }
        public string agent_address { get; set; }

        public bool Certify { get; set; }
        public int? Flag { get; set; }
        public int? SubmitFlag { get; set; }
        public string Name_OF_Colliery_SidingP { get; set; }
        public string MineralGradeP { get; set; }
        public string DSCFilePath { get; set; }

        public int? UserId { get; set; }
        public string MineName { get; set; }
        public string MineAddress { get; set; }
        public string MineDistrict { get; set; }
        public string MineState { get; set; }
        public string MineTehsil { get; set; }
        public string LesseeName { get; set; }
        public string LesseeAddress { get; set; }
    }

    public class Table_D_Model
    {
        public int Attendance_earn_Id { get; set; }

        public string BG_OS_Average_att { get; set; }
        public string BG_OS_Aggregate_No { get; set; }
        public decimal? BG_OS_Basic_wages { get; set; }
        public decimal? BG_OS_Dearness_allowance { get; set; }
        public decimal? BG_OS_cash { get; set; }

        public decimal? BG_OS_Total { get; set; }
        public string BG_ML_Average_att { get; set; }
        public string BG_ML_Aggregate_No { get; set; }
        public decimal? BG_ML_Basic_wages { get; set; }
        public decimal? BG_ML_Dearness_allowance { get; set; }
        public decimal? BG_ML_cash { get; set; }

        public decimal? BG_ML_Total { get; set; }
        public string BG_Other_Average_att { get; set; }
        public string BG_Other_Aggregate_No { get; set; }
        public decimal? BG_Other_Basic_wages { get; set; }
        public decimal? BG_Other_Dearness_allowance { get; set; }
        public decimal? BG_Other_cash { get; set; }

        public decimal? BG_Other_Total { get; set; }
        public string OC_OS_Average_att { get; set; }
        public string OC_OS_Aggregate_No { get; set; }
        public decimal? OC_OS_Basic_wages { get; set; }
        public decimal? OC_OS_Dearness_allowance { get; set; }
        public decimal? OC_OS_cash { get; set; }
        public decimal? OC_OS_Total { get; set; }
        public string OC_ML_Average_att { get; set; }
        public string OC_ML_Aggregate_No { get; set; }
        public decimal? OC_ML_Basic_wages { get; set; }
        public decimal? OC_ML_Dearness_allowance { get; set; }
        public decimal? OC_ML_cash { get; set; }
        public decimal? OC_ML_Total { get; set; }
        public string OC_Other_Average_att { get; set; }
        public string OC_Other_Aggregate_No { get; set; }
        public decimal? OC_Other_Basic_wages { get; set; }
        public decimal? OC_Other_Dearness_allowance { get; set; }
        public decimal? OC_Other_cash { get; set; }
        public decimal? OC_Other_Total { get; set; }
        public string AG_CSS_Average_att { get; set; }
        public string AG_CSS_Aggregate_No { get; set; }
        public decimal? AG_CSS_Basic_wages { get; set; }
        public decimal? AG_CSS_Dearness_allowance { get; set; }
        public decimal? AG_CSS_cash { get; set; }
        public decimal? AG_CSS_Total { get; set; }
        public string AG_Other_Average_att { get; set; }
        public string AG_Other_Aggregate_No { get; set; }
        public decimal? AG_Other_Basic_wages { get; set; }
        public decimal? AG_Other_Dearness_allowance { get; set; }
        public decimal? AG_Other_cash { get; set; }
        public decimal? AG_Other_Total { get; set; }
        public string Total_Estimated_Value { get; set; }
        public string Normal_hrs_production_shifts { get; set; }
        public string Month_Year5 { get; set; }
        public int Flag { get; set; }
        public string First_Shift { get; set; }
        public string Second_Shift { get; set; }
        public string Third_Shift { get; set; }
        public string Month_Year { get; set; }
    }

    public class CoalMonthlyViewModel
    {
        public CoalMonthlyMineDetailsModel objMine { get; set; }
        public CoalMonthlyModel objWork { get; set; }
        public Table_D_Model objEarn { get; set; }
        public List<TABLE_A_Model> listTABLE_A_Model { get; set; }
        public List<TABLE_B_Model> listTABLE_B_Model { get; set; }

        public int? UserId { get; set; }
    }

    public class TABLE_A_Model
    {
        public int? Coal_TableA_Id { get; set; }
        public string Name_OF_Colliery_Siding { get; set; }
        public int? MineralNatureId { get; set; }
        public string MineralNature { get; set; }
        public int? MineralGradeId { get; set; }
        public string MineralGrade { get; set; }
        public string Size_Of_Coal { get; set; }
        public string CoalRaised { get; set; }
        public decimal? Opening_Stock { get; set; }
        public decimal? OpenCW { get; set; }
        public decimal? Below_GW_DevelopmentDistricts { get; set; }
        public decimal? Below_GW_DepillaringDistricts { get; set; }
        public decimal? CollieryConsumption { get; set; }
        public decimal? Coalused_Makingcoke_Colliery { get; set; }
        public decimal? CokeProduced { get; set; }
        public decimal? CoalDespatched_ByRail { get; set; }
        public decimal? CoalDespatched_ByRoad { get; set; }
        public decimal? CoalDespatched_ByOther { get; set; }
        public decimal? Closing_Stock { get; set; }
        public string Month_Year { get; set; }
        public DateTime? Return_Date { get; set; }
        public int? IsActive { get; set; }
        public string Month_YearTableA { get; set; }
        public int? UserId { get; set; }
        public decimal? OtherDispatch { get; set; }
        public decimal? RoadDispatch { get; set; }
        public decimal? RailDispatche { get; set; }

    }

    public class TABLE_B_Model
    {
        public int? MACHINERY_TableB_Id { get; set; }
        public string WorkingsBG_Type { get; set; }
        public int? WorkingsBG_Type_Id { get; set; }
        public decimal? Coal_Cutting_No_In_Use { get; set; }
        public string Coal_Cutting_Type { get; set; }
        public decimal? Square_Metres_Cut { get; set; }
        public decimal? Coal_cut { get; set; }
        public decimal? MechanicalLoaders_NoInUse { get; set; }
        public string MechanicalLoaders_Type { get; set; }
        public decimal? MechanicalLoaders_Coalloaded { get; set; }
        public string Conveyors_Type { get; set; }
        public decimal? Conveyors_Length { get; set; }
        public decimal? Coal_conveyed { get; set; }
        public string Month_Year { get; set; }
        public DateTime? Return_Date { get; set; }
        public int? IsActive { get; set; }
        public string Month_YearTableB { get; set; }
        public int? UserId { get; set; }
    }
}
