// ***********************************************************************
//  Class Name               : ProfileStatusModel
//  Description              : Lessee Profile Status Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 09 July 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterEF
{
    public class ProfileStatusModel
    {
        public int? OPERATION_OFFICE_DETAILS { get; set; }
        public int? OPERATION_GRANT_DETAILS { get; set; }
        public int? OPERATION_LEASE_AREA_DETAILS { get; set; }
        public int? OPERATION_MINING_PLAN_DETAILS { get; set; }
        public int? OPERATION_MINERAL_INFO_DETAILS { get; set; }
        public int? OPERATION_APPLICATION_DETAILS { get; set; }
        public int? OPERATION_CONSENT_TO_OPERATE_DETAILS { get; set; }
        public int? OPERATION_CONSENT_TO_ESTABLISH_DETAILS { get; set; }
        public int? OPERATION_IBM_DETAILS { get; set; }
        public int? OPERATION_ENVIRONMENTAL_CLEARANCE_DETAILS { get; set; }
        public int? OPERATION_ASSESSMENT_REPORT { get; set; }
        public int? FOREST_STATUS { get; set; }
    }
}
