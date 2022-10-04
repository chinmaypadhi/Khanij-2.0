using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace SupportEF
{
    public class AddPublicGrievanceModel
    {
        public IFormFile ATTACHMENT { get; set; }
       
        public int? GRIEVANCE_COMPLAINT_TYPE_ID { get; set; }
        public String SUBJECT_OF_COMPLAINT { get; set; }
        public String COMPLAINT_IN_BRIEF { get; set; }
        public String USER_CODE_OF_COMPLAINER { get; set; }
        public String NAME_OF_COMPLAINER { get; set; }
        public String COMPLETE_ADDRESS { get; set; }
        public int? DISTRICT { get; set; }
        public int? STATE { get; set; }
        public int? IntUserId { get; set; }
        public string PINCODE { get; set; }
        public string Date { get; set; }

        public String MOBILE_NUMBER_OF_COMPLAINER { get; set; }
        public String EMAIL_ADDRESS_OF_COMPLAINER { get; set; }
        public String TO_WHOM_AGAINST_COMPLAINT { get; set; }
        public String ROLE_OF_WHOME_AGAINST_COMPLAINT { get; set; }
        public String ADDRESS { get; set; }
        public String ATTACHMENT_FILE_NAME { get; set; }
        public String ATTACHMENT_FILE_PATH { get; set; }
        public String Action_Against { get; set; }
        public int? C_DISTRICT { get; set; }
        public String OtherSubject { get; set; }
        public int? C_TEHSIL { get; set; }
        public int? C_VILLAGE { get; set; }
    }
    public class ForwardMItoDD
    {
        public int? Uid { get; set; }
        public long? Gid { get; set; }
        public String Remark { get; set; }
        public String AFilename { get; set; }
        public String base64GrivanceForward { get; set; }
    }
    public class CloseComplain
    {
        public int? IntUserId { get; set; }
        public long? GRIEVANCE_COMPLAINT_ID { get; set; }
        public String ATTACHMENT_FILE_NAME { get; set; }
        public String base64GrivanceClose { get; set; }

    }


}
