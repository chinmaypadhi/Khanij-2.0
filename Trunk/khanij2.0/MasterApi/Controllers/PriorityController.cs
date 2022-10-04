using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.PriorityMaster;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class PriorityController : ControllerBase
    {
        /// <summary>
        /// Global Decalaration
        /// </summary>
        public IPriorityProvider _objIPriorityProvider;
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        /// <param name="objPriorityProvider"></param>
        public PriorityController(IPriorityProvider objPriorityProvider)
        {
            _objIPriorityProvider = objPriorityProvider;
        }
        /// <summary>
        /// To Add Priority Master
        /// </summary>
        /// <param name="objPrioritymaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(Prioritymaster objPrioritymaster)
        {
            return _objIPriorityProvider.AddPriorityMaster(objPrioritymaster);
        }
        /// <summary>
        /// To View Priority Master
        /// </summary>
        /// <param name="objPrioritymaster"></param>
        /// <returns></returns>
        [HttpPost]
        public List<Prioritymaster> View(Prioritymaster objPrioritymaster)
        {
            return _objIPriorityProvider.ViewPriorityMaster(objPrioritymaster);
        }
        /// <summary>
        /// To Edit Priority Master
        /// </summary>
        /// <param name="objPrioritymaster"></param>
        /// <returns></returns>
        [HttpPost]
        public Prioritymaster Edit(Prioritymaster objPrioritymaster)
        {
            return _objIPriorityProvider.EditPriorityMaster(objPrioritymaster);
        }
        /// <summary>
        /// To Delete Priority Master
        /// </summary>
        /// <param name="objPrioritymaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(Prioritymaster objPrioritymaster)
        {
            return _objIPriorityProvider.DeletePriorityMaster(objPrioritymaster);
        }
        /// <summary>
        /// To Update Priority Master
        /// </summary>
        /// <param name="objPrioritymaster"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(Prioritymaster objPrioritymaster)
        {
            return _objIPriorityProvider.UpdatePriorityMaster(objPrioritymaster);
        }
    }
}