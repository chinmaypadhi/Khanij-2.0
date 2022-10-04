using System;
using System.Collections.Generic;
using System.Text;

namespace userregistrationEF
{
    public class PublicGrievanceModel
    {
        public PublicGrievanceModel()
        {
            this.GRIEVANCE_COMPLAINT_ID = 0L;
            this.SUBJECT_OF_COMPLAINT = String.Empty;
            this.COMPLAINT_IN_BRIEF = String.Empty;
            this.USER_CODE_OF_COMPLAINER = String.Empty;
            this.NAME_OF_COMPLAINER = String.Empty;
            this.COMPLETE_ADDRESS = String.Empty;
            this.DISTRICT = 0;
            this.Type = "";
            this.STATE = 0;
            this.PINCODE = String.Empty;
            this.MOBILE_NUMBER_OF_COMPLAINER = String.Empty;

            this.EMAIL_ADDRESS_OF_COMPLAINER = String.Empty;
            this.TO_WHOM_AGAINST_COMPLAINT = String.Empty;
            this.ROLE_OF_WHOME_AGAINST_COMPLAINT = String.Empty;
            this.ADDRESS = String.Empty;
            //this.MOBILE_NUMBER = String.Empty;
            this.ATTACHMENT_FILE_NAME = String.Empty;
            this.ATTACHMENT_FILE_PATH = String.Empty;
            this.ACTIVE_STATUS = 0;
            this.GRIEVANCE_COMPLAINT_TYPE_ID = 0;
            this.ComplaintNumber = String.Empty;
        }
        public long? GRIEVANCE_COMPLAINT_ID { get; set; }

        public int? GRIEVANCE_COMPLAINT_TYPE_ID { get; set; }
        public string Type { get; set; }


        public String SUBJECT_OF_COMPLAINT { get; set; }


        public String COMPLAINT_IN_BRIEF { get; set; }


        public String OtherSubject { get; set; }


        public String USER_CODE_OF_COMPLAINER { get; set; }


        public String NAME_OF_COMPLAINER { get; set; }


        public String COMPLETE_ADDRESS { get; set; }


        public int? DISTRICT { get; set; }
        public String DISTRICT_NAME { get; set; }


        public int STATE { get; set; }
        public String STATE_NAME { get; set; }


        public int? C_DISTRICT { get; set; }
        public String C_DISTRICT_NAME { get; set; }


        //[Required(ErrorMessage = "Tehsil required")]
        public int? C_TEHSIL { get; set; }
        public String C_TEHSIL_NAME { get; set; }


        //[Required(ErrorMessage = "Village required")]
        public int? C_VILLAGE { get; set; }
        public String C_VILLAGE_NAME { get; set; }


        public int? REGION { get; set; }

        public string PINCODE { get; set; }


        public String MOBILE_NUMBER_OF_COMPLAINER { get; set; }


        public String EMAIL_ADDRESS_OF_COMPLAINER { get; set; }


        //[Required(ErrorMessage = "Name required")]
        public String TO_WHOM_AGAINST_COMPLAINT { get; set; }


        //[Required(ErrorMessage = "Designation / Post required")]
        public String ROLE_OF_WHOME_AGAINST_COMPLAINT { get; set; }


        public String Action_Against { get; set; }


        public String ADDRESS { get; set; }

        //[Display(Name = "Mobile Number")]
        //[StringLength(10, MinimumLength = 10, ErrorMessage = "Invalid Mobile Number")]
        //public String MOBILE_NUMBER { get; set; }


        //  public HttpPostedFileBase ATTACHMENT { get; set; }
        public String ATTACHMENT_FILE_NAME { get; set; }
        public String ATTACHMENT_FILE_PATH { get; set; }
        public int ACTIVE_STATUS { get; set; }

        public string Date { get; set; }
        public string Complaint_Status { get; set; }
        public string ComplaintNumber { get; set; }
    }
}
