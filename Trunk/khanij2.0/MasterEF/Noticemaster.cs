// ***********************************************************************
// Assembly         : Khanij
// Author           : Debaraj Swain
// Created          : 08-Jan-2021
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
  public  class Noticemaster
    {
        public int NoticeID { get; set; }
  
        public string NoticeText { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string ActiveStatus { get; set; }
    }
}
