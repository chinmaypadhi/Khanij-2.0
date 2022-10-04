using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDeskEF
{
   public  class IssueLogsummaryModel
    {
        public int SrNo { get; set; }
        public int LesseThan1 { get; set; }
        public int LesseThan2 { get; set; }
        public int LesseThan3 { get; set; }
        public int LesseThan4 { get; set; }
        public int LesseThan5 { get; set; }
        public int GreaterThan5 { get; set; }
        public int Total { get; set; }
        public string CategoryName { get; set; }
        public string ModuleName { get; set; }
        public string ItemName { get; set; }
        public int ItemId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string IssueStatus { get; set; }
        public int? Userid { get; set; }
    }
}
