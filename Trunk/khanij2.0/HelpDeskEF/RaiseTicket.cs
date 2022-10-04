using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using Microsoft.AspNetCore.Http;
namespace HelpDeskEF
{
    public class RaiseTicket
    {
        public string IssueStatus { get; set; }
        public string OtherThanHelpdesk_ModuleName { get; set; }
        #region for NonUser
        public string NonUser_StateName1 { get; set; }
        public string NonUser_DistrictName1 { get; set; }
        public string NonUser_ComplainerName1 { get; set; }
        public string NonUser_ComplainerMobileNumber1 { get; set; }
        public string NonUser_ComplainerEmailID1 { get; set; }
        public string NonUser_ComplainerUserName1 { get; set; }
        #endregion

        #region other than Non user
        
        public int? OtherThenNonUser_StateName2id { get; set; }
        public string OtherThenNonUser_StateName2 { get; set; }
        public int? OtherThenNonUser_DistrictName2id { get; set; }
        public string OtherThenNonUser_DistrictName2 { get; set; }
        public string OtherThenNonUser_ComplainerName2 { get; set; }
        public string OtherThenNonUser_ComplainerMobileNumber2 { get; set; }
        public string OtherThenNonUser_ComplainerEmailID2 { get; set; }
        public string OtherThenNonUser_ComplainerUserName2 { get; set; }
        #endregion
        public DataTable Document { get; set; }
        public string FetchUserCode { get; set; }
        public List<IFormFile> Photo { get; set; }
        public double? TicketID { get; set; }
        public string TicketNumber { get; set; }
        public int? OnBehalfOfId { get; set; }
        public string SrNo { get; set; }
        public string Remark { get; set; }
        public string Action { get; set; }
        public string OnBehalfOfName { get; set; }
        public string ApplicantName { get; set; }
        public int? StateID { get; set; }
        public int? Userid { get; set; }
        public string StateName { get; set; }

        
        public int? DistrictID { get; set; }
        public string Ticketstatus { get; set; }
        public string DistrictName { get; set; }
        public string UserName { get; set; }

        public string ComplainerName { get; set; }

        public string ComplainerMobileNumber { get; set; }

        public string ComplainerEmailID { get; set; }

        public string ComplainerUserName { get; set; }

        public int? OtherThanHelpdesk_ModuleID { get; set; }
        public int? ModuleID { get; set; }

        public string ModuleName { get; set; }

        public int? CategoryID { get; set; }

        public string CategoryName { get; set; }

        public int? ItemID { get; set; }

        public string ItemName { get; set; }

        public int? CriticalityID { get; set; }

        public string CriticalityName { get; set; }
        public string Createdon { get; set; }
        public string Remarks { get; set; }
        public int? PriorityID { get; set; }

        public string PriorityName { get; set; }


        public string ProblemDescription { get; set; }
        public string document_path { get; set; }
        public string document_name { get; set; }


        public string status { get; set; }
       public string SolutionDescription { get; set; }
        
        public string TicketOpenDate { get; set; }
       

        public string designation { get; set; }

        public string IssueReportedBy { get; set; }
        public string Logged { get; set; }
        public string Resolved_Issues_On_Same_Day { get; set; }
        public string PreviousPendingIssue { get; set; }
        public string PreviousPendingIssueSolved { get; set; }
        public string TotalIssueReSolved { get; set; }
        public string TotalIssuePending { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public string delaytime { get; set; }


        public string TicketRaisedDateTime { get; set; }

        public string Status_Details { get; set; }
        public string CloseDateTime { get; set; }
        public string DaysTimeTaken { get; set; }
        
        public string DiffMinute { get; set; }
        public string DiffMinuteForOSUFMS { get; set; }
       
       
        public int? IsBackendApprove { get; set; }
        public string Description { get; set; }
        public List<Filedetail> attachments{get;set;}
        public string UserType { get; set; }
        public int? intUsertypeid { get; set; }
        public string Fmsuser { get; set; }
       
       public string Osuuser { get; set; }

        public int? Fmuserid { get; set; }
        public int? Osuuserid { get; set; }
        public string Closeremark { get; set; }
        public string ForwardDistrictName { get; set; }
        public string ForwardDistrictId { get; set; }

        public string ForwardRemark { get; set; }
        public string UpdateRemark { get; set; }
        public string ReopenRemark { get; set; }

        public string PullRemark { get; set; }

    }
    public class Filedetail
    {

