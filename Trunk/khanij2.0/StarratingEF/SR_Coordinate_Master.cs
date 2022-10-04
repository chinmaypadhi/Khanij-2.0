// ***********************************************************************
//  Class Name               : SR_Coordinate_Master
//  Desciption               : Starrating Assessment
//  Created By               : Lingaraj Dalai
//  Created On               : 30 April 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace StarratingEF
{
    public class SR_Coordinate_Master
    {
        public int Coordinate_Id { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int Assesment_Id { get; set; }
    }
}
