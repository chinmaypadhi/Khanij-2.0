
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.Rule;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class RuleMasterController : ControllerBase
    {
        /// <summary>
        /// Global Declaration
        /// </summary>
        public IRuleMasterProvider _objIRuleMasterProvider;
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        /// <param name="objRuleMasterProvider"></param>
        public RuleMasterController(IRuleMasterProvider objRuleMasterProvider)
        {
            _objIRuleMasterProvider = objRuleMasterProvider;
        }
        /// <summary>
        /// To Add Rule Master
        /// </summary>
        /// <param name="objRulemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(RuleMaster objRulemaster)
        {
            return _objIRuleMasterProvider.AddRuleMaster(objRulemaster);
        }
        /// <summary>
        /// To View Rule Master
        /// </summary>
        /// <param name="objRulemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<RuleMaster> View(RuleMaster objRulemaster)
        {
            return _objIRuleMasterProvider.ViewRuleMaster(objRulemaster);
        }
        /// <summary>
        /// To Edit Rule Master
        /// </summary>
        /// <param name="objRulemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public RuleMaster Edit(RuleMaster objRulemaster)
        {
            return _objIRuleMasterProvider.EditRulemaster(objRulemaster);
        }
        /// <summary>
        /// To Delete Rule Master
        /// </summary>
        /// <param name="objRulemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(RuleMaster objRulemaster)
        {
            return _objIRuleMasterProvider.DeleteRulemaster(objRulemaster);
        }
        /// <summary>
        /// To Update Rule Master
        /// </summary>
        /// <param name="objRulemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(RuleMaster objRulemaster)
        {
            return _objIRuleMasterProvider.UpdateRulemaster(objRulemaster);
        }
        [HttpPost]
        public string test()
        {
            return "test";
        }
    }
}
