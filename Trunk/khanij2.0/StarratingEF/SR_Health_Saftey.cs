// ***********************************************************************
//  Class Name               : SR_Health_Saftey
//  Desciption               : Starrating Assessment
//  Created By               : Lingaraj Dalai
//  Created On               : 30 April 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace StarratingEF
{
    public class SR_Health_Saftey
    {
        public int Id { get; set; }
        public int? Assesment_Id { get; set; }
        public string Health_Saftey_Type { get; set; }
        public int? Total_Employment { get; set; }
        public double? Percentage_Total_Employment { get; set; }
        public string Details { get; set; }
        public int? Rating_Value { get; set; }
        public int? Points_Obtained { get; set; }

        //Point
        public int? First_Point { get; set; }
        public string First_Remark { get; set; }
        public int? Second_Point { get; set; }
        public string Second_Remark { get; set; }
        public int? Third_Point { get; set; }
        public string Third_Remark { get; set; }
        public string Mode { get; set; }
    }
}
