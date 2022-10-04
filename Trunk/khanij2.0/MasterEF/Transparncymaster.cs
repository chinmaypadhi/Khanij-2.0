// ***********************************************************************
// Assembly         : Khanij
// Author           : Lingaraj Dalai
// Created          : 25-Jan-2021
//
// ***********************************************************************
using System;

namespace MasterEF
{
    public class Transparncymaster
    {
        public int? DNId { get; set; }
        public string NoticeText { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsPublished { get; set; }
        public string ActiveStatus { get; set; }
        public string IsPublish { get; set; }
        public int? CREATED_BY { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string NoticeFilePath { get; set; }
        public string NoticeFileName { get; set; }
        public string ImageUrlPath { get; set; }
        public bool isDelete { get; set; }
    }
}
