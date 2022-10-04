// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 20-Jan-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace MasterEF
{
    public class Checkpostmaster
    {
        public int? CheckPostId { get; set; }
        public string CheckPostName { get; set; }
        public int? DistrictID { get; set; }
        public string DistrictName { get; set; }
        public int? UserID { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string ActiveStatus { get; set; }
    }
}
