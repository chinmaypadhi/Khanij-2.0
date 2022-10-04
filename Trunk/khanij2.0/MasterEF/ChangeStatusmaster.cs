// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 29-Jan-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterEF
{
    public class ChangeStatusmaster
    {
        public int? Status_History_Id { get; set; }
        public int? StatusId { get; set; }
        public int? DistrictID { get; set; }
        public int? RegionalID { get; set; }
        public int? ID { get; set; }
        public string UserType { get; set; }
        public string UserName { get; set; }
        public string Staus { get; set; }
        public int? UserId { get; set; }
        public string OldStatus { get; set; }
        public string newSatus { get; set; }
        public int? NewStatusId { get; set; }

        public string ChangeBy { get; set; }
        public string CreatedOn { get; set; }

        public string RegionalName { get; set; }
        public string DistrictName { get; set; }
        public string Remarks { get; set; }
        //public HttpPostedFileBase Document { get; set; }
        public string Document_Path { get; set; }
        public string Document_Name { get; set; }
        public string SRNO { get; set; }
        public int? UserLoginId { get; set; }
        public string ApplicantName { get; set; }
        public string Type { get; set; }
        public int? DistirctId { get; set; }
        public string RoleType { get; set; }
        public int? UserTypeId { get; set; }
        public string Status { get; set; }
        public IFormFile Document { get; set; }
    }
}
