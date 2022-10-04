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
    public class YearlyReturnModel
    {
        public string FinancialYear { get; set; }
        public string Status { get; set; }
        public string ModifiedOn { get; set; }
        public string FormType { get; set; }
        public int? MineralId { get; set; }
        public string MineralName { get; set; }
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
}
