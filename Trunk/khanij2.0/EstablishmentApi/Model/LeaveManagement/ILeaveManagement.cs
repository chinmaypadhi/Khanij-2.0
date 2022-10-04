// ***********************************************************************
//  Controller Name          : LeaveManagement
//  Desciption               : Leave Management Details 
//  Created By               : Suresh Kumar Behera
//  Created On               : 13-Jul-2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EstablishmentApi.Repository;
using EstablishmentEf;


namespace EstablishmentApi.Model.LeaveManagement
{
    public interface ILeaveManagement : IDisposable, IRepository
    {
        #region leaveRule
        /// <summary>
        /// Add leave rule master
        /// </summary>
        /// <param name="objLeaveRule"></param>
        /// <returns></returns>
        MessageEF AddLeaveRuleMaster(LeaveRuleMasterEF objLeaveRule);
        /// <summary>
        /// view leave rule master
        /// </summary>
        /// <param name="objLeaveRuleMaster"></param>
        /// <returns></returns>
        Task<List<LeaveRuleMasterEF>> ViewLeaveRuleMaster(LeaveRuleMasterEF objLeaveRuleMaster);
        /// <summary>
        /// view leave rule master details
        /// </summary>
        /// <param name="objLeaveRuleMaster"></param>
        /// <returns></returns>
        Task<LeaveRuleMasterEF> ViewLeaveRuleMasterDetails(LeaveRuleMasterEF objLeaveRuleMaster);
        /// <summary>
        /// Delete leave rule
        /// </summary>
        /// <param name="objLeaveRule"></param>
        /// <returns></returns>
        MessageEF DeleteLeaveRuleDetails(LeaveRuleMasterEF objLeaveRule);

        #endregion

        #region leaveType
        /// <summary>
        /// view leave type
        /// </summary>
        /// <param name="objLeaveTypeMaster"></param>
        /// <returns></returns>
        Task<LeaveTypeMasterEF> ViewLeaveTypeMasterDetails(LeaveTypeMasterEF objLeaveTypeMaster);
        /// <summary>
        /// Add leave type
        /// </summary>
        /// <param name="objLeaveType"></param>
        /// <returns></returns>
        MessageEF AddLeaveTypeMaster(LeaveTypeMasterEF objLeaveRule);
        /// <summary>
        /// view leave type master
        /// </summary>
        /// <param name="objLeaveRuleMaster"></param>
        /// <returns></returns>
        Task<List<LeaveTypeMasterEF>> ViewLeaveTypeMaster(LeaveTypeMasterEF objLeaveRuleMaster);
        /// <summary>
        /// delete leave type 
        /// </summary>
        /// <param name="objLeaveType"></param>
        /// <returns></returns>
        MessageEF DeleteLeaveTypeDetails(LeaveTypeMasterEF objLeaveType);

        Task<List<LeaveDropDown>> BindLeaveRule(LeaveDropDown objRule);

        #endregion

        #region HolidayType
        Task<List<HolidayTypeMasterEF>> ViewHolidayTypeMaster(HolidayTypeMasterEF objHolidayTypeMaster);

        /// <summary>
        /// Add leave type
        /// </summary>
        /// <param name="objLeaveType"></param>
        /// <returns></returns>
        MessageEF AddHolidayType(HolidayTypeMasterEF objHolidayType);

        /// <summary>
        /// Add holiday type
        /// </summary>
        /// <param name="objLeaveType"></param>
        /// <returns></returns>
        Task<HolidayTypeMasterEF> ViewHolidayTypeDetails(HolidayTypeMasterEF objHolidayTypeDetails);


        /// <summary>
        /// Delete holiday type
        /// </summary>
        /// <param name="objLeaveType"></param>
        /// <returns></returns>
        MessageEF DeleteHolidayType(HolidayTypeMasterEF objHolidayType);
        #endregion

        #region Holiday
        MessageEF AddHoliday(HolidayMasterEF objHoliday);

        Task<List<LeaveDropDown>> BindDropdown(LeaveDropDown objLeaveDropDown);

        Task<List<HolidayMasterEF>> ViewHoliday(HolidayMasterEF objHoliday);

        Task<HolidayMasterEF> ViewHolidayDetails(HolidayMasterEF objHoliday);
        MessageEF DeleteHoliday(HolidayMasterEF objHoliday);

        #endregion

        #region RiderLeave
        Task<List<LeaveDropDown>> BindDistrict(LeaveDropDown objLeaveDropDown);
        Task<List<LeaveDropDown>> BindDesignation(LeaveDropDown objLeaveDropDown);

        Task<List<LeaveDropDown>> BindLeaveType(LeaveDropDown objLeaveDropDown);

        MessageEF AddRiderLeave(RiderLeave objRiderLeave);

        Task<List<RiderLeave>> ViewRiderleave(RiderLeave objRiderLeave);

        Task<RiderLeave> ViewRiderleaveDetails(RiderLeave objRiderLeave);
        MessageEF DeleteRiderLeave(RiderLeave objRiderLeave);
        #endregion

