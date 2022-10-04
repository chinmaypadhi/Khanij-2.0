// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 15-Jan-2021
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
    public class Prioritymaster
    {
        public int PriorityID { get; set; }


        public string PriorityName { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public string _status { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string Status { get; set; }
        public int UserLoginID { get; set; }
    }
}
