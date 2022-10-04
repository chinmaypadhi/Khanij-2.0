// ***********************************************************************
//  Class Name               : SR_Lease_Area_Master
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
    public class SR_Lease_Area_Master
    {
        public int Lease_Area_Id { get; set; }
        public int? Area_Type_Id { get; set; }
        public double? Area_In_Hectare { get; set; }
        public int? Assesment_Id { get; set; }
        public string LeaseAreaType { get; set; }
    }
}