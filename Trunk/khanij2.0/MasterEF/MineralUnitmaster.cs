// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 18-Jan-2021
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
    public class MineralUnitmaster
    {
        public int MineralUnitID { get; set; }


        public string MineralUnitName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public int ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string Status { get; set; }
    }
}
