using System;
using System.Collections.Generic;
using System.Text;

namespace ReturnEF
{
    public class CoalYearlyMineDetailsModel
    {
        public int? Coal_Year_Id { get; set; }
        public string Year { get; set; }
        public string Name_of_mine { get; set; }
        public string postal_address_of_mine { get; set; }
        public string DateOfopening { get; set; }
        public string DateOfclosing { get; set; }
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
        public string Designations { get; set; }
        public List<string> DesignationsList { get; set; }
        public string Numbers_employed { get; set; }
        public List<string> Numbers_employedList { get; set; }
        public string Machinery_Used { get; set; }
        public string Nature_Of_Power { get; set; }
        public bool Certify { get; set; }
        public int Flag { get; set; }
        public int SubmitFlag { get; set; }
        public string Agent_Name { get; set; }
        public string Agent_Address { get; set; }
        public string DSCFilePath { get; set; }

        public string MineName { get; set; }
        public string MineAddress { get; set; }
        public string MineDistrict { get; set; }
        public string MineState { get; set; }
        public string MineTehsil { get; set; }
        public string LesseeName { get; set; }
        public string LesseeAddress { get; set; }


    }

    public class EMPLOYMENT
    {
        public int? Employment_Id { get; set; }
        public string NumberofPersons { get; set; }
        public string Belowground_onDay { get; set; }

        public string Belowground_onDate { get; set; }
        public string Belowground_onDatestr { get; set; }
        public int? Belowground_No_Employee { get; set; }
        public string Mine_onDay { get; set; }

        public string Mine_onDate { get; set; }
        public string Mine_onDatestr { get; set; }
        public int? Mine_No_Employee { get; set; }


        //-----------------------------------------------

        public string BG_Overman_2A { get; set; }
        public string BG_Overman_2B { get; set; }
        public string BG_Overman_2C { get; set; }
        public string BG_Overman_3 { get; set; }
        public string BG_Overman_4A { get; set; }
        public string BG_Overman_4B { get; set; }
        public string BG_Overman_4C { get; set; }
        public string BG_Overman_4D { get; set; }
        public string BG_Overman_5 { get; set; }

        public string BG_Mine_Loader_2A { get; set; }
        public string BG_Mine_Loader_2B { get; set; }
        public string BG_Mine_Loader_2C { get; set; }
        public string BG_Mine_Loader_3 { get; set; }
        public string BG_Mine_Loader_4A { get; set; }
        public string BG_Mine_Loader_4B { get; set; }
        public string BG_Mine_Loader_4C { get; set; }
        public string BG_Mine_Loader_4D { get; set; }
        public string BG_Mine_Loader_5 { get; set; }

        public string BG_Others_2A { get; set; }
        public string BG_Others_2B { get; set; }
        public string BG_Others_2C { get; set; }
        public string BG_Others_3 { get; set; }
        public string BG_Others_4A { get; set; }
        public string BG_Others_4B { get; set; }
        public string BG_Others_4C { get; set; }
        public string BG_Others_4D { get; set; }
        public string BG_Others_5 { get; set; }
        //----------------------------------------------
        public string OC_Overman_2A { get; set; }
        public string OC_Overman_2B { get; set; }
        public string OC_Overman_2C { get; set; }
        public string OC_Overman_3 { get; set; }
        public string OC_Overman_4A { get; set; }
        public string OC_Overman_4B { get; set; }
        public string OC_Overman_4C { get; set; }
        public string OC_Overman_4D { get; set; }
        public string OC_Overman_5 { get; set; }

        public string OC_Mine_Loader_2A { get; set; }
        public string OC_Mine_Loader_2B { get; set; }
        public string OC_Mine_Loader_2C { get; set; }
        public string OC_Mine_Loader_3 { get; set; }
        public string OC_Mine_Loader_4A { get; set; }
        public string OC_Mine_Loader_4B { get; set; }
        public string OC_Mine_Loader_4C { get; set; }
        public string OC_Mine_Loader_4D { get; set; }
        public string OC_Mine_Loader_5 { get; set; }

