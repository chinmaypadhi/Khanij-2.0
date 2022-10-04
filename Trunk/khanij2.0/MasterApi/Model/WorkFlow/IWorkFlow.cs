using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MasterEF;
using MasterApi.Repository;

namespace MasterApi.Model.WorkFlow
{
    public interface IWorkFlow : IDisposable, IRepository
    {
        #region LeaveAssignClassWise
        Task<List<WorkFlowDropDown>> BindWorkFlowDDL(WorkFlowDropDown objWorkFlow);
        MessageEF AddWorkFlow(WorkFlowEF objWorkFlow);
        Task<List<WorkFlowEFQuery>> ViewWorkFlow(WorkFlowEFQuery objWorkFlow);

        Task<List<WorkFlowAuthorityLogEF>> ViewActionTakingAuthority(WorkFlowAuthorityLogEF objWorkFlow);
        Task<WorkFlowEF> ViewWorkFlowDetails(WorkFlowEF objWorkFlow);
        Task<List<WorkFlowTransactionEF>> ViewWorkFlowDetailsTransaction(WorkFlowEF objWorkFlow);
        MessageEF DeleteWorkFlow(WorkFlowEF objWorkFlow);
        MessageEF RemoveWorkFlowTransaction(WorkFlowTransactionEF objWorkFlow);


        Task<List<WorkFlowDropDown>> BindActionType(WorkFlowDropDown objWorkFlow);

        #endregion
    }
}
