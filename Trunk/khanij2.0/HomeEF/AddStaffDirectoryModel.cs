// ***********************************************************************
//  Class Name               : AddStaffDirectoryModel
//  Desciption               : Add Staff Directory Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 20 Oct 2021
// ***********************************************************************
using Microsoft.AspNetCore.Http;

namespace HomeEF
{
    public class AddStaffDirectoryModel
    {
        public int? INT_STAFFDIR_ID { get; set; }
        public int? INT_OFFICE_TYPE_ID { get; set; }
        public string VCH_OFFICE_TYPE { get; set; }
        public string VCH_OFFICER_NAME { get; set; }
        public string VCH_OFFICER_DESIG { get; set; }
        public string VCH_PHONE_NO { get; set; }
        public string VCH_EMAIL { get; set; }
        public string VCH_LOCATION { get; set; }
        public int? INT_CREATED_BY { get; set; }
        public bool BIT_STATUS { get; set; }
    }
}