        public string OC_Others_2A { get; set; }
        public string OC_Others_2B { get; set; }
        public string OC_Others_2C { get; set; }
        public string OC_Others_3 { get; set; }
        public string OC_Others_4A { get; set; }
        public string OC_Others_4B { get; set; }
        public string OC_Others_4C { get; set; }
        public string OC_Others_4D { get; set; }
        public string OC_Others_5 { get; set; }
        //--------------------------------------------
        public string CS_staff_2A { get; set; }
        public string CS_staff_2B { get; set; }
        public string CS_staff_2C { get; set; }
        public string CS_staff_3 { get; set; }
        public string CS_staff_4A { get; set; }
        public string CS_staff_4B { get; set; }
        public string CS_staff_4C { get; set; }
        public string CS_staff_4D { get; set; }
        public string CS_staff_5 { get; set; }

        public string Workers_2A { get; set; }
        public string Workers_2B { get; set; }
        public string Workers_2C { get; set; }
        public string Workers_3 { get; set; }
        public string Workers_4A { get; set; }
        public string Workers_4B { get; set; }
        public string Workers_4C { get; set; }
        public string Workers_4D { get; set; }
        public string Workers_5 { get; set; }

        public string Others_2A { get; set; }
        public string Others_2B { get; set; }
        public string Others_2C { get; set; }
        public string Others_3 { get; set; }
        public string Others_4A { get; set; }
        public string Others_4B { get; set; }
        public string Others_4C { get; set; }
        public string Others_4D { get; set; }
        public string Others_5 { get; set; }
        //------------------------------------------
        public string Total_2A { get; set; }
        public string Total_2B { get; set; }
        public string Total_2C { get; set; }
        public string Total_3 { get; set; }
        public string Total_4A { get; set; }
        public string Total_4B { get; set; }
        public string Total_4C { get; set; }
        public string Total_4D { get; set; }
        public string Total_5 { get; set; }

        public string Year { get; set; }
        public int? Flag { get; set; }
    }