        #region AuthoritySetting
        Task<List<LeaveDropDown>> BindState_Authority(LeaveDropDown objLeaveDropDown);
        Task<List<LeaveDropDown>> BindDepartment_Authority(LeaveDropDown objLeaveDropDown);
        Task<List<LeaveDropDown>> BindDistrict_Authority(LeaveDropDown objLeaveDropDown);

        Task<List<LeaveDropDown>> BindVerifyDesignation(LeaveDropDown objLeaveDropDown);
        Task<List<LeaveDropDown>> BindForwardDepartment_Authority(LeaveDropDown objLeaveDropDown);
        Task<List<LeaveDropDown>> BindForwardDesignation(LeaveDropDown objLeaveDropDown);


        Task<List<LeaveDropDown>> BindOICOfficer(LeaveDropDown objLeaveDropDown);
        Task<List<LeaveDropDown>> BindOICApproveDesignation(LeaveDropDown objLeaveDropDown);
        Task<List<LeaveDropDown>> BindOICApproveUser(LeaveDropDown objLeaveDropDown);


        Task<List<LeaveDropDown>> BindNoOfDaysExceed_FirstLevel(LeaveDropDown objLeaveDropDown);
        Task<List<LeaveDropDown>> BindNextApproveDesignation1(LeaveDropDown objLeaveDropDown);
        Task<List<LeaveDropDown>> BindNextApproveUser1(LeaveDropDown objLeaveDropDown);

        Task<List<LeaveDropDown>> BindNoOfDaysExceed_secondLevel(LeaveDropDown objLeaveDropDown);
        Task<List<LeaveDropDown>> BindNextApproveDesignation2(LeaveDropDown objLeaveDropDown);
        Task<List<LeaveDropDown>> BindNextApproveUser2(LeaveDropDown objLeaveDropDown);

        MessageEF AddAuthoritySetting(AuthoritySetting objAuthoritySetting);

        Task<List<AuthoritySettingQuery>> ViewAuthoritySetting(AuthoritySettingQuery objAuthoritySetting);

        Task<AuthoritySetting> ViewAuthoritySettingDetails(AuthoritySetting objAuthoritySetting);

        MessageEF DeleteAuthoritySetting(AuthoritySetting objAuthoritySetting);
        #endregion

        #region ApplyLeave
        Task<List<LeaveDropDown>> BindEmployee(LeaveDropDown objLeaveDropDown);
        Task<List<LeaveDropDown>> BindLeaveType_ApplyLeave(LeaveDropDown objLeaveDropDown);

        Task<LeaveDetails> BindLeaveCount(LeaveDetails objLeaveDetails);
        MessageEF AddApplyLeave(ApplyLeave objApplyLeave);
        Task<List<ApplyLeaveQuery>> ViewApplyLeave(ApplyLeaveQuery objApplyLeave);
        Task<ApplyLeave> ViewApplyLeaveDetails(ApplyLeave objApplyLeave);
        MessageEF DeleteApplyLeave(ApplyLeave objApplyLeave);
        #endregion

        #region TribalDistLeave
        MessageEF AddTribalDistrictLeave(TribalDistLeave objApplyLeave);

        Task<List<TribalDistLeaveQuery>> ViewTribalDistrictLeave(TribalDistLeaveQuery objApplyLeave);

        Task<TribalDistLeave> ViewTribalDistrictLeaveDetails(TribalDistLeave objApplyLeave);

        MessageEF DeleteTribalDistrictLeave(TribalDistLeave objApplyLeave);
        #endregion

        #region userwise authority
        Task<List<LeaveDropDown>> BindDropDownSetAuthority(LeaveDropDown objLeaveDropDown);
        MessageEF AddUserWiseSetAuthority(UserWiseSetAuthority objAuthoritySetting);

        Task<UserWiseSetAuthority> ViewUserWiseSetAuthoritySettingDetails(UserWiseSetAuthority objUserWiseAuthority);

        Task<List<UserWiseSetAuthorityChild>> ViewUserWiseSetAuthorityChild(UserWiseSetAuthority objUserWiseAuthority);

        MessageEF RemoveUserWiseSetAuthoritychild(UserWiseSetAuthorityChild objAuthoritySetting);

        Task<List<UserWiseSetAuthorityQuery>> ViewUserWiseSetAuthority(UserWiseSetAuthorityQuery objUserWiseAuthority);

        MessageEF DeleteUserWiseSetAuthoritySetting(UserWiseSetAuthority objAuthoritySetting);
        #endregion

        #region LeaveInbox
        Task<List<LeaveInboxQuery>> ViewLeaveInbox(LeaveInboxQuery objApplyLeave);

        Task<LeaveInboxDetails> ViewLeaveInboxDetails(LeaveInboxDetails objLeaveInbox);
        MessageEF TakeAction(LeaveInboxDetails objLeave);

        Task<List<LeaveDropDown>> BindActionType(LeaveDropDown objActionType);
        #endregion

        #region ProcessFlow

        //Task<List<LeaveDropDown>> BindSubModuleName(LeaveDropDown objLeaveDropDown);
        //Task<List<LeaveDropDown>> BindAction(LeaveDropDown objLeaveDropDown);

        #endregion ProcessFlow
    }
}
