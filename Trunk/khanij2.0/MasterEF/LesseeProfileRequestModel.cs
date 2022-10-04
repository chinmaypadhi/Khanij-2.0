// ***********************************************************************
//  Class Name               : LesseeProfileRequestModel
//  Description              : Lessee Profile Request Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 09 July 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterEF
{
    public class LesseeProfileRequestModel
    {
        public int? ID { get; set; }
        public string APPLICANT_NAME { get; set; }
        public string USER_NAME { get; set; }
        public string DISTRICT_NAME { get; set; }
        public string STATE_NAME { get; set; }
        public string REQUESTED_ON { get; set; }
        public string REQUESTED_FOR { get; set; }
        public int? STATUS { get; set; }
        public string REQUEST_STATUS { get; set; }
        public string Path { get; set; }
        public int? LesseeCntPendency { get; set; }
        public string REQUEST { get; set; }
        public int? USER_ID { get; set; }
    }
}
