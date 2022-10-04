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

using EstablishmentEf;

namespace EstablishmentApp.Areas.LeaveManagement.Models.LeaveManagement
{
    public interface ILeaveManagementModel
    {
        #region LeaveRule
        /// <summary>
        /// Add leave rule master
        /// </summary>
        /// <param name="objLeaveRule"></param>
        /// <returns></returns>
        public MessageEF AddLeaveRuleMaster(LeaveRuleMasterEF objLeaveRule);
        /// <summary>
        /// view leave rule master
        /// </summary>
        /// <param name="objLeaveRuleMaster"></param>
        /// <returns></returns>
        public Task<List<LeaveRuleMasterEF>> ViewLeaveRuleMaster(LeaveRuleMasterEF objLeaveRuleMaster);
        /// <summary>
        /// view leave rule master details
        /// </summary>
        /// <param name="objLeaveRuleMaster"></param>
        /// <returns></returns>
        public Task<LeaveRuleMasterEF> ViewLeaveRuleMasterDetails(LeaveRuleMasterEF objLeaveRuleMaster);
        /// <summary>
        /// Delete leave rule
        /// </summary>
        /// <param name="objLeaveRule"></param>
        /// <returns></returns>
        public MessageEF DeleteLeaveRuleDetails(LeaveRuleMasterEF objLeaveRule);

        #endregion
        #region LeaveType
        /// <summary>
        /// Bind Leave Rule
        /// </summary>
        /// <param name="objRule"></param>
        /// <returns></returns>
        public Task<List<LeaveDropDown>> BindLeaveRule(LeaveDropDown objRule);

        /// <summary>
        /// Add leave type
        /// </summary>
        /// <param name="objLeaveType"></param>
        /// <returns></returns>
        public MessageEF AddLeaveTypeMaster(LeaveTypeMasterEF objLeaveType);
        /// <summary>
        /// view leave type
        /// </summary>
        /// <param name="objLeaveTypeMaster"></param>
        /// <returns></returns>
        public Task<LeaveTypeMasterEF> ViewLeaveTypeMasterDetails(LeaveTypeMasterEF objLeaveTypeMaster);
        /// <summary>
        /// view leave type master
        /// </summary>
        /// <param name="objLeaveRuleMaster"></param>
        /// <returns></returns>
        public Task<List<LeaveTypeMasterEF>> ViewLeaveTypeMaster(LeaveTypeMasterEF objLeaveTypeMaster);
        /// <summary>
        /// delete leave type 
        /// </summary>
        /// <param name="objLeaveType"></param>
        /// <returns></returns>
        public MessageEF DeleteLeaveTypeDetails(LeaveTypeMasterEF objLeaveType);
        #endregion

        #region HolidayType
        public Task<List<HolidayTypeMasterEF>> ViewHolidayTypeMaster(HolidayTypeMasterEF objHolidayTypeMaster);

        public MessageEF AddHolidayType(HolidayTypeMasterEF objHolidayType);

        public Task<HolidayTypeMasterEF> ViewHolidayTypeDetails(HolidayTypeMasterEF objHolidayTypeDetails);

        public MessageEF DeleteHolidayType(HolidayTypeMasterEF objHolidayType);
        #endregion
        #region HolidayType
        public MessageEF AddHoliday(HolidayMasterEF objHoliday);

        public Task<List<LeaveDropDown>> BindDropdown(LeaveDropDown objLeaveDropDown);

        public Task<List<HolidayMasterEF>> ViewHoliday(HolidayMasterEF objHoliday);

        public Task<HolidayMasterEF> ViewHolidayDetails(HolidayMasterEF objHoliday);

        public MessageEF DeleteHoliday(HolidayMasterEF objHoliday);
        #endregion
        #region RiderLeave
        public Task<List<LeaveDropDown>> BindDistrict(LeaveDropDown objLeaveDropDown);

        public Task<List<LeaveDropDown>> BindDesignation(LeaveDropDown objLeaveDropDown);

        public Task<List<LeaveDropDown>> BindLeaveType(LeaveDropDown objLeaveDropDown);

        public MessageEF AddRiderLeave(RiderLeave objRiderLeave);

        public Task<List<RiderLeave>> ViewRiderleave(RiderLeave objRiderLeave);

        public Task<RiderLeave> ViewRiderleaveDetails(RiderLeave objRiderLeave);

        public MessageEF DeleteRiderLeave(RiderLeave objRiderLeave);
        #endregion

        #region AAuthoritySetting
        public Task<List<LeaveDropDown>> BindState_Authority(LeaveDropDown objLeaveDropDown);
        public Task<List<LeaveDropDown>> BindDistrict_Authority(LeaveDropDown objLeaveDropDown);
        public Task<List<LeaveDropDown>> BindDepartment_Authority(LeaveDropDown objLeaveDropDown);

