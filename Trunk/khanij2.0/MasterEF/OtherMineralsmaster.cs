// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 27-Jan-2021
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

namespace MasterEF
{
    public class OtherMineralsmaster
    {
        public int? OtherMineralId { get; set; }
        public int? MineralId { get; set; }
        public string MineralName { get; set; }
        public string Fector1 { get; set; }
        public decimal? Fector2 { get; set; }
        public string EffectiveFromDate { get; set; }
        public string EffectiveToDate { get; set; }
        public int? Status { get; set; }
        public int? IsPublish { get; set; }
        public string DscFilePath { get; set; }
        public int? IsActive { get; set; }
        public int? UserId { get; set; }
        public int? UserLoginId { get; set; }
    }
}
