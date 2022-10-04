// ***********************************************************************
//  Class Name               : SR_Conservation_Renewal
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
    public class SR_Conservation_Renewal
    {
        public int Id { get; set; }
        public int? Assesment_Id { get; set; }
        public string Conservation_Type { get; set; }
        public string Conservation_Details { get; set; }
        public string Rating_Value { get; set; }
        public int? Points_Obtained { get; set; }
    }
}