    public class ELECTRICAL_APPARTATUS
    {
        public int? Electrical_Appartatus_Id { get; set; }
        public string Generated_OwnUse { get; set; }
        public string Purchased_OwnUse { get; set; }
        public string Generated_Sale { get; set; }
        public string Purchased_Sale { get; set; }
        public string Voltageofsupply { get; set; }
        public string Periodicity { get; set; }
        public string Source_of_supply { get; set; }
        public string Ag_Lighting { get; set; }
        public string Bg_Lighting { get; set; }
        public string Ag_Power { get; set; }
        public string Bg_Power { get; set; }
        public string High_pressure { get; set; }
        public string Medium_pressure { get; set; }
        public string A1_Winding_NoOfUnit_Use { get; set; }
        public string A1_Winding_TotalHP_Use { get; set; }
        public string A1_Winding_NoOfUnit_Reserve { get; set; }
        public string A1_Winding_TotalHP_Reserve { get; set; }
        public string A1_Ventilation_NoOfUnit_Use { get; set; }
        public string A1_Ventilation_TotalHP_Use { get; set; }
        public string A1_Ventilation_NoOfUnit_Reserve { get; set; }
        public string A1_Ventilation_TotalHP_Reserve { get; set; }
        public string A1_Haulage_NoOfUnit_Use { get; set; }
        public string A1_Haulage_TotalHP_Use { get; set; }
        public string A1_Haulage_NoOfUnit_Reserve { get; set; }
        public string A1_Haulage_TotalHP_Reserve { get; set; }
        public string A1_Pumping_NoOfUnit_Use { get; set; }
        public string A1_Pumping_TotalHP_Use { get; set; }
        public string A1_Pumping_NoOfUnit_Reserve { get; set; }
        public string A1_Pumping_TotalHP_Reserve { get; set; }
        public string A1_Coalwashing_NoOfUnit_Use { get; set; }
        public string A1_Coalwashing_TotalHP_Use { get; set; }
        public string A1_Coalwashing_NoOfUnit_Reserve { get; set; }
        public string A1_Coalwashing_TotalHP_Reserve { get; set; }
        public string A1_Workshops_NoOfUnit_Use { get; set; }
        public string A1_Workshops_TotalHP_Use { get; set; }
        public string A1_Workshops_NoOfUnit_Reserve { get; set; }
        public string A1_Workshops_TotalHP_Reserve { get; set; }
        public string A1_Miscellaneous { get; set; }
        public string A1_Miscellaneous_NoOfUnit_Use { get; set; }
        public string A1_Miscellaneous_TotalHP_Use { get; set; }
        public string A1_Miscellaneous_NoOfUnit_Reserve { get; set; }
        public string A1_Miscellaneous_TotalHP_Reserve { get; set; }
        public string A1_Total_NoOfUnit_Use { get; set; }
        public string A1_Total_TotalHP_Use { get; set; }
        public string A1_Total_NoOfUnit_Reserve { get; set; }
        public string A1_Total_TotalHP_Reserve { get; set; }
        public string A2_Winding_NoOfUnit_Use { get; set; }
        public string A2_Winding_TotalHP_Use { get; set; }
        public string A2_Winding_NoOfUnit_Reserve { get; set; }
        public string A2_Winding_TotalHP_Reserve { get; set; }
        public string A2_Haulage_NoOfUnit_Use { get; set; }
        public string A2_Haulage_TotalHP_Use { get; set; }
        public string A2_Haulage_NoOfUnit_Reserve { get; set; }
        public string A2_Haulage_TotalHP_Reserve { get; set; }
        public string A2_Ventilation_NoOfUnit_Use { get; set; }
        public string A2_Ventilation_TotalHP_Use { get; set; }
        public string A2_Ventilation_NoOfUnit_Reserve { get; set; }
        public string A2_Ventilation_TotalHP_Reserve { get; set; }
        public string A2_Pumping_NoOfUnit_Use { get; set; }
        public string A2_Pumping_TotalHP_Use { get; set; }
        public string A2_Pumping_NoOfUnit_Reserve { get; set; }
        public string A2_Pumping_TotalHP_Reserve { get; set; }
        public string A2_Other_NoOfUnit_Use { get; set; }
        public string A2_Other_TotalHP_Use { get; set; }
        public string A2_Other_NoOfUnit_Reserve { get; set; }
        public string A2_Other_TotalHP_Reserve { get; set; }
        public string A2_Conveyors_NoOfUnit_Use { get; set; }
        public string A2_Conveyors_TotalHP_Use { get; set; }
        public string A2_Conveyors_NoOfUnit_Reserve { get; set; }
        public string A2_Conveyors_TotalHP_Reserve { get; set; }
        public string A2_Electric_NoOfUnit_Use { get; set; }
        public string A2_Electric_TotalHP_Use { get; set; }
        public string A2_Electric_NoOfUnit_Reserve { get; set; }
        public string A2_Electric_TotalHP_Reserve { get; set; }
        public string A2_Miscellaneous { get; set; }
        public string A2_Miscellaneous_NoOfUnit_Use { get; set; }
        public string A2_Miscellaneous_TotalHP_Use { get; set; }
        public string A2_Miscellaneous_NoOfUnit_Reserve { get; set; }
        public string A2_Miscellaneous_TotalHP_Reserve { get; set; }
        public string A2_Total_NoOfUnit_Use { get; set; }
        public string A2_Total_TotalHP_Use { get; set; }
        public string A2_Total_NoOfUnit_Reserve { get; set; }
        public string A2_Total_TotalHP_Reserve { get; set; }
        public string B_Haulage_NoOfUnit_Use { get; set; }
        public string B_Haulage_TotalHP_Use { get; set; }
        public string B_Haulage_NoOfUnit_Reserve { get; set; }
        public string B_Haulage_TotalHP_Reserve { get; set; }
        public string B_Ventilation_NoOfUnit_Use { get; set; }
        public string B_Ventilation_TotalHP_Use { get; set; }
        public string B_Ventilation_NoOfUnit_Reserve { get; set; }
        public string B_Ventilation_TotalHP_Reserve { get; set; }
        public string B_Pumping_NoOfUnit_Use { get; set; }
        public string B_Pumping_TotalHP_Use { get; set; }
        public string B_Pumping_NoOfUnit_Reserve { get; set; }
        public string B_Pumping_TotalHP_Reserve { get; set; }
        public string B_Coal_cutting_NoOfUnit_Use { get; set; }
        public string B_Coal_cutting_TotalHP_Use { get; set; }
        public string B_Coal_cutting_NoOfUnit_Reserve { get; set; }
        public string B_Coal_cutting_TotalHP_Reserve { get; set; }
        public string B_Other_NoOfUnit_Use { get; set; }
        public string B_Other_TotalHP_Use { get; set; }
        public string B_Other_NoOfUnit_Reserve { get; set; }
        public string B_Other_TotalHP_Reserve { get; set; }
        public string B_Conveyors_NoOfUnit_Use { get; set; }
        public string B_Conveyors_TotalHP_Use { get; set; }
        public string B_Conveyors_NoOfUnit_Reserve { get; set; }
        public string B_Conveyors_TotalHP_Reserve { get; set; }
        public string B_Electric_NoOfUnit_Use { get; set; }
        public string B_Electric_TotalHP_Use { get; set; }
        public string B_Electric_NoOfUnit_Reserve { get; set; }
        public string B_Electric_TotalHP_Reserve { get; set; }
        public string B_Miscellaneous { get; set; }
        public string B_Miscellaneous_NoOfUnit_Use { get; set; }
        public string B_Miscellaneous_TotalHP_Use { get; set; }
        public string B_Miscellaneous_NoOfUnit_Reserve { get; set; }
        public string B_Miscellaneous_TotalHP_Reserve { get; set; }
        public string B_Total_NoOfUnit_Use { get; set; }
        public string B_Total_TotalHP_Use { get; set; }
        public string B_Total_NoOfUnit_Reserve { get; set; }
        public string B_Total_TotalHP_Reserve { get; set; }
        public string Year { get; set; }
        public int? Flag { get; set; }
    }

