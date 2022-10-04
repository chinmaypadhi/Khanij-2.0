using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeEF;

namespace HomeApp.Areas.Website.Models.Feedback
{
    public interface IFeedbackModel
    {
        /// <summary>
        /// To add Feedback Details
        /// </summary>
        /// <param name="addFeedbackModel"></param>
        /// <returns></returns>
        MessageEF Add(AddFeedbackModel addFeedbackModel);
        /// <summary>
        /// To Update Feedback Details
        /// </summary>
        /// <param name="addFeedbackModel"></param>
        /// <returns></returns>
        MessageEF Update(AddFeedbackModel addFeedbackModel);
        /// <summary>
        /// To Edit Feedback Details
        /// </summary>
        /// <param name="addFeedbackModel"></param>
        /// <returns></returns>
        AddFeedbackModel Edit(AddFeedbackModel addFeedbackModel);
        /// <summary>
        /// To View Feedback Details
        /// </summary>
        /// <param name="viewFeedbackModel"></param>
        /// <returns></returns>
        Task<List<ViewFeedbackModel>> View(ViewFeedbackModel viewFeedbackModel);
        /// <summary>
        /// To Delete Feedback Details
        /// </summary>
        /// <param name="viewFeedbackModel"></param>
        /// <returns></returns>
        MessageEF Delete(ViewFeedbackModel viewFeedbackModel);
    }
}
