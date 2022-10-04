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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MasterEF
{
    public class Routemaster
    {

        public int? RouteID { get; set; }
        public string RouteName { get; set; }
        public int? DistrictID { get; set; }        
        public string DistrictName { get; set; }
        public string Remarks { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string ActiveStatus { get; set; }
        
    }
     
}
