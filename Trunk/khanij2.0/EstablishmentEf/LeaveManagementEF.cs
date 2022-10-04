using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;

namespace EstablishmentEf
{
    public class LeaveManagementEF
    {
        public int RuleId { get; set; }
        public string RuleName { get; set; }
        public string RuleNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int CreatedBy { get; set; }

    }

    public class LeaveRuleMasterEF
    {

        public int Check { get; set; }
        public int RuleId { get; set; }
        public string RuleName { get; set; }
        public string RuleNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public class LeaveTypeMasterEF
    {
        public int Check { get; set; }
        public int RuleId { get; set; }
        public string RuleNo { get; set; }
        public int LeaveTypeId { get; set; }
        public string LeaveType { get; set; }

        public int NoOfLeave { get; set; }
        public bool BitIncludeHoliday { get; set; }
        public string Description { get; set; }
        public bool BitCarryForward { get; set; }
        public bool IsDelete { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public bool BitDocRequired { get; set; }
        public bool BitPerMonthLeave { get; set; }
        public int intPerMonthLeave { get; set; }
    }

    #region leaveHolidayType
    public class HolidayTypeMasterEF
    {
        public int Check { get; set; }
        public int HolidayTypeId { get; set; }
        public string HolidayTypeName { get; set; }
        public bool HolidayType { get; set; }
        public bool IsDelete { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    #endregion

    #region Holiday
    public class HolidayMasterEF
    {
        public int Check { get; set; }
        public int? HolidayId { get; set; }
        public string HolidayName { get; set; }

        public int HolidayTypeId { get; set; }
        public string HolidayTypeName { get; set; }

        public string HolidayDate { get; set; }
        public bool IsDelete { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }


    #endregion

    #region RiderLeave

    public class RiderLeave
    {
        public int Check { get; set; }
        public int RiderLeaveId { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int DesignationId { get; set; }
        public string Designation { get; set; }
        public int LeaveTypeId { get; set; }
        public string LeaveType { get; set; }
        public int NoOfDays { get; set; }
        public string Remarks { get; set; }
        public bool IsDocumentRequired { get; set; }
        public bool IsDelete { get; set; }
        public int CreatedBy { get; set; }


    }
    #endregion

    #region Authority
    public class AuthoritySetting
    {
        public int Check { get; set; }
        public int intAuthorityId { get; set; }

        public int intStateId { get; set; }

        public int intDepartmentId { get; set; }
        public int intDistrictId { get; set; }

        public int intVerifyDesignationId { get; set; }
        public int intForwardDepartmentId { get; set; }
        public int intForwardDesignationId { get; set; }

        public int intOicOfficerId { get; set; }
        public int intOicApproveDesignationId { get; set; }
        public int intOicApproveUserId { get; set; }

        public int intDaysExceed1 { get; set; }
        public int intNextApprovedDesignationId1 { get; set; }
        public int intNextApprovedUserId1 { get; set; }
        //public string NextApprovedUser1 { get; set; }

        public int intDaysExceed2 { get; set; }
        public int intNextApprovedDesignationId2 { get; set; }
        public int intNextApprovedUserId2 { get; set; }
        //public string NextApprovedUser2 { get; set; }

        //public bool bitDeleted { get; set; }
        public int intCreatedBy { get; set; }

    }

    public class AuthoritySettingQuery
    {
        public int Check { get; set; }
        public int intAuthorityId { get; set; }

        public string StateName { get; set; }
        public string Department { get; set; }
        public string DistrictName { get; set; }

        public string VerifyDesignation { get; set; }
        public string ForwardDepartment { get; set; }
        public string ForwardDesignation { get; set; }

        public string OicOfficer { get; set; }
        public string OicApproveDesignation { get; set; }
        public string OicApproveUser { get; set; }

        public int intDaysExceed1 { get; set; }
        public string NextApprovedDesignation1 { get; set; }
        public string NextApprovedUser1 { get; set; }

        public int intDaysExceed2 { get; set; }
        public string NextApprovedDesignation2 { get; set; }
        public string NextApprovedUser2 { get; set; }

    }
    #endregion

    #region ApplyLeave
    public class ApplyLeave
    {
        public int Check { get; set; }
        public int intLeaveId { get; set; }
        public int intEmployeeId { get; set; }
        public int intLeaveTypeId { get; set; }

        public string dtFromDate { get; set; }
        public bool bitFromHalfDay { get; set; }
        public int intFromHalfDay { get; set; }


        public string dtToDate { get; set; }
        public bool bitToHalfDay { get; set; }
        public int intToHalfDay { get; set; }

        public decimal NoOfDays { get; set; }

        public string varReason { get; set; }
        public string varOffice { get; set; }
        public string varSection { get; set; }
        public string varPay { get; set; }
        public string varHouseAndRentAllowance { get; set; }
        public string varSundayHoliday { get; set; }
        public string varProposedToAvail { get; set; }
        public string varChildName { get; set; }
        public string dtChildDOB { get; set; }
        public bool bitPermissionRequired { get; set; }
        public string dtDateOfReturn { get; set; }
        public int intCreatedBy { get; set; }
        public int intStep { get; set; }
        public int intStatus { get; set; }



    }

    public class ApplyLeaveQuery
    {
        public int Check { get; set; }
        public int intLeaveId { get; set; }

        public string EmployeeName { get; set; }
        public string LeaveType { get; set; }
        public string varReason { get; set; }
        public string dtFromDate { get; set; }
        public string dtToDate { get; set; }

        public decimal? NoOfDays { get; set; }
        public int? intStatus { get; set; }
        public string Status { get; set; }
        public string AppliedOn { get; set; }
        public string Designation { get; set; }
        public string OfficeLevel { get; set; }
        public string ActionTakenTo { get; set; }
        public int? ActionId { get; set; }
        public int? intStep { get; set; }
        public int? intCreatedBy { get; set; }

        public int? intModuleId { get; set; }
        public int? intSubModuleId { get; set; }
    }

    public class LeaveDetails
    {

        public int intLeaveTypeId { get; set; }
        public int intEmployeeId { get; set; }
        public int Check { get; set; }
        public decimal leaves_total { get; set; }
        public decimal leaves_taken { get; set; }
        public decimal leaves_waiting_for_approval { get; set; }
        public decimal leaves_remaining { get; set; }
    }
    #endregion

    #region LeaveAssign

    public class LeaveAssignClassWise
    {
        public int Check { get; set; }
        public int intId { get; set; }
        public int intLeaveTypeId { get; set; }
        public int intClassId { get; set; }
        public decimal decNoOfDays { get; set; }
        public int intCreatedBy { get; set; }
    }

    public class LeaveAssignClassWiseQuery
    {
        public int Check { get; set; }
        public int intId { get; set; }
        public string EmployeeClass { get; set; }
        public string LeaveType { get; set; }
        public decimal decNoOfDays { get; set; }

    }
    #endregion


    #region TribalDistLeave
    public class TribalDistLeave
    {
        public int Check { get; set; }
        public int intTribalLeaveid { get; set; }
        public int intLeaveTypeId { get; set; }
        public int IntDistrictId { get; set; }
        public int intNoOfLeave { get; set; }
        public int intCreatedBy { get; set; }
    }

    public class TribalDistLeaveQuery
    {
        public int Check { get; set; }
        public int intTribalLeaveid { get; set; }
        public string LeaveType { get; set; }
        public string District { get; set; }
        public int intNoOfLeave { get; set; }

    }
    #endregion

    #region User Wise Authority
    public class UserWiseSetAuthority
    {
        public int Check { get; set; }
        public int intAuthorityId { get; set; }

        public int intEmpStateId { get; set; }

        public int intEmpDepartmentId { get; set; }
        public int intEmpOfficeLevelId { get; set; }

        public int intEmpDesignationId { get; set; }
        public int intEmployeeId { get; set; }
        public int intStep { get; set; }

        public int intPrimaryOfficeLevelId { get; set; }
        public int intPrimaryDesignationId { get; set; }
        public int intPrimaryAuthorityUserId { get; set; }

        public int intSecondaryOfficeLevelid { get; set; }
        public int intSecondaryDesignationId { get; set; }
        public int intSecondaryAuthorityUserId { get; set; }
        public int intCreatedBy { get; set; }

        public bool IsSameUser { get; set; }

        public List<UserWiseSetAuthorityChild> childAuthority = new List<UserWiseSetAuthorityChild>();

    }

    public class UserWiseSetAuthorityChild
    {
        public int Check { get; set; }
        public int? intChildId { get; set; }
        public int? intAuthorityId { get; set; }
        public int intStep { get; set; }
        public int intPrimaryOfficeLevelId { get; set; }
        public int intPrimaryDesignationId { get; set; }
        public int intPrimaryAuthorityUserId { get; set; }

        public string PrimaryAuthorityUser { get; set; }

        public int intSecondaryOfficeLevelid { get; set; }
        public int intSecondaryDesignationId { get; set; }
        public int intSecondaryAuthorityUserId { get; set; }
        public string SecondaryAuthorityUser { get; set; }
        public bool IsSameUser { get; set; }
        public int intCreatedBy { get; set; }
    }
    public class UserWiseSetAuthorityQuery
    {
        public int Check { get; set; }
        public int intAuthorityId { get; set; }

        public string StateName { get; set; }
        public string Department { get; set; }
        public string OfficeLevel { get; set; }
        public string EmployeeDesignation { get; set; }
        public string EmployeeName { get; set; }

        public int intStep { get; set; }
        public string PrimaryAuthorityUser { get; set; }
        public string SecondaryAuthorityUser { get; set; }



    }
    #endregion

    #region leaveInbox
    public class LeaveInboxQuery
    {
        public int Check { get; set; }
        public int intLeaveId { get; set; }

        public string EmployeeName { get; set; }
        public string LeaveType { get; set; }
        public string dtFromDate { get; set; }
        public string dtToDate { get; set; }

        public decimal? NoOfDays { get; set; }
        public string varReason { get; set; }
        public string Status { get; set; }

        public string PrimaryAuthority { get; set; }
        public string SecondaryAuthority { get; set; }

        public int intCreatedBy { get; set; }

        public string AppliedOn { get; set; }
        public string Designation { get; set; }
        public string OfficeLevel { get; set; }
        public string ActionTakenTo { get; set; }
    }
    public class LeaveInboxDetails
    {
        public int Check { get; set; }
        public int intLeaveId { get; set; }

        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }

        public string PostingDistrict { get; set; }
        public string Designation { get; set; }
        public string EmployeeClass { get; set; }
        public string OfficeLevel { get; set; }

        public string ModeofRecruitment { get; set; }
        public string VchMobileNo { get; set; }
        public string VchEmailid { get; set; }
        public string LeaveType { get; set; }

        public string dtFromDate { get; set; }
        public string dtToDate { get; set; }

        public decimal? NoOfDays { get; set; }
        public string varReason { get; set; }
        public string Status { get; set; }
        public int intStatus { get; set; }

        public int intStep { get; set; }
        public int intActionId { get; set; }
        public string vchRemarks { get; set; }
        public int intCreatedBy { get; set; }
    }

    #endregion

     public class LeaveDropDown
    {
        public int? Check { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public int? Id { get; set; }
        public int? Id2 { get; set; }
        public int? Id3 { get; set; }

    }
}
