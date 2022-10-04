using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.StateMaster;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class StateMasterController : ControllerBase
    {
        /// <summary>
        /// Global Declaration
        /// </summary>
        public IStateMasterProvider _objIStateMasterProvider;
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        /// <param name="objStateMasterProvider"></param>
        public StateMasterController(IStateMasterProvider objStateMasterProvider)
        {
            _objIStateMasterProvider = objStateMasterProvider;
        }
        /// <summary>
        /// To Add State 
        /// </summary>
        /// <param name="objStatemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(Statemaster objStatemaster)
        {
            return _objIStateMasterProvider.AddStateMaster(objStatemaster);
        }
        /// <summary>
        /// To View State Master
        /// </summary>
        /// <param name="objStatemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<Statemaster> View(Statemaster objStatemaster)
        {
            return _objIStateMasterProvider.ViewStateMaster(objStatemaster);
        }
        /// <summary>
        /// To Edit State Master
        /// </summary>
        /// <param name="objStatemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public Statemaster Edit(Statemaster objStatemaster)
        {
            return _objIStateMasterProvider.EditStatemaster(objStatemaster);
        }
        /// <summary>
        /// To Delete State
        /// </summary>
        /// <param name="objStatemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(Statemaster objStatemaster)
        {
            return _objIStateMasterProvider.DeleteStatemaster(objStatemaster);
        }
        /// <summary>
        /// To Update State
        /// </summary>
        /// <param name="objStatemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(Statemaster objStatemaster)
        {
            return _objIStateMasterProvider.UpdateStatemaster(objStatemaster);
        }
        [HttpPost]
        public string test()
        {
            return "test";
        }
    }
}
