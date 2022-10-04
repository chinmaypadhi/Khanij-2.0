// ***********************************************************************
//  Class Name               : MPRWorkmaster
//  Desciption               : Monthly Progress Report work master Model Class
//  Created By               : Lingaraj Dalai
//  Created On               : 02 March 2021
// ***********************************************************************
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace GeologyEF
{
    public class MPRWorkmaster
    {
        public MPRWorkmaster()
        {

            List_Camps_Name = new List<string>();
            List_Camps_Designation = new List<string>();
            List_Camps_From = new List<string>();
            List_Camps_To = new List<string>();
            List_Camps_No_Of_Days = new List<string>();
            List_Camps_Remarks = new List<string>();
        }
        public int? MPR_Id { get; set; }
        public int? UserId { get; set; }
        public int? Approve_Status { get; set; }
        public string Status { get; set; }
        public int? UserLoginId { get; set; }
        #region MPRPreview
        public string MPR_Code { get; set; }
        public string Str_Report_MY { get; set; }
        public string Str_SubmissionDate { get; set; }
        public string Up_To_The_Last_Month { get; set; }
        public string During_The_Month { get; set; }
        public string Labor { get; set; }
        public string POL { get; set; }
        public string Repair_And_Maintenance { get; set; }
        public string others { get; set; }
        public string Total { get; set; }
        #region Reconn
        public string Reconn_Area_Target { get; set; }
        public string Reconn_Area_Last_Month { get; set; }
        public string Reconn_Area_During_Month { get; set; }
        public string Reconn_Area_Current_Month { get; set; }
        #endregion
        #region TDetailed
        public string Detailed_Area_Target { get; set; }
        public string Detailed_Area_Last_Month { get; set; }
        public string Detailed_Area_During_Month { get; set; }
        public string Detailed_Area_Current_Month { get; set; }
        #endregion
        #region  Pitting
        public string Pitting_Nos_Target { get; set; }
        public string Pitting_Nos_Last_Month { get; set; }
        public string Pitting_Nos_During_Month { get; set; }
        public string Pitting_Nos_Current_Month { get; set; }

        public string Pitting_Volume_Target { get; set; }
        public string Pitting_Volume_Last_Month { get; set; }
        public string Pitting_Volume_During_Month { get; set; }
        public string Pitting_Volume_Current_Month { get; set; }
        #endregion
        #region Trenching
        public string Trenching_Nos_Target { get; set; }
        public string Trenching_Nos_Last_Month { get; set; }
        public string Trenching_Nos_During_Month { get; set; }
        public string Trenching_Nos_Current_Month { get; set; }


        public string Trenching_Volume_Target { get; set; }
        public string Trenching_Volume_Last_Month { get; set; }
        public string Trenching_Volume_During_Month { get; set; }
        public string Trenching_Volume_Current_Month { get; set; }
        #endregion
        #region Drilling
        public string B_H_Cpmpleted_Target { get; set; }
        public string B_H_Cpmpleted_Last_Month { get; set; }
        public string B_H_Cpmpleted_During_Month { get; set; }
        public string B_H_Cpmpleted_Current_Month { get; set; }

        public string Metrage_Target { get; set; }
        public string Metrage_Last_Month { get; set; }
        public string Metrage_During_Month { get; set; }
        public string Metrage_Current_Month { get; set; }

        public string Metrage_2_Target { get; set; }
        public string Metrage_2_Last_Month { get; set; }
        public string Metrage_2_During_Month { get; set; }
        public string Metrage_2_Current_Month { get; set; }

        public string B_H_Under_Progress_Target { get; set; }
        public string B_H_Under_Progress_Last_Month { get; set; }
        public string B_H_Under_Progress_During_Month { get; set; }
        public string B_H_Under_Progress_Current_Month { get; set; }

        public string Total_Metrage_Target { get; set; }
        public string Total_Metrage_Last_Month { get; set; }
        public string Total_Metrage_During_Month { get; set; }
        public string Total_Metrage_Current_Month { get; set; }
        #endregion
        #region Geochemical Sampling
        public string Geochemical_Sampling_Target { get; set; }
        public string Geochemical_Sampling_Last_Month { get; set; }
        public string Geochemical_Samplinge_During_Month { get; set; }
        public string Geochemical_Sampling_Current_Month { get; set; }
        #endregion
        #region Geophysical Survey
        public string Geophysical_Survey_Target { get; set; }
        public string Geophysical_Survey_Last_Month { get; set; }
        public string Geophysical_Survey_During_Month { get; set; }
        public string Geophysical_Survey_Current_Month { get; set; }
        #endregion
        #region Photogeological Survey


        public string Prefield_Interpretation_Target { get; set; }
        public string Prefield_Interpretation_Last_Month { get; set; }
        public string Prefield_Interpretation_During_Month { get; set; }
        public string Prefield_Interpretation_Current_Month { get; set; }

        public string Postfield_Interpretation_Target { get; set; }
        public string Postfield_Interpretation_Last_Month { get; set; }
        public string Postfield_Interpretation_During_Month { get; set; }
        public string Postfield_Interpretation_Current_Month { get; set; }

        public string Field_Check_Target { get; set; }
        public string Field_Check_Last_Month { get; set; }
        public string Field_Check_During_Month { get; set; }
        public string Field_Check_Current_Month { get; set; }
        #endregion
        #region Sampling (Surface/Core Sample)
        public string Sample_Drawn_Target { get; set; }
        public string Sample_Drawn_Last_Month { get; set; }
        public string Sample_Drawn_During_Month { get; set; }
        public string Sample_Drawn_Current_Month { get; set; }

        public string Sample_Prepared_Target { get; set; }
        public string Sample_Prepared_Last_Month { get; set; }
        public string Sample_Prepared_During_Month { get; set; }
        public string Sample_Prepared_Current_Month { get; set; }

        public string Sample_Sent_For_Chemical_Analysis_Target { get; set; }
        public string Sample_Sent_For_Chemical_Analysis_Last_Month { get; set; }
        public string Sample_Sent_For_Chemical_Analysis_During_Month { get; set; }
        public string Sample_Sent_For_Chemical_Analysis_Current_Month { get; set; }

        public string Sample_Sent_For_Petrography_Target { get; set; }
        public string Sample_Sent_For_Petrography_Last_Month { get; set; }
        public string Sample_Sent_For_Petrography_During_Month { get; set; }
        public string Sample_Sent_For_Petrography_Current_Month { get; set; }
        #endregion
        #region Reserves
        public string Inferred_Target { get; set; }
        public string Inferred_Last_Month { get; set; }
        public string Inferred_During_Month { get; set; }
        public string Inferred_Current_Month { get; set; }

        public string Estimated_Target { get; set; }
        public string Estimated_Last_Month { get; set; }
        public string Estimated_During_Month { get; set; }
        public string Estimated_Current_Month { get; set; }

        public string Proved_Target { get; set; }
        public string Proved_Last_Month { get; set; }
        public string Proved_During_Month { get; set; }
        public string Proved_Current_Month { get; set; }
        #endregion
        #region Topographical Survey
        public string Laying_Of_Base_Line_Target { get; set; }
        public string Laying_Of_Base_Line_Last_Month { get; set; }
        public string Laying_Of_Base_Line_During_Month { get; set; }
        public string Laying_Of_Base_Line_Current_Month { get; set; }

        public string Laying_Of_Grids_Target { get; set; }
        public string Laying_Of_Grids_Last_Month { get; set; }
        public string Laying_Of_Grids_During_Month { get; set; }
        public string Laying_Of_Grids_Current_Month { get; set; }

        public string No_of_Pits_Target { get; set; }
        public string No_of_Pits_Last_Month { get; set; }
        public string No_of_Pits_During_Month { get; set; }
        public string No_of_Pits_Current_Month { get; set; }

        public string Co_ordinates_Of_Pits_Target { get; set; }
        public string Co_ordinates_Of_Pits_Last_Month { get; set; }
        public string Co_ordinates_Of_Pits_During_Month { get; set; }
        public string Co_ordinates_Of_Pits_Current_Month { get; set; }

        public string Contouring_Target { get; set; }
        public string Contouring_Last_Month { get; set; }
        public string Contouring_During_Month { get; set; }
        public string Contouring_Current_Month { get; set; }

        public string Plotting_Of_Permanent_Features_Target { get; set; }
        public string Plotting_Of_Permanent_Features_Last_Month { get; set; }
        public string Plotting_Of_Permanent_Features_During_Month { get; set; }
        public string Plotting_Of_Permanent_Features_Current_Month { get; set; }

        public string Plotting_Of_Road_Nala_Target { get; set; }
        public string Plotting_Of_Road_Nala_Last_Month { get; set; }
        public string Plotting_Of_Road_Nala_During_Month { get; set; }
        public string Plotting_Of_Road_Nala_Current_Month { get; set; }

        #endregion
        public string Resources { get; set; }
        public string Camps_Name { get; set; }
        public string Camps_Designation { get; set; }
        public string Camps_From { get; set; }
        public string Camps_To { get; set; }
        public string Camps_No_Of_Days { get; set; }
        public string Camps_Remarks { get; set; }
        public List<string> List_Camps_Name { get; set; }
        public List<string> List_Camps_Designation { get; set; }
        public List<string> List_Camps_From { get; set; }
        public List<string> List_Camps_To { get; set; }
        public List<string> List_Camps_No_Of_Days { get; set; }
        public List<string> List_Camps_Remarks { get; set; }
        public string MapName { get; set; }
        public string BoreholeLogs { get; set; }
        public string LogName { get; set; }
        public string Synopsis { get; set; }
        public string SynopsisName { get; set; }
        public string Other_Info { get; set; }
        public string OtherName { get; set; }
        public int SrNo { get; set; }
        public string Map { get; set; }
        #endregion
        #region MPRWork
        public int? WorkType_Id { get; set; }
        public string Volume_ofWork { get; set; }
        public int? UnitID { get; set; }
        public string Location_NewM { get; set; }
        public string No_ofEmployees { get; set; }
        public decimal? TotalExp { get; set; }
        public IFormFile MapAttachment { get; set; }
        public IFormFile BoreholeAttachment { get; set; }
        public IFormFile SynopsisAttachment { get; set; }
        public IFormFile Other_InfoAttachment { get; set; }
        public string Camps_Namedetails { get; set; }
        public string Camps_Designationdetails { get; set; }
        public string Camps_Fromdetails { get; set; }
        public string Camps_Todetails { get; set; }
        public string Camps_No_Of_Daysdetails { get; set; }
        public string Camps_Remarksdetails { get; set; }
        public int? Work_Id { get; set; }
        #endregion
    }
}
