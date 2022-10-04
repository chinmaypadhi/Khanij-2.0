// ***********************************************************************
//  Class Name               : UserCreationModel
//  Description              : Add,View,Edit,Update,Delete User Master details
//  Created By               : Prakash Chandra Biswal
//  Created On               : 27 Dec 2021
// ***********************************************************************
using System;
namespace MasterEF
{
    public class UserCreationModel
    {
        public int? UserId { get; set; }
        public int? Userid1 { get; set; }
        public int? LesseeApplicationTypeId { get; set; }
        public int? LicenseeApplicationTypeId { get; set; }
        public string UserName { get; set; }
        public string ApplicantName { get; set; }
        public string Password { get; set; }
        public string EncryptPassword { get; set; }
        //public int? UserTypeId { get; set; }
        //public string UserTypeName { get; set; }
        public int? UsertypeId { get; set; }   // This is For Dropdwon UserType Binding 
        public string Usertype { get; set; }   // This is For Dropdwon UserType Binding 
        public string Address { get; set; }
        public int? RoleTypeId { get; set; }
        public string RoleTypeName { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
        public int? DistrictID { get; set; }
        public string DistrictName { get; set; }
        public int? StateId { get; set; }
        public string StateName { get; set; }
        public int? PinCode { get; set; }
        public string MobileNo { get; set; }
        public string EMailId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string Status { get; set; }
        public int? UserLoginId { get; set; }
        public string ActiveStatus { get; set; }

    }
    public class ViewUserCreationModel
    {
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string MobileNo { get; set; }
        public string EMailId { get; set; }
        //public int? UserTypeId { get; set; }
        public string UserType { get; set; }
       // public int? RoleTypeId { get; set; }
        public string RoleTypeName { get; set; }
        //public int? RoleId { get; set; }
        public string RoleName { get; set; }
       // public int? DistrictID { get; set; }
        public string DistrictName { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
       // public int? StateId { get; set; }
        public string StateName { get; set; }
        public string PinCode { get; set; }
        public bool IsActive { get; set; }
        public string ApplicantName { get; set; }

    }
}
