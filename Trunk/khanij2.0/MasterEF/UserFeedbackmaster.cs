// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 22-Jan-2021
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
    public class UserFeedbackmaster
    {
        public int? FeedbackId { get; set; }      
        public string FromDate { get; set; }
        public string  ToDate { get; set; }
        public string  Name { get; set; }
        public string  Email { get; set; }
        public string  MobileNo { get; set; }
        public string UserTypeName { get; set; }
        public string Organization { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public int? IsApproved { get; set; }
        public string ApproveStatus { get; set; }
    }
}