    public class MACHINERY_EQUIPMENT
    {
        public int? Equipment_Id { get; set; }
        public string Boilers_NoOfUnit_Use { get; set; }
        public string Boilers_TotalHP_Use { get; set; }
        public string Boilers_NoOfUnit_Reserve { get; set; }
        public string Boilers_TotalHP_Reserve { get; set; }
        public string SteamTurbines_NoOfUnit_Use { get; set; }
        public string SteamTurbines_TotalHP_Use { get; set; }
        public string SteamTurbines_NoOfUnit_Reserve { get; set; }
        public string SteamTurbines_TotalHP_Reserve { get; set; }
        public string DieselEngines_NoOfUnit_Use { get; set; }
        public string DieselEngines_TotalHP_Use { get; set; }
        public string DieselEngines_NoOfUnit_Reserve { get; set; }
        public string DieselEngines_TotalHP_Reserve { get; set; }
        public string Gasoline_NoOfUnit_Use { get; set; }
        public string Gasoline_TotalHP_Use { get; set; }
        public string Gasoline_NoOfUnit_Reserve { get; set; }
        public string Gasoline_TotalHP_Reserve { get; set; }
        public string HydraulicTurbines_NoOfUnit_Use { get; set; }
        public string HydraulicTurbines_TotalHP_Use { get; set; }
        public string HydraulicTurbines_NoOfUnit_Reserve { get; set; }
        public string HydraulicTurbines_TotalHP_Reserve { get; set; }
        public string AirCompressors_NoOfUnit_Use { get; set; }
        public string AirCompressors_TotalHP_Use { get; set; }
        public string AirCompressors_NoOfUnit_Reserve { get; set; }
        public string AirCompressors_TotalHP_Reserve { get; set; }
        public string Winding_NoOfUnit_Use { get; set; }
        public string Winding_TotalHP_Use { get; set; }
        public string Winding_NoOfUnit_Reserve { get; set; }
        public string Winding_TotalHP_Reserve { get; set; }
        public string A1Ventilation_NoOfUnit_Use { get; set; }
        public string A1Ventilation_TotalHP_Use { get; set; }
        public string A1Ventilation_NoOfUnit_Reserve { get; set; }
        public string A1Ventilation_TotalHP_Reserve { get; set; }
        public string A1Haulage_NoOfUnit_Use { get; set; }
        public string A1Haulage_TotalHP_Use { get; set; }
        public string A1Haulage_NoOfUnit_Reserve { get; set; }
        public string A1Haulage_TotalHP_Reserve { get; set; }
        public string A1Pumping_NoOfUnit_Use { get; set; }
        public string A1Pumping_TotalHP_Use { get; set; }
        public string A1Pumping_NoOfUnit_Reserve { get; set; }
        public string A1Pumping_TotalHP_Reserve { get; set; }
        public string Dressing_NoOfUnit_Use { get; set; }
        public string Dressing_TotalHP_Use { get; set; }
        public string Dressing_NoOfUnit_Reserve { get; set; }
        public string Dressing_TotalHP_Reserve { get; set; }
        public string Workshops_NoOfUnit_Use { get; set; }
        public string Workshops_TotalHP_Use { get; set; }
        public string Workshops_NoOfUnit_Reserve { get; set; }
        public string Workshops_TotalHP_Reserve { get; set; }

