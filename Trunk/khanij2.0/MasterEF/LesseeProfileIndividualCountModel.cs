// ***********************************************************************
//  Class Name               : LesseeProfileIndividualCountModel
//  Desciption               : Lessee Profile Request Count Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 03 March 2022
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterEF
{
    public class LesseeProfileIndividualCountModel
    {
        public int? UserId { get; set; }
        public string ApplicantName { get; set; }
        public string UserTypeName { get; set; }
        public int? IndividualId { get; set; }
        public int? LESSEE_OFFICE_COUNT { get; set; }
        public int? LESSEE_APPLICATION_COUNT { get; set; }
        public int? LESSEE_LICENSE_COUNT { get; set; }
        public int? LESSEE_FOREST_CLEARANCE_COUNT { get; set; }
        public int? LESSEE_MINERAL_INFORMATION_COUNT { get; set; }
        public int? LESSEE_MINING_PLAN_COUNT { get; set; }
        public int? LESSEE_GRANT_ORDER_COUNT { get; set; }
        public int? LESSEE_CTE_COUNT { get; set; }
        public int? LESSEE_CTO_COUNT { get; set; }
        public int? LESSEE_IBM_COUNT { get; set; }
        public int? LESSEE_EC_COUNT { get; set; }
        public int? LESSEE_Assessment_COUNT { get; set; }
        public int? LESSEE_New_Application_Count { get; set; }
    }
}
