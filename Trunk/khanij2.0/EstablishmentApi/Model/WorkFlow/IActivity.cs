using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EstablishmentEf;
using EstablishmentApi.Repository;

namespace EstablishmentApi.Model.WorkFlow
{
    public interface IActivity : IDisposable, IRepository
    {
        #region LeaveAssignClassWise
        Task<List<WorkFlowDropDown>> BindActivityDDL(WorkFlowDropDown objWorkFlow);

        MessageEF AddWorkFlowActivity(ActivityEF objWorkFlow);
        Task<List<ActivityEFQuery>> ViewWorkFlowActivity(ActivityEFQuery objWorkFlow);

        Task<ActivityEF> ViewWorkFlowActivityDetails(ActivityEF objWorkFlow);

        MessageEF DeleteWorkFlowActivity(ActivityEF objWorkFlow);
        #endregion
    }
}
