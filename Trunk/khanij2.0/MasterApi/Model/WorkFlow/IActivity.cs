using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MasterEF;
using MasterApi.Repository;

namespace MasterApi.Model.WorkFlow
{
    public interface IActivity : IDisposable, IRepository
    {
        #region LeaveAssignClassWise
        Task<List<WorkFlowDropDown>> BindDropDownSetAuthority(WorkFlowDropDown objLeaveDropDown);

        Task<List<WorkFlowDropDown>> BindActivityDDL(WorkFlowDropDown objWorkFlow);

        MessageEF AddWorkFlowActivity(ActivityEF objWorkFlow);
        Task<List<ActivityEFQuery>> ViewWorkFlowActivity(ActivityEFQuery objWorkFlow);

        Task<ActivityEF> ViewWorkFlowActivityDetails(ActivityEF objWorkFlow);

        MessageEF DeleteWorkFlowActivity(ActivityEF objWorkFlow);
        #endregion
    }
}