        public string FileName { get; set; }
        public string FilePath { get; set; }

        public int? SrNo { get; set; }
    }

    public class Applicantdetail
    {

        public int? SrNo { get; set; }
        public string ApplicantName { get; set; }

        public string Remarks { get; set; }

        public string Createdon { get; set; }
    }

    public class BackendModel
    {
        public List<Filedetail> attachments { get; set; }
        public string Action { get; set; }
        public int? TicketID { get; set; }
       public int? userid { get; set; }
        public int? SeverityId { get; set; }
        public string Severity { get;set; }
        public int? id { get; set; }
        public string ProblemType { get; set; }
        public int? UserTypeId { get; set; }
        public string UserType { get; set; }
        public string ForwardedTo { get; set; }
       
        public int? ForwardedId { get; set; }
        public string ForwardedName { get; set; }

        
        public string ProblemDescription { get; set; }
        public string Document_Path { get; set; }
        public string Document_Name { get; set; }
        public DataTable Document { get; set; }

        public List<IFormFile> Photo { get; set; }
        public DataTable TicketHistory { get; set; }

        public string DistrictId { get; set; }
        public string Districtname { get; set; }
        public string ApplicantName { get; set; }
        public string TicketNo { get; set; }

        public string qry { get; set; }
        public int? Qrytype { get; set; }
    }



    public class TotalIssueLogModel
    {
        public List<ChildModel> ISSUE_STATUS_SUMMARY { get; set; }
        public List<ChildModel> SOFTWARE_ISSUES { get; set; }
        public List<ChildModel> HARDWARE_ISSUES { get; set; }
        public List<ChildModel> NETWORK_CALLS { get; set; }
        public List<ChildModel> OTHERS { get; set; }
        public List<ChildModel> HDSSummary { get; set; }
        public List<ChildModel> StatusSummary { get; set; }
        public string SoftwareIssueLoggedEncryptUrl { get; set; }
        public string SoftwareIssuesTotalCallResolvedEncryptUrl { get; set; }
        public string SoftwareCurrentOpenIssueEncryptUrl { get; set; }
        public string HardwareIssuesEncryptUrl { get; set; }
        public string HardwareTotalIssuesResolvedEncryptUrl { get; set; }
        public string HardwareCurrentOpenIssueEncryptUrl { get; set; }
        public string NetworkInternetConnectivityAtUserSideEncryptUrl { get; set; }
        public string NetworkServerDownEncryptUrl { get; set; }
        public string OtherIssuesEncryptUrl { get; set; }
        public string StatusSummaryInitiatedEncryptUrl { get; set; }
        public string StatusSummaryFMSEncryptUrl { get; set; }
        public string StatusSummaryOSUEncryptUrl { get; set; }
        public string StatusSummaryClosedEncryptUrl { get; set; }
        public string StatusSummaryReopenEncryptUrl { get; set; }
        public string StatusSummaryTotalEncryptUrl { get; set; }
        public string TotalIssueReSolvedEncryptUrl { get; set; }
        public string TotalIssuePendingEncryptUrl { get; set; }
        public string LoggedEncryptUrl { get; set; }
        public string Resolved_Issues_On_Same_DayEncryptUrl { get; set; }
        public string PreviousPendingIssueSolvedEncryptUrl { get; set; }
        public string TodaysPendingIssueEncryptUrl { get; set; }
        public string PreviousPendingIssueEncryptUrl { get; set; }
        public TotalIssueLogModel()
        {
            ISSUE_STATUS_SUMMARY = new List<ChildModel>();
            SOFTWARE_ISSUES = new List<ChildModel>();
            HARDWARE_ISSUES = new List<ChildModel>();
            NETWORK_CALLS = new List<ChildModel>();
            OTHERS = new List<ChildModel>();
            HDSSummary = new List<ChildModel>();
            StatusSummary = new List<ChildModel>();
        }

    }
    public class ChildModel
    {
        public string Header { get; set; }
        public string Total { get; set; }
    }

}
