// ***********************************************************************
// Assembly         : Khanij
// Author           : Debaraj Swain
// Created          : 12-Jan-2021
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
using System.Data;

namespace ReturnEF
{
   public class DailyProductionModel
    {
        public int? DailyProductionMasterId { get; set; }
        public int? SrNo { get; set; }
        public int MineralId { get; set; }
        public decimal TotalQty { get; set; }
        public string MineralName { get; set; }
        public string jsonSerialize { get; set; }


        public int? MineralFormID { get; set; }
        public string MineralForm { get; set; }

        public int? MineralNatureId { get; set; }
        public string MineralNature { get; set; }


        public int? MineralGradeID { get; set; }
        public string MineralGrade { get; set; }

        public int? UserId { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? DisplayQuantity { get; set; }

      
        public DateTime? Date { get; set; }

        public string ProductionDate { get; set; }
        public string ProductionYear { get; set; }
        public string ProductionMonth { get; set; }
        public decimal? TotalProduction { get; set; }
        public decimal? ProductionMonthlyAmount { get; set; }
        public decimal? TotalPayableProductionMonthlyAmount { get; set; }

        public int? PaymentMode { get; set; }
        public int? IsSubmited { get; set; }

        public string PaymentBank { get; set; }
        public string P_Mode { get; set; }
        public string NetBanking_mode { get; set; }
        public string ProductionDataAvailableStatus { get; set; }
        public string ApplicantName { get; set; }
        public string UserCode { get; set; }
        public string DistrictName { get; set; }
        public decimal PaidAmount { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentStatus { get; set; }
       



        public DataTable DT { get; set; }
        public string Production { get; set; }
        public string ProductionCap { get; set; }
        
        public string RunningQty { get; set; }
        public string Dispatch { get; set; }
        public string PCap { get; set; }
        public string MonthYear { get; set; }

        public string M_Id { get; set; }
        public string Months { get; set; }
        public string IsSelected { get; set; }

    
        public string Year { get; set; }
        public string UniqueID { get; set; }


    }
    public class GetMineralResult
    {
        public List<DailyProductionModel> GetMineralLst { get; set; }
    }
    public class GetMonthResult
    {
        public List<DailyProductionModel> GetMonthLst { get; set; }
    }
    public class GetYearResult
    {
        public List<DailyProductionModel> GetYearLst { get; set; }
    }
}
