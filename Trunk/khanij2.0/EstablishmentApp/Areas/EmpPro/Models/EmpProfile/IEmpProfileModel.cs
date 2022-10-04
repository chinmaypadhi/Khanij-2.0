using EstablishmentEf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApp.Areas.EmpPro.Models.EmpProfile
{
    public interface IEmpProfileModel
    {
        MessageEF AddEmpProfile(EmpProfileEf objEmpProfileEf);
        List<EmpDropDown> Dropdown(EmpDropDown objEmpDropDown);
        MessageEF AddAddress(EmpProfileEf objEmpProfileEf);
        MessageEF AddPostingAddress(EmpProfileEf objEmpProfileEf);
        List<EmpProfileEf> getList(EmpProfileEf objEmpProfileEf);
        EmpProfileEf ViewDetails(EmpProfileEf objEmpProfileEf);
        //EmpProfileEf GetUserId(EmpProfileEf objEmpProfileEf);

        EmpProfileEf ViewUserInformation(EmpProfileEf objEmpProfileEf);

        #region EmployeeProfileInbox
        List<EmployeeProfileInboxQuery> ViewEmployeeProfileInbox(EmployeeProfileInboxQuery objEmpProfileEf);

        EmployeeProfileInboxDetails ViewEmployeeProfileInboxDetails(EmployeeProfileInboxDetails objProfile);

        //public Task<LeaveInboxDetails> ViewLeaveInboxDetails(LeaveInboxDetails objLeaveInbox);

        public MessageEF ProfileTakeAction(EmployeeProfileInboxDetails objLeave);

        public List<WorkFlowDropDown> BindActionType(WorkFlowDropDown objActionType);
        #endregion
    }
}
