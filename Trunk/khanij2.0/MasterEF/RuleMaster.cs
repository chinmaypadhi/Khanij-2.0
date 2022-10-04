// ***********************************************************************
// Assembly         : Khanij
// Author           : Debaraj Swain
// Created          : 11-Jan-2021
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
   public class RuleMaster
    {
        public int? RuleID { get; set; }
        public string RuleName { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string Status { get; set; }
        public string strCreateddate { get; set; }

    }

}
