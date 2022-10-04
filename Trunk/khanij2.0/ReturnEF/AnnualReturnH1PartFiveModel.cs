using System;
using System.Collections.Generic;
using System.Text;

namespace ReturnEF
{
    public  class AnnualReturnH1PartFiveModel
    {
        public Exploration objExploration { get; set; }
        public ReservesAndResources objResources { get; set; }
        public RejectWasteTreesPlanted objRejectWaste { get; set; }
        public FurnishDetails objFurnishDetails { get; set; }
        public AnnualReturnH1PartFiveModel()
        {
            objExploration = new Exploration();
            objResources = new ReservesAndResources();
            objRejectWaste = new RejectWasteTreesPlanted();
            objFurnishDetails = new FurnishDetails();
        }
        public int? UserId { get; set; }
    }

    public class Exploration
    {
        public int Exploration_Id { get; set; }
        public string Drilling_holes_Beginning { get; set; }
        public string Drilling_holes_During { get; set; }
        public string Drilling_holes_Cumulative { get; set; }
        public string Drilling_holes_Dimension { get; set; }

        public string Drilling_Metrage_Beginning { get; set; }
        public string Drilling_Metrage_During { get; set; }
        public string Drilling_Metrage_Cumulative { get; set; }
        public string Drilling_Metrage_Dimension { get; set; }

        public string Pitting_Pits_Beginning { get; set; }
        public string Pitting_Pits_During { get; set; }
        public string Pitting_Pits_Cumulative { get; set; }
        public string Pitting_Pits_Dimension { get; set; }

        public string Pitting_Excavation_Beginning { get; set; }
        public string Pitting_Excavation_During { get; set; }
        public string Pitting_Excavation_Cumulative { get; set; }
        public string Pitting_Excavation_Dimension { get; set; }

        public string Pitting_trenches_Beginning { get; set; }
        public string Pitting_trenches_During { get; set; }
        public string Pitting_trenches_Cumulative { get; set; }
        public string Pitting_trenches_Dimension { get; set; }

        public string Pitting_Excavation1_Beginning { get; set; }
        public string Pitting_Excavation1_During { get; set; }
        public string Pitting_Excavation1_Cumulative { get; set; }
        public string Pitting_Excavation1_Dimension { get; set; }

        public string Pitting_Length_Beginning { get; set; }
        public string Pitting_Length_During { get; set; }
        public string Pitting_Length_Cumulative { get; set; }
        public string Pitting_Length_Dimension { get; set; }

        public string Expenditure_Beginning { get; set; }
        public string Expenditure_During { get; set; }
        public string Expenditure_Cumulative { get; set; }

        public string Exploration_Activity { get; set; }
        public string Year { get; set; }
        public int? Flag1 { get; set; }
        public int? UserId { get; set; }
    }
    public class ReservesAndResources
    {
        public int Resources_Id { get; set; }
        public string BegningYear { get; set; }
        public string ClosingYear { get; set; }

        public string AtBeginning_Proved { get; set; }
        public string Assessed_Proved { get; set; }
        public string Depletion_Proved { get; set; }
        public string Balance_Proved { get; set; }

        public string AtBeginning_Probable1 { get; set; }
        public string Assessed_Probable1 { get; set; }
        public string Depletion_Probable1 { get; set; }
        public string Balance_Probable1 { get; set; }

        public string AtBeginning_Probable2 { get; set; }
        public string Assessed_Probable2 { get; set; }
        public string Depletion_Probable2 { get; set; }
        public string Balance_Probable2 { get; set; }

        public string AtBeginning_TotalReserves { get; set; }
        public string Assessed_TotalReserves { get; set; }
        public string Depletion_TotalReserves { get; set; }
        public string Balance_TotalReserves { get; set; }

        public string AtBeginning_Feasibility { get; set; }
        public string Assessed_Feasibility { get; set; }
        public string Depletion_Feasibility { get; set; }
        public string Balance_Feasibility { get; set; }

        public string AtBeginning_Prefeasibility1 { get; set; }
        public string Assessed_Prefeasibility1 { get; set; }
        public string Depletion_Prefeasibility1 { get; set; }
        public string Balance_Prefeasibility1 { get; set; }

