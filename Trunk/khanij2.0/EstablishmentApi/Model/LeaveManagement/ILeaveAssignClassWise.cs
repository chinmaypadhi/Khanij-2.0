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
    public interface ILeaveAssignClassWise : IDisposable, IRepository
    {
        #region LeaveAssignClassWise
        Task<List<LeaveDropDown>> BindEmployeeClass(LeaveDropDown objLeaveDropDown);
        Task<List<LeaveDropDown>> BindLeaveTypeClass(LeaveDropDown objLeaveDropDown);

        MessageEF AddLeaveAssignClassWise(EstablishmentEf.LeaveAssignClassWise objApplyLeave);
        Task<List<LeaveAssignClassWiseQuery>> ViewLeaveAssignClassWise(LeaveAssignClassWiseQuery objApplyLeave);

        Task<EstablishmentEf.LeaveAssignClassWise> ViewLeaveAssignClassWiseDetails(EstablishmentEf.LeaveAssignClassWise objApplyLeave);

        MessageEF DeleteLeaveAssignClassWise(EstablishmentEf.LeaveAssignClassWise objApplyLeave);
        #endregion
    }
}
