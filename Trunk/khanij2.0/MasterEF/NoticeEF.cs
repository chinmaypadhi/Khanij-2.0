using System;
using System.Collections.Generic;
using System.Text;

namespace MasterEF
{
  public  class NoticeEF
    {
        public NoticeEF()
        {
            SelectedCondition = new List<string>();
            //ConditionList = new List<SelectListItem>();
            UsersIDs = new List<int?>();
        }
        public int? RoleTypeId { get; set; }
        public int? NoticeID { get; set; }
        public int? NoticeDetailsID { get; set; }
        public int[] SelectedPriceIds { get; set; }
        public List<int?> UsersIDs { get; set; }
        public int? UserID { get; set; }
        public string NoticeSubject { get; set; }
        public string NoticeDescription { get; set; }
        public string AttatchmentName { get; set; }
        public string AttatchmentPath { get; set; }
        public string FileCount { get; set; }

        //public IEnumerable<HttpPostedFileBase> Attatchment { get; set; }
        public bool IsDraft { get; set; }

        public string SrNo { get; set; }
        public string CreatedDate { get; set; }
        public string UsersList { get; set; }
        public int? IsView { get; set; }
      //  public IEnumerable<Files> FileList { get; set; }
        public IEnumerable<string> SelectedCondition { get; set; }
        //public IEnumerable<SelectListItem> ConditionList { get; set; }

        public string IssuanceOfNoticeText { get; set; }
        public string IssuanceOfNoticeId { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public int? IsReplay { get; set; }
        public string ApplicantName { get; set; }
        public int? UsersCount { get; set; }
        public string SuspensionCopy { get; set; }
        public string SuspensionDate { get; set; }
        public string Status { get; set; }
        public string User_ID { get; set; }
        public string ExpiryDays { get; set; }
        public int? RepliedUser { get; set; }
        public int? IsHide { get; set; }

        public string Type { get; set; }

        public string PenaltyDate { get; set; }
        public string PenaltyAmount { get; set; }

        public string FileCopy { get; set; }
        public string FilePath { get; set; }

        public string UserFilePath { get; set; }
        public string PenaltyFilePath { get; set; }

        public string PenaltyPaymentStatus { get; set; }
        public string TimeLineOfReply { get; set; }
        
    }
}
