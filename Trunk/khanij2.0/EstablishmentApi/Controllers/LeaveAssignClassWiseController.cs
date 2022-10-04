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
    public class LeaveAssignClassWiseController : ControllerBase
    {
        public ILeaveAssignClassWise _objILeaveManagement;
        public LeaveAssignClassWiseController(ILeaveAssignClassWise objILeaveManagement)
        {
            _objILeaveManagement = objILeaveManagement;
        }
        public async Task<List<LeaveDropDown>> BindEmployeeClass(LeaveDropDown objLeaveDropDown)
        {
            return await _objILeaveManagement.BindEmployeeClass(objLeaveDropDown);
        }

        public async Task<List<LeaveDropDown>> BindLeaveTypeClass(LeaveDropDown objLeaveDropDown)
        {
            return await _objILeaveManagement.BindLeaveTypeClass(objLeaveDropDown);
        }

        public MessageEF AddLeaveAssignClassWise(EstablishmentEf.LeaveAssignClassWise objApplyLeave)
        {
            return  _objILeaveManagement.AddLeaveAssignClassWise(objApplyLeave);
        }

        public async Task<List<LeaveAssignClassWiseQuery>> ViewLeaveAssignClassWise(LeaveAssignClassWiseQuery objApplyLeave)
        {
            return await _objILeaveManagement.ViewLeaveAssignClassWise(objApplyLeave);
        }
        public async Task<EstablishmentEf.LeaveAssignClassWise> ViewLeaveAssignClassWiseDetails(EstablishmentEf.LeaveAssignClassWise objApplyLeave)
        {
            return await _objILeaveManagement.ViewLeaveAssignClassWiseDetails(objApplyLeave);
        }

        public MessageEF DeleteLeaveAssignClassWise(EstablishmentEf.LeaveAssignClassWise objApplyLeave)
        {
            return _objILeaveManagement.DeleteLeaveAssignClassWise(objApplyLeave);
        }
    }
}
