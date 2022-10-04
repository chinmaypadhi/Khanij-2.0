// ***********************************************************************
//  Class Name               : SR_Lease_Area_Mineral
//  Desciption               : Starrating Assessment
//  Created By               : Lingaraj Dalai
//  Created On               : 30 April 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace StarratingEF
{
    public class SR_Lease_Area_Mineral
    {
        public int LeaseAreaMineralID { get; set; }
        public int? MineralID { get; set; }
        public double? LeaseArea { get; set; }
        public int? Assesment_Id { get; set; }
        public string MineralName { get; set; }
    }
}
