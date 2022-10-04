using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeApp.Models.Utility;
using HomeEF;
using Newtonsoft.Json;

namespace HomeApp.Areas.Website.Models.Feedback
{
    public class FeedbackModel:IFeedbackModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public FeedbackModel(IOptions<KeyList> objKeyList,IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// To Add Feedback Details
        /// </summary>
        /// <param name="addFeedbackModel"></param>
        /// <returns></returns>
        public MessageEF Add(AddFeedbackModel addFeedbackModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Feedback/Add", JsonConvert.SerializeObject(addFeedbackModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Update Feedback Details
        /// </summary>
        /// <param name="addFeedbackModel"></param>
        /// <returns></returns>
        public MessageEF Update(AddFeedbackModel addFeedbackModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Feedback/Update", JsonConvert.SerializeObject(addFeedbackModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Edit Feedback Details
        /// </summary>
        /// <param name="addFeedbackModel"></param>
        /// <returns></returns>
        public AddFeedbackModel Edit(AddFeedbackModel addFeedbackModel)
        {
            try
            {
                addFeedbackModel = JsonConvert.DeserializeObject<AddFeedbackModel>(_objIHttpWebClients.PostRequest("Feedback/Edit", JsonConvert.SerializeObject(addFeedbackModel)));
                return addFeedbackModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To View Feedbadk Details
        /// </summary>
        /// <param name="viewFeedbackModel"></param>
        /// <returns></returns>
        public async Task<List<ViewFeedbackModel>> View(ViewFeedbackModel viewFeedbackModel)
        {
            try
            {
                List<ViewFeedbackModel> objlistFeedback = new List<ViewFeedbackModel>();
                objlistFeedback = JsonConvert.DeserializeObject<List<ViewFeedbackModel>>(await _objIHttpWebClients.AwaitPostRequest("Feedback/View", JsonConvert.SerializeObject(viewFeedbackModel)));
                return objlistFeedback;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Delete Feedback Details
        /// </summary>
        /// <param name="viewFeedbackModel"></param>
        /// <returns></returns>
        public MessageEF Delete(ViewFeedbackModel viewFeedbackModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Feedback/Delete", JsonConvert.SerializeObject(viewFeedbackModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
