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
using System.Collections.Generic;
using System.Text;

namespace MasterEF
{
    public class ApplicationSettingmaster
    {
        public int? EXPIRY_DATE_ALERT_COUNT { get; set; }
        public decimal? TP_OFFLINE_NET_WEIGHT { get; set; }
        public decimal? FORWARDINGNOTE_GRACE_WEIGHT { get; set; }
        public decimal? TIMELINE_OF_REPLY_OF_NOTICE { get; set; }
        public decimal? EXPIRY_DATE_INTIMATION { get; set; }
        public bool SMS_SENT { get; set; }
        public string strSMS_SENT { get; set; }
        public bool EMAIL_SENT { get; set; }
        public string strEMAIL_SENT { get; set; }
        public int? UserId { get; set; }
    }
}
