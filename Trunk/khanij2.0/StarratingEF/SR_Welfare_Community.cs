// ***********************************************************************
//  Class Name               : SR_Welfare_Community
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
    public class SR_Welfare_Community
    {
        public int Id { get; set; }
        public int? Assesment_Id { get; set; }
        public string Welfare_Community_Type { get; set; }
        public double? Total_Royalty_Or_Mandays_Worked { get; set; }
        public double? Total_Expenditure_Or_Mandays_Worked_LocalManPower { get; set; }
        public string Rating_Value { get; set; }
        public int? Points_Obtained { get; set; }

    }
}