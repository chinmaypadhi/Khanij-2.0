using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Http;

namespace SupportEF
{
    public class InspectionModel
    {
        public InspectionModel()
        {
            this.inspectionDetails = new List<InspectoinReportDetailsDataViewModel>();
        }
        string jsonserialize;
        string fromDate;
        string toDate;
        string lesseLicenseeName;
        int? uSERID;
        int? intUid;
        int? sRNO;
        int? count;
        int? insid;
        string inssubject;
        string insdate;
        int? inspectorid;
        string inspectorcode;
        string inspectorname;
        string inspectordesignation;
        string district;
        string Pincode;
        string insmobileNo;
        string insemail;
        int? IdoflesseeLicensee;
        string NameoflesseeLicensee;
        int? LesseeLicenseeUsertypeId;
        string LesseeLicenseeuserTypeName;
        string LesseeLicenseevillage;
        string LesseeLicenseetehsil;
        string LesseeLicenseedistrict;
        string LesseeLicenseepanchayat;
        string LesseeLicenseepoliceStation;
        string LesseeLicenseepinCode;
        string LesseeLicenseemobile;
        string LesseeLicenseeemail;
        string Inspection_Report_fILE_PATH;
        string Inspection_Report_fILE_NAME;
        string Panchnama_FILE_nAME;
        string bayan_FILE_NAME;
        string Others_fILE_NAME;
        string Panchnama_fILE_PATH;
        string Bayan_fILE_pATH;
        string Photos_fILE_PATH;
        string Others_fILE_PATH;
        DateTime? Submiteddate;
        string Inspectiondate;
        string Lesseecode;
        string Lesseename;
        string status;
        string state;
        string text;
        string values;
        public string jsonSerialize
        {
            get
            {
                return jsonserialize == null ? "" : jsonserialize;
            }
            set
            {
                jsonserialize = value == null ? "" : value;
            }
        }
        public DataTable DT { get; set; }
        public IFormFile InspectionReport { get; set; }
        public IFormFile Panchaname { get; set; }
        public IFormFile Bayan { get; set; }
        public IFormFile Photos { get; set; }
        public IFormFile Others { get; set; }
        public string base64InspectionReport { get; set; }
        public string base64Panchaname { get; set; }
        public string base64Bayan { get; set; }
        public string base64Photos { get; set; }
        public string base64Others { get; set; }
        public string FromDate
        {
            get
            {
                return fromDate == null ? "" : fromDate;
            }
            set
            {
                fromDate = value == null ? "" : value;
            }
        }
        public string ToDate
        {
            get
            {
                return toDate == null ? "" : toDate;
            }
            set
            {
                toDate = value == null ? "" : value;
            }
        }
        public string LesseLicenseeName
        {
            get
            {
                return lesseLicenseeName == null ? "" : lesseLicenseeName;
            }
            set
            {
                lesseLicenseeName = value == null ? "" : value;
            }
        }
        public int? USERID
        {
            get
            {
                return uSERID == null ? 0 : uSERID;
            }
            set
            {
                uSERID = value == null ? 0 : value;
            }
        }
        public int? IntUid
        {
            get
            {
                return intUid == null ? 0 : intUid;
            }
            set
            {
                intUid = value == null ? 0 : value;
            }
        }
        public int? SRNO
        {
            get
            {
                return sRNO == null ? 0 : sRNO;
            }
            set
            {
                sRNO = value == null ? 0 : value;
            }
        }
        public int? Count
        {
            get
            {
                return count == null ? 0 : count;
            }
            set
            {
                count = value == null ? 0 : value;
            }
        }
        public int? insId
        {
            get
            {
                return insid == null ? 0 : insid;
            }
            set
            {
                insid = value == null ? 0 : value;
            }
        }
        public string insSubject
        {
            get
            {
                return inssubject == null ? "" : inssubject;
            }
            set
            {
                inssubject = value == null ? "" : value;
            }
        }
        public string insDate
        {
            get
            {
                return insdate == null ? "" : insdate;
            }
            set
            {
                insdate = value == null ? "" : value;
            }
        }
        public int? inspectorId
        {
            get
            {
                return inspectorid == null ? 0 : inspectorid;
            }
            set
            {
                inspectorid = value == null ? 0 : value;
            }
        }
        public string inspectorCode
        {
            get
            {
                return inspectorcode == null ? "" : inspectorcode;
            }
            set
            {
                inspectorcode = value == null ? "" : value;
            }
        }
        public string inspectorName
        {
            get
            {
                return inspectorname == null ? "" : inspectorname;
            }
            set
            {
                inspectorname = value == null ? "" : value;
            }
        }
        public string inspectorDesignation
        {
            get
            {
                return inspectordesignation == null ? "" : inspectordesignation;
            }
            set
            {
                inspectordesignation = value == null ? "" : value;
            }
        }
        public string District
        {
            get
            {
                return district == null ? "" : district;
            }
            set
            {
                district = value == null ? "" : value;
            }
        }
        public string PinCode
        {
            get
            {
                return Pincode == null ? "" : Pincode;
            }
            set
            {
                Pincode = value == null ? "" : value;
            }
        }


        
        public string insMobileNo
        {
            get
            {
                return insmobileNo == null ? "" : insmobileNo;
            }
            set
            {
                insmobileNo = value == null ? "" : value;
            }
        }
        public string insEmail
        {
            get
            {
                return insemail == null ? "" : insemail;
            }
            set
            {
                insemail = value == null ? "" : value;
            }
        }
        public int? IdofLesseeLicensee
        {
            get
            {
                return IdoflesseeLicensee == null ? 0 : IdoflesseeLicensee;
            }
            set
            {
                IdoflesseeLicensee = value == null ? 0 : value;
            }
        }
        public string NameofLesseeLicensee
        {
            get
            {
                return NameoflesseeLicensee == null ? "" : NameoflesseeLicensee;
            }
            set
            {
                NameoflesseeLicensee = value == null ? "" : value;
            }
        }
        public int? LesseeLicenseeUserTypeId
        {
            get
            {
                return LesseeLicenseeUsertypeId == null ? 0 : LesseeLicenseeUsertypeId;
            }
            set
            {
                LesseeLicenseeUsertypeId = value == null ? 0 : value;
            }
        }
        public string LesseeLicenseeUserTypeName
        {
            get
            {
                return LesseeLicenseeuserTypeName == null ? "" : LesseeLicenseeuserTypeName;
            }
            set
            {
                LesseeLicenseeuserTypeName = value == null ? "" : value;
            }
        }
        public string LesseeLicenseeVillage
        {
            get
            {
                return LesseeLicenseevillage == null ? "" : LesseeLicenseevillage;
            }
            set
            {
                LesseeLicenseevillage = value == null ? "" : value;
            }
        }
        public string LesseeLicenseeTehsil
        {
            get
            {
                return LesseeLicenseetehsil == null ? "" : LesseeLicenseetehsil;
            }
            set
            {
                LesseeLicenseetehsil = value == null ? "" : value;
            }
        }
        public string LesseeLicenseeDistrict
        {
            get
            {
                return LesseeLicenseedistrict == null ? "" : LesseeLicenseedistrict;
            }
            set
            {
                LesseeLicenseedistrict = value == null ? "" : value;
            }
        }
        public string LesseeLicenseePanchayat
        {
            get
            {
                return LesseeLicenseepanchayat == null ? "" : LesseeLicenseepanchayat;
            }
            set
            {
                LesseeLicenseepanchayat = value == null ? "" : value;
            }
        }
        public string LesseeLicenseePoliceStation
        {
            get
            {
                return LesseeLicenseepoliceStation == null ? "" : LesseeLicenseepoliceStation;
            }
            set
            {
                LesseeLicenseepoliceStation = value == null ? "" : value;
            }
        }
        public string LesseeLicenseePinCode
        {
            get
            {
                return LesseeLicenseepinCode == null ? "" : LesseeLicenseepinCode;
            }
            set
            {
                LesseeLicenseepinCode = value == null ? "" : value;
            }
        }
        public string LesseeLicenseeMobile
        {
            get
            {
                return LesseeLicenseemobile == null ? "" : LesseeLicenseemobile;
            }
            set
            {
                LesseeLicenseemobile = value == null ? "" : value;
            }
        }
        public string LesseeLicenseeEmail
        {
            get
            {
                return LesseeLicenseeemail == null ? "" : LesseeLicenseeemail;
            }
            set
            {
                LesseeLicenseeemail = value == null ? "" : value;
            }
        }
        //  public HttpPostedFileBase Inspection_Report { get; set; }
        public string Inspection_Report_FILE_PATH
        {
            get
            {
                return Inspection_Report_fILE_PATH == null ? "" : Inspection_Report_fILE_PATH;
            }
            set
            {
                Inspection_Report_fILE_PATH = value == null ? "" : value;
            }
        }
        public string Inspection_Report_FILE_NAME
        {
            get
            {
                return Inspection_Report_fILE_NAME == null ? "" : Inspection_Report_fILE_NAME;
            }
            set
            {
                Inspection_Report_fILE_NAME = value == null ? "" : value;
            }
        }
        public string Panchnama_FILE_NAME
        {
            get
            {
                return Panchnama_FILE_nAME == null ? "" : Panchnama_FILE_nAME;
            }
            set
            {
                Panchnama_FILE_nAME = value == null ? "" : value;
            }
        }
        public string Bayan_FILE_NAME
        {
            get
            {
                return bayan_FILE_NAME == null ? "" : bayan_FILE_NAME;
            }
            set
            {
                bayan_FILE_NAME = value == null ? "" : value;
            }
        }
        public string Photos_FILE_NAME
        {
            get
            {
                return bayan_FILE_NAME == null ? "" : bayan_FILE_NAME;
            }
            set
            {
                bayan_FILE_NAME = value == null ? "" : value;
            }
        }
        public string Others_FILE_NAME
        {
            get
            {
                return Others_fILE_NAME == null ? "" : Others_fILE_NAME;
            }
            set
            {
                Others_fILE_NAME = value == null ? "" : value;
            }
        }
        public string Panchnama_FILE_PATH
        {
            get
            {
                return Panchnama_fILE_PATH == null ? "" : Panchnama_fILE_PATH;
            }
            set
            {
                Panchnama_fILE_PATH = value == null ? "" : value;
            }
        }
        public string Bayan_FILE_PATH
        {
            get
            {
                return Bayan_fILE_pATH == null ? "" : Bayan_fILE_pATH;
            }
            set
            {
                Bayan_fILE_pATH = value == null ? "" : value;
            }
        }
        public string Photos_FILE_PATH
        {
            get
            {
                return Photos_fILE_PATH == null ? "" : Photos_fILE_PATH;
            }
            set
            {
                Photos_fILE_PATH = value == null ? "" : value;
            }
        }
        public string Others_FILE_PATH
        {
            get
            {
                return Others_fILE_PATH == null ? "" : Others_fILE_PATH;
            }
            set
            {
                Others_fILE_PATH = value == null ? "" : value;
            }
        }
        public DateTime? SubmitedDate
        {
            get
            {
                return Submiteddate == null ? null : Submiteddate;
            }
            set
            {
                Submiteddate = value == null ? null : value;
            }
        }
        public string InspectionDate
        {
            get
            {
                return Inspectiondate == null ? "" : Inspectiondate;
            }
            set
            {
                Inspectiondate = value == null ? "" : value;
            }
        }
        public string LesseeCode
        {
            get
            {
                return Lesseecode == "" ? null : Lesseecode;
            }
            set
            {
                Lesseecode = value == null ? null : value;
            }
        }
        public string LesseeName
        {
            get
            {
                return Lesseename == "" ? "" : Lesseename;
            }
            set
            {
                Lesseename = value == null ? null : value;
            }
        }
        public string Status
        {
            get
            {
                return status == null ? "" : status;
            }
            set
            {
                status = value == null ? "" : value;
            }
        }
        public string State
        {
            get
            {
                return state == null ? "" : state;
            }
            set
            {
                state = value == null ? "" : value;
            }
        }
        public string TEXT
        {
            get
            {
                return text == null ? "" : text;
            }
            set
            {
                text = value == null ? "" : value;
            }
        }
        public string VALUE
        {
            get
            {
                return values == null ? " " : values;
            }
            set
            {
                values = value == null ? " " : value;
            }
        }
        public List<InspectoinReportDetailsDataViewModel> inspectionDetails
        {
            get;

            set;

        }
        public ListTearmsAndCondition listTerms { get; set; }
    }
    public class FillDDlInspection
    {
        public List<InspectionModel> DDL { get; set; }
    }
    public class ListTearmsAndCondition
    {
        public ListTearmsAndCondition()
        {
            this.IssuanceOfNoticeId = new List<int>();
            this.remarks = new List<string>();
            this.isSatisfied = new List<int>();
        }
        public List<int> IssuanceOfNoticeId { get; set; }
        public List<string> remarks { get; set; }
        public List<int> isSatisfied { get; set; }
    }
    public class InspectoinReportDetailsDataViewModel
    {
        int ? IssuanceOfnoticeId;
        string IssuanceOfnoticeText;
        string remarks;
        public InspectoinReportDetailsDataViewModel()
        {
            this.IssuanceOfNoticeId = 0;
            this.IsSatisfied = false;
            this.Remarks = "";
            this.IssuanceOfNoticeText = "";
        }
        public int? IssuanceOfNoticeId
        {
            get
            {
                return IssuanceOfnoticeId == null ? 0 : IssuanceOfnoticeId;
            }
            set
            {
                IssuanceOfnoticeId = value == null ? 0 : value;
            }
        }
        public bool IsSatisfied { get; set; }
        public string Remarks
        {
            get
            {
                return remarks == null ? "" : remarks;
            }
            set
            {
                remarks = value == null ? "" : value;
            }
        }
        public string IssuanceOfNoticeText
        {
            get
            {
                return IssuanceOfnoticeText == null ? "" : IssuanceOfnoticeText;
            }
            set
            {
                IssuanceOfnoticeText = value == null ? "" : value;
            }
        }
    }
    public class NoticeModel
    {
        int? intUserID;
        int? roleTypeId;
        int? noticeID;
        int? noticeDetailsID;
        int? userID;
        string noticeSubject;
        string noticeDescription;
        string attatchmentName;
        string attatchmentPath;
        string fileCount;
        string srNo;
        string createdDate;
        string usersList;
        int? isView;
        string issuanceOfNoticeText;
        string issuanceOfNoticeId;
        string emailId;
        string mobileNo;
        int? isReplay;
        int? usersCount;
        int? repliedUser;
        int? isHide;
        string applicantName;
        string suspensionCopy;
        string suspensionDate;
        string status;
        string user_ID;
        string expiryDays;
        string type;
        string penaltyDate;
        string penaltyAmount;
        string fileCopy;
        string filePath;
        string userFilePath;
        string penaltyFilePath;
        string penaltyPaymentStatus;
        string timeLineOfReply;
        public int? IntUserID
        {
            get
            {
                return intUserID == null ? 0 : intUserID;
            }
            set
            {
                intUserID = value == null ? 0 : value;
            }
        }
        public int? RoleTypeId
        {
            get
            {
                return roleTypeId == null ? 0 : roleTypeId;
            }
            set
            {
                roleTypeId = value == null ? 0 : value;
            }
        }
        public int? NoticeID
        {
            get
            {
                return noticeID == null ? 0 : noticeID;
            }
            set
            {
                noticeID = value == null ? 0 : value;
            }
        }
        public int? NoticeDetailsID
        {
            get
            {
                return noticeDetailsID == null ? 0 : noticeDetailsID;
            }
            set
            {
                noticeDetailsID = value == null ? 0 : value;
            }
        }
        public int[] SelectedPriceIds { get; set; }
        public List<int?> UsersIDs { get; set; }
        public int? UserID
        {
            get
            {
                return userID == null ? 0 : userID;
            }
            set
            {
                userID = value == null ? 0 : value;
            }
        }
        public string NoticeSubject {
            get
            {
                return noticeSubject == null ? "" : noticeSubject;
            }
            set
            {
                noticeSubject = value == null ? "" : value;
            }
        }
        public string NoticeDescription
        {
            get
            {
                return noticeDescription == null ? "" : noticeDescription;
            }
            set
            {
                noticeDescription = value == null ? "" : value;
            }
        }
        public string AttatchmentName
        {
            get
            {
                return attatchmentName == null ? "" : attatchmentName;
            }
            set
            {
                attatchmentName = value == null ? "" : value;
            }
        }
        public string AttatchmentPath
        {
            get
            {
                return attatchmentPath == null ? "" : attatchmentPath;
            }
            set
            {
                attatchmentPath = value == null ? "" : value;
            }
        }
        public string FileCount
        {
            get
            {
                return fileCount == null ? "" : fileCount;
            }
            set
            {
                fileCount = value == null ? "" : value;
            }
        }
        public bool IsDraft
        {
            get;set;
        }
        public string SrNo
        {
            get
            {
                return srNo == null ? "" : srNo;
            }
            set
            {
                srNo = value == null ? "" : value;
            }
        }
        public string CreatedDate
        {
            get
            {
                return createdDate == null ? "" : createdDate;
            }
            set
            {
                createdDate = value == null ? "" : value;
            }
        }
        public string UsersList
        {
            get
            {
                return usersList == null ? "" : usersList;
            }
            set
            {
                usersList = value == null ? "" : value;
            }
        }
        public int? IsView
        {
            get
            {
                return isView == null ? 0 : isView;
            }
            set
            {
                isView = value == null ? 0 : value;
            }
        }
        public string IssuanceOfNoticeText
        {
            get
            {
                return issuanceOfNoticeText == null ? "" : issuanceOfNoticeText;
            }
            set
            {
                issuanceOfNoticeText = value == null ? "" : value;
            }
        }
        public string IssuanceOfNoticeId
        {
            get
            {
                return issuanceOfNoticeId == null ? "" : issuanceOfNoticeId;
            }
            set
            {
                issuanceOfNoticeId = value == null ? "" : value;
            }
        }
        public string EmailId
        {
            get
            {
                return emailId == null ? "" : emailId;
            }
            set
            {
                emailId = value == null ? "" : value;
            }
        }
        public string MobileNo
        {
            get
            {
                return mobileNo == null ? "" : mobileNo;
            }
            set
            {
                mobileNo = value == null ? "" : value;
            }
        }
        public int? IsReplay
        {
            get
            {
                return isReplay == null ? 0 : isReplay;
            }
            set
            {
                isReplay = value == null ? 0 : value;
            }
        }
        public string ApplicantName
        {
            get
            {
                return applicantName == null ? "" : applicantName;
            }
            set
            {
                applicantName = value == null ? "" : value;
            }
        }
        public int? UsersCount
        {
            get
            {
                return usersCount == null ? 0 : usersCount;
            }
            set
            {
                usersCount = value == null ? 0 : value;
            }
        }
        public string SuspensionCopy
        {
            get
            {
                return suspensionCopy == null ? "" : suspensionCopy;
            }
            set
            {
                suspensionCopy = value == null ? "" : value;
            }
        }
        public string SuspensionDate
        {
            get
            {
                return suspensionDate == null ? "" : suspensionDate;
            }
            set
            {
                suspensionDate = value == null ? "" : value;
            }
        }
        public string Status
        {
            get
            {
                return status == null ? "" : status;
            }
            set
            {
                status = value == null ? "" : value;
            }
        }
        public string User_ID
        {
            get
            {
                return user_ID == null ? "" : user_ID;
            }
            set
            {
                user_ID = value == null ? "" : value;
            }
        }
        public string ExpiryDays
        {
            get
            {
                return expiryDays == null ? "" : expiryDays;
            }
            set
            {
                expiryDays = value == null ? "" : value;
            }
        }
        public int? RepliedUser
        {
            get
            {
                return repliedUser == null ? 0 : repliedUser;
            }
            set
            {
                repliedUser = value == null ? 0 : value;
            }
        }
        public int? IsHide
        {
            get
            {
                return isHide == null ? 0 : isHide;
            }
            set
            {
                isHide = value == null ? 0 : value;
            }
        }
        public string Type {
            get
            {
                return type == null ? "" : type;
            }
            set
            {
                type = value == null ? "" : value;
            }
        }
        public string PenaltyDate {
            get
            {
                return penaltyDate == null ? "" : penaltyDate;
            }
            set
            {
                penaltyDate = value == null ? "" : value;
            }
        }
        public string PenaltyAmount {
            get
            {
                return penaltyAmount == null ? "" : penaltyAmount;
            }
            set
            {
                penaltyAmount = value == null ? "" : value;
            }
        }
        public string FileCopy {
            get
            {
                return fileCopy == null ? "" : fileCopy;
            }
            set
            {
                fileCopy = value == null ? "" : value;
            }
        }
        public string FilePath {
            get
            {
                return filePath == null ? "" : filePath;
            }
            set
            {
                filePath = value == null ? "" : value;
            }
        }
        public string UserFilePath {
            get
            {
                return userFilePath == null ? "" : userFilePath;
            }
            set
            {
                userFilePath = value == null ? "" : value;
            }
        }
        public string PenaltyFilePath {
            get
            {
                return penaltyFilePath == null ? "" : penaltyFilePath;
            }
            set
            {
                penaltyFilePath = value == null ? "" : value;
            }
        }
        public string PenaltyPaymentStatus {
            get
            {
                return penaltyPaymentStatus == null ? "" : penaltyPaymentStatus;
            }
            set
            {
                penaltyPaymentStatus = value == null ? "" : value;
            }
        }
        public string TimeLineOfReply {
            get
            {
                return timeLineOfReply == null ? "" : timeLineOfReply;
            }
            set
            {
                timeLineOfReply = value == null ? "" : value;
            }
        }
    }
}