        public string A1_Miscellaneous { get; set; }
        public string A2_Miscellaneous { get; set; }

        public string A1Miscellaneous_NoOfUnit_Use { get; set; }
        public string A1Miscellaneous_TotalHP_Use { get; set; }
        public string A1Miscellaneous_NoOfUnit_Reserve { get; set; }
        public string A1Miscellaneous_TotalHP_Reserve { get; set; }
        public string A2Haulage_NoOfUnit_Use { get; set; }
        public string A2Haulage_TotalHP_Use { get; set; }
        public string A2Haulage_NoOfUnit_Reserve { get; set; }
        public string A2Haulage_TotalHP_Reserve { get; set; }
        public string A2Ventilation_NoOfUnit_Use { get; set; }
        public string A2Ventilation_TotalHP_Use { get; set; }
        public string A2Ventilation_NoOfUnit_Reserve { get; set; }
        public string A2Ventilation_TotalHP_Reserve { get; set; }
        public string A2Pumping_NoOfUnit_Use { get; set; }
        public string A2Pumping_TotalHP_Use { get; set; }
        public string A2Pumping_NoOfUnit_Reserve { get; set; }
        public string A2Pumping_TotalHP_Reserve { get; set; }
        public string locomotives_NoOfUnit_Use { get; set; }
        public string locomotives_TotalHP_Use { get; set; }
        public string locomotives_NoOfUnit_Reserve { get; set; }
        public string locomotives_TotalHP_Reserve { get; set; }
        public string A2Miscellaneous_NoOfUnit_Use { get; set; }
        public string A2Miscellaneous_TotalHP_Use { get; set; }
        public string A2Miscellaneous_NoOfUnit_Reserve { get; set; }
        public string A2Miscellaneous_TotalHP_Reserve { get; set; }
        public string A1_Total_NoOfUnit_Use { get; set; }
        public string A1_Total_TotalHP_Use { get; set; }
        public string A1_Total_NoOfUnit_Reserve { get; set; }
        public string A1_Total_TotalHP_Reserve { get; set; }
        public string A2_Total_NoOfUnit_Use { get; set; }
        public string A2_Total_TotalHP_Use { get; set; }
        public string A2_Total_NoOfUnit_Reserve { get; set; }
        public string A2_Total_TotalHP_Reserve { get; set; }
        public string A3_Total_NoOfUnit_Use { get; set; }
        public string A3_Total_TotalHP_Use { get; set; }
        public string A3_Total_NoOfUnit_Reserve { get; set; }
        public string A3_Total_TotalHP_Reserve { get; set; }

