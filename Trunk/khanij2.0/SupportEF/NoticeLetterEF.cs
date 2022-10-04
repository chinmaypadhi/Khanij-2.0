using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Linq;
using System.Data;

namespace SupportEF
{
  public  class NoticeLetterEF
    {


       public NoticeLetterEF()
        {
            this.RoleTypeId = 0;
            this.RoleTypeName = "";
            this.NoticeID = 0;
            this.NoticeDetailsID = 0;
            this.UserID = 0;
            this.NoticeSubject = "";
            this.NoticeDescription = "";
            this.AttatchmentName = "";
            this.AttatchmentPath = "";
            this.FileCount = "";
            this.SrNo = "";
            this.CreatedDate = "";
            this.UsersList = "";
            this.IsView = 0;

            this.IssuanceOfNoticeText = "";
            this.IssuanceOfNoticeId = "";
            this.EmailId = "";
            this.MobileNo = "";
            this.IsReplay = 0;
            this.ApplicantName = "";
            this.UsersCount = 0;
            this.SuspensionCopy = "";
            this.SuspensionDate = "";
            this.StatusType = "";
            this. Status_Type="";
            this.User_ID = "";
            this.ExpiryDays = "";
            this.ExpiryDays = "";
            this.RepliedUser = 0;
            this.IsHide =0;
            this.Type = "";
            this.UserType = 0;
            this.PenaltyDate = "";
            this.PenaltyAmount = "";

            this.FileCopy = "";
            this.FileName = "";
            this.FilePath = "";
            this.UserFilePath = "";
            this.PenaltyFilePath = "";

            this.PenaltyPaymentStatus = "";
            this.TimeLineOfReply = "";
            this.CreatedBy = 0;
            this.UserLoginId = 0;
            this.TIMELINE_OF_REPLY_OF_NOTICE = 0;
            this.Replay_NoticeDescription = "";
            this.EMailId = "";

    }


        public int? RoleTypeId { get; set; }
        public string RoleTypeName { get; set; }
        public int? NoticeID { get; set; }
        public int? NoticeDetailsID { get; set; }
        public int?[] SelectedPriceIds { get; set; }
        public List<int?> UsersIDs { get; set; }
        public int? UserID { get; set; }
        public string NoticeSubject { get; set; }
        public string NoticeDescription { get; set; }
        public string AttatchmentName { get; set; }
        public string AttatchmentPath { get; set; }
        public string FileCount { get; set; }
        public DateTime CreatedOn { get; set; }
        //public IEnumerable<HttpPostedFileBase>   { get; set; }
        //public IList<IFormFile> Attatchment { get; set; }
        public bool IsDraft { get; set; }
       
        public string SrNo { get; set; }
        public string CreatedDate { get; set; }
        public string UsersList { get; set; }
        public int? IsView { get; set; }
       // public IEnumerable<Files> FileList { get; set; }
        public IEnumerable<string> SelectedCondition { get; set; }
       // public IEnumerable<SelectListItem> ConditionList { get; set; }

        public string IssuanceOfNoticeText { get; set; }
        public string IssuanceOfNoticeId { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public int? IsReplay { get; set; }
        public string ApplicantName { get; set; }
        public int? UsersCount { get; set; }
        public string SuspensionCopy { get; set; }
        public string SuspensionDate { get; set; }
        public string StatusType { get; set; }
        public string Status_Type { get; set; }
        public string User_ID { get; set; }
        public string ExpiryDays { get; set; }
        //public int ExpiryDays { get; set; }
        public int? RepliedUser { get; set; }
        public int? IsHide { get; set; }

        public string Type { get; set; }
        public int? UserType { get; set; }
        public string PenaltyDate { get; set; }
        public string PenaltyAmount { get; set; }

        public string FileCopy { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public string UserFilePath { get; set; }
        public string PenaltyFilePath { get; set; }

        public string PenaltyPaymentStatus { get; set; }
        public string TimeLineOfReply { get; set; }
        public int? CreatedBy { get; set; }
        public bool? IsActive { get; set; }
        public int? UserLoginId { get; set; }
        public DataTable MultipleFile { get; set; }
        public int? TIMELINE_OF_REPLY_OF_NOTICE { get; set; }
        public string Replay_NoticeDescription { get; set; }
        public string EMailId { get; set; }
        
        //public NoticeLetterEF()
        //{
        //    SelectedCondition = new List<string>();
        //    ConditionList = new List<SelectListItem>();
        //    UsersIDs = new List<int?>();
        //}

    }
    public class UserTypeResult
    {
        public List<NoticeLetterEF> UserTypeLst { get; set; }
    }
    public class ReplyNotice
    {
        public List<NoticeLetterEF> UserTypeLst { get; set; }
        public List<NoticeLetterEF> FileType { get; set; }
    }

}
