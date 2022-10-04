// ***********************************************************************
// Assembly         : Khanij
// Author           : Kumar jeevan jyoti
// Created          : 28-dec-2020
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using MineralConcessionEF;

namespace MineralConcessionEF
{
    public class UserLoginSession
    {
        public List<MenuEF> Listmenu { get; set; }
        public int? UserId { get; set; }
        public int? SubUserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ApplicantName { get; set; }
        public string UserType { get; set; }
        public int? UserTypeId { get; set; }
        public int? RoleId { get; set; }
        public int? UserLoginId { get; set; }
        public int? IsPasswordChange { get; set; }
        public int? MineralId { get; set; }
        public string MineralName { get; set; }
        public string UserRoleInfo { get; set; }
        public string MobileNumber { get; set; }
        public string EmailID { get; set; }
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
        
    }
}