        public string Year { get; set; }
        public int? Flag { get; set; }
    }

    public class MECHANICAL_VENTILATORS
    {
        public int? Ventilators_Id { get; set; }
        public string Nameofexplosive { get; set; }
        public string Quantity_used { get; set; }
        public string Electric { get; set; }
        public string Ordinary { get; set; }
        public string Safety_Lamps { get; set; }
        public string Lead_Rivet { get; set; }
        public string Magnetic { get; set; }
        public string Other { get; set; }
        public string Mechanical_Ventilator { get; set; }
        public string Position { get; set; }
        public string Avg_Totalqty { get; set; }
        public string Water_gauge { get; set; }
        public string Year { get; set; }
        public int? Flag { get; set; }
    }

    public class E_EXPLOSIVES_b
    {
        public int? E_Explosives_b_Id { get; set; }
        public string OpeningStocks_hard { get; set; }
        public string Cokemanufactured_hard { get; set; }
        public string Totalvalueofcokemade_hard { get; set; }
        public string TotalI_hard { get; set; }
        public string Cokedespatched_hard { get; set; }
        public string Collieryconsumption_hard { get; set; }
        public string Shortage_hard { get; set; }
        public string Closingstocks_hard { get; set; }
        public string TotalII_hard { get; set; }

        public string OpeningStocks_soft { get; set; }
        public string Cokemanufactured_soft { get; set; }
        public string Totalvalueofcokemade_soft { get; set; }
        public string TotalI_soft { get; set; }
        public string Cokedespatched_soft { get; set; }
        public string Collieryconsumption_soft { get; set; }
        public string Shortage_soft { get; set; }
        public string Closingstocks_soft { get; set; }
        public string TotalII_soft { get; set; }
        public string Year { get; set; }
        public int? Flag { get; set; }
        public int? FinalSubmitFlag { get; set; }
        public int? UserId { get; set; }
    }

    public class CoalYearlyViewModel
    {
        public CoalYearlyMineDetailsModel objMine { get; set; }
        public EMPLOYMENT objEmployment { get; set; }
        public ELECTRICAL_APPARTATUS objElectrical { get; set; }
        public MACHINERY_EQUIPMENT objMachinery { get; set; }
        public MECHANICAL_VENTILATORS objVentilators { get; set; }
        public E_EXPLOSIVES_b objE_Explosives_b { get; set; }
        public List<E_EXPLOSIVES> obje_EXPLOSIVEs { get; set; }
        public int? UserId { get; set; }

    }

    public class E_EXPLOSIVES
    {
        public int? E_Explosive_Id { get; set; }
        public int? MineralGradeId { get; set; }
        public string MineralGrade { get; set; }
        public string Opening_stocks { get; set; }
        public string Coal_raised { get; set; }
        public string Totalvalueofrasing { get; set; }
        public string TotalI { get; set; }
        public string Coaldespatched { get; set; }
        public string Collieryconsumption { get; set; }
        public string Coalusedforcoking { get; set; }
        public string Shortagedueto_Causes { get; set; }
        public string Closingstocks { get; set; }
        public string TotalII { get; set; }
        public int? IsActive { get; set; }
        public string Year1 { get; set; }
        public int? UserId { get; set; }
        public decimal? CoalDispatched { get; set; }
        public decimal? OpeningStock { get; set; }


    }
}
