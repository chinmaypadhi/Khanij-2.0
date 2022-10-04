// ***********************************************************************
//  Class Name               : AddUserProfileModel
//  Desciption               : Add,Edit,Update Website User Profile Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 05 Nov 2021
// ***********************************************************************
using Microsoft.AspNetCore.Http;

namespace HomeEF
{
    public class AddUserProfileModel
    {
        public int? INT_UPROFILE_ID { get; set; }
        public int? INT_CREATED_BY { get; set; }
        public string VCH_NAME { get; set; }
        public string VCH_DESIGNATION { get; set; }
        public string VCH_DEPARTMENT { get; set; }
        public string VCH_PHOTO_PATH { get; set; }
        public string VCH_MOBILE_NO { get; set; }
        public string VCH_OFC_EXTN_NO { get; set; }
        public string VCH_EMAIL_ID { get; set; }
        public string VCH_USER_ID { get; set; }
        public string VCH_PASSWORD { get; set; }
        public string VCH_CONF_PASSWORD { get; set; }
        public IFormFile Photo { get; set; }
    }
}
