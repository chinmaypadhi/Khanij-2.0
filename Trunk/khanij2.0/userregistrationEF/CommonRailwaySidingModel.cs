using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userregistrationEF
{
    public class CRSDropDown
    {
        public int? Check { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public int? Id { get; set; }
        public int? Id2 { get; set; }
        public int? Id3 { get; set; }

    }
    public class CommonRailwaySidingModel
    {
        public int? Check { get; set; }
        public int? CRSId { get; set; }
        public int? RSId { get; set; }
        public string Area { get; set; }
        public string RSCode { get; set; }
        public string RSName { get; set; }
        public string RSAddress { get; set; }
        public string RSLatitute { get; set; }
        public string RSLongitute { get; set; }

        public int? RailwayZoneId { get; set; }
        public int? RSGradeid { get; set; }
        public string RSGradeDoc { get; set; }
        public string RsGradeDocPath { get; set; }
        public string vchRemarks { get; set; }
        public int? intStep { get; set; }
        public int? IntStatus { get; set; }
        public int? IntActionId { get; set; }
        public int? intCreatedBy { get; set; }
        public string RepresentitiveName { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }

        public int? DistrictId { get; set; }
        public string DistrictName { get; set; }
        public string LesseeList { get; set; }

        public List<int> LesseeCount { get; set; }

    }
    public class CommonRailwaySidingModel_Query
    {
        public int? Check { get; set; }
        public int? CRSId { get; set; }

        public string Area { get; set; }
        public string RailwayZone { get; set; }
        public string RailwaySiding { get; set; }
        public string RSAddress { get; set; }
        public string RSLatitute { get; set; }
        public string RSLongitute { get; set; }


        public string MineralGrade { get; set; }
        public string RSGradeDoc { get; set; }
        public string RsGradeDocPath { get; set; }
        public string vchRemarks { get; set; }

        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string LesseeList { get; set; }
        public List<int> LesseeCount { get; set; }

        public string Status { get; set; }
        public int? intStep { get; set; }

        public string RepresentitiveName { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }

        public int? DistrictId { get; set; }
        public string DistrictName { get; set; }






    }

    public class CommonRailwaySidingInboxEF_Query
    {
        private static CommonRailwaySidingInboxEF_Query instance = null;
        public static CommonRailwaySidingInboxEF_Query GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommonRailwaySidingInboxEF_Query();
                }
                return instance;
            }
        }
        private CommonRailwaySidingInboxEF_Query()
        {

        }
        public int? Check { get; set; }
        public int? CRSId { get; set; }

        public string Area { get; set; }
        public string RailwayZone { get; set; }
        public string RailwaySiding { get; set; }
        public string RSAddress { get; set; }
        public string RSLatitute { get; set; }
        public string RSLongitute { get; set; }

        public string MineralGrade { get; set; }
        public string RSGradeDoc { get; set; }
        public string RsGradeDocPath { get; set; }
        public string vchRemarks { get; set; }

        public int? intCreatedBy { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public string LesseeList { get; set; }
        public List<int> LesseeCount { get; set; }

        public string Status { get; set; }
        public int intStatus { get; set; }
        public string RepresentitiveName { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }

        public int? DistrictId { get; set; }
        public string DistrictName { get; set; }

    }

    public class CommonRailwaySidingTakeAction
    {
        private static CommonRailwaySidingTakeAction _instance = null;

        public static CommonRailwaySidingTakeAction GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CommonRailwaySidingTakeAction();
                }
                return _instance;
            }
        }
        private CommonRailwaySidingTakeAction()
        {

        }
        public int? Check { get; set; }
        public int? CRSId { get; set; }
        public string vchRemarks { get; set; }
        public int? intStatus { get; set; }

        public int? UserId { get; set; }
        public int? UserLoginId { get; set; }

        public string RepresentitiveName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public string CreatedBy { get; set; }
        public int? DistrictId { get; set; }
        public int? intCreatedBy { get; set; }

    }

    public class ExcelDataValues
    {
        public DataTable CommonRailwaySidingFile_Upload { get; set; }
    }

    public class CommonRailwaySidingFile_Upload
    {
        public int? UserId { get; set; }
        public DataTable DocumentName { get; set; }
        public string PerformanceSecurity_Installment_UploadName { get; set; }
        public string PerformanceSecurity_Installment_UploadPath { get; set; }
        public int DocId { get; set; }
        public string DocName { get; set; }
        public string PartyCode { get; set; }

        public IFormFile ExcelKharsa { get; set; }

        public string KhasraNo { get; set; }
        public string KhasraNo_FilePath { get; set; }
        public IFormFile KhasraNo_File { get; set; }
        public string ExcelKhasraNo { get; set; }
        public string ExcelKhasraNo_FilePath { get; set; }
        public string UniqNumber { get; set; }
        public string DONumber { get; set; }
        public string DODate { get; set; }
        public string SCH { get; set; }
        public decimal DOQty { get; set; }
        public string PartyName { get; set; }
        public string CollieryCode { get; set; }
        public string CollieryName { get; set; }
        public string CreatedBy { get; set; }

        public string MineralForm { get; set; }
        public string MineralGrade { get; set; }
        public string DistrictId { get; set; }
        public string DOStartDate { get; set; }
        public string DOEndDate { get; set; }
        public int? IsActive { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedOn { get; set; }
        public int? IsDelete { get; set; }
        public decimal? SalePrice { get; set; }
        public int? MineralSize { get; set; }















    }

}