        public Task<List<LeaveDropDown>> BindVerifyDesignation(LeaveDropDown objLeaveDropDown);
        public Task<List<LeaveDropDown>> BindForwardDepartment_Authority(LeaveDropDown objLeaveDropDown);
        public Task<List<LeaveDropDown>> BindForwardDesignation(LeaveDropDown objLeaveDropDown);

        public Task<List<LeaveDropDown>> BindOICOfficer(LeaveDropDown objLeaveDropDown);
        public Task<List<LeaveDropDown>> BindOICApproveDesignation(LeaveDropDown objLeaveDropDown);
        public Task<List<LeaveDropDown>> BindOICApproveUser(LeaveDropDown objLeaveDropDown);

        public Task<List<LeaveDropDown>> BindNoOfDaysExceed_FirstLevel(LeaveDropDown objLeaveDropDown);
        public Task<List<LeaveDropDown>> BindNextApproveDesignation1(LeaveDropDown objLeaveDropDown);
        public Task<List<LeaveDropDown>> BindNextApproveUser1(LeaveDropDown objLeaveDropDown);


        public Task<List<LeaveDropDown>> BindNoOfDaysExceed_secondLevel(LeaveDropDown objLeaveDropDown);
        public Task<List<LeaveDropDown>> BindNextApproveDesignation2(LeaveDropDown objLeaveDropDown);
        public Task<List<LeaveDropDown>> BindNextApproveUser2(LeaveDropDown objLeaveDropDown);

        public MessageEF AddAuthoritySetting(AuthoritySetting objAuthoritySetting);

        public Task<List<AuthoritySettingQuery>> ViewAuthoritySetting(AuthoritySettingQuery objAuthoritySetting);

        public Task<AuthoritySetting> ViewAuthoritySettingDetails(AuthoritySetting objAuthoritySetting);

        public MessageEF DeleteAuthoritySetting(AuthoritySetting objAuthoritySetting);
        #endregion



        #region tribalDistrictLeave
        public MessageEF AddTribalDistrictLeave(TribalDistLeave objApplyLeave);

        public Task<List<TribalDistLeaveQuery>> ViewTribalDistrictLeave(TribalDistLeaveQuery objApplyLeave);

        public Task<TribalDistLeave> ViewTribalDistrictLeaveDetails(TribalDistLeave objApplyLeave);

        public MessageEF DeleteTribalDistrictLeave(TribalDistLeave objApplyLeave);
        #endregion

        #region userwise set authority
        public Task<List<LeaveDropDown>> BindDropDownSetAuthority(LeaveDropDown objLeaveDropDown);

        public MessageEF AddUserWiseSetAuthority(UserWiseSetAuthority objAuthoritySetting);

        public Task<UserWiseSetAuthority> ViewUserWiseSetAuthoritySettingDetails(UserWiseSetAuthority objUserWiseAuthority);
        public Task<List<UserWiseSetAuthorityChild>> ViewUserWiseSetAuthorityChild(UserWiseSetAuthority objUserWiseAuthority);

        public MessageEF RemoveUserWiseSetAuthoritychild(UserWiseSetAuthorityChild objAuthoritySetting);
        public Task<List<UserWiseSetAuthorityQuery>> ViewUserWiseSetAuthority(UserWiseSetAuthorityQuery objUserWiseAuthority);
        public MessageEF DeleteUserWiseSetAuthoritySetting(UserWiseSetAuthority objAuthoritySetting);

        #endregion

        #region ApplyLeave
        public Task<List<LeaveDropDown>> BindEmployee(LeaveDropDown objLeaveDropDown);
        public Task<List<LeaveDropDown>> BindLeaveType_ApplyLeave(LeaveDropDown objLeaveDropDown);

        //public Task<LeaveDetails> BindLeaveDetails(LeaveDetails objLeaveDetails);
        public MessageEF AddApplyLeave(ApplyLeave objApplyleave);

        public Task<List<ApplyLeaveQuery>> ViewApplyLeave(ApplyLeaveQuery objApplyLeave);

        public Task<ApplyLeave> ViewApplyLeaveDetails(ApplyLeave objApplyLeave);

        public MessageEF DeleteApplyLeave(ApplyLeave objApplyLeave);

        public Task<LeaveDetails> BindLeaveCount(LeaveDetails objLeaveDetails);
        #endregion
        #region LeaveInbox
        public Task<List<LeaveInboxQuery>> ViewLeaveInbox(LeaveInboxQuery objApplyLeave);

        public Task<LeaveInboxDetails> ViewLeaveInboxDetails(LeaveInboxDetails objLeaveInbox);

        public MessageEF TakeAction(LeaveInboxDetails objLeave);

        public List<WorkFlowDropDown> BindActionType(WorkFlowDropDown objActionType);
        #endregion
    }
}
