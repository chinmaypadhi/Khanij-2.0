// ***********************************************************************
//  Class Name               : SR_Statutory_Compliance
//  Desciption               : Starrating Assessment
//  Created By               : Lingaraj Dalai
//  Created On               : 30 April 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace StarratingEF
{
    public class SR_Statutory_Compliance
    {
        public int Id { get; set; }
        public int? Assesment_Id { get; set; }
        public string Compliance_Type { get; set; }
        public string Compliance_Details { get; set; }
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
