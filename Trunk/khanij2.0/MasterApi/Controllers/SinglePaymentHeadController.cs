using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.PaymentHead;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class SinglePaymentHeadController : ControllerBase
    {
        /// <summary>
        /// Global Declaration
        /// </summary>
        private readonly ISinglePaymentHeadProvider singlePaymentHeadProvider;
        /// <summary>
        /// Constructor Declaration
        /// </summary>
        /// <param name="singlePaymentHeadProvider"></param>
        public SinglePaymentHeadController(ISinglePaymentHeadProvider singlePaymentHeadProvider)
        {
            this.singlePaymentHeadProvider = singlePaymentHeadProvider;
        }
        /// <summary>
        /// To Add Payment Head
        /// </summary>
        /// <param name="singlePaymentHeadModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(SinglePaymentHeadModel singlePaymentHeadModel)
        {
            return singlePaymentHeadProvider.AddSinglePaymentHead(singlePaymentHeadModel);
        }
        /// <summary>
        /// To View Payment Head
        /// </summary>
        /// <param name="singlePaymentHeadModel"></param>
        /// <returns></returns>
        [HttpPost]
        public List<SinglePaymentHeadModel> ViewDetails(SinglePaymentHeadModel singlePaymentHeadModel)
        {
            return singlePaymentHeadProvider.ViewSinglePaymentHead(singlePaymentHeadModel);
        }
        /// <summary>
        /// To Edit Payment Head
        /// </summary>
        /// <param name="singlePaymentHeadModel"></param>
        /// <returns></returns>
        [HttpPost]
        public SinglePaymentHeadModel Edit(SinglePaymentHeadModel singlePaymentHeadModel)
        {
            return singlePaymentHeadProvider.EditSinglePaymentHead(singlePaymentHeadModel);
        }
        /// <summary>
        /// To Delete Payment Head
        /// </summary>
        /// <param name="singlePaymentHeadModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(SinglePaymentHeadModel singlePaymentHeadModel)
        {
            return singlePaymentHeadProvider.DeleteSinglePaymentHead(singlePaymentHeadModel);
        }
        /// <summary>
        /// To Update Payment Head 
        /// </summary>
        /// <param name="singlePaymentHeadModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(SinglePaymentHeadModel singlePaymentHeadModel)
        {
            return singlePaymentHeadProvider.UpdateSinglePaymentHead(singlePaymentHeadModel);
        }
        /// <summary>
        /// To Get District Details
        /// </summary>
        /// <param name="singlePaymentHeadModel"></param>
        /// <returns></returns>
        [HttpPost]
        public List<SinglePaymentHeadModel> DistrictDetails(SinglePaymentHeadModel singlePaymentHeadModel)
        {
            return singlePaymentHeadProvider.GetDistrict(singlePaymentHeadModel);
        }
        [HttpPost]
        public List<SinglePaymentHeadModel> HeadDataDetails(SinglePaymentHeadModel singlePaymentHeadModel)
        {
            return singlePaymentHeadProvider.GetHeadData(singlePaymentHeadModel);
        }
    }
}