// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 21-Jan-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Data;
using Microsoft.AspNetCore.Http;
namespace MasterEF
{
    public class Policymaster
    {
        public int? PolicyID { get; set; }
        public int? RuleID { get; set; }
        public string RuleName { get; set; }
        public string PolicyName { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmentPath { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string ActiveStatus { get; set; }
        public string FileCount { get; set; }
        public DateTime? DateOfPublished { get; set; }
        public IFormFile Photo { get; set; }
    }
}

