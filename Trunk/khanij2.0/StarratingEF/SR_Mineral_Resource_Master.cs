// ***********************************************************************
//  Class Name               : SR_Mineral_Resource_Master
//  Desciption               : Starrating Assessment
//  Created By               : Lingaraj Dalai
//  Created On               : 30 April 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StarratingEF
{
    public class SR_Mineral_Resource_Master
    {
        public int Mineral_Resource_Id { get; set; }
        public int? Mineral_Id { get; set; }
        public double? Available_Resource { get; set; }
        public int? Approved_Quantity { get; set; }
        public int? Actual_Quantity { get; set; }
        public int? Assesment_Id { get; set; }
    }
}