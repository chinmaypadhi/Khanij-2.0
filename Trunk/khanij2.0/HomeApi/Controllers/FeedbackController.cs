// ***********************************************************************
//  Controller Name          : FeedbackProvider
//  Desciption               : Add,Select,Update,Delete Website Feedback Details 
//  Created By               : Prakash Chandra Biswal
//  Created On               : 21 Oct 2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeEF;
using HomeApi.Model.Feedback;
namespace HomeApi.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Route("api/[controller]")]
    [ApiController]
    //[Route("[controller]")]
     [ApiExplorerSettings(IgnoreApi = true)]
    public class FeedbackController : ControllerBase
    {
        /// <summary>
        /// Global Object & Variable declaration 
        /// </summary>

        public IFeedbackProvider _objfeedbackProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="feedbackProvider"></param>
        public FeedbackController(IFeedbackProvider feedbackProvider)
        {
            _objfeedbackProvider = feedbackProvider;
        }
        /// <summary>
        /// To Add Feedbadk Details
        /// </summary>
        /// <param name="addFeedbackModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(AddFeedbackModel addFeedbackModel)
        {
            return _objfeedbackProvider.AddFeedback(addFeedbackModel);
        }
        /// <summary>
        /// TO Edit Feedback Details
        /// </summary>
        /// <param name="addFeedbackModel"></param>
        /// <returns></returns>
        [HttpPost]
        public AddFeedbackModel Edit(AddFeedbackModel addFeedbackModel)
        {
            return _objfeedbackProvider.EditFeedback(addFeedbackModel);
        }
        /// <summary>
        /// To View Feedbackd Details
        /// </summary>
        /// <param name="viewFeedbackModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ViewFeedbackModel>>> View(ViewFeedbackModel viewFeedbackModel)
        {
            return await _objfeedbackProvider.ViewFeedback(viewFeedbackModel);
        }
        /// <summary>
        /// To Delete Feedback Details
        /// </summary>
        /// <param name="viewFeedbackModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(ViewFeedbackModel viewFeedbackModel)
        {
            return _objfeedbackProvider.DelteFeedback(viewFeedbackModel);
        }
        /// <summary>
        /// To Update Feedback Details
        /// </summary>
        /// <param name="addFeedbackModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update (AddFeedbackModel addFeedbackModel)
        {
            return _objfeedbackProvider.UpdateFeedback(addFeedbackModel);
        }
    }
}
