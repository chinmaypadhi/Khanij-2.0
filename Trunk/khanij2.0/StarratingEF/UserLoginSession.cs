// ***********************************************************************
//  Class Name               : UserLoginSession
//  Desciption               : Starrating Assessment
//  Created By               : Lingaraj Dalai
//  Created On               : 14 April 2021
// ***********************************************************************
using System.Collections.Generic;

namespace StarratingEF
{
    public class UserLoginSession
    {
        public int? UserId { get; set; }
        public int? SubUserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ApplicantName { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string EMailId { get; set; }
        public string UserType { get; set; }
        public int? UserTypeId { get; set; }
        public int? RoleId { get; set; }
        public int? UserLoginId { get; set; }
        public int? IsPasswordChange { get; set; }
        public int? MineralId { get; set; }
        public string MineralName { get; set; }
        public string UserRoleInfo { get; set; }
        public string MobileNumber { get; set; }
        public bool IsSubUser { get; set; }
        public int TPOffline { get; set; }
        public string DistrictName { get; set; }
        public bool IsOnlyTP { get; set; }
        public int? LeaseStatusId { get; set; }
        public string LesseeStatus { get; set; }
        public string MineralTypeName { get; set; }
        public string IsSidePanelHide { get; set; }
        public string NoticeFilePath { get; set; }
        public int? IsLowGradeLimestone { get; set; }
        public string SMS_SENT { get; set; }
        public string EMAIL_SENT { get; set; }
        public int StateId { get; set; }
        public int DistrictId { get; set; }
        public int TehsilId { get; set; }
        public int VillageId { get; set; }         
        public List<MenuEF> Listmenu { get; set; }
    }
}
