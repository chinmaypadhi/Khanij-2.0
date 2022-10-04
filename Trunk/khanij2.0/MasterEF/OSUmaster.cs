// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 28-Jan-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace MasterEF
{
    public class OSUmaster
    {
        public string ApplicantName { get; set; }
        public int? UserTypeId { get; set; }
        public string UserType { get; set; }
        public int? DistrictID { get; set; }
        public string DistrictName { get; set; }

        public string EmailID { get; set; }
        public string MobileNumber { get; set; }

        public string Address { get; set; }
        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }

        public int? LesseeMinesStatusID { get; set; }
        public string LesseeMinesStatus { get; set; }

        public int? LicenseeMinesStatusID { get; set; }
        public string LicenseeMinesStatus { get; set; }

        public int? LesseeTypeID { get; set; }
        public string LesseeTypeName { get; set; }

        public int? LicenseeTypeID { get; set; }
        public string LicenseeTypeName { get; set; }
        public int? UserId { get; set; }
        public int? UserLoginId { get; set; }
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

    }
}
