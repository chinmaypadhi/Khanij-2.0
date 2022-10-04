using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Http;

namespace EstablishmentEf
{
    public class EmpProfileEf
    {
        public string Satus { get; set; }
        public int? intEmployeeid { get; set; }
        public string VchEmployeeid { get; set; }
        public string VchName { get; set; }
        public string VchFatherName { get; set; }
        public string VchEmployeeType { get; set; }
        public string VchAadharNumber { get; set; }
        public string VchAadharCard { get; set; }
        public int? Intdesignation { get; set; }
        public string VchCategory { get; set; }
        public int? IntClass { get; set; }
        public string EmployeeClass { get; set; }
        public string VchMobileNo { get; set; }
        public string VchEmailid { get; set; }
        public string DateDateofbirth { get; set; }
        public int? IntHomeSate { get; set; }
        public int? IntHomeDistrict { get; set; }
        public string VchGender { get; set; }
        public string VchMaritalStatus { get; set; }
        public string VchSignature { get; set; }
        public string VchPhoto { get; set; }
        public int? intApproveStatus { get; set; }

        public bool BitdeletedFlage { get; set; }
        public int? intCreatedBy { get; set; }
        public string dateCreatedOn { get; set; }
public int? UserLoginId { get; set; }
        //public bool IsLoginExists { get; set; }
        //public int? UserId { get; set; }
        //public string UserName { get; set; }
        //

        //public string Password { get; set; }
        //public string EncryptPassword { get; set; }


        public int? IntStep { get; set; }
        public int? IntStatus { get; set; }
        public int? IntActionId { get; set; }
        public string Status { get; set; }

        public string VchRemarks { get; set; }

        //Posting
        public int? intPostingid { get; set; }
        public int? intPostingDepartment { get; set; }
        public int? intPostingDistrict { get; set; }
        public int? IntOfficeLevel { get; set; }

        public string DateOfJoining { get; set; }
        public string DateOfRetirement { get; set; }
        public int? intEstablishmentoffice { get; set; }
        public string VchModeofRecruitment { get; set; }
        public string DecPayBand { get; set; }
        public decimal DecBasicPay { get; set; }
        public decimal DecGradePay { get; set; }


        //Address 
        public int? intAddressId { get; set; }
        public int? intPresentState { get; set; }
        public int? intPresentDistrict { get; set; }
        public string vchPresentAddress { get; set; }
        public string vchPresentPINCode { get; set; }
        public int? intPermanentState { get; set; }
        public int? intPermanentDistrict { get; set; }
        public string vchPermanentAddress { get; set; }
        public string vchPermanentPINCode { get; set; }
        public string VchEmail { get; set; }
        public string VchPhoneno { get; set; }

        public int? intSection { get; set; }

        //public IFormFile fileAadharCard { get; set; }
        public string VchAadharCardPath { get; set; }

        //public IFormFile fileVchPhoto { get; set; }
        public string VchPhotoPath { get; set; }

        //public IFormFile fileSignature { get; set; }
        public string VchSignaturePath { get; set; }

    }
    public class EmpDropDown
    {
        public string Action { get; set; }
        public string Text { get; set; }
        public string value { get; set; }
        public int? Stateid { get; set; }
    }

    sealed class EmployeeTakeAction
    {
        private static EmployeeTakeAction _instance = null;
        public static EmployeeTakeAction GetInstance()
        {
            if (_instance == null)
            {
                _instance = new EmployeeTakeAction();
            }
            return _instance;
        }

        //private EmployeeTakeAction()
        //{ }
        public int Id { get; set; }
        public int intEmployeeid { get; set; }
        public int intStep { get; set; }
        public int intStatus { get; set; }
        public int ActionId { get; set; }
        public string vchRemarks { get; set; }
        public int intActionTakenBy { get; set; }
        public int intCreatedBy { get; set; }


    }

    #region EmployeeProfileInbox
    public sealed class EmployeeProfileInboxQuery
    {
        private static EmployeeProfileInboxQuery _instance = null;
        public static EmployeeProfileInboxQuery GetInstance()
        {
            if (_instance == null)
            {
                _instance = new EmployeeProfileInboxQuery();
            }
            return _instance;
        }
        //private EmployeeProfileInboxQuery() { }
        public int Check { get; set; }
        public int intEmployeeid { get; set; }
        public int intModuleId { get; set; }
        public int intSubModuleId { get; set; }

        public string EmployeeName { get; set; }
        public string VchGender { get; set; }
        public string VchEmployeeType { get; set; }
        public string VchFatherName { get; set; }
        public string DateDateofbirth { get; set; }

        public string VchAadharCard { get; set; }
        public string VchMobileNo { get; set; }

        public string dateCreatedOn { get; set; }
        public string Status { get; set; }

        public string PrimaryAuthority { get; set; }
        public string VchRemarks { get; set; }

        public int intCreatedBy { get; set; }


    }
    public sealed class EmployeeProfileInboxDetails
    {
        private static EmployeeProfileInboxDetails _instance = null;
        public static EmployeeProfileInboxDetails GetInstance()
        {
            if (_instance == null)
            {
                _instance = new EmployeeProfileInboxDetails();
            }
            return _instance;
        }
        //private EmployeeProfileInboxDetails()
        //{ 
        
        //}

        public int Check { get; set; }
        public int intModuleId { get; set; }
        public int intSubModuleId { get; set; }

        public int intEmployeeid { get; set; }
        public string EmployeeName { get; set; }
        public string VchGender { get; set; }
        public string VchEmployeeType { get; set; }
        public string VchFatherName { get; set; }
        public string DateDateofbirth { get; set; }

        public string VchAadharCard { get; set; }
        public string VchMobileNo { get; set; }
 public string VchEmailid { get; set; }

        public string dateCreatedOn { get; set; }
        public string Status { get; set; }
        public int intStatus { get; set; }
        public int intStep { get; set; }
        public int IntActionId { get; set; }
        public string EmployeeClass { get; set; }

        public string PostingDistrict { get; set; }

        public string Designation { get; set; }
public string Department { get; set; }
        public string OfficeLevel { get; set; }
        public string ModeofRecruitment { get; set; }
        public string VchRemarks { get; set; }

        public int intCreatedBy { get; set; }


    }

    #endregion
}