        public string AtBeginning_Prefeasibility2 { get; set; }
        public string Assessed_Prefeasibility2 { get; set; }
        public string Depletion_Prefeasibility2 { get; set; }
        public string Balance_Prefeasibility2 { get; set; }

        public string AtBeginning_Measured { get; set; }
        public string Assessed_Measured { get; set; }
        public string Depletion_Measured { get; set; }
        public string Balance_Measured { get; set; }

        public string AtBeginning_Indicated { get; set; }
        public string Assessed_Indicated { get; set; }
        public string Depletion_Indicated { get; set; }
        public string Balance_Indicated { get; set; }

        public string AtBeginning_Inferred { get; set; }
        public string Assessed_Inferred { get; set; }
        public string Depletion_Inferred { get; set; }
        public string Balance_Inferred { get; set; }

        public string AtBeginning_Reconnaissance { get; set; }
        public string Assessed_Reconnaissance { get; set; }
        public string Depletion_Reconnaissance { get; set; }
        public string Balance_Reconnaissance { get; set; }

        public string AtBeginning_Totalremaining { get; set; }
        public string Assessed_Totalremaining { get; set; }
        public string Depletion_Totalremaining { get; set; }
        public string Balance_Totalremaining { get; set; }

        public string AtBeginning_Total { get; set; }
        public string Assessed_Total { get; set; }
        public string Depletion_Total { get; set; }
        public string Balance_Total { get; set; }
        public int? Flag2 { get; set; }
        public string Year { get; set; }
        public int? UserId { get; set; }

    }
    public class RejectWasteTreesPlanted
    {
        public int RWT_Id { get; set; }

        public string Reject_AtBeginning { get; set; }
        public string Reject_DuringYear { get; set; }
        public string Reject_DisposedDuringYear { get; set; }
        public string Reject_Stacked { get; set; }
        public string Reject_AverageGrade { get; set; }

        //This has been added as per change form H-1 to G-1
        public string Processed_AtBeginning { get; set; }
        public string Processed_DuringYear { get; set; }
        public string Processed_DisposedDuringYear { get; set; }
        public string Processed_Stacked { get; set; }
        public string Processed_AverageGrade { get; set; }
        //------------------------------------------------
        public string Waste_AtBeginning { get; set; }
        public string Waste_DuringYear { get; set; }
        public string Waste_DisposedDuringYear { get; set; }
        public string Waste_Stacked { get; set; }
        public string Waste_AverageGrade { get; set; }

        public string Treesplanted_in_LeaseArea { get; set; }
        public string Treesplanted_Outside_LeaseArea { get; set; }
        public string Survivalrate_in_LeaseArea { get; set; }
        public string Survivalrate_Outside_LeaseArea { get; set; }
        public string NoOFTrees_in_LeaseArea { get; set; }
        public string NoOFTrees_Outside_LeaseArea { get; set; }

        public string Year { get; set; }
        public int? Flag3 { get; set; }
        public int? UserId { get; set; }
    }
    public class FurnishDetails
    {
        public int Furnish_Id { get; set; }
        public string Mineral_Treatment { get; set; }

        public string TonnageFeed { get; set; }
        public string AverageFeed { get; set; }

        public string Processed_products { get; set; }
        public string Processed_Tonnage { get; set; }
        public string Processed_Average { get; set; }

        public string Co_products { get; set; }
        public string Co_products_Tonnage { get; set; }
        public string Co_products_Average { get; set; }

        public string TonnageTailings { get; set; }
        public string AverageTailings { get; set; }

        public string Year { get; set; }
        public int? Flag4 { get; set; }
        public int? UserId { get; set; }
    }
    public class MachineryDetails
    {
        public int? MachineryType_Id { get; set; } 
        public string TypeofMachinery { get; set; } 
        public string Capacity { get; set; } 
        public string Capacity_Unit { get; set; } 
        public string NoofMachinery { get; set; } 
        public string Type_Electrical { get; set; } 
        public string Used_Area { get; set; } 
        public string Year1 { get; set; }
        public int? IsActive { get; set; }
        public int? UserId { get; set; }
        public string Year { get; set; }
    }
}
