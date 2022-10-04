using EstablishmentApi.Repository;
using EstablishmentEf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApi.Model.EmpProfile
{
    public interface IEmpProfile: IDisposable, IRepository
    {
        MessageEF AddEmpProfile(EmpProfileEf objEmpProfileEf);
        Task<List<EmpDropDown>> Dropdown(EmpDropDown objEmpDropDown);
        MessageEF AddAddress(EmpProfileEf objEmpProfileEf);
        MessageEF AddPostingAddress(EmpProfileEf objEmpProfileEf);
        Task<List<EmpProfileEf>> getList(EmpProfileEf objEmpProfileEf);
        Task<EmpProfileEf> ViewDetails(EmpProfileEf objEmpProfileEf);
        //Task<EmpProfileEf> GetUserId(EmpProfileEf objEmpProfileEf);

        Task<EmpProfileEf> ViewUserInformation(EmpProfileEf objEmpProfileEf);


        #region EmployeeProfileInbox
        Task<List<EmployeeProfileInboxQuery>> ViewEmployeeProfileInbox(EmployeeProfileInboxQuery objApplyLeave);

        Task<EmployeeProfileInboxDetails> ViewEmployeeProfileInboxDetails(EmployeeProfileInboxDetails objLeaveInbox);
        MessageEF ProfileTakeAction(EmployeeProfileInboxDetails objLeave);

        //Task<List<LeaveDropDown>> BindActionType(LeaveDropDown objActionType);
        #endregion
    }
}
