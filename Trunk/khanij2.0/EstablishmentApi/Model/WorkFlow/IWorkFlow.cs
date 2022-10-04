using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EstablishmentEf;
using EstablishmentApi.Repository;

namespace EstablishmentApi.Model.WorkFlow
{
    public interface IWorkFlow : IDisposable, IRepository
    {
        #region LeaveAssignClassWise
        Task<List<WorkFlowDropDown>> BindWorkFlowDDL(WorkFlowDropDown objWorkFlow);
        MessageEF AddWorkFlow(WorkFlowEF objWorkFlow);

        Task<List<WorkFlowEFQuery>> ViewWorkFlow(WorkFlowEFQuery objWorkFlow);
        Task<WorkFlowEF> ViewWorkFlowDetails(WorkFlowEF objWorkFlow);
        Task<List<WorkFlowTransactionEF>> ViewWorkFlowDetailsTransaction(WorkFlowEF objWorkFlow);
        MessageEF DeleteWorkFlow(WorkFlowEF objWorkFlow);
        MessageEF RemoveWorkFlowTransaction(WorkFlowTransactionEF objWorkFlow);
        #endregion
    }
}
