// ***********************************************************************
// Assembly         : Khanij
// Author           : Debaraj Swain
// Created          : 05-Jan-2021
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
    public class Statemaster
    {
        public int StateID { get; set; }
       
       
        public string StateName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public string ActiveStatus { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string Status { get; set; }
        public int UserLoginID { get; set; }
    }
}
