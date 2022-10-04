using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MasterEF;

namespace MasterApp.Areas.WorkFlowEngine.Models.WorkFlow
{
    public interface IWorkFlowModel
    {
        public List<WorkFlowDropDown> BindWorkFlowDDL(WorkFlowDropDown objWorkFlow);
        public List<WorkFlowDropDown> BindActivityDDL(WorkFlowDropDown objWorkFlow);
        public List<WorkFlowDropDown> BindDropDownSetAuthority(WorkFlowDropDown objWorkFlow);

        public MessageEF AddWorkFlow(WorkFlowEF objWorkFlow);
        public List<WorkFlowEFQuery> ViewWorkFlow(WorkFlowEFQuery objWorkFlow);
        public List<WorkFlowAuthorityLogEF> ViewActionTakingAuthority(WorkFlowAuthorityLogEF objWorkFlow);
        public WorkFlowEF ViewWorkFlowDetails(WorkFlowEF objWorkFlow);



        public List<WorkFlowTransactionEF> ViewWorkFlowDetailsTransaction(WorkFlowEF objWorkFlow);
        public MessageEF DeleteWorkFlow(WorkFlowEF objWorkFlow);
        public MessageEF RemoveWorkFlowTransaction(WorkFlowTransactionEF objWorkFlow);
    }
}
