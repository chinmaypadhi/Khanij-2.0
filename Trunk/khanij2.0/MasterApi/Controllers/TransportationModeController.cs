using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.TransportationMode;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class TransportationModeController : ControllerBase
    {
        /// <summary>
        /// Global Declaration
        /// </summary>
        public ITransportationModeProvider _objITransportationProvider;
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        /// <param name="objITransportationProvider"></param>
        public TransportationModeController(ITransportationModeProvider objITransportationProvider)
        {
            _objITransportationProvider = objITransportationProvider;
        }
        /// <summary>
        /// To Add Transportation Mode
        /// </summary>
        /// <param name="objTR"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(TransportationModeMaster objTR)
        {
            return _objITransportationProvider.AddTransportationMode(objTR);
        }
        /// <summary>
        /// To View Transportation Mode
        /// </summary>
        /// <param name="objTR"></param>
        /// <returns></returns>
        [HttpPost]
        public List<TransportationModeMaster> View(TransportationModeMaster objTR)
        {
            return _objITransportationProvider.ViewTransportationMode(objTR);
        }
        /// <summary>
        /// To Edit Transportation Mode
        /// </summary>
        /// <param name="objTR"></param>
        /// <returns></returns>
        [HttpPost]
        public TransportationModeMaster Edit(TransportationModeMaster objTR)
        {
            return _objITransportationProvider.EditTransportationMode(objTR);
        }
        /// <summary>
        /// To Delete Transportation Mode
        /// </summary>
        /// <param name="objTR"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(TransportationModeMaster objTR)
        {
            return _objITransportationProvider.DeleteTransportationMode(objTR);
        }
        /// <summary>
        /// To Update Transportation Mode
        /// </summary>
        /// <param name="objTR"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(TransportationModeMaster objTR)
        {
            return _objITransportationProvider.UpdateTransportationMode(objTR);
        }
    }
}