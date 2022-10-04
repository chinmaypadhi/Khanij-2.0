using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace SupportEF
{
   public class PublicGrievanceModel
    {
        public PublicGrievanceModel()
        {

            this.GRIEVANCE_COMPLAINT_ID = 0;
            this.SUBJECT_OF_COMPLAINT = String.Empty;
            this.COMPLAINT_IN_BRIEF = String.Empty;
            this.USER_CODE_OF_COMPLAINER = String.Empty;
            this.NAME_OF_COMPLAINER = String.Empty;
            this.COMPLETE_ADDRESS = String.Empty;
            this.DISTRICT = 0;
            this.STATE = 0;
            this.PINCODE = String.Empty;
            this.MOBILE_NUMBER_OF_COMPLAINER = String.Empty;

            this.EMAIL_ADDRESS_OF_COMPLAINER = String.Empty;
            this.TO_WHOM_AGAINST_COMPLAINT = String.Empty;
            this.ROLE_OF_WHOME_AGAINST_COMPLAINT = String.Empty;
            this.ADDRESS = String.Empty;
            //this.MOBILE_NUMBER = String.Empty;
            
            this.ATTACHMENT_FILE_PATH = String.Empty;
            this.ACTIVE_STATUS = 0;
            this.GRIEVANCE_COMPLAINT_TYPE_ID = 0;
            this.ComplaintNumber = String.Empty;
            this.DistrictID = 0;
            this.DistrictName = String.Empty;
            this.TEXT = String.Empty;
            this.VALUE = String.Empty;
            this.MobileNo = String.Empty;
            this.EmailId = String.Empty;
            this.OTP = String.Empty;
            this.IntUserId = 0;
            this.IsBackendApprove = 0;
            this.FromDate = String.Empty;
            this.ToDate = String.Empty;
            this.MOBILE_NUMBER = String.Empty;
            this.DGM_REMARKS = String.Empty;
            this.MINING_INSPECTER_REMARKS= String.Empty;
            this.MIResultFile = string.Empty;
            this.ComplaintType = string.Empty;
            this.RoleId = 0;
            this.RoleName = string.Empty;
            this.UserType = string.Empty;
            this.COC = string.Empty;
            this.DD_DMO_REMARKS = string.Empty;
            this.MINING_INSPECTER_ID = 0;
            this.base64GrivanceRegistration = string.Empty;
            this.OtherSubject = String.Empty;
            this.DISTRICT_NAME = String.Empty;
            this.STATE_NAME = String.Empty;
            this.C_DISTRICT = 0;
            this.C_DISTRICT_NAME = String.Empty;
            this.C_TEHSIL_NAME = String.Empty;
            this.C_VILLAGE = 0;
            this.C_TEHSIL = 0;
            this.C_VILLAGE_NAME = String.Empty;
            this.Action_Against = String.Empty;
            this.ATTACHMENT_FILE_NAME = String.Empty;
            this.REGION = 0;
            this.Date = string.Empty;
            this.Complaint_Status = string.Empty;
            this.fileURLPath = string.Empty;   
            this.Type = string.Empty;   
        }
        
       
        public string fileURLPath { get; set; }
        public string Type { get; set; }
        public IFormFile ATTACHMENT { get; set; }
        public int? DistrictID { get; set; }
        public int? MINING_INSPECTER_ID { get; set; }
        public string COC { get; set; }
        public int? IntUserId { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
        public string UserType { get; set; }
        public int? IsBackendApprove { get; set; }
        public string DistrictName { get; set; }
        public string DD_DMO_REMARKS { get; set; }

        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string MobileNo { get; set; }

        public string MOBILE_NUMBER { get; set; }
        public string DGM_REMARKS { get; set; }
        public string MINING_INSPECTER_REMARKS { get; set; }
        public string MIResultFile { get; set; }
        public string ComplaintType { get; set; }
        public string EmailId { get; set; }
        public string OTP { get; set; }
        

        public string TEXT { get; set; }
        public string VALUE { get; set; }

        public long? GRIEVANCE_COMPLAINT_ID { get; set; }

        public int? GRIEVANCE_COMPLAINT_TYPE_ID { get; set; }


        public String SUBJECT_OF_COMPLAINT { get; set; }


        public String COMPLAINT_IN_BRIEF { get; set; }


        public String OtherSubject { get; set; }


        public String USER_CODE_OF_COMPLAINER { get; set; }
   


        public String NAME_OF_COMPLAINER { get; set; }

       


        public String COMPLETE_ADDRESS { get; set; }


        public int? DISTRICT { get; set; }


        public String DISTRICT_NAME { get; set; }


        public int? STATE { get; set; }


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
        public int? ACTIVE_STATUS { get; set; }

        public string Date { get; set; }
        public string Complaint_Status { get; set; }
        public string ComplaintNumber { get; set; }
        public string base64GrivanceRegistration { get; set; }
    }
    public class FillDDl
    {
        public List<PublicGrievanceModel> DDL{ get; set; }
    }
}
