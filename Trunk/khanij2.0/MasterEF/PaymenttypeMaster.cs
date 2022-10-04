// ***********************************************************************
// Assembly         : Khanij
// Author           : Debaraj Swain
// Created          : 07-Jan-2021
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

namespace MasterEF
{
  public  class PaymenttypeMaster
    {
        public int? PaymentTypeId { get; set; }
       
    
        public string PaymentType { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public bool? RoyaltyMaping { get; set; }
        public bool? IsOnline { get; set; }
        public string Mapping { get; set; }
        public string OnlinePayment { get; set; }
        public string Status { get; set; }
    }
}
