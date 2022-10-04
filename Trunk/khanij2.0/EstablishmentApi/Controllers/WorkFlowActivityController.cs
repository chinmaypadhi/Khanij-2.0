using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EstablishmentEf;
using EstablishmentApi.Model.WorkFlow;
using Microsoft.AspNetCore.Authorization;

namespace EstablishmentApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class WorkFlowActivityController : ControllerBase
    {
        public IActivity _objIActivity;
        public WorkFlowActivityController(IActivity objIWorkFlow)
        {
            _objIActivity = objIWorkFlow;
        }
        [HttpPost]
        public async Task<List<WorkFlowDropDown>> BindActivityDDL(WorkFlowDropDown objWorkFlow)
        {
            return await _objIActivity.BindActivityDDL(objWorkFlow);
        }

        [HttpPost]
        public MessageEF AddWorkFlowActivity(ActivityEF objWorkFlow)
        {
            return _objIActivity.AddWorkFlowActivity(objWorkFlow);
        }
        [HttpPost]
        public async Task<List<ActivityEFQuery>> ViewWorkFlowActivity(ActivityEFQuery objWorkFlow)
        {
            return await _objIActivity.ViewWorkFlowActivity(objWorkFlow);
        }
        [HttpPost]
        public async Task<ActivityEF> ViewWorkFlowActivityDetails(ActivityEF objWorkFlow)
        {
            return await _objIActivity.ViewWorkFlowActivityDetails(objWorkFlow);
        }
        [HttpPost]
        public MessageEF DeleteWorkFlowActivity(ActivityEF objWorkFlow)
        {
            return _objIActivity.DeleteWorkFlowActivity(objWorkFlow);
        }
    }
}
