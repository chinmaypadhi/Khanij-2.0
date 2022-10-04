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

namespace HomeEF
{
    public class UserLoginSession
    {
        int? userId;
        int? subUserId;
        int? userTypeId;
        int? roleId;
        int? userLoginId;
        int? isPasswordChange;
        int? mineralId;
        int? tPOffline;
        int? leaseStatusId;
        int? isLowGradeLimestone;
        List<MenuEF> listmenu;
        List<string> list;
        string userName;
        string password;
        string applicantName;
        string userType;
        string mineralName;
        string userRoleInfo;
        string mobileNumber;
        string emailID;
        string districtName;
        string lesseeStatus;
        string mineralTypeName;
        string isSidePanelHide;
        string noticeFilePath;
        string sMS_SENT;
        string encryptPassword;
        public int? UserId
        {
            get
            {
                return userId == null ? 0 : userId;
            }
            set
            {
                userId = value == null ? 0 : value;
            }
        }
        public int? SubUserID
        {
            get
            {
                return subUserId == null ? 0 : subUserId;
            }
            set
            {
                subUserId = value == null ? 0 : value;
            }
        }
        public int? UserTypeId
        {
            get
            {
                return userTypeId == null ? 0 : userTypeId;
            }
            set
            {
                userTypeId = value == null ? 0 : value;
            }
        }
        public int? RoleId
        {
            get
            {
                return roleId == null ? 0 : roleId;
            }
            set
            {
                roleId = value == null ? 0 : value;
            }
        }
        public int? UserLoginId
        {
            get
            {
                return userLoginId == null ? 0 : userLoginId;
            }
            set
            {
                userLoginId = value == null ? 0 : value;
            }
        }
        public int? IsPasswordChange
        {
            get
            {
                return isPasswordChange == null ? 0 : isPasswordChange;
            }
            set
            {
                isPasswordChange = value == null ? 0 : value;
            }
        }
        public int? MineralId
        {
            get
            {
                return mineralId == null ? 0 : mineralId;
            }
            set
            {
                mineralId = value == null ? 0 : value;
            }
        }
        public int? TPOffline
        {
            get
            {
                return tPOffline == null ? 0 : tPOffline;
            }
            set
            {
                tPOffline = value == null ? 0 : value;
            }
        }
        public int? LeaseStatusId
        {
            get
            {
                return leaseStatusId == null ? 0 : leaseStatusId;
            }
            set
            {
                leaseStatusId = value == null ? 0 : value;
            }
        }
        public int? IsLowGradeLimestone
        {
            get
            {
                return isLowGradeLimestone == null ? 0 : isLowGradeLimestone;
            }
            set
            {
                isLowGradeLimestone = value == null ? 0 : value;
            }
        }
        public string UserName
        {
            get
            {
                return userName == null ? "" : userName;
            }
            set
            {
                userName = value == null ? "" : value;
            }
        }
        public string Password
        {
            get
            {
                return password == null ? "" : password;
            }
            set
            {
                password = value == null ? "" : value;
            }
        }
        public string ApplicantName
        {
            get
            {
                return applicantName == null ? "" : applicantName;
            }
            set
            {
                applicantName = value == null ? "" : value;
            }
        }
        public string UserType
        {
            get
            {
                return userType == null ? "" : userType;
            }
            set
            {
                userType = value == null ? "" : value;
            }
        }
        public string MineralName
        {
            get
            {
                return mineralName == null ? "" : mineralName;
            }
            set
            {
                mineralName = value == null ? "" : value;
            }
        }
        public string UserRoleInfo
        {
            get
            {
                return userRoleInfo == null ? "" : userRoleInfo;
            }
            set
            {
                userRoleInfo = value == null ? "" : value;
            }
        }
        public string MobileNumber
        {
            get
            {
                return mobileNumber == null ? "" : mobileNumber;
            }
            set
            {
                mobileNumber = value == null ? "" : value;
            }
        }
        public string EmailID
        {
            get
            {
                return emailID == null ? "" : emailID;
            }
            set
            {
                emailID = value == null ? "" : value;
            }
        }       
        public string DistrictName 
        {
            get
            {
                return districtName == null ? "" : districtName;
            }
            set
            {
                districtName = value == null ? "" : value;
            }
        }
        public string LesseeStatus 
        {
            get
            {
                return lesseeStatus == null ? "" : lesseeStatus;
            }
            set
            {
                lesseeStatus = value == null ? "" : value;
            }
        }
        public string MineralTypeName 
        {
            get
            {
                return mineralTypeName == null ? "" : mineralTypeName;
            }
            set
            {
                mineralTypeName = value == null ? "" : value;
            }
        }
        public string IsSidePanelHide 
        {
            get
            {
                return isSidePanelHide == null ? "" : isSidePanelHide;
            }
            set
            {
                isSidePanelHide = value == null ? "" : value;
            }
        }
        public string NoticeFilePath 
        {
            get
            {
                return noticeFilePath == null ? "" : noticeFilePath;
            }
            set
            {
                noticeFilePath = value == null ? "" : value;
            }
        }
        public string SMS_SENT 
        {
            get
            {
                return sMS_SENT == null ? "" : sMS_SENT;
            }
            set
            {
                sMS_SENT = value == null ? "" : value;
            }
        }
        public string EncryptPassword
        {
            get
            {
                return encryptPassword == null ? "" : encryptPassword;
            }
            set
            {
                encryptPassword = value == null ? "" : value;
            }
        }
        public List<MenuEF> Listmenu 
        {
            get;set;
        }
        public bool IsSubUser { get; set; }
        public bool IsOnlyTP { get; set; }
    }
}
