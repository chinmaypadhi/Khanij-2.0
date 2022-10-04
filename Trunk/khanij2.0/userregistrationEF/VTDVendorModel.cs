using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userregistrationEF
{
    public class VTDVendorModel
    {
        public int? VTDVendorId { get; set; }
        public string CompanyName { get; set; }
        public string GST { get; set; }
        public string Company_Corp_Address { get; set; }
        public int? Company_Corp_State { get; set; }
        public string Company_Corp_State_Name { get; set; }
        public int? Company_Corp_District { get; set; }
        public string Company_Corp_District_Name { get; set; }
        public string Company_Corp_Block { get; set; }
        public int? Company_Corp_PinCode { get; set; }
        public string Company_Local_Address { get; set; }
        public int? Company_Local_State { get; set; }
        public string StateName { get; set; }
        public int? Company_Local_District { get; set; }
        public string DistrictName { get; set; }
        public int? Company_Local_Block { get; set; }
        public string BlockName { get; set; }
        public int? Company_Local_PinCode { get; set; }
        public string Contact_Person_Name { get; set; }
        public string Contact_Person_MobileNo { get; set; }
        public string Contact_Person_EmailId { get; set; }
        public string Contact_Person_Designation { get; set; }
        public string Transport_Dept_ApprovalLetter { get; set; }
        public string Transport_Dept_ApprovalLetter_Path { get; set; }
        public IFormFile ApprovalLetter { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? ActiveStatus { get; set; }
        public string Remarks { get; set; } 
        public string RegistrationNo { get; set; }
        public int? UserId { get; set; }
        public string DSCResponse { get; set; }
        public string Status { get; set; }
        public int? ProfileUserID { get; set; }
        public string Secondary_Contact_Person_Name { get; set; }
        public string Secondary_Contact_Person_MobileNo { get; set; }
        public string Secondary_Contact_Person_EmailId { get; set; }
        public string Secondary_Designation { get; set; }
        public int? CompanyId { get; set; }
        public List<VTDUserModelPortDetails> VTDUserModelPortDetails { get; set; }
    }

    public class VTDUserModelPortDetails
    {
        public string ModelName { get; set; }
        public string PortNo { get; set; }
    }
}
