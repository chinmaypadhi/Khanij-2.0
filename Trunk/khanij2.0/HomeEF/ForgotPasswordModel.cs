// ***********************************************************************
//  Class Name               : ForgotPasswordModel
//  Desciption               : To Mangae Forgot Password Model  
//  Created By               : Prakash Chandra Biswal
//  Created On               : 23 DEC 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeEF
{
    public class ForgotPasswordModel
    {
        public int UserId { get; set; }
        public int SubUserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ApplicantName { get; set; }
        public string UserType { get; set; }
        public int UserTypeId { get; set; }
        public int RoleId { get; set; }
        public int UserLoginId { get; set; }
        public int IsPasswordChange { get; set; }
        public int MineralId { get; set; }
        public string MineralName { get; set; }
        public string UserRoleInfo { get; set; }
        public string MOBILENO { get; set; }
        public bool IsSubUser { get; set; }
        public int TPOffline { get; set; }
        public string DistrictName { get; set; }
        public bool IsOnlyTP { get; set; }
        public int? LeaseStatusId { get; set; }
        public string LesseeStatus { get; set; }
        public string MineralTypeName { get; set; }
        public string IsSidePanelHide { get; set; }
        public string NoticeFilePath { get; set; }
        public int IsLowGradeLimestone { get; set; }
        public string SMS_SENT { get; set; }
        public string EMAIL_SENT { get; set; }
        public string EMAILID { get; set; }
        public string maskmobile { get; set; }
        public string maskEmailId { get; set; }
        public string Captcha { get; set; }
        public string OTP { get; set; }
        public string EncryptPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
