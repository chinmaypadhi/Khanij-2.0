using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstablishmentApi.Model.EmpProfile;
using EstablishmentEf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EstablishmentApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class EmpProfileController : ControllerBase
    {
        public IEmpProfile _objIEmpProfile;
        public EmpProfileController(IEmpProfile objIEmpProfile)
        {
            _objIEmpProfile = objIEmpProfile;
        }
        [HttpPost]
        public MessageEF AddEmpProfile(EmpProfileEf objEmpProfileEf)
        {
            return _objIEmpProfile.AddEmpProfile(objEmpProfileEf);
        }
        [HttpPost]
        public async Task<List<EmpDropDown>> Dropdown(EmpDropDown objEmpDropDown)
        {
            return await _objIEmpProfile.Dropdown(objEmpDropDown);
        }
        [HttpPost]
        public MessageEF AddAddress(EmpProfileEf objEmpProfileEf)
        {
            return _objIEmpProfile.AddAddress(objEmpProfileEf);
        }
        [HttpPost]
        public MessageEF AddPostingAddress(EmpProfileEf objEmpProfileEf)
        {
            return _objIEmpProfile.AddPostingAddress(objEmpProfileEf);
        }
        [HttpPost]
        public async Task<List<EmpProfileEf>> getList(EmpProfileEf objEmpProfileEf)
        {
            return await _objIEmpProfile.getList(objEmpProfileEf);
        }
        [HttpPost]
        public async Task<EmpProfileEf> ViewDetails(EmpProfileEf objEmpProfileEf)
        {
            return await _objIEmpProfile.ViewDetails(objEmpProfileEf);
        }
        //[HttpPost]
        //public async Task<EmpProfileEf> GetUserId(EmpProfileEf objEmpProfileEf)
        //{
        //    return await _objIEmpProfile.GetUserId(objEmpProfileEf);
        //}
        [HttpPost]

        public async Task<EmpProfileEf> ViewUserInformation(EmpProfileEf objEmpProfileEf)
        {
            return await _objIEmpProfile.ViewUserInformation(objEmpProfileEf);
        }

        #region EmployeeProfile Inbox

        public async Task<List<EmployeeProfileInboxQuery>> ViewEmployeeProfileInbox(EmployeeProfileInboxQuery objEmpProfileEf)
        {
            return await _objIEmpProfile.ViewEmployeeProfileInbox(objEmpProfileEf);
        }

        public async Task<EmployeeProfileInboxDetails> ViewEmployeeProfileInboxDetails(EmployeeProfileInboxDetails objProfile)
        {
            return await _objIEmpProfile.ViewEmployeeProfileInboxDetails(objProfile);
        }


        public MessageEF ProfileTakeAction(EmployeeProfileInboxDetails objLeave)
        {
            return _objIEmpProfile.ProfileTakeAction(objLeave);
        }

        //public async Task<List<LeaveDropDown>> BindActionType(LeaveDropDown objActionType)
        //{
        //    return await _objILeaveManagement.BindActionType(objActionType);
        //}
        #endregion

    }
}