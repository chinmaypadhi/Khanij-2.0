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
    public interface ILeaveAssignClassWiseModel
    {
        #region LeaveAssign class wise
        public Task<List<LeaveDropDown>> BindEmployeeClass(LeaveDropDown objLeaveDropDown);
        public Task<List<LeaveDropDown>> BindLeaveTypeClass(LeaveDropDown objLeaveDropDown);
        public MessageEF AddLeaveAssignClassWise(EstablishmentEf.LeaveAssignClassWise objApplyLeave);

        public Task<List<LeaveAssignClassWiseQuery>> ViewLeaveAssignClassWise(LeaveAssignClassWiseQuery objApplyLeave);
        public Task<EstablishmentEf.LeaveAssignClassWise> ViewLeaveAssignClassWiseDetails(EstablishmentEf.LeaveAssignClassWise objApplyLeave);

        public MessageEF DeleteLeaveAssignClassWise(EstablishmentEf.LeaveAssignClassWise objApplyLeave);


        #endregion
    }
}
