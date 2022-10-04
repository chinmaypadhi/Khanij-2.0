using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.Mvc;
using Microsoft.AspNetCore.Http;

namespace IntegrationEF
{
   public class MCPaymentUserDetails
    {
        public string SessionBank { get; set; }
        public string DocContent { get; set; }
        public string PaymentVehicleID { get; set; }
        public int? UserId { get; set; }
        public string PaymentStatus { get; set; }
        public int? UserLoginId { get; set; }
        public string TXN_STATUS { get; set; }
        public string CLNT_TXN_REF { get; set; }
        public string PaymentRecieptId { get; set; }
        public string ChallanNumber { get; set; }
        public int? SubUserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ApplicantName { get; set; }
        public string UserType { get; set; }
        public int? UserTypeId { get; set; }
        public int? RoleId { get; set; }
        public string Check { get; set; }
        public string USR_NAME { get; set; }
        public string USR_PW { get; set; }
        public string RemoteIp { get; set; }
        public string LocalIp { get; set; }
        public string UserAgent { get; set; }
        

    }
}
