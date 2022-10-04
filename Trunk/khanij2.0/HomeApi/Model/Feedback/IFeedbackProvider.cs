// ***********************************************************************
//  Interface Name               : IFeedbackProvider
//  Desciption               : Add,Select,Update,Delete Website Feedback Details 
//  Created By               : Prakash Chandra Biswal
//  Created On               : 21 Oct 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeEF;

namespace HomeApi.Model.Feedback
{
   public interface IFeedbackProvider:IDisposable
    {
        /// <summary>
        /// To Add Feedback Details
        /// </summary>
        /// <param name="addFeedbackModel"></param>
        /// <returns></returns>
        MessageEF AddFeedback(AddFeedbackModel addFeedbackModel);
        /// <summary>
        /// To View Feedback Details
        /// </summary>
        /// <param name="viewFeedbackModel"></param>
        /// <returns></returns>
        Task<List<ViewFeedbackModel>> ViewFeedback(ViewFeedbackModel viewFeedbackModel);
        /// <summary>
        /// To Edit Feedback Details
        /// </summary>
        /// <param name="addFeedbackModel"></param>
        /// <returns></returns>
        AddFeedbackModel EditFeedback(AddFeedbackModel addFeedbackModel);
        /// <summary>
        /// To Delete Feedbadk Details
        /// </summary>
        /// <param name="viewFeedbackModel"></param>
        /// <returns></returns>
        MessageEF DelteFeedback(ViewFeedbackModel viewFeedbackModel);
        /// <summary>
        /// To Update Feedback Details
        /// </summary>
        /// <param name="addFeedbackModel"></param>
        /// <returns></returns>
        MessageEF UpdateFeedback(AddFeedbackModel addFeedbackModel);
    }
}
