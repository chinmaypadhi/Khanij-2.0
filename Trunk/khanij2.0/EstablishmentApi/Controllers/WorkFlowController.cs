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
    public class WorkFlowController : ControllerBase
    {
        public IWorkFlow _objIWorkFlow;
        public WorkFlowController(IWorkFlow objIWorkFlow)
        {
            _objIWorkFlow = objIWorkFlow;
        }
        [HttpPost]
        public async Task<List<WorkFlowDropDown>> BindWorkFlowDDL(WorkFlowDropDown objWorkFlow)
        {

            return await _objIWorkFlow.BindWorkFlowDDL(objWorkFlow);
        }
        [HttpPost]
        public MessageEF AddWorkFlow(WorkFlowEF objWorkFlow)
        {
            return _objIWorkFlow.AddWorkFlow(objWorkFlow);
        }
        [HttpPost]
        public async Task<List<WorkFlowEFQuery>> ViewWorkFlow(WorkFlowEFQuery objWorkFlow)
        {
            return await _objIWorkFlow.ViewWorkFlow(objWorkFlow);
        }
        [HttpPost]
        public async Task<WorkFlowEF> ViewWorkFlowDetails(WorkFlowEF objWorkFlow)
        {
            return await _objIWorkFlow.ViewWorkFlowDetails(objWorkFlow);
        }
        [HttpPost]
        public async Task<List<WorkFlowTransactionEF>> ViewWorkFlowDetailsTransaction(WorkFlowEF objWorkFlow)
        {
            return await _objIWorkFlow.ViewWorkFlowDetailsTransaction(objWorkFlow);
        }
        [HttpPost]
        public MessageEF DeleteWorkFlow(WorkFlowEF objWorkFlow)
        {
            return _objIWorkFlow.DeleteWorkFlow(objWorkFlow);
        }
        [HttpPost]
        public MessageEF RemoveWorkFlowTransaction(WorkFlowTransactionEF objWorkFlow)
        {
            return _objIWorkFlow.RemoveWorkFlowTransaction(objWorkFlow);
        }
        
    }
}
