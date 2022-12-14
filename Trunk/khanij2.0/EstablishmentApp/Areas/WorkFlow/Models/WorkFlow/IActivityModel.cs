using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstablishmentEf;

namespace EstablishmentApp.Areas.WorkFlow.Models.WorkFlow
{
    public interface IActivityModel
    {
        #region WorkFlow
        public List<WorkFlowDropDown> BindActivityDDL(WorkFlowDropDown objWorkFlow);

        public MessageEF AddWorkFlowActivity(ActivityEF objWorkFlow);

        public List<ActivityEFQuery> ViewWorkFlowActivity(ActivityEFQuery objWorkFlow);

        public ActivityEF ViewWorkFlowActivityDetails(ActivityEF objWorkFlow);
        public MessageEF DeleteWorkFlowActivity(ActivityEF objWorkFlow);
        #endregion
    }
}
