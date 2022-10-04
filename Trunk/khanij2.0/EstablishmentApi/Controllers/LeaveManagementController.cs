// ***********************************************************************
//  Controller Name          : LeaveManagement
//  Desciption               : Leave Management Details 
//  Created By               : Suresh Kumar Behera
//  Created On               : 13-Jul-2021
// ***********************************************************************
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using EstablishmentEf;
using EstablishmentApi.Model.LeaveManagement;
using Microsoft.AspNetCore.Authorization;

namespace EstablishmentApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class LeaveManagementController : ControllerBase
    {
        public ILeaveManagement _objILeaveManagement;
        public LeaveManagementController(ILeaveManagement objILeaveManagement)
        {
            _objILeaveManagement = objILeaveManagement;
        }

        #region LevaeRule
        /// <summary>
        /// Add Leave Rule Details
        /// </summary>
        /// <param name="objLeaveRuleMasterEF"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF AddLeaveRuleMaster(LeaveRuleMasterEF objLeaveRuleMasterEF)
        {
            return _objILeaveManagement.AddLeaveRuleMaster(objLeaveRuleMasterEF);
        }
        /// <summary>
        /// View leave rule master
        /// </summary>
        /// <param name="objLeaveRuleMaster"></param>
        /// <returns></returns>
        /// 

        [HttpPost]
        public async Task<List<LeaveRuleMasterEF>> ViewLeaveRuleMaster(LeaveRuleMasterEF objLeaveRuleMaster)
        {
            return await _objILeaveManagement.ViewLeaveRuleMaster(objLeaveRuleMaster);
        }
        /// <summary>
        /// view leave rule details
        /// </summary>
        /// <param name="objLeaveRuleMaster"></param>
        /// <returns></returns>

        public async Task<LeaveRuleMasterEF> ViewLeaveRuleMasterDetails(LeaveRuleMasterEF objLeaveRuleMaster)
        {
            return await _objILeaveManagement.ViewLeaveRuleMasterDetails(objLeaveRuleMaster);
        }
        /// <summary>
        ///  delete Leave Rule Details
        /// </summary>
        /// <param name="objLeaveRule"></param>
        /// <returns></returns>
        public MessageEF DeleteLeaveRuleDetails(LeaveRuleMasterEF objLeaveRule)
        {
            return _objILeaveManagement.DeleteLeaveRuleDetails(objLeaveRule);
        }

        #endregion

        #region LeaveType
        /// <summary>
        /// Bind Leave Rule
        /// </summary>
        /// <param name="objRule"></param>
        /// <returns></returns>
        public async Task<List<LeaveDropDown>> BindLeaveRule(LeaveDropDown objRule)
        {
            return await _objILeaveManagement.BindLeaveRule(objRule);
        }
        /// <summary>
        ///  Add/Update Leave Type Details
        /// </summary>
        /// <param name="objLeaveType"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF AddLeaveTypeMaster(LeaveTypeMasterEF objLeaveType)
        {
            return _objILeaveManagement.AddLeaveTypeMaster(objLeaveType);
        }
        /// <summary>
        /// Leave Type Details
        /// </summary>
        /// <param name="objLeaveRuleMaster"></param>
        /// <returns></returns>
        public async Task<LeaveTypeMasterEF> ViewLeaveTypeMasterDetails(LeaveTypeMasterEF objLeaveRuleMaster)
        {
            return await _objILeaveManagement.ViewLeaveTypeMasterDetails(objLeaveRuleMaster);
        }
        /// <summary>
        /// View Leave Type Details
        /// </summary>
        /// <param name="objLeaveTypeMaster"></param>
        /// <returns></returns>
        public async Task<List<LeaveTypeMasterEF>> ViewLeaveTypeMaster(LeaveTypeMasterEF objLeaveTypeMaster)
        {
            return await _objILeaveManagement.ViewLeaveTypeMaster(objLeaveTypeMaster);
        }
        /// <summary>
        ///  delete Leave Type Details
        /// </summary>
        /// <param name="objLeaveType"></param>
        /// <returns></returns>
        public MessageEF DeleteLeaveTypeDetails(LeaveTypeMasterEF objLeaveType)
        {
            return _objILeaveManagement.DeleteLeaveTypeDetails(objLeaveType);
        }
        #endregion

        #region HolidayType
        public async Task<List<HolidayTypeMasterEF>> ViewHolidayTypeMaster(HolidayTypeMasterEF objHolidayTypeMaster)
        {
            return await _objILeaveManagement.ViewHolidayTypeMaster(objHolidayTypeMaster);
        }

        public MessageEF AddHolidayType(HolidayTypeMasterEF objHolidayType)
        {
            return _objILeaveManagement.AddHolidayType(objHolidayType);
        }

        public async Task<HolidayTypeMasterEF> ViewHolidayTypeDetails(HolidayTypeMasterEF objHolidayTypeDetails)
        {
            return await _objILeaveManagement.ViewHolidayTypeDetails(objHolidayTypeDetails);
        }

        public MessageEF DeleteHolidayType(HolidayTypeMasterEF objHolidayType)
        {
            return _objILeaveManagement.DeleteHolidayType(objHolidayType);
        }
        #endregion

        #region Holiday

        public MessageEF AddHoliday(HolidayMasterEF objHoliday)
        {
            return _objILeaveManagement.AddHoliday(objHoliday);
        }
        [HttpPost]
        public async Task<List<LeaveDropDown>> BindDropdown(LeaveDropDown objEmpDropDown)
        {
            return await _objILeaveManagement.BindDropdown(objEmpDropDown);
        }
        [Authorize]
        [HttpPost]
        public async Task<List<HolidayMasterEF>> ViewHoliday(HolidayMasterEF objHoliday)
        {
            return await _objILeaveManagement.ViewHoliday(objHoliday);
        }

        public async Task<HolidayMasterEF> ViewHolidayDetails(HolidayMasterEF objHoliday)
        {
            return await _objILeaveManagement.ViewHolidayDetails(objHoliday);
        }

        public MessageEF DeleteHoliday(HolidayMasterEF objHoliday)
        {
            return _objILeaveManagement.DeleteHoliday(objHoliday);
        }
        #endregion

        #region RiderLeave
        public async Task<List<LeaveDropDown>> BindDistrict(LeaveDropDown objLeaveDropDown)
        {
            return await _objILeaveManagement.BindDistrict(objLeaveDropDown);
        }

        public async Task<List<LeaveDropDown>> BindDesignation(LeaveDropDown objLeaveDropDown)
        {
            return await _objILeaveManagement.BindDesignation(objLeaveDropDown);
        }

        public async Task<List<LeaveDropDown>> BindLeaveType(LeaveDropDown objLeaveDropDown)
        {
            return await _objILeaveManagement.BindLeaveType(objLeaveDropDown);
        }

        public MessageEF AddRiderLeave(RiderLeave objRiderLeave)
        {
            return _objILeaveManagement.AddRiderLeave(objRiderLeave);
        }

        //[Authorize]
        public async Task<List<RiderLeave>> ViewRiderleave(RiderLeave objRiderLeave)
        {
            return await _objILeaveManagement.ViewRiderleave(objRiderLeave);
        }

        public async Task<RiderLeave> ViewRiderleaveDetails(RiderLeave objRiderLeave)
        {
            return await _objILeaveManagement.ViewRiderleaveDetails(objRiderLeave);
        }
        public MessageEF DeleteRiderLeave(RiderLeave objRiderLeave)
        {
            return _objILeaveManagement.DeleteRiderLeave(objRiderLeave);
        }
        #endregion

        #region AuthoritySetting
        public async Task<List<LeaveDropDown>> BindState_Authority(LeaveDropDown objLeaveDropDown)
        {
            return await _objILeaveManagement.BindState_Authority(objLeaveDropDown);
        }
        public async Task<List<LeaveDropDown>> BindDepartment_Authority(LeaveDropDown objLeaveDropDown)
        {
            return await _objILeaveManagement.BindDepartment_Authority(objLeaveDropDown);
        }
        public async Task<List<LeaveDropDown>> BindDistrict_Authority(LeaveDropDown objLeaveDropDown)
        {
            return await _objILeaveManagement.BindDistrict_Authority(objLeaveDropDown);
        }

        public async Task<List<LeaveDropDown>> BindVerifyDesignation(LeaveDropDown objLeaveDropDown)
        {
            return await _objILeaveManagement.BindVerifyDesignation(objLeaveDropDown);
        }
        public async Task<List<LeaveDropDown>> BindForwardDepartment_Authority(LeaveDropDown objLeaveDropDown)
        {
            return await _objILeaveManagement.BindForwardDepartment_Authority(objLeaveDropDown);
        }

        public async Task<List<LeaveDropDown>> BindForwardDesignation(LeaveDropDown objLeaveDropDown)
        {
            return await _objILeaveManagement.BindForwardDesignation(objLeaveDropDown);
        }


        public async Task<List<LeaveDropDown>> BindOICOfficer(LeaveDropDown objLeaveDropDown)
        {
            return await _objILeaveManagement.BindOICOfficer(objLeaveDropDown);
        }
        public async Task<List<LeaveDropDown>> BindOICApproveDesignation(LeaveDropDown objLeaveDropDown)
        {
            return await _objILeaveManagement.BindOICApproveDesignation(objLeaveDropDown);
        }
        public async Task<List<LeaveDropDown>> BindOICApproveUser(LeaveDropDown objLeaveDropDown)
        {
            return await _objILeaveManagement.BindOICApproveUser(objLeaveDropDown);
        }


        public async Task<List<LeaveDropDown>> BindNoOfDaysExceed_FirstLevel(LeaveDropDown objLeaveDropDown)
        {
            return await _objILeaveManagement.BindNoOfDaysExceed_FirstLevel(objLeaveDropDown);
        }
        public async Task<List<LeaveDropDown>> BindNextApproveDesignation1(LeaveDropDown objLeaveDropDown)
        {
            return await _objILeaveManagement.BindNextApproveDesignation1(objLeaveDropDown);
        }

        public async Task<List<LeaveDropDown>> BindNextApproveUser1(LeaveDropDown objLeaveDropDown)
        {
            return await _objILeaveManagement.BindNextApproveUser1(objLeaveDropDown);
        }


        public async Task<List<LeaveDropDown>> BindNoOfDaysExceed_secondLevel(LeaveDropDown objLeaveDropDown)
        {
            return await _objILeaveManagement.BindNoOfDaysExceed_secondLevel(objLeaveDropDown);
        }
        public async Task<List<LeaveDropDown>> BindNextApproveDesignation2(LeaveDropDown objLeaveDropDown)
        {
            return await _objILeaveManagement.BindNextApproveDesignation2(objLeaveDropDown);
        }

        public async Task<List<LeaveDropDown>> BindNextApproveUser2(LeaveDropDown objLeaveDropDown)
        {
            return await _objILeaveManagement.BindNextApproveUser2(objLeaveDropDown);
        }

        public MessageEF AddAuthoritySetting(AuthoritySetting objAuthoritySetting)
        {
            return _objILeaveManagement.AddAuthoritySetting(objAuthoritySetting);
        }

        public async Task<List<AuthoritySettingQuery>> ViewAuthoritySetting(AuthoritySettingQuery objAuthoritySetting)
        {
            return await _objILeaveManagement.ViewAuthoritySetting(objAuthoritySetting);
        }

        public async Task<AuthoritySetting> ViewAuthoritySettingDetails(AuthoritySetting objAuthoritySetting)
        {
            return await _objILeaveManagement.ViewAuthoritySettingDetails(objAuthoritySetting);
        }

        public MessageEF DeleteAuthoritySetting(AuthoritySetting objAuthoritySetting)
        {
            return _objILeaveManagement.DeleteAuthoritySetting(objAuthoritySetting);
        }
        #endregion

        #region ApplyLeave

        public async Task<List<LeaveDropDown>> BindEmployee(LeaveDropDown objLeaveDropDown)
        {
            return await _objILeaveManagement.BindLeaveType_ApplyLeave(objLeaveDropDown);
        }
        public async Task<List<LeaveDropDown>> BindLeaveType_ApplyLeave(LeaveDropDown objLeaveDropDown)
        {
            return await _objILeaveManagement.BindLeaveType_ApplyLeave(objLeaveDropDown);
        }

        public async Task<LeaveDetails> BindLeaveCount(LeaveDetails objLeaveDetails)
        {
            return await _objILeaveManagement.BindLeaveCount(objLeaveDetails);
        }


        public MessageEF AddApplyLeave(ApplyLeave objApplyleave)
        {
            return _objILeaveManagement.AddApplyLeave(objApplyleave);
        }

        public async Task<List<ApplyLeaveQuery>> ViewApplyLeave(ApplyLeaveQuery objApplyLeave)
        {
            return await _objILeaveManagement.ViewApplyLeave(objApplyLeave);
        }

        public async Task<ApplyLeave> ViewApplyLeaveDetails(ApplyLeave objApplyLeave)
        {
            return await _objILeaveManagement.ViewApplyLeaveDetails(objApplyLeave);
        }


        public MessageEF DeleteApplyLeave(ApplyLeave objApplyLeave)
        {
            return _objILeaveManagement.DeleteApplyLeave(objApplyLeave);
        }
        #endregion

        #region TribalDistrictLeave

        public MessageEF AddTribalDistrictLeave(TribalDistLeave objApplyLeave)
        {
            return _objILeaveManagement.AddTribalDistrictLeave(objApplyLeave);
        }

        public async Task<List<TribalDistLeaveQuery>> ViewTribalDistrictLeave(TribalDistLeaveQuery objApplyLeave)
        {
            return await _objILeaveManagement.ViewTribalDistrictLeave(objApplyLeave);
        }


        public async Task<TribalDistLeave> ViewTribalDistrictLeaveDetails(TribalDistLeave objApplyLeave)
        {
            return await _objILeaveManagement.ViewTribalDistrictLeaveDetails(objApplyLeave);
        }

        public MessageEF DeleteTribalDistrictLeave(TribalDistLeave objApplyLeave)
        {
            return _objILeaveManagement.DeleteTribalDistrictLeave(objApplyLeave);
        }
        #endregion

        #region userwise set authority
        public async Task<List<LeaveDropDown>> BindDropDownSetAuthority(LeaveDropDown objLeaveDropDown)
        {
            return await _objILeaveManagement.BindDropDownSetAuthority(objLeaveDropDown);
        }
        public MessageEF AddUserWiseSetAuthority(UserWiseSetAuthority objAuthoritySetting)
        {
            return _objILeaveManagement.AddUserWiseSetAuthority(objAuthoritySetting);
        }

        public async Task<UserWiseSetAuthority> ViewUserWiseSetAuthoritySettingDetails(UserWiseSetAuthority objUserWiseAuthority)
        {
            return await _objILeaveManagement.ViewUserWiseSetAuthoritySettingDetails(objUserWiseAuthority);
        }

        public async Task<List<UserWiseSetAuthorityChild>> ViewUserWiseSetAuthorityChild(UserWiseSetAuthority objUserWiseAuthority)
        {
            return await _objILeaveManagement.ViewUserWiseSetAuthorityChild(objUserWiseAuthority);
        }


        public MessageEF RemoveUserWiseSetAuthoritychild(UserWiseSetAuthorityChild objAuthoritySetting)
        {
            return  _objILeaveManagement.RemoveUserWiseSetAuthoritychild(objAuthoritySetting);
        }

        public async Task<List<UserWiseSetAuthorityQuery>> ViewUserWiseSetAuthority(UserWiseSetAuthorityQuery objUserWiseAuthority)
        {
            return await _objILeaveManagement.ViewUserWiseSetAuthority(objUserWiseAuthority);
        }

        public MessageEF DeleteUserWiseSetAuthoritySetting(UserWiseSetAuthority objAuthoritySetting)
        {
            return  _objILeaveManagement.DeleteUserWiseSetAuthoritySetting(objAuthoritySetting);
        }
        #endregion
   
        #region leaveInbox
        public async Task<List<LeaveInboxQuery>> ViewLeaveInbox(LeaveInboxQuery objApplyLeave)
        {
            return await _objILeaveManagement.ViewLeaveInbox(objApplyLeave);
        }

        public async Task<LeaveInboxDetails> ViewLeaveInboxDetails(LeaveInboxDetails objLeaveInbox)
        {
            return await _objILeaveManagement.ViewLeaveInboxDetails(objLeaveInbox);
        }

        public MessageEF TakeAction(LeaveInboxDetails objLeave)
        {
            return _objILeaveManagement.TakeAction(objLeave);
        }

        public async Task<List<LeaveDropDown>> BindActionType(LeaveDropDown objActionType)
        {
            return await _objILeaveManagement.BindActionType(objActionType);
        }
        #endregion

    }
}
